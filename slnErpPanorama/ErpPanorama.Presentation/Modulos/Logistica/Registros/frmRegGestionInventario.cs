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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegGestionInventario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InventarioBE> mLista = new List<InventarioBE>();
        private bool bHangTag;

        #endregion

        #region "Eventos"

        public frmRegGestionInventario()
        {
            InitializeComponent();
        }

        private void frmRegGestionInventario_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;


            Cargar();

            //btnNuevo.Focus();
            if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.strUsuarioLogin.ToLower() == "almacen1"  
                 || Parametros.strUsuarioLogin == "jtapia" || Parametros.strUsuarioLogin == "ccalderon"  || Parametros.intPerfilId == Parametros.intPerAnalistaProducto
                 || Parametros.intPerfilId == Parametros.intPerAnalistaInventario || Parametros.strUsuarioLogin == "jmorocco" || Parametros.intPerfilId == Parametros.intPerCoordinadorVisualCentral 
                 || Parametros.intPerfilId == Parametros.intPerProgramador || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen )
            {                
                btnNuevo.Enabled = true;

                btnEditar.Enabled = true;
                //btnEliminar.Enabled = true;
                //btnImportarBulto.Enabled = true;
                //btnImportarAnaquel.Enabled = true;
                gcInventario.ContextMenuStrip = mnuContextual;

            }
            else
            {
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnImportarBulto.Enabled = false;
                btnImportarAnaquel.Enabled = false;
                gcInventario.ContextMenuStrip = null;
            }

            //if (Parametros.intPerfilId == 21 || Parametros.strUsuarioLogin == "jvasquez")
            //{
            //    btnNuevo.Enabled = true;
            //    btnEditar.Enabled = true;
            //    btnEliminar.Enabled = true;
            //    btnImportarAnaquel.Enabled = true;
            //}


            btnNuevo.Focus();
        }

        private void gvInventario_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cboAlmacen.Text == "")
                //{
                //    XtraMessageBox.Show("Seleccione un Almacén.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                frmRegInventarioEdit objInventario = new frmRegInventarioEdit();
                objInventario.pOperacion = frmRegInventarioEdit.Operacion.Nuevo;
                objInventario.IdInventario = 0;
                objInventario.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objInventario.IdAlmacen = Parametros.intAlmCentralUcayali;
                objInventario.HangTag = bHangTag;
                objInventario.StartPosition = FormStartPosition.CenterParent;
                if (objInventario.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }

                btnNuevo.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        InventarioBE objE_Inventario = new InventarioBE();
                        objE_Inventario.IdInventario = int.Parse(gvInventario.GetFocusedRowCellValue("IdInventario").ToString());
                        objE_Inventario.Usuario = Parametros.strUsuarioLogin;
                        objE_Inventario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Inventario.IdEmpresa = Parametros.intEmpresaId;

                        InventarioBL objBL_Inventario = new InventarioBL();
                        objBL_Inventario.Elimina(objE_Inventario);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
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

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.modificarprecioToolStripMenuItem_Click(sender, e);
        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void chkHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHangTag.Checked == true)
            {
                bHangTag = true;
            }
            else
            {
                bHangTag = false;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoInventario_"+ cboTienda.Text ;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventario.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteInventarioBE> lstReporte = null;
                lstReporte = new ReporteInventarioBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                        objRptKardexBulto.VerRptInventario(lstReporte);
                        objRptKardexBulto.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerPersona_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteInventarioBE> lstReporte = null;
                lstReporte = new ReporteInventarioBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                        objRptKardexBulto.VerRptInventarioPersonal(lstReporte);
                        objRptKardexBulto.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvInventario_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularCantidadTotal();
        }

        private void btnImportarBulto_Click(object sender, EventArgs e)
        {
            try
            {
                if (Parametros.strUsuarioLogin == "master")
                {
                    Cursor = Cursors.WaitCursor;
                    if (XtraMessageBox.Show("Está seguro de importar los bultos a esta Fecha?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarIngreso())
                        {
                            InventarioBL objBL_Inventario = new InventarioBL();
                            objBL_Inventario.InsertaBulto(Parametros.intEmpresaId);
                            XtraMessageBox.Show("Bultos Importados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                            btnImportarBulto.Enabled = false;
                        }
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new InventarioBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue));
            gcInventario.DataSource = mLista;
            CalcularCantidadTotal();
        }


        private void CargarBusqueda()
        {
            gcInventario.DataSource = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
            CalcularCantidadTotal();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            //if (gvInventario.GetFocusedRowCellValue("IdInventario").ToString() == "")
            //{
            //    XtraMessageBox.Show("Seleccione una Inventario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    flag = true;
            //}

            Cursor = Cursors.Default;
            return flag;
        }

        public void InicializarModificar()
        {
            if (gvInventario.RowCount > 0)
            {
                InventarioBE objInventario = new InventarioBE();
                objInventario.IdInventario = int.Parse(gvInventario.GetFocusedRowCellValue("IdInventario").ToString());

                frmRegInventarioEdit objManInventarioEdit = new frmRegInventarioEdit();
                objManInventarioEdit.pOperacion = frmRegInventarioEdit.Operacion.Modificar;
                objManInventarioEdit.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManInventarioEdit.IdAlmacen =  int.Parse(gvInventario.GetFocusedRowCellValue("IdAlmacen").ToString());
                objManInventarioEdit.IdInventario = objInventario.IdInventario;
                objManInventarioEdit.StartPosition = FormStartPosition.CenterParent;
                if (objManInventarioEdit.ShowDialog() == DialogResult.OK)
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
                InicializarModificar();
            }
        }

        private void CalcularCantidadTotal()
        {
            try
            {
                int decTotal = 0;

                for (int i = 0; i < gvInventario.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToInt32(gvInventario.GetRowCellValue(i, (gvInventario.Columns["Cantidad"])));
                    lblRegistros.Text = gvInventario.RowCount.ToString() + " Registros encontrados";
                }
                txtTotal.EditValue = decTotal;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
        }

        private void btnImportarAnaquel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Parametros.strUsuarioLogin == "master")
                {
                    Cursor = Cursors.WaitCursor;
                    if (XtraMessageBox.Show("Está seguro de importar el inventario de anaqueles a esta Fecha?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarIngreso())
                        {
                            InventarioBL objBL_Inventario = new InventarioBL();
                            objBL_Inventario.InsertaAnaqueles(Parametros.intEmpresaId);
                            XtraMessageBox.Show("Inventario de Anaqueles importado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                            btnImportarAnaquel.Enabled = false;
                        }
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}