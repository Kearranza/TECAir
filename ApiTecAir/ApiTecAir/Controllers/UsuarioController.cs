using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class UsuarioController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    public UsuarioController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    [HttpPost("/user")]
    public IActionResult CreateUser([FromBody] UsuarioDto payload)
    {
        var model = _mapper.Map<Usuario>(payload);
        var userExist = _tecAirDbContext.usuario.Any(e => e.id_usuario == model.id_usuario);
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
        var users = _tecAirDbContext.usuario;
        return Ok(users);
    }

    [HttpGet("/{id}/user")]
    public Usuario GetById(int id)
    {
        var user = _tecAirDbContext.usuario.Find(id);
        return user;
    }

    [HttpPut("/user/id")]
    public IActionResult Put(int id, [FromBody] UsuarioDto payload)
    {
        var model = _mapper.Map<Usuario>(payload);
        _tecAirDbContext.usuario.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "User updated" });
    }
    
    [HttpDelete("/user/id")]
    public IActionResult Delete(int id)
    {
        var user = GetById(id);

        _tecAirDbContext.usuario.Remove(user);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "User Deleted" });
    }
}