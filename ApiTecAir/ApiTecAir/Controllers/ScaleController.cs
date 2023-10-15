using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class ScaleController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public ScaleController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/escala")]
    public IActionResult CreateScale([FromBody] EscalaDto model)
    {
        var scaleExist = _tecAirDbContext.escala.Any(e => e.id_escala == model.id_escala);
        if (scaleExist == true)
        {
            return Ok(new { Message = "Scale Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/escala")]
    public IActionResult GetAllScales()
    {
        var scales = _tecAirDbContext.escala;
        return Ok(scales);
    }

    [HttpGet("/{id}/escala")]
    public EscalaDto GetById(int id)
    {
        var scale = _tecAirDbContext.escala.Find(id);
        return scale;
    }

    [HttpPut("/escala/id")]
    public IActionResult Put(int id, [FromBody] EscalaDto model)
    {
        _tecAirDbContext.escala.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Scale updated" });
    }
    
    [HttpDelete("/escala/id")]
    public IActionResult Delete(int id)
    {
        var scale = GetById(id);

        _tecAirDbContext.escala.Remove(scale);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Scale Deleted" });
    }
}