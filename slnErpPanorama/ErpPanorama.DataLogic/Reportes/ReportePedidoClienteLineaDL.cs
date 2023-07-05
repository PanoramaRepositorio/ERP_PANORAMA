using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoClienteLineaDL
    {
        public List<ReportePedidoClienteLineaBE> Listado(int Periodo, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoClienteLinea");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoClienteLineaBE> Pedidolist = new List<ReportePedidoClienteLineaBE>();
            ReportePedidoClienteLineaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoClienteLineaBE();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
        public List<ReportePedidoClienteLineaBE> ListadoModelo(int Periodo, int IdCliente, int IdLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoClienteModeloProducto");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoClienteLineaBE> Pedidolist = new List<ReportePedidoClienteLineaBE>();
            ReportePedidoClienteLineaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoClienteLineaBE();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.IdModeloProducto = Int32.Parse(reader["IdModeloProducto"].ToString());
                Pedido.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Pedido.TotalSolesM = Decimal.Parse(reader["TotalSolesM"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

    }
}
