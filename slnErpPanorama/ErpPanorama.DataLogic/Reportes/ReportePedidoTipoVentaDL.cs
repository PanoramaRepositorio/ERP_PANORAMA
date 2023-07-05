using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoTipoVentaDL
    {
        public List<ReportePedidoTipoVentaBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdTipoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTipoVenta");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pIdTipoVenta", DbType.Int32, IdTipoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTipoVentaBE> Pedidolist = new List<ReportePedidoTipoVentaBE>();
            ReportePedidoTipoVentaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTipoVentaBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoTipoVentaBE> ListadoDetalle(DateTime FechaDesde, DateTime FechaHasta, int IdTipoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTipoVentaDetalle");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pIdTipoVenta", DbType.Int32, IdTipoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTipoVentaBE> Pedidolist = new List<ReportePedidoTipoVentaBE>();
            ReportePedidoTipoVentaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTipoVentaBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.DescRuta = reader["DescRuta"].ToString();
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.FechaPedido = DateTime.Parse(reader["FechaPedido"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["Total"].ToString());
                Pedido.FechaFacturacion = DateTime.Parse(reader["FechaFacturacion"].ToString());
                Pedido.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.DescAsesor = reader["DescAsesor"].ToString();
                Pedido.Tienda = reader["Tienda"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoTipoVentaBE> ListadoEcommerce(DateTime FechaDesde, DateTime FechaHasta, int Detalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_ListadoVentasEcommerce");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pDetalle", DbType.Int32, Detalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTipoVentaBE> Pedidolist = new List<ReportePedidoTipoVentaBE>();
            ReportePedidoTipoVentaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTipoVentaBE();
                Pedido.Situacion = reader["Situacion"].ToString();
                Pedido.TotalVentas = decimal.Parse(reader["Total"].ToString());
                Pedido.Tickets = Int32.Parse(reader["Tickets"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

    }
}
