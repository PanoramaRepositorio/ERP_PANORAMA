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

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas
{
    public partial class frmConFacturaCompra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<FacturaCompraBE> mLista = new List<FacturaCompraBE>();

        #endregion

        #region "Eventos"

        public frmConFacturaCompra()
        {
            InitializeComponent();
        }

        private void frmConFacturaCompra_Load(object sender, EventArgs e)
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
                frmConFacturaCompraEdit objManFacturaCompra = new frmConFacturaCompraEdit();
                objManFacturaCompra.pOperacion = frmConFacturaCompraEdit.Operacion.Nuevo;
                objManFacturaCompra.IdFacturaCompra = 0;
                objManFacturaCompra.StartPosition = FormStartPosition.CenterParent;
                objManFacturaCompra.ShowDialog();
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

                if (gvFacturaCompra.RowCount > 0)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || Parametros.strUsuarioLogin == "ygomez" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "etapia" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador)
                        {
                            if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (!ValidarIngreso())
                                {
                                    FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                                    objE_FacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
                                    objE_FacturaCompra.Usuario = Parametros.strUsuarioLogin;
                                    objE_FacturaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;

                                    FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                                    objBL_FacturaCompra.Elimina(objE_FacturaCompra);
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


                //if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    if (!ValidarIngreso())
                //    {
                //        FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                //        objE_FacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
                //        objE_FacturaCompra.Usuario = Parametros.strUsuarioLogin;
                //        objE_FacturaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                //        objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;

                //        FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                //        objBL_FacturaCompra.Elimina(objE_FacturaCompra);
                //        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        Cargar();
                //    }
                //}
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
                    FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                    objE_FacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
                    objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;

                    List<ReporteFacturaCompraBE> lstReporte = null;
                    lstReporte = new ReporteFacturaCompraBL().ListadoStock(Parametros.intEmpresaId, objE_FacturaCompra.IdFacturaCompra);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptFacturaCompra = new RptVistaReportes();
                            objRptFacturaCompra.VerRptFacturaCompraStock(lstReporte);
                            objRptFacturaCompra.ShowDialog();
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
            string _fileName = "ListadoFacturas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvFacturaCompra.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvFacturaCompra_DoubleClick(object sender, EventArgs e)
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

        }

        private void vercatalogotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvFacturaCompra.RowCount > 0)
                {
                    int IdFactura = 0;
                    IdFactura = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());

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
                if (gvFacturaCompra.RowCount > 0)
                {
                    int IdFactura = 0;
                    IdFactura = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());

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
            mLista = new FacturaCompraBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intPeriodo);
            gcFacturaCompra.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcFacturaCompra.DataSource = mLista.Where(obj =>
                                                   obj.NumeroDocumento.ToUpper().Contains(txtNumeroDocumento.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvFacturaCompra.RowCount > 0)
            {
                FacturaCompraBE objFacturaCompra = new FacturaCompraBE();
                objFacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());

                frmConFacturaCompraEdit objManFacturaCompraEdit = new frmConFacturaCompraEdit();
                objManFacturaCompraEdit.pOperacion = frmConFacturaCompraEdit.Operacion.Modificar;
                objManFacturaCompraEdit.IdFacturaCompra = objFacturaCompra.IdFacturaCompra;
                objManFacturaCompraEdit.bMostrarVenta = chkIncluirVenta.Checked;
                objManFacturaCompraEdit.StartPosition = FormStartPosition.CenterParent;

                //objManFacturaCompraEdit.ShowDialog();
                if (objManFacturaCompraEdit.ShowDialog() == DialogResult.OK)
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

            if (gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Factura Compra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void verclasificacionpreciofototoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaProductoFoto frm = new frmListaProductoFoto();
            frm.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
            frm.Show();
        }

        private void verdetalleventatoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gvFacturaCompra_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvFacturaCompra.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["PorcentajeVenta"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(0.7))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.7))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Orange;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Red;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

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

        private void d()
        {

        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}