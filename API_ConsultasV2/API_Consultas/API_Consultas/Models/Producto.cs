using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_Consultas.Models;

public partial class Producto
{
    public int CodProducto { get; set; }

    public string? NomProducto { get; set; }

    public int? PrecioProducto { get; set; }
    [JsonIgnore]
    public virtual ICollection<Ventum>? Venta { get; set; } = new List<Ventum>();
}
