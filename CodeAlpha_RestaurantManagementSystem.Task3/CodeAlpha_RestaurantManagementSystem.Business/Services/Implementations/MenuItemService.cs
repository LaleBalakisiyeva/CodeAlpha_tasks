using AutoMapper;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.MenuItemDtos;
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
    public class MenuItemService : IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MenuItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuItemGetDto>> GetAllAsync()
        {
            var items = await _unitOfWork.MenuItems.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuItemGetDto>>(items);
        }

        public async Task<MenuItemGetDto> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.MenuItems.GetByIdAsync(id);
            if (item == null)
                throw new NotFoundException($"Menu item with ID {id} was not found.");

            return _mapper.Map<MenuItemGetDto>(item);
        }

        public async Task CreateAsync(MenuItemCreateDto dto)
        {
            var entity = _mapper.Map<MenuItem>(dto);
            await _unitOfWork.MenuItems.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItemUpdateDto dto)
        {
            var item = await _unitOfWork.MenuItems.GetByIdAsync(dto.Id);
            if (item == null)
                throw new NotFoundException($"Menu item with ID {dto.Id} was not found.");

            _mapper.Map(dto, item);
            _unitOfWork.MenuItems.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _unitOfWork.MenuItems.GetByIdAsync(id);
            if (item == null)
                throw new NotFoundException($"Menu item with ID {id} was not found.");

            _unitOfWork.MenuItems.Remove(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
