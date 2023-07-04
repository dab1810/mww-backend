using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public interface IPostRepository{
    IEnumerable<Post> GetAllPosts();
    Post? GetPostById(int postId);
    Post CreatePost(Post newPost);
    Post? EditPost(Post newPost);
    void DeletePost(int postId);
    User? GetUserById(int userId);
    IEnumerable<User> GetAllUsers();
}