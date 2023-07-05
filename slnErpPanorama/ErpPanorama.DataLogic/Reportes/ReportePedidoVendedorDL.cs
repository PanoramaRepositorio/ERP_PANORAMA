using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorDL
    {
        public List<ReportePedidoVendedorBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdVendedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedor");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorBE> Pedidolist = new List<ReportePedidoVendedorBE>();
            ReportePedidoVendedorBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
