using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class EscalaDto
{
    [Key]
    public int id_escala { set; get; }
    
    public required string orden_lugares { set; get; }
    
    public required string origen { set; get; }
    
    public required string destino { set; get; }
    
    public VuelosDto id_vuelo { set; get; }
}