using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using ProyectoChat.Clases;
using ProyectoChat.Formularios;

namespace ProyectoChat
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
            var user = UserSession.CurrentUser;
            LoadImageFromUrl(user.photo);
        }
     
        private void metroSetPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock inicio = new Stock();
            inicio.Show();
        }

        private void lblhora_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChatUsuarios inicio = new ChatUsuarios();
            inicio.Show();
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            UserSession.CurrentUser = null;
            UserSession.CurrentConc = null;
            UserSession.CurrentStockVehiculos = null;
            this.Hide();
            Form1 inicio = new Form1();
            inicio.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            InfoPers inicio = new InfoPers();
            inicio.Show();
        }
        private void LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(imageUrl);
                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        pictureBox2.Image = Image.FromStream(stream);
                    }
                }
            }
            catch (WebException webEx)
            {
                // Esto capturará errores específicos de la red
                MessageBox.Show("Error al cargar la imagen desde la web: " + webEx.Message);
            }
            catch (Exception ex)
            {
                // Esto capturará cualquier otro tipo de error
                MessageBox.Show("Error general: " + ex.Message);
            }
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
                // Cargar y ajustar la imagen al PictureBox
                var originalImage = new Bitmap(openFileDialog.FileName);
                pictureBox2.Image = new Bitmap(originalImage, pictureBox2.Size);

                // Guardar la imagen temporalmente
                string tempPath = Path.Combine(Path.GetTempPath(), "tempImage.png");
                originalImage.Save(tempPath, System.Drawing.Imaging.ImageFormat.Png);

                // Subir la imagen al servidor y actualizar la base de datos
                UploadImageAndUpdateDatabase(tempPath);
            };
            
        }
        private async void UploadImageAndUpdateDatabase(string imagePath)
        {
            var user = UserSession.CurrentUser;
            int id_admin = user.id_admin;  // Obtén el ID del admin de la sesión actual

            var baseUrl = "http://20.90.95.76/actuImagen.php";
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(id_admin.ToString()), "id_admin");
                content.Add(new StreamContent(File.OpenRead(imagePath)), "imagen", "admin_" + id_admin + ".png");

                try
                {
                    var response = await client.PostAsync(baseUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                        if (result.ContainsKey("success"))
                        {
                            MessageBox.Show("La imagen se ha actualizado correctamente.");
                        }
                        else if (result.ContainsKey("error"))
                        {
                            MessageBox.Show("Error al actualizar la imagen: " + result["error"]);
                        }
                        else
                        {
                            MessageBox.Show("Respuesta inesperada del servidor.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al subir la imagen. Código de estado: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con el servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
