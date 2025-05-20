using Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace Event_Booking_System.Models.Identity.Users
{
    public class UserRoleViewModel
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        public string Username { get; set; }
        public List<UpdateRoleViewModel> Roles { get; set; }
    }
}
