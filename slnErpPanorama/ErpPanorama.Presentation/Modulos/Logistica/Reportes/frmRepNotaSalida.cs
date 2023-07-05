using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Consultas;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Rpt;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic.Reportes;
using ErpPanorama.BusinessEntity.Reportes;

namespace ErpPanorama.Presentation.Modulos.Logistica.Reportes
{
    public partial class frmRepNotaSalida : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MovimientoAlmacenBE> mLista = new List<MovimientoAlmacenBE>();
        private List<ReporteNotaSalidaDetBE> mLista2 = new List<ReporteNotaSalidaDetBE>();

        DataTable dt = new DataTable();
        
        #endregion

        #region "Eventos"

        public frmRepNotaSalida()
        {
            InitializeComponent();
        }

        private void frmRepNotaSalida_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = DateTime.Now.Year;
            cboMes.EditValue = DateTime.Now.Month;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosCombo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;

            Cargar();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                if (Convert.ToInt32(cboTienda.EditValue) == 0)
                {
                    cboAlmacen.EditValue = 0;
                }
                else
                {
                    BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                }
            }
        }

        private void tlbMenu_Excel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoNotaSalida";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMovimientoAlmacen.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }
        private void tlbMenu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
      
        private void txtNumero_EditValueChanged(object sender, EventArgs e)
        {
            //CargarBusqueda();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvMovimientoAlmacen_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvMovimientoAlmacen.GetRow(e.RowHandle);
                object objMov = gvMovimientoAlmacen.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objRecibido = View.GetRowCellValue(e.RowHandle, View.Columns["FlagRecibido"]);
                    object objMotivo = View.GetRowCellValue(e.RowHandle, View.Columns["IdMotivo"]);
                    if (objRecibido != null)
                    {
                        bool FlagRecibido = bool.Parse(objRecibido.ToString());
                        int IdMotivo = int.Parse(objMotivo.ToString());
                        if (FlagRecibido)
                        {
                            //int IdMotivo = int.Parse(objMotivo.ToString());
                            if (IdMotivo == Parametros.intMovReparacionTaller || IdMotivo == Parametros.intMovTransferenciaAndahuaylas || IdMotivo == Parametros.intMovTransferenciaUcayali || IdMotivo == Parametros.intMovMuestrasUcayali || IdMotivo == Parametros.intMovMuestrasAndahuaylas || IdMotivo == Parametros.intAutoservicioUcayali || IdMotivo == Parametros.intMovAutoservicioAndahuaylas)
                                e.Appearance.ForeColor = Color.Blue;
                        }
                        if (IdMotivo == Parametros.intMovMermas)
                            e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista2 = new ReporteNotaSalidaDetBL().ListaReporte(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovSalida);
            dt = FuncionBase.ToDataTable(mLista2);
            gcMovimientoAlmacen.DataSource = mLista2;
        }

        private void CargarBusqueda()
        {
                mLista = new MovimientoAlmacenBL().SeleccionaNumero(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), 0, 0, Parametros.intTipMovSalida, txtNumero.Text);
                gcMovimientoAlmacen.DataSource = mLista;
        }

        private void CargarBusquedaCodigo(int IdProducto)
        {
            mLista = new MovimientoAlmacenBL().ListaCodigo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovSalida, IdProducto);
            dt = FuncionBase.ToDataTable(mLista);
            gcMovimientoAlmacen.DataSource = mLista;
        }
            
        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

       
        private void gvMovimientoAlmacen_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvMovimientoAlmacen.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocumento = View.GetRowCellValue(e.RowHandle, View.Columns["FlagEstado"]);
                    if (objDocumento != null)
                    {
                        bool IdTipoDocumento = bool.Parse(objDocumento.ToString());
                        if (!IdTipoDocumento)
                        {
                            e.Appearance.BackColor = Color.Gray;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        if (objE_Producto != null)
                        {
                            //IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            //txtDescripcion.Text = objE_Producto.NombreProducto;

                            txtCodigo.SelectAll();
                            CargarBusquedaCodigo(objE_Producto.IdProducto);
                            //Cargar();
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
                            //IdProducto = objE_Producto.IdProducto;
                            //txtCodigo.Text = objE_Producto.CodigoProveedor;
                            //txtDescripcion.Text = objE_Producto.NombreProducto;

                            txtCodigo.SelectAll();
                            CargarBusquedaCodigo(objE_Producto.IdProducto);
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCodigo.Checked)
            {
                txtCodigo.Select();
            }
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (optHangTag.Checked)
            {
                txtCodigo.Select();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void gcMovimientoAlmacen_Click(object sender, EventArgs e)
        {

        }
    }
}