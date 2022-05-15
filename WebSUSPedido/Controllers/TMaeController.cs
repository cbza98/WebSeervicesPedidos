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
   
    public class TMaeController : ControllerBase
    {
        #region GetAlls Clients

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("{cod_tabla}")]
        public IActionResult GetMaestro(string cod_tabla)
        {
            IEnumerable<T_Maestro> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {

                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@CODIGO", cod_tabla);
                    var procedure = "GetDataMaestro";

                    listado = db.Query<T_Maestro>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region GetTipoCambio

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("/TC")]
        public IActionResult GetTipoCambio()
        {
            IEnumerable<Tipo_Cambio> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {

                    DynamicParameters cmd = new DynamicParameters();
                    var procedure = "TIPO_CAMBIO_COMERCIAL";

                    listado = db.Query<Tipo_Cambio>(procedure, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region GetListaPrecio

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("/LSTPrecio")]
        public IActionResult GetListaPrecio()
        {
            IEnumerable<Lista_Precio> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {

                    DynamicParameters cmd = new DynamicParameters();
                    var procedure = "GetDataListaPrecio";

                    listado = db.Query<Lista_Precio>(procedure, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region GetAlls Provincia

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("{cod_tabla}/{cdg_depa}")]
        public IActionResult GetProvincia(string cod_tabla, string cdg_depa)
        {
            IEnumerable<T_Maestro> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {

                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@CODIGO", cod_tabla);
                    cmd.Add("@CODIGO_DEPA", cdg_depa);
                    var procedure = "GetDataMaestro_Provincia";

                    listado = db.Query<T_Maestro>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region GetAlls Distrito

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("{cod_tabla}/{cdg_Depa}/{cdg_provincia}")]
        public IActionResult GetDistrito(string cod_tabla,string cdg_Depa, string cdg_provincia)
        {
            IEnumerable<T_Maestro> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {

                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@CODIGO", cod_tabla);
                    cmd.Add("@CODIGO_DEPA", cdg_Depa);
                    cmd.Add("@CODIGO_PROVINCIA", cdg_provincia);
                    var procedure = "GetDataMaestro_distrito";

                    listado = db.Query<T_Maestro>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
    }
}
