using System.ComponentModel.DataAnnotations;
using ApiTecAir.Entities;

namespace ApiTecAir.Dtos;

//Creacion del dto para la entidad Aeropuerto
public class AeropuertoDto
{
    public  string id_aereo { set; get; }
    
    public  string ciudad { set; get; }
    
    public  string pais { set; get; }

    //Listas de dto que referencian este dto
    public List<Vuelos> vuelos { set; get; }
}