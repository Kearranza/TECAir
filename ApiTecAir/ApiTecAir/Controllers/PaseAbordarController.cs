using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class PaseAbordarController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    //Constructor del controlador
    public PaseAbordarController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear un pase
    [HttpPost("/pase_abordar")]
    public IActionResult CreateTicket([FromBody] PaseAbordarDto payload)
    {
        var model = _mapper.Map<PaseAbordar>(payload);
        var ticketExist = _tecAirDbContext.pase_abordar.Any(e => e.id_pasaje == model.id_pasaje);
        if (ticketExist == true)
        {
            return Ok(new { Message = "Ticket Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    //Metodo para obtener todos los datos de los pases
    [HttpGet("/pase_abordar")]
    public IActionResult GetAllTickets()
    {
        var tickets = _tecAirDbContext.pase_abordar;
        return Ok(tickets);
    }

    //Metodo para obtener los datos de un pase por su llave primaria
    [HttpGet("/{id}/pase_abordar")]
    public PaseAbordar GetById(int id)
    {
        var ticket = _tecAirDbContext.pase_abordar.Find(id);
        return ticket;
    }

    //Metodo para actualizar un pase
    [HttpPut("/pase_abordar/id")]
    public IActionResult Put(int id, [FromBody] PaseAbordarDto payload)
    {
        var model = _mapper.Map<PaseAbordar>(payload);
        _tecAirDbContext.pase_abordar.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Ticket updated" });
    }
    
    //Metodo para borrar un pase
    [HttpDelete("/pase_abordar/id")]
    public IActionResult Delete(int id)
    {
        var ticket = GetById(id);

        _tecAirDbContext.pase_abordar.Remove(ticket);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Ticket Deleted" });
    }
}