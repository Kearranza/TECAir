using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class SaleDto
{
    [Key]
    public int saleid { set; get; }
    
    public required string origin { set; get; }
    
    public required string destination { set; get; }
    
    public DateTime salestart { set; get; }
    
    public DateTime saleend { set; get; }
    
    public int discount { set; get; }
}