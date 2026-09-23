using CodeAlpha_RestaurantManagementSystem.Business.DTOs.TableDtos;
using CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeAlpha_RestaurantManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tables = await _tableService.GetAllAsync();
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var table = await _tableService.GetByIdAsync(id);
            return Ok(table);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TableCreateDto dto)
        {
            await _tableService.CreateAsync(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TableUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            await _tableService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tableService.DeleteAsync(id);
            return NoContent();
        }
    }
}
