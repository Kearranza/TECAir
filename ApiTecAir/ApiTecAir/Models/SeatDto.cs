namespace ApiTecAir.Models;

public class SeatDto
{
    public required string SeatId { set; get; }
    
    public int SeatNo { set; get; }
    
    public bool Availability { set; get; }
}