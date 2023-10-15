using System.Runtime.InteropServices.ComTypes;
using ApiTecAir.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.DbContexts;

public class TECAirDbContext : DbContext
{
    public TECAirDbContext(DbContextOptions<TECAirDbContext> options)
        : base(options)
    {
        
    }
    //Asignacion de los DBContext para cada una de las tablas
    public virtual DbSet<PromocionesDto> promociones { set; get; }
    
    public virtual DbSet<EstudianteDto> estudiante { set; get; }
    
    public virtual DbSet<FacturaDto> factura { set; get; }
    
    public virtual DbSet<ClienteDto> cliente { set; get; }
    
    public virtual DbSet<VuelosDto> vuelos { set; get; }

    public virtual DbSet<CalendarioVueloDto> calendario_vuelos { set; get; }

    public virtual DbSet<AvionDto> avion { set; get; }
    
    public virtual DbSet<EscalaDto> escala { set; get; }
    
    public virtual DbSet<MapaAsientoDto> mapa_asiento { set; get; }
    
    public virtual DbSet<MaletaDto> maleta { set; get; }
    
    public virtual DbSet<PaseAbordarDto> pase_abordar { set; get; }
    
    public virtual DbSet<UsuarioDto> usuario { set; get; }
    
    public virtual DbSet<TarjetaCreditoDto> tarjeta_credito { set; get; }
    
    public virtual DbSet<AeropuertoDto> aereopuerto { set; get; }
    
    public virtual DbSet<ColorDto> color { set; get; }
}