using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Funciones;
using System.Drawing.Printing;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegistroDocumentos: DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //public List<PrestamoBancoBE> lstPrestamoBanco;
        public List<CCajaEgresoDetalleDocumentos> mCajaEgresoDetalleDocumentosOrigen = new List<CCajaEgresoDetalleDocumentos>();
        public List<CCajaEgresoDetalleDocumentos2> mCajaEgresoDetalleDocumentosOrigen2 = new List<CCajaEgresoDetalleDocumentos2>();


        public int IdSituacionDocs = 0;
        public int IdEmpresa = 0;
        public string Empresa = "";
        public string NombreCaja = "";
        public string NumRecibo = "";
        public string NumDocumento = "";
        public string Nombres = "";
        public string ConceptoRef = "";
        public int IdMoneda = 0;
        public decimal ImporteSaldoInicial = 0;
        public int IdProveedor=0;
        public int IdCajaEgresoDetalleDocumento = 0;

        public int vIdTienda = 0;
        public int vIdTipoEgreso = 0;

        private int IdPersona = 0;
        private int IdCliente=0;
        private string Usuario = "";

        int _IdCajaEgreso  = 0;
        public int IdCajaEgreso 
        {
            get { return _IdCajaEgreso ; }
            set { _IdCajaEgreso  = value; }
        }

        int _IdCajaEgresoDetalle = 0;
        public int IdCajaEgresoDetalle
        {
            get { return _IdCajaEgresoDetalle; }
            set { _IdCajaEgresoDetalle = value; }
        }

        Decimal _MontoRecibo = 0;
        public Decimal MontoRecibo
        {
            get { return _MontoRecibo; }
            set { _MontoRecibo = value; }
        }
        Decimal _MontoDevolucion = 0;
        public Decimal MontoDevolucion
        {
            get { return _MontoDevolucion; }
            set { _MontoDevolucion = value; }
        }
        #endregion

        #region "Eventos"
        public frmRegistroDocumentos()
        {
            InitializeComponent();
        }

        private void frmRegistroDocumentos_Load(object sender, EventArgs e)
        {
            txtUnidadNegocio.Text = Empresa;
            txtNombres.Text = Nombres;
            //txtNumRecibo.Text = NumRecibo;
            cboFecha.EditValue = DateTime.Now;
            dteFechaFactura.EditValue= DateTime.Now;
            //txtMontoRecibo.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(MontoRecibo, 2)));
            BSUtils.LoaderLook(cboCentroCosto, new TablaBL().ListaTodosActivoCentroCosto(Parametros.intEmpresaId), "DescTabla", "IdTabla", true);
            cboCentroCosto.EditValue = 86;
            BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboTipoDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 91), "DescTablaElemento", "IdTablaElemento", true);
            txtSaldoRendir.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(ImporteSaldoInicial, 2)));  
            txtDevolucion.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(MontoDevolucion, 2)));

            BSUtils.LoaderLook(cboTipoEgreso, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 89), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoEgreso.EditValue = vIdTipoEgreso;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosTiendasActivo2(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = vIdTienda ;

            if (IdSituacionDocs==2)
            {
                simpleButton1.Enabled = false;
            }

            txtDescripcion.Text = ConceptoRef.ToString().Trim();
            CargaMovimientosCajaDetalle();
            CargaDetalleEgresos();
            CalculaTotales();
            CalculaTotalesEgresos();
        }

        private void CargaMovimientosCajaDetalle()
        {
            List<CajaEgresoDetalleDocumentosBE> lstTmpCajaEgresoDetalle = null;
            lstTmpCajaEgresoDetalle = new CajaEgresoDetalleDocumentosBL().ListaTodosActivo(IdCajaEgresoDetalle);

            foreach (CajaEgresoDetalleDocumentosBE item in lstTmpCajaEgresoDetalle)
            {
                CCajaEgresoDetalleDocumentos objE_SolicitudEgresoDetalleDocumentos = new CCajaEgresoDetalleDocumentos();

                objE_SolicitudEgresoDetalleDocumentos.IdCajaEgresoDetalle = item.IdCajaEgresoDetalle;
                objE_SolicitudEgresoDetalleDocumentos.IdCajaEgresoDetalleDocumentos = item.IdCajaEgresoDetalleDocumentos;
                objE_SolicitudEgresoDetalleDocumentos.IdArea = item.IdArea;
                objE_SolicitudEgresoDetalleDocumentos.Area = item.Area;
                objE_SolicitudEgresoDetalleDocumentos.Fecha = item.Fecha;
                objE_SolicitudEgresoDetalleDocumentos.NumDocProv = item.NumDocProv;
                objE_SolicitudEgresoDetalleDocumentos.DescProv = item.DescProv;
                objE_SolicitudEgresoDetalleDocumentos.FechaFactura = item.FechaFactura;
                objE_SolicitudEgresoDetalleDocumentos.Descripcion = item.Descripcion;
                objE_SolicitudEgresoDetalleDocumentos.Moneda = item.Moneda;
                objE_SolicitudEgresoDetalleDocumentos.DescTipoDocumento = item.DescTipoDocumento;
                objE_SolicitudEgresoDetalleDocumentos.NumeroFactura = item.NumeroFactura;

                objE_SolicitudEgresoDetalleDocumentos.ImporteFactura = item.ImporteFactura;
                objE_SolicitudEgresoDetalleDocumentos.ImporteCuarta = item.ImporteCuarta;
                objE_SolicitudEgresoDetalleDocumentos.ImporteDetraccion = item.ImporteDetraccion;
                objE_SolicitudEgresoDetalleDocumentos.UsuarioCreacion = item.UsuarioCreacion;

                objE_SolicitudEgresoDetalleDocumentos.IdTienda = item.IdTienda;
                objE_SolicitudEgresoDetalleDocumentos.DescTienda = item.DescTienda;
                objE_SolicitudEgresoDetalleDocumentos.IdTipoEgreso = item.IdTipoEgreso;
                objE_SolicitudEgresoDetalleDocumentos.DescTipoEgreso = item.DescTipoEgreso;

                mCajaEgresoDetalleDocumentosOrigen.Add(objE_SolicitudEgresoDetalleDocumentos);
            }

            bsListado.DataSource = mCajaEgresoDetalleDocumentosOrigen;
            gcDocumentos.DataSource = bsListado;
            gcDocumentos.RefreshDataSource();
        }

        private void CargaDetalleEgresos()
        {
            List<CajaEgresoDetalleDocumentosBE> lstTmpCajaEgresoDetalle = null;
            lstTmpCajaEgresoDetalle = new CajaEgresoDetalleDocumentosBL().ListaTodosActivoEgresos(IdCajaEgreso, IdCajaEgresoDetalle);

            foreach (CajaEgresoDetalleDocumentosBE item in lstTmpCajaEgresoDetalle)
            {
                CCajaEgresoDetalleDocumentos2 objE_CajaEgresoDetalleDocs_Egresos = new CCajaEgresoDetalleDocumentos2();

                objE_CajaEgresoDetalleDocs_Egresos.IdCajaEgreso = item.IdCajaEgreso;
                objE_CajaEgresoDetalleDocs_Egresos.IdCajaEgresoDetalle = item.IdCajaEgresoDetalle;
                objE_CajaEgresoDetalleDocs_Egresos.IdCajaEgresoDetalleDocumentos = item.IdCajaEgresoDetalleDocumentos;
                
                objE_CajaEgresoDetalleDocs_Egresos.IdEmpresa = item.IdEmpresa;
                objE_CajaEgresoDetalleDocs_Egresos.NumRecibo = item.NumRecibo;
                objE_CajaEgresoDetalleDocs_Egresos.Fecha = item.Fecha;
                objE_CajaEgresoDetalleDocs_Egresos.Monto = item.ImporteEgreso;

                mCajaEgresoDetalleDocumentosOrigen2.Add(objE_CajaEgresoDetalleDocs_Egresos);
            }

            bsListado2.DataSource = mCajaEgresoDetalleDocumentosOrigen2;
            gcListaEgresos.DataSource = bsListado2;
            gcListaEgresos.RefreshDataSource();
        }

        public class CCajaEgresoDetalleDocumentos
        {
            public Int32 IdCajaEgresoDetalle { get; set; }
            public Int32 IdCajaEgresoDetalleDocumentos { get; set; }
            public Int32 IdCentroCosto { get; set; }
            public Int32 IdArea { get; set; }
            public String Area { get; set; }
            public DateTime ?Fecha { get; set; }
            public String NumDocProv { get; set; }
            public String DescProv { get; set; }
            public DateTime? FechaFactura { get; set; }
            public String Descripcion { get; set; }
            public String Moneda { get; set; }
            public Int32 TipoDocumentoProv { get; set; }
            public String DescTipoDocumento { get; set; }
            
            public String NumeroFactura { get; set; }
            public Decimal ImporteFactura { get; set; }
            public Decimal ImporteCuarta { get; set; }
            public Decimal ImporteDetraccion { get; set; }
            public String UsuarioCreacion { get; set; }
            public Boolean FlagEstado { get; set; }
            public Int32 TipoOper { get; set; }
            public Int32 IdTienda { get; set; }
            public Int32 IdTipoEgreso { get; set; }

            public String DescTienda { get; set; }
            public String DescTipoEgreso { get; set; }
            public CCajaEgresoDetalleDocumentos()
            {

            }
        }

        public class CCajaEgresoDetalleDocumentos2
        {
            public Int32 IdCajaEgreso { get; set; }
            public Int32 IdCajaEgresoDetalle { get; set; }
            public Int32 IdCajaEgresoDetalleDocumentos { get; set; }          
            public Int32 IdEmpresa { get; set; }
            public String NumRecibo { get; set; }
            public DateTime? Fecha { get; set; }
            public Decimal Monto { get; set; }

            public CCajaEgresoDetalleDocumentos2()
            {

            }
        }


        private void CalculaTotales()
        {
            try
            {
                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deTotal = 0;

                decimal TotalIngreso = 0;
                decimal TotalEgreso = 0;

                decimal deTotal22 = 0;
                int intTotalCantidad = 0;

                if (mCajaEgresoDetalleDocumentosOrigen.Count > 0)
                {
                    foreach (var item in mCajaEgresoDetalleDocumentosOrigen)
                    {
                        TotalIngreso = TotalIngreso + item.ImporteFactura;
                    }

                    txtTotalDocumentos.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(TotalIngreso, 2)));
                    txtSaldoRendir.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(MontoRecibo - TotalIngreso - MontoDevolucion, 2)));
                }
                else
                {
                   // txtTotalDocumentos.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    txtTotalDocumentos.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    txtSaldoRendir.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(MontoRecibo - TotalIngreso - MontoDevolucion, 2)));
                    //  txtSaldoFinal.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculaTotalesEgresos()
        {
            try
            {
                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deTotal = 0;

                decimal TotalIngreso = 0;
                decimal TotalEgreso = 0;

                decimal deTotal22 = 0;
                int intTotalCantidad = 0;

                if (mCajaEgresoDetalleDocumentosOrigen2.Count > 0)
                {
                    foreach (var item in mCajaEgresoDetalleDocumentosOrigen2)
                    {
                        TotalEgreso = TotalEgreso + item.Monto;
                    }

                    txtTotalEgresos.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(TotalEgreso, 2)));
                }
                else
                {
                    txtTotalEgresos.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegPrestamoBancoEdit_Shown(object sender, EventArgs e)
        {
            //NumCar = 1;
        }

        private void cboCuentaBanco_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
                //Cargar();
            }
        }

        private void cancelarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSituacion = int.Parse(gvDocumentos.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion == Parametros.intSITPagoCancelado)
                {
                    XtraMessageBox.Show("La cuota ya está cancelada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    frmEstablecerFecha frm = new frmEstablecerFecha();
                    frm.Text = "Establecer Fecha de Pago";
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
                        PrestamoBancoDetalleBL objBL_PrestamoBancoDetalle = new PrestamoBancoDetalleBL();

                        int IdPrestamoBancoDetalle = int.Parse(gvDocumentos.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                        //objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                        objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                        objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoCancelado;
                        objE_PrestamoBancoDetalle.FechaPago = frm.Fecha;
                        objE_PrestamoBancoDetalle.Usuario = frmAutoriza.Usuario;//Parametros.strUsuarioLogin;
                        objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                        gvDocumentos.SetRowCellValue(gvDocumentos.FocusedRowHandle, "DescSituacion", "CANCELADO");
                        gvDocumentos.SetRowCellValue(gvDocumentos.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoCancelado);
                        gvDocumentos.SetRowCellValue(gvDocumentos.FocusedRowHandle, "FechaPago", frm.Fecha);
                        gvDocumentos.SetRowCellValue(gvDocumentos.FocusedRowHandle, "UsuarioPago", frmAutoriza.Usuario);//Parametros.strUsuarioLogin);

                        CalcularTotalSaldoPrestamo();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void gvPrestamoBancoDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotalGeneral = 0;
                decimal decAmortizacion = 0;
                decimal decInteres = 0;
                decimal decEnvioInfo = 0;
                decimal decDesgravamen = 0;
                decimal decSeguro = 0;

                if (e.Column.FieldName == "Monto")
                {
                    decAmortizacion = decimal.Parse(e.Value.ToString());
                    decAmortizacion = Convert.ToDecimal(gvDocumentos.GetRowCellValue(e.RowHandle, (gvDocumentos.Columns["Monto"])));
                    decInteres = Convert.ToDecimal(gvDocumentos.GetRowCellValue(e.RowHandle, (gvDocumentos.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvDocumentos.GetRowCellValue(e.RowHandle, (gvDocumentos.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvDocumentos.GetRowCellValue(e.RowHandle, (gvDocumentos.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvDocumentos.GetRowCellValue(e.RowHandle, (gvDocumentos.Columns["Seguro"])));


                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvDocumentos.SetRowCellValue(e.RowHandle, gvDocumentos.Columns["TotalPagar"], decTotal);
                }
                //if (e.Column.FieldName == "Interes")
                //{
                //    decInteres = decimal.Parse(e.Value.ToString());
                //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                //}
                //if (e.Column.FieldName == "EnvioInformacion")
                //{
                //    decEnvioInfo = decimal.Parse(e.Value.ToString());
                //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                //}
                //if (e.Column.FieldName == "Desgravamen")
                //{
                //    decDesgravamen = decimal.Parse(e.Value.ToString());
                //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                //}
                //if (e.Column.FieldName == "Seguro")
                //{
                //    decSeguro = decimal.Parse(e.Value.ToString());
                //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCuotas_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (pOperacion == Operacion.Nuevo)
            //    {
            //        int nCuotas = 0;
            //        nCuotas = Convert.ToInt32(speFin.Value);  // txtCuotas.EditValue
            //        if (nCuotas > 0)
            //        {
            //            for (int i = 1; i <= nCuotas; i++)
            //            {
            //                gvMovimientoCaja.AddNewRow();
            //                gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "NumeroCuota", i);
            //            }
            //        }
            //    }
            //}
        }

        private void habilitarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSituacion = int.Parse(gvDocumentos.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion != Parametros.intSITPagoCancelado)
                {
                    XtraMessageBox.Show("La cuota no está cancelada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
                    PrestamoBancoDetalleBL objBL_PrestamoBancoDetalle = new PrestamoBancoDetalleBL();

                    int IdPrestamoBancoDetalle = int.Parse(gvDocumentos.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                    //objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                    objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                    objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoPendiente;
                    objE_PrestamoBancoDetalle.FechaPago = null;
                    objE_PrestamoBancoDetalle.Usuario = Parametros.strUsuarioLogin;
                    objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                    gvDocumentos.SetRowCellValue(gvDocumentos.FocusedRowHandle, "DescSituacion", "PENDIENTE");
                    gvDocumentos.SetRowCellValue(gvDocumentos.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoPendiente);
                    gvDocumentos.SetRowCellValue(gvDocumentos.FocusedRowHandle, "FechaPago", null);
                    gvDocumentos.SetRowCellValue(gvDocumentos.FocusedRowHandle, "UsuarioPago", Parametros.strUsuarioLogin);

                    CalcularTotalSaldoPrestamo();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                //throw;
            }

        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;

            string strMensaje = "No se pudo registrar:\n";

 
                if (txtNumeroDocumento.Text.Trim().ToString() == "" || txtDescProveedor.Text=="")
                {
                    strMensaje = strMensaje + "- Ingrese los datos del Proveedor/Personal.\n";
                    flag = true;
                }

            //if (IdEmpresa == 13)
            //{
                if (Convert.ToInt32(cboAsignar.EditValue) == 0)
                {
                    strMensaje = strMensaje + "- Seleccione el area.\n";
                    flag = true;
                }
            //}

            if (Convert.ToInt32(cboTipoDocumento.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Seleccione el tipo de documento.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción o detalle.\n";
                flag = true;
            }

            if (Convert.ToDecimal(txtImporte.Text) == 0)
            {
                strMensaje = strMensaje + "- Ingrese el importe del documento.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        //private void CargaPrestamoBancoDetalle()
        //{
        //    List<SolicitudEgresoDetalleBE> lstTmpPrestamoBancoDetalle = null;
        //    lstTmpPrestamoBancoDetalle = new SolicitudEgresoDetalleBL().ListaTodosActivo(IdSolicitudEgreso);

        //    foreach (SolicitudEgresoDetalleBE item in lstTmpPrestamoBancoDetalle)
        //    {
        //        CSolicitudEgresoDetalle objE_SolicitudEgresoDetalle = new CSolicitudEgresoDetalle();

        //        objE_SolicitudEgresoDetalle.IdSolicitudEgreso = item.IdSolicitudEgreso;
        //        objE_SolicitudEgresoDetalle.IdSolicitudEgresoDetalle = item.IdSolicitudEgresoDetalle;
        //        objE_SolicitudEgresoDetalle.NumAbono = item.NumeroAbono;
        //        objE_SolicitudEgresoDetalle.FechaPagoSolicitada2 =Convert.ToDateTime( item.FechaPagoSolicitada);
        //        objE_SolicitudEgresoDetalle.Monto = item.MontoAbono;

        //        //objE_SolicitudEgresoDetalle.TipoOper = Convert.ToInt32(Operacion.Consultar);

        //        mListaPrestamoBancoDetalleOrigen.Add(objE_SolicitudEgresoDetalle);
        //    }

        //    bsListado.DataSource = mListaPrestamoBancoDetalleOrigen;
        //    gcMovimientoCaja.DataSource = bsListado;
        //    gcMovimientoCaja.RefreshDataSource();

        //    lblTotalRegistros.Text = gvMovimientoCaja.RowCount.ToString() + " Registros";
        //}

        private void CargarCombo()
        {
            //mListaCuentaBanco = new CuentaBancoBL().Lista(0);
            //if (mListaCuentaBanco.Count > 0)
            //{
            //    //cboCuentaBanco.Properties.DataSource = mListaCuentaBanco;

            //    //cboCuentaBanco.EditValue = mListaCuentaBanco[0].IdCuentaBanco;
            //    //cboCuentaBanco.Properties.DisplayMember = "DescBanco";

            //}
        }

        private void ImportarExcel(string filename)
        {
            //if (pOperacion == Operacion.Nuevo)
            //{
            //    XtraMessageBox.Show("Debe grabar al menos un código, luego abrir e importar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            int TotalAgregado = 0;
            int TotalActualizado = 0;
            decimal decAmortizacion = 0;
            decimal decTotalInteres = 0;
            decimal decInteres = 0;
            int intCuotas = 0;
            DateTime FechaVen= DateTime.Now;
            string sNumeroPrestamo = "";


            if (filename.Trim() == "")
                return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            int Row = 2;
            int TotRow = 2;

            try
            {
                //Contador de Registros
                while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                //prgFactura.Properties.Step = 1;
                //prgFactura.Properties.Maximum = TotRow;
                //prgFactura.Properties.Minimum = 0;


                //Recorremos los códigos de PromocionTemporal
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string NumeroCuota = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    DateTime FechaVencimiento = Convert.ToDateTime((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    string SaldoPendiente = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    string Amortizacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();
                    string Interes = (string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim();
                    string EnvioInformacion = (string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim();
                    string Desgravamen = (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim();
                    string Seguro = (string)xlHoja.get_Range("H" + Row, Missing.Value).Text.ToString().Trim();
                    string TotalPagar = (string)xlHoja.get_Range("I" + Row, Missing.Value).Text.ToString().Trim();
                    string Moneda = (string)xlHoja.get_Range("J" + Row, Missing.Value).Text.ToString().Trim();
                    string Cuotas = (string)xlHoja.get_Range("K" + Row, Missing.Value).Text.ToString().Trim();
                    string NumeroPrestamo = (string)xlHoja.get_Range("L" + Row, Missing.Value).Text.ToString().Trim();


                    //if (pOperacion == Operacion.Nuevo)
                    //{
                    //    gvMovimientoCaja.AddNewRow();
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "IdPrestamoBanco", IdPrestamoBanco);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "IdPrestamoBancoDetalle", 0);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "NumeroCuota", NumeroCuota);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "FechaVencimiento", FechaVencimiento);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "SaldoPendiente", SaldoPendiente);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "Amortizacion", Amortizacion);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "Interes", Interes);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "Desgravamen", Desgravamen);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "Seguro", Seguro);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "TotalPagar", TotalPagar);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "FlagEstado", true);
                    //    if (pOperacion == Operacion.Modificar)
                    //        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    //    else
                    //        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                    //    TotalAgregado = TotalAgregado + 1;
                    //}

                    decTotalInteres = decTotalInteres + Convert.ToDecimal(Interes);
                    decInteres = decInteres + Convert.ToDecimal(Interes);
                    intCuotas = Convert.ToInt32(Cuotas);
                    FechaVen = FechaVencimiento;
                    sNumeroPrestamo = NumeroPrestamo;
                    decAmortizacion = decAmortizacion + Convert.ToDecimal(Amortizacion);
                    //prgFactura.PerformStep();
                    //prgFactura.Update();

                    Row++;
                }
              //  lblTotalRegistros.Text = gvMovimientoCaja.RowCount.ToString() + " Registros";



                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                //if (pOperacion == Operacion.Modificar)
                //{
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotalSaldoPrestamo()
        {
            try
            {
                decimal decSaldo = 0;
                decimal decInteres = 0;
                decimal decTotalInteres = 0;
                decimal decMayorSaldo = 0;
                int intSituacion = 0;

                for (int i = 0; i < gvDocumentos.RowCount; i++)
                {
                    intSituacion = Convert.ToInt32(gvDocumentos.GetRowCellValue(i, (gvDocumentos.Columns["IdSituacion"])));

                    decSaldo = Convert.ToDecimal(gvDocumentos.GetRowCellValue(i, (gvDocumentos.Columns["SaldoPendiente"])));
                    decInteres = Convert.ToDecimal(gvDocumentos.GetRowCellValue(i, (gvDocumentos.Columns["Interes"])));

                    if (intSituacion != Parametros.intSITPagoCancelado)
                    {
                        decTotalInteres = decTotalInteres + decInteres;

                        if(decSaldo > decMayorSaldo)
                        {
                            decMayorSaldo = decSaldo;
                        }
                    }
                }
                //txtSaldoPrestamo.EditValue = decMayorSaldo;
                //txtSaldoInteres.EditValue = decTotalInteres;
                //lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                /// Validación del documento que se va ingresar (evitar duplicidad de documento)                                         
                /// 
                if (!ValidarIngreso())
                {
                    if (Convert.ToInt32(cboTienda.EditValue) == 0)
                    {
                        XtraMessageBox.Show("Seleccione la tienda para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboTienda.Select();
                        return;
                    }

                    if (Convert.ToInt32(cboTipoEgreso.EditValue) == 0)
                    {
                        XtraMessageBox.Show("Seleccione el tipo de egreso para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboTipoEgreso.Select();
                        return;
                    }

                    CajaEgresoDetalleDocumentosBL objBL_CajaEgresoDetalleDocumentos = new CajaEgresoDetalleDocumentosBL();
                    CajaEgresoDetalleDocumentosBE objCajaEgresoDetalleDocumentos = new CajaEgresoDetalleDocumentosBE();

                    objCajaEgresoDetalleDocumentos.IdEmpresa = IdEmpresa;
                    objCajaEgresoDetalleDocumentos.IdCajaEgreso = IdCajaEgreso;
                    objCajaEgresoDetalleDocumentos.IdCajaEgresoDetalle = IdCajaEgresoDetalle;
                    objCajaEgresoDetalleDocumentos.IdCentroCosto = Convert.ToInt32(cboCentroCosto.EditValue);
                    objCajaEgresoDetalleDocumentos.IdArea = Convert.ToInt32(cboAsignar.EditValue);
                    objCajaEgresoDetalleDocumentos.Fecha = Convert.ToDateTime(cboFecha.EditValue);
                    objCajaEgresoDetalleDocumentos.FechaFactura = Convert.ToDateTime(dteFechaFactura.EditValue);
                    objCajaEgresoDetalleDocumentos.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objCajaEgresoDetalleDocumentos.TipoDocumentoProv = Convert.ToInt32(cboTipoDocumento.EditValue);
                    objCajaEgresoDetalleDocumentos.SerieFactura = txtSerie.Text.Trim();
                    objCajaEgresoDetalleDocumentos.NumeroFactura = txtNumFactura.Text.Trim();

                    objCajaEgresoDetalleDocumentos.IdProveedor = IdProveedor;
                    objCajaEgresoDetalleDocumentos.NumDocProv = txtNumeroDocumento.Text.Trim();
                    objCajaEgresoDetalleDocumentos.DescProv = txtDescProveedor.Text.Trim();
                    objCajaEgresoDetalleDocumentos.Descripcion = txtDescripcion.Text.Trim();

                    objCajaEgresoDetalleDocumentos.ImporteCuarta = Convert.ToDecimal(txtCuarta.Text.Trim());
                    objCajaEgresoDetalleDocumentos.ImporteDetraccion = Convert.ToDecimal(txtDetraccion.Text.Trim());
                    objCajaEgresoDetalleDocumentos.ImporteFactura = Convert.ToDecimal(txtImporte.Text.Trim());
                    objCajaEgresoDetalleDocumentos.UsuarioCreacion = Parametros.strUsuarioLogin;

                    objCajaEgresoDetalleDocumentos.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objCajaEgresoDetalleDocumentos.IdTipoEgreso = Convert.ToInt32(cboTipoEgreso.EditValue);

                    IdCajaEgresoDetalleDocumento = objBL_CajaEgresoDetalleDocumentos.Inserta(objCajaEgresoDetalleDocumentos);

                    bsListado.Clear();
                    gcDocumentos.DataSource = null;
                    gcDocumentos.RefreshDataSource();

                    CargaMovimientosCajaDetalle();
                    CalculaTotales();

                    cboFecha.EditValue = DateTime.Now;
                    dteFechaFactura.EditValue = DateTime.Now;
                    cboAsignar.EditValue = 0;
                    cboTipoDocumento.EditValue = 0;
                    txtSerie.Text = "";
                    txtNumFactura.Text = "";
                    txtNumeroDocumento.Text = "";
                    txtDescProveedor.Text = "";
                    IdProveedor = 0;
                    txtImporte.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    txtCuarta.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    txtDetraccion.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    txtNumeroDocumento.Text = "";
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCentroCosto_EditValueChanged(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //if (rb1.Checked)
                    //{
                    //    if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                    //    {
                    //        PersonaBE objE_Persona = null;
                    //        objE_Persona = new PersonaBL().SeleccionaPersonal(txtNumeroDocumento.Text.Trim());
                    //        if (objE_Persona != null)
                    //        {
                    //            IdPersona = objE_Persona.IdPersona;
                    //            txtNumeroDocumento.Text = objE_Persona.Dni.Trim();
                    //            txtApeNom.Text = objE_Persona.ApeNom.Trim();
                    //        }
                    //        else
                    //        {
                    //            XtraMessageBox.Show("El personal no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        btnBuscar_Click(sender, e);
                    //    }
                    //}
                    //else if (rb2.Checked)
                    //{
                    //    txtApeNom.Select();


                    //}

                }
            }
            catch (Exception ex)
            {
               // XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                frmBusPersonal frm = new frmBusPersonal();
                //frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();

                if (frm.pProveedorBE != null)
                {

                    IdPersona = frm.pProveedorBE.IdPersona;
                    //txtNumeroDocumento.Text = frm.pProveedorBE.Dni;
                    //txtApeNom.Text = frm.pProveedorBE.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCuentaBancoProveedor_EditValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cboOperacion.EditValue)==Parametros.intOperacionIngreso)
            //{
            //    //lblReferencia.Visible = true;
            //    //txtReferenciaEgreso.Visible = true;
            //    //txtReferenciaEgreso.Text = "";
            //    //lblRecibio.Text = "Devuelve:";
            //}
            //else  
            //{
            //    //lblReferencia.Visible = false;
            //    //txtReferenciaEgreso.Visible = false;
            //    //lblRecibio.Text = "Recibe:";
            //}
            //CuentaBancoBE objBE_CuentaBancoProveedor = null;
            //objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
            //if (objBE_CuentaBancoProveedor != null)
            //{
            //    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
            //    txtCCI.EditValue = objBE_CuentaBancoProveedor.CCI;
            //}
            //else
            //{
            //    txtCuenta.EditValue = "";
            //    txtCCI.EditValue = "";
            //}
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    txtCuenta.EditValue = "";
            //    cboCuentaBancoProveedor.EditValue=0;
            //    BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(IdProveedor, Convert.ToInt32(cboMoneda.EditValue)), "DescBanco", "IdCuentaBancoProveedor", true);

            //    CuentaBancoBE objBE_CuentaBancoProveedor = null;
            //    objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
            //    if (objBE_CuentaBancoProveedor != null)
            //    {
            //        txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
            //        txtCCI.EditValue = objBE_CuentaBancoProveedor.CCI;
            //    }
            //    else
            //{
            //        txtCuenta.EditValue = "";
            //        txtCCI.EditValue = "";
            //    }
            //}
            //catch (Exception ex)
            //{
            //   // XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cboTipoEgreso_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusClienteSolicitud frm = new frmBusClienteSolicitud();
                frm.pNumeroDescCliente = "";
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();

                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    //txtAFacturar.Text = frm.pClienteBE.DescCliente;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rb1_Click(object sender, EventArgs e)
        {
            //if (rb1.Checked)
            //{
            //    IdPersona = 0;
            //    txtNumeroDocumento.Text = "";
            //    txtApeNom.Text = "";
            //    txtApeNom.ReadOnly = true;
            //}
            //btnBuscar.Enabled = true;
            //txtNumeroDocumento.Select();
        }

        private void rb2_Click(object sender, EventArgs e)
        {
            //if (rb2.Checked)
            //{
            //    IdPersona =0;
            //    txtNumeroDocumento.Text = "";
            //    txtApeNom.Text = "";
            //    txtApeNom.ReadOnly = false;
            //}
            //btnBuscar.Enabled = false;
            //txtNumeroDocumento.Select();
        }

        private void rb1_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bsListado.Clear();
            gcDocumentos.DataSource = null;
            gcDocumentos.RefreshDataSource();

            CargaMovimientosCajaDetalle();
            CalculaTotales();
        }

        private void txtReferenciaEgreso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //this.txtReferenciaEgreso.Text = txtReferenciaEgreso.Text.ToString().PadLeft(6, '0');
                //if (this.txtReferenciaEgreso.Text == "000000")
                //{
                //    XtraMessageBox.Show("Ingrese el Nro. de Recibo de referencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                //DataTable dtPedido = new DataTable();
                //dtPedido = FuncionBase.ToDataTable(new MovimientoPedidoBL().ListaNumero(Convert.ToInt32(txtperiodo.Text), txtNumero.Text.Trim()));
                //if (dtPedido.Rows.Count > 0)
                //{
                //    gcPedido.DataSource = dtPedido;
                //}
                //else
                //{
                //    XtraMessageBox.Show("El N° Pedido no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
        }

        private void eliminarReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (int.Parse(gvDocumentos.GetFocusedRowCellValue("TipoOperacion").ToString())==1)
            //{
            //    if (XtraMessageBox.Show("¿Está seguro de Eliminar el Recibo de Ingreso Nro. " + gvDocumentos.GetFocusedRowCellValue("NumRecibo").ToString() +" ? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        CajaEgresoDetalleBL objBL_CajaEgresoDetalle = new CajaEgresoDetalleBL();
            //        CajaEgresoDetalleBE objCajaEgresoDetalle = new CajaEgresoDetalleBE();

            //        objCajaEgresoDetalle.IdCajaEgresoDetalle = int.Parse(gvDocumentos.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());
            //        objCajaEgresoDetalle.FlagEstado = 0;

            //        objBL_CajaEgresoDetalle.Actualiza(objCajaEgresoDetalle);
            //    }
            //    else
            //    { return; }
            //}
            //else
            //{
            if (IdSituacionDocs == 2)
            {
                XtraMessageBox.Show("La caja esta cerrada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("¿Está seguro de Eliminar el documento Nro. " + gvDocumentos.GetFocusedRowCellValue("NumeroFactura").ToString() + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CajaEgresoDetalleDocumentosBL objBL_CajaEgresoDetalle = new CajaEgresoDetalleDocumentosBL();
                    CajaEgresoDetalleDocumentosBE objCajaEgresoDetalleDocumento = new CajaEgresoDetalleDocumentosBE();

                    objCajaEgresoDetalleDocumento.IdCajaEgresoDetalleDocumentos = int.Parse(gvDocumentos.GetFocusedRowCellValue("IdCajaEgresoDetalleDocumentos").ToString());
                    objCajaEgresoDetalleDocumento.FlagEstado = 0;

                    objBL_CajaEgresoDetalle.Actualiza(objCajaEgresoDetalleDocumento);
                }
                else
                { return; }
            //}

            XtraMessageBox.Show("Se elimino satisfactoriamente el documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            bsListado.Clear();
            gcDocumentos.DataSource = null;
            gcDocumentos.RefreshDataSource();

            CargaMovimientosCajaDetalle();
            CalculaTotales();
        }

        private void txtReferenciaEgreso_TextChanged(object sender, EventArgs e)
        {
             //txtReferenciaEgreso.Text = txtReferenciaEgreso.Text.ToString().PadLeft(6, '0');
        }

        private void txtReferenciaEgreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //txtNumeroDocumento.Focus();
            }
        }

        private void txtApeNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //txtConcepto.Focus();
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    txtApeNom.Focus();
            //}
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtImporte.Focus();
            }
        }

        private void reimprimirReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CajaEgresoDetalleBE> lstReporte = null;
            lstReporte = new CajaEgresoDetalleBL().ListadoPrint(int.Parse(gvDocumentos.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString()));

            CreaTicketCajaEgreso ticket = new CreaTicketCajaEgreso();

            // IMPRESIÓN DE TICKET
            #region "Impresión Recibo"
                ticket.TextoCentro("************************************");
            if (lstReporte[0].TipoOperacion==1)
                {
                    ticket.TextoCentro("RECIBO DE INGRESO "  + ": Nro. " + lstReporte[0].NumRecibo.ToString());
                }
                else
                {
                    ticket.TextoCentro("RECIBO DE EGRESO " + ": Nro. " + lstReporte[0].NumRecibo.ToString());
                }
                ticket.TextoCentro("************************************");
                ticket.TextoCentro("");
                ticket.TextoIzquierda("FECHA   " + ": " + lstReporte[0].Fecha.ToString());
                if (lstReporte[0].IdEmpresa == 13)
                {
                    ticket.TextoIzquierda("RUC     " + ": " + lstReporte[0].Ruc);
                    ticket.TextoIzquierda("EMPRESA " + ": " + "PANORAMA DISTRIBUIDORES S.A.");
                }
                else if (lstReporte[0].IdEmpresa == 27)
                {
                    ticket.TextoIzquierda("RUC     " + ": " + lstReporte[0].Ruc);
                    ticket.TextoIzquierda("EMPRESA " + ": " + "DECORATEX E.I.R.L.");
                }
                ticket.TextoIzquierda("CAJA    " + ": " + lstReporte[0].De);
                ticket.TextoCentro("");

                if (lstReporte[0].TipoOperacion == 1)
                {
                    ticket.TextoIzquierda("DEVUELVE: ");
                    ticket.TextoIzquierda("NOMBRES " + ": " + lstReporte[0].Recibio);
                    ticket.TextoIzquierda("REFERENCIA RECIBO DE EGRESO " + ": Nro. " + lstReporte[0].Referencia.ToString());
                    ticket.TextoCentro("");
            }
            ticket.TextoIzquierda("DATOS DEL QUE RECIBE:");

                if (lstReporte[0].TipoOperacion == 1)
                {
                        ticket.TextoIzquierda("DNI/CE " + ": " );
                        ticket.TextoIzquierda("CAJA " + ": " + lstReporte[0].De);
                }
                else if (lstReporte[0].TipoOperacion == 2)
                {
                    ticket.TextoIzquierda("DNI/CE " + ": " + lstReporte[0].NumDocumento);
                    ticket.TextoIzquierda("RECIBI " + ": " + lstReporte[0].Recibio);
                }

                ticket.TextoIzquierdaNLineas("CONCEPTO " + ": " + lstReporte[0].Concepto);
            ticket.TextoCentro("");
            ticket.TextoIzquierda("IMPORTE    " + ": S/ " + lstReporte[0].Importe);
                ticket.TextoIzquierdaNLineas("LA SUMA DE " + ": " + lstReporte[0].ImporteTexto);
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("__________________________________");
                ticket.TextoCentro("RECIBI");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("__________________________________");
                ticket.TextoCentro("ENTREGE");
                ticket.CortaTicket();

                #endregion
        }

        private void grdDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gcDocumentos_Click(object sender, EventArgs e)
        {

        }

        private void cboAsignar_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCentroCosto_EditValueChanged_1(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);
        }

        private void textEdit6_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                    {
                        ProveedorBE objE_Proveedor = null;
                        objE_Proveedor = new ProveedorBL().SeleccionaNumero(txtNumeroDocumento.Text.Trim());
                        if (objE_Proveedor != null)
                        {
                            IdProveedor = objE_Proveedor.IdProveedor;
                            txtNumeroDocumento.Text = objE_Proveedor.NumeroDocumento.Trim();
                            txtDescProveedor.Text = objE_Proveedor.DescProveedor.Trim();

                            if(objE_Proveedor.PCredito)
                            { 
                            XtraMessageBox.Show("El proveedor nos emite Credito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("El proveedor no existe, debera registrarlo antes de continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        btnBuscar_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                // XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboTipoDocumento.EditValue) == 567)
                {
                        frmBusPersonal frm = new frmBusPersonal();
                        frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                        frm.pFlagMultiSelect = false;
                        frm.ShowDialog();

                        if (frm.pProveedorBE != null)
                        {

                        IdProveedor = frm.pProveedorBE.IdPersona;
                            txtNumeroDocumento.Text = frm.pProveedorBE.Dni;
                            txtDescProveedor.Text = frm.pProveedorBE.ApeNom;
                        }
                
                }
                else
                {
                    frmBusProveedor frm = new frmBusProveedor();
                    frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                    frm.pFlagMultiSelect = false;
                    frm.ShowDialog();

                    if (frm.pProveedorBE != null)
                    {

                        IdProveedor = frm.pProveedorBE.IdProveedor;
                        txtNumeroDocumento.Text = frm.pProveedorBE.NumeroDocumento;
                        txtDescProveedor.Text = frm.pProveedorBE.DescProveedor;

                        if (frm.pProveedorBE.PCredito)
                        {
                            XtraMessageBox.Show("El proveedor nos emite Credito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                //BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(IdProveedor, Convert.ToInt32(cboMoneda.EditValue)), "DescBanco", "IdCuentaBancoProveedor", true);

                //CuentaBancoBE objBE_CuentaBancoProveedor = null;
                //objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
                //if (objBE_CuentaBancoProveedor != null)
                //{
                //    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
                //}
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTipoDocumento_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoDocumento.EditValue)==567)
            {
                txtNumeroDocumento.ReadOnly = false;
                txtDescProveedor.ReadOnly = false;
                btnBuscar.Enabled = true;

                txtNumeroDocumento.Text = NumDocumento;
                txtDescProveedor.Text = Nombres;
            }
            else
            {
                txtNumeroDocumento.ReadOnly = false;
                txtDescProveedor.ReadOnly = false;
                btnBuscar.Enabled = true;
                txtNumeroDocumento.Text = "";
                txtDescProveedor.Text = "";
            }
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmManProveedorEdit objManProveedor = new frmManProveedorEdit();
            objManProveedor.lstProveedor = Parametros.pListaProveedores;
            objManProveedor.pOperacion = frmManProveedorEdit.Operacion.Nuevo;
            objManProveedor.IdProveedor = 0;
            objManProveedor.StartPosition = FormStartPosition.CenterParent;
            objManProveedor.ShowDialog();

            txtNumeroDocumento.Text = objManProveedor.DocProveedor;
            txtDescProveedor.Text = objManProveedor.NomProveedor;
            IdProveedor = objManProveedor.IdProveedor2;
        }

        private void simpleButton2_Click_3(object sender, EventArgs e)
        {
            try
            {

                if (mCajaEgresoDetalleDocumentosOrigen2.Count > 0)
                {
                    int xposition = 0;

                    frmBuscaEgresos movDetalle = new frmBuscaEgresos();

                    //movDetalle.pOperacion = frmAdjuntarArchivo.Operacion.Modificar;
                    movDetalle.StartPosition = FormStartPosition.CenterParent;

                    movDetalle.oBE.IdCajaEgreso =   int.Parse(gvListaEgresos.GetFocusedRowCellValue("IdCajaEgreso").ToString());
                    movDetalle.oBE.IdCajaEgresoDetalle =  int.Parse(gvListaEgresos.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());

                    if (movDetalle.ShowDialog() == DialogResult.OK)
                    {
                        xposition = mCajaEgresoDetalleDocumentosOrigen2.Count + 1;  // gvListaEgresos.FocusedRowHandle;

                        if (movDetalle.oBE != null)
                        {
                            gvListaEgresos.AddNewRow();
                            gvListaEgresos.SetRowCellValue(gvListaEgresos.FocusedRowHandle, "IdCajaEgreso", movDetalle.oBE.IdCajaEgreso);
                            gvListaEgresos.SetRowCellValue(gvListaEgresos.FocusedRowHandle, "IdCajaEgresoDetalle", movDetalle.oBE.IdCajaEgresoDetalle);
                            gvListaEgresos.SetRowCellValue(gvListaEgresos.FocusedRowHandle, "IdCajaEgresoDetalleDocumentos", IdCajaEgresoDetalleDocumento);
                            
                            gvListaEgresos.SetRowCellValue(gvListaEgresos.FocusedRowHandle, "IdEmpresa", IdEmpresa);
                            gvListaEgresos.SetRowCellValue(gvListaEgresos.FocusedRowHandle, "NumRecibo", movDetalle.oBE.NumRecibo);
                            gvListaEgresos.SetRowCellValue(gvListaEgresos.FocusedRowHandle, "Fecha", movDetalle.oBE.Fecha);
                            gvListaEgresos.SetRowCellValue(gvListaEgresos.FocusedRowHandle, "Monto", movDetalle.oBE.Importe);
                            gvListaEgresos.UpdateCurrentRow();
                        }
                    }
                }
                CalculaTotalesEgresos();

                // Obtener el Id del documento asociado
                int IdDocumento = 0;
                foreach (var item in mCajaEgresoDetalleDocumentosOrigen)
                {
                    CajaEgresoDetalleBE objE_SolicitudEgresoDetalle = new CajaEgresoDetalleBE();

                     IdDocumento = item.IdCajaEgresoDetalleDocumentos;
                }

                // Lista de Egresos
                CajaEgresoDetalleBL objBL_CajaEgresoDetalle = new CajaEgresoDetalleBL();
                List<CajaEgresoDetalleBE> lstListaCajaEgresoDetalle = new List<CajaEgresoDetalleBE>();

                foreach (var item in mCajaEgresoDetalleDocumentosOrigen2)
                {
                    CajaEgresoDetalleBE objE_SolicitudEgresoDetalle = new CajaEgresoDetalleBE();

                    objE_SolicitudEgresoDetalle.IdCajaEgreso = item.IdCajaEgreso;
                    objE_SolicitudEgresoDetalle.IdCajaEgresoDetalle = item.IdCajaEgresoDetalle;
                    objE_SolicitudEgresoDetalle.IdCajaEgresoDetalleDocumentos = IdDocumento;
                    objE_SolicitudEgresoDetalle.IdEmpresa = item.IdEmpresa;
                    objE_SolicitudEgresoDetalle.Fecha = item.Fecha;
                    objE_SolicitudEgresoDetalle.NumRecibo = item.NumRecibo;
                    objE_SolicitudEgresoDetalle.Importe = item.Monto;

                    lstListaCajaEgresoDetalle.Add(objE_SolicitudEgresoDetalle);
                }
                objBL_CajaEgresoDetalle.InsertaListaEgresos(lstListaCajaEgresoDetalle);
            }
            catch (Exception ex)
            {

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (mCajaEgresoDetalleDocumentosOrigen2.Count > 0)
                {
                    //if (int.Parse(gvListaEgresos.GetFocusedRowCellValue("IdProveedor").ToString()) != 0)
                    //{
                        int IdCuentaBancoProveedor = 0;
                        if (gvListaEgresos.GetFocusedRowCellValue("IdCajaEgresoDetalle") != null)
                            IdCuentaBancoProveedor = int.Parse(gvListaEgresos.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());

                        int Item = 0;
                        if (gvListaEgresos.GetFocusedRowCellValue("IdCajaEgresoDetalle") != null)
                            Item = int.Parse(gvListaEgresos.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());

                        CuentaBancoBE objBE_CtaBcoProveedor = new CuentaBancoBE();
                        objBE_CtaBcoProveedor.IdCuentaBancoProveedor = IdCuentaBancoProveedor;

                        CuentaBancoBL objBL_CuentaBanco = new CuentaBancoBL();
                        objBL_CuentaBanco.EliminaCuentaBancoProvee(objBE_CtaBcoProveedor);
                        gvListaEgresos.DeleteRow(gvListaEgresos.FocusedRowHandle);
                        gvListaEgresos.RefreshData();
                    //}
                    //else
                    //{
                    //    gvListaEgresos.DeleteRow(gvListaEgresos.FocusedRowHandle);
                    //    gvListaEgresos.RefreshData();
                    //}
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}