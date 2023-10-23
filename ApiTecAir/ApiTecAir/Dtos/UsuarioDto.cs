using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

//Creacion del dto para la entidad Usuario
public class UsuarioDto
{
    public int id_usuario { set; get; }
    
    public  string contrasena { set; get; }
    
    public int cedula { set; get; }
}