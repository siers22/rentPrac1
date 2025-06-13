using System;
using System.Collections.Generic;

namespace rentPrac1.Models;

public partial class Property
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public string Address { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual PropertyType Type { get; set; } = null!;
}
