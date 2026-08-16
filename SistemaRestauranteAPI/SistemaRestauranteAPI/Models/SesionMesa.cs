using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class SesionMesa
{
    public int IdSesionMesa { get; set; }

    public int IdMesa { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? IdEstadoSesionMesa { get; set; }

    public virtual EstadoSesionMesa? IdEstadoSesionMesaNavigation { get; set; }

    public virtual Mesa IdMesaNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
