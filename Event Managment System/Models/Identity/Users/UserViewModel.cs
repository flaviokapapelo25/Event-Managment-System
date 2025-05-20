using System.ComponentModel.DataAnnotations;

namespace Event_Booking_System.Models.Identity.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
