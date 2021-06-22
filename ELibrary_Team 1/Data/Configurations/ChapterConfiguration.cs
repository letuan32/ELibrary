using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class ChapterConfiguration: IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("Chapters");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);

            //ORM
            builder.HasOne(x => x.Document).WithMany(x => x.Chapters).HasForeignKey(x => x.DocumentId)/*.OnDelete(DeleteBehavior.SetNull)*/;



        }
    }
}
