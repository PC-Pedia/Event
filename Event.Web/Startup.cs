using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Event.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Event.Infrastructure.Data.Repository.Interfaces;
using Event.Infrastructure.Data.Repository.SQLRepositories;
using Event.Model.EntityModels;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace Event.Web
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
           
        }

        //for develment environment
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
        

            services.AddDbContext<AppDBContext>(option =>
            option.UseSqlServer(Configuration["Data:Event:ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<AppUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<AppDBContext>();
            //resolving repository dependencies
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IEventCategoryRepository, EventCategoryRepository>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<ICommentRepository,CommentRepository>();
            services.AddTransient<IUserRepository,UserRepository>();

            //services.AddSingleton<Event.Model.Mapper.MappingEX>();
            services.AddAutoMapper();

            services.AddMvc();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseAuthentication();
            
            app.UseExceptionHandler("/Home/Error");
           
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // development env
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseAuthentication();
            
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
