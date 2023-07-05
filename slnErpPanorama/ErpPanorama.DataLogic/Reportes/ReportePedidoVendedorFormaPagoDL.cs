using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorFormaPagoDL
    {
        public List<ReportePedidoVendedorFormaPagoBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorFormaPago");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorFormaPagoBE> Pedidolist = new List<ReportePedidoVendedorFormaPagoBE>();
            ReportePedidoVendedorFormaPagoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorFormaPagoBE();
                Pedido.Item = int.Parse(reader["Item"].ToString());
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.TipoVendedor = reader["TipoVendedor"].ToString();
                Pedido.TipoVenta = reader["TipoVenta"].ToString();
                Pedido.TipoCliente = reader["TipoCliente"].ToString();
                Pedido.Contado = decimal.Parse(reader["Contado"].ToString());
                Pedido.Credito = decimal.Parse(reader["Credito"].ToString());
                Pedido.Obsequio = decimal.Parse(reader["Obsequio"].ToString());
                Pedido.Consignacion = decimal.Parse(reader["Consignacion"].ToString());
                Pedido.Devolucion = decimal.Parse(reader["Devolucion"].ToString());
                Pedido.Separacion = decimal.Parse(reader["Separacion"].ToString());
                Pedido.Copagan = decimal.Parse(reader["Copagan"].ToString());
                Pedido.Contraentrega = decimal.Parse(reader["Contraentrega"].ToString());
                Pedido.Asaf = decimal.Parse(reader["Asaf"].ToString());
                Pedido.Total = decimal.Parse(reader["Total"].ToString());
                 Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
