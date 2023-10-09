namespace ApiTecAir.Models;

public class AirplaneDto
{
    public required string PlateNo { set; get; }
    
    public int Size { set; get; }
    
    public int Rows { set; get; }
    
    public int Columns { set; get; }
}