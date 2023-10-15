using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

public class VuelosDto
{
    public int id_vuelo { set; get; }
    
    public DateTime hora_salida { set; get; }
    
    public string aereo_origen { set; get; }
    
    public string aereo_final { set; get; }
    
    public List<CalendarioVueloDto> calendarios { set; get; }
    
    public List<EscalaDto> escalas { set; get; }
}