using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdSesionMesa { get; set; }

    public DateTime FechaHora { get; set; }

    public int IdPedidoEstado { get; set; }

    public string? Observacion { get; set; }

    public decimal Total { get; set; }

    public virtual PedidoEstado IdPedidoEstadoNavigation { get; set; } = null!;

    public virtual SesionMesa IdSesionMesaNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
