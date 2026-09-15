using CodeAlpha_EventRegistrationSystem.Business.DTOs.User;
using CodeAlpha_EventRegistrationSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_EventRegistrationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            var createdUser = await _userService.CreateUserAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
