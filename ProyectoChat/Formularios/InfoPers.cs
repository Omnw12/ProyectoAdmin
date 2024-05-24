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
    public partial class InfoPers : Form
    {
        public InfoPers()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
            LoadConcesionarioInfo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chat inicio = new Chat();
            inicio.Show();
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

        private void InfoPers_Load(object sender, EventArgs e)
        {

        }

        private void metroSetLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Actualizar();
        }
        private async void LoadConcesionarioInfo()
        {
            var user = UserSession.CurrentUser;
            if (user != null)
            {
                var conc = await MostrarInfoAsync(user.id_concesionario);
                UserSession.CurrentConc = conc;
                DisplayConcesionarioInfo(conc);
            }
            else
            {
                MessageBox.Show("No se pudo cargar la información del usuario.");
            }
        }

        private void DisplayConcesionarioInfo(InfoConc conc)
        {
            if (conc != null && !string.IsNullOrEmpty(conc.nombre))
            {
                metroSetTextBox1.Text = conc.nombre;
                metroSetTextBox2.Text = conc.direccion;
                metroSetTextBox4.Text = conc.telefono;
            }
            else
            {
                metroSetTextBox1.Text = "Información no disponible";
            }
        }
        private async Task Actualizar()
        {
            var conc = new InfoConc
            {
                id_concesionario = UserSession.CurrentConc.id_concesionario,
                nombre = metroSetTextBox1.Text,
                direccion = metroSetTextBox2.Text,
                id_provincia = UserSession.CurrentConc.id_provincia,
                telefono = metroSetTextBox4.Text
            };

            bool success = await ActualizarInfoAsync(conc);
            if (success)
            {
                MessageBox.Show("Información actualizada correctamente.");
            }
            else
            {
                MessageBox.Show("Error al actualizar la información.");
            }
        }
        public async Task<InfoConc> MostrarInfoAsync(int idConcesionario)
        {
            var baseUrl = $"http://20.90.95.76/mostrarInfo.php?id_concesionario={idConcesionario}";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<InfoConc>(jsonResponse);
                }
            }
            return null;
        }

        public async Task<bool> ActualizarInfoAsync(InfoConc conc)
        {
            var baseUrl = "http://20.90.95.76/actualizarInfo.php";
            using (var client = new HttpClient())
            {
                var jsonData = JsonConvert.SerializeObject(conc);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Dictionary<string, bool>>(jsonResponse);
                    return result["success"];
                }
            }
            return false;
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
