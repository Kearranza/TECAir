using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class UsuarioDto
{
    [Key]
    public int id_usuario { set; get; }
    
    public required string contrasena { set; get; }
    
    public ClienteDto cedula { set; get; }
}