using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscritorioApiConsultas
{
    internal class DatosVenta
    {
        public string? mensaje { get; set; }
        public string? retorno { get; set; }
        public valoresVenta[]? respuesta { get; set; }
    }
    public partial class valoresVenta()
    {
        public int IdVenta { get; set; }
        public string? NomProducto { get; set; }
        public int? PrecioProducto { get; set; }
        public int? Cantidad { get; set; }
    }
}
