using DB_cinema;

namespace backend_cinema.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetSchedulesAsync();
        Task<List<Schedule>> GetSchedulesWithDiscountAsync();
        Task<Schedule> GetScheduleByIdAsync(int ScheduleID);
        Task<Schedule> AddScheduleAsync(Schedule schedule);
        Task<Schedule> UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(int ScheduleID);
    }
}
