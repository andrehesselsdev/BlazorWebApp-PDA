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



        public async Task<List<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings
                                 .Include(b => b.Acc)
                                     .ThenInclude(a => a.Loc)
                                 .Include(b => b.Customer)
                                 .ToListAsync();
        }

        public async Task<List<Accommodation>> GetAccommodationsAsync()
        {
            return await _context.Accommodations
                                 .Include(a => a.Loc)
                                 .ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task AddBookingAsync(Booking booking)
        {
            var maxId = await _context.Bookings.MaxAsync(b => (int?)b.BookingId) ?? 0;
            booking.BookingId = maxId + 1;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
    }
}