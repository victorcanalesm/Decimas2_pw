using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using WebApiConsultas.Models;

namespace WebApiConsultas.Repository
{
    public class RepServicioAPI : IAPIServicio
    {
        private static string? _UrlBase = "";
        private readonly HttpClient _httpClient;
        public RepServicioAPI()
        {
            var constructor = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            _UrlBase = constructor.GetSection("ConexionApi:UrlBase").Value;
            _httpClient = new();
            _httpClient.BaseAddress = new Uri(_UrlBase);
        }
        async Task<List<Producto>> IAPIServicio.FiltroDatos(int CodProducto,
                                                        string NomProducto,
                                                        int PrecioProducto)
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                var valores = new Producto() {
                    CodProducto = CodProducto,
                    NomProducto = NomProducto,
                    PrecioProducto = PrecioProducto };

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer");

                StringContent contenido =
                   new(JsonConvert.SerializeObject(valores), Encoding.UTF8, "application/json");

                HttpResponseMessage respuesta = 
                    await _httpClient.PostAsync("Producto/FiltroDatos", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    string result = await respuesta.Content.ReadAsStringAsync();
                    Datos? res = JsonConvert.DeserializeObject<Datos>(result);

                    if (res.mensaje == "OK"){
                        foreach (var item in res.respuesta){
                            lista.Add(new Producto() {
                                CodProducto = item.CodProducto,
                                NomProducto = item.NomProducto,
                                PrecioProducto = item.PrecioProducto
                            });
                        }
                    }else{
                        foreach (var item in res.respuesta){
                            lista.Add(new Producto() {
                                NomProducto = item.NomProducto
                            });
                        }
                    }
                }
                else
                {
                    lista.Add(new Producto()
                    {
                        NomProducto = "Error al buscar registros"
                    });
                }
            }
            catch (Exception ex)
            {
                lista.Add(new Producto()
                {
                    NomProducto = ex.Message
                });
            }
            return lista;
        }



        async Task<Datos> IAPIServicio.Insertar(int CodProducto, string NomProducto, int PrecioProducto)
        {          
            try
            {
                var values = new Producto() { CodProducto = CodProducto, NomProducto = NomProducto, PrecioProducto = PrecioProducto };

                _httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer");
                StringContent contenido = 
                    new(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await _httpClient.PostAsync("Producto/Insertar", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    string result = await respuesta.Content.ReadAsStringAsync();
                    Datos? res = JsonConvert.DeserializeObject<Datos>(result);

                    return new Datos() {
                        mensaje = "OK",
                        retorno = res.retorno }; 
                }
                else
                {
                    return new Datos() { 
                        mensaje = "ERROR", 
                        retorno = "Error al insertar los registros" };
                }

            }
            catch (Exception ex)
            {
                return new Datos() {
                    mensaje = "ERROR",
                    retorno = ex.Message };
            }
        }

        async Task<List<Producto>> IAPIServicio.Listado()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer");
                HttpResponseMessage respuesta = 
                    await _httpClient.GetAsync("Producto/Listado");

                if (respuesta.IsSuccessStatusCode)
                {
                    string result = await respuesta.Content.ReadAsStringAsync();
                    Datos? res = JsonConvert.DeserializeObject<Datos>(result);

                    foreach (var item in res.respuesta)
                    {
                        lista.Add(new Producto()
                        {
                            CodProducto = item.CodProducto,
                            NomProducto = item.NomProducto,
                            PrecioProducto = item.PrecioProducto
                        });
                    }
                    return lista;
                }
                else
                {
                    return await Task.FromResult(lista);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        async Task<Datos> IAPIServicio.Editar(int CodProducto, string NomProducto, int PrecioProducto)
        {
            try
            {
                var values = new Producto() { CodProducto = CodProducto, NomProducto = NomProducto, PrecioProducto = PrecioProducto };

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer");
                StringContent contenido =
                    new(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await _httpClient.PostAsync("Producto/EditarDatos", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    string result = await respuesta.Content.ReadAsStringAsync();
                    Datos? res = JsonConvert.DeserializeObject<Datos>(result);

                    return new Datos()
                    {
                        mensaje = "OK",
                        retorno = res.retorno };
                }
                else
                {
                    return new Datos()
                    {
                        mensaje = "ERROR",
                        retorno =  "Error al editar los registros" };
                }

            }
            catch (Exception ex)
            {
                return new Datos()
                {
                    mensaje = "ERROR",
                    retorno = ex.Message
                };
            }
        }
        async Task<Datos> IAPIServicio.Eliminar(int CodProducto)
        {
            try
            {
                var values = new Producto() { CodProducto = CodProducto };

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer");
                StringContent contenido =
                    new(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await _httpClient.PostAsync("Producto/EliminarDatos", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    string result = await respuesta.Content.ReadAsStringAsync();
                    Datos? res = JsonConvert.DeserializeObject<Datos>(result);

                    return new Datos()
                    {
                        mensaje = "OK",
                        retorno = res.retorno };
                }
                else
                {
                    return new Datos()
                    {
                        mensaje = "ERROR",
                        retorno = "Error al eliminar los registros" };
                }

            }
            catch (Exception ex)
            {
                return new Datos()
                {
                    mensaje = "ERROR",
                    retorno = ex.Message
                };
            }
        }

        async Task<Datos> IAPIServicio.InsertarVenta(int CodProducto, int Cantidad)
        {
            try
            {
                var values = new Venta() { CodProducto = CodProducto, Cantidad = Cantidad };

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer");
                StringContent contenido =
                    new(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");
                HttpResponseMessage respuesta = await _httpClient.PostAsync("Producto/InsertarVenta", contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    string result = await respuesta.Content.ReadAsStringAsync();
                    Datos? res = JsonConvert.DeserializeObject<Datos>(result);

                    return new Datos()
                    {
                        mensaje = res.mensaje,
                        retorno = res.retorno
                    };
                }
                else
                {
                    return new Datos()
                    {
                        mensaje = "ERROR",
                        retorno = "Error al insertar los registros"
                    };
                }

            }
            catch (Exception ex)
            {
                return new Datos()
                {
                    mensaje = "ERROR",
                    retorno = ex.Message
                };
            }
        }
        async Task<List<VentaProducto>> IAPIServicio.TraerVenta()
        {
            List<VentaProducto> lista = new List<VentaProducto>();
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer");
                HttpResponseMessage respuesta =
                    await _httpClient.GetAsync("Producto/TraerVenta");

                if (respuesta.IsSuccessStatusCode)
                {
                    string result = await respuesta.Content.ReadAsStringAsync();
                    DatosVenta? res = JsonConvert.DeserializeObject<DatosVenta>(result);

                    foreach (var item in res.respuesta)
                    {
                        lista.Add(new VentaProducto()
                        {
                            IdVenta = item.IdVenta,
                            NomProducto = item.NomProducto,
                            PrecioProducto = item.PrecioProducto,
                            Cantidad = item.Cantidad
                        });
                    }
                    return lista;
                }
                else
                {
                    return await Task.FromResult(lista);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
