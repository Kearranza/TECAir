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
    public CalendarioVuelo GetById(string id)
    {
        var calendar = _tecAirDbContext.calendario_vuelo.Find(id);
        return calendar;
    }

    [HttpGet("/calendar/info")]
    public IActionResult GetInfo()
    {
        var info = (from c in _tecAirDbContext.calendario_vuelo
            join m in _tecAirDbContext.vuelos on c.id_vuelo equals m.id_vuelo
            select new
            {
                calendarioId = c.id_calendario,
                precio = c.precio,
                aero_origen = m.aereo_origen,
                aero_final = m.aereo_final
            }).Take(100);

        return Ok(info);
    }
    
    [HttpGet("/calendar/info/{id}")]
    public IActionResult GetHoraById(string id)
    {
        var info = (from c in _tecAirDbContext.calendario_vuelo
            join m in _tecAirDbContext.vuelos on c.id_vuelo equals m.id_vuelo
            where c.id_calendario == id
            select new
            {
                hora = m.hora_salida
            }).Take(1);

        return Ok(info);
    }
    
    [HttpGet("/calendar/promos")]
    public IActionResult GetPromos()
    {
        var info = (from c in _tecAirDbContext.calendario_vuelo
            join m in _tecAirDbContext.promociones on c.id_calendario equals m.aplicado_calendario
            select new
            {
                calendarioId = c.id_calendario,
                precio = c.precio,
                aero_origen = m.descuento
            }).Take(100);

        return Ok(info);
    }

    [HttpPut("/calendar/id")]
    public IActionResult Put(string id, [FromBody] CalendarioVueloDto payload)
    {
        var model = _mapper.Map<CalendarioVuelo>(payload);
        _tecAirDbContext.calendario_vuelo.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Calendar updated" });
    }
    
    [HttpDelete("/calendar/id")]
    public IActionResult Delete(string id)
    {
        var calendar = GetById(id);

        _tecAirDbContext.calendario_vuelo.Remove(calendar);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Calendar Deleted" });
    }
}