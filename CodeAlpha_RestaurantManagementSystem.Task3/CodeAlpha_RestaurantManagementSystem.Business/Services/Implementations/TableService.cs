using AutoMapper;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.TableDtos;
using CodeAlpha_RestaurantManagementSystem.Business.Helpers.Exceptions;
using CodeAlpha_RestaurantManagementSystem.Business.Services.Interfaces;
using CodeAlpha_RestaurantManagementSystem.Core.Entities;
using CodeAlpha_RestaurantManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.Services.Implementations
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TableService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TableGetDto>> GetAllAsync()
        {
            var tables = await _unitOfWork.Tables.GetAllAsync();
            return _mapper.Map<IEnumerable<TableGetDto>>(tables);
        }

        public async Task<TableGetDto> GetByIdAsync(int id)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(id);
            if (table == null)
                throw new NotFoundException($"Table with ID {id} was not found.");

            return _mapper.Map<TableGetDto>(table);
        }

        public async Task CreateAsync(TableCreateDto dto)
        {
            var entity = _mapper.Map<Table>(dto);
            await _unitOfWork.Tables.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TableUpdateDto dto)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(dto.Id);
            if (table == null)
                throw new NotFoundException($"Table with ID {dto.Id} was not found.");

            _mapper.Map(dto, table);
            _unitOfWork.Tables.Update(table);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(id);
            if (table == null)
                throw new NotFoundException($"Table with ID {id} was not found.");

            _unitOfWork.Tables.Remove(table);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
