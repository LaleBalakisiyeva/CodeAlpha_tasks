using CodeAlpha_SimpleUrlShortener.DAL.Repositories.Implementations;
using CodeAlpha_SimpleUrlShortener.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeAlpha_SimpleUrlShortener.DAL
{
    public static class DALServiceRegistration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
