using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Vuelos
public class Vuelos
{
    [Key]
    public int id_vuelo { set; get; }
    
    public TimeOnly hora_salida { set; get; }
    
    public string aereo_origen { set; get; }
    
    public string aereo_final { set; get; }
    
    //Atributos utilizados para indicar que existen llaves foraneas
    public Aeropuerto origen { set; get; }
    
    public Aeropuerto destino { set; get; }
    
    //Listas de entidades que referencian esta entidad
    public List<CalendarioVuelo> calendarios { set; get; }
    
    public List<Escala> escalas { set; get; }
}