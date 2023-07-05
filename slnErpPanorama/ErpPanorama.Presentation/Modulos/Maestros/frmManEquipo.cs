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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManEquipo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EquipoBE> mLista = new List<EquipoBE>();

        #endregion

        #region "Eventos"

        public frmManEquipo()
        {
            InitializeComponent();
        }

        private void frmManEquipo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
            //CargarEquipoConexion();
        }

        private void tlbMenu_NewClick()
        {
            XtraMessageBox.Show("Para registrar un equipo Ud. debe ingresar al sistema ERP en el equipo que desea registrar,\nluego actualizar este módulo y asignar la tienda y almacén",this.Text);
            //try
            //{
            //    frmManEquipoEdit objManEquipo = new frmManEquipoEdit();
            //    objManEquipo.lstEquipo = mLista;
            //    objManEquipo.pOperacion = frmManEquipoEdit.Operacion.Nuevo;
            //    objManEquipo.IdEquipo = 0;
            //    objManEquipo.StartPosition = FormStartPosition.CenterParent;
            //    objManEquipo.ShowDialog();
            //    Cargar();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
                        EquipoBE objE_Equipo = new EquipoBE();
                        objE_Equipo.IdEquipo = int.Parse(gvEquipo.GetFocusedRowCellValue("IdEquipo").ToString());
                        objE_Equipo.Usuario = Parametros.strUsuarioLogin;
                        objE_Equipo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Equipo.IdEmpresa = Parametros.intEmpresaId;

                        EquipoBL objBL_Equipo = new EquipoBL();
                        objBL_Equipo.Elimina(objE_Equipo);
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteEquipoBE> lstReporte = null;
            //    lstReporte = new ReporteEquipoBL().Listado(Parametros.intEquipoId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptEquipo = new RptVistaReportes();
            //            objRptEquipo.VerRptEquipo(lstReporte);
            //            objRptEquipo.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEquipos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEquipo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvEquipo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
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

        private void CargarEquipoConexion()
        {
            mLista = new EquipoBL().ListaTodosConexion(0);
            gcEquipoConexion.DataSource = mLista;
            //lblTotalRegistros.Text = mLista.Count.ToString() +" Registros encontrados";
        }

        private void Cargar()
        {
            mLista = new EquipoBL().ListaTodosActivo(0);
            gcEquipo.DataSource = mLista;
            lblTotalRegistros.Text = mLista.Count.ToString() + " Registros encontrados";
        }

        private void CargarBusqueda()
        {
            gcEquipo.DataSource = mLista.Where(obj =>
                                                   obj.HostName.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvEquipo.RowCount > 0)
            {
                EquipoBE objEquipo = new EquipoBE();
                objEquipo.IdEquipo = int.Parse(gvEquipo.GetFocusedRowCellValue("IdEquipo").ToString());

                frmManEquipoEdit objManEquipoEdit = new frmManEquipoEdit();
                objManEquipoEdit.pOperacion = frmManEquipoEdit.Operacion.Modificar;
                objManEquipoEdit.IdEquipo = objEquipo.IdEquipo;
                objManEquipoEdit.StartPosition = FormStartPosition.CenterParent;
                //objManEquipoEdit.ShowDialog();
                if (objManEquipoEdit.ShowDialog() == DialogResult.OK)
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
            if (gvEquipo.GetFocusedRowCellValue("IdEquipo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Equipo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}