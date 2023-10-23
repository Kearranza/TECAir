using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Color
public class Color
{
    [Key] 
    public  String id_color { set; get; }
    
    //Listas de entidades que referencian esta entidad
    public List<Maleta> maletas { set; get; }
}