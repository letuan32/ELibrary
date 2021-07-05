using ELibrary_Team_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("Users");


            //builder.HasMany(x => x.UserVotes).WithOne(x => x.AppUser).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasMany(x => x.AccessRequests).WithOne(x => x.AppUser).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasMany(x => x.UpdateRequests).WithOne(x => x.AppUser).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            


        }
          
        //
    }
}
