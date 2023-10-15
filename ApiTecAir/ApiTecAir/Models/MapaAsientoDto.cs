using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTecAir.Models;

public class MapaAsientoDto
{
    [Key]
    public int id_mapa_asiento { set; get; }
    
    public int num_asiento { set; get; }
    
    public bool disponibilidad { set; get; }
    
    public AvionDto id_avion { set; get; }
    
}