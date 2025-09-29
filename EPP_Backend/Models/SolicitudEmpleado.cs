using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class SolicitudEmpleado
{
    public int IdSolicitudEmpleado { get; set; }

    public int IdSolicitud { get; set; }

    public int NumEmpleado { get; set; }

    public string? Rol { get; set; }

    public virtual Solicitudes IdSolicitudNavigation { get; set; } = null!;

    public virtual ICollection<ItemsSolicitud> ItemsSolicitud { get; set; } = new List<ItemsSolicitud>();

    public virtual Empleados NumEmpleadoNavigation { get; set; } = null!;
}
