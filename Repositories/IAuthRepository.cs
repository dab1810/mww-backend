using team_scriptslingers_backend.Migrations;
using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public interface IAuthRepository
{
    User CreateUser(User user);
    string SignIn(string email, string password);
    User GetUserById(int id);
    User UpdateUser(User user);
    IEnumerable<User> GetAllUsers();
}