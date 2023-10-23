using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Factura
public class Factura
{
    [Key]
    public int id_factura { set; get; }
    
    public int cliente { set; get; }
    
    public int tarjeta_cred { set; get; }
    
    public string calendario { set; get; }
    
    //Atributos utilizados para indicar que existen llaves foraneas
    public Cliente ccliente { set; get; }
    
    public TarjetaCredito tarjeta { set; get; }
    
    public CalendarioVuelo calendario_vuelo { set; get; }
}