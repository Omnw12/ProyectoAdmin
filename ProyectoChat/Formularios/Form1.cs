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

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text.Trim();
            String password = textBox2.Text.Trim();
            BBdd bbdd = new BBdd();
            var result = bbdd.SelectLogin(username, password);
            if (result != null)
            {
                UserSession.CurrentUser = result;
                Chat chat = new Chat();
                chat.Show();
                this.Hide();
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
    }
}
