
using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class UpdateRequestConfiguration : IEntityTypeConfiguration<UpdateRequest>
    {
        public void Configure(EntityTypeBuilder<UpdateRequest> builder)
        {
            builder.ToTable("UpdateRequest");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            //ORM
            builder.HasOne(x => x.AppUser).WithMany(x => x.UpdateRequests).HasForeignKey(x => x.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            



        }
    }
}
