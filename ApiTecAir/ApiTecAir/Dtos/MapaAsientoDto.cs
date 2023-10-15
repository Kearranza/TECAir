using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTecAir.Dtos;

public class MapaAsientoDto
{
    public int id_mapa_asiento { set; get; }
    
    public int num_asiento { set; get; }
    
    public bool disponibilidad { set; get; }
    
    public string placa { set; get; }
}