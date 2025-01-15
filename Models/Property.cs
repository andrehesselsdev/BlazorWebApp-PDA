using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Property
{
    public int AccId { get; set; }

    public int PropId { get; set; }

    public string? Value { get; set; }

    public virtual Accommodation Acc { get; set; } = null!;

    public virtual PropertySet Prop { get; set; } = null!;
}
