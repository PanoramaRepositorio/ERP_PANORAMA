using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegNotaIngreso : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<MovimientoAlmacenBE> mLista = new List<MovimientoAlmacenBE>();
        
        #endregion

        #region "Eventos"

        public frmRegNotaIngreso()
        {
            InitializeComponent();
        }

        private void frmRegNotaIngreso_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = DateTime.Now.Year;
            cboMes.EditValue = DateTime.Now.Month;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;

            Cargar();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegNotaIngresoEdit objManMovimientoAlmacen = new frmRegNotaIngresoEdit();
                objManMovimientoAlmacen.lstMovimientoAlmacen = mLista;
                objManMovimientoAlmacen.pOperacion = frmRegNotaIngresoEdit.Operacion.Nuevo;
                objManMovimientoAlmacen.IdMovimientoAlmacen = 0;
                objManMovimientoAlmacen.StartPosition = FormStartPosition.CenterParent;
                objManMovimientoAlmacen.btnGrabar.Enabled = true;
                if (objManMovimientoAlmacen.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        if (Convert.ToBoolean(gvMovimientoAlmacen.GetFocusedRowCellValue("FlagEstado").ToString()) == false)
                        {
                            XtraMessageBox.Show("La nota de salida está eliminada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cursor = Cursors.Default;
                            return;
                        }


                        //string Usuario = Parametros.strUsuarioLogin;
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (!frmAutoriza.Edita)
                        {
                            Cursor = Cursors.Default;
                            return;
                        }


                        if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                        {
                            Cursor = Cursors.Default;
                            XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                            return;
                        }

                        //string Observacion = "";
                        frmObservacion frmObserva = new frmObservacion();
                        frmObserva.StartPosition = FormStartPosition.CenterParent;
                        if (frmObserva.ShowDialog() == DialogResult.OK)
                        {
                            MovimientoAlmacenBE objE_MovimientoAlmacen = null;
                            objE_MovimientoAlmacen = new MovimientoAlmacenBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString()));
                            objE_MovimientoAlmacen.ObservacionElimina = frmObserva.txtObservacion.Text;
                            objE_MovimientoAlmacen.Usuario = frmAutoriza.Usuario; //Parametros.strUsuarioLogin;
                            objE_MovimientoAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;

                            MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                            objBL_MovimientoAlmacen.Elimina(objE_MovimientoAlmacen);
                            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    ReporteNotaSalidaBE objE_MovimientoAlmacen = new ReporteNotaSalidaBE();
                    objE_MovimientoAlmacen.IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());
                    objE_MovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;

                    List<ReporteNotaSalidaBE> lstReporte = null;
                    lstReporte = new ReporteNotaSalidaBL().Listado(Parametros.intEmpresaId, objE_MovimientoAlmacen.IdMovimientoAlmacen);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptMovimientoAlmacen = new RptVistaReportes();
                            objRptMovimientoAlmacen.VerRptNotaIngreso(lstReporte);
                            objRptMovimientoAlmacen.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMovimientoAlmacenes";
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

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMovimientoAlmacen_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumero_EditValueChanged(object sender, EventArgs e)
        {
            //CargarBusqueda();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
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
            mLista = new MovimientoAlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue),  Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovIngreso);
            gcMovimientoAlmacen.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador)
            {
                mLista = new MovimientoAlmacenBL().SeleccionaNumero(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), 0, 0, Parametros.intTipMovIngreso, txtNumero.Text);
                gcMovimientoAlmacen.DataSource = mLista;
            }
            else
            {
                mLista = new MovimientoAlmacenBL().SeleccionaNumero(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovIngreso, txtNumero.Text);
                gcMovimientoAlmacen.DataSource = mLista;
            }
        }

        private void CargarBusquedaCodigo(int IdProducto)
        {
            mLista = new MovimientoAlmacenBL().ListaCodigo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovIngreso, IdProducto);
            //dt = FuncionBase.ToDataTable(mLista);
            gcMovimientoAlmacen.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvMovimientoAlmacen.RowCount > 0)
            {
                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();
                objMovimientoAlmacen.IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());

                int IdMotivo = 0;
                IdMotivo = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMotivo").ToString());

                frmRegNotaIngresoEdit objManMovimientoAlmacenEdit = new frmRegNotaIngresoEdit();
                objManMovimientoAlmacenEdit.pOperacion = frmRegNotaIngresoEdit.Operacion.Modificar;
                objManMovimientoAlmacenEdit.IdMovimientoAlmacen = objMovimientoAlmacen.IdMovimientoAlmacen;
                objManMovimientoAlmacenEdit.StartPosition = FormStartPosition.CenterParent;
                //if (IdMotivo == Parametros.intMovDevolucion || IdMotivo == Parametros.intMovFaltanteOrigen || IdMotivo == Parametros.intMovMermas || IdMotivo == Parametros.intMovAutoservicioAndahuaylas ||IdMotivo == Parametros.intAutoservicioUcayali)
                //    objManMovimientoAlmacenEdit.btnGrabar.Enabled = false;
                //else
                //    objManMovimientoAlmacenEdit.btnGrabar.Enabled = true;
                if (Parametros.strUsuarioLogin == "htapia" || Parametros.strUsuarioLogin == "master")
                    objManMovimientoAlmacenEdit.btnGrabar.Enabled = true;
                else
                    objManMovimientoAlmacenEdit.btnGrabar.Enabled = false;
                objManMovimientoAlmacenEdit.btnGrabar.Enabled = true;
                //objManMovimientoAlmacenEdit.ShowDialog();
                if (objManMovimientoAlmacenEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                if (gvMovimientoAlmacen.RowCount > 0)
                {
                    MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();
                    objMovimientoAlmacen.IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());

                    frmRegNotaIngresoEdit objManMovimientoAlmacenEdit = new frmRegNotaIngresoEdit();
                    objManMovimientoAlmacenEdit.pOperacion = frmRegNotaIngresoEdit.Operacion.Modificar;
                    objManMovimientoAlmacenEdit.IdMovimientoAlmacen = objMovimientoAlmacen.IdMovimientoAlmacen;
                    objManMovimientoAlmacenEdit.StartPosition = FormStartPosition.CenterParent;
                    objManMovimientoAlmacenEdit.btnGrabar.Enabled = false;
                    //objManMovimientoAlmacenEdit.ShowDialog();
                    if (objManMovimientoAlmacenEdit.ShowDialog() == DialogResult.OK)
                    {
                        Cargar();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo editar");
                }
            }
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

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}