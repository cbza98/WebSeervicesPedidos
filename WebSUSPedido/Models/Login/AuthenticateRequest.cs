using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.Login
{
    public class AuthenticateRequest
    {
        [Required]
        public string CODIGO { get; set; }

        [Required]
        public string REFERENCIA35 { get; set; }
    }
}
