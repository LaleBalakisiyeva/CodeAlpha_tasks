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

        public IEventRepository EventRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRegistrationRepository RegistrationRepository { get; }

        public UnitOfWork(
            AppDbContext context,
            IEventRepository eventRepository,
            IUserRepository userRepository,
            IRegistrationRepository registrationRepository)
        {
            _context = context;
            EventRepository = eventRepository;
            UserRepository = userRepository;
            RegistrationRepository = registrationRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
