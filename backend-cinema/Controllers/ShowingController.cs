using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowingController : ControllerBase
    {

        private readonly IShowingService _showingService;

        public ShowingController(IShowingService showingService)
        {
            _showingService= showingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Showing>>> GetShowsAsync()
        {
            try
            {
                var shows = await _showingService.GetShowsAsync();
                return Ok(shows);

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("id/{ShowID:int}", Name ="GetShowById")]
        public async Task<ActionResult<Showing>> GetShowByIdAsync(int ShowID)
        {
            try
            {
                var show = await _showingService.GetShowByIdAsync(ShowID);
                if(show == null)
                {
                    return NotFound();
                }
                return Ok(show);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Showing>> AddShowAsync(Showing Show)
        {
            try
            {
               var saveShow = await _showingService.AddShowAsync(Show);
                return CreatedAtRoute("GetShowById",
                    new {ShowID = saveShow.ShowID},saveShow);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Showing>> UpdateShowAsync(Showing Show)
        {
            try
            {
                var updatedShow = await _showingService.UpdateShowAsync(Show);
                return Ok(updatedShow);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{ShowID:int}")]
        public async Task<IActionResult> DeleteShowAsync(int ShowID)
        {
            try
            {
                await _showingService.DeleteShowAsync(ShowID);
                
                return Ok("Showing Removed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
