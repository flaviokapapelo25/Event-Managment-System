using Areeb.DAL.Repositories.Interfaces;
using Event_Booking_System.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areeb.DAL.Repositories.Implementations
{
    public class BookingRepository : IGenericRepository<Booking>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

        public async Task<IEnumerable<Booking>> GetAllAsync() => await _applicationDbContext.Bookings.Include(b => b.Event).ToListAsync();
        public async Task<Booking> GetByIdAsync(int id)
        {
            var booking = await _applicationDbContext.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            return booking ?? throw new Exception($"Booking with ID {id} not found.");
        }
        public async Task AddAsync(Booking booking)
        {
            await _applicationDbContext.Bookings.AddAsync(booking);
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Update(Booking booking)
        {
            var existingBooking = _applicationDbContext.Bookings.FirstOrDefault(b => b.Id == booking.Id) ?? throw new Exception($"Booking with ID {booking.Id} not found.");
            _applicationDbContext.Update(booking);
            _applicationDbContext.SaveChanges();

        }
        public void Delete(int id)
        {
            var booking = _applicationDbContext.Bookings.FirstOrDefault(b => b.Id == id) ?? throw new Exception($"Booking with ID {id} not found.");
            _applicationDbContext.Bookings.Remove(booking);
            _applicationDbContext.SaveChanges();


        }


    }
   
}
