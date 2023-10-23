using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Avion
public class Avion
{
    [Key]
    public string placa { set; get; }
    
    public int filas { set; get; }
    
    public int columnas { set; get; }
    
    //Listas de entidades que referencian esta entidad
    public List<CalendarioVuelo> calendarios { set; get; }
    
    public List<MapaAsiento> asientos { set; get; }
}