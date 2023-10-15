using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class CalendarioVueloController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    public CalendarioVueloController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    [HttpPost("/calendar")]
    public IActionResult CreateCalendar([FromBody] CalendarioVueloDto payload)
    {
        var model = _mapper.Map<CalendarioVuelo>(payload);
        var calendarExist = _tecAirDbContext.calendario_vuelo.Any(e => e.id_calendario == model.id_calendario);
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
        var calendars = _tecAirDbContext.calendario_vuelo;
        return Ok(calendars);
    }

    [HttpGet("/{id}/calendar")]
    public CalendarioVuelo GetById(int id)
    {
        var calendar = _tecAirDbContext.calendario_vuelo.Find(id);
        return calendar;
    }

    [HttpPut("/calendar/id")]
    public IActionResult Put(int id, [FromBody] CalendarioVueloDto payload)
    {
        var model = _mapper.Map<CalendarioVuelo>(payload);
        _tecAirDbContext.calendario_vuelo.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Calendar updated" });
    }
    
    [HttpDelete("/calendar/id")]
    public IActionResult Delete(int id)
    {
        var calendar = GetById(id);

        _tecAirDbContext.calendario_vuelo.Remove(calendar);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Calendar Deleted" });
    }
}