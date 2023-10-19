using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class PaseAbordar
{
    [Key]
    public int id_pasaje { set; get; }
    
    public string puerta { set; get; }
    
    public   string asiento { set; get; }
    
    public TimeOnly hora_salida { set; get; }
    
    public int cedula_cliente { set; get; }
    
    public string id_calendario { set; get; }
    
    public Cliente cliente { set; get; }
    
    public CalendarioVuelo calendario { set; get; }
    
    public List<Maleta> maletas { set; get; }
}