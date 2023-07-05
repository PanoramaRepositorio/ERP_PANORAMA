using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoPreventaDetalleDL
    {
        public List<ReportePedidoPreventaDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoPreventaDetalle");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoPreventaDetalleBE> Pedidolist = new List<ReportePedidoPreventaDetalleBE>();
            ReportePedidoPreventaDetalleBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoPreventaDetalleBE();

                Pedido.NombreProducto = reader["NombreProducto"].ToString();
                Pedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Pedido.PrecioAB = decimal.Parse(reader["PrecioAB"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
