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

    [HttpPost("/avion")]
    public IActionResult CreateAirplane([FromBody] AvionDto model)
    {
        var airplaneExist = _tecAirDbContext.avion.Any(e => e.placa == model.placa);
        if (airplaneExist == true)
        {
            return Ok(new { Message = "Avion Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/avion")]
    public IActionResult GetAllAvion()
    {
        var avion = _tecAirDbContext.avion;
        return Ok(avion);
    }

    [HttpGet("/{id}/avion")]
    public AvionDto GetById(int id)
    {
        var airplane = _tecAirDbContext.avion.Find(id);
        return airplane;
    }

    [HttpPut("/avion/id")]
    public IActionResult Put(int id, [FromBody] AvionDto model)
    {
        _tecAirDbContext.avion.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Avion updated" });
    }
    
    [HttpDelete("/avion/id")]
    public IActionResult Delete(int id)
    {
        var airplane = GetById(id);

        _tecAirDbContext.avion.Remove(airplane);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Avion Deleted" });
    }
}