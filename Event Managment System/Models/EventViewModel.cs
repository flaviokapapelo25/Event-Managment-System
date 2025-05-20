using Microsoft.AspNetCore.Mvc.Rendering;

namespace Event_Managment_System.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int TicketsAvailable { get; set; }
        public int BookingId { get; set; }
        public bool IsBookedByUser { get; set; }
        public string? ImageUrl { get; set; }

    }

}
