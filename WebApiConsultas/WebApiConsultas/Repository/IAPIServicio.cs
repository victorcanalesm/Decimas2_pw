using WebApiConsultas.Models;

namespace WebApiConsultas.Repository
{
    public interface IAPIServicio
    {
        Task<List<Producto>> Listado();
        Task<Datos> Insertar(int CodProducto,
                                 string NomProducto,
                                 int PrecioProducto);
        Task<List<Producto>> FiltroDatos(int CodProducto,
                                 string NomProducto,
                                 int PrecioProducto);
        Task<Datos> Editar(int CodProducto,
                                 string NomProducto,
                                 int PrecioProducto);
        Task<Datos> Eliminar(int CodProducto);

        Task<Datos> InsertarVenta(int CodProducto,
                                    int Cantidad);
        Task<List<VentaProducto>> TraerVenta();
    }
}
