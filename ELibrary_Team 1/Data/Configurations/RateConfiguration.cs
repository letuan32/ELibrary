using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable("Rates");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            //ORM
            builder.HasOne(x => x.Document).WithMany(x => x.Rates).HasForeignKey(x => x.DocumentId)/*.OnDelete(DeleteBehavior.Cascade)*/;
            builder.HasOne(x => x.AppUser).WithMany(x => x.Rates).HasForeignKey(x =>x.UserId)/*.OnDelete(DeleteBehavior.Cascade)*/;


            



        }
    }
}
