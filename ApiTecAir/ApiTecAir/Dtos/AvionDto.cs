using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

//Creacion del dto para la entidad Avion
public class AvionDto
{
    public string placa { set; get; }
    
    public int filas { set; get; }
    
    public int columnas { set; get; }
    
    //Listas de dto que referencian este dto
    public List<CalendarioVueloDto> calendarios { set; get; }
    
    public List<MapaAsientoDto> asientos { set; get; }
}