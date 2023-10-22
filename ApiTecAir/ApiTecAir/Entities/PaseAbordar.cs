using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Pase_Abordar
public class PaseAbordar
{
    [Key]
    public int id_pasaje { set; get; }
    
    public string puerta { set; get; }
    
    public   string asiento { set; get; }
    
    public TimeOnly hora_salida { set; get; }
    
    public int cedula_cliente { set; get; }
    
    public string id_calendario { set; get; }
    
    //Atributo utilizado para indicar que existe una llave foranea
    public Cliente cliente { set; get; }
    
    public CalendarioVuelo calendario { set; get; }
    
    //Listas de entidades que referencian esta entidad
    public List<Maleta> maletas { set; get; }
}