using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.DTOs.InventoryDtos
{
    public class InventoryItemGetDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = null!;
        public decimal MinimumRequiredQuantity { get; set; }
        public bool IsLowStock => Quantity <= MinimumRequiredQuantity;
    }
}
