using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class Usuario
{
    [Key]
    public int id_usuario { set; get; }
    
    public  string contrasena { set; get; }
    
    public int cedula { set; get; }
    
    public Cliente cliente { set; get; }
}