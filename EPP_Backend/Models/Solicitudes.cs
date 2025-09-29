using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class Solicitudes
{
    public int IdSolicitud { get; set; }

    public int IdSolicitante { get; set; }

    public DateTime FechaSolicitud { get; set; }

    public string Justificacion { get; set; } = null!;

    public string? Status { get; set; }

    public virtual Usuarios IdSolicitanteNavigation { get; set; } = null!;

    public virtual ICollection<SolicitudEmpleado> SolicitudEmpleado { get; set; } = new List<SolicitudEmpleado>();
}
