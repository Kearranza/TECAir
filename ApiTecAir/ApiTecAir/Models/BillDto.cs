using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

//Creation of the data structure Bill
public class BillDto
{
    [Key]
    public int billid { set; get; }
    
}