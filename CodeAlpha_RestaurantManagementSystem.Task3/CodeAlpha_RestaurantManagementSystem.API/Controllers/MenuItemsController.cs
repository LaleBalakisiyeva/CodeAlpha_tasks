using CodeAlpha_RestaurantManagementSystem.Business.DTOs.MenuItemDtos;
using CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_RestaurantManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _menuItemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _menuItemService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuItemCreateDto dto)
        {
            await _menuItemService.CreateAsync(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MenuItemUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            await _menuItemService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _menuItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
