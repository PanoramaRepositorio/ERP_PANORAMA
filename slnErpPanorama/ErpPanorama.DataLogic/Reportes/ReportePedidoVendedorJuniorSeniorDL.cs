using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorJuniorSeniorDL
    {
        public List<ReportePedidoVendedorJuniorSeniorBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorJuniorSenior");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorJuniorSeniorBE> Pedidolist = new List<ReportePedidoVendedorJuniorSeniorBE>();
            ReportePedidoVendedorJuniorSeniorBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorJuniorSeniorBE();
                Pedido.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.TotalCliMin = decimal.Parse(reader["TotalCliMin"].ToString());
                Pedido.TotalCliMay = decimal.Parse(reader["TotalCliMay"].ToString());
                Pedido.TotalRusMin = decimal.Parse(reader["TotalRusMin"].ToString());
                Pedido.TotalRusMay = decimal.Parse(reader["TotalRusMay"].ToString());
                Pedido.TotalRus = decimal.Parse(reader["TotalRus"].ToString());
                Pedido.TotalFacEsp = decimal.Parse(reader["TotalFacEsp"].ToString());
                Pedido.TotalNotaCre = decimal.Parse(reader["TotalNotaCre"].ToString());
                Pedido.CanRegCliente = Int32.Parse(reader["CanRegCliente"].ToString());
                Pedido.Total = decimal.Parse(reader["Total"].ToString());
                Pedido.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Pedido.Cargo = reader["Cargo"].ToString();
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());
                Pedido.TotalCliMinSIGV = decimal.Parse(reader["TotalCliMinSIGV"].ToString());
                Pedido.TotalCliMaySIGV = decimal.Parse(reader["TotalCliMaySIGV"].ToString());
                Pedido.TotalRusSIGV = decimal.Parse(reader["TotalRusSIGV"].ToString());
                Pedido.TotalFacEspSIGV = decimal.Parse(reader["TotalFacEspSIGV"].ToString());
                Pedido.TotalVentaNeta = decimal.Parse(reader["TotalVentaNeta"].ToString());
                Pedido.TotalVenta = decimal.Parse(reader["TotalVenta"].ToString());
                Pedido.TotalVentaIncentivado = decimal.Parse(reader["TotalVentaIncentivado"].ToString());
                Pedido.TotalCompraPerfecta = decimal.Parse(reader["TotalCompraPerfecta"].ToString());
                Pedido.PorMeta = decimal.Parse(reader["PorMeta"].ToString());
                Pedido.Basico = decimal.Parse(reader["Basico"].ToString());
                Pedido.RusSueldo = decimal.Parse(reader["RusSueldo"].ToString());
                //Pedido.BonoVenta = decimal.Parse(reader["BonoVenta"].ToString());
                Pedido.BonoVentaIntermediaria = decimal.Parse(reader["BonoVentaIntermediaria"].ToString());
                Pedido.RegCliSueldo = decimal.Parse(reader["RegCliSueldo"].ToString());
                Pedido.BonoMeta = decimal.Parse(reader["BonoMeta"].ToString());
                Pedido.Sbruto = decimal.Parse(reader["Sbruto"].ToString());
                Pedido.SubVencion = decimal.Parse(reader["SubVencion"].ToString());
                Pedido.Promocion = decimal.Parse(reader["Promocion"].ToString());
                Pedido.Asesoria = decimal.Parse(reader["Asesoria"].ToString());
                Pedido.ComisionVentaNeta = decimal.Parse(reader["ComisionVentaNeta"].ToString());
                Pedido.ComisionPromocion = decimal.Parse(reader["ComisionPromocion"].ToString());
                Pedido.ComisionAsesoria = decimal.Parse(reader["ComisionAsesoria"].ToString());
                Pedido.ComisionIncentivado = decimal.Parse(reader["ComisionIncentivado"].ToString());
                Pedido.ComisionCompraPerfecta = decimal.Parse(reader["ComisionCompraPerfecta"].ToString());
                Pedido.TotalComision = decimal.Parse(reader["TotalComision"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}

