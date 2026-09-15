using CodeAlpha_EventRegistrationSystem.Business.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
        Task<UserGetDto> GetUserByIdAsync(int id);
        Task<UserGetDto> CreateUserAsync(UserCreateDto userDto);
        Task DeleteUserAsync(int id);
    }
}
