

namespace team_scriptslingers_backend.Models;

public class Post {
    public int postId { get; set; }
    public string? hostName { get; set; }
    public string? content { get; set; }
    public DateTime postedAt { get; set; }
}