using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.CotRequest
{
    public class DCotizacion
    {
        public Decimal? ID_COTIZACION { get; set; }

        public Decimal? ID_PRODUCTO { get; set; }

        public Decimal? CANTIDAD { get; set; }

        public Decimal? PRECIO { get; set; }

        public Decimal? DESCUENTO { get; set; }

        public Decimal? IGV { get; set; }

        public Decimal? IMPORTE { get; set; }

        public string? OBSERVACION { get; set; }

        public Decimal? SECUENCIA { get; set; }

        public Decimal? PRECIO_ORIGINAL { get; set; }

        public string? TIPO { get; set; }

        public Decimal? IMPORTE_DSCTO { get; set; }

        public string? AFECTO_IGV { get; set; }

        public Decimal? COMISION { get; set; }

        public Decimal? ID_PRESUPUESTO { get; set; }

        public string? CDG_SERV { get; set; }

        public byte[]? IMAGEN_REF { get; set; }

        public string? OBSERVACION2 { get; set; }

        public string? UNIDAD { get; set; }

        public Decimal? POR_PERCEPCION { get; set; }

        public Decimal? PERCEPCION { get; set; }

        public Decimal? VALOR_VEN { get; set; }

        public string? UNID_VEN { get; set; }

        public DateTime? FECHA_VEN { get; set; }

        public string? CDG_KIT { get; set; }

        public string? SWT_PIGV { get; set; }

        public Decimal? POR_DETRACCION { get; set; }

        public Decimal? DETRACCION { get; set; }

        public Decimal? FACTOR_CONVERSION { get; set; }

        public Decimal? MARGEN { get; set; }

        public Decimal? IMPORTE_MARGEN { get; set; }

        public Decimal? COSTO_ADIC { get; set; }

        public Decimal? CANT_KIT { get; set; }
    }
}
