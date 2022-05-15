using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models
{
    public class Cliente
    {
        public int Id_persona { get; set; }
        public string Ruc { get; set; }
        public string Persona { get; set; }
        public string Condicion_pago { get; set; }
        public string Tipo_cliente { get; set; }
        public string Vendedor { get; set; }
    }
}
