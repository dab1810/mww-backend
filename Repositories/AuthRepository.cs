using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using team_scriptslingers_backend.Migrations;
using team_scriptslingers_backend.Models;
using bcrypt = BCrypt.Net.BCrypt;

namespace team_scriptslingers_backend.Repositories;

public class AuthRepository : IAuthRepository
{
    private static EventDbContext _context;
    private static IConfiguration _config;

    public AuthRepository(EventDbContext context, IConfiguration config){
        _context = context;
        _config = config;
    }

    private string BuildToken(User user) {
        var secret = _config.GetValue<string>("MoWildToken");
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.email ?? ""),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.lastName ?? ""),
            new Claim(JwtRegisteredClaimNames.GivenName, user.firstName ?? "")
        };

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signingCredentials
        );

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }

    public User CreateUser(User user)
    {
        var passwordHash = bcrypt.HashPassword(user.password);
        user.password = passwordHash;

        _context.Add(user);
        _context.SaveChanges();
        return user;
    }

    public string SignIn(string email, string password)
    {
        var user = _context.Users.SingleOrDefault(x => x.email == email);
        var verified = false;

        if (user != null) {
            verified = bcrypt.Verify(password, user.password);
        }

        if(user == null || !verified){
            return String.Empty;
        }

        return BuildToken(user);
    }
}