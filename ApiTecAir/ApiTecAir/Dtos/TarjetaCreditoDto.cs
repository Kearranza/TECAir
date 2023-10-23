using System.ComponentModel.DataAnnotations;
using ApiTecAir.Entities;

namespace ApiTecAir.Dtos;

//Creacion del dto para la entidad Tarjeta_de_Credito
public class TarjetaCreditoDto
{
    public int num_tarjeta { set; get; }

    public string fecha_exp { set; get; }
    
    public int cvv { set; get; }

    public int cedula { set; get; }
    
    //Listas de dto que referencian este dto
    public List<FacturaDto> facturas { set; get; }
}