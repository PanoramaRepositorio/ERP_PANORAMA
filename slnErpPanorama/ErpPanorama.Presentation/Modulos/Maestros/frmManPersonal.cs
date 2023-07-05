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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManPersonal : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<PersonaBE> mLista = new List<PersonaBE>();
        
        #endregion

        #region "Eventos"

        public frmManPersonal()
        {
            InitializeComponent();
        }

        private void frmManPersonal_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            //BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            Cargar();

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
            {
                gridColumn33.Visible = true;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPersonalEdit objManPersonal = new frmManPersonalEdit();
                objManPersonal.pOperacion = frmManPersonalEdit.Operacion.Nuevo;
                objManPersonal.IdPersona = 0;
                objManPersonal.StartPosition = FormStartPosition.CenterParent;
                if (objManPersonal.ShowDialog() == DialogResult.OK)
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
                        ////Verificar Pedidos
                        //PersonaBE objE_Per = new PersonaBE();
                        //objE_Per = new PersonaBL().Selecciona(Parametros.intEmpresaId, int.Parse(gvPersonal.GetFocusedRowCellValue("IdPersona").ToString()));
                        ////Devolver valor

                        PersonaBE objE_Personal = new PersonaBE();
                        objE_Personal.IdPersona = int.Parse(gvPersonal.GetFocusedRowCellValue("IdPersona").ToString());
                        objE_Personal.Usuario = Parametros.strUsuarioLogin;
                        objE_Personal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Personal.IdEmpresa = Parametros.intEmpresaId;

                        PersonaBL objBL_Persona = new PersonaBL();
                        objBL_Persona.Elimina(objE_Personal);
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

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReportePersonaBE> lstReporte = null;
                lstReporte = new ReportePersonaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptPersonal = new RptVistaReportes();
                        objRptPersonal.VerRptPersonal(lstReporte);
                        objRptPersonal.ShowDialog();
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPersonales";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPersonal.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPersonal_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                Cargar();
            }
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PersonaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue));
            gcPersonal.DataSource = mLista;
            lblTotalRegistros.Text = gvPersonal.RowCount.ToString() + " Registros";
        }

        private void CargarTodos()
        {
            mLista = new PersonaBL().ListaTodos(Convert.ToInt32(cboEmpresa.EditValue), 0);
            gcPersonal.DataSource = mLista;
            lblTotalRegistros.Text = gvPersonal.RowCount.ToString() + " Registros";
        }

        private void CargarBusqueda()
        {
            gcPersonal.DataSource = mLista.Where(obj => obj.Dni.ToUpper().Contains(txtDescripcion.Text.ToUpper()) ||
                                                   obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPersonal.RowCount > 0)
            {
                PersonaBE objPersonal = new PersonaBE();
                objPersonal.IdPersona = int.Parse(gvPersonal.GetFocusedRowCellValue("IdPersona").ToString());

                frmManPersonalEdit objManPersonalEdit = new frmManPersonalEdit();
                objManPersonalEdit.pOperacion = frmManPersonalEdit.Operacion.Modificar;
                objManPersonalEdit.IdPersona = objPersonal.IdPersona;
                objManPersonalEdit.StartPosition = FormStartPosition.CenterParent;
                if (objManPersonalEdit.ShowDialog() == DialogResult.OK)
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

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvPersonal.GetFocusedRowCellValue("IdPersona").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Personal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosCombo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = 0;
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            CargarTodos();
        }

        private void gvPersonal_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvPersonal.RowCount.ToString() + " Registros";
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}