using team_scriptslingers_backend.Migrations;
using team_scriptslingers_backend.Models;

namespace team_scriptslingers_backend.Repositories;

public class AuthService : IAuthService
{
    private static EventDbContext _context;

    public AuthService(EventDbContext context){
        _context = context;
    }

    public User CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public string SignIn(string email, string password)
    {
        throw new NotImplementedException();
    }
}