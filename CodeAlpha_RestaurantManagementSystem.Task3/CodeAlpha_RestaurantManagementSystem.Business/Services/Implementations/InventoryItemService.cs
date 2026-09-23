using AutoMapper;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.InventoryDtos;
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
    public class InventoryItemService : IInventoryItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InventoryItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InventoryItemGetDto>> GetAllAsync()
        {
            var items = await _unitOfWork.InventoryItems.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryItemGetDto>>(items);
        }

        public async Task<InventoryItemGetDto> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.InventoryItems.GetByIdAsync(id);
            if (item == null)
                throw new NotFoundException($"Inventory item with ID {id} was not found.");

            return _mapper.Map<InventoryItemGetDto>(item);
        }

        public async Task CreateAsync(InventoryItemCreateDto dto)
        {
            var entity = _mapper.Map<InventoryItem>(dto);
            await _unitOfWork.InventoryItems.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _unitOfWork.InventoryItems.GetByIdAsync(id);
            if (item == null)
                throw new NotFoundException($"Inventory item with ID {id} was not found.");

            _unitOfWork.InventoryItems.Remove(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
