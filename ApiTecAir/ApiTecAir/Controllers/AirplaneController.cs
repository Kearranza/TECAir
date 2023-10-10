using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class AirplaneController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public AirplaneController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/airplane")]
    public IActionResult CreateAirplane([FromBody] AirplaneDto model)
    {
        var airplaneExist = _tecAirDbContext.aeroplane.Any(e => e.plateno == model.plateno);
        if (airplaneExist == true)
        {
            return Ok(new { Message = "Airplane Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/airplane")]
    public IActionResult GetAllAirplaness()
    {
        var airplanes = _tecAirDbContext.aeroplane;
        return Ok(airplanes);
    }

    [HttpGet("/{id}/airplane")]
    public AirplaneDto GetById(int id)
    {
        var airplane = _tecAirDbContext.aeroplane.Find(id);
        return airplane;
    }

    [HttpPut("/airplane/id")]
    public IActionResult Put(int id, [FromBody] AirplaneDto model)
    {
        _tecAirDbContext.aeroplane.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Airplane updated" });
    }
    
    [HttpDelete("/airplane/id")]
    public IActionResult Delete(int id)
    {
        var airplane = GetById(id);

        _tecAirDbContext.aeroplane.Remove(airplane);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Airplane Deleted" });
    }
}