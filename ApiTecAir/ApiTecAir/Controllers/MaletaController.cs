using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class MaletaController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    public MaletaController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    [HttpPost("/maleta")]
    public IActionResult CreateSuitcase([FromBody] MaletaDto payload)
    {
        var model = _mapper.Map<Maleta>(payload);
        var suitcaseExist = _tecAirDbContext.maleta.Any(e => e.id_maleta == model.id_maleta);
        if (suitcaseExist == true)
        {
            return Ok(new { Message = "Suitcase Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/maleta")]
    public IActionResult GetAllMaletas()
    {
        var suitcase = _tecAirDbContext.maleta;
        return Ok(suitcase);
    }

    [HttpGet("/{id}/maleta")]
    public Maleta GetById(int id)
    {
        var suitcase = _tecAirDbContext.maleta.Find(id);
        return suitcase;
    }

    [HttpPut("/maleta/id")]
    public IActionResult Put(int id, [FromBody] MaletaDto payload)
    {
        var model = _mapper.Map<Maleta>(payload);
        _tecAirDbContext.maleta.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Suitcase updated" });
    }
    
    [HttpDelete("/maleta/id")]
    public IActionResult Delete(int id)
    {
        var suitcase = GetById(id);

        _tecAirDbContext.maleta.Remove(suitcase);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Suitcase Deleted" });
    }
}