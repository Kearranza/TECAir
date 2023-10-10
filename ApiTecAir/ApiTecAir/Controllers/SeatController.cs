using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class SeatController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public SeatController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/seat")]
    public IActionResult CreateSeat([FromBody] SeatDto model)
    {
        var seatExist = _tecAirDbContext.seat.Any(e => e.seatid == model.seatid);
        if (seatExist == true)
        {
            return Ok(new { Message = "Seat Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/seat")]
    public IActionResult GetAllSeats()
    {
        var seats = _tecAirDbContext.seat;
        return Ok(seats);
    }

    [HttpGet("/{id}/seat")]
    public SeatDto GetById(int id)
    {
        var seat = _tecAirDbContext.seat.Find(id);
        return seat;
    }

    [HttpPut("/seat/id")]
    public IActionResult Put(int id, [FromBody] SeatDto model)
    {
        _tecAirDbContext.seat.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Seat updated" });
    }
    
    [HttpDelete("/seat/id")]
    public IActionResult Delete(int id)
    {
        var seat = GetById(id);

        _tecAirDbContext.seat.Remove(seat);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Seat Deleted" });
    }
}