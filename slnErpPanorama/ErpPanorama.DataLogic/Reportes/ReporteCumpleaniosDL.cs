using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCumpleaniosDL
    {
        public List<ReporteCumpleaniosBE> Listado(int Mes, bool FlagApoyo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Personal_ListaCumpleanios");
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pFlagApoyo", DbType.Boolean, FlagApoyo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCumpleaniosBE> lista = new List<ReporteCumpleaniosBE>();
            ReporteCumpleaniosBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteCumpleaniosBE();
                reporte.RazonSocial = reader["razonSocial"].ToString();
                reporte.ApeNom = reader["ApeNom"].ToString();
                reporte.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
