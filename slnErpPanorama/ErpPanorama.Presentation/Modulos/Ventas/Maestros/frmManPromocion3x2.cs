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
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManPromocion3x2 : DevExpress.XtraEditors.XtraForm
    //: DevExpress.XtraEditors.XtraBaseForm  //   .XtraForm
    {
        #region "Propiedades"

        private List<Promocion3x2BE> mLista = new List<Promocion3x2BE>();

        #endregion

        #region "Eventos"

        public frmManPromocion3x2()
        {
            InitializeComponent();
        }

        private void frmManPromocion3x2_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPromocion3x2Edit objManPromocion3x2 = new frmManPromocion3x2Edit();
                //objManPromocion2x1. = mLista;
                objManPromocion3x2.pOperacion = frmManPromocion3x2Edit.Operacion.Nuevo;
                objManPromocion3x2.IdPromocion3x2 = 0;
                objManPromocion3x2.StartPosition = FormStartPosition.CenterParent;
                objManPromocion3x2.ShowDialog();
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
                        Promocion2x1BE objE_Promocion2x1 = new Promocion2x1BE();
                        objE_Promocion2x1.IdPromocion2x1 = int.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdPromocion2x1").ToString());
                        objE_Promocion2x1.Usuario = Parametros.strUsuarioLogin;
                        objE_Promocion2x1.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Promocion2x1.IdEmpresa = Parametros.intEmpresaId;

                        Promocion2x1BL objBL_Promocion2x1 = new Promocion2x1BL();
                        objBL_Promocion2x1.Elimina(objE_Promocion2x1);
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

            //    List<ErpPanoramaServicios.ReportePromocion2x1BE> lstReporte = null;
            //    lstReporte = objServicio.ReportePromocion2x1_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPromocion2x1 = new RptVistaReportes();
            //            objRptPromocion2x1.VerRptPromocion2x1(lstReporte);
            //            objRptPromocion2x1.ShowDialog();
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
            string _fileName = "ListadoPromocion3x2";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPromocion2x1.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPromocion2x1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new Promocion3x2BL().ListaTodosActivo(Parametros.intEmpresaId, "3x2");
            gcPromocion3x2.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPromocion3x2.DataSource = mLista.Where(obj =>
                                                   obj.DescFormaPago.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPromocion2x1.RowCount > 0)
            {
                Promocion2x1BE objPromocion2x1 = new Promocion2x1BE();
                objPromocion2x1.IdPromocion2x1 = int.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdPromocion2x1").ToString());
                objPromocion2x1.IdEmpresa = int.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdEmpresa").ToString());
                objPromocion2x1.DescPromocion2x1 = gvPromocion2x1.GetFocusedRowCellValue("DescPromocion2x1").ToString();
                objPromocion2x1.IdTipoCliente = int.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objPromocion2x1.IdFormaPago = int.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdFormaPago").ToString());
                objPromocion2x1.FechaInicio = DateTime.Parse(gvPromocion2x1.GetFocusedRowCellValue("FechaInicio").ToString());
                objPromocion2x1.FechaFin = DateTime.Parse(gvPromocion2x1.GetFocusedRowCellValue("FechaFin").ToString());
                objPromocion2x1.FlagContado = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagContado").ToString());
                objPromocion2x1.FlagCredito = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagCredito").ToString());
                objPromocion2x1.FlagConsignacion = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagConsignacion").ToString());
                objPromocion2x1.FlagSeparacion = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagSeparacion").ToString());
                objPromocion2x1.FlagContraentrega = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagContraentrega").ToString());
                objPromocion2x1.FlagCopagan = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagCopagan").ToString());
                objPromocion2x1.FlagObsequio = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagObsequio").ToString());
                objPromocion2x1.FlagAsaf = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagAsaf").ToString());
                objPromocion2x1.FlagClienteMayorista = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagClienteMayorista").ToString());
                objPromocion2x1.FlagClienteFinal = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagClienteFinal").ToString());
                objPromocion2x1.FlagEstado = Convert.ToBoolean(gvPromocion2x1.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPromocion3x2Edit objManPromocion2x1Edit = new frmManPromocion3x2Edit();
                objManPromocion2x1Edit.pOperacion = frmManPromocion3x2Edit.Operacion.Modificar;
                objManPromocion2x1Edit.IdPromocion3x2 = objPromocion2x1.IdPromocion2x1;
                //objManPromocion2x1Edit.pPromocion3x1BE = objPromocion2x1;
                objManPromocion2x1Edit.StartPosition = FormStartPosition.CenterParent;
                objManPromocion2x1Edit.ShowDialog();

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

            if (gvPromocion2x1.GetFocusedRowCellValue("IdPromocion2x1").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Promocion2x1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void generarporlineatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string _msg = "Se genero el archivo pdf de forma satisfactoria en la siguiente ubicación.\n{0}";
                //string _fileName = "Linea";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;

                    int IdTipoCliente = 0;
                    int IdPromocion2x1 = 0;
                    if (gvPromocion2x1.RowCount > 0)
                    {
                        IdTipoCliente = Int32.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdTipoCliente").ToString());
                        IdPromocion2x1 = Int32.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdPromocion2x1").ToString());

                        List<LineaProductoBE> lstLineaProducto = new List<LineaProductoBE>();
                        lstLineaProducto = new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);

                        foreach (var item in lstLineaProducto)
                        {
                            List<ReporteProductoCatalogoPromocion2x1BE> lstReporte = null;
                            lstReporte = new ReporteProductoCatalogoPromocion2x1BL().ListadoLineaProducto(IdPromocion2x1, item.IdLineaProducto);
                            if (lstReporte.Count > 0)
                            {
                                rptProductoCatalogo objReporte = new rptProductoCatalogo();
                                objReporte.SetDataSource(lstReporte);
                                objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, f.SelectedPath + @"\" + item.DescLineaProducto + ".pdf");
                                string _nM = string.Format(_msg, f.SelectedPath + @"\" + item.DescLineaProducto + ".pdf");
                                lblMensaje.Text = _nM;
                            }
                        }
                        XtraMessageBox.Show("Catálogos generados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Cursor = Cursors.Default;
               }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarporsublineatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string _msg = "Se genero el archivo pdf de forma satisfactoria en la siguiente ubicación.\n{0}";
                //string _fileName = "Linea";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;

                    int IdTipoCliente = 0;
                    int IdPromocion2x1 = 0;
                    if (gvPromocion2x1.RowCount > 0)
                    {
                        IdTipoCliente = Int32.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdTipoCliente").ToString());
                        IdPromocion2x1 = Int32.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdPromocion2x1").ToString());

                        List<LineaProductoBE> lstLineaProducto = new List<LineaProductoBE>();
                        lstLineaProducto = new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);

                        foreach (var itemLinea in lstLineaProducto)
                        {
                            string Directorio = f.SelectedPath;
                            List<SubLineaProductoBE> lstSubLineaProducto = new List<SubLineaProductoBE>();
                            lstSubLineaProducto = new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, itemLinea.IdLineaProducto);

                            Directorio = Directorio + @"\" + itemLinea.DescLineaProducto;
                            Directory.CreateDirectory(Directorio);

                            foreach (var item in lstSubLineaProducto)
                            {
                                List<ReporteProductoCatalogoPromocion2x1BE> lstReporte = null;
                                lstReporte = new ReporteProductoCatalogoPromocion2x1BL().ListadoSubLineaProducto(IdPromocion2x1, item.IdSubLineaProducto);
                                if (lstReporte.Count > 0)
                                {
                                    rptProductoCatalogo objReporte = new rptProductoCatalogo();
                                    objReporte.SetDataSource(lstReporte);
                                    objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, Directorio + @"\" + item.DescSubLineaProducto + ".pdf");
                                    string _nM = string.Format(_msg, Directorio + @"\" + item.DescSubLineaProducto + ".pdf");
                                    lblMensaje.Text = _nM;
                                }
                            }

                        }
                        XtraMessageBox.Show("Catálogos generados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copiartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvPromocion2x1.RowCount > 0)
            {
                //int IdPromocion2x1 = 0;
                //IdPromocion2x1 = Int32.Parse(gvPromocion2x1.GetFocusedRowCellValue("IdPromocion2x1").ToString());
                XtraMessageBox.Show("Copiado... Muy pronto Pegar", this.Text);
            }
        }

        private void pegartoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gvPromocion2x1_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPromocion2x1.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object ojbFechaInicio = View.GetRowCellValue(e.RowHandle, View.Columns["FechaInicio"]);
                    object ojbFechaFin = View.GetRowCellValue(e.RowHandle, View.Columns["FechaFin"]);
                    if (ojbFechaInicio != null && ojbFechaFin != null)
                    {
                        DateTime FechaInicio = DateTime.Parse(ojbFechaInicio.ToString());
                        DateTime FechaFin = DateTime.Parse(ojbFechaFin.ToString());
                        if (DateTime.Now > FechaInicio && DateTime.Now < FechaFin)
                        {
                            e.Appearance.BackColor = Color.YellowGreen;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                object obj = gvPromocion2x1.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["FlagEstado"]);
                    if (objDocRetiro != null)
                    {
                        Boolean IdTipoDocumento = Boolean.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == false)
                        {
                            e.Appearance.BackColor = Color.Gray;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcPromocion3x2_Click(object sender, EventArgs e)
        {

        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}