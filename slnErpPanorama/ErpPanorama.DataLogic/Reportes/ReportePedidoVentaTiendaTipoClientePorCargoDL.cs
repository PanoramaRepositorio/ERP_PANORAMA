using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVentaTiendaTipoClientePorCargoDL
    {
        public List<ReportePedidoVentaTiendaTipoClientePorCargoBE> Listado(Int32 IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVentaTiendaTipoClientePorCargo");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVentaTiendaTipoClientePorCargoBE> PedidoVentaTiendaTipoClientePorCargolist = new List<ReportePedidoVentaTiendaTipoClientePorCargoBE>();
            ReportePedidoVentaTiendaTipoClientePorCargoBE PedidoVentaTiendaTipoClientePorCargo;
            while (reader.Read())
            {
                PedidoVentaTiendaTipoClientePorCargo = new ReportePedidoVentaTiendaTipoClientePorCargoBE();
                PedidoVentaTiendaTipoClientePorCargo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.DescTienda = reader["DescTienda"].ToString();
                PedidoVentaTiendaTipoClientePorCargo.DescVendedor = reader["DescVendedor"].ToString();
                PedidoVentaTiendaTipoClientePorCargo.DescCargo = reader["DescCargo"].ToString();
                PedidoVentaTiendaTipoClientePorCargo.ClienteFinal = Decimal.Parse(reader["ClienteFinal"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.ClienteMayorista = Decimal.Parse(reader["ClienteMayorista"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.CantidadClienteFinal = Int32.Parse(reader["CantidadClienteFinal"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.CantidadClienteMayorista = Int32.Parse(reader["CantidadClienteMayorista"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.CuotaDiario = Decimal.Parse(reader["CuotaDiario"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.CuotaMensual = Decimal.Parse(reader["CuotaMensual"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.CantidadPorCargo = Int32.Parse(reader["CantidadPorCargo"].ToString());

                PedidoVentaTiendaTipoClientePorCargo.Porcentaje = Decimal.Parse(reader["Porcentaje"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.Total = Decimal.Parse(reader["Total"].ToString());
                PedidoVentaTiendaTipoClientePorCargo.Diferencia = Decimal.Parse(reader["Diferencia"].ToString());

                PedidoVentaTiendaTipoClientePorCargolist.Add(PedidoVentaTiendaTipoClientePorCargo);
            }
            reader.Close();
            reader.Dispose();
            return PedidoVentaTiendaTipoClientePorCargolist;
        }
    }
}
