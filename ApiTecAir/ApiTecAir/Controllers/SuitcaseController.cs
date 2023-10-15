using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class SuitcaseController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public SuitcaseController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/maleta")]
    public IActionResult CreateSuitcase([FromBody] MaletaDto model)
    {
        var suitcaseExist = _tecAirDbContext.maleta.Any(e => e.id_maleta == model.id_maleta);
        if (suitcaseExist == true)
        {
            return Ok(new { Message = "Suitcase Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/maleta")]
    public IActionResult GetAllSales()
    {
        var suitcase = _tecAirDbContext.promociones;
        return Ok(suitcase);
    }

    [HttpGet("/{id}/maleta")]
    public MaletaDto GetById(int id)
    {
        var suitcase = _tecAirDbContext.maleta.Find(id);
        return suitcase;
    }

    [HttpPut("/maleta/id")]
    public IActionResult Put(int id, [FromBody] MaletaDto model)
    {
        _tecAirDbContext.maleta.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Suitcase updated" });
    }
    
    [HttpDelete("/maleta/id")]
    public IActionResult Delete(int id)
    {
        var suitcase = GetById(id);

        _tecAirDbContext.maleta.Remove(suitcase);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Suitcase Deleted" });
    }
}