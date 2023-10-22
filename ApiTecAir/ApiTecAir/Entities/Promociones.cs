using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Promociones
public class Promociones
{
    [Key]
    public int id_promo { set; get; }
    
    public float descuento { set; get; }
    
    public DateOnly fecha_inicio { set; get; }
    
    public DateOnly fecha_final { set; get; }
    
    public  string origen { set; get; }
    
    public  string destino { set; get; }
    
    public string aplicado_calendario { set; get; }
    
    //Atributo utilizado para indicar que existe una llave foranea
    public CalendarioVuelo calendario { set; get; }
}