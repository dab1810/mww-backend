using team_scriptslingers_backend.Migrations;
using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public class EventRepository : IEventRepository
{

    private readonly EventDbContext _context;

    public EventRepository(EventDbContext context){
        _context = context;
    }

    public Event CreateEvent(Event newEvent)
    {
        _context.Event.Add(newEvent);
        _context.SaveChanges();
        return newEvent;
    }

    public void DeleteEvent(int id)
    {
        var requestedEvent = _context.Event.Find(id);
        if(requestedEvent != null){
            _context.Event.Remove(requestedEvent);
            _context.SaveChanges();
        }
    }

    public Event EditEvent(Event newEvent)
    {
        var originalEvent = _context.Event.Find(newEvent.eventId);
        if (originalEvent != null){
            originalEvent.eventTitle = newEvent.eventTitle;
            originalEvent.description = newEvent.description;
            originalEvent.location = newEvent.location;
            originalEvent.hostName = newEvent.hostName;
            originalEvent.attendeeList = newEvent.attendeeList;
            originalEvent.eventTime = newEvent.eventTime;
            originalEvent.isFinished = newEvent.isFinished;
        }
    }

    public IEnumerable<Event> GetAllEvents()
    {
        return _context.Event.ToList();
    }

    public Event GetAllFutureEvents()
    {
        return _context.Event.Where(e => e.isFinished == true);
    }

    public Event GetEventById(Event id)
    {
        return _context.Event.SingleOrDefault(c => c.eventId == id);
    }

    public Event GetEventsByMonth(int month, int year)
    {
        return _context.Event.Where(e => e.eventTime.Month == month && e.eventTime.year == year);
    }
}