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
            HideAllFragments();
            fragment.Show();
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
    }
}
