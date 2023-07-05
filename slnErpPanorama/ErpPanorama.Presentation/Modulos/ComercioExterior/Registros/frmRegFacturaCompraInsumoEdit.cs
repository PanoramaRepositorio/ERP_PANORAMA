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
    public partial class frmRegFacturaCompraInsumoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<FacturaCompraInsumoDetalleBE> mLista;
        List<FacturaCompraInsumoDetalleBE> mListaSolicitudDetalle = new List<FacturaCompraInsumoDetalleBE>();
        int _IdFacturaCompraInsumo = 0;
        private bool bNacional = false;

        public int IdFacturaCompraInsumo
        {
            get { return _IdFacturaCompraInsumo; }
            set { _IdFacturaCompraInsumo = value; }
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
        public frmRegFacturaCompraInsumoEdit()
        {
            InitializeComponent();
        }

        private void frmRegFacturaCompraInsumoEdit_Load(object sender, EventArgs e)
        {
            //Obtenemos la lista de proveedores
            Parametros.pListaProveedores = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);

            //Obtenemos la lista de Forma de Pago
            Parametros.pListaFormaPago = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago);

            //Obtenemos la lista de Unidades de Medida
            Parametros.pListaUnidadMedida = new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId);

            BSUtils.LoaderLook(cboDocumento, new TipoDocumentoBL().ListaTodosActivo(Parametros.intEmpresaId), "CodTipoDocumento", "IdTipoDocumento", false);
            cboDocumento.EditValue = Parametros.intTipoDocFacturaCompraInsumo;
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

                FacturaCompraInsumoBE objE_FacturaCompraInsumo = new FacturaCompraInsumoBE();

                objE_FacturaCompraInsumo = new FacturaCompraInsumoBL().Selecciona(IdFacturaCompraInsumo);

                IdFacturaCompraInsumo = objE_FacturaCompraInsumo.IdFacturaCompraInsumo;
                cboDocumento.EditValue = objE_FacturaCompraInsumo.IdTipoDocumento;
                txtNumero.Text = objE_FacturaCompraInsumo.NumeroDocumento;
                deFecha.EditValue = objE_FacturaCompraInsumo.FechaCompra;
                deFechaRecepcion.EditValue = objE_FacturaCompraInsumo.FechaRecepcion;
                cboFormaPago.EditValue = objE_FacturaCompraInsumo.IdFormaPago;
                cboProveedor.EditValue = objE_FacturaCompraInsumo.IdProveedor;
                cboMoneda.EditValue = objE_FacturaCompraInsumo.IdMoneda;
                txtTipoCambio.EditValue = objE_FacturaCompraInsumo.TipoCambio;
                txtCantidad.EditValue = objE_FacturaCompraInsumo.Cantidad;
                txtImporte.EditValue = objE_FacturaCompraInsumo.Importe;
                txtObservaciones.Text = objE_FacturaCompraInsumo.Observacion;
                txtDiasCredito.EditValue = objE_FacturaCompraInsumo.DiasCredito;
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
                FacturaCompraInsumoBL objBL_FacturaCompraInsumo = new FacturaCompraInsumoBL();
                FacturaCompraInsumoBE objE_FacturaCompraInsumo = new FacturaCompraInsumoBE();
                objE_FacturaCompraInsumo.IdFacturaCompraInsumo = IdFacturaCompraInsumo;
                objE_FacturaCompraInsumo.IdEmpresa = Parametros.intEmpresaId;
                objE_FacturaCompraInsumo.Periodo = deFecha.DateTime.Year;
                objE_FacturaCompraInsumo.IdTipoDocumento = Parametros.intTipoDocFacturaCompraInsumo;
                objE_FacturaCompraInsumo.NumeroDocumento = txtNumero.Text.Trim();
                objE_FacturaCompraInsumo.IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                objE_FacturaCompraInsumo.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                objE_FacturaCompraInsumo.FechaCompra = Convert.ToDateTime(deFecha.EditValue);
                objE_FacturaCompraInsumo.FechaRecepcion = deFechaRecepcion.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deFechaRecepcion.Text);
                objE_FacturaCompraInsumo.TipoRegistro = "M";
                objE_FacturaCompraInsumo.Importe = Convert.ToDecimal(txtImporte.EditValue);
                objE_FacturaCompraInsumo.IdMoneda = Parametros.intDolares;
                objE_FacturaCompraInsumo.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                objE_FacturaCompraInsumo.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                objE_FacturaCompraInsumo.DiasCredito = Convert.ToInt32(txtDiasCredito.EditValue);
                objE_FacturaCompraInsumo.Observacion = txtObservaciones.Text.Trim();
                objE_FacturaCompraInsumo.FlagRecibido = false;
                objE_FacturaCompraInsumo.FechaRegistro = DateTime.Now;
                objE_FacturaCompraInsumo.FlagEstado = true;
                objE_FacturaCompraInsumo.Usuario = Parametros.strUsuarioLogin;
                objE_FacturaCompraInsumo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_FacturaCompraInsumo.Actualiza(objE_FacturaCompraInsumo, mLista);

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
                FacturaCompraInsumoBE objE_FacturaCompraInsumo = new FacturaCompraInsumoBE();
                objE_FacturaCompraInsumo.IdFacturaCompraInsumo = 0;
                objE_FacturaCompraInsumo.IdEmpresa = Parametros.intEmpresaId;
                objE_FacturaCompraInsumo.Periodo = Parametros.intPeriodo;
                objE_FacturaCompraInsumo.IdTipoDocumento = Parametros.intTipoDocFacturaCompraInsumo;
                objE_FacturaCompraInsumo.NumeroDocumento = Convert.ToString((string)xlHoja.get_Range("B3", Missing.Value).Text.ToString().Trim());
                foreach (ProveedorBE item in Parametros.pListaProveedores)
                {
                    if (item.DescProveedor == (string)xlHoja.get_Range("B1", Missing.Value).Text.ToString().Trim())
                    {
                        objE_FacturaCompraInsumo.IdProveedor = item.IdProveedor;
                    }
                }
                foreach (TablaElementoBE item in Parametros.pListaFormaPago)
                {
                    if (item.DescTablaElemento == (string)xlHoja.get_Range("B4", Missing.Value).Text.ToString().Trim())
                    {
                        objE_FacturaCompraInsumo.IdFormaPago = item.IdTablaElemento;
                    }
                }
                string Fecha = (string)xlHoja.get_Range("B2", Missing.Value).Text.ToString().Trim();
                objE_FacturaCompraInsumo.FechaCompra = Convert.ToDateTime((string)xlHoja.get_Range("B2", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompraInsumo.FechaRecepcion = null;
                objE_FacturaCompraInsumo.TipoRegistro = "A";
                objE_FacturaCompraInsumo.Importe = Convert.ToDecimal((string)xlHoja.get_Range("B7", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompraInsumo.IdMoneda = Parametros.intDolares;
                objE_FacturaCompraInsumo.TipoCambio = Convert.ToDecimal((string)xlHoja.get_Range("B5", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompraInsumo.Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B6", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompraInsumo.DiasCredito = Convert.ToInt32((string)xlHoja.get_Range("D4", Missing.Value).Text.ToString().Trim());
                objE_FacturaCompraInsumo.Observacion = "Ingreso Automatico " + Convert.ToString((string)xlHoja.get_Range("B8", Missing.Value).Text.ToString().Trim()); ;
                objE_FacturaCompraInsumo.FlagRecibido = false;
                objE_FacturaCompraInsumo.FechaRegistro = DateTime.Now;
                objE_FacturaCompraInsumo.FlagEstado = true;
                objE_FacturaCompraInsumo.Usuario = Parametros.strUsuarioLogin;
                objE_FacturaCompraInsumo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                List<FacturaCompraInsumoBE> mListaFactura = new List<FacturaCompraInsumoBE>();
                mListaFactura = new FacturaCompraInsumoBL().ListaProveedor(objE_FacturaCompraInsumo.IdEmpresa, objE_FacturaCompraInsumo.IdProveedor, objE_FacturaCompraInsumo.NumeroDocumento);

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
                        FacturaCompraInsumoDetalleBE objE_FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleBE();
                        objE_FacturaCompraInsumoDetalle.IdFacturaCompraInsumoDetalle = 0;
                        objE_FacturaCompraInsumoDetalle.IdFacturaCompraInsumo = 0;
                        objE_FacturaCompraInsumoDetalle.IdInsumo = 0;
                        CodigoProveedor = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                        objE_FacturaCompraInsumoDetalle.Descripcion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                        objE_FacturaCompraInsumoDetalle.Cantidad = Convert.ToInt32((string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim());
                        objE_FacturaCompraInsumoDetalle.PrecioUnitario = Convert.ToDecimal((string)xlHoja.get_Range("H" + Row, Missing.Value).Text.ToString().Trim());
                        objE_FacturaCompraInsumoDetalle.SubTotal = Convert.ToDecimal((string)xlHoja.get_Range("I" + Row, Missing.Value).Text.ToString().Trim());

                        foreach (UnidadMedidaBE item in Parametros.pListaUnidadMedida)
                        {
                            if (item.Abreviatura.Trim() == (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim())
                            {
                                objE_FacturaCompraInsumoDetalle.IdUnidadMedida = item.IdUnidadMedida;
                            }
                        }
                        if (objE_FacturaCompraInsumoDetalle.IdUnidadMedida == 0)
                        {
                            XtraMessageBox.Show("La Unidad de medida " + (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim() + " no existe, verifique el formato del archivo excel.\nLínea: " + Row.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        objE_FacturaCompraInsumoDetalle.FlagEstado = true;
                        objE_FacturaCompraInsumoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_FacturaCompraInsumoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_FacturaCompraInsumoDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_FacturaCompraInsumoDetalle.Imagen = new FuncionBase().Image2Bytes(ErpPanorama.Presentation.Properties.Resources.noImage);

                        var Buscar = mListaSolicitudDetalle.Where(oB => oB.Descripcion.ToUpper() == objE_FacturaCompraInsumoDetalle.Descripcion.ToUpper()).ToList();
                        if (Buscar.Count > 0)
                        {
                            XtraMessageBox.Show("El código de producto : " + objE_FacturaCompraInsumoDetalle.Descripcion + " se repite en la lista. \n Por favor cierre la ventana, verifique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            mListaSolicitudDetalle.Add(objE_FacturaCompraInsumoDetalle);
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

                    objE_FacturaCompraInsumo.Importe = ImporteCabecera;
                    objE_FacturaCompraInsumo.Cantidad = CantidadTotal;
                    //*------------------------

                    FacturaCompraInsumoBL objBL_FacturaCompraInsumo = new FacturaCompraInsumoBL();
                    objBL_FacturaCompraInsumo.Inserta(objE_FacturaCompraInsumo, mListaSolicitudDetalle);

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
            mLista = new FacturaCompraInsumoDetalleBL().ListaTodosActivo(IdFacturaCompraInsumo);
            gcFacturaCompraInsumoDetalle.DataSource = mLista;
        }

        #endregion


    }
}