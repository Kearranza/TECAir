using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class Escala
{
    [Key]
    public int id_escala { set; get; }
    
    public  string orden_lugares { set; get; }
    
    public  string origen { set; get; }
    
    public  string destino { set; get; }
    
    public int id_vuelo { set; get; }
    
    public Vuelos vuelo { set; get; }
}