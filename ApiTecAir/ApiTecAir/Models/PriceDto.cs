using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class PriceDto
{
    [Key]
    public int priceid { set; get; } 
        
    public required string type { set; get; }
    
    public int value { set; get; }
}