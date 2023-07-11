using System;
using System.Collections.Generic;

namespace team_scriptslingers_backend.Models;

public class Post {
    public int postId { get; set; }
    public string? hostName { get; set; }
    public string? postContent { get; set; }
    public DateTime postedAt { get; set; }
}