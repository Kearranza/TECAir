using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class TarjetaCredito
{
    [Key]
    public  int num_tarjeta { set; get; }

    public string fecha_exp { set; get; }
    
    public int cvv { set; get; }
    
    public int cedula { set; get; }

    public Cliente cliente { set; get; }
    
    public List<Factura> facturas { set; get; }
}