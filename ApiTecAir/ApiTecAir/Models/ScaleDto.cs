using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class ScaleDto
{
    [Key]
    public int scaleid { set; get; }
    
    public required string origin { set; get; }
    
    public required string destination { set; get; }
    
    public required string placeorder { set; get; }
}