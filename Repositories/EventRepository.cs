using team_scriptslingers_backend.Migrations;
using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public class EventRepository : IEventRepository
{
    public Event CreateEvent(Event newEvent)
    {
        throw new NotImplementedException();
    }

    public void DeleteEvent(int id)
    {
        throw new NotImplementedException();
    }

    public Event EditEvent(Event newEvent)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Event> GetAllEvents()
    {
        throw new NotImplementedException();
    }

    public Event GetAllFutureEvents()
    {
        throw new NotImplementedException();
    }

    public Event GetEventById(Event id)
    {
        throw new NotImplementedException();
    }

    public Event GetEventsByMonth(int month, int year)
    {
        throw new NotImplementedException();
    }
}