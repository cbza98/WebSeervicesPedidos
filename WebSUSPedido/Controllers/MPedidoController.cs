using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebSUSPedido.Common;
using WebSUSPedido.Models;
using WebSUSPedido.Models.Pedidosend;
using SqlConnection = System.Data.SqlClient.SqlConnection;
using SqlTransaction = System.Data.SqlClient.SqlTransaction;

namespace WebSUSPedido.Controllers
{
	[Route("api/[controller]")]
	[ApiController]


	public class MPedidoController : ControllerBase
	{
		#region GetPedidoID
		[HttpGet("MS/{Id_pedido}")]
		public async Task<IActionResult> PedidoID(string Id_pedido)
		{
			IEnumerable<MPedido> cotizacionVs = (IEnumerable<MPedido>)null;
			using (IDbConnection db = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
			{
				if (db.State == ConnectionState.Closed)
					db.Open();
				DynamicParameters dynamicParameters1 = new DynamicParameters();
				dynamicParameters1.Add("@ID_PEDIDO", (object)Id_pedido);
				string str = "GET_PEDIDO_ID";
				IDbConnection cnn = db;
				string sql = str;
				DynamicParameters dynamicParameters2 = dynamicParameters1;
				CommandType? nullable = new CommandType?(CommandType.StoredProcedure);
				int? commandTimeout = new int?();
				CommandType? commandType = nullable;
				cotizacionVs = await cnn.QueryAsync<MPedido>(sql, (object)dynamicParameters2, commandTimeout: commandTimeout, commandType: commandType);
			}
			return (IActionResult)new JsonResult((object)cotizacionVs);
		}
		#endregion
		#region Get Detalle Pedido
		[HttpGet("DT/{Id_pedido}")]
		public async Task<IActionResult> GetDPed(string Id_pedido)
		{
			IEnumerable<DPedido> dcotizacionVs = (IEnumerable<DPedido>)null;
			using (IDbConnection db = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
			{
				if (db.State == ConnectionState.Closed)
					db.Open();
				DynamicParameters dynamicParameters1 = new DynamicParameters();
				dynamicParameters1.Add("@ID_PEDIDO", (object)Id_pedido);
				string str = "GET_DETALLE_PEDIDO_ID";
				IDbConnection cnn = db;
				string sql = str;
				DynamicParameters dynamicParameters2 = dynamicParameters1;
				CommandType? nullable = new CommandType?(CommandType.StoredProcedure);
				int? commandTimeout = new int?();
				CommandType? commandType = nullable;
				dcotizacionVs = await cnn.QueryAsync<DPedido>(sql, (object)dynamicParameters2, commandTimeout: commandTimeout, commandType: commandType);
			}
			return (IActionResult)new JsonResult((object)dcotizacionVs);
		}
		#endregion
		#region Creación de Pedido
		[HttpPost("CreateOrder")]
		public IActionResult InsertPedido([FromBody] MPedido objDev)
		{


			using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
			{
				//if (db.State == ConnectionState.Closed)
				db.Open();
				using (SqlTransaction sqlTransaction = (SqlTransaction)db.BeginTransaction())
				{
					try
					{
						DynamicParameters dynamicParameters1 = new DynamicParameters();
						dynamicParameters1.Add("@ID_PEDIDO", (object)objDev.ID_PEDIDO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@NUMERO_PEDIDO", (object)objDev.NUMERO_PEDIDO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_VENDEDOR", (object)objDev.CODIGO_VENDEDOR, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_CPAGO", (object)objDev.CODIGO_CPAGO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_MONEDA", (object)objDev.CODIGO_MONEDA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@FECHA_PEDIDO", (object)objDev.FECHA_PEDIDO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@NUMERO_OCLIENTE", (object)objDev.NUMERO_OCLIENTE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_STOT", (object)objDev.IMPORTE_STOT, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_IGV", (object)objDev.IMPORTE_IGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_DESCUENTO", (object)objDev.IMPORTE_DESCUENTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_TOTAL", (object)objDev.IMPORTE_TOTAL, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@PORCENTAJE_DESCUENTO", (object)objDev.PORCENTAJE_DESCUENTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@PORCENTAJE_IGV", (object)objDev.PORCENTAJE_IGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@OBSERVACION", (object)objDev.OBSERVACION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@ESTADO", (object)objDev.ESTADO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@ID_CLIENTE", (object)objDev.ID_CLIENTE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_ISC", (object)objDev.IMPORTE_ISC, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@VALOR_VENTA", (object)objDev.VALOR_VENTA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@ID_CLIENTE_FACTURA", (object)objDev.ID_CLIENTE_FACTURA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_VENDEDOR_ASIGNADO", (object)objDev.CODIGO_VENDEDOR_ASIGNADO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@FECHA_PROGRAMADA", (object)objDev.FECHA_PROGRAMADA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CONTACTO", (object)objDev.CONTACTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@EMAIL_CONTACTO", (object)objDev.EMAIL_CONTACTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@LUGAR_ENTREGA", (object)objDev.LUGAR_ENTREGA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@FACTURA_ADELANTADA", (object)objDev.FACTURA_ADELANTADA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@ID_COTIZACION", (object)objDev.ID_COTIZACION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_EMPRESA", (object)objDev.CODIGO_EMPRESA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_SUCURSAL", (object)objDev.CODIGO_SUCURSAL, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@USUARIO", (object)objDev.USUARIO_AUTORIZA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@COMISION", (object)objDev.COMISION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@PUNTO_VENTA", (object)objDev.PUNTO_VENTA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@REDONDEO", (object)objDev.REDONDEO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@VALIDEZ", (object)objDev.VALIDEZ, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@MOTIVO", (object)objDev.MOTIVO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CORRELATIVO", (object)objDev.CORRELATIVO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CENTRO_COSTO", (object)objDev.CENTRO_COSTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@TIPO_CAMBIO", (object)objDev.TIPO_CAMBIO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@SUCURSAL", (object)objDev.SUCURSAL, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@SERIE", (object)objDev.SERIE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						int num = db.ExecuteScalar<int>("InsertPedidoVenta", (object)dynamicParameters1, (IDbTransaction)sqlTransaction, new int?(), new CommandType?(CommandType.StoredProcedure));
						foreach (DPedido devolucionDetalle in objDev.DetDevolucion)
						{
							DynamicParameters dynamicParameters2 = new DynamicParameters();
							dynamicParameters2.Add("@ID_PRODUCTO", (object)devolucionDetalle.ID_PRODUCTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@ID_PEDIDO", (object)num, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@CANTIDAD", (object)devolucionDetalle.CANTIDAD, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@PRECIO", (object)devolucionDetalle.PRECIO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@DESCUENTO", (object)devolucionDetalle.DESCUENTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@IGV", (object)devolucionDetalle.IGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@IMPORTE", (object)devolucionDetalle.IMPORTE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@CANT_DESPACHADA", (object)devolucionDetalle.CANT_DESPACHADA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@CANT_FACTURADA", (object)devolucionDetalle.CANT_FACTURADA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@OBSERVACION", (object)devolucionDetalle.OBSERVACION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SECUENCIA", (object)devolucionDetalle.SECUENCIA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@PRECIO_ORIGINAL", (object)devolucionDetalle.PRECIO_ORIGINAL, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@TIPO", (object)devolucionDetalle.TIPO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@IMPORTE_DSCTO", (object)devolucionDetalle.IMPORTE_DSCTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@COMISION", (object)devolucionDetalle.COMISION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@AFECTO_IGV", (object)devolucionDetalle.AFECTO_IGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@ID_PRESUPUESTO", (object)devolucionDetalle.ID_PRESUPUESTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@UNIDAD", (object)devolucionDetalle.UNIDAD, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@FACTOR_CONVERSION", (object)devolucionDetalle.FACTOR_CONVERSION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_PIGV", (object)devolucionDetalle.SWT_PIGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_PROM", (object)devolucionDetalle.SWT_PROM, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@CANT_KIT", (object)devolucionDetalle.CANT_KIT, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_DCOM", (object)devolucionDetalle.SWT_DCOM, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_SABOR", (object)devolucionDetalle.SWT_SABOR, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_FREE", (object)devolucionDetalle.SWT_FREE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@POR_DETRACCION", (object)devolucionDetalle.POR_DETRACCION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@DETRACCION", (object)devolucionDetalle.DETRACCION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							db.ExecuteScalar("InsertDetallePedido", (object)dynamicParameters2, (IDbTransaction)sqlTransaction, new int?(), new CommandType?(CommandType.StoredProcedure));
						}

						sqlTransaction.Commit();
					}
					catch (Exception)
					{
						sqlTransaction.Rollback();
						throw;
					}
				}
				return Ok();
			}

		}
		#endregion
		#region UpdatePedido
		[HttpPost("UpdateOrder")]
		public IActionResult Updatepedido([FromBody] MPedido objDev)
		{


			using (IDbConnection db = new SqlConnection(Global.ConnectionStrings))
			{
				//if (db.State == ConnectionState.Closed)
				db.Open();
				using (SqlTransaction sqlTransaction = (SqlTransaction)db.BeginTransaction())
				{
					try
					{
						DynamicParameters dynamicParameters1 = new DynamicParameters();
						dynamicParameters1.Add("@ID_PEDIDO", (object)objDev.ID_PEDIDO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@NUMERO_PEDIDO", (object)objDev.NUMERO_PEDIDO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_VENDEDOR", (object)objDev.CODIGO_VENDEDOR, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_CPAGO", (object)objDev.CODIGO_CPAGO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_MONEDA", (object)objDev.CODIGO_MONEDA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@FECHA_PEDIDO", (object)objDev.FECHA_PEDIDO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@NUMERO_OCLIENTE", (object)objDev.NUMERO_OCLIENTE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_STOT", (object)objDev.IMPORTE_STOT, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_IGV", (object)objDev.IMPORTE_IGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_DESCUENTO", (object)objDev.IMPORTE_DESCUENTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_TOTAL", (object)objDev.IMPORTE_TOTAL, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@PORCENTAJE_DESCUENTO", (object)objDev.PORCENTAJE_DESCUENTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@PORCENTAJE_IGV", (object)objDev.PORCENTAJE_IGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@OBSERVACION", (object)objDev.OBSERVACION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@ESTADO", (object)objDev.ESTADO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@ID_CLIENTE", (object)objDev.ID_CLIENTE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@IMPORTE_ISC", (object)objDev.IMPORTE_ISC, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@VALOR_VENTA", (object)objDev.VALOR_VENTA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@ID_CLIENTE_FACTURA", (object)objDev.ID_CLIENTE_FACTURA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_VENDEDOR_ASIGNADO", (object)objDev.CODIGO_VENDEDOR_ASIGNADO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@FECHA_PROGRAMADA", (object)objDev.FECHA_PEDIDO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CONTACTO", (object)objDev.CONTACTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@EMAIL_CONTACTO", (object)objDev.EMAIL_CONTACTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@LUGAR_ENTREGA", (object)objDev.LUGAR_ENTREGA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@FACTURA_ADELANTADA", (object)objDev.FACTURA_ADELANTADA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@ID_COTIZACION", (object)objDev.ID_COTIZACION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_EMPRESA", (object)objDev.CODIGO_EMPRESA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CODIGO_SUCURSAL", (object)objDev.CODIGO_SUCURSAL, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@USUARIO", (object)objDev.USUARIO_AUTORIZA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@COMISION", (object)objDev.COMISION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@PUNTO_VENTA", (object)objDev.PUNTO_VENTA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@REDONDEO", (object)objDev.REDONDEO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@VALIDEZ", (object)objDev.VALIDEZ, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@MOTIVO", (object)objDev.MOTIVO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@CORRELATIVO", (object)objDev.CORRELATIVO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());						dynamicParameters1.Add("@CENTRO_COSTO", (object)objDev.CENTRO_COSTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@TIPO_CAMBIO", (object)objDev.TIPO_CAMBIO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@SUCURSAL", (object)objDev.SUCURSAL, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						dynamicParameters1.Add("@SERIE", (object)objDev.SERIE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
						int num = db.ExecuteScalar<int>("InsertPedidoVenta", (object)dynamicParameters1, (IDbTransaction)sqlTransaction, new int?(), new CommandType?(CommandType.StoredProcedure));
						foreach (DPedido devolucionDetalle in objDev.DetDevolucion)
						{
							DynamicParameters dynamicParameters2 = new DynamicParameters();
							dynamicParameters2.Add("@ID_PRODUCTO", (object)devolucionDetalle.ID_PRODUCTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@ID_PEDIDO", (object)objDev.ID_PEDIDO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@CANTIDAD", (object)devolucionDetalle.CANTIDAD, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@PRECIO", (object)devolucionDetalle.PRECIO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@DESCUENTO", (object)devolucionDetalle.DESCUENTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@IGV", (object)devolucionDetalle.IGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@IMPORTE", (object)devolucionDetalle.IMPORTE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@CANT_DESPACHADA", (object)devolucionDetalle.CANT_DESPACHADA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@CANT_FACTURADA", (object)devolucionDetalle.CANT_FACTURADA, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@OBSERVACION", (object)devolucionDetalle.OBSERVACION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SECUENCIA", (object)0, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@PRECIO_ORIGINAL", (object)devolucionDetalle.PRECIO_ORIGINAL, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@TIPO", (object)devolucionDetalle.TIPO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@IMPORTE_DSCTO", (object)devolucionDetalle.IMPORTE_DSCTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@COMISION", (object)devolucionDetalle.COMISION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@AFECTO_IGV", (object)devolucionDetalle.AFECTO_IGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@ID_PRESUPUESTO", (object)devolucionDetalle.ID_PRESUPUESTO, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@UNIDAD", (object)devolucionDetalle.UNIDAD, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@FACTOR_CONVERSION", (object)devolucionDetalle.FACTOR_CONVERSION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_PIGV", (object)devolucionDetalle.SWT_PIGV, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_PROM", (object)devolucionDetalle.SWT_PROM, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@CANT_KIT", (object)devolucionDetalle.CANT_KIT, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_DCOM", (object)devolucionDetalle.SWT_DCOM, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_SABOR", (object)devolucionDetalle.SWT_SABOR, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@SWT_FREE", (object)devolucionDetalle.SWT_FREE, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@POR_DETRACCION", (object)devolucionDetalle.POR_DETRACCION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							dynamicParameters2.Add("@DETRACCION", (object)devolucionDetalle.DETRACCION, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
							db.ExecuteScalar("InsertDetallePedido", (object)dynamicParameters2, (IDbTransaction)sqlTransaction, new int?(), new CommandType?(CommandType.StoredProcedure));
						}

						sqlTransaction.Commit();
					}
					catch (Exception)
					{
						sqlTransaction.Rollback();
						throw;
					}
				}
				return Ok();
			}

		}
		#endregion
		#region Delete
		[HttpDelete("Delete/{Id_pedido}")]
		public async Task<IActionResult> DeletePedido(string Id_pedido)
		{
			using (IDbConnection db = (IDbConnection)new SqlConnection(Global.ConnectionStrings))
			{
				try
				{
					if (db.State == ConnectionState.Closed)
						db.Open();
					DynamicParameters dynamicParameters1 = new DynamicParameters();
					dynamicParameters1.Add("@ID_PEDIDO", (object)Id_pedido);
					string str = "DELETE_PEDIDO_DETALLE";
					IDbConnection cnn = db;
					string sql = str;
					DynamicParameters dynamicParameters2 = dynamicParameters1;
					CommandType? nullable = new CommandType?(CommandType.StoredProcedure);
					int? commandTimeout = new int?();
					CommandType? commandType = nullable;
					int num = cnn.ExecuteScalar<int>("DELETE_PEDIDO_DETALLE", (object)dynamicParameters1, commandType: new CommandType?(CommandType.StoredProcedure));

				}
				catch (Exception)
				{

					throw;
				}

			}
			return (IActionResult)this.Ok();
		}

		#endregion
	}





}
