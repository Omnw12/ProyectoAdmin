using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoChat.Clases
{
    public static class UserSession
    {
        public static ClassAdmins CurrentUser { get; set; }
        public static InfoConc CurrentConc { get; set; }
        public static StockVehiculos CurrentStockVehiculos { get; set; }
    }
}
