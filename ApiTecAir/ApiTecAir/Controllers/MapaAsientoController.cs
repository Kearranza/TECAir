using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class MapaAsientoController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    //Constructor del controlador
    public MapaAsientoController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear asientos
    [HttpPost("/asiento")]
    public IActionResult CreateSeat([FromBody] MapaAsientoDto payload)
    {
        var model = _mapper.Map<MapaAsiento>(payload);
        var seatExist = _tecAirDbContext.mapa_asientos.Any(e => e.id_mapa_asiento == model.id_mapa_asiento);
        if (seatExist == true)
        {
            return Ok(new { Message = "Seat Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    //Metodo para obtener los datos de todos los asientos
    [HttpGet("/asiento")]
    public IActionResult GetAllSeats()
    {
        var seats = _tecAirDbContext.mapa_asientos;
        return Ok(seats);
    }

    //Metodo para obtener un asiento por su llave primaria
    [HttpGet("/{id}/asiento")]
    public MapaAsiento GetById(int id)
    {
        var seat = _tecAirDbContext.mapa_asientos.Find(id);
        return seat;
    }

    //Metodo para actualizar un asiento
    [HttpPut("/asiento/id")]
    public IActionResult Put(int id, [FromBody] MapaAsientoDto payload)
    {
        var model = _mapper.Map<MapaAsiento>(payload);
        _tecAirDbContext.mapa_asientos.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Seat updated" });
    }
    
    //Metodo para borrar un asiento
    [HttpDelete("/asiento/id")]
    public IActionResult Delete(int id)
    {
        var seat = GetById(id);

        _tecAirDbContext.mapa_asientos.Remove(seat);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Seat Deleted" });
    }
}