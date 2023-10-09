namespace ApiTecAir.Models;

//Creation of the data structure Bill
public class BillDto
{
    public int BillId { set; get; }
    
    public required PriceDto Price { set; get; }
    
}