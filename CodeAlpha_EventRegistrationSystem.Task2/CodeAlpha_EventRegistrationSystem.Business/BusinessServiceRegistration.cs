using CodeAlpha_EventRegistrationSystem.Business.Services.Implementations;
using CodeAlpha_EventRegistrationSystem.Business.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRegistrationService, RegistrationService>();

            return services;
        }
    }
}
