using System.ComponentModel.DataAnnotations;

namespace ApiTecAir.Models;

public class CreditCardDto
{
    [Key]
    public required string creditcardno { set; get; }
    
}