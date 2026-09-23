using CodeAlpha_RestaurantManagementSystem.Business.DTOs.TableDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces
{
    public interface ITableService
    {
        Task<IEnumerable<TableGetDto>> GetAllAsync();
        Task<TableGetDto> GetByIdAsync(int id);
        Task CreateAsync(TableCreateDto dto);
        Task UpdateAsync(TableUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
