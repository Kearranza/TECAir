namespace ApiTecAir.Models;

public class FlightDto
{
    public required string FlightId { set; get; }
    
    public required string Origin { set; get; }
    
    public required string Destination { set; get; }
    
    public required AirplaneDto Airplane { set; get; }
    
    public DateTime DepartureTime { set; get; }
}