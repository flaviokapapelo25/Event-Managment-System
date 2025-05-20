using System.ComponentModel.DataAnnotations;

namespace Event_Managment_System.Models
{
    public class CreateBookingViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please choose a valid quantity.")]
        public int Quantity { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
    }
}
