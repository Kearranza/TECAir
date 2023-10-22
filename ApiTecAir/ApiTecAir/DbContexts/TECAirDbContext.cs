using System.Runtime.InteropServices.ComTypes;
using ApiTecAir.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.DbContexts;

public class TECAirDbContext : DbContext
{
    //Constructor del objeto
    public TECAirDbContext(DbContextOptions<TECAirDbContext> options)
        : base(options)
    {
        
    }
    
    //Asignacion del DBContext para la tabla Promociones
    public virtual DbSet<Promociones> promociones { set; get; }
    
    //Asignacion del DBContext para la tabla Estudiante
    public virtual DbSet<Estudiante> estudiante { set; get; }
    
    //Asignacion del DBContext para la tabla Factura
    public virtual DbSet<Factura> factura { set; get; }
    
    //Asignacion del DBContext para la tabla cliente
    public virtual DbSet<Cliente> cliente { set; get; }
    
    //Asignacion del DBContext para la tabla vuelos
    public virtual DbSet<Vuelos> vuelos { set; get; }

    //Asignacion del DBContext para la tabla Calendario_vuelo
    public virtual DbSet<CalendarioVuelo> calendario_vuelo { set; get; }

    //Asignacion del DBContext para la tabla avion
    public virtual DbSet<Avion> avion { set; get; }
    
    //Asignacion del DBContext para la tabla escala
    public virtual DbSet<Escala> escala { set; get; }
    
    //Asignacion del DBContext para la tabla mapa_asientos
    public virtual DbSet<MapaAsiento> mapa_asientos { set; get; }
    
    //Asignacion del DBContext para la tabla maleta
    public virtual DbSet<Maleta> maleta { set; get; }
    
    //Asignacion del DBContext para la tabla Pase_abordar
    public virtual DbSet<PaseAbordar> pase_abordar { set; get; }
    
    //Asignacion del DBContext para la tabla Usuario
    public virtual DbSet<Usuario> usuario { set; get; }
    
    //Asignacion del DBContext para la tabla Tarjeta_de_credito
    public virtual DbSet<TarjetaCredito> tarjeta_de_credito { set; get; }
    
    //Asignacion del DBContext para la tabla Aereopuerto
    public virtual DbSet<Aeropuerto> aereopuerto { set; get; }
    
