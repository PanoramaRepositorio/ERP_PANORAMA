using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDis_ContratoFabricacionDL
    {
        public List<ReporteDis_ContratoFabricacionBE> Listado(int IdDis_ContratoFabricacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDis_ContratoFabricacion");
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, IdDis_ContratoFabricacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDis_ContratoFabricacionBE> lista = new List<ReporteDis_ContratoFabricacionBE>();
            ReporteDis_ContratoFabricacionBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteDis_ContratoFabricacionBE();
                reporte.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                reporte.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                reporte.Numero = reader["Numero"].ToString();
                reporte.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                reporte.NumeroDocumento = reader["NumeroDocumento"].ToString();
                reporte.DescCliente = reader["DescCliente"].ToString();
                reporte.Direccion = reader["Direccion"].ToString();
                reporte.Referencia = reader["Referencia"].ToString();
                reporte.Email = reader["Email"].ToString();
                reporte.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                reporte.DescVendedor = reader["DescVendedor"].ToString();
                reporte.FechaEntrega = DateTime.Parse(reader["FechaEntrega"].ToString());
                reporte.IdProyecto = Int32.Parse(reader["IdProyecto"].ToString());
                reporte.IdDis_ContratoFabricacionDetalle = Int32.Parse(reader["IdDis_ContratoFabricacionDetalle"].ToString());
                reporte.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                reporte.Email = reader["Email"].ToString();
                reporte.NombreProducto = reader["NombreProducto"].ToString();
                reporte.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                reporte.Modelo = reader["Modelo"].ToString();
                reporte.Medida = reader["Medida"].ToString();
                reporte.Material = reader["Material"].ToString();
                reporte.Precio = Decimal.Parse(reader["Precio"].ToString());
                reporte.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
