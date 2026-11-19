namespace WebApiConsultas.Models
{
    public class DatosVenta
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
