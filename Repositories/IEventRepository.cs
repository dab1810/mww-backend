using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public interface IEventRepository{
    IEnumerable<Event> GetAllEvents();
    Event GetAllFutureEvents();
    Event GetEventById(Event id);
    Event GetEventsByMonth(int month, int year);
    Event EditEvent(Event newEvent);
    Event CreateEvent(Event newEvent);
    void DeleteEvent(int id);
}