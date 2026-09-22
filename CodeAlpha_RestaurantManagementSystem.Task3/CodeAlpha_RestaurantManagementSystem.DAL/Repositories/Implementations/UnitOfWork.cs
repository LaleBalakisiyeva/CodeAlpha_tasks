using CodeAlpha_RestaurantManagementSystem.DAL.Contexts;
using CodeAlpha_RestaurantManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IMenuItemRepository MenuItems { get; private set; }
        public ITableRepository Tables { get; private set; }
        public IReservationRepository Reservations { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderItemRepository OrderItems { get; private set; }
        public IInventoryItemRepository InventoryItems { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            MenuItems = new MenuItemRepository(_context);
            Tables = new TableRepository(_context);
            Reservations = new ReservationRepository(_context);
            Orders = new OrderRepository(_context);
            OrderItems = new OrderItemRepository(_context);
            InventoryItems = new InventoryItemRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
