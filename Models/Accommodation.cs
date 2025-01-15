using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Accommodation
{
    public int AccId { get; set; }

    public int LocId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Location Loc { get; set; } = null!;

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
