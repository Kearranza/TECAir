using ApiTecAir.DbContexts;
using ApiTecAir.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTecAir.Controllers;

[Route ("/api/[controller]")]
public class SaleController : ControllerBase
{
    private SaledbContext _saledbContext;

    public SaleController(SaledbContext sales)
    {
        _saledbContext = sales;
    }

    [HttpPost("/sale")]
    public IActionResult CreateSale([FromBody] SaleDto model)
    {
        var saleExist = _saledbContext.Sale.Any(e => e.SaleId == model.SaleId);
        if (saleExist == true)
        {
            return Ok(new { Message = "Sale Already Created" });
        }

        _saledbContext.Add(model);
        _saledbContext.SaveChanges();

        return Ok(new { Message = "Sale Created" });
    }
    
}