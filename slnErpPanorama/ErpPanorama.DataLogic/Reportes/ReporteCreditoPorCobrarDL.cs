using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCreditoPorCobrarDL
    {
        public List<ReporteCreditoPorCobrarBE> Listado()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptListaCreditoPorCobrar");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCreditoPorCobrarBE> ReporteCreditoPorCobrarlist = new List<ReporteCreditoPorCobrarBE>();
            ReporteCreditoPorCobrarBE ReporteCreditoPorCobrar;
            while (reader.Read())
            {
                ReporteCreditoPorCobrar = new ReporteCreditoPorCobrarBE();
                ReporteCreditoPorCobrar.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteCreditoPorCobrar.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteCreditoPorCobrar.DescCliente = reader["descCliente"].ToString();
                ReporteCreditoPorCobrar.DescRuta= reader["DescRuta"].ToString();
                ReporteCreditoPorCobrar.Importe = Decimal.Parse(reader["Importe"].ToString());
                ReporteCreditoPorCobrarlist.Add(ReporteCreditoPorCobrar);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCreditoPorCobrarlist;
        }
    }
}
