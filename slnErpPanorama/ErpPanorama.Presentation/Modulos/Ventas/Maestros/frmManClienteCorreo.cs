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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManClienteCorreo : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<ClienteCorreoBE> mLista = new List<ClienteCorreoBE>();

        #endregion

        #region "Eventos"

        public frmManClienteCorreo()
        {
            InitializeComponent();
        }

        private void frmManClienteCorreo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManClienteCorreoEdit objManClienteCorreo = new frmManClienteCorreoEdit();
                objManClienteCorreo.lstClienteCorreo = mLista;
                objManClienteCorreo.pOperacion = frmManClienteCorreoEdit.Operacion.Nuevo;
                objManClienteCorreo.IdClienteCorreo = 0;
                objManClienteCorreo.StartPosition = FormStartPosition.CenterParent;
                objManClienteCorreo.ShowDialog();
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
                        ClienteCorreoBE objE_ClienteCorreo = new ClienteCorreoBE();
                        objE_ClienteCorreo.IdClienteCorreo = int.Parse(gvClienteCorreo.GetFocusedRowCellValue("IdClienteCorreo").ToString());
                        objE_ClienteCorreo.Usuario = Parametros.strUsuarioLogin;
                        objE_ClienteCorreo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClienteCorreo.IdEmpresa = Parametros.intEmpresaId;

                        ClienteCorreoBL objBL_ClienteCorreo = new ClienteCorreoBL();
                        objBL_ClienteCorreo.Elimina(objE_ClienteCorreo);
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

            //    List<ReporteClienteCorreoBE> lstReporte = null;
            //    lstReporte = new ReporteClienteCorreoBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptClienteCorreo = new RptVistaReportes();
            //            objRptClienteCorreo.VerRptClienteCorreo(lstReporte);
            //            objRptClienteCorreo.ShowDialog();
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
            if (Parametros.strUsuarioLogin =="master" || Parametros.intPerfilId == Parametros.intPerAdministrador)
            {
                string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "ListadoClienteCorreos";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    gvClienteCorreo.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor = Cursors.Default;
                }
            }
            else
            {
                XtraMessageBox.Show("UD. No cuenta con permiso para Exportar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvClienteCorreo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ClienteCorreoBL().ListadoMailing(13, 0);
            gcClienteCorreo.DataSource = mLista;
            lblTotal.Text = mLista.Count().ToString() + " Registros Encontrados";
        }

        private void CargarBusqueda()
        {
            gcClienteCorreo.DataSource = mLista.Where(obj =>
                                                   obj.Email.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
            lblTotal.Text =gvClienteCorreo.RowCount.ToString() + " Registros Encontrados";
        }

        public void InicializarModificar()
        {
            if (gvClienteCorreo.RowCount > 0)
            {
                int TipoCliente = 0;

                TipoCliente = int.Parse(gvClienteCorreo.GetFocusedRowCellValue("IdTipoCliente").ToString());
                if (TipoCliente == Parametros.intTipClienteFinal)
                {
                    ClienteBE objClientel = new ClienteBE();
                    objClientel.IdCliente = int.Parse(gvClienteCorreo.GetFocusedRowCellValue("IdCliente").ToString());

                    frmManClienteMinoristaEdit objManClientelEdit = new frmManClienteMinoristaEdit();
                    objManClientelEdit.pOperacion = frmManClienteMinoristaEdit.Operacion.Modificar;
                    objManClientelEdit.IdCliente = objClientel.IdCliente;
                    objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                    objManClientelEdit.ShowDialog();
                }
                else
                {

                        ClienteBE objClientel = new ClienteBE();
                        objClientel.IdCliente = int.Parse(gvClienteCorreo.GetFocusedRowCellValue("IdCliente").ToString());

                        frmManClienteMayoristaEdit objManClientelEdit = new frmManClienteMayoristaEdit();
                        objManClientelEdit.pOperacion = frmManClienteMayoristaEdit.Operacion.Modificar;
                        objManClientelEdit.IdCliente = objClientel.IdCliente;
                        objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                        if (Parametros.strUsuarioLogin == "liliana" || Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "dhuaman")
                        {
                            objManClientelEdit.cboRuta.Enabled = true;
                            objManClientelEdit.cboVendedor.Enabled = true;
                            objManClientelEdit.btnGrabar.Enabled = true;
                        }
                        else
                        {
                            objManClientelEdit.cboRuta.Enabled = false;
                            objManClientelEdit.cboVendedor.Enabled = false;
                            objManClientelEdit.btnGrabar.Enabled = true;
                        }

                        objManClientelEdit.ShowDialog();

                   
                        
                }

                //ClienteCorreoBE objClienteCorreo = new ClienteCorreoBE();
                //objClienteCorreo.IdClienteCorreo = int.Parse(gvClienteCorreo.GetFocusedRowCellValue("IdClienteCorreo").ToString());
                //objClienteCorreo.Email = gvClienteCorreo.GetFocusedRowCellValue("Email").ToString();
                //objClienteCorreo.FlagEstado = Convert.ToBoolean(gvClienteCorreo.GetFocusedRowCellValue("FlagEstado").ToString());

                //frmManClienteCorreoEdit objManClienteCorreoEdit = new frmManClienteCorreoEdit();
                //objManClienteCorreoEdit.pOperacion = frmManClienteCorreoEdit.Operacion.Modificar;
                //objManClienteCorreoEdit.IdClienteCorreo = objClienteCorreo.IdClienteCorreo;
                //objManClienteCorreoEdit.pClienteCorreoBE = objClienteCorreo;
                //objManClienteCorreoEdit.StartPosition = FormStartPosition.CenterParent;
                //objManClienteCorreoEdit.ShowDialog();

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

            if (gvClienteCorreo.GetFocusedRowCellValue("IdClienteCorreo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Linea Producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gvClienteCorreo_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotal.Text = gvClienteCorreo.RowCount.ToString() + " Registros";
        }


    }
}