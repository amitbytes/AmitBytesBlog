using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DA = AmitBytesBlog.DataAccess;
using BE = AmitBytesBlog.Entity;

namespace AmitBytesBlog.Admin
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            //DI Registration
            services.AddScoped<DA.ISystemUserRepository, DA.SystemUserRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(CurrentUser));

            //override default Antiforgrey token service configuration
            //https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-2.2
            services.AddAntiforgery(options =>
            {
                options.FormFieldName = UIConstants.XCSRF_FORMTOKEN_NAME;
                options.Cookie.Name = UIConstants.XCSRF_COOKIE_NAME;
                options.Cookie.HttpOnly = true;
                var dt = DateTime.Now.AddMonths(1); //1 month
                options.Cookie.Expiration = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                // options.Cookie.SecurePolicy = Environment.IsDevelopment() ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.Always;
            });


            //add session service
            services.AddSession(option =>
            {
                option.Cookie.Name = UIConstants.SESSION_COOKIE_NAME;
                option.Cookie.HttpOnly = true;
                option.IdleTimeout = TimeSpan.FromMinutes(10);
                option.Cookie.IsEssential = true;
            });


            // Authentication Configuration
            //https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-2.2
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.Cookie.HttpOnly = true;
                    option.Cookie.Expiration = TimeSpan.FromMinutes(15); // 15 minutes
                    option.LoginPath = "/Account/Login";
                    option.LogoutPath = "/Account/Logout";
                    option.SlidingExpiration = true;
                    option.AccessDeniedPath = "/Error/Index";
                    option.Cookie.Name = UIConstants.AUTH_COOKIE_NAME;
                    //TODO : Change this option once https configured
                    //option.Cookie.SecurePolicy = env.IsDevelopment() ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.Always;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Build Add Global Configruation
            BE.Global.MongoDb = new BE.MongoDbConfig();
            Configuration.GetSection("MongoDb").Bind(BE.Global.MongoDb);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithReExecute("/Error/{0}");// just to test will remove
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseSession();
            app.UseAuthentication(); // Enable authentication

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Account", action = "Login" });
            });


        }
    }
}
