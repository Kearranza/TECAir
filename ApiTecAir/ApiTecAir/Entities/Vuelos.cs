using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class Vuelos
{
    [Key]
    public int id_vuelo { set; get; }
    
    public DateTime hora_salida { set; get; }
    
    public string aereo_origen { set; get; }
    
    public string aereo_final { set; get; }
    
    public Aeropuerto origen { set; get; }
    
    public Aeropuerto destino { set; get; }
    
    public List<CalendarioVuelo> calendarios { set; get; }
    
    public List<Escala> escalas { set; get; }
}