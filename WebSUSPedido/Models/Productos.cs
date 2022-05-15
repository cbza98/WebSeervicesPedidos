using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models
{
    public class Productos
    {
        public int Id_Producto { get; set; }

        public string CODIGO { get; set; }
        public string Codigo_Barra { get; set; }
        public string Nombre { get; set; }
        public string Mon { get; set; }
        public double Precio_Venta { get; set; }
        public double Factor_Conversion { get; set; }
        public string Cdg_Unidad { get; set; }
        public string Unidad { get; set; }
        public string Moneda_Lp { get; set; }



    }
}
