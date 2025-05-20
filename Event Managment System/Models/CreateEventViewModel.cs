using DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Event_Managment_System.Models
{
    public class CreateEventViewModel
    {
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1,000,000.")]
        public decimal Price { get; set; }
        [Range(1, 1000, ErrorMessage = "Capacity must be between 1 and 1,000.")]
        public int Capacity { get; set; }

        [Display(Name = "Category")]
        public Category Category { get; set; }



        public IFormFile? Image { get; set; }

    }
}
