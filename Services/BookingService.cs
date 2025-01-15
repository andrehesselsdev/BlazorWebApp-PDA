using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class BookingService
    {
        private readonly BookingAppContext _context;
        public BookingService(BookingAppContext context)
        {
            _context = context;
        }

        public async Task<List<Accommodation>> GetAccommodationsAsync()
        {
            return await _context.Accommodations
                                 .Include(a => a.Loc)
                                 .ToListAsync();
        }

        public async Task<Accommodation> GetAccommodationByIdAsync(int id)
        {
            return await _context.Accommodations.FindAsync(id);
        }
    }
}