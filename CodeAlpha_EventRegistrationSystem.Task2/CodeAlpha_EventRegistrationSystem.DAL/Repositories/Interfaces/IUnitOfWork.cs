using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository EventRepository { get; }
        IUserRepository UserRepository { get; }
        IRegistrationRepository RegistrationRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
