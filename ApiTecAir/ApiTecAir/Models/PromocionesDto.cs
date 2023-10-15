using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class PromocionesDto
{
    [Key]
    public int id_promo { set; get; }
    
    public int descuento { set; get; }
    
    public DateTime fecha_inicio { set; get; }
    
    public DateTime fecha_fin { set; get; }
    
    public required string origen { set; get; }
    
    public required string destino { set; get; }
    
    public CalendarioVueloDto aplicado_calendario { set; get; }
}