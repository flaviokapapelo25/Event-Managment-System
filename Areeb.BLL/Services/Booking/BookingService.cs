using Areeb.BLL.Services.Mail;
using Areeb.DAL;
using Areeb.DAL.Entities;
using Areeb.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areeb.BLL
{
    public class BookingService : IBookingService
    {
        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly BookingMailService _bookingMailService;

        public BookingService(IGenericRepository<Booking> BookingRepository, IGenericRepository<Event> eventRepository, BookingMailService bookingMailService)
        {
            _eventRepository = eventRepository;
            _bookingRepository = BookingRepository;
            _bookingMailService = bookingMailService;
        }
        public async Task Book(int eventId, string username, int quantity)
        {
            // 1. Checking availability of tickets
            var eventToBook = await _eventRepository.GetByIdAsync(eventId);
            if (eventToBook.TicketsAvailable <= 0)
                throw new Exception("No tickets available for this event.");

            // 2. Creating a new booking
            var booking = new Booking
            {
                EventId = eventId,
                CustomerName = username,
                Quantity = quantity,
                BookingDate = DateTime.Now,
                IsPaid = true
            };

            //3. Adding the booking to the database
            await _bookingRepository.AddAsync(booking);

            // 4. Send a confirmation mail to the user
            var userMail = username + "@gmail.com";
            await _bookingMailService.SendBookingConfirmationAsync(userMail, eventToBook.Name, eventToBook.StartDate.ToString());


        }

        public async Task<Booking> GetBookingById(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            return booking ?? throw new Exception("Booking not found.");
        }

        public async Task CancelBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId) ?? throw new Exception("Booking not found.");
            _bookingRepository.Delete(bookingId);
        }


        public async Task<IEnumerable<Booking>> GetBookingsByUser(string username)
        {
            var UserBookings = await _bookingRepository.GetAllAsync();
            UserBookings = UserBookings.Where(b => b.CustomerName == username).ToList();

            return UserBookings;
        }
    }
}
