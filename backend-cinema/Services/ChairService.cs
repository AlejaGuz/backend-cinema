using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace backend_cinema.Services
{
    public class ChairService : IChairService
    {
        private readonly AlejaCinemaContext _context;

        public ChairService(AlejaCinemaContext context)
        {
            _context = context;
        }

        public async Task<Chair> AddChairAsync(Chair Chair)
        {
            try
            {
                await _context.Chairs.AddAsync(Chair);
                await _context.SaveChangesAsync();
                return Chair;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteChairAsync(int ChairID)
        {
            try
            {
                var chair = await GetChairByIdAsync(ChairID);
                if (chair != null)
                {
                    _context.Chairs.Remove(chair);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Chair>> GetAvailableChairsByShowAsync(int ShowID)
        {
            try
            {
                var ocuppiedChairs = await GetOcuppiedChairsByShowAsync(ShowID);
                var allChairs = await GetChairsAsync();

                if (ocuppiedChairs != null)
                {
                    return allChairs.Except(ocuppiedChairs).ToList(); 
                }
                
                return allChairs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Chair> GetChairByIdAsync(int ChairID)
        {
            try
            {
                var chair = await _context.Chairs
                    .Where(c => c.ChairID == ChairID).FirstOrDefaultAsync();
                return chair;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Chair>> GetChairsAsync()
        {
            try
            {
                var chairs = await _context.Chairs.ToListAsync();
                return chairs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Chair>> GetOcuppiedChairsByShowAsync(int ShowID)
        {
            try
            {
                var tickets = await _context.Tickets
                    .Where(t => t.IdShowing == ShowID).ToListAsync();

                if (tickets.Count > 0)
                {
                    List<Chair> result = new List<Chair>();
                    foreach (var t in tickets)
                    {
                        Chair c = await GetChairByIdAsync(t.IdChair);
                        result.Add(c);
                    }

                    return result;
                }

                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Chair> UpdateChairAsync(Chair Chair)
        {
            try
            {
                _context.Entry(Chair).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Chair;
            }
            catch
            {
                throw;
            }
        }
    }
}
