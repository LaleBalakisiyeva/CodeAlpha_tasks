using CodeAlpha_RestaurantManagementSystem.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Core.Entities
{
    public class Order : BaseEntity
    {
        public int TableId { get; set; }
        public Table Table { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; } = false;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
