using AutoMapper;
using CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderDtos;
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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderGetDto>> GetAllAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderGetDto>>(orders);
        }

        public async Task<OrderGetDto> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
                throw new NotFoundException($"Order with ID {id} was not found.");

            return _mapper.Map<OrderGetDto>(order);
        }

        public async Task CreateAsync(OrderCreateDto dto)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(dto.TableId);
            if (table == null)
                throw new NotFoundException($"Table with ID {dto.TableId} does not exist.");

            var order = _mapper.Map<Order>(dto);
            order.IsCompleted = false; 

            decimal totalAmount = 0;
            foreach (var item in order.OrderItems) 
            {
                var menuItem = await _unitOfWork.MenuItems.GetByIdAsync(item.MenuItemId);
                if (menuItem == null)
                    throw new NotFoundException($"Menu item with ID {item.MenuItemId} does not exist.");

                item.UnitPrice = menuItem.Price;
                totalAmount += item.Quantity * item.UnitPrice;
            }

            order.TotalAmount = totalAmount;

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
                throw new NotFoundException($"Order with ID {id} was not found.");

            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
