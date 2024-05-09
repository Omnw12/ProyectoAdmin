using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoChat.Clases
{
    public class StockVehiculos
    {
        public int id_offer { get; set; }
        public int id_concesionario { get; set; }
        public int id_modelo { get; set; }
        public string description { get; set; }
        public string fotos { get; set; }
        public int stock { get; set; }
    }
}
