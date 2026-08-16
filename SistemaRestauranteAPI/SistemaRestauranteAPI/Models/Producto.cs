using System;
using System.Collections.Generic;

namespace SistemaRestauranteAPI.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string? Imagen { get; set; }

    public bool Activo { get; set; }

    public virtual Categorias IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
