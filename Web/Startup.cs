﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Web.Middlewares;
using IoC.DependencyInjection;
using Web.Service;
using Web.Permission;

namespace Web
{
    public class Startup
    {
        public const string CookieScheme = "Cookies";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
            {
                //options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                //options.JsonSerializerOptions.Converters.Add(new JsonConverter());
            }); ;

            services.AddPersistenceContexts(Configuration);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Vahid", builder =>
                {
                    builder.AddRequirements(new AuthorizationRequirement());
                });

            });

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Areas/General/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Areas/BaseInformation/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Areas/General/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddRazorPages();
            services.AddAuthentication(CookieScheme) // Sets the default scheme to cookies
                    .AddCookie(CookieScheme, options =>
                    {
                        options.AccessDeniedPath = "/account/AccessDenied";
                        options.LoginPath = "/account/Index";
                        options.LogoutPath = "/account/Logout";
                    });


            services.AddRepositories();
            services.AddServices();

            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, Authentication>();

            //services.AddSingleton<IAuthorizationRequirement, AuthorizationRequirement>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength = 4;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //});
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
                app.UseHsts();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<AppDBContext>();
            //    //context.Database.EnsureDeleted();
            //    //context.Database.EnsureCreated();
            //    //context.Database.Migrate();
            //}

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Areas/General/Business")),
                RequestPath = new PathString("/General/Business")
            });

            app.UseRouting();

            app.UseAuthentication();
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
