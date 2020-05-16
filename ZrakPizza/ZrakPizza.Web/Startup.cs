using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ZrakPizza.DataAccess;
using ZrakPizza.Services;
using ZrakPizza.Web.Hubs;

namespace ZrakPizza.Web
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
            var jwtConfigSection = Configuration.GetSection("JwtConfig");
            services.Configure<JwtConfig>(jwtConfigSection);

            var connectionString = new ConnectionString(Configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton(connectionString);

            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<IAuthenticateService, AuthenticateService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddSignalR();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSignalR(configure =>
            {
                configure.MapHub<CartHub>("/CartHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
