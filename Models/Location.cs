using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Location
{
    public int LocId { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
}
