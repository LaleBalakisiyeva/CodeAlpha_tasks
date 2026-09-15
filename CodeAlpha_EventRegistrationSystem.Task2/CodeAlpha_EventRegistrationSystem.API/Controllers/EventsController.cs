using CodeAlpha_EventRegistrationSystem.Business.DTOs.Event;
using CodeAlpha_EventRegistrationSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_EventRegistrationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventDto = await _eventService.GetEventByIdAsync(id);
            return Ok(eventDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EventCreateDto dto)
        {
            var createdEvent = await _eventService.CreateEventAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EventUpdateDto dto)
        {
            await _eventService.UpdateEventAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }
}
