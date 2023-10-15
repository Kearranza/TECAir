using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class ClientController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public ClientController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/cliente")]
    public IActionResult CreateClient([FromBody] ClienteDto model)
    {
        var clientExist = _tecAirDbContext.cliente.Any(e => e.cedula == model.cedula);
        if (clientExist == true)
        {
            return Ok(new { Message = "Client Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/cliente")]
    public IActionResult GetAllClients()
    {
        var clients = _tecAirDbContext.cliente;
        return Ok(clients);
    }

    [HttpGet("/{id}/cliente")]
    public ClienteDto GetById(int id)
    {
        var client = _tecAirDbContext.cliente.Find(id);
        return client;
    }

    [HttpPut("/cliente/id")]
    public IActionResult Put(int id, [FromBody] ClienteDto model)
    {
        _tecAirDbContext.cliente.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Client updated" });
    }
    
    [HttpDelete("/cliente/id")]
    public IActionResult Delete(int id)
    {
        var client = GetById(id);

        _tecAirDbContext.cliente.Remove(client);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "cliente Deleted" });
    }
}