using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
using WebSUSPedido.Models.Pedidosend;
using WebSUSPedido.Models.Request;
using WebSUSPedido.Reports;

namespace WebSUSPedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PedidoController : ControllerBase
    {
        private readonly IWebHostEnvironment _oHostEnvironment;
        public PedidoController(IWebHostEnvironment oHostEnvironment)
        {
            _oHostEnvironment = oHostEnvironment;
        }
        #region GetAlls Pedidos

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("{cdg_ven}")]
        public async Task<IActionResult> GetAll(string cdg_ven)
        {
            IEnumerable<Pedido> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {
                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@CDG_VENDEDOR", cdg_ven);
                    var procedure = "GetDataPedido";

                    listado = await db.QueryAsync<Pedido>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region Get Cant Pedidos

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("cantped/{CDG_VENDEDOR}")]
        public async Task<IActionResult> GetCantPed(string CDG_VENDEDOR)
        {
            IEnumerable<Request_Cant_Ped> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {
                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@CDG_VENDEDOR", CDG_VENDEDOR);
                    var procedure = "CANT_ORDEN_PEDIDO";

                    listado = await db.QueryAsync<Request_Cant_Ped>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region GetAlls Detalle_Pedidos

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("dt/{id_ped}")]
        public IActionResult GetDetail(string id_ped)
        {
            IEnumerable<Pedido> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {
                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@ID_PEDIDO", id_ped);
                    var procedure = "GetDataPedidoDetalleID";

                    listado = db.Query<Pedido>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region Get Pedido Maestro Cabecera

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("ms/{id_ped}")]
        public IActionResult GetPedido(string id_ped)
        {
            IEnumerable<Pedido> listado = null;
            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {
                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@ID_PEDIDO", id_ped);
                    var procedure = "GetDataPedidoID";

                    listado = db.Query<Pedido>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);

                }
            }

            return new JsonResult(listado);

        }

        #endregion
        #region Pdf Pedido

        //private string _connection = @"Data Source=DESKTOP-CKJNAHP;Initial Catalog=Test_Products;User ID=sa;Password=Qz0966lb";
        [HttpGet("pdf/{id_ped}")]
        [Produces(contentType: "application/pdf")]
        public async Task<IActionResult> PdfPedido(string id_ped)
        {
            List<Pedido> lstorder = new List<Pedido>();
            List<DPedidoV> lstorderp = new List<DPedidoV>();


            IEnumerable<Pedido> listado = null;
            IEnumerable<DPedidoV> listadop = null;

            using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed) db.Open();
                {
                    DynamicParameters cmd = new DynamicParameters();
                    cmd.Add("@ID_PEDIDO", id_ped);
                    var procedure = "GetDataPedidoID";
                    var procedure2 = "GetDataPedidoDetalleID";
                 
                    listado = db.Query<Pedido>(procedure, cmd, commandType: System.Data.CommandType.StoredProcedure);
                    lstorder = listado.ToList();
                    listadop = db.Query<DPedidoV>(procedure2, cmd, commandType: System.Data.CommandType.StoredProcedure);
                    lstorderp = listadop.ToList();
     
                }
            }
            RPedido orpt = new RPedido(_oHostEnvironment);
            return File(orpt.Report(lstorder, lstorderp), "application/pdf");
           

        }

        #endregion

    }
}
