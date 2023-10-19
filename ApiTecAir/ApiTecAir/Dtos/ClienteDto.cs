using System.ComponentModel.DataAnnotations;


namespace ApiTecAir.Dtos;

public class ClienteDto
{
    public  int cedula { set; get; }
    
    public  string nombre { set; get; }
    
    public  string apellido_1 { set; get; }
    
    public  string? apellido_2 { set; get; }
    
    public  string telefono { set; get; }
    
    public  string correo { set; get; }
    
    public List<EstudianteDto> estudiantes { set; get; }
    
    public List<UsuarioDto> usuarios { set; get; }
    
    public List<MaletaDto> maletas { set; get; }
    
    public List<PaseAbordarDto> pases { set; get; }
    
    public List<TarjetaCreditoDto> tarjetas { set; get; }
    
    public List<FacturaDto> facturas { set; get; }
}