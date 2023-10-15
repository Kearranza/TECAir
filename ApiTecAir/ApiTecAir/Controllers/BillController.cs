using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class BillController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public BillController(TECAirDbContext tecAirs) 
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/factura")]
    public IActionResult CreateBill([FromBody] FacturaDto model)
    {
        var billExist = _tecAirDbContext.factura.Any(e => e.id_factura == model.id_factura);
        if (billExist == true)
        {
            return Ok(new { Message = "Bill Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/factura")]
    public IActionResult GetAllBills()
    {
        var bills = _tecAirDbContext.factura;
        return Ok(bills);
    }

    [HttpGet("/{id}/factura")]
    public FacturaDto GetById(int id)
    {
        var bill = _tecAirDbContext.factura.Find(id);
        return bill;
    }

    [HttpPut("/factura/id")]
    public IActionResult Put(int id, [FromBody] FacturaDto model)
    {
        _tecAirDbContext.factura.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Bill updated" });
    }
    
    [HttpDelete("/factura/id")]
    public IActionResult Delete(int id)
    {
        var bill = GetById(id);

        _tecAirDbContext.factura.Remove(bill);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Bill Deleted" });
    }
}