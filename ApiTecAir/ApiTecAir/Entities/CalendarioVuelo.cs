using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Calendario_Vuelo
public class CalendarioVuelo
{
    [Key]
    public string id_calendario { set; get; }
    
    public DateOnly fecha { set; get; }
    
    public float precio { set; get; }
    
    public string id_avion { set; get; }
    
    public int id_vuelo { set; get; }
    
    public bool abierto { set; get; }
    
    //Atributos utilizados para indicar que existen llaves foraneas
    public Avion avion { set; get; }
    
    public Vuelos vuelo { set; get; }
    
    //Listas de entidades que referencian esta entidad
    public List<PaseAbordar> pases { set; get; }
    
    public List<Promociones> promociones { set; get; }
    
    public List<Factura> facturas { set; get; }
}