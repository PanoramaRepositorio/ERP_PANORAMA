using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCreditoTotalDL
    {
        public List<ReporteCreditoTotalBE> Listado(int Periodo, int OrderByColumn, string OrderByType)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptListaCreditoTotal");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pOrderByColumn", DbType.Int32, OrderByColumn);
            db.AddInParameter(dbCommand, "pOrderByType", DbType.String, OrderByType);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCreditoTotalBE> ReporteCreditoTotallist = new List<ReporteCreditoTotalBE>();
            ReporteCreditoTotalBE ReporteCreditoTotal;
            while (reader.Read())
            {
                ReporteCreditoTotal = new ReporteCreditoTotalBE();
                ReporteCreditoTotal.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteCreditoTotal.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteCreditoTotal.DescCliente = reader["descCliente"].ToString();
                ReporteCreditoTotal.Importe = Decimal.Parse(reader["Importe"].ToString());
                ReporteCreditoTotallist.Add(ReporteCreditoTotal);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCreditoTotallist;
        }
    }
}
