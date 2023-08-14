using team_scriptslingers_backend.Migrations;
using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public class PostRepository : IPostRepository
{

    private readonly EventDbContext _context;

    public PostRepository(EventDbContext context){
        _context = context;
    }

    public Post CreatePost(Post newPost)
    {
        _context.Posts.Add(newPost);
        _context.SaveChanges();
        return newPost;
    }

    public void DeletePost(int postId)
    {
        var post = _context.Posts.Find(postId);
        if (post != null) {
            _context.Posts.Remove(post); 
            _context.SaveChanges(); 
        }
    }

    public Post? EditPost(Post newPost)
    {
        var originalPost = _context.Posts.Find(newPost.postId);
        if (originalPost != null) {
            originalPost.postContent = newPost.postContent;
            originalPost.hostName = newPost.hostName;
            originalPost.postedAt = DateTime.Now;
            _context.SaveChanges();
        }
        return originalPost;
    }

    public IEnumerable<Post> GetAllPosts()
    {
        return _context.Posts.ToList();
    } 

    public Post? GetPostById(int postId)
    {
        return _context.Posts.SingleOrDefault(c => c.postId == postId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User? GetUserById(int userId)
    {
        return _context.Users.SingleOrDefault(u => u.userId == userId);
    }
}