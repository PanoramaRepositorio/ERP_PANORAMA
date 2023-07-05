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
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegInventario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InventarioBE> mLista = new List<InventarioBE>();
        private bool bHangTag;
        private bool bAsignado = false;
        private int IdPersonaApoyo = 0;
        #endregion

        #region "Eventos"

        public frmRegInventario()
        {
            InitializeComponent();
        }

        private void frmRegInventario_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deFecha.DateTime = DateTime.Now;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            //BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, cbo), "DescAlmacen", "IdAlmacen", true);

            InventarioPersonaBE objE_InventarioPersona = null;
            objE_InventarioPersona = new InventarioPersonaBL().Selecciona(Parametros.intPersonaId);
            if (objE_InventarioPersona != null)
            {
                cboTienda.EditValue = objE_InventarioPersona.IdTienda;
                cboAlmacen.EditValue = objE_InventarioPersona.IdAlmacen;
                cboTienda.Properties.ReadOnly = true;
                cboAlmacen.Properties.ReadOnly = true;
                bAsignado = true;
            }

            txtPersona.EditValue = Parametros.strUsuarioNombres;

            //btnNuevo.Focus();
            //if (Parametros.strUsuarioLogin == "master")
            //{
            //    btnNuevo.Enabled = true;
            //    btnEditar.Enabled = true;
            //    btnEliminar.Enabled = true;
            //}
            //else
            //{
            //    btnNuevo.Enabled = false;
            //    btnEditar.Enabled = false;
            //    btnEliminar.Enabled = false;
            //}


        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
            }

        }

        private void cboAlmacen_EditValueChanged(object sender, EventArgs e)
        {
            if (cboAlmacen.EditValue != null)
            {
                Cargar();
            }
        }

        private void gvInventario_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmRegInventarioAgregar frm = new frmRegInventarioAgregar();
            frm.IdTienda = Convert.ToInt32(cboTienda.EditValue);
            frm.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
            frm.bHangTag = chkHangTag.Checked;
            frm.IdPersonaApoyo = IdPersonaApoyo;
            frm.DescPersonaApoyo = txtPersonaApoyo.Text;
            if (bAsignado)
            {
                frm.cboTienda.Properties.ReadOnly = true;
                frm.cboAlmacen.Properties.ReadOnly = true;
            }

            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            Cargar();

            //********* Version 1 Para Grabar Directamente
            /*try
            {
                if (cboAlmacen.Text == "")
                {
                    XtraMessageBox.Show("Seleccione un Almacén.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmRegInventarioEdit objInventario = new frmRegInventarioEdit();
                objInventario.pOperacion = frmRegInventarioEdit.Operacion.Nuevo;
                objInventario.IdInventario = 0;
                objInventario.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objInventario.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                objInventario.HangTag = bHangTag;
                objInventario.StartPosition = FormStartPosition.CenterParent;
                objInventario.ShowDialog();
                Cargar();

                btnNuevo.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
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

        private void gvInventario_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularCantidadTotal();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.TipoBusqueda = 0;
                //frm.Title = "Búsqueda de Persona sin Usuario";
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    IdPersonaApoyo = frm._Be.IdPersona;
                    txtPersonaApoyo.Text = frm._Be.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoInventario_" + cboTienda.Text;
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new InventarioBL().ListaTodosActivoUsuario(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboAlmacen.EditValue),Parametros.intPersonaId, deFecha.DateTime);
            gcInventario.DataSource = mLista;

            CalcularCantidadTotal();
        }

        private void CargarTodo()
        {
            mLista = new InventarioBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue));
            gcInventario.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcInventario.DataSource = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvInventario.GetFocusedRowCellValue("IdInventario").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Inventario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

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
                objManInventarioEdit.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                objManInventarioEdit.IdInventario = objInventario.IdInventario;
                objManInventarioEdit.cboTienda.Properties.ReadOnly = true;
                objManInventarioEdit.cboAlmacen.Properties.ReadOnly = true;
                objManInventarioEdit.StartPosition = FormStartPosition.CenterParent;
                objManInventarioEdit.ShowDialog();

                Cargar();
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

    }
}