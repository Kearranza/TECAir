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

    [HttpPost("/sale")]
    public IActionResult CreateSale([FromBody] SaleDto model)
    {
        var saleExist = _tecAirDbContext.sale.Any(e => e.saleid == model.saleid);
        if (saleExist == true)
        {
            return Ok(new { Message = "Sale Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/sale")]
    public IActionResult GetAllSales()
    {
        var sales = _tecAirDbContext.sale;
        return Ok(sales);
    }

    [HttpGet("/{id}/sale")]
    public SaleDto GetById(int id)
    {
            var sale = _tecAirDbContext.sale.Find(id);
            return sale;
    }

    [HttpPut("/sale/id")]
    public IActionResult Put(int id, [FromBody] SaleDto model)
    {
        _tecAirDbContext.sale.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Sale updated" });
    }
    
    [HttpDelete("/sale/id")]
    public IActionResult Delete(int id)
    {
        var sale = GetById(id);

        _tecAirDbContext.sale.Remove(sale);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Sale Deleted" });
    }
    
}