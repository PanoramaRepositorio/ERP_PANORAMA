using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public  class ReporteDis_DisenoEsteticoDL
    {
        public List<ReporteDis_DisenoEsteticoBE> Listado(int IdDis_ProyectoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDis_DisenoEstetico");
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDis_DisenoEsteticoBE> lista = new List<ReporteDis_DisenoEsteticoBE>();
            ReporteDis_DisenoEsteticoBE reporte;
            while (reader.Read())
            {
                reporte = new ReporteDis_DisenoEsteticoBE();
                reporte.IdDis_DisenoEstetico = Int32.Parse(reader["IdDis_DisenoEstetico"].ToString());
                reporte.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                reporte.Objetivos = reader["Objetivos"].ToString();
                reporte.IdDis_Estilo = Int32.Parse(reader["IdDis_Estilo"].ToString());
                reporte.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                reporte.IdDis_Forma = Int32.Parse(reader["IdDis_Forma"].ToString());
                reporte.DescDis_Forma = reader["DescDis_Forma"].ToString();
                reporte.DescVolumen = reader["DescVolumen"].ToString();
                reporte.DescTextura = reader["DescTextura"].ToString();
                reporte.IdMaterial = Int32.Parse(reader["IdMaterial"].ToString());
                reporte.DescMaterial = reader["DescMaterial"].ToString();
                reporte.IdDis_TipoColor = Int32.Parse(reader["IdDis_TipoColor"].ToString());
                reporte.DescDis_TipoColor = reader["DescDis_TipoColor"].ToString();
                reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
