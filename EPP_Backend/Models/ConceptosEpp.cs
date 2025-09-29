using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class ConceptosEpp
{
    public int IdEpp { get; set; }

    public string Concepto { get; set; } = null!;

    public string UnidadMedida { get; set; } = null!;

    public bool EsResguardo { get; set; }

    public virtual ICollection<ItemsSolicitud> ItemsSolicitud { get; set; } = new List<ItemsSolicitud>();

    public virtual Stock? Stock { get; set; }
}
