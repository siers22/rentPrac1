using System;
using System.Collections.Generic;

namespace rentPrac1.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
