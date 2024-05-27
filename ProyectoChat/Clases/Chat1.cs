using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoChat.Clases
{
    public class Chat1
    {
        public Dictionary<string, bool> Participants { get; set; }
        public Dictionary<string, Message> Messages { get; set; }
    }
}
