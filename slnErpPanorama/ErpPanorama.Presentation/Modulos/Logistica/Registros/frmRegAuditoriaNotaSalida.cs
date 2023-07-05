using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Rpt;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegAuditoriaNotaSalida : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MovimientoAlmacenBE> mLista = new List<MovimientoAlmacenBE>();

        #endregion

        #region "Eventos"

        public frmRegAuditoriaNotaSalida()
        {
            InitializeComponent();
        }

        private void frmRegAuditoriaNotaSalida_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            txtPeriodo.EditValue = DateTime.Now.Year;
            BSUtils.LoaderLook(cboSituacion, CargarTipoDocumento(), "Descripcion", "Id", false);
            cboSituacion.EditValue = 3;
            txtNumero.Focus();
        }


        private void gvMovimientoAlmacen_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvMovimientoAlmacen_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvMovimientoAlmacen.RowCount > 0)
            {
                DataRow dr;
                int IdMovimientoAlmacen = 0;
                dr = gvMovimientoAlmacen.GetDataRow(e.RowHandle);
                IdMovimientoAlmacen = int.Parse(dr["IdMovimientoAlmacen"].ToString());
                CargarDetalles(IdMovimientoAlmacen);
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarNumero();
            }
        }

        private void gvMovimientoAlmacen_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvMovimientoAlmacen.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["PorcentajeChequeo"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(1))
                        {
                            gvMovimientoAlmacen.Columns["PorcentajeChequeo"].AppearanceCell.BackColor = Color.Green;
                            gvMovimientoAlmacen.Columns["PorcentajeChequeo"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(1))
                        {
                            gvMovimientoAlmacen.Columns["PorcentajeChequeo"].AppearanceCell.BackColor = Color.Orange;
                            gvMovimientoAlmacen.Columns["PorcentajeChequeo"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        {
                            gvMovimientoAlmacen.Columns["PorcentajeChequeo"].AppearanceCell.BackColor = Color.Red;
                            gvMovimientoAlmacen.Columns["PorcentajeChequeo"].AppearanceCell.BackColor2 = Color.SeaShell;
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
            //if (optFechaMovimientoAlmacen.Checked == true)
            //{
            //    TipoConsulta = 1;
            //}

            DataTable dtMovimientoAlmacen = new DataTable();
            mLista = new MovimientoAlmacenBL().ListaFechaChequeo(deDesde.DateTime, deHasta.DateTime, Parametros.intTipMovSalida,Convert.ToInt32(cboSituacion.EditValue));
            dtMovimientoAlmacen = FuncionBase.ToDataTable(mLista);
            gcMovimientoAlmacen.DataSource = dtMovimientoAlmacen;
            lblTotalRegistros.Text = mLista.Count.ToString() + " Registros encontrados";
        }

        private void CargarNumero()
        {
            DataTable dtMovimientoAlmacen = new DataTable();
            mLista = new MovimientoAlmacenBL().ListaNumeroChequeo(Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim(), Parametros.intTipMovSalida);
            dtMovimientoAlmacen = FuncionBase.ToDataTable(mLista);
            gcMovimientoAlmacen.DataSource = dtMovimientoAlmacen;
            lblTotalRegistros.Text = mLista.Count.ToString() + " Registros encontrados";
        }

        private void CargarDetalles(int IdMovimientoAlmacen)
        {
            //try
            //{
            //    DataTable dtDetalle = new DataTable();
            //    dtDetalle = FuncionBase.ToDataTable(new MovimientoAlmacenDetalleBL().ListaTodosActivo(IdMovimientoAlmacen));
            //    gcMovimientoAlmacenDetalle.DataSource = dtDetalle;


            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        public void InicializarModificar()
        {
            if (gvMovimientoAlmacen.RowCount > 0)
            {
                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();
                objMovimientoAlmacen.IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());
                frmRegAuditoriaNotaIngresoEdit objRegMovimientoAlmacenEdit = new frmRegAuditoriaNotaIngresoEdit();
                objRegMovimientoAlmacenEdit.pOperacion = frmRegAuditoriaNotaIngresoEdit.Operacion.Modificar;
                objRegMovimientoAlmacenEdit.IdMovimientoAlmacen = objMovimientoAlmacen.IdMovimientoAlmacen;
                objRegMovimientoAlmacenEdit.TipoMovimiento = 1;
                objRegMovimientoAlmacenEdit.StartPosition = FormStartPosition.CenterParent;
                objRegMovimientoAlmacenEdit.btnGrabar.Enabled = true;
                if (objRegMovimientoAlmacenEdit.ShowDialog() == DialogResult.OK)
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

            if (gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una MovimientoAlmacen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "Cuadre_de_Operacion_ChequeoMovimientoAlmacen_" + deHasta.DateTime.Day.ToString();
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMovimientoAlmacen.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMovimientoAlmacen.RowCount > 0)
                {
                    frmListaPrinters frmPrinter = new frmListaPrinters();
                    if (frmPrinter.ShowDialog() == DialogResult.OK)
                    {
                        List<ReporteMovimientoAlmacenChequeoBE> lstReporte = null;
                        lstReporte = new ReporteMovimientoAlmacenChequeoBL().Listado(Parametros.intPeriodo, gvMovimientoAlmacen.GetFocusedRowCellValue("Numero").ToString(), int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdTipoMovimiento").ToString()));

                        //CodigoBarra
                        iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                        bc.TextAlignment = Element.ALIGN_LEFT;
                        bc.Code = lstReporte[0].Numero;
                        bc.StartStopText = false;
                        bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                        bc.Extended = true;
                        bc.BarHeight = 27;
                        lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));


                        if (lstReporte.Count > 0)
                        {
                            rptMovimientoAlmacenChequeoNotaSalida objReporteGuia = new rptMovimientoAlmacenChequeoNotaSalida();
                            objReporteGuia.SetDataSource(lstReporte);
                            objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                            objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                            Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpEditar_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }
        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "NOTA SALIDA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "PICKING";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "CHEQUEO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "EMBALAJE";
            dt.Rows.Add(dr);
            return dt;
        }

    }
}