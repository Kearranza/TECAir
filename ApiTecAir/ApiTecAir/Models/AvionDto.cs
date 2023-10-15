using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class AvionDto
{
    [Key]
    public required string placa { set; get; }
    
    public int filas { set; get; }
    
    public int columnas { set; get; }
}