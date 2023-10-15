using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

public class PromocionesDto
{
    public int id_promo { set; get; }
    
    public float descuento { set; get; }
    
    public DateTime fecha_inicio { set; get; }
    
    public DateTime fecha_fin { set; get; }
    
    public  string origen { set; get; }
    
    public  string destino { set; get; }
    
    public CalendarioVueloDto aplicado_calendario { set; get; }
}