    //Asignacion del DBContext para la tabla Color
    public virtual DbSet<Color> color { set; get; }
    
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        // Se asignan todas las clausulas de foreign key para la tabla Estudiante
        modelbuilder.Entity<Estudiante>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.estudiantes)
            .HasForeignKey(_ => _.cedula);
        
        // Se asignan todas las clausulas de foreign key para la tabla Usuario
        modelbuilder.Entity<Usuario>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.usuarios)
            .HasForeignKey(_ => _.cedula);
        
        // Se asignan todas las clausulas de foreign key para la tabla Tarjeta de Credito
        modelbuilder.Entity<TarjetaCredito>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.tarjetas)
            .HasForeignKey(_ => _.cedula);
        
        // Se asignan todas las clausulas de foreign key para la tabla Factura
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
        
        // Se asignan todas las clausulas de foreign key para la tabla Maleta
        modelbuilder.Entity<Maleta>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.maletas)
            .HasForeignKey(_ => _.cedula_cliente);
        
        modelbuilder.Entity<Maleta>()
            .HasOne(_ => _.pasaje)
            .WithMany(_ => _.maletas)
            .HasForeignKey(_ => _.id_pasaje);

        modelbuilder.Entity<Maleta>()
            .HasOne(c => c.Mcolor)
            .WithMany(m => m.maletas)
            .HasForeignKey(m => m.color);
        
        // Se asignan todas las clausulas de foreign key para la tabla Pase Abordar
        modelbuilder.Entity<PaseAbordar>()
            .HasOne(_ => _.cliente)
            .WithMany(_ => _.pases)
            .HasForeignKey(_ => _.cedula_cliente);
        
        modelbuilder.Entity<PaseAbordar>()
            .HasOne(_ => _.calendario)
            .WithMany(_ => _.pases)
            .HasForeignKey(_ => _.id_calendario);

        // Se asignan todas las clausulas de foreign key para la tabla vuelos
        modelbuilder.Entity<Vuelos>()
            .HasOne(_ => _.destino)
            .WithMany(_ => _.vuelosDestino)
            .HasForeignKey(_ => _.aereo_final);
        
        modelbuilder.Entity<Vuelos>()
            .HasOne(_ => _.origen)
            .WithMany(_ => _.vuelosOrigen)
            .HasForeignKey(_ => _.aereo_origen);
        
        // Se asignan todas las clausulas de foreign key para la tabla Calendario Vuelo
        modelbuilder.Entity<CalendarioVuelo>()
            .HasOne(_ => _.avion)
            .WithMany(_ => _.calendarios)
            .HasForeignKey(_ => _.id_avion);
        
        modelbuilder.Entity<CalendarioVuelo>()
            .HasOne(_ => _.vuelo)
            .WithMany(_ => _.calendarios)
            .HasForeignKey(_ => _.id_vuelo);
        
        // Se asignan todas las clausulas de foreign key para la tabla Promociones
        modelbuilder.Entity<Promociones>()
            .HasOne(_ => _.calendario)
            .WithMany(_ => _.promociones)
            .HasForeignKey(_ => _.aplicado_calendario);
        
        // Se asignan todas las clausulas de foreign key para la tabla Escala
        modelbuilder.Entity<Escala>()
            .HasOne(_ => _.vuelo)
            .WithMany(_ => _.escalas)
            .HasForeignKey(_ => _.id_vuelo);
        
        // Se asignan todas las clausulas de foreign key para la tabla Mapa Asiento
        modelbuilder.Entity<MapaAsiento>()
            .HasOne(_ => _.avion)
            .WithMany(_ => _.asientos)
            .HasForeignKey(_ => _.id_avión);
        
        //Se agregan de manera automatica las entidades obtenidas
        //de las foreign keys que referencian Avion
        modelbuilder.Entity<Avion>().Navigation(e => e.calendarios);
        modelbuilder.Entity<Avion>().Navigation(e => e.asientos);
        
        //Se agregan de manera automatica las entidades obtenidas
        //de las foreign keys que referencian CalendarioVuelo
        modelbuilder.Entity<CalendarioVuelo>().Navigation(e => e.pases);
        modelbuilder.Entity<CalendarioVuelo>().Navigation(e => e.promociones);
        modelbuilder.Entity<CalendarioVuelo>().Navigation(e => e.facturas);
        
        //Se agregan de manera automatica las entidades obtenidas
        //de las foreign keys que referencian Cliente
        modelbuilder.Entity<Cliente>().Navigation(e => e.maletas).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.estudiantes).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.tarjetas).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.pases).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.usuarios).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.facturas).AutoInclude();
        modelbuilder.Entity<Cliente>().Navigation(e => e.usuarios).AutoInclude();

        //Se agregan de manera automatica las entidades obtenidas
        //de las foreign keys que referencian Color
        modelbuilder.Entity<Color>().Navigation(e => e.maletas).AutoInclude();
        
        //Se agregan de manera automatica las entidades obtenidas
        //de las foreign keys que referencian Pase Abordar
        modelbuilder.Entity<PaseAbordar>().Navigation(e => e.maletas).AutoInclude();
        
        //Se agregan de manera automatica las entidades obtenidas
        //de las foreign keys que referencian Vuelos
        modelbuilder.Entity<Vuelos>().Navigation(e => e.calendarios).AutoInclude();
        modelbuilder.Entity<Vuelos>().Navigation(e => e.escalas).AutoInclude();

        //Se agregan de manera automatica las entidades obtenidas
        //de las foreign keys que referencian Tarjeta Credito
        modelbuilder.Entity<TarjetaCredito>().Navigation(e => e.facturas).AutoInclude();

    }
}