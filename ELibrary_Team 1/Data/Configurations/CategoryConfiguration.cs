using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
         
            //ORM
            builder.HasMany(x => x.DocumentCategories).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId)/*.OnDelete(DeleteBehavior.SetNull)*/;
            

        }
    }
}
