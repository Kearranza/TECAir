using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiTecAir.Entities;

//Clase que representa la entidad Estudiante
public class Estudiante
{
    [Key]
    public int carnet { set; get; }
    
    public string universidad { set; get; }

    public int millas { set; get; }
    
    public int cedula { set;get; }
    
    //Atributo utilizado para indicar que existe una llave foranea
    public Cliente cliente { get; set; }
}