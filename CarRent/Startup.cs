using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarRent.Data;
using CarRent.Data.Repo;
using CarRent.Models;
using CarRent.Services;
using CarRent.Models.SeedData;

namespace CarRent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            services.AddScoped<IAddressRepo, AddressRepo>();
            services.AddScoped<ILocationRepo, LocationRepo>();
            services.AddScoped<ICarDetalistRepo, CarDetalistRepo>();
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<IGradeRepo, GradeRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IPersonRepo, PersonRepo>();
            services.AddScoped<IUserRatingRepo, UserRatingRepo>();
            services.AddScoped<IEmployeRepo, EmployeRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "Oferta/{category}/Strona{carPage:int}",
                    defaults: new { controller="Car", action= "CarsList" }
                );
                routes.MapRoute(
                      name: null,
                      template: "Oferta/Lokalizajca{locationId}",
                      defaults: new { controller = "Car", action = "CarsList" }
                      );
                routes.MapRoute(
                    name: null,
                    template: "Strona{carPage:int}",
                    defaults: new { controller = "Car", action = "CarsList", carPage = 1 }
                    );
                routes.MapRoute(
                    name:null,
                    template: "Oferta/{category}",
                    defaults: new {controller="Car", action= "CarsList", carPage=1}
                    );
                routes.MapRoute(
                   name: null,
                   template: "Auto/{carId:int}",
                   defaults: new { controller = "Car", action = "Car"}
                   );
                routes.MapRoute(
                    name: null,
                    template:"O_nas/",
                    defaults: new { controller = "Home", action = "About" }
                    );
                routes.MapRoute(
                    name: null,
                    template: "Kontakt/",
                    defaults: new { controller = "Location", action = "LocationList" }
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
            //Tworzenie bazy danych i dodawanie przykładowych danych do bazy danych
           SeedData.Ensure(app);
        }
    }
}
