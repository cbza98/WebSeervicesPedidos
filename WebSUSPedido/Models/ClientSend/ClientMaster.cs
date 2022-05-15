using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.ClientSend
{
    public class ClientMaster
    {
        public string CODIGO_EMPRESA { get; set; }
        public int ID_PERSONA { get; set; }
        public string CODIGO { get; set; }
        public string RUC { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string NOMBRE { get; set; }
        public string TELEFONO { get; set; }
        public string FAX { get; set; }
        public string DIRECCION { get; set; }
        public string EMAIL { get; set; }
        public string TIPO_PERSONA { get; set; }
        public string TIPO { get; set; }
        public string ESTADO { get; set; }
        public string CODIGO_SUCURSAL { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string TIPO_CLIENTE { get; set; }
        public string VENDEDOR { get; set; }
        public string CONDICION_PAGO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string PROVINCIA { get; set; }
        public string DISTRITO { get; set; }
        public string USUARIO { get; set; }
        public int ID_GENERADO { get; set; }
        public string Mensaje { get; set; }

    }
}
