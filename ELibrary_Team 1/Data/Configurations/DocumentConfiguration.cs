using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");
            builder.HasKey(x => x.Id);
           
          
            
            //ORM
            //builder.HasMany(x => x.DocumentCategories).WithOne(x => x.Document).HasForeignKey(x => x.DocumentId);
            //builder.HasMany(x => x.Chapters).WithOne(x => x.Document).HasForeignKey(x => x.DocumentId)/*.OnDelete(DeleteBehavior.Cascade)*/;
            //builder.HasMany(x => x.AccessRequests).WithOne(x => x.Document).HasForeignKey(x => x.DocumentId)/*.OnDelete(DeleteBehavior.Cascade)*/;
            //builder.HasMany(x => x.UserVotes).WithOne(x => x.Document).HasForeignKey(x => x.DocumentId)/*.OnDelete(DeleteBehavior.Cascade)*/;



        }
    }
}
