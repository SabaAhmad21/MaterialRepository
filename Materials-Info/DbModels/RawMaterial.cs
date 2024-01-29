using System;
using System.Collections.Generic;

namespace Materials_Info.DbModels;

public partial class RawMaterial
{
    public int MaterialId { get; set; }

    public string MaterialName { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public decimal Quantity { get; set; }

    public DateTime CreatedDate { get; set; }
}
