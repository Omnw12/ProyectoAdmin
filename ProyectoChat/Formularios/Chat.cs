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
            this.Hide();
            Form1 inicio = new Form1();
            inicio.Show();

        }
    }
}
