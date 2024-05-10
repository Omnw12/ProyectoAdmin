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
using ProyectoChat.Formularios;

namespace ProyectoChat
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
            var user = UserSession.CurrentUser;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void lblfecha_Click(object sender, EventArgs e)
        {

        }


        private void lblhora_Click_1(object sender, EventArgs e)
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
    }
}
