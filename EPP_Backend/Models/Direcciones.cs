using System;
using System.Collections.Generic;

namespace EPP_Backend.Models;

public partial class Direcciones
{
    public int IdDireccion { get; set; }

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Gerencias> Gerencias { get; set; } = new List<Gerencias>();
}
