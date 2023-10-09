namespace ApiTecAir.Models;

public class UserDto
{
    public int UserId { set; get; }
    
    public required string Password { set; get; }
}