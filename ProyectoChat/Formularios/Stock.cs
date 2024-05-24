using ProyectoChat.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using ProyectoChat.Formularios;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace ProyectoChat
{
    public partial class Stock : Form
    {
        private const string BaseUrl = "http://20.90.95.76/";
        public Stock()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
            LoadStock();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellClick += dataGridView1_CellClick;

        }

        private async void LoadStock()
        {
            try
            {
                var user = UserSession.CurrentUser;
                List<StockVehiculos> stock = await MostrarStockAsync(user.id_concesionario.ToString());
                dataGridView1.DataSource = stock;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task<List<StockVehiculos>> MostrarStockAsync(string id_concesionario)
        {
            var baseUrl = $"http://20.90.95.76/mostrarStock.php?id_concesionario={id_concesionario}";
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(baseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<StockVehiculos>>(jsonResponse);
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener respuesta del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<StockVehiculos>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<StockVehiculos>();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chat inicio = new Chat();
            inicio.Show();
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            UserSession.CurrentConc = null;
            UserSession.CurrentUser = null;
            UserSession.CurrentStockVehiculos = null;
            this.Hide();
            Form1 inicio = new Form1();
            inicio.Show();
        }

        private void metroSetButton2_Click(object sender, EventArgs e)
        {
            Modelos models = new Modelos();
            this.Hide();
            models.Show();
        }

        private void metroSetLabel4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Seleccionar imagen"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var id_modelo = metroSetTextBox3.Text; // Cambiado a .Text para obtener el texto real
            var user = UserSession.CurrentUser;
            List<StockVehiculos> stock = await BuscarCoche_idAsync(id_modelo, user.id_concesionario.ToString());
            if (stock != null && stock.Count > 0)
            {
                dataGridView1.DataSource = stock;
            }
            else
            {
                MessageBox.Show("No se encontraron resultados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = new List<StockVehiculos>();
            }
        }

        public async Task<List<StockVehiculos>> BuscarCoche_idAsync(string id_modelo, string id_concesionario)
        {
            var baseUrl = $"http://20.90.95.76/buscarModelo.php";
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string, string>("id_modelo", id_modelo),
            new KeyValuePair<string, string>("id_concesionario", id_concesionario)
        });

                try
                {
                    var response = await client.PostAsync(baseUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var stock = JsonConvert.DeserializeObject<List<StockVehiculos>>(jsonResponse);

                        // Verificar si los datos deserializados son correctos
                        if (stock != null && stock.Count > 0 && stock[0].id_modelo != 0)
                        {
                            return stock;
                        }
                        else
                        {
                            LoadStock();
                            return new List<StockVehiculos>();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error al obtener respuesta del servidor. Código de estado: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<StockVehiculos>();
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    MessageBox.Show($"Error de solicitud HTTP: {httpEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<StockVehiculos>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<StockVehiculos>();
                }
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            var user = UserSession.CurrentUser;
            int id_concesionario = user.id_concesionario;
            int id_modelo = int.Parse(metroSetTextBox4.Text);
            string description = metroSetTextBox1.Text;
            int stock = int.Parse(metroSetTextBox2.Text);

            var stockItem = new StockVehiculos
            {
                id_concesionario = id_concesionario,
                id_modelo = id_modelo,
                description = description,
                stock = stock
            };

            await InsertarStockAsync(stockItem);
            LoadStock();  
            LimpiarTxt();
        }
        public async Task InsertarStockAsync(StockVehiculos stock)
        {
            var baseUrl = "http://20.90.95.76/insertStock.php";
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(stock.id_concesionario.ToString()), "id_concesionario");
                content.Add(new StringContent(stock.id_modelo.ToString()), "id_modelo");
                content.Add(new StringContent(stock.description), "description");
                content.Add(new StringContent(stock.stock.ToString()), "stock");

                if (pictureBox2.Image != null)
                {
                    var imageStream = new MemoryStream();
                    pictureBox2.Image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                    imageStream.Seek(0, SeekOrigin.Begin);
                    content.Add(new StreamContent(imageStream), "photo", "photo.png");
                }

                try
                {
                    var response = await client.PostAsync(baseUrl, content);
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                    if (result.ContainsKey("success"))
                    {
                        MessageBox.Show("Stock añadido exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add stock: " + result["error"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LimpiarTxt()
        {
            metroSetTextBox4.Text = "";
            metroSetTextBox1.Text = "";
            metroSetTextBox2.Text = "";
            pictureBox2.Image = null;
        }
        private void metroSetTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            var user = UserSession.CurrentUser;
            int id_offer = int.Parse(dataGridView1.CurrentRow.Cells["id_offer"].Value.ToString());
            int id_modelo = int.Parse(metroSetTextBox4.Text);
            string description = metroSetTextBox1.Text;
            int stock = int.Parse(metroSetTextBox2.Text);

            var stockItem = new StockVehiculos
            {
                id_offer = id_offer,
                id_modelo = id_modelo,
                description = description,
                stock = stock
            };

            ModificarStock(stockItem);
            LimpiarTxt();
        }
        private async void ModificarStock(StockVehiculos stock)
        {
            var baseUrl = "http://20.90.95.76/modifyStock.php";
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(stock.id_offer.ToString()), "id_offer");
                content.Add(new StringContent(stock.id_modelo.ToString()), "id_modelo");
                content.Add(new StringContent(stock.description), "description");
                content.Add(new StringContent(stock.stock.ToString()), "stock");

                if (pictureBox2.Image != null)
                {
                    var imageStream = new MemoryStream();
                    pictureBox2.Image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                    imageStream.Seek(0, SeekOrigin.Begin);
                    content.Add(new StreamContent(imageStream), "photo", "photo.png");
                }

                try
                {
                    var response = await client.PostAsync(baseUrl, content);
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                    if (result.ContainsKey("success"))
                    {
                        MessageBox.Show("Stock modificado exitosamente");
                        LoadStock(); // Recargar la lista de stock
                    }
                    else
                    {
                        MessageBox.Show("Failed to modify stock: " + result["error"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id_offer = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_offer"].Value.ToString());
                await EliminarStockAsync(id_offer);
                LoadStock();
                
            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de intentar eliminar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public async Task EliminarStockAsync(int id_offer)
        {
            var baseUrl = "http://20.90.95.76/deleteStock.php";
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "id_offer", id_offer.ToString() }
                };

                var content = new FormUrlEncodedContent(values);
                try
                {
                    var response = await client.PostAsync(baseUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                        if (result.ContainsKey("success"))
                        {
                            MessageBox.Show("Registro eliminado exitosamente");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete stock: " + result["error"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete stock. Código de estado: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                metroSetTextBox4.Text = row.Cells["id_modelo"].Value.ToString();
                metroSetTextBox1.Text = row.Cells["description"].Value.ToString();
                metroSetTextBox2.Text = row.Cells["stock"].Value.ToString();

                // Cargar la imagen si el campo photo no está vacío
                string imagePath = row.Cells["photo"].Value.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    try
                    {
                        using (var client = new HttpClient())
                        {
                            var response = await client.GetAsync(imagePath);
                            if (response.IsSuccessStatusCode)
                            {
                                using (var stream = await response.Content.ReadAsStreamAsync())
                                {
                                    pictureBox2.Image = new Bitmap(stream);
                                }
                            }
                            else
                            {
                                pictureBox2.Image = null;
                                MessageBox.Show("No se pudo cargar la imagen desde la URL especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        pictureBox2.Image = null;
                        MessageBox.Show($"No se pudo cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    pictureBox2.Image = null; // Limpiar la imagen si no hay ruta
                }
            }
        }



        private void Stock_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Confirmar si el usuario realmente desea salir
            DialogResult result = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Cerrar toda la aplicación
                // o this.Close(); // Cerrar solo el formulario actual
            }
        }
    }
}
