using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class AeropuertoDto
{
    [Key]
    public required string id_aereo { set; get; }
    
    public required string ciudad { set; get; }
    
    public required string pais { set; get; }
}