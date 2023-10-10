using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class ClientDto
{
    [Key]
    public  string ssn { set; get; }
    
    public required string email { set; get; }
    
    public required string phone { set; get; }
    
    public required string firstlname { set; get; }
    
    public required string secondlname { set; get; }
    
    public required string name { set; get; }
    
}