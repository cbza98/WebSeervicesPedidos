using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.CotRequest
{
    public class CotizacionGet
    {
        public int Id_cotizacion { get; set; }

        public string Numero_Cotizacion { get; set; }

        public DateTime Fecha_Cotizacion { get; set; }

        public string Persona { get; set; }

        public string Ruc { get; set; }

        public string Documento { get; set; }

        public string Mon { get; set; }

        public double Importe_descuento { get; set; }

        public double Importe_igv { get; set; }

        public double Importe_total { get; set; }

        public string Estado { get; set; }
    }
}
