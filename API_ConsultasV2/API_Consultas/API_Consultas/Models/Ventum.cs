using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_Consultas.Models;

public partial class Ventum
{
    [JsonIgnore]
    public int IdVenta { get; set; }

    public int CodProducto { get; set; }

    public int? Cantidad { get; set; }
    [JsonIgnore]
    public virtual Producto? CodProductoNavigation { get; set; } = null!;
}
