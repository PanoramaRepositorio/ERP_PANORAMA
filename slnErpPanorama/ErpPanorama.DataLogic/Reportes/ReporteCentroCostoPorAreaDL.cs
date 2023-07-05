using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCentroCostoPorAreaDL
    {
        public List<ReporteCentroCostoPorAreaBE> Listado(int Periodo, int Mes, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Concar_rptCentroCostoPorArea");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.String, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCentroCostoPorAreaBE> Lista = new List<ReporteCentroCostoPorAreaBE>();
            ReporteCentroCostoPorAreaBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteCentroCostoPorAreaBE();

                Reporte.CodGrupo = reader["CodGrupo"].ToString();
                Reporte.DescGrupo = reader["DescGrupo"].ToString();
                Reporte.CodCentroCosto = reader["CodCentroCosto"].ToString();
                Reporte.DescCentroCosto = reader["DescCentroCosto"].ToString();
                Reporte.CodCuenta = reader["CodCuenta"].ToString();
                Reporte.DescCuenta = reader["DescCuenta"].ToString();
                Reporte.DebeUS = Decimal.Parse(reader["DebeUS"].ToString());
                Reporte.HaberUS = Decimal.Parse(reader["HaberUS"].ToString());
                Reporte.DebeMN = Decimal.Parse(reader["DebeMN"].ToString());
                Reporte.HaberMN = Decimal.Parse(reader["HaberMN"].ToString());
                Reporte.Mes = Int32.Parse(reader["Mes"].ToString());
                Reporte.NombreMes = reader["NombreMes"].ToString();
                Reporte.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
