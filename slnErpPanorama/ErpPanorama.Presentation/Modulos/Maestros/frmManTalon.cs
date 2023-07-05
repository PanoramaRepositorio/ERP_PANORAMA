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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTalon : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TalonBE> mLista = new List<TalonBE>();
        
        #endregion

        #region "Eventos"

        public frmManTalon()
        {
            InitializeComponent();
        }

        private void frmManTalon_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;// Parametros.intIdPanoramaDistribuidores;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTalonEdit objManTalon = new frmManTalonEdit();
                objManTalon.lstTalon = mLista;
                objManTalon.pOperacion = frmManTalonEdit.Operacion.Nuevo;
                objManTalon.IdTalon = 0;
                objManTalon.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objManTalon.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManTalon.StartPosition = FormStartPosition.CenterParent;
                objManTalon.ShowDialog();
                Cargar();
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
                        TalonBE objE_Talon = new TalonBE();
                        objE_Talon.IdTalon = int.Parse(gvTalon.GetFocusedRowCellValue("IdTalon").ToString());
                        objE_Talon.Usuario = Parametros.strUsuarioLogin;
                        objE_Talon.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Talon.IdEmpresa = Parametros.intEmpresaId;

                        TalonBL objBL_Talon = new TalonBL();
                        objBL_Talon.Elimina(objE_Talon);
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

                List<ReporteTalonBE> lstReporte = null;
                lstReporte = new ReporteTalonBL().Listado();

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptTalon = new RptVistaReportes();
                        objRptTalon.VerRptTalon(lstReporte);
                        objRptTalon.ShowDialog();
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
            string _fileName = "ListadoTalones";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTalon.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTalon_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
            }
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                Cargar();
            }
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new TalonBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue));
            gcTalon.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvTalon.RowCount > 0)
            {
                TalonBE objTalon = new TalonBE();
                objTalon.IdTalon = int.Parse(gvTalon.GetFocusedRowCellValue("IdTalon").ToString());

                frmManTalonEdit objManTalonEdit = new frmManTalonEdit();
                objManTalonEdit.pOperacion = frmManTalonEdit.Operacion.Modificar;
                objManTalonEdit.IdTalon = objTalon.IdTalon;
                objManTalonEdit.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objManTalonEdit.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManTalonEdit.StartPosition = FormStartPosition.CenterParent;
                objManTalonEdit.ShowDialog();

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

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvTalon.GetFocusedRowCellValue("IdTalon").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Talon", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}