using DB_cinema;

namespace backend_cinema.Services.Interfaces
{
    public interface IChairService
    {
        Task<List<Chair>> GetChairsAsync();
        Task<Chair> GetChairByIdAsync(int ChairID);
        Task<Chair> GetChairByRowColumnAsync(int Number, char Row);
        Task<Double> GetPriceByLeverAsync(int level); 
        Task<List<Chair>> GetAvailableChairsByShowAsync(int ShowID);
        Task<List<Chair>> GetOcuppiedChairsByShowAsync(int ShowID);
        Task<List<char>> GetTotalRowsAsync();
        Task<List<int>> GetTotalSeatsByRowAsync();
        Task<Chair> AddChairAsync(Chair Chair);
        Task<Chair> UpdateChairAsync(Chair Chair);
        Task DeleteChairAsync(int ChairID);
    }
}
