using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using DevExpress.XtraBars;
using ErpPanorama.Presentation.Modulos.Maestros.Rpt;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Logistica.Rpt;
using ErpPanorama.Presentation.Modulos.Creditos.Rpt;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Rpt;
using ErpPanorama.Presentation.Modulos.Contabilidad.Rpt;
using ErpPanorama.Presentation.Modulos.DiseñoInteriores.Rpt;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Rpt;
using ErpPanorama.Presentation.Modulos.KiraHogar.Rpt;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity.Reportes;
using ErpPanorama.Presentation.Modulos.Ecommerce.Rpt;

namespace ErpPanorama.Presentation
{
    public partial class RptVistaReportes : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        #region "Propiedades"

        #endregion

        #region Eventos

        public RptVistaReportes()
        {
            InitializeComponent();
        }

        private void RptVistaReportes_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Metodos

        public void VerRptAccesoUsuario(List<ReporteAccesoUsuarioBE> lstReporte)
        {
            rptAccesoUsuario objReporte = new rptAccesoUsuario();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptLineaProducto(List<ReporteLineaProductoBE> lstReporte)
        {
            rptLineaProducto objReporte = new rptLineaProducto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSector(List<ReporteSectorBE> lstReporte)
        {
            rptSector objReporte = new rptSector();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptRuta(List<ReporteRutaBE> lstReporte)
        {
            rptRuta objReporte = new rptRuta();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCampana(List<ReporteCampanaBE> lstReporte)
        {
            rptCampana objReporte = new rptCampana();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptBanco(List<ReporteBancoBE> lstReporte)
        {
            rptBanco objReporte = new rptBanco();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCaja(List<ReporteCajaBE> lstReporte)
        {
            rptCaja objReporte = new rptCaja();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptBloque(List<ReporteBloqueBE> lstReporte)
        {
            rptBloque objReporte = new rptBloque();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCuentaBanco(List<ReporteCuentaBancoBE> lstReporte)
        {
            rptCuentaBanco objReporte = new rptCuentaBanco();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPiso(List<ReportePisoBE> lstReporte)
        {
            rptPiso objReporte = new rptPiso();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptNumeracionDocumento(List<ReporteNumeracionDocumentoBE> lstReporte)
        {
            rptNumeracionDocumento objReporte = new rptNumeracionDocumento();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTablaElemento(List<ReporteTablaElementoBE> lstReporte)
        {
            rptTablaElemento objReporte = new rptTablaElemento();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTienda(List<ReporteTiendaBE> lstReporte)
        {
            rptTienda objReporte = new rptTienda();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTipoCambio(List<ReporteTipoCambioBE> lstReporte)
        {
            rptTipoCambio objReporte = new rptTipoCambio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTipoDocumento(List<ReporteTipoDocumentoBE> lstReporte)
        {
            rptTipoDocumento objReporte = new rptTipoDocumento();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptUbicacion(List<ReporteUbicacionBE> lstReporte)
        {
            rptUbicacion objReporte = new rptUbicacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptUbicacionProducto(List<ReporteUbicacionProductoBE> lstReporte)
        {
            rptUbicacionProducto objReporte = new rptUbicacionProducto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSolicitudProducto(List<ReporteSolicitudProductoBE> lstReporte)
        {
            rptSolicitudProducto1 objReporte = new rptSolicitudProducto1();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSolicitudProductoAsesoria(List<ReporteSolicitudProductoBE> lstReporte)
        {
            rptSolicitudProductoAsesoria objReporte = new rptSolicitudProductoAsesoria();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptGuiaRemision(List<ReporteGuiaRemisionBE> lstReporte)
        {
            rptGuiaRemision objReporte = new rptGuiaRemision();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptBulto(List<ReporteBultoBE> lstReporte)
        {
            rptBulto objReporte = new rptBulto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMaterial(List<ReporteMaterialBE> lstReporte)
        {
            rptMaterial objReporte = new rptMaterial();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProducto(List<ReporteProductoBE> lstReporte)
        {
            rptProducto objReporte = new rptProducto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteCredito(List<ReporteClienteCreditoBE> lstReporte)
        {
            rptClienteCredito objReporte = new rptClienteCredito();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCajaVacia(List<ReporteCajaVaciaBE> lstReporte)
        {
            rptCajaVacia objReporte = new rptCajaVacia();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTransferenciaBulto(List<ReporteTransferenciaBultoBE> lstReporte)
        {
            rptTransferenciaBulto objReporte = new rptTransferenciaBulto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPersonal(List<ReportePersonaBE> lstReporte)
        {
            rptPersonal objReporte = new rptPersonal();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEmpresa(List<ReporteEmpresaBE> lstReporte)
        {
            rptEmpresa objReporte = new rptEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptUnidadMedida(List<ReporteUnidadMedidaBE> lstReporte)
        {
            rptUnidadMedida objReporte = new rptUnidadMedida();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProveedor(List<ReporteProveedorBE> lstReporte)
        {
            rptProveedor objReporte = new rptProveedor();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptFacturaCompra(List<ReporteFacturaCompraBE> lstReporte)
        {
            rptFacturaCompra objReporte = new rptFacturaCompra();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCotizacionKira(List<CotizacionKiraBE> lstReporte)
        {
            rptCotizacionkira objReporte = new rptCotizacionkira();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCotizacionKiraProductoTerminado(List<CotizacionKiraProductoTerminadoBE> lstReporte)
        {
            rptCotizacionkiraProducto objReporte = new rptCotizacionkiraProducto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptFacturaCompraStock(List<ReporteFacturaCompraBE> lstReporte)
        {
            rptFacturaCompraStock objReporte = new rptFacturaCompraStock();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptAlmacen(List<ReporteAlmacenBE> lstReporte)
        {
            rptAlmacen objReporte = new rptAlmacen();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptModeloProducto(List<ReporteModeloProductoBE> lstReporte)
        {
            rptModeloProducto objReporte = new rptModeloProducto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMarca(List<ReporteMarcaBE> lstReporte)
        {
            rptMarca objReporte = new rptMarca();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProcedencia(List<ReporteProcedenciaBE> lstReporte)
        {
            rptProcedencia objReporte = new rptProcedencia();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteMayorista(List<ReporteClienteMayoristaBE> lstReporte)
        {
            //rptClienteMayorista objReporte = new rptClienteMayorista();
            //objReporte.SetDataSource(lstReporte);
            //this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteMinorista(List<ReporteClienteMinoristaBE> lstReporte)
        {
            //rptClienteMinorista objReporte = new rptClienteMinorista();
            //objReporte.SetDataSource(lstReporte);
            //this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoAlmacen(List<ReporteMovimientoAlmacenBE> lstReporte)
        {
            //rptMovimientoAlmacen objReporte = new rptMovimientoAlmacen();
            //objReporte.SetDataSource(lstReporte);
            //this.crystalReportViewer1.ReportSource = objReporte;
        }

        //public void VerRptNotaSalida(List<ErpPanoramaServicios.ReporteNotaSalidaBE> lstReporte)
        //{
        //    rptNotaSalida objReporte = new rptNotaSalida();
        //    objReporte.SetDataSource(lstReporte);
        //    this.crystalReportViewer1.ReportSource = objReporte;
        //}

        public void VerRptNotaSalida(List<ReporteNotaSalidaBE> lstReporte)
        {
            rptNotaSalida objReporte = new rptNotaSalida();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptNotaIngreso(List<ReporteNotaSalidaBE> lstReporte)
        {
            rptNotaIngreso objReporte = new rptNotaIngreso();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMermas(List<ReporteMovimientoAlmacenMermasBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptMermas objReporte = new rptMermas();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptFaltaOrigen(List<ReporteMovimientoAlmacenFaltanteOrigenBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptFaltanteOrigen objReporte = new rptFaltanteOrigen();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteGeneral(List<ReporteClienteListaGeneralBE> lstReporte)
        {
            rptClienteGeneral objReporte = new rptClienteGeneral();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTalon(List<ReporteTalonBE> lstReporte)
        {
            rptTalon objReporte = new rptTalon();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptKardexBulto(List<ReporteKardexBultoBE> lstReporte)
        {
            rptKardexBulto objReporte = new rptKardexBulto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInventarioBulto(List<ReporteInventarioBultoBE> lstReporte)
        {
            rptInventarioBulto objReporte = new rptInventarioBulto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInventarioBultoBloque(List<ReporteInventarioBultoBE> lstReporte)
        {
            rptInventarioBultoBloque objReporte = new rptInventarioBultoBloque();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInventario(List<ReporteInventarioBE> lstReporte)
        {
            rptInventario objReporte = new rptInventario();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInventarioPersonal(List<ReporteInventarioBE> lstReporte)
        {
            rptInventarioPersonal objReporte = new rptInventarioPersonal();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptBultosTransferidos(List<ReporteBultosTransferidosBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptTransferenciaBulto objReporte = new rptTransferenciaBulto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoCaja(List<ReporteMovimientoCajaBE> lstReporte)
        {
            rptMovimientoCaja objReporte = new rptMovimientoCaja();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoCaja_Cajeros(List<ReporteMovimientoCajaBE> lstReporte)
        {
            rptMovimientoCaja_Cajeros objReporte = new rptMovimientoCaja_Cajeros();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProformaVenta(List<ReporteProformaBE> lstReporte)
        {
            rptProforma objReporte = new rptProforma();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoContado(List<ReportePedidoContadoBE> lstReporte, string Equipo, string Usuario)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pEquipo = new ParameterField();
            pEquipo.ParameterFieldName = "Equipo";
            ParameterDiscreteValue ValueEquipo = new ParameterDiscreteValue();
            ValueEquipo.Value = Equipo;
            pEquipo.CurrentValues.Add(ValueEquipo);
            paramFields.Add(pEquipo);

            ParameterField pUsuario = new ParameterField();
            pUsuario.ParameterFieldName = "Usuario";
            ParameterDiscreteValue ValueUsuario = new ParameterDiscreteValue();
            ValueUsuario.Value = Usuario;
            pUsuario.CurrentValues.Add(ValueUsuario);
            paramFields.Add(pUsuario);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptTransferenciaBulto objReporte = new rptTransferenciaBulto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteMayoristaVendedor(List<ReporteClienteMayoristaVendedorBE> lstReporte, string DescVendedor)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pVendedor = new ParameterField();
            pVendedor.ParameterFieldName = "DescVendedor";
            ParameterDiscreteValue ValueVendedor = new ParameterDiscreteValue();
            ValueVendedor.Value = DescVendedor;
            pVendedor.CurrentValues.Add(ValueVendedor);
            paramFields.Add(pVendedor);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptClienteMayoristaVendedor objReporte = new rptClienteMayoristaVendedor();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteMayoristaVendedorAsociado(List<ReporteClienteMayoristaVendedorBE> lstReporte, string DescVendedor)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pVendedor = new ParameterField();
            pVendedor.ParameterFieldName = "DescVendedor";
            ParameterDiscreteValue ValueVendedor = new ParameterDiscreteValue();
            ValueVendedor.Value = DescVendedor;
            pVendedor.CurrentValues.Add(ValueVendedor);
            paramFields.Add(pVendedor);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptClienteMayoristaVendedorAsociado objReporte = new rptClienteMayoristaVendedorAsociado();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteMayoristaVendedorCompra(List<ReporteClienteMayoristaVendedorBE> lstReporte, string DescVendedor)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pVendedor = new ParameterField();
            pVendedor.ParameterFieldName = "DescVendedor";
            ParameterDiscreteValue ValueVendedor = new ParameterDiscreteValue();
            ValueVendedor.Value = DescVendedor;
            pVendedor.CurrentValues.Add(ValueVendedor);
            paramFields.Add(pVendedor);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptClienteMayoristaVendedorCompra objReporte = new rptClienteMayoristaVendedorCompra();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        //public void VerRptProductoCatalogo(List<ErpPanoramaServicios.ReporteProductoCatalogoBE> lstReporte)
        //{
        //    rptProductoCatalogo objReporte = new rptProductoCatalogo();
        //    objReporte.SetDataSource(lstReporte);
        //    this.crystalReportViewer1.ReportSource = objReporte;
        //}

        public void VerRptProductoCatalogoPedido(List<ReporteProductoCatalogoPedidoBE> lstReporte)
        {
            rptProductoCatalogoPedido objReporte = new rptProductoCatalogoPedido();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoPedidoSinPrecio(List<ReporteProductoCatalogoPedidoBE> lstReporte)
        {
            rptProductoCatalogoPedidoSinPrecio objReporte = new rptProductoCatalogoPedidoSinPrecio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoProforma(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProforma objReporte = new rptProductoCatalogoProforma();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }
        public void rptProductoCatalogosProformaSinProcedencia(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogosProformaSinProcedencia objReporte = new rptProductoCatalogosProformaSinProcedencia();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void rptProductoCatalogosProformaCantidad(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogosProformaCantidad objReporte = new rptProductoCatalogosProformaCantidad();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void rptProductoCatalogosProformaCantidadAB(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformaPrecioAB_Cantidad objReporte = new rptProductoCatalogoProformaPrecioAB_Cantidad();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void rptProductoCatalogosProformaCantidadCD(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformaPrecioCD_Cantidad objReporte = new rptProductoCatalogoProformaPrecioCD_Cantidad();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoProformasinPrecio(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformasinPrecio objReporte = new rptProductoCatalogoProformasinPrecio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoProformaPrecioABCD(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformaPrecioABCD objReporte = new rptProductoCatalogoProformaPrecioABCD();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoProformaPrecioAB(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformaPrecioAB objReporte = new rptProductoCatalogoProformaPrecioAB();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoProformaPrecioCD(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformaPrecioCD objReporte = new rptProductoCatalogoProformaPrecioCD();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoInvBulto(List<ReporteProductoCatologoInvBultoBE> lstReporte)
        {
            //rptProductoCatologoInvBulto objReporte = new rptProductoCatologoInvBulto();
            rptProductoCatalogoProforma objReporte = new rptProductoCatalogoProforma();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoNovioRegalo(List<ReporteProductoCatalogoNovioRegaloBE> lstReporte)
        {
            rptProductoCatalogoProformaPrecioCD objReporte = new rptProductoCatalogoProformaPrecioCD();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }



        public void VerRptPedidoSoles(List<ReportePedidoSolesBE> lstReporte, string Usuario)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pUsuario = new ParameterField();
            pUsuario.ParameterFieldName = "Usuario";
            ParameterDiscreteValue ValueUsuario = new ParameterDiscreteValue();
            ValueUsuario.Value = Usuario;
            pUsuario.CurrentValues.Add(ValueUsuario);
            paramFields.Add(pUsuario);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoSoles objReporte = new rptPedidoSoles();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoSolesMayorista(List<ReportePedidoSolesBE> lstReporte, string Usuario)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pUsuario = new ParameterField();
            pUsuario.ParameterFieldName = "Usuario";
            ParameterDiscreteValue ValueUsuario = new ParameterDiscreteValue();
            ValueUsuario.Value = Usuario;
            pUsuario.CurrentValues.Add(ValueUsuario);
            paramFields.Add(pUsuario);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoSolesMayorista objReporte = new rptPedidoSolesMayorista();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoDolares(List<ReportePedidoDolaresBE> lstReporte, string Usuario)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pUsuario = new ParameterField();
            pUsuario.ParameterFieldName = "Usuario";
            ParameterDiscreteValue ValueUsuario = new ParameterDiscreteValue();
            ValueUsuario.Value = Usuario;
            pUsuario.CurrentValues.Add(ValueUsuario);
            paramFields.Add(pUsuario);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoDolares objReporte = new rptPedidoDolares();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoTienda(List<ReportePedidoTiendaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoTienda objReporte = new rptPedidoTienda();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoTiendaMesTipoClienteVariacion(List<ReportePedidoTiendaMesTipoClienteVariacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoTiendaMesTipoClienteVariacion objReporte = new rptPedidoTiendaMesTipoClienteVariacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedor(List<ReportePedidoVendedorBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoVendedor objReporte = new rptPedidoVendedor();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteRegistroVendedor(List<ReporteClienteRegistroVendedorBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptClienteRegistroVendedor objReporte = new rptClienteRegistroVendedor();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMuestra(List<ReporteMuestraBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoMuestra objReporte = new rptPedidoMuestra();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorTipoCliente(List<ReportePedidoVendedorTipoClienteBE> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoVendedorTipoCliente objReporte = new rptPedidoVendedorTipoCliente();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorTipoClienteDisenio(List<ReportePedidoVendedorTipoClienteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoVendedorDisenio objReporte = new rptPedidoVendedorDisenio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptPedidoAvanceMeta(List<ReporteAvanceMeta> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoAvanceMeta objReporte = new rptPedidoAvanceMeta();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoAvanceMetaCartera(List<ReporteAvanceMeta> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSueldoJefeCampo objReporte = new rptSueldoJefeCampo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSueldoVendedorCartera(List<ReporteAvanceMeta> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoAvanceMetaVendedorCartera objReporte = new rptPedidoAvanceMetaVendedorCartera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSueldoVendPiso(List<ReporteAvanceMeta> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSueldoVendPiso objReporte = new rptSueldoVendPiso();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSueldoAsesorVentasDigital(List<ReporteAvanceMeta> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSueldoVendDigital objReporte = new rptSueldoVendDigital();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSueldoDiseñoInterior(List<ReporteAvanceMeta> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSueldoDiseñoInterior objReporte = new rptSueldoDiseñoInterior();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoAvanceMetaDisenio(List<ReporteAvanceMeta> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoAvanceMetaDisenio objReporte = new rptPedidoAvanceMetaDisenio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptSueldoAdmUcayali(List<ReporteSueldoAdmUcayali> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSueldoAdmUcayali objReporte = new rptSueldoAdmUcayali();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSueldoSubAdmUcayali(List<ReporteSueldoAdmUcayali> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSueldoSubAdmUcayali objReporte = new rptSueldoSubAdmUcayali();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSueldoJefeCampo(List<ReporteSueldoAdmUcayali> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSueldoJefeCampo objReporte = new rptSueldoJefeCampo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSueldoAdmOtrasTiendas(List<ReporteSueldoAdmUcayali> lstReporte, string TipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pTipoCliente = new ParameterField();
            pTipoCliente.ParameterFieldName = "TipoCliente";
            ParameterDiscreteValue ValueTipoCliente = new ParameterDiscreteValue();
            ValueTipoCliente.Value = TipoCliente;
            pTipoCliente.CurrentValues.Add(ValueTipoCliente);
            paramFields.Add(pTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSueldoAdmOtrasTiendas objReporte = new rptSueldoAdmOtrasTiendas();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoTipoClienteOperador(List<ReportePedidoTipoClienteOperadorBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoGestion objReporte = new rptPedidoGestion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoContadoOperador(List<ReportePedidoContadoOperadorBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoContadoOperador objReporte = new rptPedidoContadoOperador();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptVentaProducto(List<ReporteVentaProductoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptVentaProducto objReporte = new rptVentaProducto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptVentaProductoResumen(List<ReporteVentaProductoBE> lstReporte, string FechaIni, string FechaFin, int Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (Resumen == 1)
            {
                rptVentaProductoResumen objReporte = new rptVentaProductoResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptVentaProductoGrafico objReporte = new rptVentaProductoGrafico();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }

        }

        public void VerRptVentaProductoRentabilidad(List<ReporteVentaProductoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptVentaProductoRentabilidad objReporte = new rptVentaProductoRentabilidad();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;


        }

        public void VerRptVentaProductoDias(List<ReporteVentaProductoBE> lstReporte, string FechaIni, string FechaFin, int Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (Resumen == 1)
            {
                rptVentaProductoDiasResumen objReporte = new rptVentaProductoDiasResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptVentaProductoDias objReporte = new rptVentaProductoDias();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }

        }

        public void VerRptListadoCompra(List<ReporteListadoCompraBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptListadoCompra objReporte = new rptListadoCompra();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoTiendaMesTipoCliente(List<ReportePedidoTiendaMesTipoClienteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoTiendaMesTipoCliente objReporte = new rptPedidoTiendaMesTipoCliente();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoTiendaComparativo(List<ReportePedidoTiendaMesTipoClienteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoTiendaComparativo objReporte = new rptPedidoTiendaComparativo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }
        public void VerRptPedidoTiendaMesTipoClienteLineaProducto(List<ReportePedidoTiendaMesTipoClienteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoTiendaMesTipoClienteLineaProducto objReporte = new rptPedidoTiendaMesTipoClienteLineaProducto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptClienteRegistroVendedorDetalle(List<ReporteClienteRegistroVendedorDetalleBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptClienteRegistroVendedorDetalle objReporte = new rptClienteRegistroVendedorDetalle();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorFormaPago(List<ReportePedidoVendedorFormaPagoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoVendedorFormaPago objReporte = new rptPedidoVendedorFormaPago();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDocumentoVenta(List<ReporteDocumentoVentaBE> lstReporte, int IdTipoDocumento)
        {
            if (IdTipoDocumento == Parametros.intTipoDocBoletaVenta)
            {
                rptBoletaPanorama objReporte = new rptBoletaPanorama();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            if (IdTipoDocumento == Parametros.intTipoDocFacturaVenta)
            {
                rptFacturaPanorama objReporte = new rptFacturaPanorama();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptDocumentoVentaElectronica(List<ReporteDocumentoVentaElectronicaBE> lstReporte, int IdTipoDocumento)
        {
            if (IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
            {
                rptFacturaElectronicaPanoramaA4 objReporte = new rptFacturaElectronicaPanoramaA4();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            if (IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
            {
                rptNotaCreditoElectronicaPanoramaA4 objReporte = new rptNotaCreditoElectronicaPanoramaA4();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            if (IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
            {

                rptGuiaRemisionPanoramaElectronica objReporte = new rptGuiaRemisionPanoramaElectronica();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptDocumentoGuiaElectronica(List<ReporteDocumentoVentaElectronicaBE> lstReporte, int IdTipoDocumento, int parIdEmpresa)
        {
            if (parIdEmpresa == 13)
            {
                rptGuiaRemisionPanoramaElectronica objReporte = new rptGuiaRemisionPanoramaElectronica();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptGuiaRemisionPanoramaElectronicaRER objReporte = new rptGuiaRemisionPanoramaElectronicaRER();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptDocumentoVentaElectronicaRER(List<ReporteDocumentoVentaElectronicaBE> lstReporte, int IdTipoDocumento)
        {
            if (IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
            {
                rptFacturaElectronicaPanoramaA4RER objReporte = new rptFacturaElectronicaPanoramaA4RER();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            if (IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
            {
                rptNotaCreditoElectronicaPanoramaA4RER objReporte = new rptNotaCreditoElectronicaPanoramaA4RER();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            if (IdTipoDocumento == Parametros.intTipoDocGuiaElectronica)
            {
                rptGuiaRemisionPanoramaElectronicaRER objReporte = new rptGuiaRemisionPanoramaElectronicaRER();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptDocumentoReferencia(List<ReporteDocumentoReferenciaBE> lstReporte, int IdTipoDocumento)
        {
            rptNotaCreditoPanorama objReporte = new rptNotaCreditoPanorama();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoRutaMes(List<ReportePedidoRutaMesBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoRutaMes objReporte = new rptPedidoRutaMes();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCambio(List<ReporteCambioBE> lstReporte)
        {
            rptCambio objReporte = new rptCambio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCambioCambio(List<ReporteCambioBE> lstReporte)
        {
            rptCambioCambio objReporte = new rptCambioCambio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCambioReparacion(List<ReporteCambioBE> lstReporte)
        {
            rptCambioReparacion objReporte = new rptCambioReparacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoRutaSemana(List<ReportePedidoRutaSemanaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoRutaSemana objReporte = new rptPedidoRutaSemana();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoRutaAnio(List<ReportePedidoRutaAnioBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoRutaAnio objReporte = new rptPedidoRutaAnio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoRutaDia(List<ReportePedidoRutaDiaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoRutaDia objReporte = new rptPedidoRutaDia();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptConsolidadoCambio(List<ReporteCambioBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptConsolidadoCambio objReporte = new rptConsolidadoCambio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptConsolidadoPedidoPreventa(List<ReportePedidoPreventaDetalleBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoPreventaConsolidado objReporte = new rptPedidoPreventaConsolidado();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptPedidoPreventa(List<ReportePedidoPreventaBE> lstReporte, string FechaIni, string FechaFin, int TipoReporte)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (TipoReporte == 0)
            {
                rptPedidoPreventa objReporte = new rptPedidoPreventa();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptPedidoPreventaPedidoCodigo objReporte = new rptPedidoPreventaPedidoCodigo();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }

        }



        public void VerRptMetas(List<ReporteMetasBE> lstReporte)
        {
            rptMetas objReporte = new rptMetas();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorCartera(List<ReportePedidoVendedorCarteraBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoVendedorCartera objReporte = new rptPedidoVendedorCartera();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorJuniorSenior(List<ReportePedidoVendedorJuniorSeniorBE> lstReporte, string FechaIni, string FechaFin, Int32 Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            if (Resumen == 0)
            {
                rptPedidoVendedorJuniorSenior objReporte = new rptPedidoVendedorJuniorSenior();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 1)
            {
                rptPedidoVendedorJuniorSeniorResumen objReporte = new rptPedidoVendedorJuniorSeniorResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 2)
            {
                rptPedidoVendedorJuniorSeniorSueldo objReporte = new rptPedidoVendedorJuniorSeniorSueldo();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 3)
            {
                rptPedidoVendedorJuniorSeniorAvance objReporte = new rptPedidoVendedorJuniorSeniorAvance();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }

        }

        public void VerRptPedidoVentaTiendaTipoClientePorCargo(List<ReportePedidoVentaTiendaTipoClientePorCargoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoVentaTiendaTipoClientePorCargo objReporte = new rptPedidoVentaTiendaTipoClientePorCargo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptPedidoMayoristas(List<ReportePedidoMayoristasBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoMayoristas objReporte = new rptPedidoMayoristas();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoFactura(List<ReporteProductoCatalogoFacturaBE> lstReporte)
        {
            rptProductoCatalogoFactura objReporte = new rptProductoCatalogoFactura();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoFacturaSoles(List<ReporteProductoCatalogoFacturaBE> lstReporte)
        {
            rptProductoCatalogoFacturaSoles objReporte = new rptProductoCatalogoFacturaSoles();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoFacturaSinPrecio(List<ReporteProductoCatalogoFacturaBE> lstReporte)
        {
            rptProductoCatalogoFacturaSinPrecio objReporte = new rptProductoCatalogoFacturaSinPrecio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorCarteraMeta(List<ReportePedidoVendedorCarteraMetaBE> lstReporte, string FechaIni, string FechaFin, Int32 Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (Resumen == 0)
            {
                rptPedidoVendedorCarteraMetaDetalle objReporte = new rptPedidoVendedorCarteraMetaDetalle();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 1)
            {
                rptPedidoVendedorCarteraMeta objReporte = new rptPedidoVendedorCarteraMeta();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 2)
            {
                rptPedidoVendedorCarteraMetaSueldo objReporte = new rptPedidoVendedorCarteraMetaSueldo();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }

        public void VerRptPedidoTipoVenta(List<ReportePedidoTipoVentaBE> lstReporte, string FechaIni, string FechaFin, string Tventa, Int32 Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            ParameterField pTventa = new ParameterField();
            pTventa.ParameterFieldName = "Tventa";
            ParameterDiscreteValue ValuepTventa = new ParameterDiscreteValue();
            ValuepTventa.Value = Tventa;
            pTventa.CurrentValues.Add(ValuepTventa);
            paramFields.Add(pTventa);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (Resumen == 0)
            {
                rptPedidoTipoVentaDetalle objReporte = new rptPedidoTipoVentaDetalle();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptPedidoTipoVenta objReporte = new rptPedidoTipoVenta();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptDocumentoVentaEmpresaTraslado(List<ReporteDocumentoVentaBE> lstReporte, int IdTipoDocumento)
        {
            if (IdTipoDocumento == Parametros.intTipoDocBoletaVentaTraslado)
            {
                rptBoletaPanoramaTraslado objReporte = new rptBoletaPanoramaTraslado();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }

            if (IdTipoDocumento == Parametros.intTipoDocFacturaVentaTraslado)
            {
                rptFacturaPanoramaTraslado objReporte = new rptFacturaPanoramaTraslado();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptGuiaEmpresaTraslado(List<ReporteDocumentoVentaBE> lstReporte, string DirecciondirFac, string dirGuia)
        {
            rptGuiaRemisionTrasladoPanorama objReporte = new rptGuiaRemisionTrasladoPanorama();
            objReporte.SetDataSource(lstReporte);
            objReporte.SetParameterValue("dirFac", DirecciondirFac);
            objReporte.SetParameterValue("dirGuia", dirGuia);

            this.crystalReportViewer1.ReportSource = objReporte;


        }

        public void VerRptArea(List<ReporteAreaBE> lstReporte)
        {
            rptArea objReporte = new rptArea();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptKardexSalidas(List<ReporteKardexSalidasBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptKardexSalidas objReporte = new rptKardexSalidas();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoClienteDaot(List<ReportePedidoClienteDaotBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoClienteDaot objReporte = new rptPedidoClienteDaot();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoClienteDaotDetalle(List<ReportePedidoClienteDaotDetalleBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoClienteDaotDetalle objReporte = new rptPedidoClienteDaotDetalle();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTopeEmpresa(List<TopeEmpresaBE> lstReporte)
        {
            rptTopeEmpresa objReporte = new rptTopeEmpresa();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEstadoCuenta(List<ReporteEstadoCuentaCabeceraBE> lstReporte, List<ReporteEstadoCuentaDetalleBE> lstEstadoCuentaDetalle, string TipoVenta)
        {
            rptEstadoCuenta objReporte = new rptEstadoCuenta();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptEstadoCuentaDetalle.rpt").SetDataSource(lstEstadoCuentaDetalle);

            objReporte.SetParameterValue("TipoVenta", TipoVenta);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSeparacion(List<ReporteSeparacionCabeceraBE> lstReporte, List<ReporteSeparacionDetalleBE> lstSeparacionDetalle, string TipoVenta)
        {
            rptSeparacion objReporte = new rptSeparacion();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptSeparacionDetalle.rpt").SetDataSource(lstSeparacionDetalle);

            objReporte.SetParameterValue("TipoVenta", TipoVenta);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptMovimientoCajaTienda(List<ReporteMovimientoCajaBE> lstReporte)
        {
            rptMovimientoCajaTienda objReporte = new rptMovimientoCajaTienda();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCotizacion(List<ReporteCotizacionBE> lstReporte, List<ReporteCotizacionBE> lstReporteDetalle)
        {
            rptCotizacion objReporte = new rptCotizacion();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptFormatoCotizacion.rpt").SetDataSource(lstReporteDetalle);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoCargoCredito(List<ReportePedidoCargoCreditoBE> lstReporte, List<ReportePedidoCargoCreditoBE> lstReporteDetalle)
        {
            rptPedidoCargoCredito objReporte = new rptPedidoCargoCredito();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptFormatoPedidoCargoCredito.rpt").SetDataSource(lstReporteDetalle);
            this.crystalReportViewer1.ReportSource = objReporte;
        }



        public void VerRptMovimientoCajaTarjeta(List<ReporteMovimientoCajaBE> lstReporte, List<ReporteMovimientoCajaBE> lstReporteTarjeta)
        {
            rptMovimientoCaja objReporte = new rptMovimientoCaja();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptMovimientoCajaTarjeta.rpt").SetDataSource(lstReporteTarjeta);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoCajaTarjetaDocumento(List<ReporteMovimientoCajaBE> lstReporte, List<ReporteMovimientoCajaBE> lstReporteTarjeta)
        {
            rptMovimientoCajaDocumento objReporte = new rptMovimientoCajaDocumento();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptMovimientoCajaTarjeta.rpt").SetDataSource(lstReporteTarjeta);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoCajaTarjetaDocumentoResumen(List<ReporteMovimientoCajaBE> lstReporte, List<ReporteMovimientoCajaBE> lstReporteTarjeta)
        {
            rptMovimientoCajaResumen objReporte = new rptMovimientoCajaResumen();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptMovimientoCajaTarjeta.rpt").SetDataSource(lstReporteTarjeta);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoCajaTarjetaDocumentoTienda(List<ReporteMovimientoCajaBE> lstReporte, List<ReporteMovimientoCajaBE> lstReporteTarjeta)
        {
            rptMovimientoCajaDocumentoTienda objReporte = new rptMovimientoCajaDocumentoTienda();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptMovimientoCajaTarjeta.rpt").SetDataSource(lstReporteTarjeta);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoCajaDocumento(List<ReporteMovimientoCajaBE> lstReporte)
        {
            rptMovimientoCajaDocumento objReporte = new rptMovimientoCajaDocumento();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoCajaDocumentoTienda(List<ReporteMovimientoCajaBE> lstReporte)
        {
            rptMovimientoCajaDocumentoTienda objReporte = new rptMovimientoCajaDocumentoTienda();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEstadoCuentaNumeroDias(List<ReporteEstadoCuentaNumeroDiasBE> lstReporte)
        {
            rptEstadoCuentaNumeroDias objReporte = new rptEstadoCuentaNumeroDias();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEstadoCuentaCreditoVencido(List<ReporteCreditoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptEstadoCuentaCreditoVencido objReporte = new rptEstadoCuentaCreditoVencido();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEstadoCuentaCreditoMensual(List<ReporteCreditoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptEstadoCuentaCreditoMensual objReporte = new rptEstadoCuentaCreditoMensual();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEstadoCuentaCreditoMensualTodos(List<ReporteCreditoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptEstadoCuentaCreditoMensualTodos objReporte = new rptEstadoCuentaCreditoMensualTodos();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCreditoTotal(List<ReporteCreditoTotalBE> lstReporte)
        {
            rptCreditoTotal objReporte = new rptCreditoTotal();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptCreditoPorCobrar(List<ReporteCreditoPorCobrarBE> lstReporte)
        {
            rptCreditoPorCobrar objReporte = new rptCreditoPorCobrar();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEstadoCuentaCreditoPago(List<ReporteCreditoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptEstadoCuentaCreditoPago objReporte = new rptEstadoCuentaCreditoPago();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptEstadoCuentaContraEntrega(List<ReporteEstadoCuentaContraEntregaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptEstadoCuentaContraEntrega objReporte = new rptEstadoCuentaContraEntrega();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSeparacionContraEntrega(List<ReporteSeparacionContraEntregaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptSeparacionContraEntrega objReporte = new rptSeparacionContraEntrega();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoClientesMayoristasFecha(List<ReportePedidoClientesMayoristasFechaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoClientesMayoristasFecha objReporte = new rptPedidoClientesMayoristasFecha();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoPedido(List<ReporteMovimientoPedidoBE> lstReporte)
        {
            rptMovimientoPedido objReporte = new rptMovimientoPedido();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoCambioFecha(List<ReportePedidoCambioFechaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoCambioFecha objReporte = new rptPedidoCambioFecha();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInventarioBultoSector(List<ReporteInventarioBultoSectorBE> lstReporte)
        {
            rptInventarioBultoSector objReporte = new rptInventarioBultoSector();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInventarioBultoSectorRecibido(List<ReporteInventarioBultoSectorBE> lstReporte)
        {
            rptInventarioBultoSectorRecibido objReporte = new rptInventarioBultoSectorRecibido();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptInventarioBultoAnaqueles(List<ReporteInventarioBultoSectorBE> lstReporte)
        {
            rptInventarioBultoAnaqueles objReporte = new rptInventarioBultoAnaqueles();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }



        public void VerRptInventarioBultoSectorStock(List<ReporteInventarioBultoSectorStockBE> lstReporte)
        {
            rptInventarioBultoSectorStock objReporte = new rptInventarioBultoSectorStock();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptRotacionProductos(List<ReporteRotacionProductosBE> lstReporte, string FechaIni, string FechaFin, int Tipo)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            ParameterField pTitulo = new ParameterField();
            pTitulo.ParameterFieldName = "Titulo";
            ParameterDiscreteValue ValueTitulo = new ParameterDiscreteValue();
            if (Tipo == 0)
                ValueTitulo.Value = "LISTADO MAYOR ROTACIÓN DE PRODUCTOS";
            else
                ValueTitulo.Value = "LISTADO PRODUCTOS SIN ROTACIÓN";
            pTitulo.CurrentValues.Add(ValueTitulo);
            paramFields.Add(pTitulo);


            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptRotacionProductos objReporte = new rptRotacionProductos();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptRotacionProductosPorTienda2(List<ReporteRotacionProductosBE> lstReporte, string FechaIni, string FechaFin, int Tipo)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            ParameterField pTitulo = new ParameterField();
            pTitulo.ParameterFieldName = "Titulo";
            ParameterDiscreteValue ValueTitulo = new ParameterDiscreteValue();
            if (Tipo == 0)
                ValueTitulo.Value = "LISTADO MAYOR ROTACIÓN DE PRODUCTOS POR TIENDA";
            else
                ValueTitulo.Value = "LISTADO PRODUCTOS SIN ROTACIÓN POR TIENDA";
            pTitulo.CurrentValues.Add(ValueTitulo);
            paramFields.Add(pTitulo);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptRotacionProductosPorTienda2 objReporte = new rptRotacionProductosPorTienda2();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptRotacionProductosPorTienda(List<ReporteRotacionProductosBE> lstReporte, string FechaIni, string FechaFin, int Tipo)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            ParameterField pTitulo = new ParameterField();
            pTitulo.ParameterFieldName = "Titulo";
            ParameterDiscreteValue ValueTitulo = new ParameterDiscreteValue();
            if (Tipo == 0)
                ValueTitulo.Value = "LISTADO MAYOR ROTACIÓN DE PRODUCTOS POR TIENDA";
            else
                ValueTitulo.Value = "LISTADO PRODUCTOS SIN ROTACIÓN POR TIENDA";
            pTitulo.CurrentValues.Add(ValueTitulo);
            paramFields.Add(pTitulo);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptRotacionProductosPorTienda objReporte = new rptRotacionProductosPorTienda();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }
        public void VerRptMetasLineaProducto(List<ReporteMetasLineaProductoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptMetasLineaProducto objReporte = new rptMetasLineaProducto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMetasLineaProductoDiario(List<ReporteMetasLineaProductoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptMetasLineaProductoDiario objReporte = new rptMetasLineaProductoDiario();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDevolucionMayoristas(List<ReporteDevolucionesMayoristasBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptDevolucionMayoristas objReporte = new rptDevolucionMayoristas();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDevolucionMayoristasRuta(List<ReporteDevolucionesMayoristasRutaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptDevolucionMayoristasRuta objReporte = new rptDevolucionMayoristasRuta();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptStockRegular(List<ReporteStockBultosBE> lstReporte)
        {
            rptStockRegular objReporte = new rptStockRegular();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptStockNavidad(List<ReporteStockBultosBE> lstReporte)
        {
            rptStockNavidad objReporte = new rptStockNavidad();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoPreventaVendedor(List<ReportePedidoPreVentaVendedorBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoPreventaVendedor objReporte = new rptPedidoPreventaVendedor();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoCredito(List<ReportePedidoCreditoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoCredito objReporte = new rptPedidoCredito();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTiendaAutoservicio(List<ReporteTiendaAutoservicioBE> lstReporte, string FechaIni, string FechaFin, int TipoReporte)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (TipoReporte == 0)
            {
                rptTiendaAutoservicio objReporte = new rptTiendaAutoservicio();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptTiendaAutoservicioDetalle objReporte = new rptTiendaAutoservicioDetalle();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }


        }

        public void VerRptDis_ProyectoServicio(List<ReporteDis_ProyectoServicioBE> lstReporte)
        {
            rptDis_ProyectoServicio objReporte = new rptDis_ProyectoServicio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDis_DisenoFuncional(List<ReporteDis_DisenoFuncionalBE> lstReporte)
        {
            rptDis_DisenoFuncional objReporte = new rptDis_DisenoFuncional();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDis_DisenoEstetico(List<ReporteDis_DisenoEsteticoBE> lstReporte)
        {
            rptDis_DisenoEstetico objReporte = new rptDis_DisenoEstetico();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDis_ProyectoServicioContrato(List<ReporteDis_ProyectoServicioContratoBE> lstReporte)
        {
            rptDis_ProyectoServicioContrato objReporte = new rptDis_ProyectoServicioContrato();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDis_ProyectoServicioContratoFabricacion(List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte)
        {
            rptDis_ProyectoServicioContratoFabricacion objReporte = new rptDis_ProyectoServicioContratoFabricacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDis_ProyectoServicioContratoFabricacionSinFoto(List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte)
        {
            rptDis_ProyectoServicioContratoFabricacionSinFoto objReporte = new rptDis_ProyectoServicioContratoFabricacionSinFoto();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDis_ProyectoServicioContratoFabricacionSinPrecio(List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte)
        {
            rptDis_ProyectoServicioContratoFabricacionSinPrecio objReporte = new rptDis_ProyectoServicioContratoFabricacionSinPrecio();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptDocumentoVentaEmpresaSerie(List<ReporteDocumentoVentaEmpresaSerieBE> lstReporte, string FechaIni, string FechaFin, int Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (Resumen == 0) //ResumenSerie
            {
                rptDocumentoVentaEmpresaSerie objReporte = new rptDocumentoVentaEmpresaSerie();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 1)
            {
                rptDocumentoVentaEmpresaSerieResumen objReporte = new rptDocumentoVentaEmpresaSerieResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 2)
            {
                rptDocumentoVentaTipoDocumentoResumen objReporte = new rptDocumentoVentaTipoDocumentoResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }


        }

        public void VerRptPedidoCreditoSituacion(List<ReportePedidoCreditoSituacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoCreditoSituacion objReporte = new rptPedidoCreditoSituacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorAsesoria(List<ReportePedidoVendedorAsesoriaBE> lstReporte, string FechaIni, string FechaFin, Int32 Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            if (Resumen == 0)
            {
                //rptPedidoVendedorAsesoria objReporte = new rptPedidoVendedorAsesoria();
                //objReporte.SetDataSource(lstReporte);
                //this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 1)
            {
                //rptPedidoVendedorAsesoriaResumen objReporte = new rptPedidoVendedorAsesoriaResumen();
                //objReporte.SetDataSource(lstReporte);
                //this.crystalReportViewer1.ReportSource = objReporte;
            }
            else if (Resumen == 2)
            {
                rptPedidoVendedorAsesoriaSueldo objReporte = new rptPedidoVendedorAsesoriaSueldo();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }

        public void VerRptCumpleanos(List<ReporteCumpleaniosBE> lstReporte, string Mes)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pMes = new ParameterField();
            pMes.ParameterFieldName = "Mes";
            ParameterDiscreteValue ValueMes = new ParameterDiscreteValue();
            ValueMes.Value = Mes;
            pMes.CurrentValues.Add(ValueMes);
            paramFields.Add(pMes);


            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptCumpleanios objReporte = new rptCumpleanios();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoProformaPrecioABHangtag(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformaPrecioABHangtag objReporte = new rptProductoCatalogoProformaPrecioABHangtag();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoProformaPrecioCDSinLogo(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformaPrecioCD_SinLogo objReporte = new rptProductoCatalogoProformaPrecioCD_SinLogo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductoCatalogoProformaSinPrecioSinLogo(List<ReporteProductoCatalogoProformaBE> lstReporte)
        {
            rptProductoCatalogoProformaSinPrecioSinLogo objReporte = new rptProductoCatalogoProformaSinPrecioSinLogo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        //--------------------------------------------------------------------------------------------------------

        public void VerRptListadoMorosos(List<ReporteCreditoBE> lstReporte)
        {
            rptEstadoCuentaCreditoMorosos objReporte = new rptEstadoCuentaCreditoMorosos();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptPedidoTiendaSupervisor(List<ReportePedidoTiendaSupervisorBE> lstReporte, string FechaIni, string FechaFin, Int32 Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            if (Resumen == 0)
            {
                //rptPedidoTiendaSupervisor objReporte = new rptPedidoTiendaSupervisor();
                //objReporte.SetDataSource(lstReporte);
                //this.crystalReportViewer1.ReportSource = objReporte;
            }

        }

        public void VerRptDiferenciaMovimientoCaja(List<ReporteMovimientoCajaBE> lstReporte)
        {
            rptMovimientoCajaDiferenciaDiario objReporte = new rptMovimientoCajaDiferenciaDiario();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptMovimientoAlmacenTransferencia(List<ReporteMovimientoAlmacenTransferenciaBE> lstReporte, string FechaIni, string FechaFin, int TipoReporte)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (TipoReporte == 0)
            {
                rptMovimientoAlmacenTransferencia objReporte = new rptMovimientoAlmacenTransferencia();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptMovimientoAlmacenTransferenciaResumen objReporte = new rptMovimientoAlmacenTransferenciaResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }

        }

        public void VerRptPedidoTiendaMesTipoClienteCanalVenta(List<ReportePedidoTiendaMesTipoClienteBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptPedidoTiendaMesTipoClienteCanalVenta objReporte = new rptPedidoTiendaMesTipoClienteCanalVenta();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorCaja(List<ReportePedidoVendedorCajaBE> lstReporte, string FechaIni, string FechaFin, Int32 Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            if (Resumen == 0)
            {
                rptPedidoVendedorCajaSueldo objReporte = new rptPedidoVendedorCajaSueldo();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }

        }

        public void VerRptKardexPorAlmacen(List<ReporteKardexAlmacenBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptKardexPorAlmacen objReporte = new rptKardexPorAlmacen();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSolicitudPrestamo(List<ReporteSolicitudPrestamoBE> lstReporte)
        {
            rptSolicitudPrestamo objReporte = new rptSolicitudPrestamo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSolicitudPrestamoPago(List<ReporteSolicitudPrestamoBE> lstReporte)
        {
            rptSolicitudPrestamoPago objReporte = new rptSolicitudPrestamoPago();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptSolicitudPrestamoVencido(List<ReporteSolicitudPrestamoBE> lstReporte, string FechaIni, string FechaFin, int Resumen)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (Resumen == 1)
            {
                rptSolicitudPrestamoVencidoResumen objReporte = new rptSolicitudPrestamoVencidoResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptSolicitudPrestamoVencido objReporte = new rptSolicitudPrestamoVencido();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }

        }

        public void VerRptEstadoCuentaCuentaBanco(List<ReporteEstadoCuentaCuentaBancoBE> lstReporte)
        {
            rptEstadoCuentaCuentaBanco objReporte = new rptEstadoCuentaCuentaBanco();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptVacacionesVendidas(List<ReporteVacacionesVendidasBE> lstReporte)
        {
            rptVacacionesVendidas objReporte = new rptVacacionesVendidas();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptVacaciones(List<ReporteVacacionesVendidasBE> lstReporte, string DescCargo, string DescArea)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pDescCargo = new ParameterField();
            pDescCargo.ParameterFieldName = "pDescCargo";
            ParameterDiscreteValue ValueDescCargo = new ParameterDiscreteValue();
            ValueDescCargo.Value = DescCargo;
            pDescCargo.CurrentValues.Add(ValueDescCargo);
            paramFields.Add(pDescCargo);

            ParameterField pDescArea = new ParameterField();
            pDescArea.ParameterFieldName = "pDescArea";
            ParameterDiscreteValue ValueDescArea = new ParameterDiscreteValue();
            ValueDescArea.Value = DescArea;
            pDescArea.CurrentValues.Add(ValueDescArea);
            paramFields.Add(pDescArea);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptVacaciones objReporte = new rptVacaciones();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptContratoPersona(List<ReporteContratoPersonaBE> lstReporte)
        {
            rtpContratoPersona objReporte = new rtpContratoPersona();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPersonaTrabajo(List<ReportePersonaTrabajoBE> lstReporte)
        {
            rptPersonaTrabajo objReporte = new rptPersonaTrabajo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }
        public void VerRptPersonaTrabajoSel(List<ReportePersonaTrabajoBE> lstReporte)
        {
            rptPersonaTrabajoSel objReporte = new rptPersonaTrabajoSel();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPersonaTrabajoFecha(List<ReportePersonaTrabajoBE> lstReporte, string FechaIni, string FechaFin, int TipoReporte)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (TipoReporte == 0)
            {
                rptPersonaTrabajoFecha objReporte = new rptPersonaTrabajoFecha();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptPersonaTrabajoFechaResumen objReporte = new rptPersonaTrabajoFechaResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }

        public void VerRptPersonaTrabajoPublicacion(List<ReportePersonaTrabajoBE> lstReporte)
        {
            rptPersonaTrabajoPublicacion objReporte = new rptPersonaTrabajoPublicacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptHojaInstalacion(List<ReporteHojaInstalacionBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptHojaInstalacion objReporte = new rptHojaInstalacion();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTarjetaVisaMasterCaja(List<ReporteTarjetaVisaMasterCajaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptTarjetaVisaMasterCaja objReporte = new rptTarjetaVisaMasterCaja();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptNovioRegalo(List<ReporteNovioRegaloBE> lstReporte)
        {
            rptNovioRegalo objReporte = new rptNovioRegalo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }
        public void VerRptNovioRegaloContrato(List<ReporteNovioRegaloBE> lstReporte)
        {
            rptNovioRegaloContrato objReporte = new rptNovioRegaloContrato();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptHoraExtraFecha(List<ReporteHoraExtraBE> lstReporte, string FechaIni, string FechaFin, int TipoReporte)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (TipoReporte == 0)
            {
                rptHoraExtra objReporte = new rptHoraExtra();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptHoraExtraResumen objReporte = new rptHoraExtraResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptComisionFecha(List<ReporteComisionJefeProduccionBE> lstReporte, string FechaIni, string FechaFin, int TipoReporte)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (TipoReporte == 0)
            {
                rptComisionJefeProduccion objReporte = new rptComisionJefeProduccion();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptHoraExtraResumen objReporte = new rptHoraExtraResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptProductividadOperador(List<ReporteProductividadOperadorBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptProductividadOperador objReporte = new rptProductividadOperador();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductividadOperadorV(List<ReporteProductividadOperadorVBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptProductividadOperadorV objReporte = new rptProductividadOperadorV();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptProductividadOperadorResumen(List<ReporteProductividadOperadorResumenBE> lstReporte, List<ReporteBultoTranferidoOperadorBE> lstBulto, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;


            rptProductividadOperadorResumen objReporte = new rptProductividadOperadorResumen();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptBultoOperador.rpt").SetDataSource(lstBulto); //add
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptPedidoVendedorPisoSueldo(List<ReportePedidoVendedorPisoSueldoBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptPedidoVendedorPisoSueldo objReporte = new rptPedidoVendedorPisoSueldo();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTicketPromedioVendedor(List<ReporteTicketVendedorBE> lstReporte, string FechaIni, string FechaFin, int TipoReporte)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (TipoReporte == 0)
            {
                rptTicketPromedioVendedor objReporte = new rptTicketPromedioVendedor();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptTicketPromedioVendedorResumen objReporte = new rptTicketPromedioVendedorResumen();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }

        public void VerRptTicketPromedioVendedorCartera(List<ReporteTicketVendedorBE> lstReporte, string FechaIni, string FechaFin, int TipoReporte)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            if (TipoReporte == 0)
            {
                rptTicketPromedioVendedorCartera objReporte = new rptTicketPromedioVendedorCartera();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
            else
            {
                rptTicketPromedioVendedorResumenCartera objReporte = new rptTicketPromedioVendedorResumenCartera();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            }
        }


        public void VerRptEstadoCuentaCliente(List<ReporteEstadoCuentaClienteCabBE> lstReporte, List<ReporteEstadoCuentaClienteDetBE> lstEstadoCuentaDetalle)
        {
            rptEstadoCuentaCliente objReporte = new rptEstadoCuentaCliente();
            objReporte.SetDataSource(lstReporte);
            objReporte.OpenSubreport("rptEstadoCuentaClienteDet.rpt").SetDataSource(lstEstadoCuentaDetalle);

            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptStockValorizado(List<ReporteStockValorizadoBE> lstReporte, string Fecha)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "Fecha";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = Fecha;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptStockValorizado objReporte = new rptStockValorizado();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptTarjetaIziPay(List<ReporteTarjetaIziPayBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptTarjetaIziPay2 objReporte = new rptTarjetaIziPay2();
            objReporte.SetDataSource(lstReporte);
            objReporte.Subreports[0].SetDataSource(lstReporte.Where(x => x.IdCondicionPago != Parametros.intCupon && x.IdCondicionPago != Parametros.intGiftCard));
            objReporte.Subreports[1].SetDataSource(lstReporte.Where(x => x.IdCondicionPago == Parametros.intCupon || x.IdCondicionPago == Parametros.intGiftCard));
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptHorarioPersona(List<ReporteHorarioPersonaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptHorarioPersona objReporte = new rptHorarioPersona();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptFacturacionRango(List<ReporteFacturacionBE> lstReporte, string DescTienda, string DescTipoCliente, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pDescTienda = new ParameterField();
            pDescTienda.ParameterFieldName = "DescTienda";
            ParameterDiscreteValue ValueDescTienda = new ParameterDiscreteValue();
            ValueDescTienda.Value = DescTienda;
            pDescTienda.CurrentValues.Add(ValueDescTienda);
            paramFields.Add(pDescTienda);

            ParameterField pDescTipoCliente = new ParameterField();
            pDescTipoCliente.ParameterFieldName = "DescTipoCliente";
            ParameterDiscreteValue ValueDescTipoCliente = new ParameterDiscreteValue();
            ValueDescTipoCliente.Value = DescTipoCliente;
            pDescTipoCliente.CurrentValues.Add(ValueDescTipoCliente);
            paramFields.Add(pDescTipoCliente);

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            rptFacturacionRango objReporte = new rptFacturacionRango();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptVacacionesDias(List<ReporteVacacionesDiasBE> lstReporte)
        {
            //rptVacacionesDias objReporte = new rptVacacionesDias();
            //objReporte.SetDataSource(lstReporte);
            //this.crystalReportViewer1.ReportSource = objReporte;
        }

        public void VerRptVacaciones2(List<ReporteVacacionesVendidasBE> lstReporte)
        {
            rptVacaciones objReporte = new rptVacaciones();
            objReporte.SetDataSource(lstReporte);
            this.crystalReportViewer1.ReportSource = objReporte;
        }


        public void VerRptVentasEcommerce(List<ReportePedidoTipoVentaBE> lstReporte, string FechaIni, string FechaFin)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField pFechaIni = new ParameterField();
            pFechaIni.ParameterFieldName = "FechaIni";
            ParameterDiscreteValue ValueFechaIni = new ParameterDiscreteValue();
            ValueFechaIni.Value = FechaIni;
            pFechaIni.CurrentValues.Add(ValueFechaIni);
            paramFields.Add(pFechaIni);

            ParameterField pFechaFin = new ParameterField();
            pFechaFin.ParameterFieldName = "FechaFin";
            ParameterDiscreteValue ValueFechaFin = new ParameterDiscreteValue();
            ValueFechaFin.Value = FechaFin;
            pFechaFin.CurrentValues.Add(ValueFechaFin);
            paramFields.Add(pFechaFin);

            //ParameterField pTventa = new ParameterField();
            //pTventa.ParameterFieldName = "Tventa";
            //ParameterDiscreteValue ValuepTventa = new ParameterDiscreteValue();
            //ValuepTventa.Value = Tventa;
            //pTventa.CurrentValues.Add(ValuepTventa);
            //paramFields.Add(pTventa);

            crystalReportViewer1.ParameterFieldInfo = paramFields;

            //if (Resumen == 0)
            //{
            rptVentasTotales objReporte = new rptVentasTotales();
                objReporte.SetDataSource(lstReporte);
                this.crystalReportViewer1.ReportSource = objReporte;
            //}
            //else
            //{
            //    rptPedidoTipoVenta objReporte = new rptPedidoTipoVenta();
            //    objReporte.SetDataSource(lstReporte);
            //    this.crystalReportViewer1.ReportSource = objReporte;
            //}
        }

        #endregion
    }

}