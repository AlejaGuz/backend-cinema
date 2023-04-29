using DB_cinema;

namespace backend_cinema.Services.Interfaces
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int TicketID);
        Task<List<Ticket>> GetTicketsByShowAsync(int ShowID);
        Task<Ticket> AddTicketAsync(Ticket ticket);
        Task<Ticket> UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(int TicketID);
    }
}
