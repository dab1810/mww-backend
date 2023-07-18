using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public interface IEventRepository{
    IEnumerable<Event> GetAllEvents();
    IEnumerable<Event> GetAllFutureEvents();
    Event GetEventById(int id);
    IEnumerable<Event> GetEventsByMonth(int year, int month);
    Event EditEvent(Event newEvent);
    Event CreateEvent(Event newEvent);
    void DeleteEvent(int id);
    Event UpdateAttendeeList(Event newEvent);
}