using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class ClienteDto
{
    [Key]
    public  int cedula { set; get; }
    
    public required string nombre { set; get; }
    
    public required string apellido_1 { set; get; }
    
    public required string apellido_2 { set; get; }
    
    public required string télefono { set; get; }
    
    public required string correo { set; get; }
}