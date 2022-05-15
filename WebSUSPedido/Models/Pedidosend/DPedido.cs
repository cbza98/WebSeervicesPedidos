using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.Pedidosend
{
    public class DPedido
    {
		public Int64 ID_PEDIDO { get; set; }
		public Int64 ID_PRODUCTO { get; set; }
		public decimal CANTIDAD { get; set; }
		public string Nombre { get; set; }
		public decimal PRECIO { get; set; }
		public decimal DESCUENTO { get; set; }
		public decimal IGV { get; set; }
		public decimal IMPORTE { get; set; }
		public decimal CANT_DESPACHADA { get; set; }
		public decimal CANT_FACTURADA { get; set; }
		public string OBSERVACION { get; set; }
		public Int64 SECUENCIA { get; set; }
		public decimal PRECIO_ORIGINAL { get; set; }
		public string TIPO { get; set; }
		public decimal? IMPORTE_DSCTO { get; set; }
		public string AFECTO_IGV { get; set; }
		public decimal COMISION { get; set; }
		public Int64 ID_PRESUPUESTO { get; set; }
		public string CDG_SERV { get; set; }
		public string FLAG_C { get; set; }
		public string FLAG_P { get; set; }
		public string FLAG_COLOR { get; set; }
		public string NOM_UNIDAD { get; set; }
		public string COMANDA { get; set; }
		public string MOZO { get; set; }
		public string UNIDAD { get; set; }
		public string CODIGO_BARRA { get; set; }
		public decimal? POR_PERCEPCION { get; set; }
		public decimal? PERCEPCION { get; set; }
		public decimal? VALOR_VEN { get; set; }
		public string UNID_VEN { get; set; }
		public DateTime? FECHA_VEN { get; set; }
		public decimal? FACTOR_CONVERSION { get; set; }
		public string CDG_KIT { get; set; }
		public string SWT_PIGV { get; set; }
		public string SWT_PROM { get; set; }
		public decimal? CANT_KIT { get; set; }
		public string SWT_DCOM { get; set; }
		public string SWT_SABOR { get; set; }
		public string SWT_FREE { get; set; }
		public string NOM_IMP { get; set; }
		public Int64? SEC_PROD { get; set; }
		public decimal? POR_DETRACCION { get; set; }
		public decimal? DETRACCION { get; set; }
		public string USUARIO_ANULA { get; set; }
		public DateTime? FECHA_ANULA { get; set; }
		public decimal? MARGEN { get; set; }
		public decimal? IMPORTE_MARGEN { get; set; }
		public decimal? COSTO_ADIC { get; set; }

	}
}
