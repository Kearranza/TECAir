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

    [HttpPost("/student")]
    public IActionResult CreateScale([FromBody] StudentDto model)
    {
        var studentExist = _tecAirDbContext.student.Any(e => e.studentid == model.studentid);
        if (studentExist == true)
        {
            return Ok(new { Message = "Student Already Created" });
        }

        _tecAirDbContext.Add(model);
        _tecAirDbContext.SaveChanges();

        return Ok(model);
    }

    [HttpGet("/student")]
    public IActionResult GetAllStudents()
    {
        var students = _tecAirDbContext.student;
        return Ok(students);
    }

    [HttpGet("/{id}/student")]
    public StudentDto GetById(int id)
    {
        var student = _tecAirDbContext.student.Find(id);
        return student;
    }

    [HttpPut("/student/id")]
    public IActionResult Put(int id, [FromBody] StudentDto model)
    {
        _tecAirDbContext.student.Attach(model);
        _tecAirDbContext.Entry(model).State = EntityState.Modified;

        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Student updated" });
    }
    
    [HttpDelete("/student/id")]
    public IActionResult Delete(int id)
    {
        var student = GetById(id);

        _tecAirDbContext.student.Remove(student);
        _tecAirDbContext.SaveChanges();

        return Ok(new { MESSAGE = "Student Deleted" });
    }
}