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

    [HttpPost("/ticket")]
    public IActionResult CreateTicket([FromBody] TicketDto model)
    {
        var ticketExist = _tecAirDbContext.ticket.Any(e => e.ticketid == model.ticketid);
        if (ticketExist == true)
        {
            return Ok(new { Message = "Ticket Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/ticket")]
    public IActionResult GetAllTickets()
    {
        var tickets = _tecAirDbContext.ticket;
        return Ok(tickets);
    }

    [HttpGet("/{id}/ticket")]
    public TicketDto GetById(int id)
    {
        var ticket = _tecAirDbContext.ticket.Find(id);
        return ticket;
    }

    [HttpPut("/ticket/id")]
    public IActionResult Put(int id, [FromBody] TicketDto model)
    {
        _tecAirDbContext.ticket.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Ticket updated" });
    }
    
    [HttpDelete("/ticket/id")]
    public IActionResult Delete(int id)
    {
        var ticket = GetById(id);

        _tecAirDbContext.ticket.Remove(ticket);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Ticket Deleted" });
    }
}