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

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmManSolicitudCompraEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        List<SolicitudCompraDetalleBE> mLista;
        List<SolicitudCompraDetalleBE> mListaSolicitudDetalle = new List<SolicitudCompraDetalleBE>();
        int _IdSolicitudCompra = 0;
        private bool bNacional = false;

        public int IdSolicitudCompra
        {
            get { return _IdSolicitudCompra; }
            set { _IdSolicitudCompra = value; }
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

        public frmManSolicitudCompraEdit()
        {
            InitializeComponent();
        }

        private void frmManSolicitudCompraEdit_Load(object sender, EventArgs e)
        {
            //Obtenemos la lista de proveedores
            Parametros.pListaProveedores = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);

            //Obtenemos la lista de Forma de Pago
            Parametros.pListaFormaPago = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago);

            //Obtenemos la lista de Unidades de Medida
            Parametros.pListaUnidadMedida = new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId);

            BSUtils.LoaderLook(cboDocumento, new TipoDocumentoBL().ListaTodosActivo(Parametros.intEmpresaId), "CodTipoDocumento", "IdTipoDocumento", false);
            cboDocumento.EditValue = Parametros.intTipoDocSolicitudCompra;
            BSUtils.LoaderLook(cboFormaPago, Parametros.pListaFormaPago, "DescTablaElemento", "IdTablaElemento", false);
            BSUtils.LoaderLook(cboProveedor, Parametros.pListaProveedores, "DescProveedor", "IdProveedor", false);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", false);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Solicitud Compra - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Solicitud Compra - Modificar";

                SolicitudCompraBE objE_SolicitudCompra = new SolicitudCompraBE();

                objE_SolicitudCompra = new SolicitudCompraBL().Selecciona(Parametros.intEmpresaId, IdSolicitudCompra);

                IdSolicitudCompra = objE_SolicitudCompra.IdSolicitudCompra;
                cboDocumento.EditValue = objE_SolicitudCompra.IdTipoDocumento;
                txtNumero.Text = objE_SolicitudCompra.NumeroDocumento;
                deFecha.EditValue = objE_SolicitudCompra.FechaCompra;
                deFechaRecepcion.EditValue = objE_SolicitudCompra.FechaRecepcion;
                cboFormaPago.EditValue = objE_SolicitudCompra.IdFormaPago;
                cboProveedor.EditValue = objE_SolicitudCompra.IdProveedor;
                cboMoneda.EditValue = objE_SolicitudCompra.IdMoneda;
                txtTipoCambio.EditValue = objE_SolicitudCompra.TipoCambio;
                txtCantidad.EditValue = objE_SolicitudCompra.Cantidad;
                txtImporte.EditValue = objE_SolicitudCompra.Importe;
                txtObservaciones.Text = objE_SolicitudCompra.Observacion;
                txtDiasCredito.EditValue = objE_SolicitudCompra.DiasCredito;
                deFechaEmbarque.EditValue = objE_SolicitudCompra.FechaEmbarque;
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


        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                //Nacional o Importado
                frmOrigenFactura frm = new frmOrigenFactura();
                frm.StartPosition = FormStartPosition.CenterParent;
                //frm.ShowDialog();
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
                    ImportarExcel(_file_excel);
                }
            }
            else
            {
                //Establecemos los datos de la factura de compra
                SolicitudCompraBL objBL_SolicitudCompra = new SolicitudCompraBL();
                SolicitudCompraBE objE_SolicitudCompra = new SolicitudCompraBE();
                objE_SolicitudCompra.IdSolicitudCompra = IdSolicitudCompra;
                objE_SolicitudCompra.IdEmpresa = Parametros.intEmpresaId;
                objE_SolicitudCompra.Periodo = deFecha.DateTime.Year;
                objE_SolicitudCompra.IdTipoDocumento = Parametros.intTipoDocSolicitudCompra;
                objE_SolicitudCompra.NumeroDocumento = txtNumero.Text.Trim();
                objE_SolicitudCompra.IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                objE_SolicitudCompra.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objE_SolicitudCompra.FechaCompra = Convert.ToDateTime(deFecha.EditValue);
                objE_SolicitudCompra.FechaRecepcion = deFechaRecepcion.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deFechaRecepcion.Text);
                objE_SolicitudCompra.FechaEmbarque = deFechaEmbarque.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deFechaEmbarque.Text);
                objE_SolicitudCompra.TipoRegistro = "M";
                objE_SolicitudCompra.Importe = Convert.ToDecimal(txtImporte.EditValue);
                objE_SolicitudCompra.IdMoneda = Parametros.intDolares;
                objE_SolicitudCompra.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objE_SolicitudCompra.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                objE_SolicitudCompra.DiasCredito = Convert.ToInt32(txtDiasCredito.EditValue);
                objE_SolicitudCompra.Observacion = txtObservaciones.Text.Trim();
                objE_SolicitudCompra.FlagRecibido = false;
                objE_SolicitudCompra.FlagMuestra = chkMuestra.Checked;
                objE_SolicitudCompra.FlagNacional = false;
                objE_SolicitudCompra.FechaRegistro = DateTime.Now;
                objE_SolicitudCompra.FlagEstado = true;
                objE_SolicitudCompra.Usuario = Parametros.strUsuarioLogin;
                objE_SolicitudCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_SolicitudCompra.Actualiza(objE_SolicitudCompra, mLista);

                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "Metodos"


        private void ImportarExcel(string filename)
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

            int Row = 10;
            int TotRow = 10;

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
                SolicitudCompraBE objE_SolicitudCompra = new SolicitudCompraBE();
                objE_SolicitudCompra.IdSolicitudCompra = 0;
                objE_SolicitudCompra.IdEmpresa = Parametros.intEmpresaId;
                objE_SolicitudCompra.Periodo = Parametros.intPeriodo;
                objE_SolicitudCompra.IdTipoDocumento = Parametros.intTipoDocSolicitudCompra;
                objE_SolicitudCompra.NumeroDocumento = Convert.ToString((string)xlHoja.get_Range("B3", Missing.Value).Text.ToString().Trim());
                foreach (ProveedorBE item in Parametros.pListaProveedores)
                {
                    if (item.DescProveedor == (string)xlHoja.get_Range("B1", Missing.Value).Text.ToString().Trim())
                    {
                        objE_SolicitudCompra.IdProveedor = item.IdProveedor;
                    }
                }
                foreach (TablaElementoBE item in Parametros.pListaFormaPago)
                {
                    if (item.DescTablaElemento == (string)xlHoja.get_Range("B4", Missing.Value).Text.ToString().Trim())
                    {
                        objE_SolicitudCompra.IdFormaPago = item.IdTablaElemento;
                    }
                }
                string Fecha = (string)xlHoja.get_Range("B2", Missing.Value).Text.ToString().Trim();
                objE_SolicitudCompra.FechaCompra = Convert.ToDateTime((string)xlHoja.get_Range("B2", Missing.Value).Text.ToString().Trim());
                objE_SolicitudCompra.FechaRecepcion = null;
                objE_SolicitudCompra.TipoRegistro = "A";
                objE_SolicitudCompra.Importe = Convert.ToDecimal((string)xlHoja.get_Range("B7", Missing.Value).Text.ToString().Trim());
                objE_SolicitudCompra.IdMoneda = Parametros.intDolares;
                objE_SolicitudCompra.TipoCambio = Convert.ToDecimal((string)xlHoja.get_Range("B5", Missing.Value).Text.ToString().Trim());
                objE_SolicitudCompra.Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B6", Missing.Value).Text.ToString().Trim());
                objE_SolicitudCompra.DiasCredito = Convert.ToInt32((string)xlHoja.get_Range("D4", Missing.Value).Text.ToString().Trim());
                objE_SolicitudCompra.Observacion = "Ingreso Automatico " + Convert.ToString((string)xlHoja.get_Range("B8", Missing.Value).Text.ToString().Trim()); ;
                objE_SolicitudCompra.FlagRecibido = false;
                objE_SolicitudCompra.FlagMuestra = chkMuestra.Checked;
                objE_SolicitudCompra.FlagNacional = bNacional;
                objE_SolicitudCompra.FechaRegistro = DateTime.Now;
                objE_SolicitudCompra.FlagEstado = true;
                objE_SolicitudCompra.Usuario = Parametros.strUsuarioLogin;
                objE_SolicitudCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                List<SolicitudCompraBE> mListaFactura = new List<SolicitudCompraBE>();
                mListaFactura = new SolicitudCompraBL().ListaProveedor(objE_SolicitudCompra.IdEmpresa, objE_SolicitudCompra.IdProveedor, objE_SolicitudCompra.NumeroDocumento);

                if (mListaFactura.Count > 0)
                {
                    XtraMessageBox.Show("La Solicitud de Compra ya existe en la base de datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xlLibro.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();
                    return;
                }
                else
                {

                    //Recorremos para el detalle de la Factura
                    while ((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                    {
                        SolicitudCompraDetalleBE objE_SolicitudCompraDetalle = new SolicitudCompraDetalleBE();
                        objE_SolicitudCompraDetalle.IdSolicitudCompraDetalle = 0;
                        objE_SolicitudCompraDetalle.IdSolicitudCompra = 0;
                        objE_SolicitudCompraDetalle.IdProducto = 0;
                        CodigoProveedor = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                        objE_SolicitudCompraDetalle.CodigoProveedor = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                        objE_SolicitudCompraDetalle.NombreProducto = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                        objE_SolicitudCompraDetalle.NumeroBultos = Convert.ToInt32((string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim());
                        objE_SolicitudCompraDetalle.Cantidad = Convert.ToInt32((string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim());
                        objE_SolicitudCompraDetalle.CantidadUM = Convert.ToInt32((string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim());
                        objE_SolicitudCompraDetalle.PrecioUnitario = Convert.ToDecimal((string)xlHoja.get_Range("H" + Row, Missing.Value).Text.ToString().Trim());
                        objE_SolicitudCompraDetalle.SubTotal = Convert.ToDecimal((string)xlHoja.get_Range("I" + Row, Missing.Value).Text.ToString().Trim());
                        objE_SolicitudCompraDetalle.CBM = (string)xlHoja.get_Range("J" + Row, Missing.Value).Text.ToString().Trim();
                        objE_SolicitudCompraDetalle.Peso = Convert.ToDecimal((string)xlHoja.get_Range("K" + Row, Missing.Value).Text.ToString().Trim());

                        foreach (UnidadMedidaBE item in Parametros.pListaUnidadMedida)
                        {
                            if (item.Abreviatura.Trim() == (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim())
                            {
                                objE_SolicitudCompraDetalle.IdUnidadMedida = item.IdUnidadMedida;
                            }
                        }
                        if (objE_SolicitudCompraDetalle.IdUnidadMedida == 0)
                        {
                            XtraMessageBox.Show("La Unidad de medida " + (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim() + " no existe, verifique el formato del archivo excel.\nLínea: " + Row.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        objE_SolicitudCompraDetalle.FlagEstado = true;
                        objE_SolicitudCompraDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_SolicitudCompraDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_SolicitudCompraDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_SolicitudCompraDetalle.Imagen = new FuncionBase().Image2Bytes(ErpPanorama.Presentation.Properties.Resources.noImage);

                        var Buscar = mListaSolicitudDetalle.Where(oB => oB.CodigoProveedor.ToUpper() == objE_SolicitudCompraDetalle.CodigoProveedor.ToUpper()).ToList();
                        if (Buscar.Count > 0)
                        {

                            XtraMessageBox.Show("El código de producto : " + objE_SolicitudCompraDetalle.CodigoProveedor + " se repite en la lista. \n Por favor cierre la ventana, verifique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            mListaSolicitudDetalle.Add(objE_SolicitudCompraDetalle);
                        }

                        prgFactura.PerformStep();
                        prgFactura.Update();

                        Row++;
                    }

                    //Totales
                    decimal ImporteCabecera = 0;
                    int CantidadTotal = 0;
                    int CantidadItems = 0;
                    foreach (var item in mListaSolicitudDetalle)
                    {
                        ImporteCabecera = ImporteCabecera + item.SubTotal;
                        CantidadTotal = CantidadTotal + item.Cantidad;
                        CantidadItems = CantidadItems + 1;
                    }

                    objE_SolicitudCompra.Importe = ImporteCabecera;
                    objE_SolicitudCompra.Cantidad = CantidadTotal;
                    objE_SolicitudCompra.Items = CantidadItems;
                    //*------------------------

                    SolicitudCompraBL objBL_SolicitudCompra = new SolicitudCompraBL();
                    objBL_SolicitudCompra.Inserta(objE_SolicitudCompra, mListaSolicitudDetalle);

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
                XtraMessageBox.Show(ex.Message + "Codigo : " + CodigoProveedor.ToString() + " Linea : " + Row.ToString() + " \n Por favor cierre la ventana, verifique el formato del archivo excel.\n-Cantidad y Datos del Bulto no debe tener Decimales", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar()
        {
            mLista = new SolicitudCompraDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdSolicitudCompra);
            gcSolicitudCompraDetalle.DataSource = mLista;
        }

        #endregion


    }
}