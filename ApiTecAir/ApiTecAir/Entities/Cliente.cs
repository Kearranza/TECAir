using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class Cliente
{
    [Key]
    public  int cedula { set; get; }
    
    public  string nombre { set; get; }
    
    public  string apellido_1 { set; get; }
    
    public  string apellido_2 { set; get; }
    
    public  string télefono { set; get; }
    
    public  string correo { set; get; }
    
    public List<Estudiante> estudiantes { set; get; }
    
    public List<Usuario> usuarios { set; get; }
    
    public List<Maleta> maletas { set; get; }
    
    public List<PaseAbordar> pases { set; get; }
    
    public List<TarjetaCredito> tarjetas { set; get; }
}