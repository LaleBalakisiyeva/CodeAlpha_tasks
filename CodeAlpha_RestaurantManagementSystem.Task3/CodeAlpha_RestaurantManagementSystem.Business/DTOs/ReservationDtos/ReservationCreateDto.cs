using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_RestaurantManagementSystem.Business.DTOs.ReservationDtos
{
    public class ReservationCreateDto
    {
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public int TableId { get; set; }
        public DateTime ReservationTime { get; set; }
        public int GuestCount { get; set; }
    }
}
