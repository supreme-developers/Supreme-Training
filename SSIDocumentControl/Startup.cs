using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SSIDocumentControl.Core;
using SSIDocumentControl.Data;
using SSIDocumentControl.Models.SystemModels;
using SSIDocumentControl.Repositories;
using SSIDocumentControl.Repositories.DocumentAuthorization;
using SSIDocumentControl.Repositories.System;
using SSIDocumentControl.Repositories.Users;

namespace SSIDocumentControl
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
            var defaultCS = Configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<DocumentContext>(options => options.UseSqlServer(defaultCS));
            services.AddIdentity<RentUser, IdentityRole>()
                    .AddEntityFrameworkStores<DocumentContext>()
                    .AddDefaultTokenProviders();
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
           .AddCookie(o =>
           {
               o.LoginPath = new PathString("/Account/Login");
               o.AccessDeniedPath = new PathString("/Common/AccessDenied");

           });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISignInManager, SignInManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSession, UserSession>();
            services.AddScoped<ISystemRepository, SystemRepository>();
            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                }, ArrayPool<char>.Shared));
            });
               

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("Admin"));
            });
            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AutomaticAuthentication = false;
            //});
            //services.Configure<IISOptions>(options =>
            //{
            //    options.ForwardClientCertificate = false;
            //});
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjIzNzBAMzEzNjJlMzQyZTMwUlA3bDVBb0xjZnQ2cXlreHpvR1lHNjhGQ3RLMys5Y3AvZ21sODBNcEcvVT0");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseDeveloperExceptionPage();
              //  app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Documents}/{action=Index}/{id?}");
            });
            
        }
    }
}
