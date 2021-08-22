using Microsoft.EntityFrameworkCore;
using MrTomato.Models;
using MrTomato.MyContext.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.MyContext
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
     




        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=DESKTOP-AICR3S2;Database=MrTomato;User Id=sa;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
