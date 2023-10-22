using System.ComponentModel.DataAnnotations;
using ApiTecAir.Entities;

namespace ApiTecAir.Dtos;

//Creacion del dto para la entidad Color
public class ColorDto
{
    public  String id_color { set; get; }
    
    //Listas de dto que referencian este dto
    public List<Maleta> maletas { set; get; }
}