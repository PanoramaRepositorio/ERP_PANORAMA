using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoMayoristasDL
    {
        public List<ReportePedidoMayoristasBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdRuta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoMayoristas");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pIdRuta", DbType.Int32, IdRuta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoMayoristasBE> Pedidolist = new List<ReportePedidoMayoristasBE>();
            ReportePedidoMayoristasBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoMayoristasBE();
                Pedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = decimal.Parse(reader["Total"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.IdRuta = int.Parse(reader["IdRuta"].ToString());
                Pedido.DescRuta = reader["DescRuta"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
