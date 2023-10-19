using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Creation of the data structure Bill
public class Factura
{
    [Key]
    public int id_factura { set; get; }
    
    public int precio { set; get; }
    
    public int cantidad { set; get; }
    
    public int total { set; get; }
    
    public int cedulacliente { set; get; }
    
    public CalendarioVuelo calendario_vuelo { set; get; }
    
    public int tarjeta_credito { set; get; }
}