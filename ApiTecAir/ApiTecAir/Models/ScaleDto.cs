namespace ApiTecAir.Models;

public class ScaleDto
{
    public required string ScaleId { set; get; }
    
    public required string Origin { set; get; }
    
    public required string Destination { set; get; }
    
    public required string[] LocationOrder { set; get; }
}