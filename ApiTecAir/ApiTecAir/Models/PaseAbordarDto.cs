using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class PaseAbordarDto
{
    [Key]
    public int id_pasaje { set; get; }
    
    public string puerta { set; get; }
    
    public required  string asiento { set; get; }
    
    public DateTime hora_salida { set; get; }
    
    public ClienteDto cedula_cliente { set; get; }
    
    public CalendarioVueloDto id_calendario { set; get; }
}