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
using ErpPanorama.Presentation.Modulos.Logistica.Consultas;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegGuiaRemision : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<GuiaRemisionBE> mLista = new List<GuiaRemisionBE>();

        #endregion

        #region "Eventos"

        public frmRegGuiaRemision()
        {
            InitializeComponent();
        }

        private void frmRegGuiaRemision_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegGuiaRemisionEdit objManGuiaRemision = new frmRegGuiaRemisionEdit();
                objManGuiaRemision.lstGuiaRemision = mLista;
                objManGuiaRemision.pOperacion = frmRegGuiaRemisionEdit.Operacion.Nuevo;
                objManGuiaRemision.IdGuiaRemision = 0;
                objManGuiaRemision.StartPosition = FormStartPosition.CenterParent;
                objManGuiaRemision.ShowDialog();
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
                        GuiaRemisionBE objE_GuiaRemision = new GuiaRemisionBE();
                        objE_GuiaRemision.IdGuiaRemision = int.Parse(gvGuiaRemision.GetFocusedRowCellValue("IdGuiaRemision").ToString());
                        objE_GuiaRemision.Usuario = Parametros.strUsuarioLogin;
                        objE_GuiaRemision.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_GuiaRemision.IdEmpresa = Parametros.intEmpresaId;

                        GuiaRemisionBL objBL_GuiaRemision = new GuiaRemisionBL();
                        objBL_GuiaRemision.Elimina(objE_GuiaRemision);
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
                if (mLista.Count > 0)
                {
                    ReporteGuiaRemisionBE objE_GuiaRemision = new ReporteGuiaRemisionBE();
                    objE_GuiaRemision.IdGuiaRemision = int.Parse(gvGuiaRemision.GetFocusedRowCellValue("IdGuiaRemision").ToString());
                    objE_GuiaRemision.IdEmpresa = Parametros.intEmpresaId;

                    List<ReporteGuiaRemisionBE> lstReporte = null;
                    lstReporte = new ReporteGuiaRemisionBL().Listado(Parametros.intEmpresaId, objE_GuiaRemision.IdGuiaRemision);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptGuiaRemision = new RptVistaReportes();
                            objRptGuiaRemision.VerRptGuiaRemision(lstReporte);
                            objRptGuiaRemision.ShowDialog();
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
            string _fileName = "ListadoGuiaRemisiones";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvGuiaRemision.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvGuiaRemision_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumero_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void bultosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvGuiaRemision.RowCount > 0)
                {
                    frmConBultosInvolucrados objBultosInvolucrados = new frmConBultosInvolucrados();
                    objBultosInvolucrados.Periodo = int.Parse(gvGuiaRemision.GetFocusedRowCellValue("Periodo").ToString());
                    objBultosInvolucrados.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                    objBultosInvolucrados.Numero = gvGuiaRemision.GetFocusedRowCellValue("Numero").ToString();
                    objBultosInvolucrados.StartPosition = FormStartPosition.CenterParent;
                    objBultosInvolucrados.ShowDialog();

                    Cargar();
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
            mLista = new GuiaRemisionBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intPeriodo);
            gcGuiaRemision.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcGuiaRemision.DataSource = mLista.Where(obj =>
                                                   obj.Numero.ToUpper().Contains(txtNumero.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvGuiaRemision.RowCount > 0)
            {
                GuiaRemisionBE objGuiaRemision = new GuiaRemisionBE();
                objGuiaRemision.IdGuiaRemision = int.Parse(gvGuiaRemision.GetFocusedRowCellValue("IdGuiaRemision").ToString());

                frmRegGuiaRemisionEdit objManGuiaRemisionEdit = new frmRegGuiaRemisionEdit();
                objManGuiaRemisionEdit.pOperacion = frmRegGuiaRemisionEdit.Operacion.Modificar;
                objManGuiaRemisionEdit.IdGuiaRemision = objGuiaRemision.IdGuiaRemision;
                objManGuiaRemisionEdit.StartPosition = FormStartPosition.CenterParent;
                objManGuiaRemisionEdit.ShowDialog();

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

            if (gvGuiaRemision.GetFocusedRowCellValue("IdGuiaRemision").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

       
       
    }
}