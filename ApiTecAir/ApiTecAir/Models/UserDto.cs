using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class UserDto
{
    [Key]
    public int userid { set; get; }
    
    public required string password { set; get; }
}