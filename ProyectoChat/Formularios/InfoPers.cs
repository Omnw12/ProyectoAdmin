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
            BBdd bbdd = new BBdd();
            var user = UserSession.CurrentUser;
            UserSession.CurrentConc = bbdd.MostrarInfo(user.id_concesionario);
            if (UserSession.CurrentConc != null && UserSession.CurrentConc.nombre != null)
            {
                metroSetTextBox1.Text = UserSession.CurrentConc.nombre;
                metroSetTextBox2.Text = UserSession.CurrentConc.direccion;
                metroSetTextBox4.Text = UserSession.CurrentConc.telefono;
            }
            else
            {
                metroSetTextBox1.Text = "Información no disponible";
                Console.WriteLine("No se pudo cargar la información del concesionario");
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            ActualizarAsync();
        }

        private async void ActualizarAsync()
        {
           
            var user = UserSession.CurrentUser;
            UserSession.CurrentConc = await MostrarInfoAsync(user.id_concesionario);
            InfoConc conc = new InfoConc();
            conc.id_concesionario = UserSession.CurrentConc.id_concesionario;
            conc.nombre = metroSetTextBox1.Text;
            conc.direccion = metroSetTextBox2.Text;
            conc.id_provincia = UserSession.CurrentConc.id_provincia;
            conc.telefono = metroSetTextBox4.Text;
            ActualizarInfoAsync(conc);
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
    }
}
