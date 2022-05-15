using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.Login
{
    public class RevokeTokenRequest
    {
        public string Token { get; set; }
        public string TokenU { get; set; }
    }
}
