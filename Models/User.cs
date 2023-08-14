using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace team_scriptslingers_backend.Models;

public class User{
    public int userId { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    [Required]
    [EmailAddress]
    public string? email { get; set; }
    [Required]
    public string? password { get; set; }
    public Boolean? isAdmin { get; set; }
    [JsonIgnore]
    public string? enrolledIn { get; set; }
}