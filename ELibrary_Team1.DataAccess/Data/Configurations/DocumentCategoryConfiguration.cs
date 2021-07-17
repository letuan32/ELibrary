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
            builder.HasKey(x => new { x.CategoryId, x.DocumentId });

            //ORM
            builder.HasOne(x => x.Category).WithMany(x => x.DocumentCategories).HasForeignKey(x => x.CategoryId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Document).WithMany(x => x.DocumentCategories).HasForeignKey(x => x.DocumentId).IsRequired().OnDelete(DeleteBehavior.Cascade);




        }
    }
}
