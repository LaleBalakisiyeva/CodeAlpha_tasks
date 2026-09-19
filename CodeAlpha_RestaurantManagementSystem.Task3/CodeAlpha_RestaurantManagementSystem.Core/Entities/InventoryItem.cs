using CodeAlpha_RestaurantManagementSystem.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Core.Entities
{
    public class InventoryItem : BaseEntity
    {
        public string IngredientName { get; set; } = null!;
        public double QuantityInStock { get; set; }
        public string Unit { get; set; } = null!; 
        public double MinimumThreshold { get; set; }
    }
}
