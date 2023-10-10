using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class TicketDto
{
    [Key]
    public int ticketid { set; get; }
    
    public string gate { set; get; }
    
    public DateTime departuretime { set; get; }
}