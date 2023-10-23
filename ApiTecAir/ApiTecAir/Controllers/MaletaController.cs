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

    //Constructor para el controlador
    public MaletaController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    //Metodo para crear una maleta
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

    //Metodo para obtener los datos de todas las maletas
    [HttpGet("/maleta")]
    public IActionResult GetAllMaletas()
    {
        var suitcase = _tecAirDbContext.maleta;
        return Ok(suitcase);
    }

    //Metodo para obtener una maleta por su llave primaria
    [HttpGet("/{id}/maleta")]
    public Maleta GetById(int id)
    {
        var suitcase = _tecAirDbContext.maleta.Find(id);
        return suitcase;
    }

    //Metodo para actualizar una maleta
    [HttpPut("/maleta/id")]
    public IActionResult Put(int id, [FromBody] MaletaDto payload)
    {
        var model = _mapper.Map<Maleta>(payload);
        _tecAirDbContext.maleta.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Suitcase updated" });
    }
    
    //Metodo para borrar una maleta
    [HttpDelete("/maleta/id")]
    public IActionResult Delete(int id)
    {
        var suitcase = GetById(id);

        _tecAirDbContext.maleta.Remove(suitcase);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Suitcase Deleted" });
    }
}