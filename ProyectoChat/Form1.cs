using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoChat
{
    public partial class Form1 : Form
    {
        
        private Image showIcon = Image.FromFile("E:\\M7\\UF1-Practica4\\ProyectoChat\\ProyectoChat\\Icons\\show.png");
        private Image hideIcon = Image.FromFile("E:\\M7\\UF1-Practica4\\ProyectoChat\\ProyectoChat\\Icons\\hide.png");
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
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
            Chat chat = new Chat(); 
            chat.Show();
            this.Hide();
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
    }
}
