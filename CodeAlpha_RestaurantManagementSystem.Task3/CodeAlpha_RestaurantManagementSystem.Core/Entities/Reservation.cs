using CodeAlpha_RestaurantManagementSystem.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Core.Entities
{
    public class Reservation : BaseEntity
    {
        public int TableId { get; set; }
        public Table Table { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public DateTime ReservationTime { get; set; }
        public int PartySize { get; set; }
    }
}
