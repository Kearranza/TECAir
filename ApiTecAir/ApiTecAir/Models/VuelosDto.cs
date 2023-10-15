using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class VuelosDto
{
    [Key]
    public required int id_vuelo { set; get; }
    
    public DateTime hora_salida { set; get; }
    
    public AeropuertoDto aereo_origen { set; get; }
    
    public AeropuertoDto aereo_destino { set; get; }
}