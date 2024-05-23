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

namespace ProyectoChat.Formularios
{
    public partial class Modelos : Form
    {
        public Modelos()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            BBdd bbdd = new BBdd();
            bbdd.MostrarModelsFull(dataGridView1);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BBdd bbdd = new BBdd();
            bbdd.BuscarModelo(dataGridView1, metroSetTextBox1.Text);
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
    }
}
