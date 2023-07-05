using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoCreditoDL
    {
        public List<ReportePedidoCreditoBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoCredito");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoCreditoBE> ReportePedidoCreditolist = new List<ReportePedidoCreditoBE>();
            ReportePedidoCreditoBE ReportePedidoCredito;
            while (reader.Read())
            {
                ReportePedidoCredito = new ReportePedidoCreditoBE();
                ReportePedidoCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReportePedidoCredito.DescCliente = reader["descCliente"].ToString();
                ReportePedidoCredito.Total = Decimal.Parse(reader["Total"].ToString());
                ReportePedidoCreditolist.Add(ReportePedidoCredito);
            }
            reader.Close();
            reader.Dispose();
            return ReportePedidoCreditolist;
        }
    }
}
