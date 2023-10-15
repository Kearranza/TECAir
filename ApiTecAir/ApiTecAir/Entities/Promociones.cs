using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class Promociones
{
    [Key]
    public int id_promo { set; get; }
    
    public float descuento { set; get; }
    
    public DateTime fecha_inicio { set; get; }
    
    public DateTime fecha_final { set; get; }
    
    public  string origen { set; get; }
    
    public  string destino { set; get; }
    
    public string aplicado_calendario { set; get; }
    
    public CalendarioVuelo calendario { set; get; }
}