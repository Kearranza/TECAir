using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

//Creacion del dto para la entidad Factura
public class FacturaDto
{
    public int id_factura { set; get; }

    public int cliente { set; get; }

    public int tarjeta_cred { set; get; }

    public string calendario { set; get; }
}