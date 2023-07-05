using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoMuestraDL
    {
        public List<ReportePedidoMuestraBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoMuestra");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoMuestraBE> Pedidolist = new List<ReportePedidoMuestraBE>();
            ReportePedidoMuestraBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoMuestraBE();
                Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Pedido.NombreProducto = reader["NombreProducto"].ToString();
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.Cantidad = int.Parse(reader["Cantidad"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
