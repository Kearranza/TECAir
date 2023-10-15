using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

[Route ("/api/[controller]")]
public class SaleController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public SaleController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/promociones")]
    public IActionResult CreateSale([FromBody] PromocionesDto model)
    {
        var saleExist = _tecAirDbContext.promociones.Any(e => e.id_promo == model.id_promo);
        if (saleExist == true)
        {
            return Ok(new { Message = "Sale Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/promociones")]
    public IActionResult GetAllSales()
    {
        var sales = _tecAirDbContext.promociones;
        return Ok(sales);
    }

    [HttpGet("/{id}/promociones")]
    public PromocionesDto GetById(int id)
    {
            var sale = _tecAirDbContext.promociones.Find(id);
            return sale;
    }

    [HttpPut("/promociones/id")]
    public IActionResult Put(int id, [FromBody] PromocionesDto model)
    {
        _tecAirDbContext.promociones.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Sale updated" });
    }
    
    [HttpDelete("/promociones/id")]
    public IActionResult Delete(int id)
    {
        var sale = GetById(id);

        _tecAirDbContext.promociones.Remove(sale);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Sale Deleted" });
    }
    
}