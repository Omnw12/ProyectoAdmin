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
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            HideAllFragments();
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
        }
        private void HideAllFragments()
        {
            
            metroSetPanel1.Hide();
            
           
        }
        private void metroSetButton2_Click(object sender, EventArgs e)
        {

        }
        private void ShowFragment(Control fragment)
        {
            // Oculta todos los fragmentos y luego muestra el fragmento dado
            ToggleFragment(fragment);
        }
        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            ShowFragment(metroSetPanel1);
        }

        private void metroSetPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroSetButton3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarFormularioEnPanel(new Ofertas());
        }
        private void CargarFormularioEnPanel(Form form)
        {
            // Asegura que el panel esté limpio antes de cargar un nuevo formulario.
            metroSetPanel2.Controls.Clear();
            metroSetPanel2.Visible = true;
            lblfecha.Visible = false;
            lblhora.Visible = false;
            form.TopLevel = false; // Importante para que el formulario no actúe como ventana independiente.
            form.FormBorderStyle = FormBorderStyle.None; // Elimina los bordes del formulario.
            form.Dock = DockStyle.Fill; // Hace que el formulario se acople y llene el panel.
            metroSetPanel2.Controls.Add(form); // Añade el formulario al panel.
            form.Show(); // Muestra el formulario.
        }
        private void ToggleFragment(Control fragment)
        {
            if (fragment.Visible)
            {
                fragment.Hide();
                metroSetPanel2.Visible = false;
                lblfecha.Visible = true;
                lblhora.Visible = true;
            }
            else
            {
                HideAllFragments(); // Asegúrate de que todos los otros fragmentos estén ocultos.
                fragment.Show();
                
            }
        }

        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarFormularioEnPanel(new Stock());
        }
    }
}
