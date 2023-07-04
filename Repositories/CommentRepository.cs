using team_scriptslingers_backend.Migrations;
using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly EventDbContext _context;
    public CommentRepository(EventDbContext context){
        _context = context;
    }

    public Comment CreateComment(Comment newComment)
    {
        _context.Comments.Add(newComment);
        _context.SaveChanges();
        return newComment;
    }

    public void DeleteComment(int commentId)
    {
        var comment = _context.Comments.Find(commentId);
        if (comment != null) {
            _context.Comments.Remove(comment); 
            _context.SaveChanges(); 
        }
    }

    public Comment? EditComment(Comment newComment)
    {
        var originalComment = _context.Comments.Find(newComment.commentId);
        if (originalComment != null) {
            originalComment.commentContent = newComment.commentContent;
            originalComment.commenter = newComment.commenter;
            originalComment.postedAt = DateTime.Now;
            _context.SaveChanges();
        }
        return originalComment;
    }

    public IEnumerable<Comment> GetAllComments()
    {
        return _context.Comments.ToList();
    }

    public Comment? GetCommentById(int commentId)
    {
        return _context.Comments.SingleOrDefault(c => c.commentId == commentId);
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