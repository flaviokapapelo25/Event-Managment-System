using Areeb.DAL.Entities;
using Areeb.DAL.Repositories.Interfaces;
using Event_Booking_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Areeb.DAL.Repositories.Implementations
{
    public class EventRepository(ApplicationDbContext applicationDbContext) : IGenericRepository<Event>
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public async Task<IEnumerable<Event>> GetAllAsync() => await _applicationDbContext.Events.Include(e => e.Bookings).ToListAsync();

        public async Task<Event> GetByIdAsync(int id)
        {
            var eventEntity = await _applicationDbContext.Events.Include(e => e.Bookings).FirstOrDefaultAsync(e => e.Id == id);
            return eventEntity ?? throw new Exception($"Event with ID {id} not found.");
        }

        public async Task AddAsync(Event applicationEvent)
        {
              await _applicationDbContext.Events.AddAsync(applicationEvent);
              await _applicationDbContext.SaveChangesAsync();
        }
        public  void Update(Event applicationEvent)
        {
            var existingEvent = _applicationDbContext.Events.FirstOrDefault(e => e.Id == applicationEvent.Id) ?? throw new Exception($"Event with ID {applicationEvent.Id} not found.");
            _applicationDbContext.Update(applicationEvent);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var eventEntity = _applicationDbContext.Events.FirstOrDefault(e => e.Id == id) ?? throw new Exception($"Event with ID {id} not found.");
            _applicationDbContext.Events.Remove(eventEntity);
            _applicationDbContext.SaveChanges();
        }

       

        

    }
}
