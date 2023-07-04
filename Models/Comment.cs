namespace team_scriptslingers_backend.Models;

public class Comment {
    public int commentId { get; set; }
    public string? commenter { get; set; }
    public string? commentContent { get; set; }
    public DateTime postedAt { get; set; }
        // Foreign key to associate the comment with a post
        public int postId { get; set; }
        // Navigation property for the associated post
        public Post? postContent { get; set; }

}