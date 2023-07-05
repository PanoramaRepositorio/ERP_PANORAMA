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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros
{
    public partial class frmManProveedor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProveedorBE> mLista = new List<ProveedorBE>();

        #endregion

        #region "Eventos"

        public frmManProveedor()
        {
            InitializeComponent();
        }

        private void frmManProveedor_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManProveedorEdit objManProveedor = new frmManProveedorEdit();
                objManProveedor.lstProveedor = mLista;
                objManProveedor.pOperacion = frmManProveedorEdit.Operacion.Nuevo;
                objManProveedor.IdProveedor = 0;
                objManProveedor.StartPosition = FormStartPosition.CenterParent;
                objManProveedor.ShowDialog();
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
                        ProveedorBE objE_Proveedor = new ProveedorBE();
                        objE_Proveedor.IdProveedor = int.Parse(gvProveedor.GetFocusedRowCellValue("IdProveedor").ToString());
                        objE_Proveedor.Usuario = Parametros.strUsuarioLogin;
                        objE_Proveedor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Proveedor.IdEmpresa = Parametros.intEmpresaId;

                        ProveedorBL objBL_Proveedor = new ProveedorBL();
                        objBL_Proveedor.Elimina(objE_Proveedor);
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

                List<ReporteProveedorBE> lstReporte = null;
                lstReporte = new ReporteProveedorBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptProveedor = new RptVistaReportes();
                        objRptProveedor.VerRptProveedor(lstReporte);
                        objRptProveedor.ShowDialog();
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
            string _fileName = "ListadoCajaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProveedor.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvProveedor_DoubleClick(object sender, EventArgs e)
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
            mLista = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcProveedor.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcProveedor.DataSource = mLista.Where(obj =>
                                                   obj.DescProveedor.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.NumeroDocumento.Contains(txtDescripcion.Text)
                                                   || obj.Contacto.Contains(txtDescripcion.Text.ToUpper()) || obj.ContactoCredito.Contains(txtDescripcion.Text.ToUpper())
                                                   ).ToList();
        }

        public void InicializarModificar()
        {
            if (gvProveedor.RowCount > 0)
            {
                ProveedorBE objProveedor = new ProveedorBE();
                objProveedor.IdProveedor = int.Parse(gvProveedor.GetFocusedRowCellValue("IdProveedor").ToString());
                objProveedor.IdEmpresa = int.Parse(gvProveedor.GetFocusedRowCellValue("IdEmpresa").ToString());
                objProveedor.DescProveedor = gvProveedor.GetFocusedRowCellValue("DescProveedor").ToString();
                objProveedor.FlagEstado = Convert.ToBoolean(gvProveedor.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManProveedorEdit objManProveedorEdit = new frmManProveedorEdit();
                objManProveedorEdit.pOperacion = frmManProveedorEdit.Operacion.Modificar;
                objManProveedorEdit.IdProveedor = objProveedor.IdProveedor;
                objManProveedorEdit.pProveedorBE = objProveedor;
                objManProveedorEdit.StartPosition = FormStartPosition.CenterParent;
                objManProveedorEdit.ShowDialog();

                if (objManProveedorEdit.vRefresca == 1)
                { Cargar(); }
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

            if (gvProveedor.GetFocusedRowCellValue("IdProveedor").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }



        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}