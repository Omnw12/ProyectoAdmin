using Newtonsoft.Json;
using ProyectoChat.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoChat.Formularios
{
    public partial class Modelos : Form
    {
        public Modelos()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            RellenarDataGridView();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            this.Hide();
            stock.Show();
        }

        private void metroSetButton2_Click(object sender, EventArgs e)
        {
            UserSession.CurrentUser = null;
            UserSession.CurrentConc = null;
            UserSession.CurrentStockVehiculos = null;
            this.Hide();
            Form1 inicio = new Form1();
            inicio.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private async void btnBuscar_ClickAsync(object sender, EventArgs e)
        {
            string modelo = metroSetTextBox1.Text;
            try
            {
                List<Modelo> modelos = await BuscarModeloAsync(modelo);
                dataGridView1.DataSource = modelos;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroSetTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroSetLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public async Task<List<Modelo>> MostrarModelsFullAsync()
        {
            var baseUrl = "http://20.90.95.76/mostrarModelsFull.php";
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(baseUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Modelo>>(jsonResponse);
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener respuesta del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<Modelo>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Modelo>();
                }
            }
        }
        private async void RellenarDataGridView()
        {
            try
            {
                List<Modelo> modelos = await MostrarModelsFullAsync();
                dataGridView1.DataSource = modelos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task<List<Modelo>> BuscarModeloAsync(string modelo = "")
        {
            var baseUrl = "http://20.90.95.76/buscarModelo.php";
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("modelo", modelo)
                });

                try
                {
                    var response = await client.PostAsync(baseUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Modelo>>(jsonResponse);
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener respuesta del servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<Modelo>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Modelo>();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
