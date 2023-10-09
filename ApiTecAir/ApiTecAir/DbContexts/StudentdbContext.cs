using ApiTecAir.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.DbContexts;

public class StudentdbContext : DbContext
{
    public StudentdbContext(DbContextOptions<StudentdbContext> options)
        : base(options)
    {
        
    }
    public virtual DbSet<StudentDto> Student { set; get; }
}