using System.ComponentModel.DataAnnotations;
using ApiTecAir.Entities;

namespace ApiTecAir.Dtos;

public class PaseAbordarDto
{
    public int id_pasaje { set; get; }
    
    public string puerta { set; get; }
    
    public  string asiento { set; get; }
    
    public TimeOnly hora_salida { set; get; }
    
    public int cedula_cliente { set; get; }
    
    public string id_calendario { set; get; }
    
    public List<MaletaDto> maletas { set; get; }
}