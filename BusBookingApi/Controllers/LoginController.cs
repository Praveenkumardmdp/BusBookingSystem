using BusBookingApi.Data;
using BusBookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusBookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly Context _Context;
    public LoginController(Context Context)
    {
        _Context = Context;
    }
    public string? userName ;
    
    [HttpGet("GetLoginByCredentials")]
    public async Task<ActionResult<Login>> GetLoginByCredentials(string userName, string password)
    {
        var login = await _Context.logins.FirstOrDefaultAsync(l => l.userName == userName && l.password == password);

        if (login == null)
        {
            return NotFound();
        }

        return Ok(login);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Login>>> TotalUser()
    {
        var TotalUsers = await _Context.logins.ToListAsync();
        return Ok(TotalUsers);
    }
}