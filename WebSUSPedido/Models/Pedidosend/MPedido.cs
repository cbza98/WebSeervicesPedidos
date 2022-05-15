using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.Pedidosend
{
    public class MPedido
    {
        public int ID_PEDIDO { get; set; }
        public string NUMERO_PEDIDO { get; set; }
        public string NOM_MON { get; set; }
        public string SMB_MON { get; set; }
        public string COND_PAGO { get; set; }
        public string PERSONA { get; set; }
        public string RUC { get; set; }
        public string FREC_DIAS { get; set; }
        public string CODIGO_VENDEDOR { get; set; }
        public string CODIGO_CPAGO { get; set; }
        public string CODIGO_MONEDA { get; set; }
        public DateTime FECHA_PEDIDO { get; set; }
        public string NUMERO_OCLIENTE { get; set; }
        public decimal IMPORTE_STOT { get; set; }
        public decimal IMPORTE_IGV { get; set; }
        public decimal IMPORTE_DESCUENTO { get; set; }
        public decimal IMPORTE_TOTAL { get; set; }
        public decimal PORCENTAJE_DESCUENTO { get; set; }
        public decimal PORCENTAJE_IGV { get; set; }
        public string OBSERVACION { get; set; }
        public string SERIE { get; set; }
        public string ESTADO { get; set; }
        public int ID_CLIENTE { get; set; }
        public decimal IMPORTE_ISC { get; set; }
        public string USUARIO_CREACION { get; set; }
        public string USUARIO_AUTORIZA { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public string CODIGO_EMPRESA { get; set; }
        public string CODIGO_SUCURSAL { get; set; }
        public decimal VALOR_VENTA { get; set; }
        public int ID_CLIENTE_FACTURA { get; set; }
        public string CODIGO_VENDEDOR_ASIGNADO { get; set; }
        public DateTime FECHA_PROGRAMADA { get; set; }
        public string FACTURA_ADELANTADA { get; set; }
        public string CONTACTO { get; set; }
        public string EMAIL_CONTACTO { get; set; }
        public string LUGAR_ENTREGA { get; set; }
        public int ID_COTIZACION { get; set; }
        public int COMISION { get; set; }
        public string PUNTO_VENTA { get; set; }
        public string REDONDEO { get; set; }
        public string VALIDEZ { get; set; }
        public string MOTIVO { get; set; }
        public string CORRELATIVO { get; set; }
        public string CENTRO_COSTO { get; set; }
        public decimal TIPO_CAMBIO { get; set; }
        public string SUCURSAL { get; set; }
        public List<DPedido> DetDevolucion { get; set; }
    }
}
