using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDis_ProyectoServicioContratoFabricacionDL
    {
        public List<ReporteDis_ProyectoServicioContratoFabricacionBE> Listado(int IdDis_ContratoFabricacion, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("rptDis_ProyectoServicioContratoFabricacion");
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDis_ProyectoServicioContratoFabricacionBE> lista = new List<ReporteDis_ProyectoServicioContratoFabricacionBE>();
            ReporteDis_ProyectoServicioContratoFabricacionBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteDis_ProyectoServicioContratoFabricacionBE();
                reporte.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                reporte.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                reporte.Periodo = Int32.Parse(reader["Periodo"].ToString());
                reporte.Numero = reader["Numero"].ToString();
                reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                reporte.NumeroDocumento = reader["NumeroDocumento"].ToString();
                reporte.DescCliente = reader["DescCliente"].ToString();
                reporte.Direccion = reader["Direccion"].ToString();
                reporte.Referencia = reader["Referencia"].ToString();
                reporte.Email = reader["Email"].ToString();
                reporte.Telefono = reader["Telefono"].ToString();
                reporte.DniVendedor = reader["DniVendedor"].ToString();
                reporte.DescVendedor = reader["DescVendedor"].ToString();
                reporte.FechaEntrega = DateTime.Parse(reader["FechaEntrega"].ToString());
                reporte.NumeroProyecto = reader["NumeroProyecto"].ToString();

                reporte.RazonSocial = reader["RazonSocial"].ToString();
                reporte.Ruc = reader["Ruc"].ToString();
                reporte.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                reporte.NombreProducto = reader["NombreProducto"].ToString();
                reporte.Abreviatura = reader["Abreviatura"].ToString();
                reporte.Modelo = reader["Modelo"].ToString();
                reporte.Medida = reader["Medida"].ToString();
                reporte.Material = reader["Material"].ToString();
                reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                reporte.Precio = Decimal.Parse(reader["Precio"].ToString());
                reporte.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                reporte.Imagen = (byte[])reader["Imagen"];
                reporte.FlagModificado = Boolean.Parse(reader["FlagModificado"].ToString());
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                reporte.Tienda = reader["Tienda"].ToString();

                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
