using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class PedidoEstado
{
    public int IdPedidoEstado { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
