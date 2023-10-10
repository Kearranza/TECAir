using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class StudentDto
{
    [Key]
    public required string studentid { set; get; }
    
    public required string university { set; get; }
    
    public int miles { set; get; }
}