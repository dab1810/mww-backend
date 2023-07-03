namespace team_scriptslingers_backend.Models;

public class Comment {
    public int commentId { get; set; }
    public string? commenter { get; set; }
    public string? content { get; set; }
    public DateTime postedAt { get; set; }
}