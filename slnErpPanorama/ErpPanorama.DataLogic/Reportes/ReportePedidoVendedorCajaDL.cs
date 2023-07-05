using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorCajaDL
    {
        public List<ReportePedidoVendedorCajaBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorCaja");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorCajaBE> Pedidolist = new List<ReportePedidoVendedorCajaBE>();
            ReportePedidoVendedorCajaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorCajaBE();
                Pedido.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.CanRegCliente = Int32.Parse(reader["CanRegCliente"].ToString());
                Pedido.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TotalVenta = decimal.Parse(reader["TotalVenta"].ToString());
                Pedido.TotalVentaSinIGV = decimal.Parse(reader["TotalVentaSinIGV"].ToString());
                Pedido.TotalRus = decimal.Parse(reader["TotalRus"].ToString());
                Pedido.TotalRusSinIGV = decimal.Parse(reader["TotalRusSinIGV"].ToString());
                Pedido.TotalRusOtros = decimal.Parse(reader["TotalRusOtros"].ToString());
                Pedido.TotalRusOtrosSinIGV = decimal.Parse(reader["TotalRusOtrosSinIGV"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());
                Pedido.AlcanceMeta = decimal.Parse(reader["AlcanceMeta"].ToString());
                Pedido.Basico = decimal.Parse(reader["Basico"].ToString());
                Pedido.ComisionRegCliente = decimal.Parse(reader["ComisionRegCliente"].ToString());
                Pedido.ComisionVenta = decimal.Parse(reader["ComisionVenta"].ToString());
                Pedido.ComisionRus = decimal.Parse(reader["ComisionRus"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());
                Pedido.Sueldo = decimal.Parse(reader["Sueldo"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
