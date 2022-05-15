using Dapper;
using Microsoft.AspNetCore.Authorization;
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
  
    public class ProductoController : ControllerBase
    {
        #region GetProducts 

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("{cdg_lista}/{CDG_MONEDA}/{TIPO_CAMBIO}")]
        public IActionResult GetProducts(string cdg_lista, string CDG_MONEDA, string TIPO_CAMBIO)
        {
            IEnumerable<Productos> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {

                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@CDG_LISTA", cdg_lista);
                    cmd.Add("@CDG_MONEDA", CDG_MONEDA);
                    cmd.Add("@TIPO_CAMBIO", TIPO_CAMBIO);
                    var procedure = "GetDataProductoVta";

                    listado = db.Query<Productos>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region GetProductbyId

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("id/{id_product}")]
        public IActionResult GetProductbyId(int id_product)
        {
            IEnumerable<Productos> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {

                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@ID_PRODUCTO", id_product);
                    var procedure = "GetDataProductoID";

                    listado = db.Query<Productos>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
    }
}
