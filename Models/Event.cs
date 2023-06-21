using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace team_scriptslingers_backend;

public class Event {
    public int eventId { get; set; }
    public string? eventTitle { get; set; }
    public string? decription { get; set; }
    public string? location { get; set; }
    public string? hostName { get; set; }
    public string? attendeeList { get; set; }
    public DateTime createdAt { get; set; }
}