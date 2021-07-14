using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class AccessRequestConfiguration : IEntityTypeConfiguration<AccessRequest>
    {
        public void Configure(EntityTypeBuilder<AccessRequest> builder)
        {

            builder.ToTable("AccessRequests");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsAccept).IsRequired(true).HasDefaultValue(false).ValueGeneratedOnAdd();
            builder.HasOne(x => x.AppUser).WithMany(x => x.AccessRequests).HasForeignKey(x => x.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
      
        }
        //
    }
}


