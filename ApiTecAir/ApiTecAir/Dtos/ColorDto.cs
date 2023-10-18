using System.ComponentModel.DataAnnotations;
using ApiTecAir.Entities;

namespace ApiTecAir.Dtos;

public class ColorDto
{
    public  String id_color { set; get; }
    
    public List<Maleta> maletas { set; get; }
}