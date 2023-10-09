namespace ApiTecAir.Models;

public class CreditCardDto
{
    public required string CreditCardNo { set; get; }
    
    public required ClientDto Owner { set; get; }
}