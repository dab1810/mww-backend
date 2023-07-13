using SQLitePCL;
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
        _context.Events.Add(newEvent);
        _context.SaveChanges();
        return newEvent;
    }

    public void DeleteEvent(int id)
    {
        var requestedEvent = _context.Events.Find(id);
        if(requestedEvent != null){
            _context.Events.Remove(requestedEvent);
            _context.SaveChanges();
        }
    }

    public Event EditEvent(Event newEvent)
    {
        var originalEvent = _context.Events.Find(newEvent.eventId);
        if (originalEvent != null){
            originalEvent.eventTitle = newEvent.eventTitle;
            originalEvent.description = newEvent.description;
            originalEvent.location = newEvent.location;
            originalEvent.hostName = newEvent.hostName;
            originalEvent.attendeeList = newEvent.attendeeList;
            originalEvent.eventTime = newEvent.eventTime;
            originalEvent.isFinished = newEvent.isFinished;
            _context.SaveChanges();
        }
        return originalEvent;
    }

    public IEnumerable<Event> GetAllEvents()
    {
        return _context.Events.ToList();
    }

    public IEnumerable<Event> GetAllFutureEvents()
    {
        return _context.Events.Where(e => e.eventTime > DateTime.Now).OrderBy(e => e.eventTime).ToList();
        //return _context.Events.Where(e => e.isFinished == false).OrderBy(e => e.eventTime).ToList();
    }

    public Event GetEventById(int id)
    {
        return _context.Events.SingleOrDefault(c => c.eventId == id);
    }

    public IEnumerable<Event> GetEventsByMonth(int year, int month)
    {
        return _context.Events.Where(e => e.eventTime.Month == month && e.eventTime.Year == year).ToList();
    }
}