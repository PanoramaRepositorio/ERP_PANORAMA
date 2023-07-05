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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManPromocionTemporal : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PromocionTemporalBE> mLista = new List<PromocionTemporalBE>();
        private List<PromocionTemporalBE> mLista2 = new List<PromocionTemporalBE>();

        #endregion

        #region "Eventos"

        public frmManPromocionTemporal()
        {
            InitializeComponent();
        }

        private void frmManPromocionTemporal_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = Convert.ToDateTime("01/01/" + Parametros.intPeriodo);
            deHasta.EditValue = Convert.ToDateTime("31/12/" + Parametros.intPeriodo);
            deDesde2.EditValue = Convert.ToDateTime("01/01/" + Parametros.intPeriodo);
            deHasta2.EditValue = Convert.ToDateTime("31/12/" + Parametros.intPeriodo);
            Cargar();

            this.SoloVisual(); //ecm
        }
        private void SoloVisual() //ecm
        {
            //if (Parametros.intPerfilId == Parametros.intPerAuxiliarVisual)
            //{
            //    txtDescripcion.ReadOnly = true;
            //    txtCodigo.ReadOnly = true;
            //    btnConsultar.Visible = false;
            //    txtDescripcion.Text = "OUTLET";

            //    this.CargarBusqueda();
            //}
        }
        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPromocionTemporalEdit objManPromocionTemporal = new frmManPromocionTemporalEdit();
                //objManPromocionTemporal. = mLista;
                objManPromocionTemporal.pOperacion = frmManPromocionTemporalEdit.Operacion.Nuevo;
                objManPromocionTemporal.IdPromocionTemporal = 0;
                objManPromocionTemporal.StartPosition = FormStartPosition.CenterParent;
                if (objManPromocionTemporal.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
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
            if (xtraTabControl1.SelectedTabPage == xtraTabPageTienda)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarIngreso())
                        {
                            PromocionTemporalBE objE_PromocionTemporal = new PromocionTemporalBE();
                            objE_PromocionTemporal.IdPromocionTemporal = int.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdPromocionTemporal").ToString());
                            objE_PromocionTemporal.Usuario = Parametros.strUsuarioLogin;
                            objE_PromocionTemporal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_PromocionTemporal.IdEmpresa = Parametros.intEmpresaId;

                            PromocionTemporalBL objBL_PromocionTemporal = new PromocionTemporalBL();
                            objBL_PromocionTemporal.Elimina(objE_PromocionTemporal);
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
            else
            {
                XtraMessageBox.Show("La promoción ya está eliminada, a donde más lo vas a enviar!!!\nSi Ud. desea activar la promoción tiene que usar las esferas del dragón(Sistemas).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

            //    List<ErpPanoramaServicios.ReportePromocionTemporalBE> lstReporte = null;
            //    lstReporte = objServicio.ReportePromocionTemporal_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPromocionTemporal = new RptVistaReportes();
            //            objRptPromocionTemporal.VerRptPromocionTemporal(lstReporte);
            //            objRptPromocionTemporal.ShowDialog();
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
            string _fileName = "ListadoPromocionTemporal";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPromocionTemporal.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPromocionTemporal_DoubleClick(object sender, EventArgs e)
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
            //CargarBusqueda();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                optCodigo.Checked = true;
                txtCodigo.Select();
            }
            if (keyData == Keys.F6)
            {
                optHangTag.Checked = true;
                txtCodigo.Select();
                //txtCodigo.SelectAll();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPageTienda)
            {
                mLista = new PromocionTemporalBL().ListaFecha(Parametros.intEmpresaId, true, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                gcPromocionTemporal.DataSource = mLista;
            }
            else //Eliminados
            {
                mLista2 = new PromocionTemporalBL().ListaFecha(Parametros.intEmpresaId, false, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
                gcPromocionTemporal2.DataSource = mLista2;
            }
        }

        private void CargarBusqueda()
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPageTienda)
            {
                gcPromocionTemporal.DataSource = mLista.Where(obj =>
                                                   obj.DescPromocionTemporal.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
            }
            else
            {
                gcPromocionTemporal2.DataSource = mLista2.Where(obj =>
                                   obj.DescPromocionTemporal.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
            }
        }


        public void InicializarModificar()
        {
            if (gvPromocionTemporal.RowCount > 0)
            {
                PromocionTemporalBE objPromocionTemporal = new PromocionTemporalBE();
                objPromocionTemporal.IdPromocionTemporal = int.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdPromocionTemporal").ToString());
                objPromocionTemporal.IdEmpresa = int.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdEmpresa").ToString());
                objPromocionTemporal.DescPromocionTemporal = gvPromocionTemporal.GetFocusedRowCellValue("DescPromocionTemporal").ToString();
                objPromocionTemporal.IdTipoCliente = int.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objPromocionTemporal.IdFormaPago = int.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdFormaPago").ToString());
                objPromocionTemporal.IdTienda = int.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdTienda").ToString());
                objPromocionTemporal.IdTipoVenta = int.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdTipoVenta").ToString());
                objPromocionTemporal.FechaInicio = DateTime.Parse(gvPromocionTemporal.GetFocusedRowCellValue("FechaInicio").ToString());
                objPromocionTemporal.FechaFin = DateTime.Parse(gvPromocionTemporal.GetFocusedRowCellValue("FechaFin").ToString());
                objPromocionTemporal.FlagContado = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagContado").ToString());
                objPromocionTemporal.FlagCredito = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagCredito").ToString());
                objPromocionTemporal.FlagConsignacion = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagConsignacion").ToString());
                objPromocionTemporal.FlagSeparacion = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagSeparacion").ToString());
                objPromocionTemporal.FlagContraentrega = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagContraentrega").ToString());
                objPromocionTemporal.FlagCopagan = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagCopagan").ToString());
                objPromocionTemporal.FlagObsequio = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagObsequio").ToString());
                objPromocionTemporal.FlagAsaf = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagAsaf").ToString());
                objPromocionTemporal.FlagClienteMayorista = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagClienteMayorista").ToString());
                objPromocionTemporal.FlagClienteFinal = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagClienteFinal").ToString());
                objPromocionTemporal.FlagUcayali = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagUcayali").ToString());
                objPromocionTemporal.FlagAndahuaylas = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagAndahuaylas").ToString());
                objPromocionTemporal.FlagPrescott = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagPrescott").ToString());
                objPromocionTemporal.FlagAviacion = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagAviacion").ToString());
                objPromocionTemporal.FlagMegaplaza = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagMegaplaza").ToString());
                objPromocionTemporal.FlagWeb = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagWeb").ToString());
                objPromocionTemporal.FechaInicioImpresion = DateTime.Parse(gvPromocionTemporal.GetFocusedRowCellValue("FechaInicioImpresion").ToString());
                objPromocionTemporal.FechaFinImpresion = DateTime.Parse(gvPromocionTemporal.GetFocusedRowCellValue("FechaFinImpresion").ToString());
                objPromocionTemporal.FlagEstado = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagEstado").ToString());
                objPromocionTemporal.FlagAviacion2 = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagAviacion2").ToString());
                objPromocionTemporal.FlagSanMiguel = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagSanMiguel").ToString());

                frmManPromocionTemporalEdit objManPromocionTemporalEdit = new frmManPromocionTemporalEdit();
                objManPromocionTemporalEdit.pOperacion = frmManPromocionTemporalEdit.Operacion.Modificar;
                objManPromocionTemporalEdit.IdPromocionTemporal = objPromocionTemporal.IdPromocionTemporal;
                objManPromocionTemporalEdit.pPromocionTemporalBE = objPromocionTemporal;
                objManPromocionTemporalEdit.StartPosition = FormStartPosition.CenterParent;
                if (objManPromocionTemporalEdit.ShowDialog() == DialogResult.OK)
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

            if (gvPromocionTemporal.GetFocusedRowCellValue("IdPromocionTemporal").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione PromocionTemporal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    int IdPromocionTemporal = 0;
                    if (gvPromocionTemporal.RowCount > 0)
                    {
                        IdTipoCliente = Int32.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdTipoCliente").ToString());
                        IdPromocionTemporal = Int32.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdPromocionTemporal").ToString());

                        //if (IdTipoCliente == Parametros.intTipClienteMayorista)
                        //{
                        List<LineaProductoBE> lstLineaProducto = new List<LineaProductoBE>();
                        lstLineaProducto = new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);

                        foreach (var item in lstLineaProducto)
                        {
                            List<ReporteProductoCatalogoPromocionTemporalBE> lstReporte = null;
                            lstReporte = new ReporteProductoCatalogoPromocionTemporalBL().ListadoLineaProducto(IdPromocionTemporal, item.IdLineaProducto);
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
                        //}
                        //else
                        //{
                        //List<ReporteProductoCatologoInvBultoBE> lstReporteaaa = null;
                        //lstReporteaaa = new ReporteProductoCatologoInvBultoBL().Listado(13);
                        //rptProductoCatalogoSoles objReporte = new rptProductoCatalogoSoles();
                        //objReporte.SetDataSource(lstReporteaaa);
                        //objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, f.SelectedPath + @"\" + Convert.ToString(i) + "." + nomLinea + ".pdf");
                        //string _nM = string.Format(_msg, f.SelectedPath + @"\" + Convert.ToString(i) + "." + nomLinea + ".pdf");
                        //lblNumExp.Text = _nM;
                        //}
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
                    int IdPromocionTemporal = 0;
                    if (gvPromocionTemporal.RowCount > 0)
                    {
                        IdTipoCliente = Int32.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdTipoCliente").ToString());
                        IdPromocionTemporal = Int32.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdPromocionTemporal").ToString());

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
                                List<ReporteProductoCatalogoPromocionTemporalBE> lstReporte = null;
                                lstReporte = new ReporteProductoCatalogoPromocionTemporalBL().ListadoSubLineaProducto(IdPromocionTemporal, item.IdSubLineaProducto);
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

        private void gvPromocionTemporal_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPromocionTemporal.GetRow(e.RowHandle);

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
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCodigo.Checked)
            {
                txtCodigo.Select();
            }
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (optHangTag.Checked)
            {
                txtCodigo.Select();
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    if (optCodigo.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        int Resultado = 0; //add 240616
                        Resultado = new ProductoBL().SeleccionaBusquedaCount(txtCodigo.Text.Trim());

                        if (Resultado == 0)
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCodigo.SelectAll();
                            return;
                        }
                        if (Resultado == 1)
                        {
                            ProductoBE objE_Producto2 = null;
                            objE_Producto2 = new ProductoBL().SeleccionaParteCodigo(Parametros.intEmpresaId, txtCodigo.Text.Trim());
                            objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objE_Producto2.CodigoProveedor);
                        }
                        else
                        {
                            frmBusProducto objBusProducto = new frmBusProducto();
                            objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            objBusProducto.ShowDialog();
                            if (objBusProducto.pProductoBE != null)
                            {
                                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                            }
                            else
                            {
                                txtCodigo.Select();
                                return;
                            }

                        }

                        if (objE_Producto != null)
                        {
                            //IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            //txtDescripcion.Text = objE_Producto.NombreProducto;

                            txtCodigo.SelectAll();
                            CargarBusquedaCodigo(objE_Producto.IdProducto);
                            //Cargar();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    //Hang Tag

                    if (optHangTag.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        if (txtCodigo.Text.Trim().Length > 6)
                            //objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo.Text.Trim()); //Codigo de Barras de Importación
                            objE_Producto = new ProductoBL().SeleccionaCodigoBarra(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                        else
                            objE_Producto = new ProductoBL().SeleccionaID(Parametros.intEmpresaId, Parametros.intTiendaId, Convert.ToInt32(txtCodigo.Text.Trim()));
                        if (objE_Producto != null)
                        {
                            //IdProducto = objE_Producto.IdProducto;
                            //txtCodigo.Text = objE_Producto.CodigoProveedor;
                            //txtDescripcion.Text = objE_Producto.NombreProducto;

                            txtCodigo.SelectAll();
                            CargarBusquedaCodigo(objE_Producto.IdProducto);
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void CargarBusquedaCodigo(int IdProducto)
        {
            //mLista = new MovimientoAlmacenBL().ListaCodigo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovSalida, IdProducto);
            //dt = FuncionBase.ToDataTable(mLista);
            //gcMovimientoAlmacen.DataSource = mLista;

            mLista = new PromocionTemporalBL().ListaFechaProducto(Parametros.intEmpresaId, IdProducto, Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcPromocionTemporal.DataSource = mLista;
        }

        private void btnConsultar2_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtDescripcion2_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void gvPromocionTemporal2_DoubleClick(object sender, EventArgs e)
        {
            if (gvPromocionTemporal2.RowCount > 0)
            {
                PromocionTemporalBE objPromocionTemporal = new PromocionTemporalBE();
                objPromocionTemporal.IdPromocionTemporal = int.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("IdPromocionTemporal").ToString());
                objPromocionTemporal.IdEmpresa = int.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("IdEmpresa").ToString());
                objPromocionTemporal.DescPromocionTemporal = gvPromocionTemporal2.GetFocusedRowCellValue("DescPromocionTemporal").ToString();
                objPromocionTemporal.IdTipoCliente = int.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objPromocionTemporal.IdFormaPago = int.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("IdFormaPago").ToString());
                objPromocionTemporal.IdTienda = int.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("IdTienda").ToString());
                objPromocionTemporal.IdTipoVenta = int.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("IdTipoVenta").ToString());
                objPromocionTemporal.FechaInicio = DateTime.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("FechaInicio").ToString());
                objPromocionTemporal.FechaFin = DateTime.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("FechaFin").ToString());
                objPromocionTemporal.FlagContado = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagContado").ToString());
                objPromocionTemporal.FlagCredito = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagCredito").ToString());
                objPromocionTemporal.FlagConsignacion = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagConsignacion").ToString());
                objPromocionTemporal.FlagSeparacion = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagSeparacion").ToString());
                objPromocionTemporal.FlagContraentrega = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagContraentrega").ToString());
                objPromocionTemporal.FlagCopagan = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagCopagan").ToString());
                objPromocionTemporal.FlagObsequio = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagObsequio").ToString());
                objPromocionTemporal.FlagAsaf = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagAsaf").ToString());
                objPromocionTemporal.FlagClienteMayorista = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagClienteMayorista").ToString());
                objPromocionTemporal.FlagClienteFinal = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagClienteFinal").ToString());
                objPromocionTemporal.FlagUcayali = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagUcayali").ToString());
                objPromocionTemporal.FlagAndahuaylas = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagAndahuaylas").ToString());
                objPromocionTemporal.FlagPrescott = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagPrescott").ToString());
                objPromocionTemporal.FlagAviacion = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagAviacion").ToString());
                objPromocionTemporal.FlagMegaplaza = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagMegaplaza").ToString());
                objPromocionTemporal.FlagAviacion2 = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagAviacion2").ToString());
                objPromocionTemporal.FlagSanMiguel = Convert.ToBoolean(gvPromocionTemporal.GetFocusedRowCellValue("FlagSanMiguel").ToString());
                objPromocionTemporal.FlagWeb = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagWeb").ToString());
                objPromocionTemporal.FechaInicioImpresion = DateTime.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("FechaInicioImpresion").ToString());
                objPromocionTemporal.FechaFinImpresion = DateTime.Parse(gvPromocionTemporal2.GetFocusedRowCellValue("FechaFinImpresion").ToString());
                objPromocionTemporal.FlagEstado = Convert.ToBoolean(gvPromocionTemporal2.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPromocionTemporalEdit objManPromocionTemporalEdit = new frmManPromocionTemporalEdit();
                objManPromocionTemporalEdit.pOperacion = frmManPromocionTemporalEdit.Operacion.Modificar;
                objManPromocionTemporalEdit.IdPromocionTemporal = objPromocionTemporal.IdPromocionTemporal;
                objManPromocionTemporalEdit.pPromocionTemporalBE = objPromocionTemporal;
                objManPromocionTemporalEdit.StartPosition = FormStartPosition.CenterParent;
                objManPromocionTemporalEdit.btnGrabar.Enabled = false;
                objManPromocionTemporalEdit.mnuContextual.Visible = false;
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void generarPorLíneaMayoristaToolStripMenuItem_Click(object sender, EventArgs e)
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
                    int IdPromocionTemporal = 0;
                    if (gvPromocionTemporal.RowCount > 0)
                    {
                        IdTipoCliente = Int32.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdTipoCliente").ToString());
                        IdPromocionTemporal = Int32.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdPromocionTemporal").ToString());

                        //if (IdTipoCliente == Parametros.intTipClienteMayorista)
                        //{
                        List<LineaProductoBE> lstLineaProducto = new List<LineaProductoBE>();
                        lstLineaProducto = new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);

                        foreach (var item in lstLineaProducto)
                        {
                            List<ReporteProductoCatalogoPromocionTemporalBE> lstReporte = null;
                            lstReporte = new ReporteProductoCatalogoPromocionTemporalBL().ListadoLineaProducto(IdPromocionTemporal, item.IdLineaProducto);
                            if (lstReporte.Count > 0)
                            {
                                rptProductoCatalogoMayorista objReporte = new rptProductoCatalogoMayorista();
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

        private void generarPorSubLíneaToolStripMenuItem_Click(object sender, EventArgs e)
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
                    int IdPromocionTemporal = 0;
                    if (gvPromocionTemporal.RowCount > 0)
                    {
                        IdTipoCliente = Int32.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdTipoCliente").ToString());
                        IdPromocionTemporal = Int32.Parse(gvPromocionTemporal.GetFocusedRowCellValue("IdPromocionTemporal").ToString());

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
                                List<ReporteProductoCatalogoPromocionTemporalBE> lstReporte = null;
                                lstReporte = new ReporteProductoCatalogoPromocionTemporalBL().ListadoSubLineaProducto(IdPromocionTemporal, item.IdSubLineaProducto);
                                if (lstReporte.Count > 0)
                                {
                                    rptProductoCatalogoMayorista objReporte = new rptProductoCatalogoMayorista();
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

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}