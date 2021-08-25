using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MrTomato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.MyContext.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "dbo");
            builder.HasKey(x=>x.id);
            builder.Property(x=>x.id).IsRequired().UseIdentityColumn();
            builder.Property(x=>x.name).IsRequired();
            builder.Property(x => x.description).HasColumnType("varchar(max)");
            builder.Property(x => x.role).HasColumnType("varchar(max)");
            builder.Property(x => x.isActive);
        }
    }
}