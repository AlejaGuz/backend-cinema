using DB_cinema;

namespace backend_cinema.Services.Interfaces
{
    public interface IChairService
    {
        Task<List<Chair>> GetChairsAsync();
        Task<Chair> GetChairByIdAsync(int ChairID);
        Task<List<Chair>> GetAvailableChairsByShowAsync(int ShowID);
        Task<List<Chair>> GetOcuppiedChairsByShowAsync(int ShowID);
        Task<Chair> AddChairAsync(Chair Chair);
        Task<Chair> UpdateChairAsync(Chair Chair);
        Task DeleteChairAsync(int ChairID);
    }
}
