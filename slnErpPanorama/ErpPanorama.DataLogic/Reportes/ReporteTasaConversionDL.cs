using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTasaConversionDL
    {
        public List<ReporteTasaConversionBE> Listado(DateTime FechaDesde,DateTime FechaHasta, int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTasaConversion");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTasaConversionBE> lista = new List<ReporteTasaConversionBE>();
            ReporteTasaConversionBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteTasaConversionBE();
                reporte.DiaSemana = reader["DiaSemana"].ToString();
                reporte.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                reporte.VisUcayali = Decimal.Parse(reader["VisUcayali"].ToString());
                reporte.VisAndahuaylas = Decimal.Parse(reader["VisAndahuaylas"].ToString());
                reporte.VisPrescott = Decimal.Parse(reader["VisPrescott"].ToString());
                reporte.VisAviacion = Decimal.Parse(reader["VisAviacion"].ToString());
                reporte.VisAviacion2 = Decimal.Parse(reader["VisAviacion2"].ToString());
                reporte.VisMegaplaza = Decimal.Parse(reader["VisMegaplaza"].ToString());
                reporte.VisSanMiguel = Decimal.Parse(reader["VisSanMiguel"].ToString());

                reporte.TraUcayali = Decimal.Parse(reader["TraUcayali"].ToString());
                reporte.TraAndahuaylas = Decimal.Parse(reader["TraAndahuaylas"].ToString());
                reporte.TraPrescott = Decimal.Parse(reader["TraPrescott"].ToString());
                reporte.TraAviacion = Decimal.Parse(reader["TraAviacion"].ToString());
                reporte.TraAviacion2 = Decimal.Parse(reader["TraAviacion2"].ToString());
                reporte.TraMegaplaza = Decimal.Parse(reader["TraMegaplaza"].ToString());
                reporte.TraSanMiguel = Decimal.Parse(reader["TraSanMiguel"].ToString());

                reporte.TasUcayali = Decimal.Parse(reader["TasUcayali"].ToString());
                reporte.TasAndahuaylas = Decimal.Parse(reader["TasAndahuaylas"].ToString());
                reporte.TasPrescott = Decimal.Parse(reader["TasPrescott"].ToString());
                reporte.TasAviacion = Decimal.Parse(reader["TasAviacion"].ToString());
                reporte.TasAviacion2 = Decimal.Parse(reader["TasAviacion2"].ToString());
                reporte.TasMegaplaza = Decimal.Parse(reader["TasMegaplaza"].ToString());
                reporte.TasSanMiguel = Decimal.Parse(reader["TasSanMiguel"].ToString());

                reporte.TotUcayali = Decimal.Parse(reader["TotUcayali"].ToString());
                reporte.TotAndahuaylas = Decimal.Parse(reader["TotAndahuaylas"].ToString());
                reporte.TotPrescott = Decimal.Parse(reader["TotPrescott"].ToString());
                reporte.TotAviacion = Decimal.Parse(reader["TotAviacion"].ToString());
                reporte.TotAviacion2 = Decimal.Parse(reader["TotAviacion2"].ToString());
                reporte.TotMegaplaza = Decimal.Parse(reader["TotMegaplaza"].ToString());
                reporte.TotSanMiguel = Decimal.Parse(reader["TotSanMiguel"].ToString());

                reporte.ProUcayali = Decimal.Parse(reader["ProUcayali"].ToString());
                reporte.ProAndahuaylas = Decimal.Parse(reader["ProAndahuaylas"].ToString());
                reporte.ProPrescott = Decimal.Parse(reader["ProPrescott"].ToString());
                reporte.ProAviacion = Decimal.Parse(reader["ProAviacion"].ToString());
                reporte.ProAviacion2 = Decimal.Parse(reader["ProAviacion2"].ToString());
                reporte.ProMegaplaza = Decimal.Parse(reader["ProMegaplaza"].ToString());
                reporte.ProSanMiguel = Decimal.Parse(reader["ProSanMiguel"].ToString());

                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
