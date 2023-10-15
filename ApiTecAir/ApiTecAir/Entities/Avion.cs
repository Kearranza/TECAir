using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class Avion
{
    [Key]
    public string placa { set; get; }
    
    public int filas { set; get; }
    
    public int columnas { set; get; }
    
    public List<CalendarioVuelo> calendarios { set; get; }
    
    public List<MapaAsiento> asientos { set; get; }
}