using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Creation of the data structure Bill
public class Factura
{
    [Key]
    public int id_factura { set; get; }
    
    public int cliente { set; get; }
    
    public int tarjeta_cred { set; get; }
    
    public string calendario { set; get; }
    
    public Cliente ccliente { set; get; }
    
    public TarjetaCredito tarjeta { set; get; }
    
    public CalendarioVuelo calendario_vuelo { set; get; }
}