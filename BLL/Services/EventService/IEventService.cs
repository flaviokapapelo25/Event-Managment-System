using BLL.DTOs;
using DAL.Entities;

namespace BLL
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task CreateEventAsync(CreatedEventDTO @event);

        void UpdateEvent(Event @event);
        void DeleteEvent(int id);
    }
}
