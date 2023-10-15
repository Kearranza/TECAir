using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class ColorDto
{
    [Key] 
    public required String id_color { set; get; }
}