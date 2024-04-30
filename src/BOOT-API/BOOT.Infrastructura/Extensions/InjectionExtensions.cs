using BOOT.Infrastructura.Persistences.Contexts;
using BOOT.Infrastructura.Persistences.Interfaces;
using BOOT.Infrastructura.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BOOT.Infrastructura.Extensions
{
    public static class InjectionExtensions
    {

        public static IServiceCollection AddInjectionInfraestructue(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DbproductContext).Assembly.FullName;

            services.AddDbContext<DbproductContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("MGConnection"),
                    b => b.MigrationsAssembly(assembly)),
                ServiceLifetime.Transient
                );

            //ciclo de vidad de servido transitor q verifica y guarda los cambios en la bd
            services.AddTransient<IUnitOfWork, UnitOfwork>();
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;

        }

    }
}
