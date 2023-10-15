using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiTecAir.Dtos;

public class EstudianteDto
{
    public int carnet { set; get; }
    
    public  string universidad { set; get; }

    public int millas { set; get; }
    
    public int cedula { set;get; }
}