using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class FlightDto
{
    [Key]
    public required int flightid { set; get; }
    
    public required string origin { set; get; }
    
    public required string destination { set; get; }
    
    public DateTime departuretime { set; get; }
}