using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteVacacionesVendidasDL
    {
        public List<ReporteVacacionesVendidasBE> Listado(int IdVacaciones)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptVacacionesVendidas");
            db.AddInParameter(dbCommand, "pIdVacaciones", DbType.Int32, IdVacaciones);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteVacacionesVendidasBE> lista = new List<ReporteVacacionesVendidasBE>();
            ReporteVacacionesVendidasBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteVacacionesVendidasBE();
                reporte.Dni = reader["Dni"].ToString();
                reporte.ApeNom = reader["ApeNom"].ToString();
                reporte.DescArea = reader["DescArea"].ToString();
                reporte.DescCargo = reader["DescCargo"].ToString();
                reporte.Periodo = reader["Periodo"].ToString();
                reporte.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                reporte.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                reporte.Dias = Int32.Parse(reader["Dias"].ToString());
                reporte.DescMoneda = reader["DescMoneda"].ToString();
                reporte.Importe = Decimal.Parse( reader["Importe"].ToString());
                reporte.Autorizado = reader["Autorizado"].ToString();
                reporte.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                reporte.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                reporte.FlagGozo = Boolean.Parse(reader["FlagGozo"].ToString());
                reporte.FlagAdelantadas = Boolean.Parse(reader["FlagAdelantadas"].ToString());
                reporte.DescSituacion = reader["DescSituacion"].ToString();
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
