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

    [HttpPost("/bill")]
    public IActionResult CreateBill([FromBody] BillDto model)
    {
        var billExist = _tecAirDbContext.bill.Any(e => e.billid == model.billid);
        if (billExist == true)
        {
            return Ok(new { Message = "Bill Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/bill")]
    public IActionResult GetAllBills()
    {
        var bills = _tecAirDbContext.bill;
        return Ok(bills);
    }

    [HttpGet("/{id}/bill")]
    public BillDto GetById(int id)
    {
        var bill = _tecAirDbContext.bill.Find(id);
        return bill;
    }

    [HttpPut("/bill/id")]
    public IActionResult Put(int id, [FromBody] BillDto model)
    {
        _tecAirDbContext.bill.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Bill updated" });
    }
    
    [HttpDelete("/bill/id")]
    public IActionResult Delete(int id)
    {
        var bill = GetById(id);

        _tecAirDbContext.bill.Remove(bill);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Bill Deleted" });
    }
}