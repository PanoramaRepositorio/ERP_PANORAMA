using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoTiendaSupervisorDL
    {
        public List<ReportePedidoTiendaSupervisorBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaMetaSupervisor");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaSupervisorBE> Pedidolist = new List<ReportePedidoTiendaSupervisorBE>();
            ReportePedidoTiendaSupervisorBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaSupervisorBE();
                Pedido.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.CanRegCliente = int.Parse(reader["CanRegCliente"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());
                Pedido.TotalClienteFinal = decimal.Parse(reader["TotalClienteFinal"].ToString());
                Pedido.TotalClienteMayorista = decimal.Parse(reader["TotalClienteMayorista"].ToString());
                Pedido.TotalVentaSupervisor = decimal.Parse(reader["TotalVentaSupervisor"].ToString());
                Pedido.TotalVentaIncentivado = decimal.Parse(reader["TotalVentaIncentivado"].ToString());
                Pedido.TotalVenta = decimal.Parse(reader["TotalVenta"].ToString());
                Pedido.TotalVentaSinIGV = decimal.Parse(reader["TotalVentaSinIGV"].ToString());
                Pedido.PorMeta = decimal.Parse(reader["PorMeta"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());

                Pedido.TasaConversion = decimal.Parse(reader["TasaConversion"].ToString());
                Pedido.MetaConversion = decimal.Parse(reader["MetaConversion"].ToString());
                Pedido.PorConversion = decimal.Parse(reader["PorConversion"].ToString());
                Pedido.BonoConversion = decimal.Parse(reader["BonoConversion"].ToString());
                Pedido.Basico = decimal.Parse(reader["Basico"].ToString());
                Pedido.AlcanceMaster = decimal.Parse(reader["AlcanceMaster"].ToString());
                Pedido.AlcanceSenior = decimal.Parse(reader["AlcanceSenior"].ToString());
                Pedido.AlcanceJunior = decimal.Parse(reader["AlcanceJunior"].ToString());
                Pedido.ComisionMaster = decimal.Parse(reader["ComisionMaster"].ToString());
                Pedido.ComisionSenior = decimal.Parse(reader["ComisionSenior"].ToString());
                Pedido.ComisionSupervisor = decimal.Parse(reader["ComisionSupervisor"].ToString());
                Pedido.ComisionIncentivado = decimal.Parse(reader["ComisionIncentivado"].ToString());
                Pedido.RegCliSueldo = decimal.Parse(reader["RegCliSueldo"].ToString());
                Pedido.ComisionTotal = decimal.Parse(reader["ComisionTotal"].ToString());
                Pedido.Sueldo = decimal.Parse(reader["Sueldo"].ToString());
                Pedido.Faltas = int.Parse(reader["Faltas"].ToString());
                Pedido.Tardanzas = int.Parse(reader["Tardanzas"].ToString());
                Pedido.FlagIndisciplina = Boolean.Parse(reader["FlagIndisciplina"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
