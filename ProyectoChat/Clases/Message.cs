using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoChat.Clases
{
    public class Message
    {
        public string Text { get; set; }
        public string Sender { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
