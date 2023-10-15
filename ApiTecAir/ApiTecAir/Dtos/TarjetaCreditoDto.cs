using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

public class TarjetaCreditoDto
{
    public  string num_tarjeta { set; get; }

    public string fecha_exp;
    
    public int cvv { set; get; }

    public int cedula { set; get; }
}