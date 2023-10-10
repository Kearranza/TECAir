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

    [HttpPost("/client")]
    public IActionResult CreateClient([FromBody] ClientDto model)
    {
        var clientExist = _tecAirDbContext.client.Any(e => e.ssn == model.ssn);
        if (clientExist == true)
        {
            return Ok(new { Message = "Client Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/client")]
    public IActionResult GetAllClients()
    {
        var clients = _tecAirDbContext.client;
        return Ok(clients);
    }

    [HttpGet("/{id}/client")]
    public ClientDto GetById(int id)
    {
        var client = _tecAirDbContext.client.Find(id);
        return client;
    }

    [HttpPut("/client/id")]
    public IActionResult Put(int id, [FromBody] ClientDto model)
    {
        _tecAirDbContext.client.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Client updated" });
    }
    
    [HttpDelete("/client/id")]
    public IActionResult Delete(int id)
    {
        var client = GetById(id);

        _tecAirDbContext.client.Remove(client);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "client Deleted" });
    }
}