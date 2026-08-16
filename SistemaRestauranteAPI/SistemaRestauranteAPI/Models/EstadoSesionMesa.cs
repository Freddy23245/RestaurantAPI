using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class EstadoSesionMesa
{
    public int IdEstadoSesionMesa { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<SesionMesa> SesionMesas { get; set; } = new List<SesionMesa>();
}
