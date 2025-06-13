using System;
using System.Collections.Generic;

namespace rentPrac1.Models;

public partial class Contract
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int PropertyId { get; set; }

    public string ContractStartDate { get; set; } = null!;

    public string ContractEndDate { get; set; } = null!;

    public int RentTime { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;
}
