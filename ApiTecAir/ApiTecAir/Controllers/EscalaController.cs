using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class EscalaController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    //Constructor del controlador
    public EscalaController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear una escala
    [HttpPost("/escala")]
    public IActionResult CreateScale([FromBody] EscalaDto payload)
    {
        var model = _mapper.Map<Escala>(payload);
        var scaleExist = _tecAirDbContext.escala.Any(e => e.id_escala == model.id_escala);
        if (scaleExist == true)
        {
            return Ok(new { Message = "Scale Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    //Metodo para obtener todas las escalas
    [HttpGet("/escala")]
    public IActionResult GetAllScales()
    {
        var scales = _tecAirDbContext.escala;
        return Ok(scales);
    }

    //Metodo para obtener una escala por id
    [HttpGet("/{id}/escala")]
    public Escala GetById(int id)
    {
        var scale = _tecAirDbContext.escala.Find(id);
        return scale;
    }

    //Metodo para cambiar una escala
    [HttpPut("/escala/id")]
    public IActionResult Put(int id, [FromBody] EscalaDto payload)
    {
        var model = _mapper.Map<Escala>(payload);
        _tecAirDbContext.escala.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Scale updated" });
    }
    
    //Metodo para borrar una escala
    [HttpDelete("/escala/id")]
    public IActionResult Delete(int id)
    {
        var scale = GetById(id);

        _tecAirDbContext.escala.Remove(scale);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Scale Deleted" });
    }
}