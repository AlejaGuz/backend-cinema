using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.EntityFrameworkCore;

namespace backend_cinema.Services
{

    public class ShowingService : IShowingService
    {
        private readonly AlejaCinemaContext _context;
        public ShowingService(AlejaCinemaContext context)
        {
            _context = context;
        }
        public async Task<Showing> AddShowAsync(Showing show)
        {
            try
            {
                await _context.Showings.AddAsync(show);
                await _context.SaveChangesAsync();
                return show;
            }
            catch
            {
                throw;
            }

        }

        public async Task DeleteShowAsync(int ShowID)
        {
            try
            {
                var show = await GetShowByIdAsync(ShowID);
                if (show != null)
                {
                    _context.Showings.Remove(show);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Showing> GetShowByIdAsync(int ShowID)
        {
            try
            {
                var showing = await _context.Showings
                    .Where(s => s.ShowID == ShowID).FirstOrDefaultAsync();
                return showing;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Showing>> GetShowsAsync()
        {
            try
            {
                var shows = await _context.Showings.ToListAsync();
                return shows;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Showing> UpdateShowAsync(Showing show)
        {
            try
            {
                _context.Entry(show).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return show;
            }
            catch
            {
                throw;
            }
        }
    }
}
