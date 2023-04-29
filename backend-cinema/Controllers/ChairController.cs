using backend_cinema.Services;
using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChairController : ControllerBase
    {
        private readonly IChairService _chairService;

        public ChairController(IChairService chairService)
        {
            _chairService = chairService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chair>>> GetChairsAsync()
        {
            try
            {
                var chairs = await _chairService.GetChairsAsync();
                return Ok(chairs);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{ChairID:int}", Name = "GetChairById")]
        public async Task<ActionResult<Chair>> GetChairByIdAsync(int ChairID)
        {
            try
            {
                var chair = await _chairService.GetChairByIdAsync(ChairID);
                if (chair == null)
                {
                    return NotFound();
                }
                return Ok(chair);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("available/{ShowID:int}")]
        public async Task<ActionResult<List<Chair>>> GetAvailableChairsByShowAsync(int ShowID)
        {
            try
            {
                var chairs = await _chairService.GetAvailableChairsByShowAsync(ShowID);
                return Ok(chairs);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Chair>> AddChairAsync(Chair Chair)
        {
            try
            {
                var saveChair = await _chairService.AddChairAsync(Chair);
                return CreatedAtRoute("GetChairById",
                    new { ChairID = saveChair.ChairID }, saveChair);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Chair>> UpdateChairAsync(Chair Chair)
        {
            try
            {
                var updatedChair = await _chairService.UpdateChairAsync(Chair);
                return Ok(updatedChair);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{TicketID:int}")]
        public async Task<IActionResult> DeleteChairAsync(int ChairID)
        {
            try
            {
                await _chairService.DeleteChairAsync(ChairID);

                return Ok("Chair Removed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
