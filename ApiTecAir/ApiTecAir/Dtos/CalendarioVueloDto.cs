using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

public class CalendarioVueloDto
{
    public  string id_calendario { set; get; }
    
    public DateTime fecha { set; get; }
    
    public float precio { set; get; }
    
    public string id_avion { set; get; }
    
    public int id_vuelo { set; get; }
    
    public List<PaseAbordarDto> pases { set; get; }
    
    public List<PromocionesDto> promociones { set; get; }
}