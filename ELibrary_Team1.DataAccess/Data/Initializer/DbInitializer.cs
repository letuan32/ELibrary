using ELibrary.Data;
using ELibrary_Team_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary_Team1.DataAccess.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ELibraryDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ELibraryDbContext db, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
                // Role
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole()
                {
                    Name = "Admin",
                };
                _roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole()
                {
                    Name = "User"
                };
                _roleManager.CreateAsync(role).GetAwaiter().GetResult();
            };

            if(_userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                var user = new AppUser()
                {
                    Email = "admin@gmail.com",
                    FirstName = "Le",
                    LastName = "Tuan",
                    EmailConfirmed = true,
                    UserName = "admin",
                    
                };
                
                IdentityResult result = _userManager.CreateAsync(user, "Admin@123").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user,"Admin").GetAwaiter().GetResult();
                }
            }
            if (_userManager.FindByEmailAsync("letuanlttt@gmail.com").Result == null)
            {
                var user = new AppUser()
                {
                    Email = "letuanlttt@gmail.com",
                    FirstName = "Le",
                    LastName = "Tuan",
                    EmailConfirmed = true,
                    UserName = "letuan32",
                };
                IdentityResult result = _userManager.CreateAsync(user, "Admin@123").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user,"Admin").GetAwaiter().GetResult();
                }
            }

            if (_userManager.FindByEmailAsync("letuanlttt@gmail.com").Result == null)
            {
                var user = new AppUser()
                {
                    Email = "letuanlttt@gmail.com",
                    FirstName = "Le",
                    LastName = "Tuan",
                    EmailConfirmed = true,
                    UserName = "letuan32",
                };
                IdentityResult result = _userManager.CreateAsync(user, "Admin@123").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
                }
            }

            if (_userManager.FindByEmailAsync("user@gmail.com").Result == null)
            {
                var user = new AppUser()
                {
                    Email = "user@gmail.com",
                    FirstName = "Le",
                    LastName = "Tuan",
                    EmailConfirmed = true,
                    UserName = "user",
                };
                IdentityResult result = _userManager.CreateAsync(user, "User@123").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();
                }
            }

        }
    }
}
