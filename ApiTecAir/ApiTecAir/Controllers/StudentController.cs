using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.Controllers;

public class StudentController : ControllerBase
{
    private TECAirDbContext _tecAirDbContext;

    public StudentController(TECAirDbContext tecAirs)
    {
        _tecAirDbContext = tecAirs;
    }

    [HttpPost("/estudiante")]
    public IActionResult CreateScale([FromBody] EstudianteDto model)
    {
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
    public EstudianteDto GetById(int id)
    {
        var student = _tecAirDbContext.estudiante.Find(id);
        return student;
    }

    [HttpPut("/estudiante/id")]
    public IActionResult Put(int id, [FromBody] EstudianteDto model)
    {
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