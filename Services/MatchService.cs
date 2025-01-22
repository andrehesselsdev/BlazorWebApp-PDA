using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class MatchService
    {
        private readonly BookingAppContext _context;

        public MatchService(BookingAppContext context)
        {
            _context = context;
        }

        public async Task<List<PropertySet>> GetPropertySetsAsync()
        {
            return await _context.PropertySets.ToListAsync();
        }

        public async Task<List<Accommodation>> GetAvailableAccommodationsAsync(int propertySetId, DateTime arrivalDate, DateTime departureDate)
        {
            var accommodationsQuery = _context.Accommodations
                .Include(a => a.Loc)
                .Include(a => a.Properties)
                .Where(a => a.Properties.Any(p => p.PropId == propertySetId));

            var arrivalDateOnly = DateOnly.FromDateTime(arrivalDate);
            var departureDateOnly = DateOnly.FromDateTime(departureDate);

            var availableAccommodations = await accommodationsQuery
                .Where(a => !a.Bookings.Any(b =>
                    (b.ArrivalDate <= departureDateOnly && b.DepartureDate >= arrivalDateOnly)))
                .ToListAsync();

            return availableAccommodations;
        }
    }
}