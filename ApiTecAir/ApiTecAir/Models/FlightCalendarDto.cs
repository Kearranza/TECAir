using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class FlightCalendarDto
{
    [Key]
    public required int calendarid { set; get; }
    
    public DateTime date { set; get; }
}