using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Usuario
public class Usuario
{
    [Key]
    public int id_usuario { set; get; }
    
    public  string contrasena { set; get; }
    
    public int cedula { set; get; }
    
    //Atributo utilizado para indicar que existe una llave foranea
    public Cliente cliente { set; get; }
}