using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class Color
{
    [Key] 
    public  String id_color { set; get; }
}