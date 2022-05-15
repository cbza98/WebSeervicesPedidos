using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebSUSPedido.Models.Login
{
    public class OPE_USUARIO
    {
       
        public string CODIGO_EMPRESA { get; set; }
        [Key]
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string SUPERUSUARIO { get; set; }
        public string ADMINISTRADOR { get; set; }
        public string CONTRASENA { get; set; }
        public string EMAIL { get; set; }
        public string ESTADO { get; set; }
        public string CAJERO { get; set; }
        public string REFERENCIA1 { get; set; }
        public string REFERENCIA2 { get; set; }
        public string REFERENCIA3 { get; set; }
        public string REFERENCIA4 { get; set; }
        public string REFERENCIA5 { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public string IMAGEN1 { get; set; }
        public string REFERENCIA6 { get; set; }
        public string REFERENCIA7 { get; set; }
        public string REFERENCIA8 { get; set; }
        public string REFERENCIA9 { get; set; }
        public string REFERENCIA10 { get; set; }
        public string REFERENCIA11 { get; set; }
        public string REFERENCIA12 { get; set; }
        public string REFERENCIA13 { get; set; }
        public string REFERENCIA14 { get; set; }
        public string REFERENCIA15 { get; set; }
        public string REFERENCIA16 { get; set; }
        public string REFERENCIA17 { get; set; }
        public string REFERENCIA18 { get; set; }
        public string REFERENCIA19 { get; set; }
        public string REFERENCIA20 { get; set; }
        public string REFERENCIA21 { get; set; }
        public string REFERENCIA22 { get; set; }
        public string REFERENCIA23 { get; set; }
        public string REFERENCIA24 { get; set; }
        public string REFERENCIA25 { get; set; }
        public string REFERENCIA26 { get; set; }
        public string REFERENCIA27 { get; set; }
        public string REFERENCIA28 { get; set; }
        public string REFERENCIA29 { get; set; }
        public string REFERENCIA30 { get; set; }
        public string REFERENCIA31 { get; set; }
        public string REFERENCIA32 { get; set; }
        public string REFERENCIA33 { get; set; }
        public string REFERENCIA34 { get; set; }

        public string TIPO_CAMBIO { get; set; }
        [JsonIgnore]
        public string REFERENCIA35 { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
