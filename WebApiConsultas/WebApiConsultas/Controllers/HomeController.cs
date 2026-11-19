using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApiConsultas.Models;
using WebApiConsultas.Repository;

namespace WebApiConsultas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAPIServicio _aPIServicio;
        public HomeController(IAPIServicio aPIServicio)
        {
            _aPIServicio = aPIServicio;
        }

        public async Task<IActionResult> Index()
        {
            List<Producto> lista = await _aPIServicio.Listado();
            ViewBag.listado = lista;
            return View();
        }       

        public async Task<IActionResult> Privacy()
        {
            List<Producto> lista = await _aPIServicio.Listado();
            ViewBag.listado = lista;
            return View();
        }
        public async Task<IActionResult> Editar()
        {
            List<Producto> lista = await _aPIServicio.Listado();
            ViewBag.listado = lista;
            return View();
        }
        public async Task<IActionResult> Eliminar()
        {
            List<Producto> lista = await _aPIServicio.Listado();
            ViewBag.listado = lista;
            return View();
        }
        public async Task<IActionResult> InsertarVenta()
        {            
            return View();
        }

        public async Task<IActionResult> InsertarDatos(int txtCodigo, string txtNombre, int txtPrecio)
        {
            var resp = await _aPIServicio.Insertar(txtCodigo, txtNombre, txtPrecio);
            ViewBag.mensaje = resp.retorno;
            List<Producto> lista = await _aPIServicio.Listado();
            ViewBag.listado = lista;
            return View("Privacy");
        }
        public async Task<IActionResult> Buscar()
        {
            return View();
        }
        public async Task<IActionResult> BuscarDatos(int txtCodigo,
                                                    string txtNombre,
                                                    int txtPrecio)
        {
            if (txtCodigo == null)
            {
                txtCodigo = 0;
            }
            if (txtNombre == null)
            {
                txtNombre = "0";
            }
            if (txtPrecio == null)
            {
                txtPrecio = 0;
            }
            try
            {
                List<Producto> resp =
                    await _aPIServicio.FiltroDatos(txtCodigo, txtNombre, txtPrecio);
                var mensaje = resp.FirstOrDefault();
                if (mensaje.CodProducto == 0)
                {
                    ViewBag.mensaje = mensaje.NomProducto;
                }
                else
                {
                    ViewBag.listado = resp;
                }
            }catch(Exception ex)
            {
                ViewBag.mensaje = ex.Message;
            }
            return View("Buscar");
        }

        public async Task<IActionResult> EditarDatos(int txtCodigo, string txtNombre, int txtPrecio)
        {
            var resp = await _aPIServicio.Editar(txtCodigo, txtNombre, txtPrecio);
            ViewBag.mensaje = resp.retorno;
            List<Producto> lista = await _aPIServicio.Listado();
            ViewBag.listado = lista;
            return View("Privacy");
        }

        public async Task<IActionResult> EliminarDatos(int txtCodigo)
        {
            var resp = await _aPIServicio.Eliminar(txtCodigo);
            ViewBag.mensaje = resp.retorno;
            List<Producto> lista = await _aPIServicio.Listado();
            ViewBag.listado = lista;
            return View("Privacy");
        }
        ////////////////////////////////////////NUEVO PARA JS///////////////////////////////////////////////
        public async Task<List<Producto>> cargaProductos()
        {
            List<Producto> lista = await _aPIServicio.Listado();
            return lista;
        }
        public async Task<Datos> VentaInsertar(int Producto, int Cantidad)
        {
            var resp = await _aPIServicio.InsertarVenta(Producto, Cantidad);
            return resp;
        }
        public async Task<List<VentaProducto>> cargaVentas()
        {
            List<VentaProducto> lista = await _aPIServicio.TraerVenta();
            return lista;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
