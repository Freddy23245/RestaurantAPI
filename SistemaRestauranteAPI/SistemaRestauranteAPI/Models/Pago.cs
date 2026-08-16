using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdSesionMesa { get; set; }

    public DateTime FechaHora { get; set; }

    public decimal Importe { get; set; }

    public int IdMedioPago { get; set; }

    public int IdEstadoPago { get; set; }

    public virtual EstadoPago IdEstadoPagoNavigation { get; set; } = null!;

    public virtual MedioPago IdMedioPagoNavigation { get; set; } = null!;

    public virtual SesionMesa IdSesionMesaNavigation { get; set; } = null!;
}
