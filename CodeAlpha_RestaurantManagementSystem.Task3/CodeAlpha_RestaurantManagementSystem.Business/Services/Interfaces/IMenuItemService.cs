using CodeAlpha_RestaurantManagementSystem.Business.DTOs.MenuItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces
{
    public interface IMenuItemService
    {
        Task<IEnumerable<MenuItemGetDto>> GetAllAsync();
        Task<MenuItemGetDto> GetByIdAsync(int id);
        Task CreateAsync(MenuItemCreateDto dto);
        Task UpdateAsync(MenuItemUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
