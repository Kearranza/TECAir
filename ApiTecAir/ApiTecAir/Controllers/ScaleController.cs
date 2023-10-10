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

    [HttpPost("/scale")]
    public IActionResult CreateScale([FromBody] ScaleDto model)
    {
        var scaleExist = _tecAirDbContext.scale.Any(e => e.scaleid == model.scaleid);
        if (scaleExist == true)
        {
            return Ok(new { Message = "Scale Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/scale")]
    public IActionResult GetAllScales()
    {
        var scales = _tecAirDbContext.scale;
        return Ok(scales);
    }

    [HttpGet("/{id}/scale")]
    public ScaleDto GetById(int id)
    {
        var scale = _tecAirDbContext.scale.Find(id);
        return scale;
    }

    [HttpPut("/scale/id")]
    public IActionResult Put(int id, [FromBody] ScaleDto model)
    {
        _tecAirDbContext.scale.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Scale updated" });
    }
    
    [HttpDelete("/scale/id")]
    public IActionResult Delete(int id)
    {
        var scale = GetById(id);

        _tecAirDbContext.scale.Remove(scale);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Scale Deleted" });
    }
}