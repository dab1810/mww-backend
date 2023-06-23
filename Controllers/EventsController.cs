using team_scriptslingers_backend.Models;
using team_scriptslingers_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace team_scriptslingers_backend.Controllers;

[ApiController]
[Route("[controller]")]
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
        return Ok(_eventsRepository.GetAllEvents());
    }
}