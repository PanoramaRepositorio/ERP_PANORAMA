using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDis_DisenoFuncionalDL
    {
        public List<ReporteDis_DisenoFuncionalBE> Listado(int IdDis_ProyectoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDis_DisenoFuncional");
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDis_DisenoFuncionalBE> lista = new List<ReporteDis_DisenoFuncionalBE>();
            ReporteDis_DisenoFuncionalBE reporte;
            while (reader.Read())
            {
                reporte = new ReporteDis_DisenoFuncionalBE();
                reporte.IdDis_DisenoFuncional = Int32.Parse(reader["idDis_DisenoFuncional"].ToString());
                reporte.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                reporte.IdDis_Ambiente = Int32.Parse(reader["IdDis_Ambiente"].ToString());
                reporte.DescDis_Ambiente = reader["DescDis_Ambiente"].ToString();
                reporte.DescActividad = reader["DescActividad"].ToString();
                reporte.IdDis_Pieza = Int32.Parse(reader["IdDis_Pieza"].ToString());
                reporte.DescDis_Pieza = reader["DescDis_Pieza"].ToString();
                reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                reporte.IdMaterial = Int32.Parse(reader["IdMaterial"].ToString());
                reporte.DescMaterial = reader["DescMaterial"].ToString();
                reporte.IdDis_Estilo = Int32.Parse(reader["IdDis_Estilo"].ToString());
                reporte.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                reporte.IdDis_Forma = Int32.Parse(reader["IdDis_Forma"].ToString());
                reporte.DescDis_Forma = reader["DescDis_Forma"].ToString();
                reporte.DescVolumen = reader["DescVolumen"].ToString();
                reporte.DescTextura = reader["DescTextura"].ToString();
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
