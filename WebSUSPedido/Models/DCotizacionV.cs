using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models
{
    public class DCotizacionV
    {
        public int ID_COTIZACION { get; set; }

        public int ID_PRODUCTO { get; set; }

        public string CODIGO { get; set; }

        public string CODIGO_BARRA { get; set; }

        public string NOMBRE { get; set; }

        public double CANTIDAD { get; set; }

        public string ID_UNIDAD { get; set; }

        public string UNIDAD { get; set; }

        public double PRECIO { get; set; }

        public double DESCUENTO { get; set; }

        public double IMPORTE { get; set; }

        public int SECUENCIA { get; set; }

        public double IGV { get; set; }

        public double PRECIO_ORIGINAL { get; set; }

        public string TIPO { get; set; }

        public string AFECTO_IGV { get; set; }

        public double IMPORTE_DSCTO { get; set; }

        public double COMISION { get; set; }

        public string SWT_PIGV { get; set; }

        public string NOM_UNIDAD { get; set; }
    }
}
