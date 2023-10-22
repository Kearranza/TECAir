using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Tarjeta_de_Credito
public class TarjetaCredito
{
    [Key]
    public  int num_tarjeta { set; get; }

    public string fecha_exp { set; get; }
    
    public int cvv { set; get; }
    
    public int cedula { set; get; }

    //Atributo utilizado para indicar que existe una llave foranea
    public Cliente cliente { set; get; }
    
    //Lista de entidades que referencian esta entidad
    public List<Factura> facturas { set; get; }
}