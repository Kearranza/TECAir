using System.ComponentModel.DataAnnotations;


namespace ApiTecAir.Entities;

//Clase que representa la entidad Maleta
public class Maleta
{
    [Key]
    public int id_maleta { set; get; }
    
    public int cedula_cliente { set; get; }
    
    public long peso { set; get; }
    
    public string color { set; get; }
    
    public int id_pasaje { set; get; }
    
    //Atributos utilizados para indicar que existen llaves foraneas
    public Cliente cliente { set; get; }
    
    public Color Mcolor { set; get; }
    
    public PaseAbordar pasaje { set; get; }
}