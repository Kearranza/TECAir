using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class PriceController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public PriceController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/price")]
    public IActionResult CreateUser([FromBody] PriceDto model)
    {
        var priceExist = _tecAirDbContext.price.Any(e => e.priceid == model.priceid);
        if (priceExist == true)
        {
            return Ok(new { Message = "Price Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/price")]
    public IActionResult GetAllPrices()
    {
        var prices = _tecAirDbContext.price;
        return Ok(prices);
    }

    [HttpGet("/{id}/price")]
    public PriceDto GetById(int id)
    {
        var price = _tecAirDbContext.price.Find(id);
        return price;
    }

    [HttpPut("/price/id")]
    public IActionResult Put(int id, [FromBody] PriceDto model)
    {
        _tecAirDbContext.price.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Price updated" });
    }
    
    [HttpDelete("/price/id")]
    public IActionResult Delete(int id)
    {
        var price = GetById(id);

        _tecAirDbContext.price.Remove(price);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Price Deleted" });
    }
}