using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class VueloController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    //Constructor del controlador
    public VueloController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear un vuelo
    [HttpPost("/vuelos")]
    public IActionResult CreateFlight([FromBody] VuelosDto payload)
    {
        var model = _mapper.Map<Vuelos>(payload);
        var flightExist = _tecAirDbContext.vuelos.Any(e => e.id_vuelo == model.id_vuelo);
        if (flightExist == true)
        {
            return Ok(new { Message = "Flight Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    //Metodo para obtener los datos de todos los vuelos
    [HttpGet("/vuelos")]
    public IActionResult GetAllFlights()
    {
        var flights = _tecAirDbContext.vuelos;
        return Ok(flights);
    }

    //Metodo para obtener los datos de un vuelo
    [HttpGet("/{id}/vuelos")]
    public Vuelos GetById(int id)
    {
        var flight = _tecAirDbContext.vuelos.Find(id);
        return flight;
    }

    //Metodo para actualizar un vuelo
    [HttpPut("/vuelos/id")]
    public IActionResult Put(int id, [FromBody] VuelosDto payload)
    {
        
        var model = _mapper.Map<Vuelos>(payload);
        _tecAirDbContext.vuelos.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Flight updated" });
    }
    
    //Metodo para borrar un vuelo
    [HttpDelete("/vuelos/id")]
    public IActionResult Delete(int id)
    {
        var flight = GetById(id);

        _tecAirDbContext.vuelos.Remove(flight);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Flight Deleted" });
    }
}