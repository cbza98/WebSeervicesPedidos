using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.Login
{
    public class AuthenticateResponse
    {
        
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string CODIGO_EMPRESA { get; set; }
        public string REFERENCIA3 { get; set; }
        public string JwtToken { get; set; }
        
        public string RefreshToken { get; set; }

        public AuthenticateResponse(OPE_USUARIO user, string jwtToken, string refreshToken)
        {
 
            NOMBRE = user.NOMBRE;
            CODIGO = user.CODIGO;
            CODIGO_EMPRESA = user.CODIGO_EMPRESA;
            REFERENCIA3 = user.REFERENCIA3;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
            
        }
    }
}