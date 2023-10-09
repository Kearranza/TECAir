namespace ApiTecAir.Models;

public class SuitcaseDto
{
    public required string SuitcaseId { set; get; }
    
    public int Weight { set; get; }
    
    public required string Color { set; get; }
    
    public required ClientDto Owner { set; get; }
}