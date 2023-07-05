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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmRegFacturaCompraInsumo : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"


        private List<FacturaCompraInsumoBE> mLista = new List<FacturaCompraInsumoBE>();

        #endregion

        #region "Eventos"


        public frmRegFacturaCompraInsumo()
        {
            InitializeComponent();
        }

        private void frmRegFacturaCompraInsumo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            Cargar();
        }
        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegFacturaCompraInsumoEdit objManFacturaCompraInsumo = new frmRegFacturaCompraInsumoEdit();
                objManFacturaCompraInsumo.pOperacion = frmRegFacturaCompraInsumoEdit.Operacion.Nuevo;
                objManFacturaCompraInsumo.IdFacturaCompraInsumo = 0;
                objManFacturaCompraInsumo.StartPosition = FormStartPosition.CenterParent;
                objManFacturaCompraInsumo.ShowDialog();
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

                if (gvFacturaCompraInsumo.RowCount > 0)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "marjorie" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" 
                            || frmAutoriza.Usuario == "etapia" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ygomez")
                        {
                            if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (!ValidarIngreso())
                                {
                                    FacturaCompraInsumoBE objE_FacturaCompraInsumo = new FacturaCompraInsumoBE();
                                    objE_FacturaCompraInsumo.IdFacturaCompraInsumo = int.Parse(gvFacturaCompraInsumo.GetFocusedRowCellValue("IdFacturaCompraInsumo").ToString());
                                    objE_FacturaCompraInsumo.Usuario = Parametros.strUsuarioLogin;
                                    objE_FacturaCompraInsumo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_FacturaCompraInsumo.IdEmpresa = Parametros.intEmpresaId;

                                    FacturaCompraInsumoBL objBL_FacturaCompraInsumo = new FacturaCompraInsumoBL();
                                    objBL_FacturaCompraInsumo.Elimina(objE_FacturaCompraInsumo);
                                    XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Cargar();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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
            //    if (mLista.Count > 0)
            //    {
            //        FacturaCompraInsumoBE objE_FacturaCompraInsumo = new FacturaCompraInsumoBE();
            //        objE_FacturaCompraInsumo.IdFacturaCompraInsumo = int.Parse(gvFacturaCompraInsumo.GetFocusedRowCellValue("IdFacturaCompraInsumo").ToString());
            //        objE_FacturaCompraInsumo.IdEmpresa = Parametros.intEmpresaId;

            //        List<ReporteFacturaCompraInsumoBE> lstReporte = null;
            //        lstReporte = new ReporteFacturaCompraInsumoBL().Listado(Parametros.intEmpresaId, objE_FacturaCompraInsumo.IdFacturaCompraInsumo);

            //        if (lstReporte != null)
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptFacturaCompraInsumo = new RptVistaReportes();
            //                objRptFacturaCompraInsumo.VerRptFacturaCompraInsumo(lstReporte);
            //                objRptFacturaCompraInsumo.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }

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
            string _fileName = "ListadoFacturas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvFacturaCompraInsumo.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvFacturaCompraInsumo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            Cargar();
        }

        private void actualizafecharecepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    frmRegActualizaFechaRecepcion objFacturaCompraInsumo = new frmRegActualizaFechaRecepcion();
            //    objFacturaCompraInsumo.IdFacturaCompraInsumo = int.Parse(gvFacturaCompraInsumo.GetFocusedRowCellValue("IdFacturaCompraInsumo").ToString());
            //    if (objFacturaCompraInsumo.ShowDialog() == DialogResult.OK)
            //    {
            //        Cargar();
            //    }

            //    Cursor = Cursors.Default;

            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void vercatalogotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvFacturaCompraInsumo.RowCount > 0)
                {
                    int IdFactura = 0;
                    IdFactura = int.Parse(gvFacturaCompraInsumo.GetFocusedRowCellValue("IdFacturaCompraInsumo").ToString());

                    List<ReporteProductoCatalogoFacturaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoFacturaBL().Listado(Parametros.intEmpresaId, IdFactura, Parametros.intTipClienteMayorista);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoFactura = new RptVistaReportes();
                            objRptProductoCatalogoFactura.VerRptProductoCatalogoFactura(lstReporte);
                            objRptProductoCatalogoFactura.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vercatalogosolestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvFacturaCompraInsumo.RowCount > 0)
                {
                    int IdFactura = 0;
                    IdFactura = int.Parse(gvFacturaCompraInsumo.GetFocusedRowCellValue("IdFacturaCompraInsumo").ToString());

                    List<ReporteProductoCatalogoFacturaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoFacturaBL().Listado(Parametros.intEmpresaId, IdFactura, Parametros.intTipClienteMayorista);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoFactura = new RptVistaReportes();
                            objRptProductoCatalogoFactura.VerRptProductoCatalogoFacturaSoles(lstReporte);
                            objRptProductoCatalogoFactura.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
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
            mLista = new FacturaCompraInsumoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intPeriodo);
            gcFacturaCompraInsumo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcFacturaCompraInsumo.DataSource = mLista.Where(obj =>
                                                   obj.NumeroDocumento.ToUpper().Contains(txtNumeroDocumento.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvFacturaCompraInsumo.RowCount > 0)
            {
                FacturaCompraInsumoBE objFacturaCompraInsumo = new FacturaCompraInsumoBE();
                objFacturaCompraInsumo.IdFacturaCompraInsumo = int.Parse(gvFacturaCompraInsumo.GetFocusedRowCellValue("IdFacturaCompraInsumo").ToString());

                frmRegFacturaCompraInsumoEdit objManFacturaCompraInsumoEdit = new frmRegFacturaCompraInsumoEdit();
                objManFacturaCompraInsumoEdit.pOperacion = frmRegFacturaCompraInsumoEdit.Operacion.Modificar;
                objManFacturaCompraInsumoEdit.IdFacturaCompraInsumo = objFacturaCompraInsumo.IdFacturaCompraInsumo;
                //objManFacturaCompraInsumoEdit.bMostrarVenta = chkIncluirVenta.Checked;
                objManFacturaCompraInsumoEdit.StartPosition = FormStartPosition.CenterParent;

                //objManFacturaCompraInsumoEdit.ShowDialog();
                if (objManFacturaCompraInsumoEdit.ShowDialog() == DialogResult.OK)
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

            if (gvFacturaCompraInsumo.GetFocusedRowCellValue("IdFacturaCompraInsumo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Factura Compra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion



        private void gvFacturaCompraInsumo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvFacturaCompraInsumo.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["PorcentajeVenta"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(0.7))
                        {
                            gvFacturaCompraInsumo.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            gvFacturaCompraInsumo.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.7))
                        {
                            gvFacturaCompraInsumo.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Orange;
                            gvFacturaCompraInsumo.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        {
                            gvFacturaCompraInsumo.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Red;
                            gvFacturaCompraInsumo.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Red; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}