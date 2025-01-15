using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class PropertySet
{
    public int PropId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();

    public virtual ICollection<Wish> Wishes { get; set; } = new List<Wish>();
}
