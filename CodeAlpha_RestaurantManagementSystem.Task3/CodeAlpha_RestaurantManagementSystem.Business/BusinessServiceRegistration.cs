using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces;
using CodeAlpha_RestaurantManagementSystem.Business.Services.Implementations;
using FluentValidation;

namespace CodeAlpha_RestaurantManagementSystem.Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(BusinessServiceRegistration)));
        services.AddValidatorsFromAssembly(typeof(BusinessServiceRegistration).Assembly);


        services.AddScoped<IMenuItemService, MenuItemService>();
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IInventoryItemService, InventoryItemService>();

        return services;
    }
}