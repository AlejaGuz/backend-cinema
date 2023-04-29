using DB_cinema;

namespace backend_cinema.Services.Interfaces
{
    public interface ISaleService
    {
        Task<List<Sale>> GetSalesAsync();
        Task<List<Sale>> GetSalesByShowAsync(int ShowID);
        Task<List<Ticket>> GetTicketsBySaleAsync(int SaleID);
        Task<Sale> GetSaleByIdAsync(int SaleID);
        Task<Sale> AddSaleAsync(Sale Sale);
        Task<Sale> UpdateSaleAsync(Sale Sale);
        Task DeleteSaleAsync(int SaleID);
    }
}
