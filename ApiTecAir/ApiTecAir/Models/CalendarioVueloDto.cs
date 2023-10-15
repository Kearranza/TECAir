using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class CalendarioVueloDto
{
    [Key]
    public required int id_calendario { set; get; }
    
    public DateTime fecha { set; get; }
    
    public float precio { set; get; }
    
    public AvionDto id_avion { set; get; }
    
    public VuelosDto id_vuelo { set; get; }
}