using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? UltimoCambio { get; set; }

    public int IntentosFallidos { get; set; }

    public string Rol { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Solicitudes> Solicitudes { get; set; } = new List<Solicitudes>();
}
