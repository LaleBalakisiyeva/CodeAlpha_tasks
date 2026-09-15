using AutoMapper;
using CodeAlpha_EventRegistrationSystem.Business.DTOs.Event;
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
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventGetDto>> GetAllEventsAsync()
        {
            var events = await _unitOfWork.EventRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EventGetDto>>(events);
        }

        public async Task<EventGetDto> GetEventByIdAsync(int id)
        {
            var eventEntity = await _unitOfWork.EventRepository.GetByIdAsync(id);
            if (eventEntity == null)
                throw new NotFoundException($"Event with ID {id} was not found.");

            return _mapper.Map<EventGetDto>(eventEntity);
        }

        public async Task<EventGetDto> CreateEventAsync(EventCreateDto eventDto)
        {
            var eventEntity = _mapper.Map<Event>(eventDto);
            await _unitOfWork.EventRepository.AddAsync(eventEntity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<EventGetDto>(eventEntity);
        }

        public async Task UpdateEventAsync(int id, EventUpdateDto eventDto)
        {
            if (id != eventDto.Id)
                throw new BadRequestException("ID mismatch between route parameter and request body.");

            var existingEvent = await _unitOfWork.EventRepository.GetByIdAsync(id);
            if (existingEvent == null)
                throw new NotFoundException($"Event with ID {id} was not found.");

            _mapper.Map(eventDto, existingEvent);
            _unitOfWork.EventRepository.Update(existingEvent);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventEntity = await _unitOfWork.EventRepository.GetByIdAsync(id);
            if (eventEntity == null)
                throw new NotFoundException($"Event with ID {id} was not found.");

            _unitOfWork.EventRepository.Remove(eventEntity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
