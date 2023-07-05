using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCambioDL
    {
        public List<ReporteCambioBE> Listado(int IdCambio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCambios");
            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, IdCambio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCambioBE> Cambiolist = new List<ReporteCambioBE>();
            ReporteCambioBE Cambio;
            while (reader.Read())
            {
                Cambio = new ReporteCambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Cambio.RazonSocial = reader["RazonSocial"].ToString();
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.DescMotivo = reader["DescMotivo"].ToString();
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.NumeroNotaCredito = reader["NumeroNotaCredito"].ToString();
                Cambio.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Cambio.NombreProducto = reader["NombreProducto"].ToString();
                Cambio.Abreviatura = reader["Abreviatura"].ToString();
                Cambio.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Cambio.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Cambio.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                Cambio.ValorVentaSoles = Decimal.Parse(reader["ValorVentaSoles"].ToString());
                Cambio.ValorVentaDolares = Decimal.Parse(reader["ValorVentaDolares"].ToString());
                Cambio.TotalDolares = Decimal.Parse(reader["TotalDolares"].ToString());
                Cambio.ObservacionDetalle = reader["ObservacionDetalle"].ToString();
                Cambio.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                Cambio.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Cambio.FlagCumpleanios = Boolean.Parse(reader["FlagCumpleanios"].ToString());
                Cambio.TotalDscCumpleanios = Decimal.Parse(reader["TotalDscCumpleanios"].ToString());
                Cambiolist.Add(Cambio);
            }
            reader.Close();
            reader.Dispose();
            return Cambiolist;
        }

        public List<ReporteCambioBE> ConsolidadoListado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptConsolidadoCambios");
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCambioBE> Cambiolist = new List<ReporteCambioBE>();
            ReporteCambioBE Cambio;
            while (reader.Read())
            {
                Cambio = new ReporteCambioBE();
                Cambio.IdCambio = Int32.Parse(reader["IdCambio"].ToString());
                Cambio.RazonSocial = reader["RazonSocial"].ToString();
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.DescMotivo = reader["DescMotivo"].ToString();
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Cambio.NombreProducto = reader["NombreProducto"].ToString();
                Cambio.Abreviatura = reader["Abreviatura"].ToString();
                Cambio.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Cambio.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Cambiolist.Add(Cambio);
            }
            reader.Close();
            reader.Dispose();
            return Cambiolist;
        }
    }
}
