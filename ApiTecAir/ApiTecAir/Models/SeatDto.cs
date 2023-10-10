using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class SeatDto
{
    [Key]
    public int seatid { set; get; }
    
    public bool availability { set; get; }
    
    public required string seatno { set; get; }
    
}