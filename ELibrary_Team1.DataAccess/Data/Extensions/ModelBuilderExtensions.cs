
using ELibrary_Team_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        // Applying Seed Data To The Database --- learnentityframeworkcore
        public static void Seed(this ModelBuilder modelBuilder)
        {

            // Identity
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "1",
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",
                    AccessFailedCount = 5,
                    TwoFactorEnabled = false,
                    PhoneNumberConfirmed = false,
                    EmailConfirmed = false,

                }
            );
            // 
            // Document Table //
            modelBuilder.Entity<Document>().HasData(
                new Document
                {
                    Id = 1,
                    Title = "Introduction to C#",
                    Author = "Unknow",
                    UpdateDate = DateTime.ParseExact("2021-06-10", "yyyy-MM-dd", null),
                    Description = "This comprehensive reference to the C# language is designed to help you get up to speed on C#. Author Eric Gunnerson, a developer on Microsoft's C# design team, has logged many hours writing and testing C# code. ",
                    IsPublic = true

                },
                new Document
                {
                    Id = 2,
                    Title = "Clean Code",
                    Author = "Unknow",
                    UpdateDate = DateTime.ParseExact("2021-06-10", "yyyy-MM-dd", null),
                    Description = "A Practical Introduction to Clean Coding for Beginners",
                    IsPublic = false
                }
            );

            // Chapter Table //
            modelBuilder.Entity<Chapter>().HasData(
                new Chapter
                {
                    Id = 1,
                    DocumentId = 1,
                    Content = "Introduction to Object and Class",
                    IsUnlock = true,

                },
                new Chapter
                {
                    Id = 2,
                    DocumentId = 2,
                    Content = "Why Clean Code",
                    IsUnlock = true,

                }
            );

            // Category Table //
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Title = "C# Language"
                },
                new Category
                {
                    Id = 2,
                    Title = "Technique"
                },
                new Category
                {
                    Id=3,
                    Title = "Skill"
                }
                
            );
            // DocumentCategory Table //
            modelBuilder.Entity<DocumentCategory>().HasData(
                new DocumentCategory
                {
                    
                    DocumentId = 1,
                    CategoryId = 1
                },
                new DocumentCategory
                {
                    
                    DocumentId = 1,
                    CategoryId = 2
                }
            );
            modelBuilder.Entity<UserVote>().HasData(
                new UserVote
                {
                    Id = 1,
                    DocumentId = 1,
                    UserId = "1",
                    Vote = 5
                }
                );






            // 


        }
    }
}
