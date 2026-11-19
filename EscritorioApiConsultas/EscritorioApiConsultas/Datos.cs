using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscritorioApiConsultas
{
    internal class Datos
    {
        public string? mensaje { get; set; }
        public string? retorno { get; set; }
        public valores[]? respuesta { get; set; }
    }
    public partial class valores()
    {
        public int CodProducto { get; set; }
        public string? NomProducto { get; set; }
        public int PrecioProducto { get; set; }
    }
}
