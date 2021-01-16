﻿using CSHTGT.Data.Context;
using CSHTGT.Service.IService;
using CSHTGT.Service.Service;
using CSHTGT.ViewModels;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CSHTGT.WebAPI
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
            //services.AddDbContext<CSHTGTDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("CSHTGTDb")));
            services.AddDbContext<CSHTGTDbContext>();
            //declare DI
            services.AddTransient<ILoaiPhuongTienService, LoaiPhuongTienService>();
            services.AddTransient<IPhuongTienService, PhuongTienService>();
            services.AddTransient<ICanBoService, CanBoService>();
            services.AddTransient<IGPLXService, GPLXService>();
            services.AddTransient<IDonViService, DonViService>();
            services.AddControllersWithViews();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test c�c API", Version = "v1" });
            });
            services.AddControllers()
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PhuongTienCreateValidator>());
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
