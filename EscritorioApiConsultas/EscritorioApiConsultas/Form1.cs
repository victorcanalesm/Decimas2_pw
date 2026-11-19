using System.Data;
using System.Net.Http.Json;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EscritorioApiConsultas
{
    public partial class Form1 : Form
    {
        private static string ruta = "https://localhost:7173/api/";
        private static readonly HttpClient cliente = new HttpClient();
        private int id_oculto = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cliente.DefaultRequestHeaders.Clear();
            cliente.DefaultRequestHeaders.Add("Accept-Languaje", "es-CL");
            cargaGrilla();
            cargaGrillaVenta();
            cargaComboProducto();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cargaGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "";
                if (id_oculto == 0)
                {
                    //insertar
                    url = ruta + "Producto/Insertar";
                }
                else
                {
                    //editar
                    url = ruta + "Producto/EditarDatos";
                }

                int codigo = int.Parse(txtCodigo.Value.ToString());
                if (codigo == 0)
                {
                    MessageBox.Show("Debe ingresar un código distinto a 0");
                }
                else
                {
                    string nombre = txtNombre.Text;
                    string pre = txtPrecio.Value.ToString();
                    int precio = int.Parse(txtPrecio.Value.ToString());

                    var contenido = new Productos
                    {
                        CodProducto = codigo,
                        NomProducto = nombre,
                        PrecioProducto = precio
                    };
                    HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, contenido);
                    respuesta.EnsureSuccessStatusCode();

                    Datos? msg = await respuesta.Content.ReadFromJsonAsync<Datos>();
                    if (msg != null)
                    {
                        if (msg.mensaje == "OK")
                        {
                            cargaGrilla();
                            cargaComboProducto();
                        }
                        else
                        {
                            MessageBox.Show(msg.retorno, msg.mensaje);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtCodigo.Enabled = true;
            id_oculto = 0;
            txtCodigo.Value = 0;
            txtNombre.Text = "";
            txtPrecio.Value = 0;
        }

        public async void cargaGrilla()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CODIGO");
                dt.Columns.Add("NOMBRE PRODUCTO");
                dt.Columns.Add("PRECIO");

                string url = ruta + "Producto/Listado";
                Datos? msg = await cliente.GetFromJsonAsync<Datos>(url);
                if (msg != null)
                {
                    foreach (var item in msg.respuesta)
                    {
                        dt.Rows.Add(item.CodProducto, item.NomProducto, item.PrecioProducto);
                    }
                    dataGridView1.DataSource = dt;
                }
                dataGridView1.Columns["CODIGO"].DisplayIndex = 0;
                dataGridView1.Columns["NOMBRE PRODUCTO"].DisplayIndex = 1;
                dataGridView1.Columns["PRECIO"].DisplayIndex = 2;
                dataGridView1.Columns["EDITAR"].DisplayIndex = 3;
                dataGridView1.Columns["ELIMINAR"].DisplayIndex = 4;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "ELIMINAR")
                {
                    if (MessageBox.Show("¿Desea eliminar el registro?",
                        "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int indexFila = dataGridView1.CurrentCell.RowIndex;
                        int id = int.Parse(dataGridView1.Rows[indexFila].Cells[2].Value.ToString());
                        //vamos a enviar a la api el valor para eliminar
                        string url = ruta + "Producto/EliminarDatos";
                        var contenido = new Productos
                        {
                            CodProducto = id
                        };
                        HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, contenido);
                        respuesta.EnsureSuccessStatusCode();

                        Datos? msg = await respuesta.Content.ReadFromJsonAsync<Datos>();
                        if (msg != null)
                        {
                            if (msg.mensaje == "OK")
                            {
                                cargaGrilla();
                            }
                            else
                            {
                                MessageBox.Show(msg.retorno, msg.mensaje);
                            }
                        }
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "EDITAR")
                {
                    int indexFila = dataGridView1.CurrentCell.RowIndex;

                    int id = int.Parse(dataGridView1.Rows[indexFila].Cells[2].Value.ToString());
                    string nombre = dataGridView1.Rows[indexFila].Cells[3].Value.ToString();
                    int precio = int.Parse(dataGridView1.Rows[indexFila].Cells[4].Value.ToString());

                    txtCodigo.Value = id;
                    txtNombre.Text = nombre;
                    txtPrecio.Value = precio;
                    txtCodigo.Enabled = false;
                    id_oculto = id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void BtnGuardarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                string url = ruta + "Producto/InsertarVenta";
                int producto = int.Parse(cmbProducto.SelectedValue.ToString());
                int cantidad = int.Parse(txtCantidad.Value.ToString());
                if (cantidad == 0)
                {
                    MessageBox.Show("Debe ingresar una cantidad mayor a 0");
                }
                else
                {
                    var contenido = new Venta
                    {
                        CodProducto = producto,
                        Cantidad = cantidad
                    };
                    HttpResponseMessage respuesta = await cliente.PostAsJsonAsync(url, contenido);
                    respuesta.EnsureSuccessStatusCode();

                    Datos? msg = await respuesta.Content.ReadFromJsonAsync<Datos>();
                    if (msg != null)
                    {
                        if (msg.mensaje == "OK")
                        {
                            cargaGrilla();
                            cargaGrillaVenta();
                        }
                        else
                        {
                            MessageBox.Show(msg.retorno, msg.mensaje);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtCantidad.Value = 0;
        }

        public async void cargaGrillaVenta()
        {

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CODIGO");
                dt.Columns.Add("NOMBRE PRODUCTO");
                dt.Columns.Add("PRECIO");
                dt.Columns.Add("CANTIDAD");
                dt.Columns.Add("TOTAL");

                string url = ruta + "Producto/TraerVenta";
                DatosVenta? msg = await cliente.GetFromJsonAsync<DatosVenta>(url);
                if (msg != null)
                {
                    foreach (var item in msg.respuesta)
                    {
                        dt.Rows.Add(item.IdVenta, item.NomProducto, item.PrecioProducto, item.Cantidad, (item.PrecioProducto*item.Cantidad));
                    }
                    dgvVenta.DataSource = dt;
                }
                dgvVenta.Columns["CODIGO"].DisplayIndex = 0;
                dgvVenta.Columns["NOMBRE PRODUCTO"].DisplayIndex = 1;
                dgvVenta.Columns["PRECIO"].DisplayIndex = 2;
                dgvVenta.Columns["CANTIDAD"].DisplayIndex = 3;
                dgvVenta.Columns["TOTAL"].DisplayIndex = 4;
                //dgvVenta.Columns["EDITAR"].DisplayIndex = 5;
                //dgvVenta.Columns["ELIMINAR"].DisplayIndex = 6;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void cargaComboProducto()
        {

            try
            {
                DataTable listado = new DataTable();
                listado.Columns.Add("ID");
                listado.Columns.Add("NOMBRE");

                string url = ruta + "Producto/Listado";
                Datos? msg = await cliente.GetFromJsonAsync<Datos>(url);
                if (msg != null)
                {
                    foreach (var item in msg.respuesta)
                    {
                        listado.Rows.Add(item.CodProducto, item.NomProducto);
                    }
                }
                cmbProducto.ValueMember = listado.Columns[0].ToString();
                cmbProducto.DisplayMember = listado.Columns[1].ToString();
                cmbProducto.DataSource = listado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
