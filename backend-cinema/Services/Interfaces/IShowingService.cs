using DB_cinema;

namespace backend_cinema.Services.Interfaces
{
    public interface IShowingService
    {
        Task<List<Showing>> GetShowsAsync();
        Task<Showing> GetShowByIdAsync(int ShowID);
        Task<Showing> AddShowAsync(Showing show);
        Task<Showing> UpdateShowAsync(Showing show);
        Task DeleteShowAsync(int ShowID);
    }
}
