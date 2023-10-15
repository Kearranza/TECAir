using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using ApiTecAir.Mappers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class ClienteController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    public ClienteController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    [HttpPost("/cliente")]
    public IActionResult CreateClient([FromBody] ClienteDto payload)
    {
        var model = _mapper.Map<Cliente>(payload);
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
    public async Task<IActionResult> GetAllClients()
    {
        var clients = await _tecAirDbContext.cliente.Include(_ => _.estudiantes).ToListAsync();
        return Ok(clients);
    }

    [HttpGet("/{id}/cliente")]
    public Cliente GetById(int id)
    {
        var client = _tecAirDbContext.cliente.Find(id);
        return client;
    }

    [HttpPut("/cliente/id")]
    public IActionResult Put(int id, [FromBody] ClienteDto payload)
    {
        var model = _mapper.Map<Cliente>(payload);
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