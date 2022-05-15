using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public string Codigo { get; set; }
        public string Codigo_Barra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion_Extendida { get; set; }
        public string Afecto_Igv { get; set; }
        public string Tipo_Afec_Igv { get; set; }

    }
}
