using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class CustomerService
    {
        private readonly BookingAppContext _context;

        public CustomerService(BookingAppContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            var maxId = await _context.Customers.MaxAsync(c => c.CustomerId);
            customer.CustomerId = maxId + 1;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
    }
}