using CodeAlpha_EventRegistrationSystem.Business.DTOs.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.Business.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegistrationGetDto>> GetAllRegistrationsAsync();
        Task<RegistrationGetDto> CreateRegistrationAsync(RegistrationCreateDto registrationDto);
        Task DeleteRegistrationAsync(int id);
    }
}
