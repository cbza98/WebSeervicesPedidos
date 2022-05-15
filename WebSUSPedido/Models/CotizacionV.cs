using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models
{
    public class CotizacionV
    {
        public int ID_COTIZACION { get; set; }
        public DateTime FECHA_COTIZACION { get; set; }
        public string PERSONA { get; set; }
        public string RUC { get; set; }
        public string TELEFONO { get; set; }
        public string NUMERO_COTIZACION { get; set; }
        public string DIRECCION { get; set; }
        public string CODIGO_MONEDA { get; set; }
        public string NOM_MONEDA { get; set; }
        public string MON { get; set; }
        public double IMPORTE_STOT { get; set; }
        public double IMPORTE_DESCUENTO { get; set; }
        public double VALOR_VENTA { get; set; }
        public double IMPORTE_IGV { get; set; }
        public double IMPORTE_TOTAL { get; set; }
        public string ESTADO { get; set; }
        public string CODIGO_CPAGO { get; set; }
        public string LUGAR_ENTREGA { get; set; }
        public string CONDICION_PAGO { get; set; }
        public string CODIGO_VENDEDOR { get; set; }
        public string NUMERO_OCLIENTE { get; set; }
        public string ID_CLIENTE { get; set; }
        public string ID_CLIENTE_FACTURA { get; set; }
        public string EMAIL_CONTACTO { get; set; }
        public string CONTACTO { get; set; }
        public string USUARIO_MODIFICACION { get; set; }

    }
}
