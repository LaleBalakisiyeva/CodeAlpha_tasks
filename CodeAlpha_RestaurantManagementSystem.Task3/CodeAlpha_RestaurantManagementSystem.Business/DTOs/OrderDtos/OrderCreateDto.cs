using CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderDtos
{
    public class OrderCreateDto
    {
        public int TableId { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new();
    }
}
