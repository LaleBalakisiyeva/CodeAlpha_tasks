
using CodeAlpha_EventRegistrationSystem.DAL.Repositories.Implementations;
using CodeAlpha_EventRegistrationSystem.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeAlpha_EventRegistrationSystem.DAL
{
    public static class DalServiceRegistration
    {

        public static IServiceCollection AddDalServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}