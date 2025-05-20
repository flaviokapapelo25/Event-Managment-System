using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace DAL.Data.Seeds
{
    public class DataSeeding(ApplicationDbContext applicationDbContext,
                       UserManager<IdentityUser> userManager)
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task SeedData()
        {
            // Checking if there are any pending migrations, migrating if any are found
            if (_applicationDbContext.Database.GetPendingMigrations().Any())
            {
                _applicationDbContext.Database.Migrate();
            }


            
            if (!_applicationDbContext.Events.Any())
            {
                var events = new List<Event>
                {
                    new() {
                        Name = "Concert",
                        Description = "Live concert featuring popular bands.",
                        StartDate = DateTime.Now.AddDays(30),
                        EndDate = DateTime.Now.AddDays(30).AddHours(3),
                        Location = "City Stadium",
                        Category = Category.Sport,
                        Price = 50.00m,
                        Capacity = 1000,
                    },
                    new() {
                        Name = "Art Exhibition",
                        Description = "Showcasing local artists' work.",
                        StartDate = DateTime.Now.AddDays(60),
                        EndDate = DateTime.Now.AddDays(60).AddHours(5),
                        Location = "Art Gallery",
                        Category = Category.Art,
                        Price = 20.00m,
                        Capacity = 500,

                    },
                    new() {
                        Name = "Tech Conference",
                        Description = "Annual tech conference with industry leaders.",
                        StartDate = DateTime.Now.AddDays(90),
                        EndDate = DateTime.Now.AddDays(90).AddHours(8),
                        Location = "Convention Center",
                        Category = Category.Conference,
                        Price = 150.00m,
                        Capacity = 2000,

                    },
                    new() {
                        Name = "Food Festival",
                        Description = "Taste dishes from around the world.",
                        StartDate = DateTime.Now.AddDays(120),
                        EndDate = DateTime.Now.AddDays(120).AddHours(6),
                        Location = "City Park",
                        Category = Category.Food,
                        Price = 10.00m,
                        Capacity = 3000,

                    },
                    new() {
                        Name = "Charity Run",
                        Description = "5K run to raise funds for local charities.",
                        StartDate = DateTime.Now.AddDays(150),
                        EndDate = DateTime.Now.AddDays(150).AddHours(4),
                        Location = "Downtown",
                        Category = Category.Sport,
                        Price = 25.00m,
                        Capacity = 800,

                    }

                };

                _applicationDbContext.Events.AddRange(events);
                _applicationDbContext.SaveChanges();
            }

            if (!_applicationDbContext.Roles.Any())
            {
                var roles = new List<IdentityRole>
                {
                    new() { Name = "Admin", NormalizedName = "ADMIN" },
                    new() { Name = "User", NormalizedName = "USER" }
                };
                _applicationDbContext.Roles.AddRange(roles);
                _applicationDbContext.SaveChanges();
            }


            string adminEmail = "eng.rawantarek21@gmail.com";
            string adminPassword = "Areeb@1234";

            var adminUser = await _userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = new MailAddress(adminEmail).User,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error creating admin: {error.Description}");
                    }

                }
            }
        }
    }
}
