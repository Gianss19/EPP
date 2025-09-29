using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class Stock
{
    public int IdEpp { get; set; }

    public int Cantidad { get; set; }

    public virtual ConceptosEpp IdEppNavigation { get; set; } = null!;
}
