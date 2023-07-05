using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;
using ErpPanorama.BusinessEntity.Reportes;

namespace ErpPanorama.DataLogic.Reportes
{
  public  class ReporteFacturacionDL
    {
        public ReporteFacturacionDL() {   }

        public List<ReporteFacturacionBE> ListaReporte(int IdTienda, int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaReporte");
            dbCommand.CommandTimeout = 60;
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteFacturacionBE> DocumentoVentalist = new List<ReporteFacturacionBE>();
            ReporteFacturacionBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new ReporteFacturacionBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdPedido = Int32.Parse(reader.GetOrdinal("IdPedido").ToString());
                DocumentoVenta.IdSituacionPedido = Int32.Parse(reader.GetOrdinal("IdSituacionPedido").ToString());
                DocumentoVenta.IdTipoDocumentoPedido = Int32.Parse(reader.GetOrdinal("IdTipoDocumentoPedido").ToString());
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = Int32.Parse(reader.GetOrdinal("IdDocumentoReferencia").ToString());
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());

                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();
                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                DocumentoVenta.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                DocumentoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DocumentoVenta.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                DocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                DocumentoVenta.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                DocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                DocumentoVenta.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVenta.Descuentos = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVenta.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.IdSituacionPSE = Int32.Parse(reader["IdSituacionPSE"].ToString());
                DocumentoVenta.DescSituacionPSE = reader["DescSituacionPSE"].ToString();
                DocumentoVenta.MensajeOSE = reader["MensajeOSE"].ToString();
                DocumentoVenta.UserCreate = reader["UserCreate"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdDocumentoVentaDetalle = Int32.Parse(reader["idDocumentoVentaDetalle"].ToString());
                DocumentoVenta.Item = Int32.Parse(reader["item"].ToString());
                DocumentoVenta.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                DocumentoVenta.CodigoProveedor = reader["codigoProveedor"].ToString();
                DocumentoVenta.NombreProducto = reader["nombreProducto"].ToString();
                DocumentoVenta.Abreviatura = reader["Abreviatura"].ToString();
                DocumentoVenta.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                DocumentoVenta.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                DocumentoVenta.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVenta.Descuento = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVenta.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                DocumentoVenta.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                DocumentoVenta.CodAfeIGV = reader["CodAfeIGV"].ToString();
                DocumentoVenta.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                DocumentoVenta.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                DocumentoVenta.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());

                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }




    }
}
