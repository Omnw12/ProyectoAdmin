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
            BBdd bbdd = new BBdd();
            bbdd.MostrarStock(dataGridView1, user.id_concesionario.ToString());
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var user = UserSession.CurrentUser;
            BBdd bbdd = new BBdd();
            bbdd.BuscarCoche_id(dataGridView1, metroSetTextBox3.Text, user.id_concesionario.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var user = UserSession.CurrentUser;
            int id_concesionario = UserSession.CurrentUser.id_concesionario;
            String id_coche1 = metroSetTextBox4.Text;
            int id_coche = int.Parse(id_coche1);
            String description = metroSetTextBox1.Text;
            String stock1 = metroSetTextBox2.Text;
            int stock = int.Parse(stock1);
            StockVehiculos stock12 = new StockVehiculos
            {
                id_concesionario = id_concesionario,
                id_coche = id_coche,
                description = description,
                stock = stock
            };
            BBdd bbdd = new BBdd();
            bbdd.InsertStock(stock12);
            bbdd.MostrarStock(dataGridView1, user.id_concesionario.ToString());
            LimpiarTxt();
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
            String id_offer = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id_offer"].Value.ToString();
            int id_offer1 = Convert.ToInt32(id_offer);
            String id_coche1 = metroSetTextBox4.Text;
            int id_coche = int.Parse(id_coche1);
            String description = metroSetTextBox1.Text;
            String stock1 = metroSetTextBox2.Text;
            int stock = int.Parse(stock1);
            StockVehiculos stock12 = new StockVehiculos
            {
                id_offer = id_offer1,
                id_coche = id_coche,
                description = description,
                stock = stock
            };
            BBdd bbdd = new BBdd();
            bbdd.modifyStock(stock12);
            bbdd.MostrarStock(dataGridView1, user.id_concesionario.ToString());
            LimpiarTxt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var user = UserSession.CurrentUser;
                string id_offer = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id_offer"].Value.ToString();
                int id_offer1 = Convert.ToInt32(id_offer);
                BBdd bbdd = new BBdd();
                bbdd.eliminarStock(id_offer1);
                bbdd.MostrarStock(dataGridView1, user.id_concesionario.ToString());

            }
            else
            {
                MessageBox.Show("Selecciona una fila antes de intentar eliminar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
