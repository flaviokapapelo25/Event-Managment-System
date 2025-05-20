using Areeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areeb.BLL
{
    public interface IBookingService
    {
        public Task Book(int eventId, string username, int quantity);
        public Task CancelBooking(int bookingId);
        public Task<Booking> GetBookingById(int bookingId);
        public Task<IEnumerable<Booking>> GetBookingsByUser(string username);
    }
}
