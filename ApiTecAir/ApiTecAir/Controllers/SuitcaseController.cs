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

    [HttpPost("/suitcase")]
    public IActionResult CreateSuitcase([FromBody] SuitcaseDto model)
    {
        var suitcaseExist = _tecAirDbContext.suitcase.Any(e => e.suitcaseid == model.suitcaseid);
        if (suitcaseExist == true)
        {
            return Ok(new { Message = "Suitcase Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/suitcase")]
    public IActionResult GetAllSales()
    {
        var suitcase = _tecAirDbContext.sale;
        return Ok(suitcase);
    }

    [HttpGet("/{id}/suitcase")]
    public SuitcaseDto GetById(int id)
    {
        var suitcase = _tecAirDbContext.suitcase.Find(id);
        return suitcase;
    }

    [HttpPut("/suitcase/id")]
    public IActionResult Put(int id, [FromBody] SuitcaseDto model)
    {
        _tecAirDbContext.suitcase.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Suitcase updated" });
    }
    
    [HttpDelete("/suitcase/id")]
    public IActionResult Delete(int id)
    {
        var suitcase = GetById(id);

        _tecAirDbContext.suitcase.Remove(suitcase);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Suitcase Deleted" });
    }
}