using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

public class PaseAbordarDto
{
    public int id_pasaje { set; get; }
    
    public string puerta { set; get; }
    
    public   string asiento { set; get; }
    
    public DateTime hora_salida { set; get; }
    
    public int cedula_cliente { set; get; }
    
    public int id_calendario { set; get; }
}