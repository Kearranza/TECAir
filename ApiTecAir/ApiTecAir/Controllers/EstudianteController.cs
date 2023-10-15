using ApiTecAir.DbContexts;
using ApiTecAir.Dtos;
using ApiTecAir.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class EstudianteController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;
    private IMapper _mapper;

    public EstudianteController(TECAirDbContext tecAirs, IMapper mapper)
    {
        _tecAirDbContext = tecAirs;
        _mapper = mapper;
    }

    [HttpPost("/estudiante")]
    public IActionResult CreateScale([FromBody] EstudianteDto payload)
    {
        var model = _mapper.Map<Estudiante>(payload);
        var studentExist = _tecAirDbContext.estudiante.Any(e => e.carnet == model.carnet);
        if (studentExist == true)
        {
            return Ok(new { Message = "Student Already Created" });
        }
        
        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/estudiante")]
    public IActionResult GetAllStudents()
    {
        var students = _tecAirDbContext.estudiante;
        return Ok(students);
    }

    [HttpGet("/{id}/estudiante")]
    public Estudiante GetById(int id)
    {
        var student = _tecAirDbContext.estudiante.Find(id);
        return student;
    }

    [HttpPut("/estudiante/id")]
    public IActionResult Put(int id, [FromBody] EstudianteDto payload)
    {
        var model = _mapper.Map<Estudiante>(payload);
        _tecAirDbContext.estudiante.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Student updated" });
    }
    
    [HttpDelete("/estudiante/id")]
    public IActionResult Delete(int id)
    {
        var student = GetById(id);

        _tecAirDbContext.estudiante.Remove(student);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Student Deleted" });
    }
}