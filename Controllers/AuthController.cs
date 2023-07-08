using team_scriptslingers_backend.Repositories;
using team_scriptslingers_backend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace team_scriptslingers_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthRepository _authService;

    public AuthController(ILogger<AuthController> logger, IAuthRepository service){
        _logger = logger;
        _authService = service;
    }

    [HttpPost]
    [Route("register")]
    public ActionResult CreateUser(User user) 
    {
        if (user == null || !ModelState.IsValid) {
            return BadRequest();
        }
        _authService.CreateUser(user);
        return NoContent();
    }

    [HttpGet]
    [Route("login")]
    public ActionResult<string> SignIn(string email, string password) 
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            return BadRequest();
        }

        var token = _authService.SignIn(email, password);

        if (string.IsNullOrWhiteSpace(token)) {
            return Unauthorized();
        }

        return Ok(token);
    }

    [HttpPut]
    [Route("sign-up")]
    public ActionResult<User> EventSignUp(User updatedUser){
        if (updatedUser == null || !ModelState.IsValid){
            return BadRequest();
        }

        var user = _authService.GetUserById(updatedUser.userId);

        return Ok(_authService.UpdateUser(user));
    }

  [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers(){
        return Ok(_authService.GetAllUsers());
    }
    
    

}