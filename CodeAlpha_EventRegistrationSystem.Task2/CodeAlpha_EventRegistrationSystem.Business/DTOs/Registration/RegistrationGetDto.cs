using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.Business.DTOs.Registration
{
    public class RegistrationGetDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
