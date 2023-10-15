using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class MaletaDto
{
    [Key]
    public int id_maleta { set; get; }
    
    public ClienteDto cedula_cliente { set; get; }
    
    public long peso { set; get; }
    
    public ColorDto color { set; get; }
    
    public PaseAbordarDto id_pasaje { set; get; }
}