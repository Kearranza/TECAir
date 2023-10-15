using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class EstudianteDto
{
    [Key]
    public required string carnet { set; get; }
    
    public required string universidad { set; get; }
    
    public int millas { set; get; }
    
    public required ClienteDto cedula { set; get; }
}