using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorAsesoriaDL
    {
        public List<ReportePedidoVendedorAsesoriaBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorAsesorDiseno");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorAsesoriaBE> Pedidolist = new List<ReportePedidoVendedorAsesoriaBE>();
            ReportePedidoVendedorAsesoriaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorAsesoriaBE();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescCargo = reader["DescCargo"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TotalClienteFinal = decimal.Parse(reader["TotalClienteFinal"].ToString());
                Pedido.TotalClienteMayorista = decimal.Parse(reader["TotalClienteMayorista"].ToString());
                Pedido.TotalClienteDiseno = decimal.Parse(reader["TotalClienteDiseno"].ToString());
                Pedido.TotalClienteFinalSinIGV = decimal.Parse(reader["TotalClienteFinalSinIGV"].ToString());
                Pedido.TotalClienteMayoristaSinIGV = decimal.Parse(reader["TotalClienteMayoristaSinIGV"].ToString());
                Pedido.TotalClienteDisenoSinIGV = decimal.Parse(reader["TotalClienteDisenoSinIGV"].ToString());
                Pedido.TotalProyectoFactura = decimal.Parse(reader["TotalProyectoFactura"].ToString());
                Pedido.TotalProyectoFacturaSinIGV = decimal.Parse(reader["TotalProyectoFacturaSinIGV"].ToString());
                Pedido.TotalVenta = decimal.Parse(reader["TotalVenta"].ToString());
                Pedido.Basico = decimal.Parse(reader["Basico"].ToString());
                Pedido.CantidadCliente = Int32.Parse(reader["CantidadCliente"].ToString());
                Pedido.ComisionCliente = decimal.Parse(reader["ComisionCliente"].ToString());
                Pedido.ComisionFinal = decimal.Parse(reader["ComisionFinal"].ToString());
                Pedido.ComisionMayorista = decimal.Parse(reader["ComisionMayorista"].ToString());
                Pedido.ComisionDiseno = decimal.Parse(reader["ComisionDiseno"].ToString());
                Pedido.ComisionExtra = decimal.Parse(reader["ComisionExtra"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());
                Pedido.AlcanceMeta = decimal.Parse(reader["AlcanceMeta"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());
                Pedido.BonoItem = decimal.Parse(reader["BonoItem"].ToString());
                Pedido.ComisionFinalDM = decimal.Parse(reader["ComisionFinalDM"].ToString());
                Pedido.ComisionMayoristaDM = decimal.Parse(reader["ComisionMayoristaDM"].ToString());
                Pedido.ComisionFinalDM5 = decimal.Parse(reader["ComisionFinalDM5"].ToString());
                Pedido.ComisionMayoristaDM5 = decimal.Parse(reader["ComisionMayoristaDM5"].ToString());
                Pedido.BonoProyectoFactura = decimal.Parse(reader["BonoProyectoFactura"].ToString());
                Pedido.BonoProyectoInstala = decimal.Parse(reader["BonoProyectoInstala"].ToString());
                Pedido.DescuentoFalta = decimal.Parse(reader["DescuentoFalta"].ToString());
                Pedido.DescuentoTardanza = decimal.Parse(reader["DescuentoTardanza"].ToString());
                Pedido.DescuentoReclamo = decimal.Parse(reader["DescuentoReclamo"].ToString());
                Pedido.DescuentoMemo = decimal.Parse(reader["DescuentoMemo"].ToString());
                Pedido.FlagIndisciplina = Boolean.Parse(reader["FlagIndisciplina"].ToString());
                Pedido.SueldoBruto = decimal.Parse(reader["SueldoBruto"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoVendedorAsesoriaBE> ListadoDetalle(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorAsesorDisenoDetalle");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorAsesoriaBE> Pedidolist = new List<ReportePedidoVendedorAsesoriaBE>();
            ReportePedidoVendedorAsesoriaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorAsesoriaBE();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescCargo = reader["DescCargo"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                //Pedido.Intermediacion = decimal.Parse(reader["Intermediacion"].ToString());
                //Pedido.VenFabConVendedor = decimal.Parse(reader["VenFabConVendedor"].ToString());
                //Pedido.VenFabSinVendedor = decimal.Parse(reader["VenFabSinVendedor"].ToString());
                //Pedido.ProyConVendedor = decimal.Parse(reader["ProyConVendedor"].ToString());
                //Pedido.ProySinVendedor = decimal.Parse(reader["ProySinVendedor"].ToString());
                //Pedido.VentaTienda = decimal.Parse(reader["VentaTienda"].ToString());
                //Pedido.VentaTiendaCP = decimal.Parse(reader["VentaTiendaCP"].ToString());
                //Pedido.CanRegCliente = Int32.Parse(reader["CanRegCliente"].ToString());
                //Pedido.VentaIncentivado = decimal.Parse(reader["VentaIncentivado"].ToString());
                //Pedido.Meta = decimal.Parse(reader["Meta"].ToString());
                //Pedido.Total = decimal.Parse(reader["Total"].ToString());
                //Pedido.TotalNotaCre = decimal.Parse(reader["TotalNotaCre"].ToString());
                //Pedido.AlcanceMeta = decimal.Parse(reader["AlcanceMeta"].ToString());
                //Pedido.SueldoBasico = decimal.Parse(reader["SueldoBasico"].ToString());
                //Pedido.ComIntermediacion = decimal.Parse(reader["ComIntermediacion"].ToString());
                //Pedido.ComVenFabConVendedor = decimal.Parse(reader["ComVenFabConVendedor"].ToString());
                //Pedido.ComVenFabSinVendedor = decimal.Parse(reader["ComVenFabSinVendedor"].ToString());
                //Pedido.ComProyConVendedor = decimal.Parse(reader["ComProyConVendedor"].ToString());
                //Pedido.ComProySinVendedor = decimal.Parse(reader["ComProySinVendedor"].ToString());
                //Pedido.ComVentaTienda = decimal.Parse(reader["ComVentaTienda"].ToString());
                //Pedido.ComVentaTiendaCP = decimal.Parse(reader["ComVentaTiendaCP"].ToString());
                //Pedido.ComCanRegCliente = decimal.Parse(reader["ComCanRegCliente"].ToString());
                //Pedido.ComVentaIncentivado = decimal.Parse(reader["ComVentaIncentivado"].ToString());
                //Pedido.ComAlcanceMeta = decimal.Parse(reader["ComAlcanceMeta"].ToString());
                //Pedido.ComTotal = decimal.Parse(reader["ComTotal"].ToString());
                //Pedido.SueldoBruto = decimal.Parse(reader["SueldoBruto"].ToString());
                //Pedido.Participacion = decimal.Parse(reader["Participacion"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
