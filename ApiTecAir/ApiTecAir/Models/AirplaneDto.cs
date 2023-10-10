using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class AirplaneDto
{
    [Key]
    public required string plateno { set; get; }
    
    public int size { set; get; }
    
    public int row { set; get; }
    
    public int pcolumn { set; get; }
}