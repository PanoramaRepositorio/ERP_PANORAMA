using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;


namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegAuditoriaBulto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<BultoBE> mLista = new List<BultoBE>();

        #endregion

        #region "Eventos"

        public frmRegAuditoriaBulto()
        {
            InitializeComponent();
        }

        private void frmRegAuditoriaBulto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            txtNumero.Focus();
        }

        private void tlbMenu_NewClick()
        {
            //try
            //{
            //    frmRegAuditoriaBultoEdit objManBultol = new frmRegAuditoriaBultoEdit();
            //    objManBultol.pOperacion = frmRegAuditoriaBultoEdit.Operacion.Nuevo;
            //    objManBultol.IdBulto = 0;
            //    objManBultol.StartPosition = FormStartPosition.CenterParent;
            //    objManBultol.ShowDialog();
            //    Cargar();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (XtraMessageBox.Show("Esta seguro de anular el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (!ValidarIngreso())
            //        {
            //            BultoBL objBL_Bulto = new BultoBL();
            //            BultoBE objE_Bulto = new BultoBE();

            //            objE_Bulto.IdBulto = int.Parse(gvBulto.GetFocusedRowCellValue("IdBulto").ToString());
            //            objE_Bulto.IdTienda = int.Parse(gvBulto.GetFocusedRowCellValue("IdTienda").ToString());
            //            objE_Bulto.IdFormaPago = int.Parse(gvBulto.GetFocusedRowCellValue("IdFormaPago").ToString());
            //            objE_Bulto.Numero = gvBulto.GetFocusedRowCellValue("Numero").ToString();
            //            objE_Bulto.FlagPreVenta = bool.Parse(gvBulto.GetFocusedRowCellValue("FlagPreVenta").ToString());
            //            objE_Bulto.Usuario = Parametros.strUsuarioLogin;
            //            objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            objE_Bulto.IdEmpresa = int.Parse(gvBulto.GetFocusedRowCellValue("IdEmpresa").ToString());
            //            objBL_Bulto.Elimina(objE_Bulto);
            //            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Cargar();
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

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                if (gvBulto.RowCount > 0)
                {


                    //Carga Informe

                    //frmListaPrinters frmPrinter = new frmListaPrinters();
                    //if (frmPrinter.ShowDialog() == DialogResult.OK)
                    //{
                    //    List<ReporteBultoContadoBE> lstReporte = null;
                    //    lstReporte = new ReporteBultoContadoBL().ListadoChequeo(Parametros.intPeriodo, int.Parse(gvBulto.GetFocusedRowCellValue("IdBulto").ToString()));

                    //    //CodigoBarra
                    //    iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                    //    bc.TextAlignment = Element.ALIGN_LEFT;
                    //    bc.Code = lstReporte[0].Numero;
                    //    bc.StartStopText = false;
                    //    bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                    //    bc.Extended = true;
                    //    bc.BarHeight = 27;
                    //    lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));


                    //    if (lstReporte.Count > 0)
                    //    {
                    //        rptBultoChequeo objReporteGuia = new rptBultoChequeo();
                    //        objReporteGuia.SetDataSource(lstReporte);
                    //        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    //        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                    //        objReporteGuia.SetParameterValue("Modificado", "()");

                    //        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "Cuadre_de_Operacion_ChequeoBulto_" + deHasta.DateTime.Day.ToString();
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBulto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvBulto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvBulto_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvBulto.RowCount > 0)
            {
                DataRow dr;
                int IdBulto = 0;
                dr = gvBulto.GetDataRow(e.RowHandle);
                IdBulto = int.Parse(dr["IdBulto"].ToString());
                CargarDetalles(IdBulto);
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarNumero();
            }
        }

        private void gvBulto_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvBulto.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["PorcentajeChequeo"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(1))
                        {
                            gvBulto.Columns["PorcentajeChequeo"].AppearanceCell.BackColor = Color.Green;
                            gvBulto.Columns["PorcentajeChequeo"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(1))
                        {
                            gvBulto.Columns["PorcentajeChequeo"].AppearanceCell.BackColor = Color.Orange;
                            gvBulto.Columns["PorcentajeChequeo"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        {
                            gvBulto.Columns["PorcentajeChequeo"].AppearanceCell.BackColor = Color.Red;
                            gvBulto.Columns["PorcentajeChequeo"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento > Convert.ToDecimal(1))
                        {
                            e.Appearance.BackColor = Color.Red;
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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            //int TipoConsulta = 0;
            //if (optFechaBulto.Checked == true)
            //{
            //    TipoConsulta = 1;
            //}

            DataTable dtBulto = new DataTable();
            mLista = new BultoBL().ListaChequeo(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime);
            dtBulto = FuncionBase.ToDataTable(mLista);
            gcBulto.DataSource = dtBulto;
            lblTotalRegistros.Text = mLista.Count.ToString(); //aadd
        }

        private void CargarNumero()
        {
            DataTable dtBulto = new DataTable();
            mLista = new BultoBL().ListaNumeroBultoChequeo(Parametros.intEmpresaId, txtNumero.Text.Trim());
            dtBulto = FuncionBase.ToDataTable(mLista);
            gcBulto.DataSource = dtBulto;
            lblTotalRegistros.Text = mLista.Count.ToString(); ; //aadd
        }

        private void CargarDetalles(int IdBulto)
        {
            //try
            //{
            //    DataTable dtDetalle = new DataTable();
            //    dtDetalle = FuncionBase.ToDataTable(new BultoDetalleBL().ListaTodosActivo(IdBulto));
            //    gcBultoDetalle.DataSource = dtDetalle;


            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        public void InicializarModificar()
        {
            if (gvBulto.RowCount > 0)
            {
                BultoBE objBulto = new BultoBE();
                objBulto.IdBulto = int.Parse(gvBulto.GetFocusedRowCellValue("IdBulto").ToString());
                frmRegAuditoriaBultoEdit objRegBultoEdit = new frmRegAuditoriaBultoEdit();
                objRegBultoEdit.pOperacion = frmRegAuditoriaBultoEdit.Operacion.Modificar;
                objRegBultoEdit.IdBulto = objBulto.IdBulto;
                objRegBultoEdit.StartPosition = FormStartPosition.CenterParent;
                objRegBultoEdit.btnGrabar.Enabled = true;
                objRegBultoEdit.ShowDialog();

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

            if (gvBulto.GetFocusedRowCellValue("IdBulto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Bulto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}