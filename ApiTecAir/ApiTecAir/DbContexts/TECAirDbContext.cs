using System.Runtime.InteropServices.ComTypes;
using ApiTecAir.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.DbContexts;

public class TECAirDbContext : DbContext
{
    public TECAirDbContext(DbContextOptions<TECAirDbContext> options)
        : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
    //Asignacion de los DBContext para cada una de las tablas
    public virtual DbSet<Promociones> promociones { set; get; }
    
    public virtual DbSet<Estudiante> estudiante { set; get; }
    
    public virtual DbSet<Factura> factura { set; get; }
    
    public virtual DbSet<Cliente> cliente { set; get; }
    
    public virtual DbSet<Vuelos> vuelos { set; get; }

    public virtual DbSet<CalendarioVuelo> calendario_vuelos { set; get; }

    public virtual DbSet<Avion> avion { set; get; }
    
    public virtual DbSet<Escala> escala { set; get; }
    
    public virtual DbSet<MapaAsiento> mapa_asiento { set; get; }
    
    public virtual DbSet<Maleta> maleta { set; get; }
    
    public virtual DbSet<PaseAbordar> pase_abordar { set; get; }
    
    public virtual DbSet<Usuario> usuario { set; get; }
    
    public virtual DbSet<TarjetaCredito> tarjeta_credito { set; get; }
    
    public virtual DbSet<Aeropuerto> aereopuerto { set; get; }
    
    public virtual DbSet<Color> color { set; get; }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<Estudiante>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.estudiantes)
            .HasForeignKey(_ => _.cedula);
        
        modelbuilder.Entity<Usuario>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.usuarios)
            .HasForeignKey(_ => _.cedula);
        
        modelbuilder.Entity<TarjetaCredito>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.tarjetas)
            .HasForeignKey(_ => _.cedula);
        
        modelbuilder.Entity<Maleta>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.maletas)
            .HasForeignKey(_ => _.cedula_cliente);
        
        modelbuilder.Entity<Maleta>()
            .HasOne(_ => _.pasaje)
            .WithMany(_ => _.maletas)
            .HasForeignKey(_ => _.id_pasaje);
        
        modelbuilder.Entity<PaseAbordar>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.pases)
            .HasForeignKey(_ => _.cedula_cliente);
        
        modelbuilder.Entity<PaseAbordar>()
            .HasOne(_ => _.calendario)
            .WithMany(_ => _.pases)
            .HasForeignKey(_ => _.id_calendario);

        modelbuilder.Entity<Vuelos>()
            .HasOne(_ => _.destino)
            .WithMany(_ => _.vuelos)
            .HasForeignKey(_ => _.aereo_destino);
        
        modelbuilder.Entity<Vuelos>()
            .HasOne(_ => _.origen)
            .WithMany(_ => _.vuelos)
            .HasForeignKey(_ => _.aereo_origen);
        
        modelbuilder.Entity<CalendarioVuelo>()
            .HasOne(_ => _.avion)
            .WithMany(_ => _.calendarios)
            .HasForeignKey(_ => _.placa);
        
        modelbuilder.Entity<CalendarioVuelo>()
            .HasOne(_ => _.vuelo)
            .WithMany(_ => _.calendarios)
            .HasForeignKey(_ => _.id_vuelo);
        
        modelbuilder.Entity<Promociones>()
            .HasOne(_ => _.calendario)
            .WithMany(_ => _.promociones)
            .HasForeignKey(_ => _.aplicado_calendario);
        
        modelbuilder.Entity<Escala>()
            .HasOne(_ => _.vuelo)
            .WithMany(_ => _.escalas)
            .HasForeignKey(_ => _.id_vuelo);
        
        modelbuilder.Entity<MapaAsiento>()
            .HasOne(_ => _.avion)
            .WithMany(_ => _.asientos)
            .HasForeignKey(_ => _.placa);
    }
}