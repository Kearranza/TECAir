using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

public class MaletaDto
{
    public int id_maleta { set; get; }
    
    public int cedula_cliente { set; get; }
    
    public long peso { set; get; }
    
    public string color { set; get; }
    
    public int id_pasaje { set; get; }
}