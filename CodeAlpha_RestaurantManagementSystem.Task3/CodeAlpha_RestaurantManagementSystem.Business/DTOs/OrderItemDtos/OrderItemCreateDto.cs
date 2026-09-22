using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.DTOs.OrderItemDtos
{
    public class OrderItemCreateDto
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
    }
}
