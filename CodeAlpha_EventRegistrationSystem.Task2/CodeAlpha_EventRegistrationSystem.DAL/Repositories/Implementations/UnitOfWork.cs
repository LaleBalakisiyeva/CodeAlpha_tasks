using CodeAlpha_EventRegistrationSystem.DAL.Contexts;
using CodeAlpha_EventRegistrationSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IEventRepository Events { get; private set; }
        public IUserRepository Users { get; private set; }
        public IRegistrationRepository Registrations { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Events = new EventRepository(_context);
            Users = new UserRepository(_context);
            Registrations = new RegistrationRepository(_context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
