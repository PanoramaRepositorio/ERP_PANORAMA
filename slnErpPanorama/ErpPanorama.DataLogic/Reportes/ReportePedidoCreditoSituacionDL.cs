using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoCreditoSituacionDL
    {
        public List<ReportePedidoCreditoSituacionBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoCreditoSituacion");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoCreditoSituacionBE> Pedidolist = new List<ReportePedidoCreditoSituacionBE>();
            ReportePedidoCreditoSituacionBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoCreditoSituacionBE();
                Pedido.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["Total"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
