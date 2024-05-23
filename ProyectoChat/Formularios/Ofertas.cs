using MetroSet_UI.Controls;
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

namespace ProyectoChat
{
    public partial class Ofertas : Form
    {
        public Ofertas()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
            var user = UserSession.CurrentUser;
            BBdd bbdd = new BBdd();
            bbdd.MostrarPeticiones(dataGridView1);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

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
            this.Hide();
            Form1 inicio = new Form1();
            inicio.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BBdd bbdd = new BBdd();
            bbdd.BuscarCoche_id1(dataGridView1, metroSetTextBox1.Text);
        }

        private void Ofertas_Load(object sender, EventArgs e)
        {

        }


    }
}
