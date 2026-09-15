using AutoMapper;
using CodeAlpha_EventRegistrationSystem.Business.DTOs.User;
using CodeAlpha_EventRegistrationSystem.Business.Helpers.Exceptions;
using CodeAlpha_EventRegistrationSystem.Business.Services.Interfaces;
using CodeAlpha_EventRegistrationSystem.Core.Entities;
using CodeAlpha_EventRegistrationSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserGetDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserGetDto>>(users);
        }

        public async Task<UserGetDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
                throw new NotFoundException($"User with ID {id} was not found.");

            return _mapper.Map<UserGetDto>(user);
        }

        public async Task<UserGetDto> CreateUserAsync(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserGetDto>(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
                throw new NotFoundException($"User with ID {id} was not found.");

            _unitOfWork.UserRepository.Remove(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
