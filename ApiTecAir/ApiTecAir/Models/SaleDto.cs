using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class SaleDto
{
    [Key]
    public required string SaleId { set; get; }
    
    public required string Origin { set; get; }
    
    public required string Destination { set; get; }
    
    public DateTime SaleStart { set; get; }
    
    public DateTime SaleEnd { set; get; }
    
    public int Discount { set; get; }
}