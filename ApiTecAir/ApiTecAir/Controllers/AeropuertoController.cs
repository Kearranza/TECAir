using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class AeropuertoController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public AeropuertoController (TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }
    
    [HttpPost ("/aeropuerto")]
    public IActionResult CreateAeropuerto([FromBody] AeropuertoDto model)
    {
        var aeropuertoExist = _tecAirDbContext.aereopuerto.Any(e => e.id_aereo == model.id_aereo);
        if (aeropuertoExist == true)
        {
            return Ok(new { Message = "Aeropuerto Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }
    
    [HttpGet("/aeropuerto")]
    public IActionResult GetAllAeropuertos()
    {
        var aeropuertos = _tecAirDbContext.aereopuerto;
        return Ok(aeropuertos);
    }

    [HttpGet("/{id}/aeropuerto")]
    public AeropuertoDto GetById(int id)
    {
        var aeropuerto = _tecAirDbContext.aereopuerto.Find(id);
        return aeropuerto;
    }

    [HttpPut("/aeropuerto/id")]
    public IActionResult Put(int id, [FromBody] AeropuertoDto model)
    {
        _tecAirDbContext.aereopuerto.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Aeropuerto updated" });
    }
    
    [HttpDelete("/aeropuerto/id")]
    public IActionResult Delete(int id)
    {
        var aeropuerto = GetById(id);

        _tecAirDbContext.aereopuerto.Remove(aeropuerto);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Aeropuerto Deleted" });
    }
}