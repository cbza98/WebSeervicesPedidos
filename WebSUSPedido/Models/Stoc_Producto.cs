using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models
{
    public class Stoc_Producto
    {
        public string ALMACEN { get; set; }
        public string DIRECCION_ALMACEN { get; set; }
        public string CODIGO { get; set; }
        public string CODIGO_BARRA { get; set; }
        public string NOMBRE { get; set; }
        public decimal STOCK_ACTUAL { get; set; }
        public string UNIDAD { get; set; }
    


    }
}
