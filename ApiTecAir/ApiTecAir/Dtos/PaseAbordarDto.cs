using System.ComponentModel.DataAnnotations;
using ApiTecAir.Entities;

namespace ApiTecAir.Dtos;

//Creacion del dto para la entidad Pase_Abordar
public class PaseAbordarDto
{
    public int id_pasaje { set; get; }
    
    public string puerta { set; get; }
    
    public  string asiento { set; get; }
    
    public TimeOnly hora_salida { set; get; }
    
    public int cedula_cliente { set; get; }
    
    public string id_calendario { set; get; }
    
    //Listas de dto que referencian este dto
    public List<MaletaDto> maletas { set; get; }
}