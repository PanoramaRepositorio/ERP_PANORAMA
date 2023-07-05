using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDis_ContratoAsesoriaDL
    {
        public List<ReporteDis_ContratoAsesoriaBE> Listado(int IdDis_ContratoAsesoria)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDis_ContratoAsesoria");
            db.AddInParameter(dbCommand, "pIdDis_ContratoAsesoria", DbType.Int32, IdDis_ContratoAsesoria);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDis_ContratoAsesoriaBE> lista = new List<ReporteDis_ContratoAsesoriaBE>();
            ReporteDis_ContratoAsesoriaBE reporte;
            while (reader.Read())
            {
                reporte = new ReporteDis_ContratoAsesoriaBE();
                reporte.IdDis_ContratoAsesoria = Int32.Parse(reader["IdDis_ContratoAsesoria"].ToString());
                reporte.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                reporte.RazonSocial = reader["RazonSocial"].ToString();
                reporte.Descripcion = reader["Descripcion"].ToString();
                reporte.Titulo = reader["Titulo"].ToString();
                reporte.CuerpoSustantivo = reader["CuerpoSustantivo"].ToString();
                reporte.Procedimiento = reader["Procedimiento"].ToString();
                reporte.PlazoCosto = reader["PlazoCosto"].ToString();
                reporte.Publicidad = reader["Publicidad"].ToString();
                reporte.Version = reader["Version"].ToString();
                reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
