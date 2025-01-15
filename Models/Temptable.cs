using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Temptable
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int BookingId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public DateOnly? DepartureDate { get; set; }

    public int? NumberOfGuests { get; set; }

    public decimal? TotalPrice { get; set; }

    public int AccId { get; set; }

    public int LocId { get; set; }

    public string AccommodationName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Country { get; set; }

    public int WishId { get; set; }

    public int PropId { get; set; }

    public string? Value { get; set; }

    public string? PropertySetName { get; set; }
}
