using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

public class TarjetaCreditoDto
{
    public int num_tarjeta { set; get; }

    public string fecha_exp { set; get; }
    
    public int cvv { set; get; }

    public int cedula { set; get; }
}