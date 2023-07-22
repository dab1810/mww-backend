using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace team_scriptslingers_backend.Models;

public class Event {
    public int eventId { get; set; }
    public string? eventTitle { get; set; }
    public string? description { get; set; }
    public string? location { get; set; }
    public string? hostName { get; set; }
    public string? attendeeList { get; set; }
    public DateTime eventTime { get; set; }
}