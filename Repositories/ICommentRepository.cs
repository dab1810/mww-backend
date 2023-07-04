using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public interface ICommentRepository{
    IEnumerable<Comment> GetAllComments();
    Comment? GetCommentById(int commentId);
    Comment CreateComment(Comment newComment);
    Comment? EditComment(Comment newComment);
    void DeleteComment(int commentId);
    User? GetUserById(int userId);
    IEnumerable<User> GetAllUsers();
}