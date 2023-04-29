using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.EntityFrameworkCore;

namespace backend_cinema.Services
{
    public class SaleService : ISaleService
    {
        private readonly AlejaCinemaContext _context;

        public SaleService(AlejaCinemaContext context)
        {
            _context = context;
        }

        public async Task<Sale> AddSaleAsync(Sale Sale)
        {
            try
            {
                await _context.Sales.AddAsync(Sale);


                await _context.SaveChangesAsync();
                return Sale;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteSaleAsync(int SaleID)
        {
            try
            {
                var sale = await GetSaleByIdAsync(SaleID);
                if (sale != null)
                {
                    _context.Sales.Remove(sale);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Sale> GetSaleByIdAsync(int SaleID)
        {
            try
            {
                var sale = await _context.Sales
                    .Where(s => s.SaleID == SaleID).FirstOrDefaultAsync();
                return sale;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Sale>> GetSalesAsync()
        {
            try
            {
                var sales = //await _context.Sales.ToListAsync();
                await _context.Sales.Include(s => s.Tickets).ToListAsync();
                return sales;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Sale>> GetSalesByShowAsync(int ShowID)
        {
            try
            {
                var sales = await _context.Sales
                    .Include(s => s.Tickets)
                    .Where(s => s.ShowingID == ShowID).ToListAsync();
                return sales;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Ticket>> GetTicketsBySaleAsync(int SaleID)
        {
            var sale = await _context.Sales
                    .Include(s => s.Tickets)
                    .Where(s => s.SaleID == SaleID).FirstOrDefaultAsync();
            return  sale.Tickets.ToList();
        }

        public async Task<Sale> UpdateSaleAsync(Sale Sale)
        {
            try
            {
                _context.Entry(Sale).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Sale;
            }
            catch
            {
                throw;
            }
        }
    }
}
