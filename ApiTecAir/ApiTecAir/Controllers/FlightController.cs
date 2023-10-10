using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class FlightController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public FlightController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/flight")]
    public IActionResult CreateFlight([FromBody] FlightDto model)
    {
        var flightExist = _tecAirDbContext.flight.Any(e => e.flightid == model.flightid);
        if (flightExist == true)
        {
            return Ok(new { Message = "Flight Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/flight")]
    public IActionResult GetAllFlights()
    {
        var flights = _tecAirDbContext.flight;
        return Ok(flights);
    }

    [HttpGet("/{id}/flight")]
    public FlightDto GetById(int id)
    {
        var flight = _tecAirDbContext.flight.Find(id);
        return flight;
    }

    [HttpPut("/flight/id")]
    public IActionResult Put(int id, [FromBody] FlightDto model)
    {
        _tecAirDbContext.flight.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Flight updated" });
    }
    
    [HttpDelete("/flight/id")]
    public IActionResult Delete(int id)
    {
        var flight = GetById(id);

        _tecAirDbContext.flight.Remove(flight);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Flight Deleted" });
    }
}