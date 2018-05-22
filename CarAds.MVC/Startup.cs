using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarAds.Domain.Interfaces.Repositories;
using CarAds.Domain.Interfaces.Services;
using CarAds.Domain.Services;
using CarAds.Infra.Data.Context;
using CarAds.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarAds.MVC
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
            services.AddAutoMapper();
            services.AddMvc();

            //services.AddDbContext<CarAdsContext>(
                //options => options.UseSqlServer(Configuration.GetConnectionString("CarAdsContext")));
            services.AddDbContext<CarAdsContext>(
                options => options.UseSqlite("Data Source=CarAds.db"));

            services.AddTransient<IMotoristaService, MotoristaService>();
            services.AddTransient<IMotoristaRepository, MotoristaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Motoristas}/{action=Index}/{id?}");
            });
        }
    }
}
