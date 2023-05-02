using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.MVC
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); //mvc uygulamasi olarak caliscagini soyledik.
            services.AddAutoMapper(typeof(Startup)); //Derleme esnasında AutoMapper'in burdaki siniflari taramasini sagliyor.
            services.LoadMyServices();
            //services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
                app.UseStatusCodePages();  //hic bulunmayan bir sayfaya gitmek istersek, bize 404 not found uyarisi vericek.
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); //static dosyalari kullanmamiz icin. Resimler, css, javascript dosyalar gibi kullanmak icin.

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"); //id? nullable id deniliyor. Admin area icin tanımladık. Admin girisinde yonlendirilecek yer. 
                //endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute(); //home controller index kısmına gidicek acilicak. 
            });
        }
    }
}
