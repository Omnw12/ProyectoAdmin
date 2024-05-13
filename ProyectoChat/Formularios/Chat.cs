using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ofertas inicio = new Ofertas();
            inicio.Show();
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
                pictureBox2.Image = new System.Drawing.Bitmap(openFileDialog.FileName);
            }
        }
    }
}
