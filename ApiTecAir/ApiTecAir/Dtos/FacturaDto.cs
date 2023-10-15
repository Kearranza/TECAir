using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

//Creation of the data structure Bill
public class FacturaDto
{
    public int id_factura { set; get; }
    
    public int precio { set; get; }
    
    public int cantidad { set; get; }
    
    public int total { set; get; }
    
    public int cedulacliente { set; get; }
    
    public CalendarioVueloDto calendario_vuelo { set; get; }
    
    public int tarjeta_credito { set; get; }
}