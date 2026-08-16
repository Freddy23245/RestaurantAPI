using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class MedioPago
{
    public int IdMedioPago { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
