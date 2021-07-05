using ELibrary.Data.Configurations;

using ELibrary.Data.Extensions;
using ELibrary_Team_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace ELibrary.Data
{
    public class ELibraryDbContext : IdentityDbContext<AppUser>
    {

        public ELibraryDbContext(DbContextOptions<ELibraryDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ChapterConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AccessRequestConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new UserVoteConfiguration());
            modelBuilder.ApplyConfiguration(new UpdateRequestConfiguration());

            /// Customize Identity Table Name


            modelBuilder.Seed();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AccessRequest> AccessRequests { get; set; }
       
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentCategory> DocumentCategories { get; set; }
        public DbSet<UserVote> UserVotes { get; set; }
        public DbSet<UpdateRequest> UpdateRequests { get; set; }
       

    }
}
