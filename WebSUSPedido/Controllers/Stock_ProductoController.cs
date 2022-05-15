using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebSUSPedido.Common;
using WebSUSPedido.Models;

namespace WebSUSPedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stock_ProductoController : ControllerBase
    {
        #region GetAlls Detalle_Pedidos

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("stock/{cod_prod}")]
        public IActionResult GetDetail(string cod_prod)
        {
            IEnumerable<Stoc_Producto> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {
                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@CODPROD", cod_prod);
                    var procedure = "GetCurrentStock";

                    listado = db.Query<Stoc_Producto>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }





            return new JsonResult(listado);

        }

        #endregion
    }
}
