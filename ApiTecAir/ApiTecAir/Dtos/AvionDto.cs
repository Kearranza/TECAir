using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

public class AvionDto
{
    public string placa { set; get; }
    
    public int filas { set; get; }
    
    public int columnas { set; get; }
    
    public List<CalendarioVueloDto> calendarios { set; get; }
    
    public List<MapaAsientoDto> asientos { set; get; }
}