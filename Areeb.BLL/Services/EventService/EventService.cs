using Areeb.BLL.DTOs;
using Areeb.DAL.Entities;
using Areeb.DAL.Repositories.Interfaces;
using LinkDev.IKEA.BLL.Common.Services.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areeb.BLL.Services.EventService
{
    public class EventService(IGenericRepository<Event> _eventRepository, IAttachmentService _attachmentService) : IEventService
    {
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllAsync();
        }
        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _eventRepository.GetByIdAsync(id);
        }
        public async Task CreateEventAsync(CreatedEventDTO @event)
        {
            var eventToAdd = new Event
            {
                Name = @event.Name,
                Description = @event.Description,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                Capacity = @event.Capacity,
                Price = @event.Price,
                Location = @event.Location,
                Category = (Category)@event.Category, 
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            if (@event.Image != null)
                eventToAdd.ImageUrl = await _attachmentService.UploadAsync(@event.Image , "images");

            await _eventRepository.AddAsync(eventToAdd);
        }
        public  void UpdateEvent(Event @event)
        {
            _eventRepository.Update(@event);
        }
        public void DeleteEvent(int id)
        {
            _eventRepository.Delete(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _eventRepository.GetAllAsync();
            return categories.Select(e => e.Category).Distinct();
        }
    }
}
