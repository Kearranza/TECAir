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
    public virtual DbSet<SaleDto> sale { set; get; }
    
    public virtual DbSet<StudentDto> student { set; get; }
    
    public virtual DbSet<BillDto> bill { set; get; }
    
    public virtual DbSet<ClientDto> client { set; get; }
    
    public virtual DbSet<FlightDto> flight { set; get; }
    
    public virtual DbSet<FlightCalendarDto> flightcalendar { set; get; }
    
    public virtual DbSet<PriceDto> price { set; get; }
    
    public virtual DbSet<AirplaneDto> aeroplane { set; get; }
    
    public virtual DbSet<ScaleDto> scale { set; get; }
    
    public virtual DbSet<SeatDto> seat { set; get; }
    
    public virtual DbSet<SuitcaseDto> suitcase { set; get; }
    
    public virtual DbSet<TicketDto> ticket { set; get; }
    
    public virtual DbSet<UserDto> usert { set; get; }
}