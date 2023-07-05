using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoPreventaVendedorDL
    {
        public List<ReportePedidoPreVentaVendedorBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoPreventaVendedor");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoPreVentaVendedorBE> Pedidolist = new List<ReportePedidoPreVentaVendedorBE>();
            ReportePedidoPreVentaVendedorBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoPreVentaVendedorBE();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = decimal.Parse(reader["Total"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
