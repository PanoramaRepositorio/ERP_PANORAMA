using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConVentaProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();
        private int IdProducto = 0;
        
        #endregion

        #region "Eventos"

        public frmConVentaProducto()
        {
            InitializeComponent();
        }

        private void frnConVentaProducto_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    ProductoBE objE_Producto = null;
            //    objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
            //    if (objE_Producto != null)
            //    {
            //        IdProducto = objE_Producto.IdProducto;
            //        txtCodigo.Text = objE_Producto.CodigoProveedor;
            //        txtNombreProducto.Text = objE_Producto.NombreProducto;

            //        btnConsultar.Focus();
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusProducto frm = new frmBusProducto();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pProductoBE != null)
                {
                    IdProducto = frm.pProductoBE.IdProducto;
                    txtCodigo.Text = frm.pProductoBE.CodigoProveedor;
                    txtNombreProducto.Text = frm.pProductoBE.NombreProducto;
                }

                btnConsultar.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdProducto == 0)
            {
                XtraMessageBox.Show("Debe ingresar un código de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cargar();
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoVentaProductos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumentoVenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void gvDocumentoVenta_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                optCodigo.Checked = true;
                txtCodigo.Select();
            }
            if (keyData == Keys.F6)
            {
                optHangTag.Checked = true;
                txtCodigo.Select();
                //txtCodigo.SelectAll();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void chkMultiempresa_CheckedChanged(object sender, EventArgs e)
        {
            if (IdProducto > 0)
            {
                Cargar();
            }
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCodigo.Checked)
            {
                txtCodigo.Select();
                txtCodigo.SelectAll();
            }
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (optHangTag.Checked)
            {
                txtCodigo.Select();
                txtCodigo.SelectAll();
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    if (optCodigo.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        int Resultado = 0; //add 240616
                        Resultado = new ProductoBL().SeleccionaBusquedaCount(txtCodigo.Text.Trim());

                        if (Resultado == 0)
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCodigo.SelectAll();
                            return;
                        }
                        if (Resultado == 1)
                        {
                            ProductoBE objE_Producto2 = null;
                            objE_Producto2 = new ProductoBL().SeleccionaParteCodigo(Parametros.intEmpresaId, txtCodigo.Text.Trim());
                            objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objE_Producto2.CodigoProveedor);
                        }
                        else
                        {
                            frmBusProducto objBusProducto = new frmBusProducto();
                            objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            objBusProducto.ShowDialog();
                            if (objBusProducto.pProductoBE != null)
                            {
                                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                            }
                            else
                            {
                                txtCodigo.Select();
                                return;
                            }

                        }

                        //ProductoBE objE_Producto = null;
                        //objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                        if (objE_Producto != null)
                        {
                            IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            txtNombreProducto.Text = objE_Producto.NombreProducto;

                            //btnConsultar.Focus();
                            txtCodigo.SelectAll();
                            Cargar();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    //Hang Tag

                    if (optHangTag.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        if (txtCodigo.Text.Trim().Length > 6)
                            //objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo.Text.Trim()); //Codigo de Barras de Importación
                            objE_Producto = new ProductoBL().SeleccionaCodigoBarra(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                        else
                            objE_Producto = new ProductoBL().SeleccionaID(Parametros.intEmpresaId, Parametros.intTiendaId, Convert.ToInt32(txtCodigo.Text.Trim()));
                        if (objE_Producto != null)
                        {
                            IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            txtNombreProducto.Text = objE_Producto.NombreProducto;

                            //btnConsultar.Focus();
                            txtCodigo.SelectAll();
                            Cargar();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int TipoConsulta = 0;
            if (chkMultiempresa.Checked) TipoConsulta = 1;

            mLista = new DocumentoVentaBL().ListaProducto(IdProducto, deDesde.DateTime, deHasta.DateTime, TipoConsulta);
            gcDocumentoVenta.DataSource = mLista;

            CalcularTotalDocumentos();

        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;
                int decCantidad = 0;

                for (int i = 0; i < gvDocumentoVenta.RowCount; i++)
                {
                    decCantidad = decCantidad + Convert.ToInt32(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["Cantidad"])));
                    decTotal = decTotal + Convert.ToDecimal(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["Total"])));
                }
                txtTotalCantidad.EditValue = decCantidad;
                txtTotal.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}