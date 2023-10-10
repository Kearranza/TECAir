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
    public IActionResult CreateCalendar([FromBody] FlightCalendarDto model)
    {
        var calendarExist = _tecAirDbContext.flightcalendar.Any(e => e.calendarid == model.calendarid);
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
        var calendars = _tecAirDbContext.flightcalendar;
        return Ok(calendars);
    }

    [HttpGet("/{id}/calendar")]
    public FlightCalendarDto GetById(int id)
    {
        var calendar = _tecAirDbContext.flightcalendar.Find(id);
        return calendar;
    }

    [HttpPut("/calendar/id")]
    public IActionResult Put(int id, [FromBody] FlightCalendarDto model)
    {
        _tecAirDbContext.flightcalendar.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Calendar updated" });
    }
    
    [HttpDelete("/calendar/id")]
    public IActionResult Delete(int id)
    {
        var calendar = GetById(id);

        _tecAirDbContext.flightcalendar.Remove(calendar);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Calendar Deleted" });
    }
}