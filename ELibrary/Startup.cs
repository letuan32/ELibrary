using ELibrary.Data;
using ELibrary_Team_1.Models;
using Elibrary_Team1.Utility;
using ELibrary_Team1.DataAccess.Data.Initializer;
using ELibrary_Team1.DataAccess.Data.Repository;
using ELibrary_Team1.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ELibrary_Team_1
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            ///
            services.AddDbContext<ELibraryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ElibraryDeploy")));


            services.AddSingleton<IEmailSender, EmailSender>();
            services.ConfigureApplicationCookie(options => {
            options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ELibraryDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddScoped<IDbInitializer, DbInitializer>();
            // Repository and Service
            services.AddRepositoryServices();

            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


            // Razor page

            services.AddRazorPages();
        }
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Deployment
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            // End deploy


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            dbInitializer.Initialize();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{area=Unauthenticated}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "{area=admin}/{controller=Home}/{action=Index}/{id?}");



                endpoints.MapRazorPages();
            });
        }
    }
}
