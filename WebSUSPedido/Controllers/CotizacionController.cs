using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebSUSPedido.Common;
using WebSUSPedido.Models;
using WebSUSPedido.Models.CotRequest;
using WebSUSPedido.Reports;

namespace WebSUSPedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : Controller
    {
        private
#nullable disable
    IWebHostEnvironment _oHostEnvironment;

        public CotizacionController(IWebHostEnvironment oHostEnvironment) => this._oHostEnvironment = oHostEnvironment;

        [HttpGet("{cdg_ven}")]
        public async Task<IActionResult> GetAll(string cdg_ven)
        {
            IEnumerable<CotizacionGet> cotizacionGets = (IEnumerable<CotizacionGet>)null;
            using (IDbConnection db = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("@CDG_VENDEDOR", (object)cdg_ven);
                string str = "GET_COT_VENDOR";
                IDbConnection cnn = db;
                string sql = str;
                DynamicParameters dynamicParameters2 = dynamicParameters1;
                CommandType? nullable = new CommandType?(CommandType.StoredProcedure);
                int? commandTimeout = new int?();
                CommandType? commandType = nullable;
                cotizacionGets = await cnn.QueryAsync<CotizacionGet>(sql, (object)dynamicParameters2, commandTimeout: commandTimeout, commandType: commandType);
            }
            return (IActionResult)new JsonResult((object)cotizacionGets);
        }

        [HttpPost("CreateCotizacion")]
        public IActionResult InsertCotizacion([FromBody] MCotizacion objDev)
        {
            using (IDbConnection cnn = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
            {
                cnn.Open();
                using (SqlTransaction sqlTransaction = (SqlTransaction)cnn.BeginTransaction())
                {
                    try
                    {
                        DynamicParameters dynamicParameters1 = new DynamicParameters();
                        dynamicParameters1.Add("@ID_COTIZACION", (object)objDev.ID_COTIZACION);
                        dynamicParameters1.Add("@CODIGO_VENDEDOR", (object)objDev.CODIGO_VENDEDOR);
                        dynamicParameters1.Add("@CODIGO_VENDEDOR_ASIGNADO", (object)objDev.CODIGO_VENDEDOR_ASIGNADO);
                        dynamicParameters1.Add("@CODIGO_CPAGO", (object)objDev.CODIGO_CPAGO);
                        dynamicParameters1.Add("@CODIGO_MONEDA", (object)objDev.CODIGO_MONEDA);
                        dynamicParameters1.Add("@NUMERO_OCLIENTE", (object)objDev.NUMERO_OCLIENTE);
                        dynamicParameters1.Add("@IMPORTE_STOT", (object)objDev.IMPORTE_STOT);
                        dynamicParameters1.Add("@IMPORTE_DESCUENTO", (object)objDev.IMPORTE_DESCUENTO);
                        dynamicParameters1.Add("@VALOR_VENTA", (object)objDev.VALOR_VENTA);
                        dynamicParameters1.Add("@IMPORTE_IGV", (object)objDev.IMPORTE_IGV);
                        dynamicParameters1.Add("@IMPORTE_TOTAL", (object)objDev.IMPORTE_TOTAL);
                        dynamicParameters1.Add("@PORCENTAJE_DESCUENTO", (object)objDev.PORCENTAJE_DESCUENTO);
                        dynamicParameters1.Add("@PORCENTAJE_IGV", (object)objDev.PORCENTAJE_IGV);
                        dynamicParameters1.Add("@OBSERVACION", (object)objDev.OBSERVACION);
                        dynamicParameters1.Add("@ID_CLIENTE", (object)objDev.ID_CLIENTE);
                        dynamicParameters1.Add("@ID_CLIENTE_FACTURA", (object)objDev.ID_CLIENTE_FACTURA);
                        dynamicParameters1.Add("@IMPORTE_ISC", (object)objDev.IMPORTE_ISC);
                        dynamicParameters1.Add("@CONTACTO", (object)' ');
                        dynamicParameters1.Add("@EMAIL_CONTACTO", (object)' ');
                        dynamicParameters1.Add("@CODIGO_EMPRESA", (object)objDev.CODIGO_EMPRESA);
                        dynamicParameters1.Add("@CODIGO_SUCURSAL", (object)objDev.CODIGO_SUCURSAL);
                        dynamicParameters1.Add("@TIPO_FECHA_ENTREGA", (object)'1');
                        dynamicParameters1.Add("@DIAS_ENTREGA", (object)'0');
                        dynamicParameters1.Add("@TIPO_ENTREGA", (object)'2');
                        dynamicParameters1.Add("@FECHA_ENTREGA", (object)objDev.FECHA_COTIZACION);
                        dynamicParameters1.Add("@LUGAR_ENTREGA", (object)' ');
                        dynamicParameters1.Add("@USUARIO", (object)objDev.USUARIO_CREACION);
                        dynamicParameters1.Add("@COMISION", (object)objDev.COMISION);
                        dynamicParameters1.Add("@REDONDEO", (object)objDev.REDONDEO);
                        dynamicParameters1.Add("@VALIDEZ", (object)objDev.VALIDEZ);
                        dynamicParameters1.Add("@MOTIVO", (object)objDev.MOTIVO);
                        dynamicParameters1.Add("@CORRELATIVO", (object)objDev.CORRELATIVO);
                        dynamicParameters1.Add("@CENTRO_COSTO", (object)objDev.CENTRO_COSTO);
                        dynamicParameters1.Add("@TIPO_CAMBIO", (object)objDev.TIPO_CAMBIO);
                        dynamicParameters1.Add("@NUMERO_COTIZACION", (object)objDev.NUMERO_COTIZACION);
                        dynamicParameters1.Add("@ID_COTIZACION_PARENT", (object)objDev.ID_COTIZACION_PARENT);
                        dynamicParameters1.Add("@VERSION", (object)'0');
                        dynamicParameters1.Add("@TIPO_OPERACION", (object)0);
                        dynamicParameters1.Add("@REF1");
                        dynamicParameters1.Add("@OBSERVACION");
                        dynamicParameters1.Add("@SUCURSAL");
                        dynamicParameters1.Add("@TIPO_COTI");
                        dynamicParameters1.Add("@DIAS_ENTREGA2", (object)0);
                        dynamicParameters1.Add("@TIPO_CLIENTE", (object)objDev.TIPO_CLIENTE);
                        dynamicParameters1.Add("@OBSERVACION2");
                        dynamicParameters1.Add("@FECHA_COTIZACION", (object)objDev.FECHA_COTIZACION);
                        int num = cnn.ExecuteScalar<int>("InsertCotizacionVenta", (object)dynamicParameters1, (IDbTransaction)sqlTransaction, commandType: new CommandType?(CommandType.StoredProcedure));
                        foreach (DCotizacion dcotizacion in objDev.DetCotizacion)
                        {
                            DynamicParameters dynamicParameters2 = new DynamicParameters();
                            dynamicParameters2.Add("@ID_COTIZACION", (object)num);
                            dynamicParameters2.Add("@ID_PRODUCTO", (object)dcotizacion.ID_PRODUCTO);
                            dynamicParameters2.Add("@CANTIDAD", (object)dcotizacion.CANTIDAD);
                            dynamicParameters2.Add("@PRECIO", (object)dcotizacion.PRECIO);
                            dynamicParameters2.Add("@DESCUENTO", (object)dcotizacion.DESCUENTO);
                            dynamicParameters2.Add("@IGV", (object)dcotizacion.IGV);
                            dynamicParameters2.Add("@IMPORTE", (object)dcotizacion.IMPORTE);
                            dynamicParameters2.Add("@OBSERVACION", (object)dcotizacion.OBSERVACION);
                            dynamicParameters2.Add("@SECUENCIA", (object)dcotizacion.SECUENCIA);
                            dynamicParameters2.Add("@PRECIO_ORIGINAL", (object)dcotizacion.PRECIO_ORIGINAL);
                            dynamicParameters2.Add("@TIPO", (object)dcotizacion.TIPO);
                            dynamicParameters2.Add("@IMPORTE_DSCTO", (object)dcotizacion.IMPORTE_DSCTO);
                            dynamicParameters2.Add("@AFECTO_IGV", (object)dcotizacion.AFECTO_IGV);
                            dynamicParameters2.Add("@COMISION", (object)dcotizacion.COMISION);
                            dynamicParameters2.Add("@ID_PRESUPUESTO", (object)dcotizacion.ID_PRESUPUESTO);
                            dynamicParameters2.Add("@CDG_SERV", (object)dcotizacion.CDG_SERV);
                            dynamicParameters2.Add("@OBSERVACION2", (object)dcotizacion.OBSERVACION2);
                            dynamicParameters2.Add("@UNIDAD", (object)dcotizacion.UNIDAD);
                            cnn.ExecuteScalar("InsertDetalleCotizacionVenta", (object)dynamicParameters2, (IDbTransaction)sqlTransaction, commandType: new CommandType?(CommandType.StoredProcedure));
                        }
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        throw;
                    }
                }
                return (IActionResult)this.Ok();
            }
        }


        [HttpPost("UpdateCotizacion")]
        public IActionResult UpdateCotizacion([FromBody] MCotizacion objDev)
        {
            using (IDbConnection cnn = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
            {
                cnn.Open();
                using (SqlTransaction sqlTransaction = (SqlTransaction)cnn.BeginTransaction())
                {
                    try
                    {
                        DynamicParameters dynamicParameters1 = new DynamicParameters();
                        dynamicParameters1.Add("@ID_COTIZACION", (object)objDev.ID_COTIZACION);
                        dynamicParameters1.Add("@CODIGO_VENDEDOR", (object)objDev.CODIGO_VENDEDOR);
                        dynamicParameters1.Add("@CODIGO_VENDEDOR_ASIGNADO", (object)objDev.CODIGO_VENDEDOR_ASIGNADO);
                        dynamicParameters1.Add("@CODIGO_CPAGO", (object)objDev.CODIGO_CPAGO);
                        dynamicParameters1.Add("@CODIGO_MONEDA", (object)objDev.CODIGO_MONEDA);
                        dynamicParameters1.Add("@NUMERO_OCLIENTE", (object)objDev.NUMERO_OCLIENTE);
                        dynamicParameters1.Add("@IMPORTE_STOT", (object)objDev.IMPORTE_STOT);
                        dynamicParameters1.Add("@IMPORTE_DESCUENTO", (object)objDev.IMPORTE_DESCUENTO);
                        dynamicParameters1.Add("@VALOR_VENTA", (object)objDev.VALOR_VENTA);
                        dynamicParameters1.Add("@IMPORTE_IGV", (object)objDev.IMPORTE_IGV);
                        dynamicParameters1.Add("@IMPORTE_TOTAL", (object)objDev.IMPORTE_TOTAL);
                        dynamicParameters1.Add("@PORCENTAJE_DESCUENTO", (object)objDev.PORCENTAJE_DESCUENTO);
                        dynamicParameters1.Add("@PORCENTAJE_IGV", (object)objDev.PORCENTAJE_IGV);
                        dynamicParameters1.Add("@OBSERVACION", (object)objDev.OBSERVACION);
                        dynamicParameters1.Add("@ID_CLIENTE", (object)objDev.ID_CLIENTE);
                        dynamicParameters1.Add("@ID_CLIENTE_FACTURA", (object)objDev.ID_CLIENTE_FACTURA);
                        dynamicParameters1.Add("@IMPORTE_ISC", (object)objDev.IMPORTE_ISC);
                        dynamicParameters1.Add("@CONTACTO", (object)' ');
                        dynamicParameters1.Add("@EMAIL_CONTACTO", (object)' ');
                        dynamicParameters1.Add("@CODIGO_EMPRESA", (object)objDev.CODIGO_EMPRESA);
                        dynamicParameters1.Add("@CODIGO_SUCURSAL", (object)objDev.CODIGO_SUCURSAL);
                        dynamicParameters1.Add("@TIPO_FECHA_ENTREGA", (object)'1');
                        dynamicParameters1.Add("@DIAS_ENTREGA", (object)'0');
                        dynamicParameters1.Add("@TIPO_ENTREGA", (object)'2');
                        dynamicParameters1.Add("@FECHA_ENTREGA", (object)objDev.FECHA_COTIZACION);
                        dynamicParameters1.Add("@LUGAR_ENTREGA", (object)' ');
                        dynamicParameters1.Add("@USUARIO", (object)objDev.USUARIO_CREACION);
                        dynamicParameters1.Add("@COMISION", (object)objDev.COMISION);
                        dynamicParameters1.Add("@REDONDEO", (object)objDev.REDONDEO);
                        dynamicParameters1.Add("@VALIDEZ", (object)objDev.VALIDEZ);
                        dynamicParameters1.Add("@MOTIVO", (object)objDev.MOTIVO);
                        dynamicParameters1.Add("@CORRELATIVO", (object)objDev.CORRELATIVO);
                        dynamicParameters1.Add("@CENTRO_COSTO", (object)objDev.CENTRO_COSTO);
                        dynamicParameters1.Add("@TIPO_CAMBIO", (object)objDev.TIPO_CAMBIO);
                        dynamicParameters1.Add("@NUMERO_COTIZACION", (object)objDev.NUMERO_COTIZACION);
                        dynamicParameters1.Add("@ID_COTIZACION_PARENT", (object)objDev.ID_COTIZACION_PARENT);
                        dynamicParameters1.Add("@VERSION", (object)'0');
                        dynamicParameters1.Add("@TIPO_OPERACION", (object)0);
                        dynamicParameters1.Add("@REF1");
                        dynamicParameters1.Add("@OBSERVACION");
                        dynamicParameters1.Add("@SUCURSAL");
                        dynamicParameters1.Add("@TIPO_COTI");
                        dynamicParameters1.Add("@DIAS_ENTREGA2", (object)0);
                        dynamicParameters1.Add("@DIAS_ENTREGA2", (object)0);
                        dynamicParameters1.Add("@TIPO_CLIENTE", (object)objDev.TIPO_CLIENTE);
                        dynamicParameters1.Add("@OBSERVACION2", (object)objDev.OBSERVACION2);
                        dynamicParameters1.Add("@FECHA_COTIZACION", (object)objDev.FECHA_COTIZACION);
                        int num = cnn.ExecuteScalar<int>("InsertCotizacionVenta", (object)dynamicParameters1, (IDbTransaction)sqlTransaction, commandType: new CommandType?(CommandType.StoredProcedure));
                        foreach (DCotizacion dcotizacion in objDev.DetCotizacion)
                        {
                            DynamicParameters dynamicParameters2 = new DynamicParameters();
                            dynamicParameters2.Add("@ID_COTIZACION", (object)objDev.ID_COTIZACION);
                            dynamicParameters2.Add("@ID_PRODUCTO", (object)dcotizacion.ID_PRODUCTO);
                            dynamicParameters2.Add("@CANTIDAD", (object)dcotizacion.CANTIDAD);
                            dynamicParameters2.Add("@PRECIO", (object)dcotizacion.PRECIO);
                            dynamicParameters2.Add("@DESCUENTO", (object)dcotizacion.DESCUENTO);
                            dynamicParameters2.Add("@IGV", (object)dcotizacion.IGV);
                            dynamicParameters2.Add("@IMPORTE", (object)dcotizacion.IMPORTE);
                            dynamicParameters2.Add("@OBSERVACION", (object)dcotizacion.OBSERVACION);
                            dynamicParameters2.Add("@SECUENCIA", (object)dcotizacion.SECUENCIA);
                            dynamicParameters2.Add("@PRECIO_ORIGINAL", (object)dcotizacion.PRECIO_ORIGINAL);
                            dynamicParameters2.Add("@TIPO", (object)dcotizacion.TIPO);
                            dynamicParameters2.Add("@IMPORTE_DSCTO", (object)dcotizacion.IMPORTE_DSCTO);
                            dynamicParameters2.Add("@AFECTO_IGV", (object)dcotizacion.AFECTO_IGV);
                            dynamicParameters2.Add("@COMISION", (object)dcotizacion.COMISION);
                            dynamicParameters2.Add("@ID_PRESUPUESTO", (object)dcotizacion.ID_PRESUPUESTO);
                            dynamicParameters2.Add("@CDG_SERV", (object)dcotizacion.CDG_SERV);
                            dynamicParameters2.Add("@OBSERVACION2", (object)dcotizacion.OBSERVACION2);
                            dynamicParameters2.Add("@UNIDAD", (object)dcotizacion.UNIDAD);
                            cnn.ExecuteScalar("InsertDetalleCotizacionVenta", (object)dynamicParameters2, (IDbTransaction)sqlTransaction, commandType: new CommandType?(CommandType.StoredProcedure));
                        }
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        throw;
                    }
                }
                return (IActionResult)this.Ok();
            }
        }

        [HttpGet("pdf/{id_Cotizacion}")]
        [Produces("application/pdf", new string[] { })]
        public async Task<IActionResult> PdfCotizacion(string id_Cotizacion)
        {
            CotizacionController cotizacionController = this;
            List<CotizacionV> pedido = new List<CotizacionV>();
            List<DCotizacionV> Detpedido = new List<DCotizacionV>();
            List<ImgHeadFoot> ImhdFT = new List<ImgHeadFoot>();
            using (IDbConnection dbConnection = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();
                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("@ID_COTIZACION", (object)id_Cotizacion);
                string str1 = "GetDataCotizacionID";
                string str2 = "GetDataCotiacionDetalleID";
                string str3 = "Get_imgHeadFoot";
                IDbConnection cnn1 = dbConnection;
                string sql1 = str1;
                DynamicParameters dynamicParameters2 = dynamicParameters1;
                CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
                int? commandTimeout1 = new int?();
                CommandType? commandType1 = nullable1;
                pedido = cnn1.Query<CotizacionV>(sql1, (object)dynamicParameters2, commandTimeout: commandTimeout1, commandType: commandType1).ToList<CotizacionV>();
                IDbConnection cnn2 = dbConnection;
                string sql2 = str2;
                DynamicParameters dynamicParameters3 = dynamicParameters1;
                CommandType? nullable2 = new CommandType?(CommandType.StoredProcedure);
                int? commandTimeout2 = new int?();
                CommandType? commandType2 = nullable2;
                Detpedido = cnn2.Query<DCotizacionV>(sql2, (object)dynamicParameters3, commandTimeout: commandTimeout2, commandType: commandType2).ToList<DCotizacionV>();
                IDbConnection cnn3 = dbConnection;
                string sql3 = str3;
                CommandType? nullable3 = new CommandType?(CommandType.StoredProcedure);
                int? commandTimeout3 = new int?();
                CommandType? commandType3 = nullable3;
                ImhdFT = cnn3.Query<ImgHeadFoot>(sql3, commandTimeout: commandTimeout3, commandType: commandType3).ToList<ImgHeadFoot>();
            }
            RCotizaciones rcotizaciones = new RCotizaciones();
            return (IActionResult)cotizacionController.File(rcotizaciones.Report(pedido, Detpedido, ImhdFT), "application/pdf");
        }

        [HttpGet("MS/{ID_COTIZACION}")]
        public async Task<IActionResult> GetCot(string ID_COTIZACION)
        {
            IEnumerable<MCotizacion> cotizacionVs = (IEnumerable<MCotizacion>)null;
            using (IDbConnection db = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("@ID_COTIZACION", (object)ID_COTIZACION);
                string str = "GET_COTIZACION_ID";
                IDbConnection cnn = db;
                string sql = str;
                DynamicParameters dynamicParameters2 = dynamicParameters1;
                CommandType? nullable = new CommandType?(CommandType.StoredProcedure);
                int? commandTimeout = new int?();
                CommandType? commandType = nullable;
                cotizacionVs = await cnn.QueryAsync<MCotizacion>(sql, (object)dynamicParameters2, commandTimeout: commandTimeout, commandType: commandType);
            }
            return (IActionResult)new JsonResult((object)cotizacionVs);
        }

        [HttpGet("DT/{ID_COTIZACION}")]
        public async Task<IActionResult> GetDCot(string ID_COTIZACION)
        {
            IEnumerable<DCotizacionV> dcotizacionVs = (IEnumerable<DCotizacionV>)null;
            using (IDbConnection db = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("@ID_COTIZACION", (object)ID_COTIZACION);
                string str = "GET_DETALLE_COTIZACION";
                IDbConnection cnn = db;
                string sql = str;
                DynamicParameters dynamicParameters2 = dynamicParameters1;
                CommandType? nullable = new CommandType?(CommandType.StoredProcedure);
                int? commandTimeout = new int?();
                CommandType? commandType = nullable;
                dcotizacionVs = await cnn.QueryAsync<DCotizacionV>(sql, (object)dynamicParameters2, commandTimeout: commandTimeout, commandType: commandType);
            }
            return (IActionResult)new JsonResult((object)dcotizacionVs);
        }


        [HttpDelete("Delete/{ID_COTIZACION}")]
        public async Task<IActionResult> DeleteCotizacion(string ID_COTIZACION)
        {
            using (IDbConnection db = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    DynamicParameters dynamicParameters1 = new DynamicParameters();
                    dynamicParameters1.Add("@ID_COTIZACION", (object)ID_COTIZACION);
                    string str = "DELETECOTIZACION";
                    IDbConnection cnn = db;
                    string sql = str;
                    DynamicParameters dynamicParameters2 = dynamicParameters1;
                    CommandType? nullable = new CommandType?(CommandType.StoredProcedure);
                    int? commandTimeout = new int?();
                    CommandType? commandType = nullable;
                    int num = cnn.ExecuteScalar<int>("DELETECOTIZACION", (object)dynamicParameters1, commandType: new CommandType?(CommandType.StoredProcedure));

                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            return (IActionResult)this.Ok();
        }
    }
}
