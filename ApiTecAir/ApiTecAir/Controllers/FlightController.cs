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

    [HttpPost("/vuelos")]
    public IActionResult CreateFlight([FromBody] VuelosDto model)
    {
        var flightExist = _tecAirDbContext.vuelos.Any(e => e.id_vuelo == model.id_vuelo);
        if (flightExist == true)
        {
            return Ok(new { Message = "Flight Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/vuelos")]
    public IActionResult GetAllFlights()
    {
        var flights = _tecAirDbContext.vuelos;
        return Ok(flights);
    }

    [HttpGet("/{id}/vuelos")]
    public VuelosDto GetById(int id)
    {
        var flight = _tecAirDbContext.vuelos.Find(id);
        return flight;
    }

    [HttpPut("/vuelos/id")]
    public IActionResult Put(int id, [FromBody] VuelosDto model)
    {
        _tecAirDbContext.vuelos.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Flight updated" });
    }
    
    [HttpDelete("/vuelos/id")]
    public IActionResult Delete(int id)
    {
        var flight = GetById(id);

        _tecAirDbContext.vuelos.Remove(flight);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Flight Deleted" });
    }
}