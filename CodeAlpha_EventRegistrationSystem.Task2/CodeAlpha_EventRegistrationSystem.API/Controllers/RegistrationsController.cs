using CodeAlpha_EventRegistrationSystem.Business.DTOs.Registration;
using CodeAlpha_EventRegistrationSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_EventRegistrationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationsController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var registrations = await _registrationService.GetAllRegistrationsAsync();
            return Ok(registrations);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegistrationCreateDto dto)
        {
            var created = await _registrationService.CreateRegistrationAsync(dto);
            return Ok(created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            await _registrationService.DeleteRegistrationAsync(id);
            return NoContent();
        }
    }
}
