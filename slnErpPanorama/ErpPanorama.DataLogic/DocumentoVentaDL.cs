using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;
//using ErpPanorama.BusinessEntity.Reportes;

namespace ErpPanorama.DataLogic
{
    public class DocumentoVentaDL
    {
        public DocumentoVentaDL() { }

        public Int32 Inserta(DocumentoVentaBE pItem)
        {
            Int32 intIdDocumentoVenta = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_Inserta");

            db.AddOutParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);

            db.AddInParameter(dbCommand, "pIdDocumentoReferencia", DbType.Int32, pItem.IdDocumentoReferencia);
            //db.AddInParameter(dbCommand, "pSerieReferencia", DbType.String, pItem.SerieReferencia);
            //db.AddInParameter(dbCommand, "pNumeroReferencia", DbType.String, pItem.NumeroReferencia);

            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);

            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Decimal, pItem.PorcentajeDescuento);//double
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuentos);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Decimal, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pIcbper", DbType.Decimal, pItem.Icbper);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pTotalBruto", DbType.Decimal, pItem.TotalBruto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);

            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdPromocionProxima", DbType.Int32, pItem.IdPromocionProxima);
            db.AddInParameter(dbCommand, "pFlagPromocionProxima", DbType.Boolean, pItem.FlagPromocionProxima);
            db.AddInParameter(dbCommand, "pCodigoNC", DbType.String, pItem.CodigoNC);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pIdUbigeoOrigen", DbType.String, pItem.IdUbigeoOrigen);
            db.AddInParameter(dbCommand, "pFechaTraslado", DbType.DateTime, pItem.FechaTraslado);
            db.AddInParameter(dbCommand, "pMotivoTraslado", DbType.String, pItem.MotivoTraslado);
            db.AddInParameter(dbCommand, "pModalildadTraslado", DbType.String, pItem.ModalidadTraslado);
            db.AddInParameter(dbCommand, "pNumeroBultos", DbType.Int32, pItem.NumeroBultos);

            db.AddInParameter(dbCommand, "pPesoBultos", DbType.Int32, pItem.PesoBultos);
            db.AddInParameter(dbCommand, "pIdTipoIdentidadTra", DbType.String, pItem.IdTipoIdentidadTra);
            db.AddInParameter(dbCommand, "pNumeroDocTra", DbType.String, pItem.NumeroDocTra);
            db.AddInParameter(dbCommand, "pRazonSocialTra", DbType.String, pItem.RazonSocialTra);
            db.AddInParameter(dbCommand, "pNumeroPlaca", DbType.String, pItem.NumeroPlaca);
            db.AddInParameter(dbCommand, "pIdPersonaRegistro", DbType.Int32, pItem.IdPersonaRegistro);

            db.AddInParameter(dbCommand, "pFlagCumpleanios", DbType.Boolean, pItem.FlagCumpleanios);
            db.AddInParameter(dbCommand, "pTotalDscCumpleanios", DbType.Decimal, pItem.TotalDscCumpleanios);

            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pIdComercioAmigo", DbType.Int32, pItem.IdComercioAmigo);

            db.AddInParameter(dbCommand, "pIdTiendaDestinoGuia", DbType.Int32, pItem.IdTiendaDestinoGuia);
            db.AddInParameter(dbCommand, "pMarca", DbType.String, pItem.Marca);
            db.AddInParameter(dbCommand, "pLicenciaConducir", DbType.String, pItem.LicenciaConducir);


            db.ExecuteNonQuery(dbCommand);

            intIdDocumentoVenta = (int)db.GetParameterValue(dbCommand, "pIdDocumentoVenta");

            return intIdDocumentoVenta;
        }


        public Int32 InsertaWeb(DocumentoVentaBE pItem)
        {
            Int32 intIdDocumentoVenta = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_InsertaWeb");

            db.AddOutParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdDocumentoReferencia", DbType.Int32, pItem.IdDocumentoReferencia);


            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);

            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Decimal, pItem.PorcentajeDescuento);//double
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuentos);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Decimal, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pIcbper", DbType.Decimal, pItem.Icbper);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pTotalBruto", DbType.Decimal, pItem.TotalBruto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);

            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdPromocionProxima", DbType.Int32, pItem.IdPromocionProxima);
            db.AddInParameter(dbCommand, "pFlagPromocionProxima", DbType.Boolean, pItem.FlagPromocionProxima);
            db.AddInParameter(dbCommand, "pCodigoNC", DbType.String, pItem.CodigoNC);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pIdUbigeoOrigen", DbType.String, pItem.IdUbigeoOrigen);
            db.AddInParameter(dbCommand, "pFechaTraslado", DbType.DateTime, pItem.FechaTraslado);
            db.AddInParameter(dbCommand, "pMotivoTraslado", DbType.String, pItem.MotivoTraslado);
            db.AddInParameter(dbCommand, "pModalildadTraslado", DbType.String, pItem.ModalidadTraslado);
            db.AddInParameter(dbCommand, "pNumeroBultos", DbType.Int32, pItem.NumeroBultos);

            db.AddInParameter(dbCommand, "pPesoBultos", DbType.Int32, pItem.PesoBultos);
            db.AddInParameter(dbCommand, "pIdTipoIdentidadTra", DbType.String, pItem.IdTipoIdentidadTra);
            db.AddInParameter(dbCommand, "pNumeroDocTra", DbType.String, pItem.NumeroDocTra);
            db.AddInParameter(dbCommand, "pRazonSocialTra", DbType.String, pItem.RazonSocialTra);
            db.AddInParameter(dbCommand, "pNumeroPlaca", DbType.String, pItem.NumeroPlaca);
            db.AddInParameter(dbCommand, "pIdPersonaRegistro", DbType.Int32, pItem.IdPersonaRegistro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.AddInParameter(dbCommand, "pIdComercioAmigo", DbType.Int32, pItem.IdComercioAmigo);
            db.AddInParameter(dbCommand, "pIdPedidoWeb", DbType.Int32, pItem.IdPedidoWeb);

            db.ExecuteNonQuery(dbCommand);

            intIdDocumentoVenta = (int)db.GetParameterValue(dbCommand, "pIdDocumentoVenta");

            return intIdDocumentoVenta;
        }

        public void Actualiza(DocumentoVentaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_Actualiza");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdDocumentoReferencia", DbType.Int32, pItem.IdDocumentoReferencia);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Decimal, pItem.PorcentajeDescuento); //Double
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuentos);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Decimal, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pIcbper", DbType.Decimal, pItem.Icbper);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pTotalBruto", DbType.Decimal, pItem.TotalBruto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pCodigoNC", DbType.String, pItem.CodigoNC);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdEmpresa, int IdDocumentoVenta, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacionPSE(int IdEmpresa, int IdDocumentoVenta, int IdSituacion, DateTime Fecha, string MensajeOSE, int GrupoBaja , string NumeroTicket, DateTime FecRecepcion, string DocReferencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaSituacionPSE");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaProcesoOSE", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pMensajeOSE", DbType.String, MensajeOSE);
            db.AddInParameter(dbCommand, "pGrupoBaja", DbType.Int32, GrupoBaja);

            db.AddInParameter(dbCommand, "pNumeroTicket", DbType.String, NumeroTicket);
            db.AddInParameter(dbCommand, "pFecRecepcion", DbType.DateTime, FecRecepcion);
            db.AddInParameter(dbCommand, "pDocReferencia", DbType.String, DocReferencia);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaMensajeSunat(int IdDocumentoVenta, DateTime Fecha, string Mensaje)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaMensajeSunat");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pFechaProcesoOSE", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pMensajeOSE", DbType.String, Mensaje);

            db.ExecuteNonQuery(dbCommand);

        }

        public void GrabarTicket(int IdEmpresa, int IdDocumentoVenta, int IdSituacion, DateTime Fecha, string MensajeOSE, int GrupoBaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaSituacionPSE");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaProcesoOSE", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pMensajeOSE", DbType.String, MensajeOSE);
            db.AddInParameter(dbCommand, "pGrupoBaja", DbType.Int32, GrupoBaja);

            db.ExecuteNonQuery(dbCommand);

        }


        public void ActualizaSituacionSituacion_FE(int IdEmpresa, int IdDocumentoVenta, int IdSituacion, DateTime Fecha, string MensajeOSE, string pTipoDoc, string pSerie, string pNumero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaSituacion_FE");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaProcesoOSE", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pMensajeOSE", DbType.String, MensajeOSE);
            db.AddInParameter(dbCommand, "pTipoDoc", DbType.String, pTipoDoc);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pSerie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pNumero);
            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacionContable(int IdEmpresa, int IdDocumentoVenta, int IdSituacionContable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaSituacionContable");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdSituacionContable", DbType.Int32, IdSituacionContable);

            db.ExecuteNonQuery(dbCommand);

        }


        public void ActualizaSerieNumero(int IdEmpresa, int IdDocumentoVenta, string Serie, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaSerieNumero");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaFecha(int IdEmpresa, int IdDocumentoVenta, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaFecha");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaCliente(int IdDocumentoVenta, int IdCliente, string NumeroDocumento, string DescCliente, string Direccion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaCliente");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, Direccion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaVinculoPedido(int IdDocumentoVenta, int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaVinculoPedido");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaPromocionProxima(int IdDocumentoVenta, bool FlagPromocionProxima)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaPromocionProxima");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pFlagPromocionProxima", DbType.Boolean, FlagPromocionProxima);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Copia(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_Copia");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(DocumentoVentaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_Elimina");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public DocumentoVentaBE Selecciona(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_Selecciona");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.IdTipoDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();

                DocumentoVenta.FechaReferencia = reader.IsDBNull(reader.GetOrdinal("FechaReferencia")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaReferencia"));
             //   DocumentoVenta.FechaReferencia = DateTime.Parse(reader["FechaReferencia"].ToString());

                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                DocumentoVenta.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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
                DocumentoVenta.IdSituacionPSE = Int32.Parse(reader["idSituacionPSE"].ToString());
                DocumentoVenta.FlagCumpleanios = Boolean.Parse(reader["FlagCumpleanios"].ToString());
                DocumentoVenta.TotalDscCumpleanios = Decimal.Parse(reader["TotalDscCumpleanios"].ToString());
                DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public DocumentoVentaBE SeleccionaEnvioValido(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaEnvioValidoFE");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.IdTipoDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                DocumentoVenta.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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
                DocumentoVenta.Icbper = Decimal.Parse(reader["TotalICBPER"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.IdSituacionPSE = Int32.Parse(reader["IdSituacionPSE"].ToString());
                DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVenta.TotalDiferencia = Decimal.Parse(reader["TotalDiferencia"].ToString());


            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public DocumentoVentaBE SeleccionaEnvioValido_RER(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaEnvioValidoFE_RER");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.IdTipoDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                DocumentoVenta.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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
                DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVenta.TotalDiferencia = Decimal.Parse(reader["TotalDiferencia"].ToString());


            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public DocumentoVentaBE SeleccionaGanador22(int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaGanador22");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public DocumentoVentaBE SeleccionaFE(int IdEmpresa, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaFE");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.DescMotivoAnula = reader["DescMotivoAnula"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                DocumentoVenta.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                DocumentoVenta.IdTipoIdentidad = reader["IdTipoIdentidad"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();
                DocumentoVenta.IdUbigeoDom = reader["IdUbigeoDom"].ToString();

                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                DocumentoVenta.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                DocumentoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DocumentoVenta.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                DocumentoVenta.DniVendedor = reader["DniVendedor"].ToString();
                DocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                DocumentoVenta.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                DocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                DocumentoVenta.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVenta.Descuentos = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVenta.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                DocumentoVenta.Icbper = Decimal.Parse(reader["TotalICBPER"].ToString());
                DocumentoVenta.OperacionGratuita = Decimal.Parse(reader["OperacionGratuita"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.IdSituacionPSE = Int32.Parse(reader["IdSituacionPSE"].ToString());
                DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.IdTipoDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePagoRef = reader["IdConTipoComprobantePagoRef"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.CodigoNC = reader["CodigoNC"].ToString();
                DocumentoVenta.FechaReferencia = DateTime.Parse(reader["FechaReferencia"].ToString());
                //DocumentoVenta.Codmot = reader["Codmot"].ToString();
                //DocumentoVenta.Tidomd = reader["Tidomd"].ToString();
                //DocumentoVenta.Nudomd = reader["Nudomd"].ToString();
                //DocumentoVenta.Fedomd = reader["Fedomd"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVenta.TotalDscCumpleanios = Decimal.Parse(reader["TotalDscCumpleanios"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public DocumentoVentaBE SeleccionaFE_RER(int IdEmpresa, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaFE_RER");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.DescMotivoAnula = reader["DescMotivoAnula"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                DocumentoVenta.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                DocumentoVenta.IdTipoIdentidad = reader["IdTipoIdentidad"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();
                DocumentoVenta.IdUbigeoDom = reader["IdUbigeoDom"].ToString();

                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                DocumentoVenta.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                DocumentoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DocumentoVenta.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                DocumentoVenta.DniVendedor = reader["DniVendedor"].ToString();
                DocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                DocumentoVenta.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                DocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                DocumentoVenta.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVenta.Descuentos = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVenta.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                DocumentoVenta.OperacionGratuita = Decimal.Parse(reader["OperacionGratuita"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.IdSituacionPSE = Int32.Parse(reader["IdSituacionPSE"].ToString());
                DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.IdTipoDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePagoRef = reader["IdConTipoComprobantePagoRef"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.CodigoNC = reader["CodigoNC"].ToString();
                //DocumentoVenta.Codmot = reader["Codmot"].ToString();
                //DocumentoVenta.Tidomd = reader["Tidomd"].ToString();
                //DocumentoVenta.Nudomd = reader["Nudomd"].ToString();
                //DocumentoVenta.Fedomd = reader["Fedomd"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }


        public DocumentoVentaBE SeleccionaGuiaFE(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaGuiaFE");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.DescMotivoAnula = reader["DescMotivoAnula"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                DocumentoVenta.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                DocumentoVenta.IdTipoIdentidad = reader["IdTipoIdentidad"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();

                DocumentoVenta.IdUbigeoDom = reader["IdUbigeoDom"].ToString();

                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                DocumentoVenta.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                DocumentoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DocumentoVenta.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                DocumentoVenta.DniVendedor = reader["DniVendedor"].ToString();
                DocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                DocumentoVenta.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                DocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                DocumentoVenta.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVenta.Descuentos = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVenta.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                DocumentoVenta.OperacionGratuita = Decimal.Parse(reader["OperacionGratuita"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.IdSituacionPSE = Int32.Parse(reader["IdSituacionPSE"].ToString());
                DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.IdTipoDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePagoRef = reader["IdConTipoComprobantePagoRef"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.CodigoNC = reader["CodigoNC"].ToString();

                DocumentoVenta.IdUbigeo = reader["IdUbigeo"].ToString();
                DocumentoVenta.IdUbigeoOrigen = reader["IdUbigeoOrigen"].ToString();

                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresaOrigen"].ToString();
                DocumentoVenta.FechaTraslado = reader.IsDBNull(reader.GetOrdinal("FechaTraslado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaTraslado"));

                DocumentoVenta.MotivoTraslado = reader["MotivoTraslado"].ToString();
                DocumentoVenta.DescTraslado = reader["DescTraslado"].ToString();

                DocumentoVenta.ModalidadTraslado = reader["ModalidadTraslado"].ToString();
                DocumentoVenta.DescModalidadTraslado = reader["DescModalidadTraslado"].ToString();
                DocumentoVenta.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                DocumentoVenta.PesoBultos = Decimal.Parse(reader["PesoBultos"].ToString());
                DocumentoVenta.IdTipoIdentidadTra = reader["IdTipoIdentidadTra"].ToString();
                DocumentoVenta.NumeroDocTra = reader["NumeroDocTra"].ToString();
                DocumentoVenta.RazonSocialTra = reader["RazonSocialTra"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                DocumentoVenta.Nombres = reader["Nombres"].ToString();
                DocumentoVenta.Apellidos = reader["Apellidos"].ToString();

                DocumentoVenta.NumeroPlaca = reader["NumeroPlaca"].ToString();
                DocumentoVenta.Marca = reader["Marca"].ToString();
                DocumentoVenta.LicenciaConducir = reader["LicenciaConducir"].ToString();
                DocumentoVenta.IdTiendaDestinoGuia = Int32.Parse(reader["IdTiendaDestinoGuia"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public DocumentoVentaBE SeleccionaGuiaFETicket(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConsultaTicketDoc");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();

                DocumentoVenta.NumeroTicket = reader["NumeroTicket"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }
        public DocumentoVentaBE SeleccionaSerieNumero(int IdEmpresa, int IdTipoDocumento, string Serie, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaSerieNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                DocumentoVenta.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();
                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.DescMoneda = reader["DescMoneda"].ToString();
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
                DocumentoVenta.CodigoNC = reader["CodigoNC"].ToString();
                DocumentoVenta.IdPromocionProxima = Int32.Parse(reader["IdPromocionProxima"].ToString());
                DocumentoVenta.FlagCumpleanios = Boolean.Parse(reader["FlagCumpleanios"].ToString());
                DocumentoVenta.TotalDscCumpleanios = Decimal.Parse(reader["TotalDscCumpleanios"].ToString());
                DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }


        public DocumentoVentaBE SeleccionaTotalCambio(int IdEmpresa, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaTotalCambio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public List<DocumentoVentaBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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
                //DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> Lista(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_Lista");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdSituacionPedido = reader.IsDBNull(reader.GetOrdinal("IdSituacionPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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
                //DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVenta.TotalDscCumpleanios = Decimal.Parse(reader["TotalDscCumpleanios"].ToString());
                
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaGeneral(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaGeneral");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdSituacionPedido = reader.IsDBNull(reader.GetOrdinal("IdSituacionPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.FechaReferencia = reader.IsDBNull(reader.GetOrdinal("FechaReferencia")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumentoReferencia"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();
                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                DocumentoVenta.TipoCambioSunat = Decimal.Parse(reader["TipoCambioSunat"].ToString());
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
                DocumentoVenta.Icbper = Decimal.Parse(reader["TotalICBPER"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());

                DocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.IdSituacionContable = Int32.Parse(reader["IdSituacionContable"].ToString());
                DocumentoVenta.DescSituacionContable = reader["DescSituacionContable"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaGeneralPD(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaGeneralPD");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdSituacionPedido = reader.IsDBNull(reader.GetOrdinal("IdSituacionPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.FechaReferencia = reader.IsDBNull(reader.GetOrdinal("FechaReferencia")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumentoReferencia"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();
                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                DocumentoVenta.TipoCambioSunat = Decimal.Parse(reader["TipoCambioSunat"].ToString());
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
                DocumentoVenta.Icbper = Decimal.Parse(reader["TotalICBPER"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                DocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.IdSituacionContable = Int32.Parse(reader["IdSituacionContable"].ToString());
                DocumentoVenta.DescSituacionContable = reader["DescSituacionContable"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaGeneralDetalle(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaGeneralDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdSituacionPedido = reader.IsDBNull(reader.GetOrdinal("IdSituacionPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.FechaReferencia = reader.IsDBNull(reader.GetOrdinal("FechaReferencia")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumentoReferencia"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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

                DocumentoVenta.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                DocumentoVenta.CodigoProveedor = reader["CodigoProveedor"].ToString();
                DocumentoVenta.NombreProducto = reader["NombreProducto"].ToString();
                DocumentoVenta.Abreviatura = reader["Abreviatura"].ToString();
                DocumentoVenta.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                DocumentoVenta.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());

                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaVendedor(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaVendedor");
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                DocumentoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.IdSituacionContable = Int32.Parse(reader["IdSituacionContable"].ToString());
                DocumentoVenta.DescSituacionContable = reader["DescSituacionContable"].ToString();
                DocumentoVenta.IdSituacionContable = Int32.Parse(reader["IdSituacionContable"].ToString());
                DocumentoVenta.FechaContable = reader.IsDBNull(reader.GetOrdinal("FechaContable")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaContable"));
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> SeleccionaPedido(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaPedido");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.DescCaja = reader["DescCaja"].ToString();
                DocumentoVenta.IdSituacionContable = Int32.Parse(reader["IdSituacionContable"].ToString());
                DocumentoVenta.DescSituacionContable = reader["DescSituacionContable"].ToString();
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaDescuentoProxima(int IdCliente, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaDescuentoProxima");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.PorcentajeDescuento = Decimal.Parse(reader["PorcentajeDescuento"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListadoPedido(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListadoPedido");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdSituacionPedido = reader.IsDBNull(reader.GetOrdinal("IdSituacionPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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
                DocumentoVenta.UserCreate = reader["UserCreate"].ToString();
                //DocumentoVenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListadoPedidoConta(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListadoPedidoConta");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdSituacionPedido = reader.IsDBNull(reader.GetOrdinal("IdSituacionPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVenta.Icbper = Decimal.Parse(reader["TotalICBPER"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaSerieNumero(int IdTipoDocumento, string Serie, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaSerieNumero");
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                DocumentoVenta.IdSituacionPedido = reader.IsDBNull(reader.GetOrdinal("IdSituacionPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPedido"));
                DocumentoVenta.IdTipoDocumentoPedido = reader.IsDBNull(reader.GetOrdinal("IdTipoDocumentoPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoDocumentoPedido"));
                DocumentoVenta.CodDocumentoPedido = reader["CodDocumentoPedido"].ToString();
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                DocumentoVenta.CodTipoDocumentoReferencia = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.SerieReferencia = reader["SerieReferencia"].ToString();
                DocumentoVenta.NumeroReferencia = reader["NumeroReferencia"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
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
                DocumentoVenta.UserCreate = reader["UserCreate"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVenta.Icbper = Decimal.Parse(reader["TotalICBPER"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaEmpresaPeriodo(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaEmpresaPeriodo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.Enero = Decimal.Parse(reader["Enero"].ToString());
                DocumentoVenta.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                DocumentoVenta.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                DocumentoVenta.Abril = Decimal.Parse(reader["Abril"].ToString());
                DocumentoVenta.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                DocumentoVenta.Junio = Decimal.Parse(reader["Junio"].ToString());
                DocumentoVenta.Julio = Decimal.Parse(reader["Julio"].ToString());
                DocumentoVenta.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                DocumentoVenta.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                DocumentoVenta.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                DocumentoVenta.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                DocumentoVenta.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaEmpresaPeriodoVentasa_RER(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaVentaEmpresaRERxPeriodo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.Enero = Decimal.Parse(reader["Enero"].ToString());
                DocumentoVenta.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                DocumentoVenta.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                DocumentoVenta.Abril = Decimal.Parse(reader["Abril"].ToString());
                DocumentoVenta.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                DocumentoVenta.Junio = Decimal.Parse(reader["Junio"].ToString());
                DocumentoVenta.Julio = Decimal.Parse(reader["Julio"].ToString());
                DocumentoVenta.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                DocumentoVenta.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                DocumentoVenta.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                DocumentoVenta.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                DocumentoVenta.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaConsolidadoComercioAmigo(string Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_VentasAcumuladasComercioAmigo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.String, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();

                DocumentoVenta.NumeroDocumento = reader["DocCliente"].ToString();
                DocumentoVenta.DescCliente = reader["Cliente"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["Fecdoc"].ToString());
                DocumentoVenta.DescMoneda = reader["Moneda"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVenta.ComercioAmigo = reader["ComercioAmigo"].ToString();

                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaPeriodoGeneral(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UtilidadBruta");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            dbCommand.CommandTimeout = 60;
            IDataReader reader = db.ExecuteReader(dbCommand);

            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["glosa"].ToString();
                DocumentoVenta.Enero = Decimal.Parse(reader["Enero"].ToString());
                DocumentoVenta.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                DocumentoVenta.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                DocumentoVenta.Abril = Decimal.Parse(reader["Abril"].ToString());
                DocumentoVenta.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                DocumentoVenta.Junio = Decimal.Parse(reader["Junio"].ToString());
                DocumentoVenta.Julio = Decimal.Parse(reader["Julio"].ToString());
                DocumentoVenta.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                DocumentoVenta.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                DocumentoVenta.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                DocumentoVenta.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                DocumentoVenta.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaPeriodoCobranzas(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ReporteCobranzas");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            dbCommand.CommandTimeout = 90;
            IDataReader reader = db.ExecuteReader(dbCommand);

            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["glosa"].ToString();
                DocumentoVenta.Enero = Decimal.Parse(reader["Enero"].ToString());
                DocumentoVenta.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                DocumentoVenta.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                DocumentoVenta.Abril = Decimal.Parse(reader["Abril"].ToString());
                DocumentoVenta.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                DocumentoVenta.Junio = Decimal.Parse(reader["Junio"].ToString());
                DocumentoVenta.Julio = Decimal.Parse(reader["Julio"].ToString());
                DocumentoVenta.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                DocumentoVenta.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                DocumentoVenta.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                DocumentoVenta.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                DocumentoVenta.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaPeriodoTiendas(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UtilidadBrutaxTienda");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.Tienda = reader["Tienda"].ToString();
                DocumentoVenta.Enero = Decimal.Parse(reader["Enero"].ToString());
                DocumentoVenta.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                DocumentoVenta.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                DocumentoVenta.Abril = Decimal.Parse(reader["Abril"].ToString());
                DocumentoVenta.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                DocumentoVenta.Junio = Decimal.Parse(reader["Junio"].ToString());
                DocumentoVenta.Julio = Decimal.Parse(reader["Julio"].ToString());
                DocumentoVenta.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                DocumentoVenta.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                DocumentoVenta.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                DocumentoVenta.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                DocumentoVenta.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaCanalesVentas(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CanalesDeVentas");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.Canal = reader["Canal"].ToString();
                DocumentoVenta.Glosa = reader["glosa"].ToString();
                DocumentoVenta.Enero = Decimal.Parse(reader["Enero"].ToString());
                DocumentoVenta.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                DocumentoVenta.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                DocumentoVenta.Abril = Decimal.Parse(reader["Abril"].ToString());
                DocumentoVenta.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                DocumentoVenta.Junio = Decimal.Parse(reader["Junio"].ToString());
                DocumentoVenta.Julio = Decimal.Parse(reader["Julio"].ToString());
                DocumentoVenta.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                DocumentoVenta.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                DocumentoVenta.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                DocumentoVenta.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                DocumentoVenta.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public DocumentoVentaBE SeleccionaEmpresaPeriodo(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaEmpresaPeriodo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());


            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public DocumentoVentaBE SeleccionaEmpresaPeriodoDia(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaEmpresaPeriodo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());


            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }


        public List<DocumentoVentaBE> ListaEmpresaFecha(int IdRegimenTributario, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaEmpresaFecha");
            db.AddInParameter(dbCommand, "pIdRegimenTributario", DbType.Int32, IdRegimenTributario);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVenta.Tope = Decimal.Parse(reader["Tope"].ToString());
                DocumentoVenta.TopeDiario = Decimal.Parse(reader["TopeDiario"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public DocumentoVentaBE SeleccionaEmpresaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_SeleccionaEmpresaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoVentaBE DocumentoVenta = null;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());


            }
            reader.Close();
            reader.Dispose();
            return DocumentoVenta;
        }

        public List<DocumentoVentaBE> ListaEmpresaTraslado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaEmpresaTraslado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();
                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                DocumentoVenta.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                DocumentoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DocumentoVenta.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                DocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaGuiaEmpresaTraslado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaGuiaEmpresaTraslado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVenta.Ruc = reader["Ruc"].ToString();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                DocumentoVenta.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                DocumentoVenta.Mes = Int32.Parse(reader["Mes"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["serie"].ToString();
                DocumentoVenta.Numero = reader["numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.Direccion = reader["direccion"].ToString();
                DocumentoVenta.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                DocumentoVenta.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                DocumentoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DocumentoVenta.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                DocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                DocumentoVenta.Observacion = reader["observacion"].ToString();
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.DescSituacion = reader["DescSituacion"].ToString();
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public void EliminaFisico(DocumentoVentaBE pItem)//int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_EliminaFisico");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DocumentoVentaBE> ListaProducto(int IdProducto, DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaProducto");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                DocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                DocumentoVenta.DescTienda = reader["DescTienda"].ToString();
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Documento = reader["Documento"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                DocumentoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                DocumentoVenta.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaComparaCabeceraDetalle(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaComparaCabeceraDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                DocumentoVenta.RazonSocial = reader["RazonSocial"].ToString();
                DocumentoVenta.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVenta.Serie = reader["Serie"].ToString();
                DocumentoVenta.Numero = reader["Numero"].ToString();
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                DocumentoVenta.TotalDetalle = Decimal.Parse(reader["TotalDetalle"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaMesCumpleanos(int Anio, int Mes, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaMesCumpleanos");
            db.AddInParameter(dbCommand, "pAnio", DbType.Int32, Anio);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                DocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());

                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public void ActualizaObsequioCosto(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaObsequioCosto");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            dbCommand.CommandTimeout = 250;

            db.ExecuteNonQuery(dbCommand);


        }

        public List<DocumentoVentaBE> ListaPendientePSE(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaPendientePSE");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.Serie = reader["Serie"].ToString();
                DocumentoVenta.Numero = reader["Numero"].ToString();
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVenta.TotalDetalle = Decimal.Parse(reader["TotalDetalle"].ToString());
                DocumentoVenta.TotalDiferencia = Decimal.Parse(reader["TotalDiferencia"].ToString());
                DocumentoVenta.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                DocumentoVenta.IdSituacionPSE = Int32.Parse(reader["IdSituacionPSE"].ToString());
                DocumentoVenta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaPendienteBajaFE(int IdEmpresa, int IdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaPendienteBajaFE");
            //  DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ResumenDiario");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            //db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, 1658223);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();

                DocumentoVenta.Item = Int32.Parse(reader["Item"].ToString());
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                DocumentoVenta.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.Serie = reader["Serie"].ToString();
                DocumentoVenta.Numero = reader["Numero"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.IdTipoIdentidad = reader["IdTipoIdentidad"].ToString();
                DocumentoVenta.CodigoNC = reader["CodigoNC"].ToString();
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["Igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVenta.IdGrupoBaja = Int32.Parse(reader["IdGrupoBaja"].ToString());
                DocumentoVenta.GrupoBaja = reader["GrupoBaja"].ToString();
                DocumentoVenta.MotivoBaja = reader["MotivoBaja"].ToString();
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());

                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> ListaPendienteBajaBE(int IdEmpresa, int IdTipoDocumento, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaPendienteBajaBE");
            //  DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ResumenDiario");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();

                DocumentoVenta.Item = Int32.Parse(reader["Item"].ToString());
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                DocumentoVenta.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.Serie = reader["Serie"].ToString();
                DocumentoVenta.Numero = reader["Numero"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.IdTipoIdentidad = reader["IdTipoIdentidad"].ToString();
                DocumentoVenta.CodigoNC = reader["CodigoNC"].ToString();
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["Igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVenta.IdGrupoBaja = Int32.Parse(reader["IdGrupoBaja"].ToString());
                DocumentoVenta.GrupoBaja = reader["GrupoBaja"].ToString();
                DocumentoVenta.MotivoBaja = reader["MotivoBaja"].ToString();
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());

                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public List<DocumentoVentaBE> BajaNC(int IdEmpresa, int IdTipoDocumento, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaPendienteBajaFE_nc");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaBE> DocumentoVentalist = new List<DocumentoVentaBE>();
            DocumentoVentaBE DocumentoVenta;
            while (reader.Read())
            {
                DocumentoVenta = new DocumentoVentaBE();
                DocumentoVenta.Item = Int32.Parse(reader["Item"].ToString());
                DocumentoVenta.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                DocumentoVenta.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                DocumentoVenta.IdConTipoComprobantePago = reader["IdConTipoComprobantePago"].ToString();
                DocumentoVenta.Serie = reader["Serie"].ToString();
                DocumentoVenta.Numero = reader["Numero"].ToString();
                DocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVenta.IdTipoIdentidad = reader["IdTipoIdentidad"].ToString();
                DocumentoVenta.CodigoNC = reader["CodigoNC"].ToString();
                DocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVenta.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                DocumentoVenta.Igv = Decimal.Parse(reader["Igv"].ToString());
                DocumentoVenta.Total = Decimal.Parse(reader["Total"].ToString());
                DocumentoVenta.IdGrupoBaja = Int32.Parse(reader["IdGrupoBaja"].ToString());
                DocumentoVenta.GrupoBaja = reader["GrupoBaja"].ToString();
                DocumentoVenta.MotivoBaja = reader["MotivoBaja"].ToString();
                DocumentoVenta.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                DocumentoVentalist.Add(DocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentalist;
        }

        public void ActualizaIdDocumentoVentaEnEstadoCuenta(int IdDocumentoVenta, int IdEstadoCuenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ActualizaIdDocumentoVenta_EstadoCuenta");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEstadoCuenta", DbType.Int32, IdEstadoCuenta);

            db.ExecuteNonQuery(dbCommand);

        }

    }
}
