using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public Category Category { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public int TicketsAvailable => Capacity - Bookings?.Where(b => b.IsPaid).Sum(b => b.Quantity) ?? 0 ;
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}
