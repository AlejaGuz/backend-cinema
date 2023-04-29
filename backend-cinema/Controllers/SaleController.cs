using backend_cinema.Services;
using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetSalesAsync()
        {
            try
            {
                var sales = await _saleService.GetSalesAsync();
                return Ok(sales);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{SaleID:int}", Name = "GetSaleById")]
        public async Task<ActionResult<Sale>> GetSaleByIdAsync(int SaleID)
        {
            try
            {
                var sale = await _saleService.GetSaleByIdAsync(SaleID);
                if (sale == null)
                {
                    return NotFound();
                }
                return Ok(sale);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("show/{ShowID:int}")]
        public async Task<ActionResult<List<Sale>>> GetSalesByShowAsync(int ShowID)
        {
            try
            {
                var sales = await _saleService.GetSalesByShowAsync(ShowID);
                return Ok(sales);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tickets/{SaleID:int}")]
        public async Task<ActionResult<List<Ticket>>> GetTicketsBySaleAsync(int SaleID)
        {
            try
            {
                var tickets = await _saleService.GetTicketsBySaleAsync(SaleID);
                return Ok(tickets);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Sale>> AddSaleAsync(Sale Sale)
        {
            try
            {
                var saveSale = await _saleService.AddSaleAsync(Sale);
                return CreatedAtRoute("GetSaleById",
                    new { SaleID = saveSale.SaleID }, saveSale);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Sale>> UpdateSaleAsync(Sale Sale)
        {
            try
            {
                var updatedSale= await _saleService.UpdateSaleAsync(Sale);
                return Ok(updatedSale);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{SaleID:int}")]
        public async Task<IActionResult> DeleteSaleAsync(int SaleID)
        {
            try
            {
                await _saleService.DeleteSaleAsync(SaleID);

                return Ok("Sale Removed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
