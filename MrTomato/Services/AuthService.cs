using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MrTomato.Helpers;
using MrTomato.Models;
using MrTomato.Models.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MrTomato.Services
{
    public class AuthService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly ApplicationSettingsDTO _appSettings;
        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<ApplicationSettingsDTO> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        public async Task<Response> RegisterUser(UserDTO user)
        {
            user.role = "Normal";
            var applicationUser = new User()
            {
                UserName = user.username,
                Email = user.email,
                name = user.name,
            };
            var result = await _userManager.CreateAsync(applicationUser, user.password);
            await _userManager.AddToRoleAsync(applicationUser,user.role);
            if (result.Errors.Count() == 0) 
            {
                return new Response
                {
                    Status = "Sucess",
                    Message = "User Added sucefully",
                    Data = result
                    
                };
            }

            return new Response
            {
                Status = "Failed",
                Message = "Information Error",
                Data = result
            };

        }


 
        public async Task<Response> Login(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return new Response 
                {
                    Status= "Sucess",
                    Message="Login Correctly",
                    Data = token
                };
            }
            else
                return new Response
                {
                    Status = "Failed",
                    Message = "Username or password is incorrect.",
                   
                }; 
        }

    
        public async Task<Response> GetUserProfile(string userId)
        {           
            var user = await _userManager.FindByIdAsync(userId);
            if (user!=null) 
            {
                UserDTO userInformation = new UserDTO
                {
                    name = user.name,
                    email = user.Email,
                    username = user.UserName,
                };
                return new Response
                {
                    Status = "Sucess",
                    Message = "User information get it Correctly",
                    Data = userInformation
                }; 
            }


            return new Response
            {
                Status = "Failed",
                Message = "Username does not exists!.",

            };


        }
    }
}
