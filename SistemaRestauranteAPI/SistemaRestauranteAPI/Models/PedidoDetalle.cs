using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class PedidoDetalle
{
    public int IdPedidoDetalle { get; set; }

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public string? Observacion { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
