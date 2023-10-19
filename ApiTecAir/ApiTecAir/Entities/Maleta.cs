using System.ComponentModel.DataAnnotations;


namespace ApiTecAir.Entities;

public class Maleta
{
    [Key]
    public int id_maleta { set; get; }
    
    public int cedula_cliente { set; get; }
    
    public long peso { set; get; }
    
    public string color { set; get; }
    
    public int id_pasaje { set; get; }
    
    public Cliente cliente { set; get; }
    
    public Color Mcolor { set; get; }
    
    public PaseAbordar pasaje { set; get; }
}