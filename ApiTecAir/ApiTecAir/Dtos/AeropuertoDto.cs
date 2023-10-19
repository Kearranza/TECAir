using System.ComponentModel.DataAnnotations;
using ApiTecAir.Entities;

namespace ApiTecAir.Dtos;

public class AeropuertoDto
{
    public  string id_aereo { set; get; }
    
    public  string ciudad { set; get; }
    
    public  string pais { set; get; }

    public List<Vuelos> vuelos { set; get; }
}