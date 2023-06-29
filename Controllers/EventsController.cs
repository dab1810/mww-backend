using team_scriptslingers_backend.Models;
using team_scriptslingers_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace team_scriptslingers_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly ILogger<EventsController> _logger;
    private readonly IEventRepository _eventsRepository;

    public EventsController(ILogger<EventsController> logger, IEventRepository repository){
        _logger = logger;
        _eventsRepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Event>> GetAllEvents()
    {
        // returns a full list of events (this route is for testing purposes, in the future the default get route will be GetFutureEvents())
        return Ok(_eventsRepository.GetAllEvents());
    }

    [HttpGet]
    [Route("future-events")]
    public ActionResult<IEnumerable<Event>> GetFutureEvents()
    {
        // returns all events where the "isFinished" property is set to false, signifying it hasn't happened yet
        return Ok(_eventsRepository.GetAllFutureEvents());
    }

    [HttpGet]
    [Route("{eventId:int}")]
    public ActionResult<Event> GetEventById(int eventId)
    {
        // Checks to see if the requested event exists, then returns it if it does and returns a NoContent error if it does not
        Event returnedEvent = _eventsRepository.GetEventById(eventId);
        if(returnedEvent == null){
            return NotFound();
        }
        return Ok(returnedEvent);
    }

    [HttpGet]
    [Route("{year:int}/{month:int}")]
    public ActionResult<IEnumerable<Event>> GetEventsByMonth(int year, int month)
    {
        // returns all events where the DateTime variable contains the specified year and month
        return Ok(_eventsRepository.GetEventsByMonth(year, month));
    }

    [HttpPost]
    public ActionResult<Event> CreateEvent(Event newEvent)
    {
        // Checks to make sure the newEvent model is valid and not null, then creates and returns the new event
        if(!ModelState.IsValid || newEvent == null){
            return BadRequest();
        }
        var createdEvent = _eventsRepository.CreateEvent(newEvent);
        return Created(nameof(GetEventById), createdEvent);
    }

    [HttpPut]
    public ActionResult<Event> EditEvent(Event newEvent)
    {
        // Checks to make sure the newEvent model is valid and not null, then edits and returns the event
        if(!ModelState.IsValid || newEvent == null){
            return BadRequest();
        }
        return Ok(_eventsRepository.EditEvent(newEvent));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ActionResult DeleteEvent(int id)
    {
        // Deletes event (admin action) and returns NoContent
        _eventsRepository.DeleteEvent(id);
        return NoContent();
    }
}