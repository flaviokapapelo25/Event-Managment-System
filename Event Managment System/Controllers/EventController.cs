using BLL;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Event_Managment_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Event_Managment_System.Controllers
{
    public class EventController(IEventService _eventService, IGenericRepository<Booking> _bookingRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllEventsAsync();

            var userBookings = await _bookingRepository.GetAllAsync();
            userBookings = userBookings.Where(b => b.CustomerName == User.Identity!.Name).ToList();

            var eventViewModels = events.Select(e =>
            {
                var userBooking = userBookings.FirstOrDefault(b => b.EventId == e.Id);

                return new EventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Location = e.Location,
                    IsBookedByUser = userBooking != null,
                    BookingId = (userBooking?.Id) ?? 0,
                    Price = e.Price,
                    StartDate = e.StartDate,
                    TicketsAvailable = e.TicketsAvailable,
                    ImageUrl = e.ImageUrl,
                };
            }).ToList();

            return View(eventViewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventDetails = await _eventService.GetEventByIdAsync(id);
            if (eventDetails == null)
                return NotFound();

            return View(eventDetails);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventViewModel eventModel)
        {
            if (ModelState.IsValid)
            {
                var eventDto = new CreatedEventDTO
                {
                    Name = eventModel.Name,
                    Description = eventModel.Description,
                    StartDate = eventModel.StartDate,
                    EndDate = eventModel.EndDate,
                    Location = eventModel.Location,
                    Price = eventModel.Price,
                    Capacity = eventModel.Capacity,
                    Category = eventModel.Category,
                    Image = eventModel.Image,

                };

                await _eventService.CreateEventAsync(eventDto);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed to create event.");
            return View(eventModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventDetails = await _eventService.GetEventByIdAsync(id);
            if (eventDetails == null)
                return NotFound();
            var eventModel = new CreateEventViewModel
            {
                Name = eventDetails.Name,
                Description = eventDetails.Description,
                StartDate = eventDetails.StartDate,
                EndDate = eventDetails.EndDate,
                Location = eventDetails.Location,
                Price = eventDetails.Price,
                Capacity = eventDetails.Capacity,
                Category = eventDetails.Category,


            };
            return View(eventModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateEventViewModel eventModel)
        {
            if (ModelState.IsValid)
            {
                var eventDetails = await _eventService.GetEventByIdAsync(id);
                if (eventDetails == null)
                    return NotFound();

                eventDetails.Name = eventModel.Name;
                eventDetails.Description = eventModel.Description;
                eventDetails.StartDate = eventModel.StartDate;
                eventDetails.EndDate = eventModel.EndDate;
                eventDetails.Location = eventModel.Location;
                eventDetails.Price = eventModel.Price;
                eventDetails.Capacity = eventModel.Capacity;
                eventDetails.Category = eventModel.Category;

                _eventService.UpdateEvent(eventDetails);

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to update event.");
            return View(eventModel);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _eventService.GetEventByIdAsync(id);
            if (eventDetails == null)
                return NotFound();
            return View(eventDetails);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventDetails = await _eventService.GetEventByIdAsync(id);
            if (eventDetails == null)
                return NotFound();

            // Checking if the event have image
            if (eventDetails.ImageUrl != null)
            {
                // Delete the image from the server
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", eventDetails.ImageUrl);
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }


            _eventService.DeleteEvent(id);
            return RedirectToAction("Index");

        }
    }
}
