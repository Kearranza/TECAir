using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

//Creation of the data structure Bill
public class FacturaDto
{
    public int id_factura { set; get; }

    public int cliente { set; get; }

    public int tarjeta_cred { set; get; }

    public string calendario { set; get; }
}