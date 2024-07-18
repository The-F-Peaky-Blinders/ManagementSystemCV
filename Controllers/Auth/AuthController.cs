using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using ManagementSystemCV.App.Interfaces;

public class AuthController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IUser _userService;
    private readonly IJwtAuthenticationService _jwtAuthenticationService;

    public AuthController(IConfiguration configuration, IUser userService, IJwtAuthenticationService jwtAuthenticationService)
    {
        _configuration = configuration;
        _userService = userService;
        _jwtAuthenticationService = jwtAuthenticationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _userService.GetUserByEmailAsync(email);

        if (user == null || !VerifyPassword(password, user.Password))
        {
            return Unauthorized();
        }

        var token = _jwtAuthenticationService.GenerateJwtToken(user.Email);
        return Ok(new { token });
    }

    private bool VerifyPassword(string password, string storedPassword)
    {
        return password == storedPassword;
    }
}