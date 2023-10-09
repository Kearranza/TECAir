namespace ApiTecAir.Models;

public class PriceDto
{
    public int PriceId { set; get; } 
        
    public int Value { set; get; }
    
    public required string Type { set; get; }
}