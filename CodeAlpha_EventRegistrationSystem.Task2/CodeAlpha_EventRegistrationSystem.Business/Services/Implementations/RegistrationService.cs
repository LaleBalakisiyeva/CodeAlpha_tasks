using AutoMapper;
using CodeAlpha_EventRegistrationSystem.Business.DTOs.Registration;
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
    public class RegistrationService : IRegistrationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegistrationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistrationGetDto>> GetAllRegistrationsAsync()
        {
            var registrations = await _unitOfWork.RegistrationRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RegistrationGetDto>>(registrations);
        }

        public async Task<RegistrationGetDto> CreateRegistrationAsync(RegistrationCreateDto registrationDto)
        {
            var eventEntity = await _unitOfWork.EventRepository.GetByIdAsync(registrationDto.EventId);
            if (eventEntity == null)
                throw new NotFoundException($"Event with ID {registrationDto.EventId} was not found.");

            var user = await _unitOfWork.UserRepository.GetByIdAsync(registrationDto.UserId);
            if (user == null)
                throw new NotFoundException($"User with ID {registrationDto.UserId} was not found.");

            var registration = _mapper.Map<Registration>(registrationDto);
            await _unitOfWork.RegistrationRepository.AddAsync(registration);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RegistrationGetDto>(registration);
        }

        public async Task DeleteRegistrationAsync(int id)
        {
            var registration = await _unitOfWork.RegistrationRepository.GetByIdAsync(id);
            if (registration == null)
                throw new NotFoundException($"Registration with ID {id} was not found.");

            _unitOfWork.RegistrationRepository.Remove(registration);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
