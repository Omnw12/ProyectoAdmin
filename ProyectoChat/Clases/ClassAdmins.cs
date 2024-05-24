using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoChat
{
    public class ClassAdmins
    {
        public ClassAdmins()
        {
        }

        public int id_admin { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string photo { get; set; }
        public int id_concesionario { get; set; }


        // Método estático para deserializar desde JSON
    }
}
