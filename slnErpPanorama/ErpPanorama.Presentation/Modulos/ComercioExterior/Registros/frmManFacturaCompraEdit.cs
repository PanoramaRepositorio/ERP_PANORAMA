using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Principal;
using System.Reflection;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmManFacturaCompraEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        List<FacturaCompraDetalleBE> mLista;
        List<FacturaCompraDetalleBE> mListaFacturaDetalle = new List<FacturaCompraDetalleBE>();
        List<CFacturaCompraGasto> mListFacturaCompraGasto=new List<CFacturaCompraGasto>();

        int _IdFacturaCompra = 0;
        private bool bNacional = false;
        public bool bMostrarVenta = false;
        public bool FlagEnviado = false;
        public int IdFacturaCompra
        {
            get { return _IdFacturaCompra; }
            set { _IdFacturaCompra = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        #endregion

        #region "Eventos"

        public frmManFacturaCompraEdit()
        {
            InitializeComponent();
        }

        private void frmManFacturaCompraEdit_Load(object sender, EventArgs e)
        {
            //Obtenemos la lista de proveedores
            Parametros.pListaProveedores = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);

            //Obtenemos la lista de Forma de Pago
            Parametros.pListaFormaPago = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago);

            //Obtenemos la lista de Unidades de Medida
            Parametros.pListaUnidadMedida = new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId);

            //Obtenemos tamaños de contenedor
            Parametros.pListaContenedor = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblContenedor);

            BSUtils.LoaderLook(cboDocumento, new TipoDocumentoBL().ListaTodosActivo(Parametros.intEmpresaId), "CodTipoDocumento", "IdTipoDocumento", false);
            BSUtils.LoaderLook(cboFormaPago, Parametros.pListaFormaPago, "DescTablaElemento", "IdTablaElemento", false);
            BSUtils.LoaderLook(cboProveedor, Parametros.pListaProveedores, "DescProveedor", "IdProveedor", false);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", false);
            BSUtils.LoaderLook(cboFamilia, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", false);
            //BSUtils.LoaderLook(cbFamilia, new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFamiliaProducto", "IdFamiliaProducto", false);
            BSUtils.LoaderLook(cboContenedor, Parametros.pListaContenedor, "DescTablaElemento", "IdTablaElemento", false);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Factura Compra - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {

                cboDocumento.Properties.ReadOnly = true;
                txtNumero.Properties.ReadOnly = true;
                deFecha.Properties.ReadOnly = true;
                cboFormaPago.Properties.ReadOnly = true;
                cboProveedor.Properties.ReadOnly = true;
                deFechaRecepcion.Properties.ReadOnly = true;
                cboMoneda.Properties.ReadOnly = true;
                btnNuevoProveedor.Enabled = false;
                txtImporte.Properties.ReadOnly = true;
                txtImporteTotal.Properties.ReadOnly = true;
                txtTotal.Properties.ReadOnly = true;

                if(FlagEnviado == true)
                {               
                        gvFacturaCompraGasto.OptionsBehavior.Editable = false;
                        EliminatoolStripMenuItem2.Enabled = false;
                        toolStripMenuItem1.Enabled = false;
                }
                
                this.Text = "Factura Compra - Modificar";

                FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                objE_FacturaCompra = new FacturaCompraBL().Selecciona(Parametros.intEmpresaId, IdFacturaCompra);

                cboDocumento.EditValue = objE_FacturaCompra.IdTipoDocumento;
                txtNumero.Text = objE_FacturaCompra.NumeroDocumento;
                deFecha.EditValue = objE_FacturaCompra.FechaCompra;
                deFechaRecepcion.EditValue = objE_FacturaCompra.FechaRecepcion;
                deFechaVencimiento.EditValue= objE_FacturaCompra.FechaVencimiento;
                cboFormaPago.EditValue = objE_FacturaCompra.IdFormaPago;
                cboFamilia.EditValue = objE_FacturaCompra.IdMotivoVenta;
                cboProveedor.EditValue = objE_FacturaCompra.IdProveedor;
                cboMoneda.EditValue = objE_FacturaCompra.IdMoneda;

                txtNroDUA.EditValue = objE_FacturaCompra.NroDUA;
                cboContenedor.EditValue = objE_FacturaCompra.TamañoContenedor;

                txtTipoCambio.EditValue = objE_FacturaCompra.TipoCambio;
                txtCantidad.EditValue = objE_FacturaCompra.Cantidad;
                txtImporte.EditValue = objE_FacturaCompra.Importe;
                txtImporteTotal.EditValue = objE_FacturaCompra.ImportePorPagar;
                txtGastosAdmin.EditValue = objE_FacturaCompra.GastosAdministrativos;
                txtFlete.EditValue = objE_FacturaCompra.Flete;
                txtIpm.EditValue = objE_FacturaCompra.Ipm;
                txtIgv.EditValue = objE_FacturaCompra.Igv;
                txtAdvalorem.EditValue = objE_FacturaCompra.Advalorem;
                txtPercepcion.EditValue = objE_FacturaCompra.Percepcion;
                txtDePercepcion.EditValue = objE_FacturaCompra.Advalorem + objE_FacturaCompra.Percepcion;  //  objE_FacturaCompra.DerechosPercepcion;
                txtDesestiba.EditValue = objE_FacturaCompra.Desestiba;
                txtSobreEstadia.EditValue = objE_FacturaCompra.SobreEstadia;
                txtTotal.EditValue = objE_FacturaCompra.Total;
                txtObservaciones.Text = objE_FacturaCompra.Observacion;
                lblUsuario.Text = objE_FacturaCompra.Usuario;
                lblFechaRegistro.Text = objE_FacturaCompra.FechaRegistro.ToString();
                bNacional = objE_FacturaCompra.FlagNacional;

                if (objE_FacturaCompra.IdMoneda == 5)
                {
                    lbl1.Text = "S/";
                    lbl2.Text = "S/";
                    lbl3.Text = "S/";
                }
                else
                {
                    lbl1.Text = "$";
                    lbl2.Text = "$";
                    lbl3.Text = "$";
                }

                if (bMostrarVenta)
                {
                    this.Size = new Size(903, 585);
                    gvFacturaCompraDetalle.Columns["CantidadVenta"].Visible = true;
                    gvFacturaCompraDetalle.Columns["ImporteVenta"].Visible = true;
                }

                CargarFacturaCompraGasto();                  
            }

            Cargar();
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmManProveedorEdit objManProveedor = new frmManProveedorEdit();
            objManProveedor.lstProveedor = Parametros.pListaProveedores;
            objManProveedor.pOperacion = frmManProveedorEdit.Operacion.Nuevo;
            objManProveedor.IdProveedor = 0;
            objManProveedor.StartPosition = FormStartPosition.CenterParent;
            objManProveedor.ShowDialog();

            BSUtils.LoaderLook(cboProveedor, new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId), "DescProveedor", "IdProveedor", false);
        }

        private void CargarFacturaCompraGasto()
        {
            List<FacturaCompraGastoBE> lstTmpFacturaCompraGasto = null;
            lstTmpFacturaCompraGasto = new FacturaCompraGastoBL().ListaTodosActivo(Parametros.intEmpresaId, IdFacturaCompra);

            foreach (FacturaCompraGastoBE item in lstTmpFacturaCompraGasto)
            {
                CFacturaCompraGasto objE_FacturaCompraGasto = new CFacturaCompraGasto();
                objE_FacturaCompraGasto.IdFacturaCompraGasto = item.IdFacturaCompraGasto;
                objE_FacturaCompraGasto.IdFacturaCompra = item.IdFacturaCompra;
                objE_FacturaCompraGasto.IdTipoGasto = item.IdTipoGasto;
                objE_FacturaCompraGasto.IdMoneda = item.IdMoneda;
                objE_FacturaCompraGasto.Moneda = item.Moneda;
                objE_FacturaCompraGasto.DescTipoGasto = item.DescTipoGasto;
                objE_FacturaCompraGasto.Importe = item.Importe;
                objE_FacturaCompraGasto.TipoOper = item.TipoOper;
                objE_FacturaCompraGasto.FlagEstado = item.FlagEstado;

                mListFacturaCompraGasto.Add(objE_FacturaCompraGasto);
            }

            bsListado.DataSource = mListFacturaCompraGasto;
            gcFacturaCompraGasto.DataSource = bsListado;
            gcFacturaCompraGasto.RefreshDataSource();
        }
        #endregion

        public class CFacturaCompraGasto
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdFacturaCompraGasto { get; set; }
            public Int32 IdFacturaCompra { get; set; }
            public Int32 IdTipoGasto { get; set; }
            public Int32 IdMoneda { get; set; }
            public String Moneda { get; set; }
            public String DescTipoGasto { get; set; }
            public Decimal Importe { get; set; }
            public Boolean FlagEstado { get; set; }
            public Int32 TipoOper { get; set; }

            public CFacturaCompraGasto()
            {

            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (pOperacion == Operacion.Nuevo)
            {
                //Nacional o Importado
                frmOrigenFactura frm = new frmOrigenFactura();
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bNacional = frm.bNacional;

                }

                string _file_excel = "";
                OpenFileDialog objOpenFileDialog = new OpenFileDialog();
                objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xls;*.csv";
                if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _file_excel = objOpenFileDialog.FileName;
                    ImportarExcel(_file_excel, bNacional);
                }
            }
            else
            {
                FacturaCompraGastoBL objBL_FacturaCompraGasto = new FacturaCompraGastoBL();
                List<FacturaCompraGastoBE> lstFacturaCompraGasto = new List<FacturaCompraGastoBE>();

                FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                objE_FacturaCompra = new FacturaCompraBL().Selecciona(Parametros.intEmpresaId, IdFacturaCompra);

                FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                FacturaCompraBE objBE_FacturaCompra = new FacturaCompraBE();
                objBE_FacturaCompra.IdFacturaCompra = IdFacturaCompra;
                objBE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;
                objBE_FacturaCompra.Periodo = deFecha.DateTime.Year;
                objBE_FacturaCompra.IdTipoDocumento = Parametros.intTipoDocFacturaCompra;
                objBE_FacturaCompra.NumeroDocumento = txtNumero.Text.Trim();
                objBE_FacturaCompra.IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                objBE_FacturaCompra.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objBE_FacturaCompra.IdMotivoVenta = Convert.ToInt32(cboFamilia.EditValue);
                objBE_FacturaCompra.FechaCompra = Convert.ToDateTime(deFecha.EditValue);
                objBE_FacturaCompra.FechaRecepcion = deFechaRecepcion.Text == "" ? (DateTime?)null : Convert.ToDateTime(deFechaRecepcion.DateTime.ToShortDateString());
                objBE_FacturaCompra.TipoRegistro = "A";

                objBE_FacturaCompra.Importe = Convert.ToDecimal(txtImporte.EditValue);  //sumatoria del detalle

                objBE_FacturaCompra.GastosAdministrativos = Convert.ToDecimal(txtGastosAdmin.EditValue);
                objBE_FacturaCompra.Flete = Convert.ToDecimal(txtFlete.EditValue);
                objBE_FacturaCompra.Ipm = Convert.ToDecimal(txtIpm.EditValue);
                objBE_FacturaCompra.Igv = Convert.ToDecimal(txtIgv.EditValue);
                objBE_FacturaCompra.Advalorem = Convert.ToDecimal(txtAdvalorem.EditValue);
                objBE_FacturaCompra.Percepcion = Convert.ToDecimal(txtPercepcion.EditValue);
                txtDePercepcion.EditValue =
                Convert.ToDecimal(txtIpm.EditValue) + Convert.ToDecimal(txtIgv.EditValue) + Convert.ToDecimal(txtAdvalorem.EditValue) +
                Convert.ToDecimal(txtPercepcion.EditValue);
                objBE_FacturaCompra.DerechosPercepcion = Convert.ToDecimal(txtDePercepcion.EditValue);
                objBE_FacturaCompra.Desestiba = Convert.ToDecimal(txtDesestiba.EditValue);

                // Add 26-11-21
                objBE_FacturaCompra.SobreEstadia = Convert.ToDecimal(txtSobreEstadia.EditValue);
                objBE_FacturaCompra.NroDUA = txtNroDUA.EditValue.ToString();
                objBE_FacturaCompra.TamañoContenedor = Convert.ToInt32(cboContenedor.EditValue);

                objBE_FacturaCompra.IdMoneda= Parametros.intDolares;
                objBE_FacturaCompra.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objBE_FacturaCompra.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                objBE_FacturaCompra.Observacion = txtObservaciones.Text;
                objBE_FacturaCompra.FlagNacional = bNacional;
                objBE_FacturaCompra.FlagRecibido = false; //BDD TOSO FALSE
                objBE_FacturaCompra.IdSolicitudCompra = null; //BDD TODO FALSE
                objBE_FacturaCompra.FlagEstado = true;
                objBE_FacturaCompra.Usuario = Parametros.strUsuarioLogin;
                objBE_FacturaCompra.Maquina= WindowsIdentity.GetCurrent().Name.ToString();

                //Ingreso Factura Compra Gasto 
                //Documento Vneta Detalle
                decimal TotalImporteGasto = 0;

                foreach (var item in mListFacturaCompraGasto)
                {
                    FacturaCompraGastoBE objE_FacturaCompraGasto = new FacturaCompraGastoBE();
                    objE_FacturaCompraGasto.IdEmpresa = item.IdEmpresa;
                    objE_FacturaCompraGasto.IdFacturaCompraGasto = item.IdFacturaCompraGasto;
                    objE_FacturaCompraGasto.IdFacturaCompra = objBE_FacturaCompra.IdFacturaCompra;
                    objE_FacturaCompraGasto.IdTipoGasto = item.IdTipoGasto;
                    objE_FacturaCompraGasto.IdMoneda = Parametros.intDolares;
                    objE_FacturaCompraGasto.Importe = item.Importe;
                    objE_FacturaCompraGasto.FlagEstado = true;
                    objE_FacturaCompraGasto.TipoOper = item.TipoOper;
                    objE_FacturaCompraGasto.Usuario = Parametros.strUsuarioLogin;
                    objE_FacturaCompraGasto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    TotalImporteGasto = TotalImporteGasto + item.Importe;

                    lstFacturaCompraGasto.Add(objE_FacturaCompraGasto);
                }


                objBE_FacturaCompra.ImportePorPagar = objBE_FacturaCompra.Importe + TotalImporteGasto;
                txtImporteTotal.EditValue = Convert.ToDecimal( TotalImporteGasto) + Convert.ToDecimal( txtImporte.EditValue);

                if(Convert.ToInt32(txtImporteTotal.EditValue) == 0)
                {
                    txtTotal.EditValue =
                                   Convert.ToDecimal(txtGastosAdmin.EditValue) +
                                   Convert.ToDecimal(txtFlete.EditValue) +
                                   Convert.ToDecimal(txtDePercepcion.EditValue)  +
                                   Convert.ToDecimal(txtDesestiba.EditValue) +
                                   Convert.ToDecimal(txtImporte.EditValue);
                    objBE_FacturaCompra.Total = Convert.ToDecimal(txtTotal.EditValue);
                }
                else
                {
                    txtTotal.EditValue =
                                   Convert.ToDecimal(txtGastosAdmin.EditValue) +
                                   Convert.ToDecimal(txtFlete.EditValue) +
                                   Convert.ToDecimal(txtDePercepcion.EditValue) +
                                   Convert.ToDecimal(txtDesestiba.EditValue) +
                                   Convert.ToDecimal(txtImporteTotal.EditValue);
                    objBE_FacturaCompra.Total = Convert.ToDecimal(txtTotal.EditValue);
                }
               

                objBL_FacturaCompra.Actualiza(objBE_FacturaCompra, mLista);

                if (mListFacturaCompraGasto.Count>0)
                {

                    objBL_FacturaCompraGasto.Actualiza(lstFacturaCompraGasto);
                }
                else
                {
                     objBL_FacturaCompraGasto.Inserta(lstFacturaCompraGasto);
                }
             
            }

            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "Metodos"

        

        private void ImportarExcel(string filename, bool vNacional)
        {

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

            int Row = 17;
            int TotRow = 17;

            string CodigoProveedor = "";

            try
            {
                //Contador de Registros
                while ((string)xlHoja.get_Range("B" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("B" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;

                //Establecemos los datos de la factura de compra
                FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                objE_FacturaCompra.vNacionales = vNacional;
                objE_FacturaCompra.IdFacturaCompra = 0;
                objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;
                objE_FacturaCompra.Periodo = Parametros.intPeriodo;
                objE_FacturaCompra.IdTipoDocumento = Parametros.intTipoDocFacturaCompra;
                objE_FacturaCompra.NumeroDocumento = Convert.ToString((string)xlHoja.get_Range("B4", Missing.Value).Text.ToString().Trim());
                foreach (ProveedorBE item in Parametros.pListaProveedores)
                {
                    if (item.DescProveedor == (string)xlHoja.get_Range("B1", Missing.Value).Text.ToString().Trim())
                    {
                        objE_FacturaCompra.IdProveedor = item.IdProveedor;
                    }

                }
                string FormaPago = (string)xlHoja.get_Range("B5", Missing.Value).Text.ToString().Trim();
                bool bFormaPago = false;
                
                foreach (TablaElementoBE item in Parametros.pListaFormaPago)
                {
                    //if (item.DescTablaElemento ==  (string)xlHoja.get_Range("B4", Missing.Value).Text.ToString().Trim())
                    if (item.DescTablaElemento == FormaPago.ToUpper())
                    {
                        objE_FacturaCompra.IdFormaPago = item.IdTablaElemento;
                        bFormaPago = true;
                    }
                    //Validar si no existe
                }
                if (!bFormaPago)
                {
                    XtraMessageBox.Show("La forma de pago " + FormaPago + " no existe en la base de datos.\nPor favor verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string MotivoVenta = (string)xlHoja.get_Range("B6", Missing.Value).Text.ToString().Trim();
                bool bMotivoVenta = false;
                List<TablaElementoBE> plistaMotivoVenta = new List<TablaElementoBE>();
                //plistaMotivoVenta = TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMotivoVenta
                plistaMotivoVenta = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMotivoVenta);
                
                foreach (TablaElementoBE item in plistaMotivoVenta)
                {
                    //if (item.DescTablaElemento ==  (string)xlHoja.get_Range("B4", Missing.Value).Text.ToString().Trim())
                    if (item.DescTablaElemento == MotivoVenta.ToUpper())
                    {
                        objE_FacturaCompra.IdMotivoVenta = item.IdTablaElemento;
                        bMotivoVenta = true;
                    }
                    //Validar si no existe
                }
                if (!bMotivoVenta)
                {
                    XtraMessageBox.Show("La Familia " + MotivoVenta + " no existe en la base de datos.\nPor favor verificar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Fecha = (string)xlHoja.get_Range("B2", Missing.Value).Text.ToString().Trim();
                objE_FacturaCompra.FechaCompra = Convert.ToDateTime((string)xlHoja.get_Range("B2", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.FechaRecepcion = null;
                if(bNacional)
                {
                    objE_FacturaCompra.FechaVencimiento = null;
                }
                else
                {
                    objE_FacturaCompra.FechaVencimiento = Convert.ToDateTime((string)xlHoja.get_Range("B3", Missing.Value).Text.ToString().Trim());
                }
                if(FormaPago=="CREDITO")
                { 
                    objE_FacturaCompra.IdSituacionPago = Parametros.intSitPendienteCon;
                }
                else
                {
                    objE_FacturaCompra.IdSituacionPago = Parametros.intSitPagadoCon;
                }

                objE_FacturaCompra.TipoRegistro = "A";
                objE_FacturaCompra.Importe = Convert.ToDecimal((string)xlHoja.get_Range("B9", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.ImportePorPagar= Convert.ToDecimal((string)xlHoja.get_Range("B9", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.GastosAdministrativos= Convert.ToDecimal((string)xlHoja.get_Range("B11", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.Flete = Convert.ToDecimal((string)xlHoja.get_Range("B12", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.DerechosPercepcion = Convert.ToDecimal((string)xlHoja.get_Range("B13", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.Desestiba = Convert.ToDecimal((string)xlHoja.get_Range("B14", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.Total = Convert.ToDecimal((string)xlHoja.get_Range("B15", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.IdMoneda = Parametros.intDolares;
                objE_FacturaCompra.TipoCambio = Convert.ToDecimal((string)xlHoja.get_Range("B7", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompra.Cantidad =  Convert.ToInt32(Convert.ToDecimal((string)xlHoja.get_Range("B8", Missing.Value).Text.ToString().Trim()));
                objE_FacturaCompra.Observacion = "Ingreso Automatico " + Convert.ToString((string)xlHoja.get_Range("B10", Missing.Value).Text.ToString().Trim()); ;
                objE_FacturaCompra.FlagRecibido = false;
                objE_FacturaCompra.FlagMuestra = chkMuestra.Checked;
                objE_FacturaCompra.FlagNacional = bNacional;
                objE_FacturaCompra.FlagEstado = true;
                objE_FacturaCompra.Usuario = Parametros.strUsuarioLogin;
                objE_FacturaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                List<FacturaCompraBE> mListaFactura = new List<FacturaCompraBE>();
                mListaFactura = new FacturaCompraBL().ListaProveedor(objE_FacturaCompra.IdEmpresa, objE_FacturaCompra.IdProveedor, objE_FacturaCompra.NumeroDocumento);

                if (mListaFactura.Count > 0)
                {
                    XtraMessageBox.Show("La Factura de Compra ya existe en la base de datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xlLibro.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();
                    return;
                }
                else
                {
                    //Recorremos para el detalle de la Factura
                    while ((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                    {
                        FacturaCompraDetalleBE objE_FacturaCompraDetalle = new FacturaCompraDetalleBE();
                        objE_FacturaCompraDetalle.IdFacturaCompraDetalle = 0;
                        objE_FacturaCompraDetalle.IdFacturaCompra = 0;
                        objE_FacturaCompraDetalle.IdProducto = 0;
                        CodigoProveedor = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                        objE_FacturaCompraDetalle.CodigoProveedor = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                        objE_FacturaCompraDetalle.NombreProducto = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                        objE_FacturaCompraDetalle.NumeroBultos = Convert.ToInt32((string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim());
                        objE_FacturaCompraDetalle.Cantidad = Convert.ToInt32((string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim());
                        objE_FacturaCompraDetalle.CantidadUM = Convert.ToInt32((string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim());
                        objE_FacturaCompraDetalle.PrecioUnitario = Convert.ToDecimal((string)xlHoja.get_Range("H" + Row, Missing.Value).Text.ToString().Trim());
                        objE_FacturaCompraDetalle.SubTotal = Convert.ToDecimal((string)xlHoja.get_Range("I" + Row, Missing.Value).Text.ToString().Trim());

                        foreach (UnidadMedidaBE item in Parametros.pListaUnidadMedida)
                        {
                            if (item.Abreviatura.Trim() == (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim())
                            {
                                objE_FacturaCompraDetalle.IdUnidadMedida = item.IdUnidadMedida;
                            }
                        }
                        if (objE_FacturaCompraDetalle.IdUnidadMedida == 0)
                        {
                            XtraMessageBox.Show("La Unidad de medida " + (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim() + " no existe, verifique el formato del archivo excel.\nLínea: " + Row.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        objE_FacturaCompraDetalle.FlagEstado = true;
                        objE_FacturaCompraDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_FacturaCompraDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_FacturaCompraDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_FacturaCompraDetalle.Imagen = new FuncionBase().Image2Bytes(ErpPanorama.Presentation.Properties.Resources.noImage);

                        var Buscar = mListaFacturaDetalle.Where(oB => oB.CodigoProveedor.ToUpper() == objE_FacturaCompraDetalle.CodigoProveedor.ToUpper()).ToList();
                        if (Buscar.Count > 0)
                        {

                            XtraMessageBox.Show("El código de producto : " + objE_FacturaCompraDetalle.CodigoProveedor + " se repite en la lista. \n Por favor cierre la ventana, verifique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            mListaFacturaDetalle.Add(objE_FacturaCompraDetalle);
                        }

                        prgFactura.PerformStep();
                        prgFactura.Update();

                        Row++;
                    }

                    //Totales
                    decimal ImporteCabecera = 0;
                    int CantidadTotal = 0;
                    foreach (var item in mListaFacturaDetalle)
                    {
                        ImporteCabecera = ImporteCabecera + item.SubTotal;
                        CantidadTotal = CantidadTotal + item.Cantidad;
                    }

                    objE_FacturaCompra.Importe = ImporteCabecera;
                    objE_FacturaCompra.Cantidad = CantidadTotal;
                    //*------------------------

                    FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                    objBL_FacturaCompra.Inserta(objE_FacturaCompra, mListaFacturaDetalle);

                    XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Codigo : " + CodigoProveedor.ToString() + " Linea : " + Row.ToString() + " \n Por favor cierre la ventana, verifique el formato del archivo excel.\n-Cantidad no debe tener Decimales", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar()
        {
            mLista = new FacturaCompraDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdFacturaCompra);
            gcFacturaCompraDetalle.DataSource = mLista;
        }

        private void CargarFoto()
        {
            mLista = new FacturaCompraDetalleBL().ListaTodosImagen(Parametros.intEmpresaId, IdFacturaCompra);
            gcFacturaCompraDetalle.DataSource = mLista;
        }

        #endregion

        private void bntImportarDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                frmManFacturaCompraDocumentoEdit objManFacturaCompra = new frmManFacturaCompraDocumentoEdit();
                objManFacturaCompra.pOperacion = frmManFacturaCompraDocumentoEdit.Operacion.Nuevo;
                objManFacturaCompra.IdFacturaCompra = 0;
                objManFacturaCompra.StartPosition = FormStartPosition.CenterParent;
                //objManFacturaCompra.ShowDialog();
                if (objManFacturaCompra.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportarSolicitudCompra_Click(object sender, EventArgs e)
        {
            try
            {
                frmManFacturaCompraSolicitudCompraEdit objManFacturaCompra = new frmManFacturaCompraSolicitudCompraEdit();
                objManFacturaCompra.pOperacion = frmManFacturaCompraSolicitudCompraEdit.Operacion.Nuevo;
                objManFacturaCompra.IdFacturaCompra = 0;
                objManFacturaCompra.StartPosition = FormStartPosition.CenterParent;
                //objManFacturaCompra.ShowDialog();
                if (objManFacturaCompra.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkMostrarFoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarFoto.Checked)
            {
                CargarFoto();
                gridColumn21.Visible = true;
                gvFacturaCompraDetalle.RowHeight = 75;

                this.Size = new Size(1087, 693);
            }
            else
            {
                Cargar();
                gridColumn21.Visible = false;
                gvFacturaCompraDetalle.RowHeight = -1;
            }
        }

        private void txtGastosAdmin_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtImporteTotal.EditValue) == 0)
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue) ) +
                               (Convert.ToDecimal(txtDesestiba.EditValue)) +
                               Convert.ToDecimal(txtImporte.EditValue);
            }
            else
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue) ) +
                               (Convert.ToDecimal(txtDesestiba.EditValue)) +
                               Convert.ToDecimal(txtImporteTotal.EditValue);
            }
        }

        private void txtFlete_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtImporteTotal.EditValue) == 0)
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue) ) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporte.EditValue);
            }
            else
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue) ) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporteTotal.EditValue);
            }
        }

        private void txtPercepcion_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtImporteTotal.EditValue) == 0)
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue) ) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporte.EditValue);
            }
            else
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue)) +
                               (Convert.ToDecimal(txtDesestiba.EditValue)) +
                               Convert.ToDecimal(txtImporteTotal.EditValue);
            }

        }

        private void txtDesestiba_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtImporteTotal.EditValue) == 0)
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue) ) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporte.EditValue);
            }
            else
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue) ) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporteTotal.EditValue);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmBuscaTablaElemento objTablaElemento = new frmBuscaTablaElemento();
            objTablaElemento.IdTabla = Parametros.intTblFacturaCompraTipoGasto;
            objTablaElemento.StartPosition = FormStartPosition.CenterParent;
            objTablaElemento.ShowDialog();
            if (objTablaElemento.pTablaElementoBE != null)
            {
                int index = gvFacturaCompraGasto.FocusedRowHandle;

                gvFacturaCompraGasto.AddNewRow();
                gvFacturaCompraGasto.SetRowCellValue(gvFacturaCompraGasto.FocusedRowHandle, "IdTipoGasto", objTablaElemento.pTablaElementoBE.IdTablaElemento);
                gvFacturaCompraGasto.SetRowCellValue(gvFacturaCompraGasto.FocusedRowHandle, "DescTipoGasto", objTablaElemento.pTablaElementoBE.DescTablaElemento);
                gvFacturaCompraGasto.SetRowCellValue(gvFacturaCompraGasto.FocusedRowHandle, "TipoOper",Operacion.Nuevo);
                gvFacturaCompraGasto.SetRowCellValue(gvFacturaCompraGasto.FocusedRowHandle, "Moneda", "US$");
                gvFacturaCompraGasto.UpdateCurrentRow();
                gvFacturaCompraGasto.FocusedColumn = gvFacturaCompraGasto.Columns["Importe"];
                gvFacturaCompraGasto.ShowEditor();


            }
        }

        private void EliminatoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int IdFacturaCompraGasto = 0;

            //int IdProformaDetalle = 0;
            if (gvFacturaCompraGasto.GetFocusedRowCellValue("IdFacturaCompraGasto") != null)
                IdFacturaCompraGasto = int.Parse(gvFacturaCompraGasto.GetFocusedRowCellValue("IdFacturaCompraGasto").ToString());

            FacturaCompraGastoBE objBE_FacturaCompraGasto = new FacturaCompraGastoBE();
            objBE_FacturaCompraGasto.IdFacturaCompraGasto = IdFacturaCompraGasto;
            objBE_FacturaCompraGasto.IdEmpresa = Parametros.intEmpresaId;
            objBE_FacturaCompraGasto.Usuario = Parametros.strUsuarioLogin;
            objBE_FacturaCompraGasto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();


            FacturaCompraGastoBL objBL_FacturaCompraGasto = new FacturaCompraGastoBL();
            objBL_FacturaCompraGasto.Elimina(objBE_FacturaCompraGasto);
            gvFacturaCompraGasto.DeleteRow(gvFacturaCompraGasto.FocusedRowHandle);
            gvFacturaCompraGasto.RefreshData();
        }

        private void gvFacturaCompraGasto_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
              if (e.Column.FieldName == "Importe")
            {
                if (pOperacion == Operacion.Modificar)
                {
                    if (Convert.ToDecimal(gvFacturaCompraGasto.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                        gvFacturaCompraGasto.SetRowCellValue(e.RowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    else
                        gvFacturaCompraGasto.SetRowCellValue(e.RowHandle, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                }
            }
        }

        private void gcFacturaCompraDetalle_Click(object sender, EventArgs e)
        {

        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtLpm_EditValueChanged(object sender, EventArgs e)
        {
            //CalcularTotalDerPercepcion();
            if (Convert.ToInt32(txtImporteTotal.EditValue) == 0)
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue)) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporte.EditValue);
            }
            else
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue) ) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporteTotal.EditValue);
            }
        }

        private void txtIgv_EditValueChanged(object sender, EventArgs e)
        {
            //CalcularTotalDerPercepcion();
            if (Convert.ToInt32(txtImporteTotal.EditValue) == 0)
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue)) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporte.EditValue);
            }
            else
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue)) +
                               (Convert.ToDecimal(txtDesestiba.EditValue)) +
                               Convert.ToDecimal(txtImporteTotal.EditValue);
            }
        }

        private void txtAdvalorem_EditValueChanged(object sender, EventArgs e)
        {
            CalcularTotalDerPercepcion();
        }

        private void txtPercepcion_EditValueChanged_1(object sender, EventArgs e)
        {
            CalcularTotalDerPercepcion();
        }

        private void CalcularTotalDerPercepcion()
        {
            
            txtDePercepcion.EditValue =  Convert.ToDecimal(txtAdvalorem.EditValue) + Convert.ToDecimal(txtPercepcion.EditValue);
        }

        private void txtSobreEstadia_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtImporteTotal.EditValue) == 0)
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue)) +
                               (Convert.ToDecimal(txtDesestiba.EditValue)) +
                               Convert.ToDecimal(txtImporte.EditValue);

                //txtTotal.EditValue =
                //               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                //               Convert.ToDecimal(txtFlete.EditValue) +
                //               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                //               Convert.ToDecimal(txtIpm.EditValue) +
                //               Convert.ToDecimal(txtIgv.EditValue) +
                //               (Convert.ToDecimal(txtDePercepcion.EditValue) / Convert.ToDecimal(txtTipoCambio.Text)) +
                //               (Convert.ToDecimal(txtDesestiba.EditValue) / Convert.ToDecimal(txtTipoCambio.Text)) +
                //               Convert.ToDecimal(txtImporte.EditValue);

            }
            else
            {
                txtTotal.EditValue =
                               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                               Convert.ToDecimal(txtFlete.EditValue) +
                               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                               Convert.ToDecimal(txtIpm.EditValue) +
                               Convert.ToDecimal(txtIgv.EditValue) +
                               (Convert.ToDecimal(txtDePercepcion.EditValue)) +
                               (Convert.ToDecimal(txtDesestiba.EditValue) ) +
                               Convert.ToDecimal(txtImporteTotal.EditValue);
                //txtTotal.EditValue =
                //               Convert.ToDecimal(txtGastosAdmin.EditValue) +
                //               Convert.ToDecimal(txtFlete.EditValue) +
                //               Convert.ToDecimal(txtSobreEstadia.EditValue) +
                //               Convert.ToDecimal(txtIpm.EditValue) +
                //               Convert.ToDecimal(txtIgv.EditValue) +
                //               (Convert.ToDecimal(txtDePercepcion.EditValue) / Convert.ToDecimal(txtTipoCambio.Text)) +
                //               (Convert.ToDecimal(txtDesestiba.EditValue) / Convert.ToDecimal(txtTipoCambio.Text)) +
                //               Convert.ToDecimal(txtImporteTotal.EditValue);
            }
        }
    }
}