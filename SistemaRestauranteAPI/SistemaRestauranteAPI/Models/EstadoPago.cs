using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class EstadoPago
{
    public int IdEstadoPago { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
