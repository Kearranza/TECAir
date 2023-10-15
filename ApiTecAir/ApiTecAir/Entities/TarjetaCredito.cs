using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class TarjetaCredito
{
    [Key]
    public  string num_tarjeta { set; get; }

    public string fecha_exp;
    
    public int cvv { set; get; }
    
    public int cedula { set; get; }

    public Cliente cliente { set; get; }
}