using CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderGetDto>> GetAllAsync();
        Task<OrderGetDto> GetByIdAsync(int id);
        Task CreateAsync(OrderCreateDto dto);
        Task DeleteAsync(int id);
    }
}
