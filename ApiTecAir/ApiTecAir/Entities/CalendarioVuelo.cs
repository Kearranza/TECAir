using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class CalendarioVuelo
{
    [Key]
    public int id_calendario { set; get; }
    
    public DateTime fecha { set; get; }
    
    public float precio { set; get; }
    
    public string placa { set; get; }
    
    public string id_vuelo { set; get; }
    
    public Avion avion { set; get; }
    
    public Vuelos vuelo { set; get; }
    
    public List<PaseAbordar> pases { set; get; }
    
    public List<Promociones> promociones { set; get; }
}