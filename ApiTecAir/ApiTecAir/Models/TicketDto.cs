namespace ApiTecAir.Models;

public class TicketDto
{
    public required string TicketId { set; get; }
    
    public int SeatNo { set; get; }
    
    public int GateNo { set; get; }
    
    public required FlightDto Flight { set; get; }
}