using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Dtos;

//Creacion del dto para la entidad Vuelos
public class VuelosDto
{
    public int id_vuelo { set; get; }
    
    public TimeOnly hora_salida { set; get; }
    
    public string aereo_origen { set; get; }
    
    public string aereo_final { set; get; }
    
    //Listas de dto que referencian este dto
    public List<CalendarioVueloDto> calendarios { set; get; }
    
    public List<EscalaDto> escalas { set; get; }
}