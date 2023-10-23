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

    //Constructor del controlador
    public ClienteController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear un cliente
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

    //Metodo para obtener los datos de todos los clientes
    [HttpGet("/cliente")]
    public IActionResult GetAllClients()
    {
        var clients = _tecAirDbContext.cliente;
        return Ok(clients);
    }

    //Metodo para obtener un cliente
    [HttpGet("/{id}/cliente")]
    public Cliente GetById(int id)
    {
        var client = _tecAirDbContext.cliente.Find(id);
        return client;
    }

    //Metodo para obtener las maletas de un cliente
    //solicitado por desarrolladores web
    [HttpGet("/cliente/{id}/maletas")]
    public int GetMaletasCliente(int id)
    {
        var cantidad = _tecAirDbContext.cliente.Find(id).maletas.Count();

        return cantidad;
    }

    //Metodo para actualizar un cliente
    [HttpPut("/cliente/id")]
    public IActionResult Put(int id, [FromBody] ClienteDto payload)
    {
        var model = _mapper.Map<Cliente>(payload);
        _tecAirDbContext.cliente.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Client updated" });
    }
    
    //Metodo para borrar un cliente
    [HttpDelete("/cliente/id")]
    public IActionResult Delete(int id)
    {
        var client = GetById(id);

        _tecAirDbContext.cliente.Remove(client);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "cliente Deleted" });
    }
}