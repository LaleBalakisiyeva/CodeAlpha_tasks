using CodeAlpha_SimpleUrlShortener.Business.Services.Implementations;
using CodeAlpha_SimpleUrlShortener.Business.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_SimpleUrlShortener.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUrlService, UrlService>();


            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(BusinessServiceRegistration).Assembly));

            services.AddValidatorsFromAssembly(typeof(BusinessServiceRegistration).Assembly);

            return services;
        }
    }
}