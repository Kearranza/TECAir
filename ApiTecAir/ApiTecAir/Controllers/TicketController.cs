using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class TicketController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public TicketController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/pase_abordar")]
    public IActionResult CreateTicket([FromBody] PaseAbordarDto model)
    {
        var ticketExist = _tecAirDbContext.pase_abordar.Any(e => e.id_pasaje == model.id_pasaje);
        if (ticketExist == true)
        {
            return Ok(new { Message = "Ticket Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/pase_abordar")]
    public IActionResult GetAllTickets()
    {
        var tickets = _tecAirDbContext.pase_abordar;
        return Ok(tickets);
    }

    [HttpGet("/{id}/pase_abordar")]
    public PaseAbordarDto GetById(int id)
    {
        var ticket = _tecAirDbContext.pase_abordar.Find(id);
        return ticket;
    }

    [HttpPut("/pase_abordar/id")]
    public IActionResult Put(int id, [FromBody] PaseAbordarDto model)
    {
        _tecAirDbContext.pase_abordar.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Ticket updated" });
    }
    
    [HttpDelete("/pase_abordar/id")]
    public IActionResult Delete(int id)
    {
        var ticket = GetById(id);

        _tecAirDbContext.pase_abordar.Remove(ticket);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Ticket Deleted" });
    }
}