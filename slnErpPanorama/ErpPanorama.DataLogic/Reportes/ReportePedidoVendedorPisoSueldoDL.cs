using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorPisoSueldoDL
    {
        public List<ReportePedidoVendedorPisoSueldoBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorPisoSueldo");
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorPisoSueldoBE> Cotizacionlist = new List<ReportePedidoVendedorPisoSueldoBE>();
            ReportePedidoVendedorPisoSueldoBE Cotizacion;
            while (reader.Read())
            {
                Cotizacion = new ReportePedidoVendedorPisoSueldoBE();
                Cotizacion.DescVendedor = reader["DescVendedor"].ToString();
                Cotizacion.DescCargo = reader["DescCargo"].ToString();
                Cotizacion.DescTienda = reader["DescTienda"].ToString();
                Cotizacion.TotalClienteFinal = Decimal.Parse(reader["TotalClienteFinal"].ToString());
                Cotizacion.TotalClienteMayorista = Decimal.Parse(reader["TotalClienteMayorista"].ToString());
                Cotizacion.TotalClienteDiseno = Decimal.Parse(reader["TotalClienteDiseno"].ToString());
                Cotizacion.TotalClienteFinalSinIGV = Decimal.Parse(reader["TotalClienteFinalSinIGV"].ToString());
                Cotizacion.TotalClienteMayoristaSinIGV = Decimal.Parse(reader["TotalClienteMayoristaSinIGV"].ToString());
                Cotizacion.TotalClienteDisenoSinIGV = Decimal.Parse(reader["TotalClienteDisenoSinIGV"].ToString());
                Cotizacion.TotalVenta = Decimal.Parse(reader["TotalVenta"].ToString());
                Cotizacion.Basico = Decimal.Parse(reader["Basico"].ToString());
                Cotizacion.CantidadCliente = Int32.Parse(reader["CantidadCliente"].ToString());
                Cotizacion.ComisionCliente = Decimal.Parse(reader["ComisionCliente"].ToString());
                Cotizacion.ComisionFinal = Decimal.Parse(reader["ComisionFinal"].ToString());
                Cotizacion.ComisionMayorista = Decimal.Parse(reader["ComisionMayorista"].ToString());
                Cotizacion.ComisionDiseno = Decimal.Parse(reader["ComisionDiseno"].ToString());
                Cotizacion.Meta = Decimal.Parse(reader["Meta"].ToString());
                Cotizacion.MetaTienda = Decimal.Parse(reader["MetaTienda"].ToString());
                Cotizacion.AlcanceMeta = Decimal.Parse(reader["AlcanceMeta"].ToString());
                Cotizacion.AlcanceMetaTienda = Decimal.Parse(reader["AlcanceMetaTienda"].ToString());
                Cotizacion.MetaConversion = Decimal.Parse(reader["MetaConversion"].ToString());
                Cotizacion.Conversion = Decimal.Parse(reader["Conversion"].ToString());
                Cotizacion.BonoConversion = Decimal.Parse(reader["BonoConversion"].ToString());
                Cotizacion.BonoMetaTienda = Decimal.Parse(reader["BonoMetaTienda"].ToString());
                Cotizacion.FlaCobro = Boolean.Parse(reader["FlaCobro"].ToString());
                Cotizacion.DetalleCobro = reader["DetalleCobro"].ToString();
                Cotizacion.BonoItem = Decimal.Parse(reader["BonoItem"].ToString());
                Cotizacion.ComisionFinalDM = Decimal.Parse(reader["ComisionFinalDM"].ToString());
                Cotizacion.ComisionMayoristaDM = Decimal.Parse(reader["ComisionMayoristaDM"].ToString());
                Cotizacion.ComisionFinalDM5 = Decimal.Parse(reader["ComisionFinalDM5"].ToString());
                Cotizacion.ComisionMayoristaDM5 = Decimal.Parse(reader["ComisionMayoristaDM5"].ToString());
                Cotizacion.ComisionAsesoria = Decimal.Parse(reader["ComisionAsesoria"].ToString());
                Cotizacion.DiaAlcanceMeta = reader["DiaAlcanceMeta"].ToString();
                Cotizacion.DiaAlcanceMetaTienda = reader["DiaAlcanceMetaTienda"].ToString();
                Cotizacion.DescuentoFalta = Decimal.Parse(reader["DescuentoFalta"].ToString());
                Cotizacion.DescuentoTardanza = Decimal.Parse(reader["DescuentoTardanza"].ToString());
                Cotizacion.DescuentoReclamo = Decimal.Parse(reader["DescuentoReclamo"].ToString());
                Cotizacion.DescuentoMemo = Decimal.Parse(reader["DescuentoMemo"].ToString());
                Cotizacion.FlagIndisciplina = Boolean.Parse(reader["FlagIndisciplina"].ToString());
                Cotizacion.Faltas = Int32.Parse(reader["Faltas"].ToString());
                Cotizacion.Tardanzas = Int32.Parse(reader["Tardanzas"].ToString());
                Cotizacion.TotalSueldo = Decimal.Parse(reader["TotalSueldo"].ToString());
                Cotizacion.TotalSueldoNeto = Decimal.Parse(reader["TotalSueldoNeto"].ToString());
                Cotizacion.DiasIngreso = Int32.Parse(reader["DiasIngreso"].ToString());
                Cotizacionlist.Add(Cotizacion);
            }
            reader.Close();
            reader.Dispose();
            return Cotizacionlist;
        }
    }
}
