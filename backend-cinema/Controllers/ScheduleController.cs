using backend_cinema.Services;
using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetSchedulesAsync()
        {
            try
            {
                var schedules = await _scheduleService.GetSchedulesAsync();
                return Ok(schedules);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("discount")]
        public async Task<ActionResult<List<Schedule>>> GetSchedulesWithDiscountAsync()
        {
            try
            {
                var schedules = await _scheduleService.GetSchedulesWithDiscountAsync();
                return Ok(schedules);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{ScheduleID:int}", Name = "GetScheduleById")]
        public async Task<ActionResult<Schedule>> GetScheduleByIdAsync(int ScheduleID)
        {
            try
            {
                var schedule = await _scheduleService.GetScheduleByIdAsync(ScheduleID);
                if (schedule == null)
                {
                    return NotFound();
                }
                return Ok(schedule);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> AddScheduleAsync(Schedule schedule)
        {
            try
            {
                var saveSchedule = await _scheduleService.AddScheduleAsync(schedule);
                return CreatedAtRoute("GetScheduleById",
                    new { ScheduleID = saveSchedule.ScheduleID }, saveSchedule);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Schedule>> UpdateScheduleAsync(Schedule schedule)
        {
            try
            {
                var updatedSchedule = await _scheduleService.UpdateScheduleAsync(schedule);
                return Ok(updatedSchedule);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
