using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public int AccId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public DateOnly? DepartureDate { get; set; }

    public int? NumberOfGuests { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Accommodation Acc { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
