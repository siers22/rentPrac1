using System;
using System.Collections.Generic;

namespace rentPrac1.Models;

public partial class PropertyType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
