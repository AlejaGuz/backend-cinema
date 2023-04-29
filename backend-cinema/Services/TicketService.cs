using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.EntityFrameworkCore;

namespace backend_cinema.Services
{
    public class TicketService : ITicketService
    {
        private readonly AlejaCinemaContext _context;
        public TicketService(AlejaCinemaContext context)
        {
            _context = context;
        }

        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            try
            {
                await _context.Tickets.AddAsync(ticket);
                await _context.SaveChangesAsync();
                return ticket;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteTicketAsync(int TicketID)
        {
            try
            {
                var ticket = await GetTicketByIdAsync(TicketID);
                if (ticket != null)
                {
                    _context.Tickets.Remove(ticket);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Ticket> GetTicketByIdAsync(int TicketID)
        {
            try
            {
                var ticket = await _context.Tickets
                    .Where(t => t.TicketId == TicketID).FirstOrDefaultAsync();
                return ticket;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            try
            {
                var tickets = await _context.Tickets.ToListAsync();
                return tickets;
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<Ticket>> GetTicketsByShowAsync(int ShowID)
        {
            try
            {
                var tickets = await _context.Tickets
                    .Where(t => t.IdShowing == ShowID).ToListAsync();
                return tickets;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Ticket> UpdateTicketAsync(Ticket ticket)
        {
            try
            {
                _context.Entry(ticket).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return ticket;
            }
            catch
            {
                throw;
            }
        }
    }
}
