using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

[Route ("/api/[controller]")]
public class SaleController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    public SaleController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    [HttpPost("/promociones")]
    public IActionResult CreateSale([FromBody] PromocionesDto payload)
    {
        var model = _mapper.Map<Promociones>(payload);
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
    public Promociones GetById(int id)
    {
            var sale = _tecAirDbContext.promociones.Find(id);
            return sale;
    }

    [HttpPut("/promociones/id")]
    public IActionResult Put(int id, [FromBody] PromocionesDto payload)
    {
        var model = _mapper.Map<Promociones>(payload);
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