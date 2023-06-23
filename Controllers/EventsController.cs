using team-scriptslingers-backend.Models;
using team_scriptslingers-backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace team-scriptslingers-backend.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly ILogger<EventsController> _logger;
    private readonly IEventsRepository _eventsRepository;

    public EventsController(ILogger<EventsController> logger, IEventsRepository repository){
        _logger = logger;
        _eventsRepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Event>> GetAllEvents()
    {
        return Ok(_eventsRepository.GetAllEvents());
    }
}