using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Configurations
{
    public class UserVoteConfiguration : IEntityTypeConfiguration<UserVote>
    {
        public void Configure(EntityTypeBuilder<UserVote> builder)
        {
            builder.ToTable("UserVotes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            //ORM
            builder.HasOne(x => x.Document).WithMany(x => x.UserVotes).HasForeignKey(x => x.DocumentId)/*.OnDelete(DeleteBehavior.Cascade)*/;
            builder.HasOne(x => x.AppUser).WithMany(x => x.UserVotes).HasForeignKey(x => x.UserId)/*.OnDelete(DeleteBehavior.Cascade)*/;






        }
    }
}
