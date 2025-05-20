using BLL;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Event_Managment_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin,User")]
public class BookingController : Controller
{
    private readonly IGenericRepository<Event> _eventRepository;
    private readonly IBookingService _bookingService;

    public BookingController(IGenericRepository<Event> eventRepository, IBookingService bookingService)
    {
        _eventRepository = eventRepository;
        _bookingService = bookingService;
    }

    

    public async Task<IActionResult> Index()
    {
        var username = User?.Identity?.Name;

        var UserBookings =await _bookingService.GetBookingsByUser(User?.Identity?.Name);
        return View(UserBookings);
    }
    
    
    
    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {

        var eventEntity = await _eventRepository.GetByIdAsync(id);
        if (eventEntity == null)
        {
            return NotFound();
        }

        var model = new CreateBookingViewModel
        {
            EventId = id,
            EventName = eventEntity.Name 
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var userName = User?.Identity?.Name;

        try
        {
            await _bookingService.Book(model.EventId, userName!, model.Quantity);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(model);
        }

        return View("CongratulationsView", model.EventName);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var booking = await _bookingService.GetBookingById(id);
        return View(booking);

    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _bookingService.CancelBooking(id);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
        return RedirectToAction("Index", "Event");
    }
}