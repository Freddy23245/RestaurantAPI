using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class Mesa
{
    public int IdMesa { get; set; }

    public int Numero { get; set; }

    public int Capacidad { get; set; }

    public string CodigoQr { get; set; } = null!;

    public bool Activa { get; set; }

    public virtual ICollection<SesionMesa> SesionMesas { get; set; } = new List<SesionMesa>();
}
