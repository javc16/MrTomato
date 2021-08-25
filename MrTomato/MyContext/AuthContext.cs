using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MrTomato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.MyContext
{
    public class AuthContext:IdentityDbContext
    {
        public AuthContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}
