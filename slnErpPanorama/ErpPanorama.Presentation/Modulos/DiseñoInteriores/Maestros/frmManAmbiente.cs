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

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    public partial class frmManAmbiente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<Dis_AmbienteBE> mLista = new List<Dis_AmbienteBE>();

        #endregion

        #region "Eventos"

        public frmManAmbiente()
        {
            InitializeComponent();
        }

        private void frmManAmbiente_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManAmbienteEdit objManDis_Ambiente = new frmManAmbienteEdit();
                objManDis_Ambiente.lstDis_Ambiente = mLista;
                objManDis_Ambiente.pOperacion = frmManAmbienteEdit.Operacion.Nuevo;
                objManDis_Ambiente.IdDis_Ambiente = 0;
                objManDis_Ambiente.StartPosition = FormStartPosition.CenterParent;
                objManDis_Ambiente.ShowDialog();
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
                        Dis_AmbienteBE objE_Dis_Ambiente = new Dis_AmbienteBE();
                        objE_Dis_Ambiente.IdDis_Ambiente = int.Parse(gvDis_Ambiente.GetFocusedRowCellValue("IdDis_Ambiente").ToString());
                        objE_Dis_Ambiente.Usuario = Parametros.strUsuarioLogin;
                        objE_Dis_Ambiente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Dis_Ambiente.IdEmpresa = Parametros.intEmpresaId;

                        Dis_AmbienteBL objBL_Dis_Ambiente = new Dis_AmbienteBL();
                        objBL_Dis_Ambiente.Elimina(objE_Dis_Ambiente);
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

            //    List<ReporteDis_AmbienteBE> lstReporte = null;
            //    lstReporte = new ReporteDis_AmbienteBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDis_Ambiente = new RptVistaReportes();
            //            objRptDis_Ambiente.VerRptDis_Ambiente(lstReporte);
            //            objRptDis_Ambiente.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
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
            string _fileName = "ListadoAmbientees";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_Ambiente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAmbiente_DoubleClick(object sender, EventArgs e)
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

        private void Cargar()
        {
            mLista = new Dis_AmbienteBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDis_Ambiente.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDis_Ambiente.DataSource = mLista.Where(obj =>
                                                   obj.DescDis_Ambiente.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDis_Ambiente.RowCount > 0)
            {
                Dis_AmbienteBE objDis_Ambiente = new Dis_AmbienteBE();
                objDis_Ambiente.IdDis_Ambiente = int.Parse(gvDis_Ambiente.GetFocusedRowCellValue("IdDis_Ambiente").ToString());
                objDis_Ambiente.DescDis_Ambiente = gvDis_Ambiente.GetFocusedRowCellValue("DescDis_Ambiente").ToString();
                objDis_Ambiente.FlagEstado = Convert.ToBoolean(gvDis_Ambiente.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManAmbienteEdit objManDis_AmbienteEdit = new frmManAmbienteEdit();
                objManDis_AmbienteEdit.pOperacion = frmManAmbienteEdit.Operacion.Modificar;
                objManDis_AmbienteEdit.IdDis_Ambiente = objDis_Ambiente.IdDis_Ambiente;
                objManDis_AmbienteEdit.pDis_AmbienteBE = objDis_Ambiente;
                objManDis_AmbienteEdit.StartPosition = FormStartPosition.CenterParent;
                objManDis_AmbienteEdit.ShowDialog();

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

            if (gvDis_Ambiente.GetFocusedRowCellValue("IdDis_Ambiente").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Ambiente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}