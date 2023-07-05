using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Creditos.Maestros;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    public partial class frmManChequeBanco : DevExpress.XtraEditors.XtraForm
    {
        public frmManChequeBanco()
        {
            InitializeComponent();
        }

        #region "Propiedades"

        private List<ChequeBancoBE> mLista = new List<ChequeBancoBE>();

        #endregion

        #region "Eventos"

        private void frmManChequeBanco_Load(object sender, EventArgs e)
        {
            //tlbMenu.Ensamblado = this.Tag.ToString(); // Necesario para que funcione tlbMenu !!!
            BSUtils.LoaderLook(cboEmpresa, CargarEmpresa(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            Cargar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvChequeBanco_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        // EVENTOS DE LOS BOTONES

        private void btnNuevoCheque_Click(object sender, EventArgs e)
        {
            try
            {
                frmManChequeBancoEdit frm = new frmManChequeBancoEdit();
                frm.pOperacion = frmManChequeBancoEdit.Operacion.Nuevo;
                frm.IdChequeBanco = 0;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCheque_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ChequeBancoBE objE_ChequeBanco = new ChequeBancoBE();
                        objE_ChequeBanco.IdChequeBanco = int.Parse(gvChequeBanco.GetFocusedRowCellValue("IdChequeBanco").ToString());
                        objE_ChequeBanco.Usuario = Parametros.strUsuarioLogin;
                        objE_ChequeBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ChequeBanco.IdEmpresa = Parametros.intEmpresaId;

                        ChequeBancoBL objBL_ChequeBanco = new ChequeBancoBL();
                        objBL_ChequeBanco.Elimina(objE_ChequeBanco);
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

        private void bntExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoChequeBanco";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvChequeBanco.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void bntSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ChequeBancoBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue));
            gcChequeBanco.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvChequeBanco.RowCount > 0)
            {
                ChequeBancoBE objChequeBanco = new ChequeBancoBE();
                objChequeBanco.IdChequeBanco = int.Parse(gvChequeBanco.GetFocusedRowCellValue("IdChequeBanco").ToString());
                frmManChequeBancoEdit frm = new frmManChequeBancoEdit();
                frm.pOperacion = frmManChequeBancoEdit.Operacion.Modificar;
                frm.IdChequeBanco = objChequeBanco.IdChequeBanco;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            else
            {
                XtraMessageBox.Show("No hay registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvChequeBanco.GetFocusedRowCellValue("IdChequeBanco").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Cheque", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private DataTable CargarEmpresa()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdEmpresa", Type.GetType("System.Int32"));
            dt.Columns.Add("RazonSocial", Type.GetType("System.String"));
            DataRow dr;

            dr = dt.NewRow();
            dr["IdEmpresa"] = 13;
            dr["RazonSocial"] = "PANORAMA DISTRIBUIDORES S.A.";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["IdEmpresa"] = 27;
            dr["RazonSocial"] = "DECORATEX E.I.R.L.";
            dt.Rows.Add(dr);

            return dt;
        }

        #endregion
    }
}