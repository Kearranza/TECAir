using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class AvionController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    public AvionController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    [HttpPost("/avion")]
    public IActionResult CreateAirplane([FromBody] AvionDto payload)
    {
        var model = _mapper.Map<Avion>(payload);
        var airplaneExist = _tecAirDbContext.avion.Any(e => e.placa == model.placa);
        if (airplaneExist == true)
        {
            return Ok(new { Message = "Avion Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/avion")]
    public IActionResult GetAllAvion()
    {
        var avion = _tecAirDbContext.avion;
        return Ok(avion);
    }

    [HttpGet("/{id}/avion")]
    public Avion GetById(int id)
    {
        var airplane = _tecAirDbContext.avion.Find(id);
        return airplane;
    }

    [HttpPut("/avion/id")]
    public IActionResult Put(int id, [FromBody] AvionDto payload)
    {
        var model = _mapper.Map<Avion>(payload);
        _tecAirDbContext.avion.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Avion updated" });
    }
    
    [HttpDelete("/avion/id")]
    public IActionResult Delete(int id)
    {
        var airplane = GetById(id);

        _tecAirDbContext.avion.Remove(airplane);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Avion Deleted" });
    }
}