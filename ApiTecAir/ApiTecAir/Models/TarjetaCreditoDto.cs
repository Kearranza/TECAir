using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class TarjetaCreditoDto
{
    [Key]
    public required string num_tarjeta { set; get; }

    public string fecha_exp;
    
    public int cvv { set; get; }

    public ClienteDto cedula { set; get; }
}