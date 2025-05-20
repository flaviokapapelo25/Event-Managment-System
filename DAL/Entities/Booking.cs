using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsPaid { get; set; }
    }

}
