using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class ItemsSolicitud
{
    public int IdItem { get; set; }

    public int IdSolicitudEmpleado { get; set; }

    public int IdEpp { get; set; }

    public int Cantidad { get; set; }

    public int? Talla { get; set; }

    public bool? Surtido { get; set; }

    public virtual ConceptosEpp IdEppNavigation { get; set; } = null!;

    public virtual SolicitudEmpleado IdSolicitudEmpleadoNavigation { get; set; } = null!;
}
