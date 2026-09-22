using CodeAlpha_RestaurantManagementSystem.Business.DTOs.InventoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces
{
    public interface IInventoryItemService
    {
        Task<IEnumerable<InventoryItemGetDto>> GetAllAsync();
        Task<InventoryItemGetDto> GetByIdAsync(int id);
        Task CreateAsync(InventoryItemCreateDto dto);
        Task DeleteAsync(int id);
    }
}
