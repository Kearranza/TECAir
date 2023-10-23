using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

[Route ("/api/[controller]")]
public class PromocionesController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    //Constructor del controlador
    public PromocionesController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear una promocion
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

    //Metodo para obterner los datos de todas las promociones
    [HttpGet("/promociones")]
    public IActionResult GetAllSales()
    {
        var sales = _tecAirDbContext.promociones;
        return Ok(sales);
    }

    //Metodo para obtener los datos de una promocion por su llave primaria
    [HttpGet("/{id}/promociones")]
    public Promociones GetById(int id)
    {
            var sale = _tecAirDbContext.promociones.Find(id);
            return sale;
    }

    //Metodo para actualizar una promocion
    [HttpPut("/promociones/id")]
    public IActionResult Put(int id, [FromBody] PromocionesDto payload)
    {
        var model = _mapper.Map<Promociones>(payload);
        _tecAirDbContext.promociones.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Sale updated" });
    }
    
    //Metodo para borrar una promocion
    [HttpDelete("/promociones/id")]
    public IActionResult Delete(int id)
    {
        var sale = GetById(id);

        _tecAirDbContext.promociones.Remove(sale);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Sale Deleted" });
    }
    
}