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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManPiso : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<PisoBE> mLista = new List<PisoBE>();

        int IdUbicacion = 0;
        
        #endregion

        #region "Eventos"

        public frmManPiso()
        {
            InitializeComponent();
        }

        private void frmManPiso_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargaTriview();
        }

        private void tvwDatos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }

            switch (e.Node.Tag.ToString().Substring(0, 3))
            {
                case "UBI":
                    IdUbicacion = Convert.ToInt32(e.Node.Tag.ToString().Substring(3, e.Node.Tag.ToString().Length - 3));
                    Cargar();
                    break;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                if (IdUbicacion == 0)
                {
                    XtraMessageBox.Show("Seleccione un Ubicacion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmManPisoEdit objManPiso = new frmManPisoEdit();
                objManPiso.lstPiso = mLista;
                objManPiso.pOperacion = frmManPisoEdit.Operacion.Nuevo;
                objManPiso.IdUbicacion = IdUbicacion;
                objManPiso.IdPiso = 0;
                objManPiso.StartPosition = FormStartPosition.CenterParent;
                objManPiso.ShowDialog();
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
                        PisoBE objE_Piso = new PisoBE();
                        objE_Piso.IdPiso = int.Parse(gvPiso.GetFocusedRowCellValue("IdPiso").ToString());
                        objE_Piso.Usuario = Parametros.strUsuarioLogin;
                        objE_Piso.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Piso.IdEmpresa = Parametros.intEmpresaId;

                        PisoBL objBL_Piso = new PisoBL();
                        objBL_Piso.Elimina(objE_Piso);
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

                List<ReportePisoBE> lstReporte = null;
                lstReporte = new ReportePisoBL().Listado(Parametros.intEmpresaId,Convert.ToInt32(IdUbicacion));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptPiso = new RptVistaReportes();
                        objRptPiso.VerRptPiso(lstReporte);
                        objRptPiso.ShowDialog();
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
            string _fileName = "ListadoPisos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPiso.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPiso_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void CargaTriview()
        {
            tvwDatos.Nodes.Clear();

            TreeNode nuevoNodo = new TreeNode();
            nuevoNodo.Text = "ALMACEN CAJAS VACIAS";
            nuevoNodo.ImageIndex = 0;
            nuevoNodo.SelectedImageIndex = 0;
            tvwDatos.Nodes.Add(nuevoNodo);

            List<UbicacionBE> lstUbicacion = null;
            lstUbicacion = new UbicacionBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId);
            foreach (var item in lstUbicacion)
            {
                TreeNode nuevoNodoChild = new TreeNode();
                nuevoNodoChild.ImageIndex = 1;
                nuevoNodoChild.SelectedImageIndex = 1;
                nuevoNodoChild.Text = item.DescUbicacion;
                nuevoNodoChild.Tag = "UBI" + item.IdUbicacion.ToString();
                nuevoNodo.Nodes.Add(nuevoNodoChild);
            }

            tvwDatos.ExpandAll();
        }

        private void Cargar()
        {
            mLista = new PisoBL().ListaTodosActivo(Parametros.intEmpresaId,Convert.ToInt32(IdUbicacion));
            gcPiso.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvPiso.RowCount > 0)
            {
                PisoBE objPiso = new PisoBE();
                objPiso.IdUbicacion = int.Parse(gvPiso.GetFocusedRowCellValue("IdUbicacion").ToString());
                objPiso.IdPiso = int.Parse(gvPiso.GetFocusedRowCellValue("IdPiso").ToString());
                objPiso.DescPiso = gvPiso.GetFocusedRowCellValue("DescPiso").ToString();
                objPiso.FlagEstado = Convert.ToBoolean(gvPiso.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPisoEdit objManPisoEdit = new frmManPisoEdit();
                objManPisoEdit.pOperacion = frmManPisoEdit.Operacion.Modificar;
                objManPisoEdit.IdUbicacion = IdUbicacion;
                objManPisoEdit.IdPiso = objPiso.IdPiso;
                objManPisoEdit.pPisoBE = objPiso;
                objManPisoEdit.StartPosition = FormStartPosition.CenterParent;
                objManPisoEdit.ShowDialog();

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

            if (gvPiso.GetFocusedRowCellValue("IdPiso").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Piso", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}