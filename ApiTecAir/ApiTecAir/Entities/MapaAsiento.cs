using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTecAir.Entities;

//Clase que representa la entidad MapaAsiento
public class MapaAsiento
{
    [Key]
    public int id_mapa_asiento { set; get; }
    
    public int num_asiento { set; get; }
    
    public bool disponibilidad { set; get; }
    
    public string id_avion { set; get; }
    
    //Atributo utilizado para indicar que existe una llave foranea
    public Avion avion { set; get; }
    
}