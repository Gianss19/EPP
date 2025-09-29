using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class Empleados
{
    public int NumEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdPuesto { get; set; }

    public virtual Puestos IdPuestoNavigation { get; set; } = null!;

    public virtual ICollection<SolicitudEmpleado> SolicitudEmpleado { get; set; } = new List<SolicitudEmpleado>();
}
