using DatabaseContext.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Services.General.PermissionService;
using Services.General.RoleService;
using Services.General.MemberService;
using System;
using Microsoft.AspNetCore.Http;
using Services.UserService;
using DatabaseContext;
using Microsoft.AspNetCore.Authorization;

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

            services.AddDbContext<UnitOfWork>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("myConnectionString")));

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
                options.ViewLocationFormats.Add("/Pages/General/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Pages/BaseInformation/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Pages/General/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddRazorPages();
            services.AddAuthentication(CookieScheme) // Sets the default scheme to cookies
                    .AddCookie(CookieScheme, options =>
                    {
                        options.AccessDeniedPath = "/account/AccessDenied";
                        options.LoginPath = "/account/Index";
                        options.LogoutPath = "/account/Logout";
                    });

            // Example of how to customize a particular instance of cookie options and
            // is able to also use other services.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddFactory<IPermissionService, PermissionService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IRoleService, RoleService>();


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

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<UnitOfWork>();
                //context.Database.Migrate();
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
            }

            app.UseStaticFiles();

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

    public static class ServiceCollectionExtensions
    {
        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>());
        }
    }
}
