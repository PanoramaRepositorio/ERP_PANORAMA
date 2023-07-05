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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManEscalaMayorista : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<EscalaMayoristaBE> mLista = new List<EscalaMayoristaBE>();
        
        #endregion

        #region "Eventos"

        public frmManEscalaMayorista()
        {
            InitializeComponent();
        }

        private void frmManEscalaMayorista_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboFamiliaProducto,  new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFamiliaProducto", "IdFamiliaProducto", true);
            //cboFormaPago.EditValue = Parametros.intContado;
            //cboFamiliaProducto.EditValue = Parametros.intFamiliaRegular;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManEscalaMayoristaEdit  objManDescuentoClienteMayorista = new frmManEscalaMayoristaEdit ();
                objManDescuentoClienteMayorista.lstEscalaMayoristaBE = mLista;
                objManDescuentoClienteMayorista.pOperacion = frmManEscalaMayoristaEdit .Operacion.Nuevo;
                objManDescuentoClienteMayorista.IdDescuentoClienteMayorista = 0;
                objManDescuentoClienteMayorista.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClienteMayorista.ShowDialog();
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

        private void gvDescuentoClienteMayorista_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvDescuentoClienteMayorista.GetRow(e.RowHandle);
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiroNac = View.GetRowCellValue(e.RowHandle, View.Columns["General"]); //o en Descuento
                    if (objDocRetiroNac != null)
                    {
                        bool IdTipoDocumento = bool.Parse(objDocRetiroNac.ToString());
                        if (IdTipoDocumento)
                        {
                            e.Appearance.BackColor = Color.LightGreen;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            //gvDescuentoClienteMayorista.Columns["General"].AppearanceCell.BackColor = Color.LightGreen;
                            //gvDescuentoClienteMayorista.Columns["General"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        EscalaMayoristaBE objE_Mayorista = new EscalaMayoristaBE();
                        objE_Mayorista.IdEscalaMayorista = int.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdEscalaMayorista").ToString());
                        objE_Mayorista.Usuario = Parametros.strUsuarioLogin;
                        objE_Mayorista.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Mayorista.IdEmpresa = Parametros.intEmpresaId;

                        EscalaMayoristaBL objBL_Mayorista = new EscalaMayoristaBL();
                        objBL_Mayorista.Elimina(objE_Mayorista);
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

            //    List<ErpPanoramaServicios.ReporteDescuentoClienteMayoristaBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteDescuentoClienteMayorista_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDescuentoClienteMayorista = new RptVistaReportes();
            //            objRptDescuentoClienteMayorista.VerRptDescuentoClienteMayorista(lstReporte);
            //            objRptDescuentoClienteMayorista.ShowDialog();
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
            string _fileName = "ListadoDescuentoClienteMayoristas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescuentoClienteMayorista.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDescuentoClienteMayorista_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new EscalaMayoristaBL().ListaTodosActivo(Convert.ToInt32(cboFamiliaProducto.EditValue), Convert.ToInt32(cboFormaPago.EditValue));
            gcDescuentoClienteMayorista.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvDescuentoClienteMayorista.RowCount > 0)
            {
                EscalaMayoristaBE eItem = new EscalaMayoristaBE();
                eItem.IdEscalaMayorista = int.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdEscalaMayorista").ToString());
                eItem.IdFamiliaProducto = int.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdFamiliaProducto").ToString());
                eItem.IdFormaPago = int.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdFormaPago").ToString());
                eItem.Precio_Al = decimal.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("Precio_Al").ToString());
                eItem.Precio_Del = decimal.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("Precio_Del").ToString());
                eItem.Descuento = decimal.Parse(gvDescuentoClienteMayorista.GetFocusedRowCellValue("Descuento").ToString());
                eItem.General = Convert.ToBoolean(gvDescuentoClienteMayorista.GetFocusedRowCellValue("General").ToString());

                frmManEscalaMayoristaEdit  objMayoristaEdit = new frmManEscalaMayoristaEdit ();
                objMayoristaEdit.pOperacion = frmManEscalaMayoristaEdit .Operacion.Modificar;
                objMayoristaEdit.IdDescuentoClienteMayorista = eItem.IdEscalaMayorista;
                objMayoristaEdit.pDescuentoClienteMayoristaBE = eItem;
                objMayoristaEdit.StartPosition = FormStartPosition.CenterParent;
                objMayoristaEdit.ShowDialog();

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

            if (gvDescuentoClienteMayorista.GetFocusedRowCellValue("IdEscalaMayorista").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione DescuentoClienteMayorista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }



        #endregion

        private void cboFormaPago_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

       
    }
}