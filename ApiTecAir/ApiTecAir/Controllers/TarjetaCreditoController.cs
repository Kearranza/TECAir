using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;


public class TarjetaCreditoController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    TarjetaCreditoController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    } 
    
    [HttpPost ("/tarjeta")]
    public IActionResult CreateTarjeta([FromBody] TarjetaCreditoDto model)
    {
        var tarjetaExist = _tecAirDbContext.tarjeta_credito.Any(e => e.num_tarjeta == model.num_tarjeta);
        if (tarjetaExist == true)
        {
            return Ok(new { Message = "Tarjeta de credito Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }
    
    [HttpGet("/tarjeta")]
    public IActionResult GetAllTarjetas()
    {
        var tarjetas = _tecAirDbContext.tarjeta_credito;
        return Ok(tarjetas);
    }

    [HttpGet("/{id}/tarjeta")]
    public TarjetaCreditoDto GetById(int id)
    {
        var tarjeta = _tecAirDbContext.tarjeta_credito.Find(id);
        return tarjeta;
    }

    [HttpPut("/tarjeta/id")]
    public IActionResult Put(int id, [FromBody] TarjetaCreditoDto model)
    {
        _tecAirDbContext.tarjeta_credito.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Tarjeta updated" });
    }
    
    [HttpDelete("/tarjeta/id")]
    public IActionResult Delete(int id)
    {
        var tarjeta = GetById(id);

        _tecAirDbContext.tarjeta_credito.Remove(tarjeta);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Tarjeta de credito Deleted" });
    }
}