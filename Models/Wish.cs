using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Wish
{
    public int CustomerId { get; set; }

    public int WishId { get; set; }

    public int PropId { get; set; }

    public string? Value { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual PropertySet Prop { get; set; } = null!;
}
