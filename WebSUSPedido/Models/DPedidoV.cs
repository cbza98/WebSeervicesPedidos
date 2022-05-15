using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models
{
    public class DPedidoV
    {
		public Int64 ID_PEDIDO { get; set; }
		public Int64 ID_PRODUCTO { get; set; }
		public Int64 CANTIDAD { get; set; }

		public string CODIGO_BARRA { get; set; }
		public string NOMBRE { get; set; }
		public string UNIDAD { get; set; }
		public decimal PRECIO { get; set; }

		public decimal IMPORTE { get; set; }

		public decimal IGV { get; set; }
		public Int64 SECUENCIA { get; set; }


	}
}
