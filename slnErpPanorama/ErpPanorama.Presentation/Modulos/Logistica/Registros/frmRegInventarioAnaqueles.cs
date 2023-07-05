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
    public partial class frmRegInventarioAnaqueles : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InventarioAnaquelesBE> mLista = new List<InventarioAnaquelesBE>();
        private bool bHangTag;
        private int IdPersonaApoyo = 0;

        #endregion

        #region "Eventos"

        public frmRegInventarioAnaqueles()
        {
            InitializeComponent();
        }

        private void frmRegInventarioAnaqueles_Load(object sender, EventArgs e)
        {
            deFecha.DateTime = DateTime.Now;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            //BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId,Convert.ToInt32( cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
            cboAlmacen.EditValue = Parametros.intAlmAnaqueles;
            cboTienda.Properties.ReadOnly = true;
            cboAlmacen.Properties.ReadOnly = true;
            txtPersona.Text = Parametros.strUsuarioNombres;
            btnNuevo.Focus();
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


        private void gvInventarioAnaqueles_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //frmRegInventarioAnaquelesEdit frm = new frmRegInventarioAnaquelesEdit();
            //frm.IdTienda = Convert.ToInt32(cboTienda.EditValue);
            //frm.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
            //frm.bHangTag = chkHangTag.Checked;
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
            //Cargar();

            //********* Version 1 Para Grabar Directamente
            try
            {
                if (cboAlmacen.Text == "")
                {
                    XtraMessageBox.Show("Seleccione un Almacén.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmRegInventarioAnaquelesEdit objInventarioAnaqueles = new frmRegInventarioAnaquelesEdit();
                objInventarioAnaqueles.pOperacion = frmRegInventarioAnaquelesEdit.Operacion.Nuevo;
                objInventarioAnaqueles.IdInventarioAnaqueles = 0;
                objInventarioAnaqueles.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objInventarioAnaqueles.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                objInventarioAnaqueles.HangTag = bHangTag;
                objInventarioAnaqueles.IdPersonaApoyo = IdPersonaApoyo;
                objInventarioAnaqueles.StartPosition = FormStartPosition.CenterParent;
                objInventarioAnaqueles.ShowDialog();
                Cargar();

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
                        InventarioAnaquelesBE objE_InventarioAnaqueles = new InventarioAnaquelesBE();
                        objE_InventarioAnaqueles.IdInventarioAnaqueles = int.Parse(gvInventarioAnaqueles.GetFocusedRowCellValue("IdInventarioAnaqueles").ToString());
                        objE_InventarioAnaqueles.Usuario = Parametros.strUsuarioLogin;
                        objE_InventarioAnaqueles.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_InventarioAnaqueles.IdEmpresa = Parametros.intEmpresaId;

                        InventarioAnaquelesBL objBL_InventarioAnaqueles = new InventarioAnaquelesBL();
                        objBL_InventarioAnaqueles.Elimina(objE_InventarioAnaqueles);
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

        private void gvInventarioAnaqueles_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularCantidadTotal();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin == "master")
            {
                CargarTodo();
            }else
                Cargar();

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoInventarioAnaqueles_" + cboTienda.Text;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventarioAnaqueles.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void mostrartodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarTodo();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new InventarioAnaquelesBL().ListaTodosActivoUsuario(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intPersonaId, deFecha.DateTime);
            gcInventarioAnaqueles.DataSource = mLista;

            CalcularCantidadTotal();
            //lblRegistros.Text = mLista.Count.ToString() +" Registros encontrados" ;
        }

        private void CargarTodo()
        {
            mLista = new InventarioAnaquelesBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue));
            gcInventarioAnaqueles.DataSource = mLista;

            CalcularCantidadTotal();
            //lblRegistros.Text = mLista.Count.ToString();
        }

        private void CargarBusqueda()
        {
            gcInventarioAnaqueles.DataSource = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvInventarioAnaqueles.GetFocusedRowCellValue("IdInventarioAnaqueles").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una InventarioAnaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        public void InicializarModificar()
        {
            if (gvInventarioAnaqueles.RowCount > 0)
            {
                InventarioAnaquelesBE objInventarioAnaqueles = new InventarioAnaquelesBE();
                objInventarioAnaqueles.IdInventarioAnaqueles = int.Parse(gvInventarioAnaqueles.GetFocusedRowCellValue("IdInventarioAnaqueles").ToString());

                frmRegInventarioAnaquelesEdit objManInventarioAnaquelesEdit = new frmRegInventarioAnaquelesEdit();
                objManInventarioAnaquelesEdit.pOperacion = frmRegInventarioAnaquelesEdit.Operacion.Modificar;
                objManInventarioAnaquelesEdit.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManInventarioAnaquelesEdit.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                objManInventarioAnaquelesEdit.IdInventarioAnaqueles = objInventarioAnaqueles.IdInventarioAnaqueles;
                objManInventarioAnaquelesEdit.StartPosition = FormStartPosition.CenterParent;
                objManInventarioAnaquelesEdit.ShowDialog();

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

                for (int i = 0; i < gvInventarioAnaqueles.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToInt32(gvInventarioAnaqueles.GetRowCellValue(i, (gvInventarioAnaqueles.Columns["Cantidad"])));
                    lblRegistros.Text = gvInventarioAnaqueles.RowCount.ToString() + " Registros encontrados";
                }
                txtTotal.EditValue = decTotal;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        #endregion

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
    }
}