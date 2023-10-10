using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class UserController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public UserController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/user")]
    public IActionResult CreateUser([FromBody] UserDto model)
    {
        var userExist = _tecAirDbContext.usert.Any(e => e.userid == model.userid);
        if (userExist == true)
        {
            return Ok(new { Message = "User Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/user")]
    public IActionResult GetAllUsers()
    {
        var users = _tecAirDbContext.usert;
        return Ok(users);
    }

    [HttpGet("/{id}/user")]
    public UserDto GetById(int id)
    {
        var user = _tecAirDbContext.usert.Find(id);
        return user;
    }

    [HttpPut("/user/id")]
    public IActionResult Put(int id, [FromBody] UserDto model)
    {
        _tecAirDbContext.usert.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "User updated" });
    }
    
    [HttpDelete("/user/id")]
    public IActionResult Delete(int id)
    {
        var user = GetById(id);

        _tecAirDbContext.usert.Remove(user);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "User Deleted" });
    }
}