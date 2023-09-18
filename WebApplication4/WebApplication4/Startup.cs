using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Helpers;
using WebApplication4.Models;

namespace WebApplication4
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
            

            services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(Configuration["ConnectionStrings:SqlCon"]));
           // services.AddDbContext<DbContext>(options=> options.UseSqlServer(Configuration["ConnectionStrings:SqlCon1"]));

            services.AddControllersWithViews();

            //services.AddSingleton<IHelper, Helper>();
            services.AddScoped<IHelper, Helper>(); //------------------->>> Kullan�m� daha cok tavsiye edilir.

            //string connectionString = "Data Source=localhost;Initial Catalog=MyDatabase;Integrated Security=True;";
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    options.UseSqlServer(connectionString);
            //});

            //string connString = ConfigurationManager.ConnectionStrings["MyDbConn1"].ConnectionString;
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
