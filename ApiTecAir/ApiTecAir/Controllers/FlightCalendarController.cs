using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class FlightCalendarController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public FlightCalendarController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/calendar")]
    public IActionResult CreateCalendar([FromBody] CalendarioVueloDto model)
    {
        var calendarExist = _tecAirDbContext.calendario_vuelos.Any(e => e.id_calendario == model.id_calendario);
        if (calendarExist == true)
        {
            return Ok(new { Message = "Calendar Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/calendar")]
    public IActionResult GetAllCalendars()
    {
        var calendars = _tecAirDbContext.calendario_vuelos;
        return Ok(calendars);
    }

    [HttpGet("/{id}/calendar")]
    public CalendarioVueloDto GetById(int id)
    {
        var calendar = _tecAirDbContext.calendario_vuelos.Find(id);
        return calendar;
    }

    [HttpPut("/calendar/id")]
    public IActionResult Put(int id, [FromBody] CalendarioVueloDto model)
    {
        _tecAirDbContext.calendario_vuelos.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Calendar updated" });
    }
    
    [HttpDelete("/calendar/id")]
    public IActionResult Delete(int id)
    {
        var calendar = GetById(id);

        _tecAirDbContext.calendario_vuelos.Remove(calendar);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Calendar Deleted" });
    }
}