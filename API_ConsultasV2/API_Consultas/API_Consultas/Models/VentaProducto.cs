namespace API_Consultas.Models
{
    public class VentaProducto
    {
        public int IdVenta {  get; set; }
        public string? NomProducto { get; set; }
        public int? PrecioProducto { get; set; }
        public int? Cantidad { get; set; }
    }
}
