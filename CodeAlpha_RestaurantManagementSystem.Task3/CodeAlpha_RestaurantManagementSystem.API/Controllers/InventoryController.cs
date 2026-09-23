using CodeAlpha_RestaurantManagementSystem.Business.DTOs.InventoryDtos;
using CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_RestaurantManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryItemService _inventoryItemService;

        public InventoryController(IInventoryItemService inventoryItemService)
        {
            _inventoryItemService = inventoryItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _inventoryItemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _inventoryItemService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryItemCreateDto dto)
        {
            await _inventoryItemService.CreateAsync(dto);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _inventoryItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
