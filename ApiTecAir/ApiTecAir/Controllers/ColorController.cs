using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class ColorController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    //Constructor del controlador
    public ColorController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear un color
    [HttpPost("/color")]
    public IActionResult CreateColor([FromBody] ColorDto payload)
    {
        var model = _mapper.Map<Color>(payload);
        var colorExist = _tecAirDbContext.color.Any(e => e.id_color == model.id_color);
        if (colorExist == true)
        {
            return Ok(new { Message = "Color Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    //Metodo para obtener todos los colores
    [HttpGet("/color")]
    public IActionResult GetAllColor()
    {
        var color = _tecAirDbContext.color;
        return Ok(color);
    }

    //Metodo para obtener un color por id
    [HttpGet("/{id}/color")]
    public Color GetById(int id)
    {
        var color = _tecAirDbContext.color.Find(id);
        return color;
    }
    
    //Metodo para cambiar un color
    [HttpPut("/color/id")]
    public IActionResult Put(int id, [FromBody] ColorDto payload)
    {
        var model = _mapper.Map<Color>(payload);
        _tecAirDbContext.color.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Color updated" });
    }
    
    //Metodo para borrar un color
    [HttpDelete("/color/id")]
    public IActionResult Delete(int id)
    {
        var color = GetById(id);

        _tecAirDbContext.color.Remove(color);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Color Deleted" });
    }
}