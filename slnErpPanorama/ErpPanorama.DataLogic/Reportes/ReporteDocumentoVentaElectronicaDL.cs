using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDocumentoVentaElectronicaDL
    {
        public List<ReporteDocumentoVentaElectronicaBE> Listado(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaFE");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaElectronicaBE> Reportelist = new List<ReporteDocumentoVentaElectronicaBE>();
            ReporteDocumentoVentaElectronicaBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteDocumentoVentaElectronicaBE();
                Reporte.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Reporte.Ruc = reader["Ruc"].ToString();
                Reporte.RazonSocial = reader["RazonSocial"].ToString();
                Reporte.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                Reporte.NumeroPedido = reader["NumeroPedido"].ToString();
                Reporte.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Reporte.DescFormaPago = reader["DescFormaPago"].ToString();
                Reporte.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Reporte.TipoDocumento = reader["TipoDocumento"].ToString();
                Reporte.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Reporte.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                Reporte.Serie = reader["Serie"].ToString();
                Reporte.Numero = reader["Numero"].ToString();
                Reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Reporte.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Reporte.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Reporte.Hora = reader["Hora"].ToString();
                Reporte.IdTipoIdentidad = reader["IdTipoIdentidad"].ToString();
                Reporte.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Reporte.DescCliente = reader["DescCliente"].ToString();
                Reporte.Direccion = reader["Direccion"].ToString();
                Reporte.CodMoneda = reader["CodMoneda"].ToString();
                Reporte.DescMoneda = reader["DescMoneda"].ToString();
                Reporte.PorcentajeImpuesto = Decimal.Parse(reader["PorcentajeImpuesto"].ToString());
                Reporte.TotalDescuento = Decimal.Parse(reader["TotalDescuento"].ToString());
                Reporte.TotalDescuentoIncIGV = Decimal.Parse(reader["TotalDescuentoIncIGV"].ToString());
                Reporte.OperacionGratuita = Decimal.Parse(reader["OperacionGratuita"].ToString());
                Reporte.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                Reporte.Igv = Decimal.Parse(reader["Igv"].ToString());
                Reporte.Icbper = Decimal.Parse(reader["Icbper"].ToString());
                Reporte.Total = Decimal.Parse(reader["Total"].ToString());
                Reporte.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                Reporte.Item = Int32.Parse(reader["Item"].ToString());
                Reporte.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Reporte.NombreProducto = reader["NombreProducto"].ToString();
                Reporte.Medida = reader["Medida"].ToString();
                Reporte.Abreviatura = reader["Abreviatura"].ToString();
                Reporte.Cantidad = Int32.Parse( reader["Cantidad"].ToString());
                Reporte.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Reporte.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                Reporte.PorcentajeDescuento = Decimal.Parse(reader["PorcentajeDescuento"].ToString());
                Reporte.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Reporte.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Reporte.CodAfeIGV = reader["CodAfeIGV"].ToString();
                Reporte.DescVendedor = reader["DescVendedor"].ToString();
                Reporte.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Reporte.DescTienda = reader["DescTienda"].ToString();
                Reporte.DescCaja = reader["DescCaja"].ToString();
                Reporte.PagoEfectivo = Decimal.Parse(reader["PagoEfectivo"].ToString());
                Reporte.PagoTarjeta = Decimal.Parse(reader["PagoTarjeta"].ToString());
                Reporte.PagoNotaCredito = Decimal.Parse(reader["PagoNotaCredito"].ToString());
                Reporte.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                Reporte.TipoCambioSunat = Decimal.Parse(reader["TipoCambioSunat"].ToString());
                Reporte.PagoNotaCredito = Decimal.Parse(reader["PagoNotaCredito"].ToString());
                Reporte.CodigoNC = reader["CodigoNC"].ToString();
                Reporte.DescCodigoNC = reader["DescCodigoNC"].ToString();
                Reporte.Autorizacion = reader["Autorizacion"].ToString();
                Reporte.IdConTipoComprobantePagoRef = reader["IdConTipoComprobantePagoRef"].ToString();
                Reporte.TipoDocumentoRef = reader["TipoDocumentoRef"].ToString();
                Reporte.SerieReferencia = reader["SerieReferencia"].ToString();
                Reporte.NumeroReferencia = reader["NumeroReferencia"].ToString();
                Reporte.FechaReferencia = reader["FechaReferencia"].ToString();
             //   Reporte.CodigoQR = null;
                Reporte.FlagCumpleanios = Boolean.Parse(reader["FlagCumpleanios"].ToString());
                Reporte.TotalDscCumpleanios = Decimal.Parse(reader["TotalDscCumpleanios"].ToString());
                Reporte.DescPromocion = reader["DescPromocion"].ToString();
                Reporte.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());

                Reportelist.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Reportelist;
        }

        public List<ReporteDocumentoVentaElectronicaBE> ListadoGuia(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaGuiaFE");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaElectronicaBE> Reportelist = new List<ReporteDocumentoVentaElectronicaBE>();
            ReporteDocumentoVentaElectronicaBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteDocumentoVentaElectronicaBE();
                Reporte.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Reporte.Ruc = reader["Ruc"].ToString();
                Reporte.RazonSocial = reader["RazonSocial"].ToString();
                Reporte.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                Reporte.NumeroPedido = reader["NumeroPedido"].ToString();
                Reporte.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Reporte.DescFormaPago = reader["DescFormaPago"].ToString();
                Reporte.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Reporte.TipoDocumento = reader["TipoDocumento"].ToString();
                Reporte.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Reporte.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                Reporte.Serie = reader["Serie"].ToString();
                Reporte.Numero = reader["Numero"].ToString();
                Reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Reporte.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Reporte.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                Reporte.Hora = reader["Hora"].ToString();
                Reporte.IdTipoIdentidad = reader["IdTipoIdentidad"].ToString();
                Reporte.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Reporte.DescCliente = reader["DescCliente"].ToString();
                Reporte.Direccion = reader["Direccion"].ToString();
                Reporte.CodMoneda = reader["CodMoneda"].ToString();
                Reporte.DescMoneda = reader["DescMoneda"].ToString();
                Reporte.PorcentajeImpuesto = Decimal.Parse(reader["PorcentajeImpuesto"].ToString());
                Reporte.TotalDescuento = Decimal.Parse(reader["TotalDescuento"].ToString());
                Reporte.TotalDescuentoIncIGV = Decimal.Parse(reader["TotalDescuentoIncIGV"].ToString());
                Reporte.OperacionGratuita = Decimal.Parse(reader["OperacionGratuita"].ToString());
                Reporte.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                Reporte.Igv = Decimal.Parse(reader["Igv"].ToString());
                Reporte.Total = Decimal.Parse(reader["Total"].ToString());
                Reporte.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                Reporte.Item = Int32.Parse(reader["Item"].ToString());
                Reporte.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Reporte.NombreProducto = reader["NombreProducto"].ToString();
                Reporte.Medida = reader["Medida"].ToString();
                Reporte.Abreviatura = reader["Abreviatura"].ToString();
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Reporte.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                Reporte.PorcentajeDescuento = Decimal.Parse(reader["PorcentajeDescuento"].ToString());
                Reporte.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Reporte.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Reporte.CodAfeIGV = reader["CodAfeIGV"].ToString();
                Reporte.DescVendedor = reader["DescVendedor"].ToString();
                Reporte.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Reporte.DescTienda = reader["DescTienda"].ToString();
                Reporte.DescCaja = reader["DescCaja"].ToString();
                Reporte.PagoEfectivo = Decimal.Parse(reader["PagoEfectivo"].ToString());
                Reporte.PagoTarjeta = Decimal.Parse(reader["PagoTarjeta"].ToString());
                Reporte.PagoNotaCredito = Decimal.Parse(reader["PagoNotaCredito"].ToString());
                Reporte.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                Reporte.TipoCambioSunat = Decimal.Parse(reader["TipoCambioSunat"].ToString());
                Reporte.PagoNotaCredito = Decimal.Parse(reader["PagoNotaCredito"].ToString());
                Reporte.CodigoNC = reader["CodigoNC"].ToString();
                Reporte.DescCodigoNC = reader["DescCodigoNC"].ToString();
                Reporte.Autorizacion = reader["Autorizacion"].ToString();
                Reporte.IdConTipoComprobantePagoRef = reader["IdConTipoComprobantePagoRef"].ToString();
                Reporte.TipoDocumentoRef = reader["TipoDocumentoRef"].ToString();
                Reporte.SerieReferencia = reader["SerieReferencia"].ToString();
                Reporte.NumeroReferencia = reader["NumeroReferencia"].ToString();
                Reporte.FechaReferencia = reader["FechaReferencia"].ToString();
                Reporte.CodigoQR = null;
                Reporte.Observacion = reader["Observacion"].ToString();
                Reporte.IdUbigeo = reader["IdUbigeo"].ToString();
                Reporte.IdUbigeoOrigen = reader["IdUbigeoOrigen"].ToString();
                Reporte.DireccionTienda = reader["DireccionTienda"].ToString();
                Reporte.FechaTraslado = DateTime.Parse(reader["FechaTraslado"].ToString()); ;
                Reporte.MotivoTraslado = reader["MotivoTraslado"].ToString();
                Reporte.ModalildadTraslado = reader["ModalildadTraslado"].ToString();
                Reporte.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                Reporte.PesoBultos = Int32.Parse(reader["PesoBultos"].ToString());
                Reporte.IdTipoIdentidadTra = reader["IdTipoIdentidadTra"].ToString();
                Reporte.NumeroDocTra = reader["NumeroDocTra"].ToString();
                Reporte.RazonSocialTra = reader["RazonSocialTra"].ToString();
                Reporte.NumeroPlaca = reader["NumeroPlaca"].ToString();

               
                Reportelist.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Reportelist;
        }

    }

}

