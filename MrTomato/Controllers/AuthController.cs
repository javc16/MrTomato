using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MrTomato.Helpers;
using MrTomato.Models;
using MrTomato.Models.DTO;
using MrTomato.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Response>> CreateUser([FromBody]UserDTO request)
        {
            var result = await _authService.RegisterUser(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Response>> Login([FromBody] LoginDTO request)
        {
            var result = await _authService.Login(request);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]      
        public async Task<ActionResult<Response>> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var result = await _authService.GetUserProfile(userId);
            return Ok(result);

        }

    }
}
