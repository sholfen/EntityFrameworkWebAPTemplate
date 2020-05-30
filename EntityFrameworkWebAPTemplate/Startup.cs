using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkWebAPTemplate.DBTools.Repository.Implements;
using EntityFrameworkWebAPTemplate.DBTools.Repository.Interfaces;
using EntityFrameworkWebAPTemplate.Models.DBModels;
using EntityFrameworkWebAPTemplate.Models.DBModels.DbContexts;
using EntityFrameworkWebAPTemplate.Models.DBModels.SQLiteModels;
using EntityFrameworkWebAPTemplate.Services.Implements;
using EntityFrameworkWebAPTemplate.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntityFrameworkWebAPTemplate
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
            //DB setup
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            _ = services.AddScoped<DbContext, NorthwindContext>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            services.AddEntityFrameworkSqlite();
            services.AddDbContext<SQLiteContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("SQLiteConnction"));
            });
            _ = services.AddScoped<DbContext, SQLiteContext>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();

            //services setup
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IAlbumService, AlbumService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
