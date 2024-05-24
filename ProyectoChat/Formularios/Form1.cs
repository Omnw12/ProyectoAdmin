using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoChat.Clases;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProyectoChat
{
    public partial class Form1 : Form
    {
        
        private Image showIcon = Image.FromFile("E:\\M7\\UF1-Practica4\\ProyectoChat\\ProyectoChat\\Icons\\show.png");
        private Image hideIcon = Image.FromFile("E:\\M7\\UF1-Practica4\\ProyectoChat\\ProyectoChat\\Icons\\hide.png");
        public Form1()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            textBox2.PasswordChar = '*';
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void metroSetButton1_ClickAsync(object sender, EventArgs e)
        {
            String username = textBox1.Text.Trim();
            String password = textBox2.Text.Trim();
            var result = await SelectLoginAsync(username, password);
            if (result != null)
            {
                MessageBox.Show("Sesión iniciada.");
                UserSession.CurrentUser = result;
                this.Hide();
                Chat chat = new Chat();
                chat.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0'; // Carácter nulo para mostrar texto
                button1.Image = showIcon; // Cambiar icono a "mostrar"
            }
            else
            {
                textBox2.PasswordChar = '*';
                button1.Image = hideIcon; // Cambiar icono a "ocultar"
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }
         
        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }
        public async Task<ClassAdmins> SelectLoginAsync(string username, string password)
        {
            var baseUrl = "http://20.90.95.76/selectLogin.php";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(baseUrl, new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                }));

                var jsonResponse = await response.Content.ReadAsStringAsync(); // Obtiene la respuesta como string
                Console.WriteLine("Response: " + jsonResponse); // Imprime la respuesta

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(jsonResponse);
                        if (loginResponse != null && loginResponse.Success)
                        {
                            return loginResponse.User;
                        }
                        else
                        {
                            Console.WriteLine("Login failed: " + loginResponse.Message);
                            return null;
                        }
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine("JSON Deserialization Error: " + ex.Message);
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("HTTP Error: " + response.StatusCode + " - " + response.ReasonPhrase);
                    return null;
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
