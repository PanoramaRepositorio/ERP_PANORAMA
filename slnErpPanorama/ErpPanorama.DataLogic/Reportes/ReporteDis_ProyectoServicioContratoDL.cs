using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDis_ProyectoServicioContratoDL
    {
        public List<ReporteDis_ProyectoServicioContratoBE> Listado(int IdDis_ProyectoServicio, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDis_ProyectoServicioContrato");
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDis_ProyectoServicioContratoBE> lista = new List<ReporteDis_ProyectoServicioContratoBE>();
            ReporteDis_ProyectoServicioContratoBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteDis_ProyectoServicioContratoBE();
                reporte.Periodo = Int32.Parse(reader["Periodo"].ToString());
                reporte.Numero = reader["Numero"].ToString();
                reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                reporte.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                reporte.NumeroDocumento = reader["NumeroDocumento"].ToString();
                reporte.DescCliente = reader["DescCliente"].ToString();
                reporte.Direccion = reader["Direccion"].ToString();
                reporte.DniAsesor = reader["DniAsesor"].ToString();
                reporte.DescAsesor = reader["DescAsesor"].ToString();
                reporte.DescMoneda = reader["DescMoneda"].ToString();
                reporte.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                reporte.Importe = Decimal.Parse(reader["Importe"].ToString());
                reporte.RutaArchivo = reader["RutaArchivo"].ToString();
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.DescAmbiente = reader["DescAmbiente"].ToString();
                reporte.Telefono = reader["Telefono"].ToString();
                reporte.DescSituacion = reader["DescSituacion"].ToString();

                reporte.FechaVisita = DateTime.Parse(reader["FechaVisita"].ToString());
                reporte.RazonSocial = reader["RazonSocial"].ToString();
                reporte.Descripcion = reader["Descripcion"].ToString();
                reporte.Titulo = reader["Titulo"].ToString();
                reporte.CuerpoSustantivo = reader["CuerpoSustantivo"].ToString();
                reporte.Procedimiento = reader["Procedimiento"].ToString();
                reporte.PlazoCosto = reader["PlazoCosto"].ToString();
                reporte.Publicidad = reader["Publicidad"].ToString();
                reporte.Version = reader["Version"].ToString();
                reporte.PagoAsesoria = Decimal.Parse(reader["PagoAsesoria"].ToString());

                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }

        public List<ReporteDis_ProyectoServicioContratoBE> ListadoContrato(int IdDis_ProyectoServicio, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDis_ProyectoServicioContratoFormato");
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDis_ProyectoServicioContratoBE> lista = new List<ReporteDis_ProyectoServicioContratoBE>();
            ReporteDis_ProyectoServicioContratoBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteDis_ProyectoServicioContratoBE();
                reporte.Periodo = Int32.Parse(reader["Periodo"].ToString());
                reporte.Numero = reader["Numero"].ToString();
                reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                reporte.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                reporte.NumeroDocumento = reader["NumeroDocumento"].ToString();
                reporte.DescCliente = reader["DescCliente"].ToString();
                reporte.Direccion = reader["Direccion"].ToString();
                reporte.DniAsesor = reader["DniAsesor"].ToString();
                reporte.DescAsesor = reader["DescAsesor"].ToString();
                reporte.DescMoneda = reader["DescMoneda"].ToString();
                reporte.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                reporte.Importe = Decimal.Parse(reader["Importe"].ToString());
                reporte.RutaArchivo = reader["RutaArchivo"].ToString();
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.DescAmbiente = reader["DescAmbiente"].ToString();
                reporte.Telefono = reader["Telefono"].ToString();
                reporte.DescSituacion = reader["DescSituacion"].ToString();

                reporte.FechaVisita = DateTime.Parse(reader["FechaVisita"].ToString());
                reporte.RazonSocial = reader["RazonSocial"].ToString();
                reporte.Descripcion = reader["Descripcion"].ToString();
                reporte.Titulo = reader["Titulo"].ToString();
                reporte.CuerpoSustantivo = reader["CuerpoSustantivo"].ToString();
                reporte.Procedimiento = reader["Procedimiento"].ToString();
                reporte.PlazoCosto = reader["PlazoCosto"].ToString();
                reporte.Publicidad = reader["Publicidad"].ToString();
                reporte.Version = reader["Version"].ToString();

                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
