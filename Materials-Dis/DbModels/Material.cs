using System;
using System.Collections.Generic;

namespace Materials_Dis.DbModels;

public partial class Material
{
    public Guid Id { get; set; }

    public string MaterialName { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public decimal Quantity { get; set; }

    public DateTime CreatedDate { get; set; }
}
