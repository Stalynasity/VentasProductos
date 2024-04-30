using BOOT.Domain.Entities;
using BOOT.Infrastructura.Persistences.Interfaces;
using BOOT.Infrastructura.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Extensions
{
    public static class InjectionExtensions
    {

        public static IServiceCollection AddInjectionInfraestructue(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(BootContext).Assembly.FullName;

            services.AddDbContext<BootContext>(
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
