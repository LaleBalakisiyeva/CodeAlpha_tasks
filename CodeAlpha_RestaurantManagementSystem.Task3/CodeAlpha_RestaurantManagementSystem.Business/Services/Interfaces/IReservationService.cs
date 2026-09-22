using CodeAlpha_RestaurantManagementSystem.Business.DTOs.ReservationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationGetDto>> GetAllAsync();
        Task<ReservationGetDto> GetByIdAsync(int id);
        Task CreateAsync(ReservationCreateDto dto);
        Task DeleteAsync(int id);
    }
}
