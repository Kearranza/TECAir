using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class SuitcaseDto
{
    [Key]
    public int suitcaseid { set; get; }
    
    public long weight { set; get; }
    
    public required string color { set; get; }
}