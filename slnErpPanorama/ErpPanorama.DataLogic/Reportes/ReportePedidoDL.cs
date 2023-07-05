using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;
using ErpPanorama.BusinessEntity.Reportes;

namespace ErpPanorama.DataLogic.Reportes
{
  public  class ReportePedidoDL
    {
        public ReportePedidoDL() {   }

        public List<ReportePedidoBE> ListaReporte(int IdTienda, int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaReporte");
            dbCommand.CommandTimeout = 60;
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoBE> Pedidolist = new List<ReportePedidoBE>();
            ReportePedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Pedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.FlagCompraPerfecta = Boolean.Parse(reader["FlagCompraPerfecta"].ToString());
                Pedido.FlagAuditado = Boolean.Parse(reader["FlagAuditado"].ToString());
                Pedido.FechaAuditado = reader.IsDBNull(reader.GetOrdinal("FechaAuditado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAuditado"));
                Pedido.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Pedido.Add_user = reader["add_user"].ToString();
                 
                Pedido.Item = Int32.Parse(reader["item"].ToString());
                Pedido.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Pedido.CodigoProveedor = reader["codigoProveedor"].ToString();
                Pedido.Medida = reader["Medida"].ToString();
                Pedido.NombreProducto = reader["nombreProducto"].ToString();
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Pedido.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Pedido.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                Pedido.Descuento = Decimal.Parse(reader["descuento"].ToString());
                Pedido.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                Pedido.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }




    }
}
