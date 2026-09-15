using CodeAlpha_EventRegistrationSystem.Business.DTOs.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.Business.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventGetDto>> GetAllEventsAsync();
        Task<EventGetDto> GetEventByIdAsync(int id);
        Task<EventGetDto> CreateEventAsync(EventCreateDto eventDto);
        Task UpdateEventAsync(int id, EventUpdateDto eventDto);
        Task DeleteEventAsync(int id);
    }
}
