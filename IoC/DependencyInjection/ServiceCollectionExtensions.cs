using DatabaseContext;
using DatabaseContext.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.General;
using Services;
using Services.General.MemberService;
using Services.General.PermissionService;
using Services.General.RoleService;
using System;

namespace IoC.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppDbContext, AppDBContext>();
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("myConnectionString")));

        }

        public static void AddRepositories(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IMemberPermissionRepository, MemberPermissionRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IRoleService, RoleService>();
        }


        public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
            services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>());
        }
    }
}
