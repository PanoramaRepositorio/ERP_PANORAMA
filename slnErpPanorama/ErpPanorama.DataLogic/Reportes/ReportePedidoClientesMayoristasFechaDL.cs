using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoClientesMayoristasFechaDL
    {
        public List<ReportePedidoClientesMayoristasFechaBE> ListaPedidoClientesMayoristasFecha(DateTime FechaDesde, DateTime FechaHasta, int IdRuta, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoClientesMayoristasFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, IdRuta);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoClientesMayoristasFechaBE> Pedidolist = new List<ReportePedidoClientesMayoristasFechaBE>();
            ReportePedidoClientesMayoristasFechaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoClientesMayoristasFechaBE();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescRuta = reader["DescRuta"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
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
