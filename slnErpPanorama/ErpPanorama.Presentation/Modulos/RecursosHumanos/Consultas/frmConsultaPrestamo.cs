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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmConsultaPrestamo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SolicitudPrestamoBE> mListaSolicitudPrestamo = new List<SolicitudPrestamoBE>();
        private List<SolicitudPrestamoDetalleBE> mLista = new List<SolicitudPrestamoDetalleBE>();

        private int IdPersona = 0;

        #endregion

        #region "Eventos"

        public frmConsultaPrestamo()
        {
            InitializeComponent();
        }

        private void frmConsultaPrestamo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = Convert.ToDateTime("01/01/2015");
            deHasta.EditValue = DateTime.Now;
            CargarPersona();
        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor = Cursors.WaitCursor;

                //if (IdCliente == 0)
                //{
                //    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                //if (gvSolicitudPrestamo.RowCount > 0)
                //{
                //    List<ReporteSolicitudPrestamoCabeceraBE> lstReporte = null;
                //    lstReporte = new ReporteSolicitudPrestamoCabeceraBL().Listado(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));

                //    if (lstReporte != null)
                //    {
                //        //Listar el datalle del reporte

                //        List<ReporteSolicitudPrestamoDetalleBE> lstReporteSolicitudPrestamoDetalle = null;
                //        lstReporteSolicitudPrestamoDetalle = new ReporteSolicitudPrestamoDetalleBL().Listado(deDesde.DateTime, deHasta.DateTime, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                //        if (lstReporte.Count > 0)
                //        {
                //            RptVistaReportes objRptAccUsu = new RptVistaReportes();
                //            objRptAccUsu.VerRptSolicitudPrestamo(lstReporte, lstReporteSolicitudPrestamoDetalle, cboMotivo.Text);
                //            objRptAccUsu.ShowDialog();
                //        }
                //        else
                //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //    Cursor = Cursors.Default;
                //}


            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEstadoCuentaPrestamo";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSolicitudPrestamo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpPersonaExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPersonaPrestamo";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPersona.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            if (IdPersona == 0)
            {
                XtraMessageBox.Show("Seleccione una persona", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        private void toolstpPersonaRefrescar_Click(object sender, EventArgs e)
        {
            CargarPersona();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.TipoBusqueda = 0;
                //frm.Title = "Búsqueda de Persona sin Usuario";
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    IdPersona = frm._Be.IdPersona;
                    txtPersona.Text = frm._Be.ApeNom;
                }

                btnConsultar.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdPersona == 0)
            {
                XtraMessageBox.Show("Seleccione un empleado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnBuscar_Click(sender, e);

                //numero o cadena
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    PersonaBE objE_Persona = new PersonaBE();
                    objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(txtNumeroDocumento.Text);

                    //ClienteBE objE_Cliente = null;
                    //objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    //if (objE_Cliente != null)
                    //{

                    //    txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                    //    txtPersona.Text = objE_Cliente.DescCliente;
                        
                    //    Cargar();

                    //}
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

            }
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
            CalcularTotalDocumentos();
        }

        private void CargarBusqueda()
        {
            gcPersona.DataSource = mListaSolicitudPrestamo.Where(obj =>
                                                   obj.DescPersona.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void gvPersona_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvPersona.SelectedRowsCount; i++)
            {
                int row = gvPersona.GetSelectedRows()[i];
                IdPersona = int.Parse(gvPersona.GetRowCellValue(row, "IdPersona").ToString());
                Cargar();
            }

        }

        private void gvPersona_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                for (int i = 0; i < gvPersona.SelectedRowsCount; i++)
                {
                    int row = gvPersona.GetSelectedRows()[i];
                    IdPersona = int.Parse(gvPersona.GetRowCellValue(row, "IdPersona").ToString());

                    Cargar();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //Exception
                //throw;
            }

        }

        private void gvPersona_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new SolicitudPrestamoDetalleBL().ListaPersona(deDesde.DateTime, deHasta.DateTime, IdPersona);
            gcSolicitudPrestamo.DataSource = mLista;

            if (mLista.Count > 0)
            {
                decimal decTotalCargo = 0;
                decimal decTotalAbono = 0;
                decimal decSaldo = 0;

                foreach (var item in mLista)
                {
                    decTotalCargo = decTotalCargo + item.Cargo;
                    decTotalAbono = decTotalAbono + item.Abono;
                }

                txtTotalCargoPrestamo.EditValue = decTotalCargo;
                txtTotalAbonoPrestamo.EditValue = decTotalAbono;
                decSaldo = decTotalCargo - decTotalAbono;
                txtTotalSaldoPrestamo.EditValue = decSaldo;
            }
        }

        private void CargarPersona()
        {
            mListaSolicitudPrestamo = new SolicitudPrestamoBL().ListaPersona(0);
            gcPersona.DataSource = mListaSolicitudPrestamo;

            CalcularTotalDocumentos();
            //if (mLista.Count > 0)
            //{
            //    decimal decTotalCargo = 0;
            //    decimal decTotalAbono = 0;
            //    decimal decSaldo = 0;

            //    foreach (var item in mLista)
            //    {
            //        decTotalCargo = decTotalCargo + item.Cargo;
            //        decTotalAbono = decTotalAbono + item.Abono;
            //    }

            //    txtTotalCargo.EditValue = decTotalCargo;
            //    txtTotalAbono.EditValue = decTotalAbono;
            //    decSaldo = decTotalCargo - decTotalAbono;
            //    txtSaldo.EditValue = decSaldo;
            //}
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decCargo = 0;
                decimal decAbono = 0;
                decimal decSaldo = 0;

                for (int i = 0; i < gvPersona.RowCount; i++)
                {
                    decCargo = decCargo + Convert.ToDecimal(gvPersona.GetRowCellValue(i, (gvPersona.Columns["Cargo"])));
                    decAbono = decAbono + Convert.ToDecimal(gvPersona.GetRowCellValue(i, (gvPersona.Columns["Abono"])));
                    decSaldo = decSaldo + Convert.ToDecimal(gvPersona.GetRowCellValue(i, (gvPersona.Columns["Saldo"])));
                }

                txtTotalCargo.EditValue = decCargo;
                txtTotalAbono.EditValue = decAbono;
                txtTotalSaldo.EditValue = decSaldo;

                lblTotalRegistros.Text = gvPersona.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void gcPersona_Click(object sender, EventArgs e)
        {

        }

        private void gvPersona_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPersona.GetRow(e.RowHandle);

                DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["Estado"]);
                    if (objDocRetiro != null)
                    {
                        string Continuidad = objDocRetiro.ToString();
                        if (Continuidad == "Activo")
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            //gvContrato.Columns["DescSituacion"].AppearanceCell.BackColor = Color.White;
                            //gvContrato.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (Continuidad == "Inactivo")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            //gvContrato.Columns["DescSituacion"].AppearanceCell.BackColor = Color.Red;
                            //gvContrato.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;
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