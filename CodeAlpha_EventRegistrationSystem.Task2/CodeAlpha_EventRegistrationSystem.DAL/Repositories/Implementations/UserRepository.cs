using CodeAlpha_EventRegistrationSystem.Core.Entities;
using CodeAlpha_EventRegistrationSystem.DAL.Contexts;
using CodeAlpha_EventRegistrationSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.DAL.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
