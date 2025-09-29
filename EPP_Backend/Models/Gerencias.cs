using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class Gerencias
{
    public int IdGerencia { get; set; }

    public string Gerencia { get; set; } = null!;

    public int IdDireccion { get; set; }

    public int CentroCostos { get; set; }

    public virtual Direcciones IdDireccionNavigation { get; set; } = null!;

    public virtual ICollection<Puestos> Puestos { get; set; } = new List<Puestos>();
}
