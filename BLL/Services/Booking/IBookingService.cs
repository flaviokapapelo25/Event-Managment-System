using DAL.Entities;

namespace BLL
{
    public interface IBookingService
    {
        public Task Book(int eventId, string username, int quantity);
        public Task CancelBooking(int bookingId);
        public Task<Booking> GetBookingById(int bookingId);
        public Task<IEnumerable<Booking>> GetBookingsByUser(string username);
    }
}
