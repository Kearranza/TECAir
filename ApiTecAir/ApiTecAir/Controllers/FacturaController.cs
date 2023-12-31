using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class FacturaController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    //Constructor para crear el controlador
    public FacturaController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear una factura
    [HttpPost("/factura")]
    public IActionResult CreateBill([FromBody] FacturaDto payload)
    {
        var model = _mapper.Map<Factura>(payload);
        var billExist = _tecAirDbContext.factura.Any(e => e.id_factura == model.id_factura);
        if (billExist == true)
        {
            return Ok(new { Message = "Bill Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    //Metodo para obtener los datos de todas las facturas
    [HttpGet("/factura")]
    public IActionResult GetAllBills()
    {
        var bills = _tecAirDbContext.factura;
        return Ok(bills);
    }

    //Metodo para obtener una factura por su llave primaria
    [HttpGet("/{id}/factura")]
    public Factura GetById(int id)
    {
        var bill = _tecAirDbContext.factura.Find(id);
        return bill;
    }

    //Metodo para actualizar una factura
    [HttpPut("/factura/id")]
    public IActionResult Put(int id, [FromBody] FacturaDto payload)
    {
        var model = _mapper.Map<Factura>(payload);
        _tecAirDbContext.factura.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Bill updated" });
    }
   
    //Metodo para borrar una factura
    [HttpDelete("/factura/id")]
    public IActionResult Delete(int id)
    {
        var bill = GetById(id);

        _tecAirDbContext.factura.Remove(bill);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Bill Deleted" });
    }
}