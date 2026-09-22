using CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderDtos
{
    public class OrderGetDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int TableNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<OrderItemGetDto> Items { get; set; } = new();
    }
}
