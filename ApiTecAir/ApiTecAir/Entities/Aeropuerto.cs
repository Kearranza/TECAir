using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Aeropuerto
public class Aeropuerto
{
    [Key]
    public string id_aereo { set; get; }
    
    public string ciudad { set; get; }
    
    public string pais { set; get; }
    
    //Listas de entidades que referencian esta entidad
    public List<Vuelos> vuelosOrigen { set; get; }
    
    public List<Vuelos> vuelosDestino { set; get; }
}