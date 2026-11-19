using API_Consultas.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        List<Producto> listado = new List<Producto>();
        [HttpGet]
        [Route("Listado")]
        public IActionResult Listado()
        {
            try
            {
                using (var bd = new EjemploContext())
                {
                    var sql = from P in bd.Productos
                              select new
                              {
                                  P.CodProducto,
                                  P.NomProducto,
                                  P.PrecioProducto
                              };
                    foreach (var item in sql)
                    {
                        listado.Add(new Producto()
                        {
                            CodProducto = item.CodProducto,
                            NomProducto = item.NomProducto,
                            PrecioProducto = item.PrecioProducto
                        });
                    }
                }

                return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        mensaje = "OK",
                                        respuesta = listado
                                    });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new
                                   {
                                       mensaje = "ERROR",
                                       retorno = ex.Message
                                   });
            }
        }

        [HttpPost]
        [Route("Insertar")]
        public IActionResult Insertar([FromBody] Producto prod)
        {
            try
            {
                using (var bd = new EjemploContext())
                {
                    /*var sql = from P in bd.Productos
                              where P.CodProducto == prod.CodProducto
                              select new { P.PrecioProducto };*/

                    var contador = bd.Productos.Where(x
                        => x.CodProducto == prod.CodProducto).Count();
                    if (contador == 0)
                    {//insertar producto
                        Producto insertar = new Producto();
                        insertar.CodProducto = prod.CodProducto;
                        insertar.NomProducto = prod.NomProducto;
                        insertar.PrecioProducto = prod.PrecioProducto;
                        bd.Productos.Add(insertar);
                        bd.SaveChanges();//guarda en la base de datos

                        return StatusCode(StatusCodes.Status200OK,
                                  new
                                  {
                                      mensaje = "OK",
                                      retorno = "Datos ingresados correctamente"
                                  });
                    }
                    else
                    {//enviar mensaje
                        return StatusCode(StatusCodes.Status200OK,
                                 new
                                 {
                                     mensaje = "ERROR",
                                     retorno = "Código ya existe"
                                 });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new
                                   {
                                       mensaje = "ERROR",
                                       retorno = ex.Message
                                   });
            }
        }
        [HttpPost]
        [Route("FiltroDatos")]
        public IActionResult FiltroDatos([FromBody] Producto prod)
        /*int codProducto,
         string nomProducto,
         int precioProducto)*/
        {
            List<Producto> temporal = new List<Producto>();//para poder almacenar los datos filtrados
            try
            {
                var query = new List<Producto>();//para poder realizar las consultas
                //codProducto = 0 => vacio
                //nomProducto = "0" => vacio
                //precioProducto = 0 => vacio
                var codProducto = prod.CodProducto;
                var nomProducto = prod.NomProducto;
                var precioProducto = prod.PrecioProducto;

                using (var bd = new EjemploContext())
                {
                    if (codProducto != 0 && nomProducto != "0" && precioProducto != 0)
                    {
                        query = bd.Productos.Where(x => x.CodProducto == codProducto && x.NomProducto == nomProducto && x.PrecioProducto == precioProducto).ToList();
                    }
                    else if (codProducto == 0 && nomProducto != "0" && precioProducto != 0)
                    {
                        query = bd.Productos.Where(x => x.NomProducto == nomProducto && x.PrecioProducto == precioProducto).ToList();
                    }
                    else if (codProducto == 0 && nomProducto == "0" && precioProducto != 0)
                    {
                        query = bd.Productos.Where(x => x.PrecioProducto == precioProducto).ToList();
                    }
                    else if (codProducto == 0 && nomProducto != "0" && precioProducto == 0)
                    {
                        query = bd.Productos.Where(x => x.NomProducto == nomProducto).ToList();
                    }
                    else if (codProducto != 0 && nomProducto == "0" && precioProducto == 0)
                    {
                        query = bd.Productos.Where(x => x.CodProducto == codProducto).ToList();
                    }
                    else if (codProducto != 0 && nomProducto == "0" && precioProducto != 0)
                    {
                        query = bd.Productos.Where(x => x.CodProducto == codProducto && x.PrecioProducto == precioProducto).ToList();
                    }
                    else if (codProducto != 0 && nomProducto != "0" && precioProducto == 0)
                    {
                        query = bd.Productos.Where(x => x.CodProducto == codProducto && x.NomProducto == nomProducto).ToList();
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status200OK,
                                new
                                {
                                    mensaje = "ERROR",
                                    retorno = "Debe enviar por lo menos un dato para filtrar",
                                    respuesta = temporal
                                });
                    }

                    foreach (var item in query)
                    {
                        temporal.Add(new Producto()
                        {
                            CodProducto = item.CodProducto,
                            NomProducto = item.NomProducto,
                            PrecioProducto = item.PrecioProducto
                        });
                    }
                    return StatusCode(StatusCodes.Status200OK,
                                 new
                                 {
                                     mensaje = "OK",
                                     respuesta = temporal
                                 });
                }
            }
            catch (Exception ex)
            {
                temporal.Add(new Producto() { NomProducto = ex.Message });
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new
                                   {
                                       mensaje = "ERROR",
                                       retorno = ex.Message,
                                       respuesta = temporal
                                   });
            }
        }

        [HttpPost]
        [Route("EditarDatos")]
        public IActionResult EditarDatos([FromBody] Producto prod)
        {
            try
            {
                using (var bd = new EjemploContext())
                {
                    var contar = bd.Productos.Where(x => x.CodProducto == prod.CodProducto);
                    if (contar.Count() == 0)
                    {//no encuentra registro

                        return StatusCode(StatusCodes.Status200OK,
                            new
                            {
                                mensaje = "ERROR",
                                retorno = "Producto no encontrado"
                            });
                    }
                    else
                    {
                        var editar = bd.Productos.First(x => x.CodProducto == prod.CodProducto);
                        if (prod.NomProducto != "0")
                        {
                            editar.NomProducto = prod.NomProducto;
                        }
                        if (prod.PrecioProducto != 0)
                        {
                            editar.PrecioProducto = prod.PrecioProducto;
                        }
                        bd.SaveChanges();
                        return StatusCode(StatusCodes.Status200OK,
                           new
                           {
                               mensaje = "OK",
                               retorno = "Datos editados correctamente"
                           });
                    }
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new
                                   {
                                       mensaje = "ERROR",
                                       retorno = ex.Message
                                   });
            }
        }

        [HttpPost]
        [Route("EliminarDatos")]
        public IActionResult EliminarDatos([FromBody] Producto prod)
        {
            try
            {
                using (var bd = new EjemploContext())
                {
                    var contar = bd.Productos.Where(x => x.CodProducto == prod.CodProducto);
                    if (contar.Count() == 0)
                    {
                        return StatusCode(StatusCodes.Status200OK,
                            new
                            {
                                mensaje = "ERROR",
                                retorno = "Producto no encontrado"
                            });
                    }
                    else
                    {
                        var eliminar = bd.Productos.Where(
                            x => x.CodProducto == prod.CodProducto).First();
                        bd.Productos.Remove(eliminar);
                        bd.SaveChanges();

                        return StatusCode(StatusCodes.Status200OK,
                           new
                           {
                               mensaje = "OK",
                               retorno = "Dato eliminado correctamente"
                           });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new
                                   {
                                       mensaje = "ERROR",
                                       retorno = ex.Message
                                   });
            }
        }

        [HttpPost]
        [Route("InsertarVenta")]
        public IActionResult InsertarVenta([FromBody] Ventum vent)
        {
            try
            {
                using (var bd = new EjemploContext())
                {
                    Ventum venta = new Ventum();
                    //venta.IdVenta = vent.IdVenta;
                    venta.CodProducto = vent.CodProducto;
                    venta.Cantidad = vent.Cantidad;
                    bd.Venta.Add(venta);
                    bd.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK,
                                  new
                                  {
                                      mensaje = "OK",
                                      retorno = "Venta insertada correctamente"
                                  });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new
                                  {
                                      mensaje = "ERROR",
                                      retorno = ex.Message + " " + ex.InnerException.Message
                                  });
            }
        }

        [HttpGet]
        [Route("TraerVenta")]

        public IActionResult TraerVenta()
        {
            try
            {
                List<VentaProducto> listaVenta = new List<VentaProducto>();
                using (var bd = new EjemploContext())
                {
                    var sql = from V in bd.Venta
                              join P in bd.Productos on V.CodProducto equals P.CodProducto
                              select new
                              {
                                 V.IdVenta,
                                 P.NomProducto,
                                 P.PrecioProducto,
                                 V.Cantidad
                              };
                    foreach (var item in sql)
                    {
                        listaVenta.Add(new VentaProducto()
                        {
                            IdVenta = item.IdVenta,
                            NomProducto = item.NomProducto,
                            PrecioProducto = item.PrecioProducto,
                            Cantidad = item.Cantidad
                        });
                    }
                    return StatusCode(StatusCodes.Status200OK,
                           new
                           {
                               mensaje = "OK",
                               respuesta = listaVenta
                           });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new
                                   {
                                       mensaje = "ERROR",
                                       retorno = ex.Message
                                   });
            }
        }
    }
}
