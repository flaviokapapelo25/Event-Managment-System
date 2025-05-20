using Areeb.BLL.DTOs;
using Areeb.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areeb.BLL.Services.EventService
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
