using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDis_ProyectoServicioDL
    {
        public List<ReporteDis_ProyectoServicioBE> Listado(int Periodo, int IdDis_ProyectoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDis_ProyectoServicio");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDis_ProyectoServicioBE> lista = new List<ReporteDis_ProyectoServicioBE>();
            ReporteDis_ProyectoServicioBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteDis_ProyectoServicioBE();

                reporte.IdDis_ProyectoServicio = Int32.Parse(reader["idDis_ProyectoServicio"].ToString());
                reporte.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                reporte.Periodo = Int32.Parse(reader["Periodo"].ToString());
                reporte.Numero = reader["Numero"].ToString();
                reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                reporte.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                reporte.IdCliente = Convert.ToInt32(reader["IdCliente"].ToString());
                reporte.NumeroDocumento = reader["NumeroDocumento"].ToString();
                reporte.DescCliente = reader["DescCliente"].ToString();
                reporte.Direccion = reader["Direccion"].ToString();
                reporte.IdAsesor = Convert.ToInt32(reader["IdAsesor"].ToString());
                reporte.DescAsesor = reader["DescAsesor"].ToString();
                reporte.IdMoneda = Convert.ToInt32(reader["IdMoneda"].ToString());
                reporte.DescMoneda = reader["DescMoneda"].ToString();
                reporte.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                reporte.Importe = Decimal.Parse(reader["Importe"].ToString());
                reporte.RutaArchivo = reader["RutaArchivo"].ToString();
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.IdSituacion = Convert.ToInt32(reader["IdSituacion"].ToString());
                reporte.DescSituacion = reader["DescSituacion"].ToString();
                reporte.DescTipoCasa = reader["DescTipoCasa"].ToString();
                reporte.DescAmbiente = reader["DescAmbiente"].ToString();
                reporte.Objetivos = reader["Objetivos"].ToString();
                reporte.Iluminacion = reader["Iluminacion"].ToString();
                reporte.Acustica = reader["Acustica"].ToString();
                reporte.Area = reader["Area"].ToString();
                reporte.IdDis_Forma = Convert.ToInt32(reader["IdDis_Forma"].ToString());
                reporte.DescDis_Forma = reader["DescDis_Forma"].ToString();
                reporte.IdDis_Estilo = Convert.ToInt32(reader["IdDis_Estilo"].ToString());
                reporte.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
