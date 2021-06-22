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
            modelBuilder.ApplyConfiguration(new RateConfiguration());
            modelBuilder.ApplyConfiguration(new UpdateRequestConfiguration());

            /// Customize Identity Table Name
            modelBuilder.Entity<IdentityRole<string>>().ToTable("AppRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens");

            modelBuilder.Seed();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AccessRequest> AccessRequests { get; set; }
       
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentCategory> DocumentCategories { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<UpdateRequest> UpdateRequests { get; set; }

    }
}
