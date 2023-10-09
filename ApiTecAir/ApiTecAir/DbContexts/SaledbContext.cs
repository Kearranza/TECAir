using ApiTecAir.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTecAir.DbContexts;

public class SaledbContext : DbContext
{
    public SaledbContext(DbContextOptions<SaledbContext> options)
        : base(options)
    {
        
    }
    public virtual DbSet<SaleDto> Sale { set; get; }
}