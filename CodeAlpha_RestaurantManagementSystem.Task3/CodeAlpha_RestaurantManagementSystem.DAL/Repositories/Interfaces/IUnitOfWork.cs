using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMenuItemRepository MenuItems { get; }
        ITableRepository Tables { get; }
        IReservationRepository Reservations { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IInventoryItemRepository InventoryItems { get; }

        Task<int> SaveChangesAsync();
    }
}
