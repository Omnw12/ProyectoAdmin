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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using static System.Net.WebRequestMethods;
using Message = ProyectoChat.Clases.Message;

namespace ProyectoChat
{
    public partial class ChatUsuarios : Form
    {
        private Image backIcon = Image.FromFile("E:\\M7\\UF1-Practica4\\ProyectoChat\\ProyectoChat\\Icons\\back.png");
        IFirebaseClient client;
        private string currentChatId;
        private Timer updateTimer;
        public ChatUsuarios()
        {
            InitializeComponent();
            InitializeFirebase();
            InitializeListView();
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
            var user = UserSession.CurrentUser;
            LoadChats();
            SetupUpdateTimer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }
        private void InitializeListView()
        {
            lstMessages.View = View.Details;
            lstMessages.Columns.Add("Messages", -2, HorizontalAlignment.Left);
            lstMessages.HeaderStyle = ColumnHeaderStyle.None;
            lstMessages.FullRowSelect = true;
        }
        private void ChatUsuarios_Load(object sender, EventArgs e)
        {

        }
        private void SetupUpdateTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 3000; // Actualiza cada 3 segundos
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chat inicio = new Chat();
            inicio.Show();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentChatId))
            {
                LoadMessagesForChat(currentChatId);
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            // Confirmar si el usuario realmente desea salir
            DialogResult result = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Cerrar toda la aplicación
                // o this.Close(); // Cerrar solo el formulario actual
            }
        }

        private void InitializeFirebase()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://prueba-chat-fb2f5-default-rtdb.europe-west1.firebasedatabase.app/"
            };
            client = new FireSharp.FirebaseClient(config);
        }
        private async void LoadChats()
        {
            int admin = UserSession.CurrentUser.id_admin;
            FirebaseResponse response = await client.GetAsync("chats/");
            var chats = response.ResultAs<Dictionary<string, Chat1>>();
            foreach (var chat in chats)
            {
                if (chat.Value.Participants.ContainsKey("admin" + admin))
                {
                    lstChats.Items.Add(chat.Key);
                }
            }
        }
        private async void LoadMessagesForChat(string chatId)
        {
            FirebaseResponse response = await client.GetAsync($"chats/{chatId}/messages/");
            var messages = response.ResultAs<Dictionary<string, Message>>();
            lstMessages.Items.Clear();
            foreach (var message in messages.Values)
            {
                AddMessageToUI(message);
            }
        }


        private void lstMessages_SelectedIndexChanged(object sender)
        {

        }

        private async void lstChats_SelectedIndexChanged(object sender)
        {
            string selectedChat = lstChats.SelectedItem.ToString();
            FirebaseResponse response = await client.GetAsync($"chats/{selectedChat}/messages/");
            var messages = response.ResultAs<Dictionary<string, Message>>();
            lstMessages.Items.Clear();
            foreach (var message in messages)
            {
                lstMessages.Items.Add($"{message.Value.Sender}: {message.Value.Text}");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            int admin = UserSession.CurrentUser.id_admin;
            if (!string.IsNullOrEmpty(txtMessage.Text) && lstChats.SelectedItem != null)
            {
                string chatId = lstChats.SelectedItem.ToString();
                var message = new Message
                {
                    Sender = "admin" + admin,
                    Text = txtMessage.Text,
                    Timestamp = DateTime.Now
                };

                await client.PushAsync($"chats/{chatId}/messages/", message);
                AddMessageToUI(message);
                txtMessage.Clear();
            }
            else
            {
                MessageBox.Show("No se puede enviar un mensaje vacío o no se seleccionó un chat.");
            }
        }
        private void AddMessageToUI(Message message)
        {
            // Solo usar el ID del admin como prefijo, sin "Tú: "
            int adminId = UserSession.CurrentUser.id_admin;
            string prefix = message.Sender == ("admin" + adminId) ? $"admin{adminId}: " : $"{message.Sender}: ";

            ListViewItem item = new ListViewItem(prefix + message.Text);
            lstMessages.Items.Add(item);
            item.EnsureVisible(); // Asegura que el nuevo ítem sea visible en el ListView
        }

    }
}