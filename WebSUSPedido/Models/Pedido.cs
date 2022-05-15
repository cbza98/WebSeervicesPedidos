using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models
{
    public class Pedido
    {
        public int Id_pedido { get; set; }
        public string Numero_Pedido { get; set; }
        public DateTime Fecha_pedido { get; set; }
        public string Persona { get; set; }
        public string Ruc { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Lugar_entrega { get; set; }
        public string Mon { get; set; }
        public double Importe_descuento { get; set; }
        public double Valor_venta { get; set; }
        public string Nom_moneda { get; set; }
        public double Importe_igv { get; set; }
        public double Importe_Total { get; set; }
        public string Estado { get; set; }
      
    }
}
