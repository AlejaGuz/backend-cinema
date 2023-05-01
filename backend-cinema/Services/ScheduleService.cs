using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.EntityFrameworkCore;

namespace backend_cinema.Services
{
    public class ScheduleService: IScheduleService
    {
        private readonly AlejaCinemaContext _context;

        public ScheduleService(AlejaCinemaContext context)
        {
            _context = context;
        }

        public async Task<Schedule> AddScheduleAsync(Schedule schedule)
        {
            try
            {
                await _context.Schedule.AddAsync(schedule);
                await _context.SaveChangesAsync();
                return schedule;
            }
            catch
            {
                throw;
            }
        }

        public Task DeleteScheduleAsync(int ScheduleID)
        {
            throw new NotImplementedException();
        }

        public async Task<Schedule> GetScheduleByIdAsync(int ScheduleID)
        {
            try
            {
                var schedule = await _context.Schedule
                    .Where(s => s.ScheduleID == ScheduleID).FirstOrDefaultAsync();
                return schedule;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Schedule>> GetSchedulesAsync()
        {
            try
            {
                var schedules = await _context.Schedule.ToListAsync();
                return schedules;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Schedule>> GetSchedulesWithDiscountAsync()
        {
            try
            {
                var schedules = await _context.Schedule
                    .Where(s => s.IsDiscount == true).ToListAsync();

                return schedules;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            try
            {
                Console.WriteLine("entro al update service");
                _context.Entry(schedule).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return schedule;
            }
            catch
            {
                throw;
            }
        }
    }
}
