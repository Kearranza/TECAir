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

    public virtual DbSet<CalendarioVuelo> calendario_vuelo { set; get; }

    public virtual DbSet<Avion> avion { set; get; }
    
    public virtual DbSet<Escala> escala { set; get; }
    
    public virtual DbSet<MapaAsiento> mapa_asientos { set; get; }
    
    public virtual DbSet<Maleta> maleta { set; get; }
    
    public virtual DbSet<PaseAbordar> pase_abordar { set; get; }
    
    public virtual DbSet<Usuario> usuario { set; get; }
    
    public virtual DbSet<TarjetaCredito> tarjeta_de_credito { set; get; }
    
    public virtual DbSet<Aeropuerto> aereopuerto { set; get; }
    
    public virtual DbSet<Color> color { set; get; }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        // Se asignan todas las clausulas de foreign key para las tablas
        
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
        
        modelbuilder.Entity<Factura>()
            .HasOne(_ => _.ccliente)
            .WithMany(_ => _.facturas)
            .HasForeignKey(_ => _.cliente);
        
        modelbuilder.Entity<Factura>()
            .HasOne(_ => _.tarjeta)
            .WithMany(_ => _.facturas)
            .HasForeignKey(_ => _.tarjeta_cred);
        
        modelbuilder.Entity<Factura>()
            .HasOne(_ => _.calendario_vuelo)
            .WithMany(_ => _.facturas)
            .HasForeignKey(_ => _.calendario);
        
        modelbuilder.Entity<Maleta>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.maletas)
            .HasForeignKey(_ => _.cedula_cliente);
        
        modelbuilder.Entity<Maleta>()
            .HasOne(_ => _.pasaje)
            .WithMany(_ => _.maletas)
            .HasForeignKey(_ => _.id_pasaje);
        
        modelbuilder.Entity<Maleta>()
            .HasOne(_ => _.Mcolor)
            .WithMany(_ => _.maletas)
            .HasForeignKey(_ => _.color);
        
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
            .WithMany(_ => _.vuelosDestino)
            .HasForeignKey(_ => _.aereo_final);
        
        modelbuilder.Entity<Vuelos>()
            .HasOne(_ => _.origen)
            .WithMany(_ => _.vuelosOrigen)
            .HasForeignKey(_ => _.aereo_origen);
        
        modelbuilder.Entity<CalendarioVuelo>()
            .HasOne(_ => _.avion)
            .WithMany(_ => _.calendarios)
            .HasForeignKey(_ => _.id_avion);
        
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
            .HasForeignKey(_ => _.id_avión);
        
        //Se agregan de manera automatica las entidades obtenidas
        //de las foreign keys
        
        modelbuilder.Entity<Avion>().Navigation(e => e.calendarios);
        modelbuilder.Entity<Avion>().Navigation(e => e.asientos);
        
        modelbuilder.Entity<CalendarioVuelo>().Navigation(e => e.pases);
        modelbuilder.Entity<CalendarioVuelo>().Navigation(e => e.promociones);
        modelbuilder.Entity<CalendarioVuelo>().Navigation(e => e.facturas);
        
        modelbuilder.Entity<Cliente>().Navigation(e => e.maletas).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.estudiantes).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.tarjetas).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.pases).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.usuarios).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.facturas).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.usuarios).AutoInclude();

        
        modelbuilder.Entity<Color>().Navigation(e => e.maletas).AutoInclude();
        
        modelbuilder.Entity<PaseAbordar>().Navigation(e => e.maletas).AutoInclude();
        
        modelbuilder.Entity<Vuelos>().Navigation(e => e.calendarios).AutoInclude();
        modelbuilder.Entity<Vuelos>().Navigation(e => e.escalas).AutoInclude();

        modelbuilder.Entity<TarjetaCredito>().Navigation(e => e.facturas).AutoInclude();

    }
}