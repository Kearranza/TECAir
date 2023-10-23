using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class AeropuertoController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;
    
    //Constructor del controlador
    public AeropuertoController (TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }
    
    //Metodo de creacion para el aeropuerto
    [HttpPost ("/aeropuerto")]
    public IActionResult CreateAeropuerto([FromBody] AeropuertoDto payload)
    {
        var model =_mapper.Map<Aeropuerto>(payload);
        var aeropuertoExist = _tecAirDbContext.aereopuerto.Any(e => e.id_aereo == model.id_aereo);
        if (aeropuertoExist == true)
        {
            return Ok(new { Message = "Aeropuerto Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }
    
    //Metodo de obtencion de todos los aeropuertos
    [HttpGet("/aeropuerto")]
    public IActionResult GetAllAeropuertos()
    {
        var aeropuertos = _tecAirDbContext.aereopuerto;
        return Ok(aeropuertos);
    }

    //Metodo de obtencion de aeropuertos por llave primaria
    [HttpGet("/{id}/aeropuerto")]
    public Aeropuerto GetById(string id)
    {
        var aeropuerto = _tecAirDbContext.aereopuerto.Find(id);
        return aeropuerto;
    }

    //Metodo de actualizacion de aeropuertos
    [HttpPut("/aeropuerto/id")]
    public IActionResult Put(string id, [FromBody] AeropuertoDto payload)
    {
        var model = _mapper.Map<Aeropuerto>(payload);
        _tecAirDbContext.aereopuerto.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Aeropuerto updated" });
    }
    
    //Metodo para borrar un aeropuerto
    [HttpDelete("/aeropuerto/id")]
    public IActionResult Delete(string id)
    {
        var aeropuerto = GetById(id);

        _tecAirDbContext.aereopuerto.Remove(aeropuerto);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Aeropuerto Deleted" });
    }
}