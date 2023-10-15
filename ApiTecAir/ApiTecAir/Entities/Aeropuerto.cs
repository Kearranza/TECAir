using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Entities;

public class Aeropuerto
{
    [Key]
    public string id_aereo { set; get; }
    
    public string ciudad { set; get; }
    
    public string pais { set; get; }
    
    public List<Vuelos> vuelosOrigen { set; get; }
    
    public List<Vuelos> vuelosDestino { set; get; }
}