using BLL;
using DAL.Data;
using DAL.Data.Seeds;
using DAL.Entities;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Attachments;
using Services.Mail;

namespace Event_Managment_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI();

            builder.Services.AddRazorPages();

            builder.Services.AddScoped<DataSeeding>();
            builder.Services.AddScoped<EventRepository>();
            builder.Services.AddScoped<IGenericRepository<Event>, EventRepository>();
            builder.Services.AddScoped<IGenericRepository<Booking>, BookingRepository>();
            builder.Services.AddScoped<IBookingService , BookingService>();
            builder.Services.AddScoped<BookingMailService>();
            builder.Services.AddScoped<EmailTemplateService>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddScoped<IEventService, EventService>();




            // Register Configuration service
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Injecting the DataSeeding class to seed the database
            var scope = app.Services.CreateScope();
            var DataSeedObject = scope.ServiceProvider.GetRequiredService<DataSeeding>();
            DataSeedObject.SeedData();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())            
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/" && !context.User.Identity!.IsAuthenticated)
                {
                    context.Response.Redirect("/Identity/Account/Login");
                    return;
                }
                else if (context.Request.Path == "/" && context.User.Identity!.IsAuthenticated)
                {
                    context.Response.Redirect("/Home/Index");
                    return;
                }

                await next();
            });



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
