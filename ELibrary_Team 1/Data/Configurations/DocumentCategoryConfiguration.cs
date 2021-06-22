using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class DocumentCategoryConfiguration : IEntityTypeConfiguration<DocumentCategory>
    {
        public void Configure(EntityTypeBuilder<DocumentCategory> builder)
        {
            builder.ToTable("DocumentCategorys");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            //ORM
            builder.HasOne(x => x.Category).WithMany(x => x.DocumentCategories).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Document).WithMany(x => x.DocumentCategories).HasForeignKey(x => x.DocumentId)/*.OnDelete(DeleteBehavior.NoAction)*/;




        }
    }
}
