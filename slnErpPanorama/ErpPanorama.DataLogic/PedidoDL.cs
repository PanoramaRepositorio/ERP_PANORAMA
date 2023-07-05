using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PedidoDL
    {
        private int _IdPedidoWeb;
        public int IdPedidoWeb
        {
            get { return _IdPedidoWeb; }
            set { _IdPedidoWeb = value; }
        }

        private int _IdCliente;
        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        private string _NumeroDocumento;
        public string NumeroDocumento
        {
            get { return _NumeroDocumento; }
            set { _NumeroDocumento = value; }
        }

        private string _DescCliente;
        public string DescCliente
        {
            get { return _DescCliente; }
            set { _DescCliente = value; }
        }

        private string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public PedidoDL() { }

        public Int32 Inserta(PedidoBE pItem)
        {
            Int32 intIdPedido = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_Inserta");

            db.AddOutParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCampana", DbType.Int32, pItem.IdCampana);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdPedidoReferencia", DbType.Int32, pItem.IdPedidoReferencia); //Add
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pFechaCancelacion", DbType.DateTime, pItem.FechaCancelacion);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdClienteAsociado", DbType.Int32, pItem.IdClienteAsociado);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Double, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pTotalBruto", DbType.Decimal, pItem.TotalBruto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pDespachar", DbType.String, pItem.Despachar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, pItem.IdTipoVenta);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pIdAsesorExterno", DbType.Int32, pItem.IdAsesorExterno);
            db.AddInParameter(dbCommand, "pFlagPreventa", DbType.Boolean, pItem.FlagPreVenta);
            db.AddInParameter(dbCommand, "pFlagImpresionRus", DbType.Boolean, pItem.FlagImpresionRus);
            db.AddInParameter(dbCommand, "pIdContratoFabricacion", DbType.Int32, pItem.IdContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdProyectoServicio", DbType.Int32, pItem.IdProyectoServicio);
            db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
            db.AddInParameter(dbCommand, "pFlagPtFlores", DbType.Boolean, pItem.FlagPtFlores);
            db.AddInParameter(dbCommand, "pFlagCumpleanios", DbType.Boolean, pItem.FlagCumpleanios);
            db.AddInParameter(dbCommand, "pTotalDscCumpleanios", DbType.Decimal, pItem.TotalDscCumpleanios);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIcbper", DbType.Decimal, pItem.Icbper);

            db.ExecuteNonQuery(dbCommand);

            intIdPedido = (int)db.GetParameterValue(dbCommand, "pIdPedido");

            return intIdPedido;

        }

        public Int32 Inserta_PedidoWEB(PedidoBE pItem)
        {
            Int32 intIdPedido = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoWEB_Inserta");

            db.AddOutParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCampana", DbType.Int32, pItem.IdCampana);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdPedidoReferencia", DbType.Int32, pItem.IdPedidoReferencia); //Add
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pFechaCancelacion", DbType.DateTime, pItem.FechaCancelacion);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdClienteAsociado", DbType.Int32, pItem.IdClienteAsociado);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Double, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pTotalBruto", DbType.Decimal, pItem.TotalBruto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pDespachar", DbType.String, pItem.Despachar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, pItem.IdTipoVenta);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pIdAsesorExterno", DbType.Int32, pItem.IdAsesorExterno);
            db.AddInParameter(dbCommand, "pFlagPreventa", DbType.Boolean, pItem.FlagPreVenta);
            db.AddInParameter(dbCommand, "pFlagImpresionRus", DbType.Boolean, pItem.FlagImpresionRus);
            db.AddInParameter(dbCommand, "pIdContratoFabricacion", DbType.Int32, pItem.IdContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdProyectoServicio", DbType.Int32, pItem.IdProyectoServicio);
            db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdPedidoWeb", DbType.Int32, pItem.IdPedidoWEB);

            db.ExecuteNonQuery(dbCommand);

            intIdPedido = (int)db.GetParameterValue(dbCommand, "pIdPedido");

            return intIdPedido;

        }


        public void Actualiza(PedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_Actualiza");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCampana", DbType.Int32, pItem.IdCampana);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdPedidoReferencia", DbType.Int32, pItem.IdPedidoReferencia); //Add
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pFechaCancelacion", DbType.DateTime, pItem.FechaCancelacion);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdClienteAsociado", DbType.Int32, pItem.IdClienteAsociado);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Double, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pIcbper", DbType.Decimal, pItem.Icbper);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pTotalBruto", DbType.Decimal, pItem.TotalBruto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pDespachar", DbType.String, pItem.Despachar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, pItem.IdTipoVenta);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pIdAsesorExterno", DbType.Int32, pItem.IdAsesorExterno);
            db.AddInParameter(dbCommand, "pFlagPreventa", DbType.Boolean, pItem.FlagPreVenta);
            db.AddInParameter(dbCommand, "pFlagImpresionRus", DbType.Boolean, pItem.FlagImpresionRus);
            db.AddInParameter(dbCommand, "pIdContratoFabricacion", DbType.Int32, pItem.IdContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdProyectoServicio", DbType.Int32, pItem.IdProyectoServicio);
            db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
            db.AddInParameter(dbCommand, "pTotalDscCumpleanios", DbType.Decimal, pItem.TotalDscCumpleanios);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaWeb(PedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaWeb");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCampana", DbType.Int32, pItem.IdCampana);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdPedidoReferencia", DbType.Int32, pItem.IdPedidoReferencia); //Add
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pFechaCancelacion", DbType.DateTime, pItem.FechaCancelacion);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdClienteAsociado", DbType.Int32, pItem.IdClienteAsociado);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pTotalCantidad", DbType.Int32, pItem.TotalCantidad);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPorcentajeImpuesto", DbType.Double, pItem.PorcentajeImpuesto);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pTotalBruto", DbType.Decimal, pItem.TotalBruto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pDespachar", DbType.String, pItem.Despachar);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, pItem.IdTipoVenta);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pIdAsesorExterno", DbType.Int32, pItem.IdAsesorExterno);
            db.AddInParameter(dbCommand, "pFlagPreventa", DbType.Boolean, pItem.FlagPreVenta);
            db.AddInParameter(dbCommand, "pFlagImpresionRus", DbType.Boolean, pItem.FlagImpresionRus);
            db.AddInParameter(dbCommand, "pIdContratoFabricacion", DbType.Int32, pItem.IdContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdProyectoServicio", DbType.Int32, pItem.IdProyectoServicio);
            db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdPedidoWeb", DbType.Int32, pItem.IdPedidoWEB);

            db.ExecuteNonQuery(dbCommand);
        }


        public void ActualizaSituacion(int IdEmpresa, int IdPedido, int IdSituacion, int IdPersona, string Motivo, string Usuario, string Maquina)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pMotivo", DbType.String, Motivo);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion2(int IdEmpresa, int IdPedido, int IdSituacion, int IdPersona, string Motivo, string Usuario, string Maquina)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaSituacion2");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pMotivo", DbType.String, Motivo);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacionPrestashop(int IdEmpresa, int IdPedido, int IdSituacion, int IdPersona, string Motivo, string Usuario, string Maquina)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaSituacionPrestashop");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacionAlmacen(int IdEmpresa, int IdPedido, int IdSituacionAlmacen, string Usuario, string Maquina)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaSituacionAlmacen");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pIdSituacionAlmacen", DbType.Int32, IdSituacionAlmacen);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdPedido, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaClienteDireccion(int IdCliente, string Direccion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaClienteDireccion");

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, Direccion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaImpresion(int IdPedido, bool FlagImpresion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaImpresion");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pFlagImpresion", DbType.Int32, FlagImpresion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaCompraPerfecta(int IdPedido, int IdVendedorTitular, int IdVendedorAsesor, bool FlagCompraPerfecta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaCompraPerfecta");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedorTitular);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, IdVendedorAsesor);
            db.AddInParameter(dbCommand, "pFlagCompraPerfecta", DbType.Boolean, FlagCompraPerfecta);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaFlagAuditado(int IdPedido, bool FlagAuditado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizaAuditoria");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pFlagAuditado", DbType.Boolean, FlagAuditado);

            db.ExecuteNonQuery(dbCommand);

        }


        public void Elimina(PedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_Elimina");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public List<PedidoBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCampana = Int32.Parse(reader["idCampana"].ToString());
                Pedido.DescCampana = reader["DescCampana"].ToString();
                Pedido.Periodo = Int32.Parse(reader["periodo"].ToString());
                Pedido.Mes = Int32.Parse(reader["mes"].ToString());
                Pedido.IdProforma = reader.IsDBNull(reader.GetOrdinal("IdProforma")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProforma"));
                Pedido.NumeroProforma = reader["NumeroProforma"].ToString();
                Pedido.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pedido.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Pedido.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal("FechaCancelacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCancelacion"));
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pedido.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Pedido.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                Pedido.Descuento = Decimal.Parse(reader["descuento"].ToString());
                Pedido.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Pedido.Igv = Decimal.Parse(reader["igv"].ToString());
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                Pedido.Observacion = reader["observacion"].ToString();
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaContado(int IdEmpresa, int IdTienda, DateTime Fecha, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaContado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.IdTipoDocumentoCliente = Int32.Parse(reader["IdTipoDocumentoCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoDocumentoClienteAsociado = Int32.Parse(reader["IdTipoDocumentoClienteAsociado"].ToString());
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.TiposCliente = (reader["TiposCliente"].ToString());

                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.FlagImpresionRus = Boolean.Parse(reader["FlagImpresionRus"].ToString());
                Pedido.IdAsesorExterno = Int32.Parse(reader["IdAsesorExterno"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaContadoWeb(int IdEmpresa, int IdTienda, DateTime Fecha, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaContadoWeb");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.IdTipoDocumentoCliente = Int32.Parse(reader["IdTipoDocumentoCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoDocumentoClienteAsociado = Int32.Parse(reader["IdTipoDocumentoClienteAsociado"].ToString());
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.FlagImpresionRus = Boolean.Parse(reader["FlagImpresionRus"].ToString());
                Pedido.IdAsesorExterno = Int32.Parse(reader["IdAsesorExterno"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }



        public List<PedidoBE> ListaContadoAlmacen(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaContadoAlmacen");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.DescAuxiliar = reader["DescAuxiliar"].ToString();
                Pedido.NumeroModificacion = reader["NumeroModificacion"].ToString();
                Pedido.NumeroLiberacion = reader["NumeroLiberacion"].ToString();
                Pedido.FlagImpresion = Boolean.Parse(reader["FlagImpresion"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaContadoAlmacenLiberacionNum(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaContadoAlmacenLiberacionNum");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                //Pedido.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                //Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                //Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                //Pedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                //Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                //Pedido.Numero = reader["numero"].ToString();
                //Pedido.DescTienda = reader["DescTienda"].ToString();
                //Pedido.DescCliente = reader["DescCliente"].ToString();
                //Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                //Pedido.CodMoneda = reader["CodMoneda"].ToString();
                //Pedido.DescVendedor = reader["DescVendedor"].ToString();
                //Pedido.Total = Decimal.Parse(reader["total"].ToString());
                //Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                //Pedido.DescSituacion = reader["DescSituacion"].ToString();
                //Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                //Pedido.DescAuxiliar = reader["DescAuxiliar"].ToString();
                Pedido.NumeroModificacion = reader["NumeroLiberacion"].ToString();
                //Pedido.NumeroLiberacion = reader["NumeroLiberacion"].ToString();
                //Pedido.FlagImpresion = Boolean.Parse(reader["FlagImpresion"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaContadoAlmacenNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaContadoAlmacenNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.DescAuxiliar = reader["DescAuxiliar"].ToString();
                Pedido.NumeroModificacion = reader["NumeroModificacion"].ToString();
                Pedido.FlagImpresion = Boolean.Parse(reader["FlagImpresion"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaCredito(DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaCredito");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Pedido.IdMotivo = Int32.Parse(reader["idMotivo"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                //      Pedido.NumDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagEstadoCuenta = Boolean.Parse(reader["FlagEstadoCuenta"].ToString());
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.DisponiblePorcentaje = Decimal.Parse(reader["DisponiblePorcentaje"].ToString());
                Pedido.DescRuta = reader["DescRuta"].ToString();
                Pedido.NumeroPedidoReferencia = reader["NumeroPedidoReferencia"].ToString();
                Pedido.Destino = reader["Destino"].ToString();

                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaCreditoNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaCreditoNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagEstadoCuenta = Boolean.Parse(reader["FlagEstadoCuenta"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaVendedor(DateTime FechaDesde, DateTime FechaHasta, int IdVendedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaVendedor");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.Add_user = reader["Add_user"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaPedidos(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_PrePedidos_ListaFechas");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                Pedido.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.Mes = Int32.Parse(reader["Mes"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                //Pedido.NumPedidoWeb = reader["NumPedidoWeb"].ToString();
                //Pedido.IdPedidoPanorama = Int32.Parse(reader["IdPedidoPanorama"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                //Pedido.FecPedPanorama = reader["FecPedidoPano"].ToString();

                Pedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.IdAlmacen = Int32.Parse(reader["idalmacen"].ToString());
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DesTipoCliente = reader["DesTipoCliente"].ToString();
                Pedido.ModalidadPago = reader["ModalidadPago"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["Total"].ToString());
                Pedido.NumDocumento = reader["NumeroDocumento"].ToString();
                Pedido.Direccion = reader["Direccion"].ToString();
                Pedido.DireccionEnvio = reader["DireccionEnvio"].ToString();
                Pedido.Ciudad = reader["Ciudad"].ToString();
                Pedido.Distrito = reader["Distrito"].ToString();
                Pedido.Correo = reader["CorreoWeb"].ToString();
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.TelMovil = reader["TelMovil"].ToString();
                Pedido.Telfijo = reader["Telfijo"].ToString();
                Pedido.ModalidadEnvio = Int32.Parse(reader["ModalidadEnvio"].ToString());
                Pedido.RefOtro = reader["RefOtro"].ToString();
                Pedido.TarifaEnvio = Decimal.Parse(reader["TarifaEnvio"].ToString());
                Pedido.Estado = reader["Estado"].ToString();
                Pedido.FlagProcesado = Boolean.Parse(reader["FlagProcesado"].ToString());
                Pedido.FlagCliente = Boolean.Parse(reader["FlagCliente"].ToString());
                Pedido.FlagPago = Boolean.Parse(reader["FlagPago"].ToString());
                Pedido.FechaPago = reader["FechaPago"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
        public List<PedidoBE> ListaFechaPrePedidosWeb(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_PrePedidosWeb_ListaFechas");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPPedido = Int32.Parse(reader["IdPPedido"].ToString());
                Pedido.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.Mes = Int32.Parse(reader["Mes"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.NumPedidoWeb = reader["NumPedidoWeb"].ToString();
                Pedido.IdPedidoPanorama = Int32.Parse(reader["IdPedidoPanorama"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.FechaPedPanorama = reader["FechaPedidoPano"].ToString(); /// reader["FecPedidoPano"].ToString();    
                Pedido.CompPago = reader["ComprobantePago"].ToString(); /// reader["FecPedidoPano"].ToString();    


                Pedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.IdAlmacen = Int32.Parse(reader["idalmacen"].ToString());
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DesTipoCliente = reader["DesTipoCliente"].ToString();
                Pedido.ModalidadPago = reader["ModalidadPago"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["Total"].ToString());
                Pedido.NumDocumento = reader["NumeroDocumento"].ToString();
                Pedido.Direccion = reader["Direccion"].ToString();
                Pedido.DireccionEnvio = reader["DireccionEnvio"].ToString();
                Pedido.Ciudad = reader["Ciudad"].ToString();
                Pedido.Distrito = reader["Distrito"].ToString();
                Pedido.Correo = reader["CorreoWeb"].ToString();
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.TelMovil = reader["TelMovil"].ToString();
                Pedido.Telfijo = reader["Telfijo"].ToString();
                Pedido.ModalidadEnvio = Int32.Parse(reader["ModalidadEnvio"].ToString());
                Pedido.RefOtro = reader["RefOtro"].ToString();
                Pedido.TarifaEnvio = Decimal.Parse(reader["TarifaEnvio"].ToString());
                Pedido.Estado = reader["Estado"].ToString();
                Pedido.FlagProcesado = Boolean.Parse(reader["FlagProcesado"].ToString());
                Pedido.FlagCliente = Boolean.Parse(reader["FlagCliente"].ToString());
                Pedido.FlagPago = Boolean.Parse(reader["FlagPago"].ToString());
                Pedido.FechaPago = reader["FechaPago"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["Situacion"].ToString();
                Pedido.EstadoActual = reader["EstadoActual"].ToString();
                Pedido.PaisLocalidad = reader["PaisLocalidad"].ToString();
                Pedido.DirReferencia = reader["Referencia"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }


        public List<PedidoBE> ListaFechaSituacion(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaSituacion");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagImpresion = bool.Parse(reader["FlagImpresion"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.DescDespachador = reader["DescDespachador"].ToString();
                Pedido.Add_user = reader["add_user"].ToString();
                Pedido.UsuarioAprobo = reader["UsuarioAprobo"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaCalidad(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion, int TipoConsulta, int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaCalidad");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagImpresion = bool.Parse(reader["FlagImpresion"].ToString());
                Pedido.FlagIniCalidad = bool.Parse(reader["FlagIniCalidad"].ToString());
                Pedido.FechaIniCalidad = reader.IsDBNull(reader.GetOrdinal("FechaIniCalidad")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIniCalidad"));
                Pedido.FlagFinCalidad = bool.Parse(reader["FlagFinCalidad"].ToString());
                Pedido.FechaFinCalidad = reader.IsDBNull(reader.GetOrdinal("FechaFinCalidad")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFinCalidad"));
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.DescPersonaCalidad = reader["DescPersonaCalidad"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaSituacion2(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaSituacion");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.FlagImpresion = bool.Parse(reader["FlagImpresion"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.DescDespachador = reader["DescDespachador"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaSituacionAlmacen(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion, int IdSituacionAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaSituacionAlmacen");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pIdSituacionAlmacen", DbType.Int32, IdSituacionAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.DescSituacionAlmacen = reader["DescSituacionAlmacen"].ToString();
                Pedido.Conductor = reader["Conductor"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaCliente(DateTime FechaDesde, DateTime FechaHasta, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaCliente");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaContratoFabricacion(int IdContratoFabricacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaContratoFabricacion");
            db.AddInParameter(dbCommand, "pIdContratoFabricacion", DbType.Int32, IdContratoFabricacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaProyecto(int IdProyecto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaProyecto");
            db.AddInParameter(dbCommand, "pIdProyecto", DbType.Int32, IdProyecto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaClientePorCobrar(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaClientePorCobrarEstadoCuenta");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Usuario = reader["Usuario"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Pedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.DescCliente = reader["DescCliente"].ToString();
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
                //Pedido.Chequeado = Boolean.Parse(reader["Chequeado"].ToString());
                Pedido.Add_user = reader["add_user"].ToString();
                Pedido.UsuarioAprobo = reader["UsuarioAprobo"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaResumen(DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaResumen");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["CantidadPedido"].ToString());
                Pedido.TotalBruto = Int32.Parse(reader["CantidadAutoservicio"].ToString());
                Pedido.Total = Decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.Cantidad = Int32.Parse(reader["CantidadVendedor"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaChequeo(DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaChequeado");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.Chequeado = Boolean.Parse(reader["Chequeado"].ToString());
                Pedido.FechaChequeado = DateTime.Parse(reader["FechaChequeado"].ToString());
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.Items = Int32.Parse(reader["Items"].ToString());
                Pedido.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                Pedido.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                Pedido.PorcentajeChequeo = Decimal.Parse(reader["PorcentajeChequeo"].ToString());
                Pedido.DescPicking = reader["DescPicking"].ToString();
                Pedido.DescChequeador = reader["DescChequeador"].ToString();
                Pedido.DescEmbalador = reader["DescEmbalador"].ToString();
                Pedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.FechaPreparacion = reader.IsDBNull(reader.GetOrdinal("FechaPreparacion")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparacion"));
                Pedido.FechaPreparado = reader.IsDBNull(reader.GetOrdinal("FechaPreparado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparado"));
                Pedido.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                Pedido.FechaChequeado2 = reader.IsDBNull(reader.GetOrdinal("FechaChequeado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeado"));

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaArmado(DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaFechaArmado");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Pedido.NombreProducto = reader["NombreProducto"].ToString();
                Pedido.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Pedido.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                Pedido.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.FlagArmado = Boolean.Parse(reader["FlagArmado"].ToString());
                Pedido.Observacion = reader["Observacion"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }


        //Estado de Cuenta

        #region "Creditos y cobranzas"


        public List<PedidoBE> ListaFechaEstadoCuenta(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaEstadoCuenta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Pedido.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.NumeroCredito = reader["NumeroCredito"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Pedido.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaEstadoCuentaPedido(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaEstadoCuentaPedido");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumeroPedido", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Pedido.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.NumeroCredito = reader["NumeroCredito"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Pedido.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaFechaDocumentoEstadoCuenta(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaDocumentoEstadoCuenta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Pedido.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.NumeroCredito = reader["NumeroCredito"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Pedido.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                Pedido.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaDocumentoEstadoCuentaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaDocumentoEstadoCuentaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Pedido.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.NumeroCredito = reader["NumeroCredito"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Pedido.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                Pedido.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaDocumentoEstadoCuentaConcepto(int Periodo, string Concepto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ListaDocumentoEstadoCuentaConcepto");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, Concepto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Pedido.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.NumeroCredito = reader["NumeroCredito"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Pedido.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                Pedido.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        #endregion

        public PedidoBE Selecciona(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_Selecciona");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCampana = Int32.Parse(reader["idCampana"].ToString());
                Pedido.DescCampana = reader["DescCampana"].ToString();
                Pedido.Periodo = Int32.Parse(reader["periodo"].ToString());
                Pedido.Mes = Int32.Parse(reader["mes"].ToString());
                Pedido.IdProforma = reader.IsDBNull(reader.GetOrdinal("IdProforma")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProforma"));
                Pedido.NumeroProforma = reader["NumeroProforma"].ToString();
                Pedido.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pedido.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.IdPedidoReferencia = reader.IsDBNull(reader.GetOrdinal("IdPedidoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedidoReferencia"));
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Pedido.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal("FechaCancelacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCancelacion"));
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.IdClienteAsociado = reader.IsDBNull(reader.GetOrdinal("IdClienteAsociado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdClienteAsociado"));
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Pedido.IdSituacionCliente = Int32.Parse(reader["IdSituacionCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();

                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.DireccionAsociado = reader["DireccionAsociado"].ToString();

                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pedido.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Pedido.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                Pedido.Descuento = Decimal.Parse(reader["descuento"].ToString());
                Pedido.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Pedido.Igv = Decimal.Parse(reader["igv"].ToString());
                Pedido.Icbper = Decimal.Parse(reader["Icbper"].ToString());
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                Pedido.Observacion = reader["observacion"].ToString();
                Pedido.IdCombo = Int32.Parse(reader["IdCombo"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.IdAsesor = Int32.Parse(reader["IdAsesor"].ToString());
                Pedido.IdAsesorExterno = Int32.Parse(reader["IdAsesorExterno"].ToString());
                Pedido.DescAsesor = reader["DescAsesor"].ToString();
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.FlagImpresion = Boolean.Parse(reader["FlagImpresion"].ToString());
                Pedido.FlagImpresionRus = Boolean.Parse(reader["FlagImpresionRus"].ToString());
                Pedido.FlagCompraPerfecta = Boolean.Parse(reader["FlagCompraPerfecta"].ToString());
                Pedido.FlagAuditado = Boolean.Parse(reader["FlagAuditado"].ToString());
                Pedido.NumeroLiberacion = reader["NumeroLiberacion"].ToString();
                Pedido.IdContratoFabricacion = reader.IsDBNull(reader.GetOrdinal("IdContratoFabricacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdContratoFabricacion"));
                Pedido.IdProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProyectoServicio"));
                Pedido.IdNovioRegalo = reader.IsDBNull(reader.GetOrdinal("IdNovioRegalo")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdNovioRegalo"));
                Pedido.FlagPtFlores = Boolean.Parse(reader["FlagPtFlores"].ToString());
                Pedido.FlagCumpleanios = Boolean.Parse(reader["FlagCumpleanios"].ToString());
                Pedido.TotalDscCumpleanios = Decimal.Parse(reader["TotalDscCumpleanios"].ToString());
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pedido.IdPedidoWeb = Int32.Parse(reader["IdPedidoWeb"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public PedidoBE SeleccionaPedidoPrestashop(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_SeleccionaPedidoPrestashop");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPedido = Int32.Parse(reader["IdPPedido"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public PedidoBE SeleccionaWeb(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PedidoWeb_Selecciona");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            //1124226
            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCampana = Int32.Parse(reader["idCampana"].ToString());
                Pedido.DescCampana = reader["DescCampana"].ToString();
                Pedido.Periodo = Int32.Parse(reader["periodo"].ToString());
                Pedido.Mes = Int32.Parse(reader["mes"].ToString());
                Pedido.IdProforma = reader.IsDBNull(reader.GetOrdinal("IdProforma")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProforma"));
                Pedido.NumeroProforma = reader["NumeroProforma"].ToString();
                Pedido.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pedido.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.IdPedidoReferencia = reader.IsDBNull(reader.GetOrdinal("IdPedidoReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedidoReferencia"));
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Pedido.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal("FechaCancelacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCancelacion"));
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.IdClienteAsociado = reader.IsDBNull(reader.GetOrdinal("IdClienteAsociado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdClienteAsociado"));
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Pedido.IdSituacionCliente = Int32.Parse(reader["IdSituacionCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();

                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.DireccionAsociado = reader["DireccionAsociado"].ToString();

                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pedido.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Pedido.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                Pedido.Descuento = Decimal.Parse(reader["descuento"].ToString());
                Pedido.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Pedido.Igv = Decimal.Parse(reader["igv"].ToString());
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                Pedido.Observacion = reader["observacion"].ToString();
                Pedido.IdCombo = Int32.Parse(reader["IdCombo"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.IdAsesor = Int32.Parse(reader["IdAsesor"].ToString());
                Pedido.IdAsesorExterno = Int32.Parse(reader["IdAsesorExterno"].ToString());
                Pedido.DescAsesor = reader["DescAsesor"].ToString();
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.FlagImpresion = Boolean.Parse(reader["FlagImpresion"].ToString());
                Pedido.FlagImpresionRus = Boolean.Parse(reader["FlagImpresionRus"].ToString());
                Pedido.FlagCompraPerfecta = Boolean.Parse(reader["FlagCompraPerfecta"].ToString());
                Pedido.FlagAuditado = Boolean.Parse(reader["FlagAuditado"].ToString());
                Pedido.NumeroLiberacion = reader["NumeroLiberacion"].ToString();
                Pedido.IdContratoFabricacion = reader.IsDBNull(reader.GetOrdinal("IdContratoFabricacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdContratoFabricacion"));
                Pedido.IdProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProyectoServicio"));
                Pedido.IdNovioRegalo = reader.IsDBNull(reader.GetOrdinal("IdNovioRegalo")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdNovioRegalo"));
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public PedidoBE SeleccionaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_SeleccionaNumero");

            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCampana = Int32.Parse(reader["idCampana"].ToString());
                Pedido.DescCampana = reader["DescCampana"].ToString();
                Pedido.Periodo = Int32.Parse(reader["periodo"].ToString());
                Pedido.Mes = Int32.Parse(reader["mes"].ToString());
                Pedido.IdProforma = reader.IsDBNull(reader.GetOrdinal("IdProforma")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProforma"));
                Pedido.NumeroProforma = reader["NumeroProforma"].ToString();
                Pedido.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pedido.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Pedido.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal("FechaCancelacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCancelacion"));
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.IdClienteAsociado = reader.IsDBNull(reader.GetOrdinal("IdClienteAsociado")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdClienteAsociado"));
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Pedido.IdTipoDocumentoCliente = Int32.Parse(reader["IdTipoDocumentoCliente"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();

                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.DireccionAsociado = reader["DireccionAsociado"].ToString();

                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pedido.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Pedido.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                Pedido.Descuento = Decimal.Parse(reader["descuento"].ToString());
                Pedido.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Pedido.Igv = Decimal.Parse(reader["igv"].ToString());
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                Pedido.Observacion = reader["observacion"].ToString();
                Pedido.IdCombo = Int32.Parse(reader["IdCombo"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.IdAsesorExterno = Int32.Parse(reader["IdAsesorExterno"].ToString());
                Pedido.FlagCumpleanios = Boolean.Parse(reader["FlagCumpleanios"].ToString());
                Pedido.TotalDscCumpleanios = Decimal.Parse(reader["TotalDscCumpleanios"].ToString());
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public PedidoBE SeleccionaClientePreventa(int Periodo, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_SeleccionaClientePreventa");

            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public PedidoBE SeleccionaImpresion(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_SeleccionaImpresion");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.FlagImpresion = Boolean.Parse(reader["FlagImpresion"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public PedidoBE SeleccionaSituacion(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_SeleccionaSituacion");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Numero = reader["idPedido"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.FlagImpresionRus = Boolean.Parse(reader["FlagImpresionRus"].ToString());
                Pedido.IdAsesorExterno = Int32.Parse(reader["IdAsesorExterno"].ToString());
                Pedido.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Pedido.Total = Decimal.Parse(reader["Total"].ToString());
                Pedido.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                Pedido.TotalDiferencia = Decimal.Parse(reader["TotalDiferencia"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public List<PedidoBE> ListaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.IdCampana = Int32.Parse(reader["idCampana"].ToString());
                Pedido.DescCampana = reader["DescCampana"].ToString();
                Pedido.Periodo = Int32.Parse(reader["periodo"].ToString());
                Pedido.Mes = Int32.Parse(reader["mes"].ToString());
                Pedido.IdProforma = reader.IsDBNull(reader.GetOrdinal("IdProforma")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProforma"));
                Pedido.NumeroProforma = reader["NumeroProforma"].ToString();
                Pedido.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pedido.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Pedido.FechaCancelacion = reader.IsDBNull(reader.GetOrdinal("FechaCancelacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCancelacion"));
                Pedido.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                Pedido.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();
                Pedido.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pedido.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.IdVendedor = Int32.Parse(reader["idVendedor"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Pedido.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                Pedido.Descuento = Decimal.Parse(reader["descuento"].ToString());
                Pedido.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Pedido.Igv = Decimal.Parse(reader["igv"].ToString());
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                Pedido.Observacion = reader["observacion"].ToString();
                Pedido.IdCombo = Int32.Parse(reader["IdCombo"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.DescSituacionAlmacen = reader["DescSituacionAlmacen"].ToString();
                Pedido.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Pedido.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                Pedido.FlagAuditado = Boolean.Parse(reader["FlagAuditado"].ToString());
                Pedido.FlagCompraPerfecta = Boolean.Parse(reader["FlagCompraPerfecta"].ToString());
                Pedido.FechaAuditado = reader.IsDBNull(reader.GetOrdinal("FechaAuditado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAuditado"));
                Pedido.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pedido.Chequeado = Boolean.Parse(reader["Chequeado"].ToString());
                Pedido.DescDespachador = reader["DescDespachador"].ToString();
                Pedido.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Pedido.Add_user = reader["add_user"].ToString();
                Pedido.UsuarioAprobo = reader["UsuarioAprobo"].ToString();

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaPedidoClientesMayoristasFecha(DateTime FechaDesde, DateTime FechaHasta, int IdRuta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoClientesMayoristasFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, IdRuta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescRuta = reader["DescRuta"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<PedidoBE> ListaNumeroChequeo(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_SeleccionaNumeroChequeo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PedidoBE> Pedidolist = new List<PedidoBE>();
            PedidoBE Pedido;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.Numero = reader["numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.Chequeado = Boolean.Parse(reader["Chequeado"].ToString());
                Pedido.FechaChequeado = DateTime.Parse(reader["FechaChequeado"].ToString());
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.Items = Int32.Parse(reader["Items"].ToString());
                Pedido.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                Pedido.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                Pedido.PorcentajeChequeo = Decimal.Parse(reader["PorcentajeChequeo"].ToString());
                Pedido.DescPicking = reader["DescPicking"].ToString();
                Pedido.DescChequeador = reader["DescChequeador"].ToString();
                Pedido.DescEmbalador = reader["DescEmbalador"].ToString();
                Pedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.FechaPreparacion = reader.IsDBNull(reader.GetOrdinal("FechaPreparacion")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparacion"));
                Pedido.FechaPreparado = reader.IsDBNull(reader.GetOrdinal("FechaPreparado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparado"));
                Pedido.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                Pedido.FechaChequeado2 = reader.IsDBNull(reader.GetOrdinal("FechaChequeado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeado"));
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }


        public void Actualizar_PedidoWeb(int parIdPedidoWeb, int parIdCliente, String parNumeroDocumento, String parDescCliente, String parDireccion, Int32 parFlagCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PrePedidoWeb_Actualiza_Cliente");

            db.AddInParameter(dbCommand, "pIdPedidoWeb", DbType.Int32, parIdPedidoWeb);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, parIdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, parNumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, parDescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, parDireccion);
            db.AddInParameter(dbCommand, "pFlagCliente", DbType.Int32, parFlagCliente);

            db.ExecuteNonQuery(dbCommand);
        }

        public void RegistroPagoPedidoWeb(int parIdPedidoWeb, DateTime parFecPago, String parNumOperacion, String parObs)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PrePedidoWeb_RegistroPago");

            db.AddInParameter(dbCommand, "pIdPedidoWeb", DbType.Int32, parIdPedidoWeb);
            db.AddInParameter(dbCommand, "pFecPago", DbType.Date, parFecPago);
            db.AddInParameter(dbCommand, "pNumOperacion", DbType.String, parNumOperacion);
            db.AddInParameter(dbCommand, "pObs", DbType.String, parObs);

            db.ExecuteNonQuery(dbCommand);
        }

        public PedidoBE SeleccionaPedidoAsociadoCF(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConsultaCFAsociado_Pedido");

            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PedidoBE Pedido = null;
            while (reader.Read())
            {
                Pedido = new PedidoBE();
                Pedido.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Pedido;
        }

        public void Eliminar_cumpleanios(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_Eliminar_cumpleanios");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}