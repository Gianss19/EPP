using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class Puestos
{
    public int IdPuesto { get; set; }

    public string Puesto { get; set; } = null!;

    public int IdGerencia { get; set; }

    public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();

    public virtual Gerencias IdGerenciaNavigation { get; set; } = null!;
}
