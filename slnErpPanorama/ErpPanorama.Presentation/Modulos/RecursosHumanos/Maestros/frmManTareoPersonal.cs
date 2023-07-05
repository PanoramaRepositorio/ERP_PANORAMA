using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros;
using ErpPanorama.Presentation.Modulos.Maestros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using DevExpress.Export;
using DevExpress.XtraPrinting;


namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManTareoPersonal : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private int TipoReporte = 1;

        #endregion

        #region "Eventos"

        public frmManTareoPersonal()
        {
            InitializeComponent();
        }

        private void frmManTareoPersonal_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            txtPeriodo.EditValue = Parametros.intPeriodo;
            cboMes.EditValue = DateTime.Now.Month;
            rdgSector.EditValue = 1;

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerJefeRRHH)
            {
                mnuContextual.Visible = true;
                editarpersonatoolStripMenuItem.Visible = true;
                asignardescansotoolStripMenuItem.Visible = true;
                verlistadomingotoolStripMenuItem.Visible = true;
            }
            else
            {
                //mnuContextual.Visible = false;
                editarpersonatoolStripMenuItem.Visible = false;
                asignardescansotoolStripMenuItem.Visible = false;
                verlistadomingotoolStripMenuItem.Visible = false;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            if (TipoReporte == 1)
                Cargar();
            else
                CargarCalculado();
        }

        private void toolstpExcel_Click(object sender, EventArgs e)
        {
            //string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            //string _fileName = "ListadoTareoPersonal_" + cboMes.Text;
            //FolderBrowserDialog f = new FolderBrowserDialog();
            //f.ShowDialog(this);
            //if (f.SelectedPath != "")
            //{
            //    Cursor = Cursors.AppStarting;
            //    gvTareo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
            //    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
            //    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    Cursor = Cursors.Default;
            //}

            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoTareoPersonal_" + cboMes.Text;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gcTareo.DefaultView.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls", new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                if (XtraMessageBox.Show("Desea abrir este archivo", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(f.SelectedPath + @"\" + _fileName + ".xls");
                }

                Cursor = Cursors.Default;
            }



        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            cboMes_SelectedValueChanged(sender, e);

            //int TipoReporte = 1;
            //TipoReporte = Convert.ToInt32(rdgSector.EditValue);
            if (TipoReporte == 1)
                Cargar();
            else
                CargarCalculado();
        }

        private void cboMes_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(cboMes.EditValue))
            {
                case 2:
                    if (Convert.ToInt32(txtPeriodo.EditValue) % 4 == 0 && Convert.ToInt32(txtPeriodo.EditValue) % 100 != 0 || Convert.ToInt32(txtPeriodo.EditValue) % 400 == 0) //Bisiesto
                        ConfigurarGrilla29dias();
                    else
                        ConfigurarGrilla28dias();
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    ConfigurarGrilla30dias();
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    ConfigurarGrilla31dias();
                    break;
            }
        }

        private void gvTareo_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {





        }

        private void rdgSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoReporte = Convert.ToInt32(rdgSector.EditValue);
            btnConsultar_Click(sender, e);
        }

        private void faltainjustificadatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvTareo.RowCount > 0)
            {
                if (TipoReporte == 2)
                {
                    string Valor = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, gvTareo.FocusedColumn.Caption.ToString()).ToString();
                    if (Valor == "F"|| Valor == "")
                    {
                        string Dni = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, "Dni").ToString();

                        string Dia = gvTareo.FocusedColumn.Caption.ToString();
                        PersonaBE objE_Persona = new PersonaBE();
                        objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(Dni);

                        frmAsignarAusencia frm = new frmAsignarAusencia();
                        frm.IdPersona = objE_Persona.IdPersona;
                        frm.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                        frm.Mes = Convert.ToInt32(cboMes.EditValue);
                        frm.Dia = Dia;
                        frm.Dni = Dni;
                        frm.ApeNom = objE_Persona.ApeNom;
                        frm.ShowDialog();

                        int intFoco = gvTareo.FocusedRowHandle;
                        CargarCalculado();
                        gvTareo.FocusedRowHandle = intFoco;
                  
                        //btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        XtraMessageBox.Show("Sólo puede asignar los Días faltados[F].", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Selecionar la opción Calculado para poder asignar la ausencia laboral.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void gvTareo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }
        private void InicializarModificar()
        {
            try
            {
                if (gvTareo.RowCount > 0)
                {
                    if (TipoReporte == 2)
                    {
                        string Valor = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, gvTareo.FocusedColumn.Caption.ToString()).ToString();
                        if (Valor == "F" || Valor == "A")
                        {
                            XtraMessageBox.Show("Este día no tiene detalles. F=faltó ó A=Asistió", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (Valor == "VC")
                        {
                            XtraMessageBox.Show("Vacaciones");
                        }
                        else
                        {
                            string Dni = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, "Dni").ToString();
                            string Dia = gvTareo.FocusedColumn.Caption.ToString();
                            int Mes = Convert.ToInt32(cboMes.EditValue);
                            int Periodo = Convert.ToInt32(txtPeriodo.EditValue);

                            DateTime Fecha = Convert.ToDateTime(Dia + "/" + Mes + "/" + Periodo);

                            AusenciaBE objE_Ausencia = null;
                            objE_Ausencia = new AusenciaBL().SeleccionaFechaDni(Fecha, Dni);

                            if (objE_Ausencia != null)
                            {
                                frmRegAusenciaEdit objManAusenciaEdit = new frmRegAusenciaEdit();
                                objManAusenciaEdit.pOperacion = frmRegAusenciaEdit.Operacion.Consultar;
                                objManAusenciaEdit.IdAusencia = objE_Ausencia.IdAusencia;
                                objManAusenciaEdit.StartPosition = FormStartPosition.CenterParent;
                                objManAusenciaEdit.ShowDialog();

                                //if (objManAusenciaEdit.ShowDialog() == DialogResult.OK)
                                //{
                                //    btnConsultar_Click(sender, e);
                                //}

                            }
                            else
                            {
                                XtraMessageBox.Show("No existe historial que justifique esta inasistencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        //Vacaciones doble click agregar
                    }
                    else
                    {
                        XtraMessageBox.Show("Selecionar la opción Calculado para poder asignar la ausencia laboral.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void gvTareo_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvTareo.RowCount.ToString() + " Registros";
        }

        private void btnVerLeyenda_Click(object sender, EventArgs e)
        {
            frmConAusenciaLeyenda frm = new frmConAusenciaLeyenda();
            frm.ShowDialog();
        }


        private void ceColorSeleccion_ColorChanged(object sender, EventArgs e)
        {
            gvTareo.Appearance.FocusedRow.BackColor = ceColorSeleccion.Color;
        }

        private void chkVerDomingo_CheckedChanged(object sender, EventArgs e)
        {
            btnConsultar_Click(sender, e);
        }

        private void gvTareo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;

            if (e.Column.FieldName == "ApeNom")
            {
                GridView View = sender as GridView;
                object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["Tipo"]);
                if (objDocRetiro != null)
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "Tipo").ToString();

                    if (Valor1 == "C")
                        e.Appearance.ForeColor = Color.Red;
                    else if (Valor1 == "N")
                        //e.Appearance.ForeColor = Color.Yellow;
                        e.Appearance.BackColor = Color.Yellow;
                    else
                        e.Appearance.ForeColor = Color.Black;
                }
            }

            if (TipoReporte == 1) //Standar
            {
                #region "Estandar"

                if (e.Column.FieldName == "1")
                {

                    String Valor1 = view.GetRowCellValue(e.RowHandle, "1").ToString();

                    if (Valor1 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "2")
                {

                    String Valor2 = view.GetRowCellValue(e.RowHandle, "2").ToString();

                    if (Valor2 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "3")
                {

                    String Valor3 = view.GetRowCellValue(e.RowHandle, "3").ToString();

                    if (Valor3 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "4")
                {

                    String Valor4 = view.GetRowCellValue(e.RowHandle, "4").ToString();

                    if (Valor4 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "5")
                {

                    String Valor5 = view.GetRowCellValue(e.RowHandle, "5").ToString();

                    if (Valor5 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "6")
                {

                    String Valor6 = view.GetRowCellValue(e.RowHandle, "6").ToString();

                    if (Valor6 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "7")
                {

                    String Valor7 = view.GetRowCellValue(e.RowHandle, "7").ToString();

                    if (Valor7 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "8")
                {

                    String Valor8 = view.GetRowCellValue(e.RowHandle, "8").ToString();

                    if (Valor8 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "9")
                {

                    String Valor9 = view.GetRowCellValue(e.RowHandle, "9").ToString();

                    if (Valor9 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "10")
                {

                    String Valor10 = view.GetRowCellValue(e.RowHandle, "10").ToString();

                    if (Valor10 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "11")
                {

                    String Valor11 = view.GetRowCellValue(e.RowHandle, "11").ToString();

                    if (Valor11 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "12")
                {

                    String Valor12 = view.GetRowCellValue(e.RowHandle, "12").ToString();

                    if (Valor12 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "13")
                {

                    String Valor13 = view.GetRowCellValue(e.RowHandle, "13").ToString();

                    if (Valor13 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "14")
                {

                    String Valor14 = view.GetRowCellValue(e.RowHandle, "14").ToString();

                    if (Valor14 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "15")
                {

                    String Valor15 = view.GetRowCellValue(e.RowHandle, "15").ToString();

                    if (Valor15 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "16")
                {

                    String Valor16 = view.GetRowCellValue(e.RowHandle, "16").ToString();

                    if (Valor16 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "17")
                {

                    String Valor17 = view.GetRowCellValue(e.RowHandle, "17").ToString();

                    if (Valor17 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "18")
                {

                    String Valor18 = view.GetRowCellValue(e.RowHandle, "18").ToString();

                    if (Valor18 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "19")
                {

                    String Valor19 = view.GetRowCellValue(e.RowHandle, "19").ToString();

                    if (Valor19 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "20")
                {

                    String Valor20 = view.GetRowCellValue(e.RowHandle, "20").ToString();

                    if (Valor20 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "21")
                {

                    String Valor21 = view.GetRowCellValue(e.RowHandle, "21").ToString();

                    if (Valor21 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "22")
                {

                    String Valor22 = view.GetRowCellValue(e.RowHandle, "22").ToString();

                    if (Valor22 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "23")
                {

                    String Valor23 = view.GetRowCellValue(e.RowHandle, "23").ToString();

                    if (Valor23 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "24")
                {

                    String Valor24 = view.GetRowCellValue(e.RowHandle, "24").ToString();

                    if (Valor24 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "25")
                {

                    String Valor25 = view.GetRowCellValue(e.RowHandle, "25").ToString();

                    if (Valor25 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "26")
                {

                    String Valor26 = view.GetRowCellValue(e.RowHandle, "26").ToString();

                    if (Valor26 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "27")
                {

                    String Valor27 = view.GetRowCellValue(e.RowHandle, "27").ToString();

                    if (Valor27 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "28")
                {

                    String Valor28 = view.GetRowCellValue(e.RowHandle, "28").ToString();

                    if (Valor28 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "29")
                {

                    String Valor29 = view.GetRowCellValue(e.RowHandle, "29").ToString();

                    if (Valor29 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "30")
                {

                    String Valor30 = view.GetRowCellValue(e.RowHandle, "30").ToString();

                    if (Valor30 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }

                if (e.Column.FieldName == "31")
                {

                    String Valor31 = view.GetRowCellValue(e.RowHandle, "31").ToString();

                    if (Valor31 == "F")
                        e.Appearance.ForeColor = Color.Red;
                    else
                        e.Appearance.ForeColor = Color.Blue;
                }
                #endregion
            }
            else
            {
                #region "Calculado"
                //if (e.Column.FieldName == "1")
                //{
                //    String Valor1 = view.GetRowCellValue(e.RowHandle, "1").ToString();
                //    if (Valor1 == "F" || Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                //        e.Appearance.BackColor = Color.Red;
                //    else
                //        e.Appearance.ForeColor = Color.Blue;
                //    if (chkVerDomingo.Checked)
                //    {
                //        DateTime FechaTb = Convert.ToDateTime("1/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                //        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                //    }
                //}
                if (e.Column.FieldName == "1")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "1").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("1/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "2")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "2").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("2/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "3")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "3").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("3/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "4")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "4").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("4/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "5")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "5").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("5/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "6")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "6").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("6/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "7")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "7").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("7/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "8")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "8").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("8/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "9")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "9").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("9/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "10")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "10").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("10/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "11")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "11").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("11/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "12")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "12").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("12/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "13")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "13").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("13/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "14")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "14").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("14/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "15")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "15").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("15/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "16")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "16").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("16/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "17")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "17").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("17/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "18")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "18").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("18/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "19")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "19").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("19/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "20")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "20").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("20/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "21")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "21").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("21/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "22")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "22").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("22/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "23")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "23").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("23/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "24")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "24").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("24/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "25")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "25").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("25/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "26")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "26").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("26/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "27")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "27").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("27/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "28")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "28").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("28/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "29")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "29").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("29/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "30")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "30").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("30/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                if (e.Column.FieldName == "31")
                {
                    String Valor1 = view.GetRowCellValue(e.RowHandle, "31").ToString();
                    if (Valor1 == "CS" || Valor1 == "FI" || Valor1 == "LC" || Valor1 == "DA" || Valor1 == "DR")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (Valor1 == "F")
                    {
                        e.Appearance.BackColor = Color.YellowGreen;
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    if (chkVerDomingo.Checked)
                    {
                        DateTime FechaTb = Convert.ToDateTime("31/" + Convert.ToInt32(cboMes.EditValue) + "/" + txtPeriodo.Text);
                        if (Convert.ToInt32(FechaTb.DayOfWeek) == 0) e.Appearance.BackColor = Color.Silver;
                    }
                }
                #endregion
            }
  

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.AppStarting;
            int TipoReporte = 1;
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad)
                TipoReporte = 0;

            DataTable dt = null;
            dt = new TareoPersonalBL().ObtenerListaTareo(Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Parametros.intPersonaId, TipoReporte);
            gcTareo.DataSource = dt;
            Cursor = Cursors.Default;
            lblTotalRegistros.Text = gvTareo.RowCount.ToString() + " Registros";
        }

        private void CargarCalculado()
        {
            Cursor = Cursors.AppStarting;
            int TipoReporte = 1;
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerCoordinadorContabilidad)
                TipoReporte = 0;

            DataTable dt = null;
            dt = new TareoPersonalBL().ObtenerListaTareoCalculado(Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Parametros.intPersonaId, TipoReporte);
            gcTareo.DataSource = dt;
            Cursor = Cursors.Default;
            lblTotalRegistros.Text = gvTareo.RowCount.ToString() + " Registros";
        }

        private void ConfigurarGrilla31dias()
        {
            gcTareo.ForceInitialize();
            gvTareo.PopulateColumns();

            gvTareo.Columns.Clear();
            gvTareo.SelectAll();
            gvTareo.DeleteSelectedRows();

            gvTareo.OptionsBehavior.Editable = true;
            gvTareo.OptionsCustomization.AllowColumnMoving = true;
            gvTareo.OptionsCustomization.AllowGroup = false;
            gvTareo.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvTareo.OptionsSelection.MultiSelect = true;
            gvTareo.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvTareo.OptionsView.ShowGroupPanel = false;
            gvTareo.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            DevExpress.XtraGrid.Columns.GridColumn gcTipo= new DevExpress.XtraGrid.Columns.GridColumn();
            //DevExpress.XtraGrid.Columns.GridColumn gcDni = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcApeNom = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc4 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc5 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc6 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc7 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc8 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc9 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc10 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc11 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc12 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc13 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc14 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc15 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc16 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc17 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc18 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc19 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc20 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc21 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc22 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc23 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc24 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc25 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc26 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc27 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc28 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc29 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc30 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc31 = new DevExpress.XtraGrid.Columns.GridColumn();

            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescArea = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescanso = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcFlagApoyo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalF = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalFI = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalDM = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalLC = new DevExpress.XtraGrid.Columns.GridColumn();

            gcTipo.Caption = "Tipo";
            gcTipo.FieldName = "Tipo";
            gcTipo.Name = "gcTipo";
            gcTipo.OptionsColumn.AllowEdit = false;
            gcTipo.Visible = false;
            gcTipo.VisibleIndex = -1;
            gcTipo.Width = 250;

            gcApeNom.Caption = "Apellidos y Nombres";
            gcApeNom.FieldName = "ApeNom";
            gcApeNom.Name = "gcApeNom";
            gcApeNom.OptionsColumn.AllowEdit = true;
            gcApeNom.Visible = true;
            gcApeNom.VisibleIndex = 0;
            gcApeNom.Width = 250;

            gc1.Caption = "1";
            gc1.FieldName = "1";
            gc1.Name = "gc1";
            gc1.OptionsColumn.AllowEdit = false;
            gc1.Visible = true;
            gc1.VisibleIndex = 1;
            gc1.Width = 20;

            gc2.Caption = "2";
            gc2.FieldName = "2";
            gc2.Name = "gc2";
            gc2.OptionsColumn.AllowEdit = false;
            gc2.Visible = true;
            gc2.VisibleIndex = 2;
            gc2.Width = 20;

            gc3.Caption = "3";
            gc3.FieldName = "3";
            gc3.Name = "gc3";
            gc3.OptionsColumn.AllowEdit = false;
            gc3.Visible = true;
            gc3.VisibleIndex = 3;
            gc3.Width = 20;

            gc4.Caption = "4";
            gc4.FieldName = "4";
            gc4.Name = "gc4";
            gc4.OptionsColumn.AllowEdit = false;
            gc4.Visible = true;
            gc4.VisibleIndex = 4;
            gc4.Width = 20;

            gc5.Caption = "5";
            gc5.FieldName = "5";
            gc5.Name = "gc5";
            gc5.OptionsColumn.AllowEdit = false;
            gc5.Visible = true;
            gc5.VisibleIndex = 5;
            gc5.Width = 20;

            gc6.Caption = "6";
            gc6.FieldName = "6";
            gc6.Name = "gc6";
            gc6.OptionsColumn.AllowEdit = false;
            gc6.Visible = true;
            gc6.VisibleIndex = 6;
            gc6.Width = 20;

            gc7.Caption = "7";
            gc7.FieldName = "7";
            gc7.Name = "gc7";
            gc7.OptionsColumn.AllowEdit = false;
            gc7.Visible = true;
            gc7.VisibleIndex = 7;
            gc7.Width = 20;

            gc8.Caption = "8";
            gc8.FieldName = "8";
            gc8.Name = "gc8";
            gc8.OptionsColumn.AllowEdit = false;
            gc8.Visible = true;
            gc8.VisibleIndex = 8;
            gc8.Width = 20;

            gc9.Caption = "9";
            gc9.FieldName = "9";
            gc9.Name = "gc9";
            gc9.OptionsColumn.AllowEdit = false;
            gc9.Visible = true;
            gc9.VisibleIndex = 9;
            gc9.Width = 20;

            gc10.Caption = "10";
            gc10.FieldName = "10";
            gc10.Name = "gc10";
            gc10.OptionsColumn.AllowEdit = false;
            gc10.Visible = true;
            gc10.VisibleIndex = 10;
            gc10.Width = 25;

            gc11.Caption = "11";
            gc11.FieldName = "11";
            gc11.Name = "gc11";
            gc11.OptionsColumn.AllowEdit = false;
            gc11.Visible = true;
            gc11.VisibleIndex = 11;
            gc11.Width = 25;

            gc12.Caption = "12";
            gc12.FieldName = "12";
            gc12.Name = "gc12";
            gc12.OptionsColumn.AllowEdit = false;
            gc12.Visible = true;
            gc12.VisibleIndex = 12;
            gc12.Width = 25;

            gc13.Caption = "13";
            gc13.FieldName = "13";
            gc13.Name = "gc13";
            gc13.OptionsColumn.AllowEdit = false;
            gc13.Visible = true;
            gc13.VisibleIndex = 13;
            gc13.Width = 25;

            gc14.Caption = "14";
            gc14.FieldName = "14";
            gc14.Name = "gc14";
            gc14.OptionsColumn.AllowEdit = false;
            gc14.Visible = true;
            gc14.VisibleIndex = 14;
            gc14.Width = 25;

            gc15.Caption = "15";
            gc15.FieldName = "15";
            gc15.Name = "gc15";
            gc15.OptionsColumn.AllowEdit = false;
            gc15.Visible = true;
            gc15.VisibleIndex = 15;
            gc15.Width = 25;

            gc16.Caption = "16";
            gc16.FieldName = "16";
            gc16.Name = "gc16";
            gc16.OptionsColumn.AllowEdit = false;
            gc16.Visible = true;
            gc16.VisibleIndex = 16;
            gc16.Width = 25;

            gc17.Caption = "17";
            gc17.FieldName = "17";
            gc17.Name = "gc17";
            gc17.OptionsColumn.AllowEdit = false;
            gc17.Visible = true;
            gc17.VisibleIndex = 17;
            gc17.Width = 25;

            gc18.Caption = "18";
            gc18.FieldName = "18";
            gc18.Name = "gc18";
            gc18.OptionsColumn.AllowEdit = false;
            gc18.Visible = true;
            gc18.VisibleIndex = 18;
            gc18.Width = 25;

            gc19.Caption = "19";
            gc19.FieldName = "19";
            gc19.Name = "gc19";
            gc19.OptionsColumn.AllowEdit = false;
            gc19.Visible = true;
            gc19.VisibleIndex = 19;
            gc19.Width = 25;

            gc20.Caption = "20";
            gc20.FieldName = "20";
            gc20.Name = "gc20";
            gc20.OptionsColumn.AllowEdit = false;
            gc20.Visible = true;
            gc20.VisibleIndex = 20;
            gc20.Width = 25;

            gc21.Caption = "21";
            gc21.FieldName = "21";
            gc21.Name = "gc21";
            gc21.OptionsColumn.AllowEdit = false;
            gc21.Visible = true;
            gc21.VisibleIndex = 21;
            gc21.Width = 25;

            gc22.Caption = "22";
            gc22.FieldName = "22";
            gc22.Name = "gc22";
            gc22.OptionsColumn.AllowEdit = false;
            gc22.Visible = true;
            gc22.VisibleIndex = 22;
            gc22.Width = 25;

            gc23.Caption = "23";
            gc23.FieldName = "23";
            gc23.Name = "gc23";
            gc23.OptionsColumn.AllowEdit = false;
            gc23.Visible = true;
            gc23.VisibleIndex = 23;
            gc23.Width = 25;

            gc24.Caption = "24";
            gc24.FieldName = "24";
            gc24.Name = "gc24";
            gc24.OptionsColumn.AllowEdit = false;
            gc24.Visible = true;
            gc24.VisibleIndex = 24;
            gc24.Width = 25;

            gc25.Caption = "25";
            gc25.FieldName = "25";
            gc25.Name = "gc25";
            gc25.OptionsColumn.AllowEdit = false;
            gc25.Visible = true;
            gc25.VisibleIndex = 25;
            gc25.Width = 25;

            gc26.Caption = "26";
            gc26.FieldName = "26";
            gc26.Name = "gc26";
            gc26.OptionsColumn.AllowEdit = false;
            gc26.Visible = true;
            gc26.VisibleIndex = 26;
            gc26.Width = 25;

            gc27.Caption = "27";
            gc27.FieldName = "27";
            gc27.Name = "gc27";
            gc27.OptionsColumn.AllowEdit = false;
            gc27.Visible = true;
            gc27.VisibleIndex = 27;
            gc27.Width = 25;

            gc28.Caption = "28";
            gc28.FieldName = "28";
            gc28.Name = "gc28";
            gc28.OptionsColumn.AllowEdit = false;
            gc28.Visible = true;
            gc28.VisibleIndex = 28;
            gc28.Width = 25;

            gc29.Caption = "29";
            gc29.FieldName = "29";
            gc29.Name = "gc29";
            gc29.OptionsColumn.AllowEdit = false;
            gc29.Visible = true;
            gc29.VisibleIndex = 29;
            gc29.Width = 25;

            gc30.Caption = "30";
            gc30.FieldName = "30";
            gc30.Name = "gc30";
            gc30.OptionsColumn.AllowEdit = false;
            gc30.Visible = true;
            gc30.VisibleIndex = 30;
            gc30.Width = 25;

            gc31.Caption = "31";
            gc31.FieldName = "31";
            gc31.Name = "gc31";
            gc31.OptionsColumn.AllowEdit = false;
            gc31.Visible = true;
            gc31.VisibleIndex = 31;
            gc31.Width = 25;

            gcFlagApoyo.Caption = "Apoyo";
            gcFlagApoyo.FieldName = "FlagApoyo";
            gcFlagApoyo.Name = "gcFlagApoyo";
            gcFlagApoyo.OptionsColumn.AllowEdit = false;
            gcFlagApoyo.Visible = true;
            gcFlagApoyo.VisibleIndex = 32;
            gcFlagApoyo.Width = 20;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 33;
            gcDescTienda.Width = 100;

            gcDescArea.Caption = "Area";
            gcDescArea.FieldName = "DescArea";
            gcDescArea.Name = "gcDescArea";
            gcDescArea.OptionsColumn.AllowEdit = false;
            gcDescArea.Visible = true;
            gcDescArea.VisibleIndex = 34;
            gcDescArea.Width = 100;

            gcDescCargo.Caption = "Cargo";
            gcDescCargo.FieldName = "DescCargo";
            gcDescCargo.Name = "gcDescCargo";
            gcDescCargo.OptionsColumn.AllowEdit = false;
            gcDescCargo.Visible = true;
            gcDescCargo.VisibleIndex = 35;
            gcDescCargo.Width = 250;

            gcDescanso.Caption = "Descanso";
            gcDescanso.FieldName = "Descanso";
            gcDescanso.Name = "gcDescanso";
            gcDescanso.OptionsColumn.AllowEdit = false;
            gcDescanso.Visible = true;
            gcDescanso.VisibleIndex = 36;
            gcDescanso.Width = 60;

            gcTotalF.Caption = "Total F";
            gcTotalF.FieldName = "TotalF";
            gcTotalF.Name = "gcTotalF";
            gcTotalF.OptionsColumn.AllowEdit = false;
            gcTotalF.Visible = true;
            gcTotalF.VisibleIndex = 37;
            gcTotalF.Width = 60;

            gcTotalFI.Caption = "Total FI";
            gcTotalFI.FieldName = "TotalFI";
            gcTotalFI.Name = "gcTotalFI";
            gcTotalFI.OptionsColumn.AllowEdit = false;
            gcTotalFI.Visible = true;
            gcTotalFI.VisibleIndex = 38;
            gcTotalFI.Width = 60;

            gcTotalDM.Caption = "Total DM";
            gcTotalDM.FieldName = "TotalDM";
            gcTotalDM.Name = "gcTotalDM";
            gcTotalDM.OptionsColumn.AllowEdit = false;
            gcTotalDM.Visible = true;
            gcTotalDM.VisibleIndex = 39;
            gcTotalDM.Width = 60;

            gcTotalLC.Caption = "Total LC";
            gcTotalLC.FieldName = "TotalLC";
            gcTotalLC.Name = "gcTotalLC";
            gcTotalLC.OptionsColumn.AllowEdit = false;
            gcTotalLC.Visible = true;
            gcTotalLC.VisibleIndex = 40;
            gcTotalLC.Width = 60;

            gvTareo.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                 gcTipo,
                 gcApeNom,
                 gc1,
                 gc2,
                 gc3,
                 gc4,
                 gc5,
                 gc6,
                 gc7,
                 gc8,
                 gc9,
                 gc10,
                 gc11,
                 gc12,
                 gc13,
                 gc14,
                 gc15,
                 gc16,
                 gc17,
                 gc18,
                 gc19,
                 gc20,
                 gc21,
                 gc22,
                 gc23,
                 gc24,
                 gc25,
                 gc26,
                 gc27,
                 gc28,
                 gc29,
                 gc30,
                 gc31,
                 gcFlagApoyo,
                 gcDescTienda,
                 gcDescArea,
                 gcDescCargo,
                 gcDescanso,
                 gcTotalF,
                 gcTotalFI,
                 gcTotalDM,
                 gcTotalLC
                });
        }

        private void ConfigurarGrilla30dias()
        {
            gcTareo.ForceInitialize();
            gvTareo.PopulateColumns();

            gvTareo.Columns.Clear();
            gvTareo.SelectAll();
            gvTareo.DeleteSelectedRows();

            gvTareo.OptionsBehavior.Editable = true;
            gvTareo.OptionsCustomization.AllowColumnMoving = true;
            gvTareo.OptionsCustomization.AllowGroup = false;
            gvTareo.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvTareo.OptionsSelection.MultiSelect = true;
            gvTareo.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvTareo.OptionsView.ShowGroupPanel = false;
            gvTareo.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            //DevExpress.XtraGrid.Columns.GridColumn gcDni = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcApeNom = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc4 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc5 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc6 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc7 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc8 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc9 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc10 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc11 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc12 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc13 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc14 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc15 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc16 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc17 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc18 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc19 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc20 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc21 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc22 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc23 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc24 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc25 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc26 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc27 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc28 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc29 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc30 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescArea = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescanso = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcFlagApoyo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalF = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalFI = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalDM = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalLC = new DevExpress.XtraGrid.Columns.GridColumn();


            gcTipo.Caption = "Tipo";
            gcTipo.FieldName = "Tipo";
            gcTipo.Name = "gcTipo";
            gcTipo.OptionsColumn.AllowEdit = false;
            gcTipo.Visible = false;
            gcTipo.VisibleIndex = -1;
            gcTipo.Width = 250;

            gcApeNom.Caption = "Apellidos y Nombres";
            gcApeNom.FieldName = "ApeNom";
            gcApeNom.Name = "gcApeNom";
            gcApeNom.OptionsColumn.AllowEdit = true;
            gcApeNom.Visible = true;
            gcApeNom.VisibleIndex = 0;
            gcApeNom.Width = 250;

            gc1.Caption = "1";
            gc1.FieldName = "1";
            gc1.Name = "gc1";
            gc1.OptionsColumn.AllowEdit = false;
            gc1.Visible = true;
            gc1.VisibleIndex = 1;
            gc1.Width = 20;

            gc2.Caption = "2";
            gc2.FieldName = "2";
            gc2.Name = "gc2";
            gc2.OptionsColumn.AllowEdit = false;
            gc2.Visible = true;
            gc2.VisibleIndex = 2;
            gc2.Width = 20;

            gc3.Caption = "3";
            gc3.FieldName = "3";
            gc3.Name = "gc3";
            gc3.OptionsColumn.AllowEdit = false;
            gc3.Visible = true;
            gc3.VisibleIndex = 3;
            gc3.Width = 20;

            gc4.Caption = "4";
            gc4.FieldName = "4";
            gc4.Name = "gc4";
            gc4.OptionsColumn.AllowEdit = false;
            gc4.Visible = true;
            gc4.VisibleIndex = 4;
            gc4.Width = 20;

            gc5.Caption = "5";
            gc5.FieldName = "5";
            gc5.Name = "gc5";
            gc5.OptionsColumn.AllowEdit = false;
            gc5.Visible = true;
            gc5.VisibleIndex = 5;
            gc5.Width = 20;

            gc6.Caption = "6";
            gc6.FieldName = "6";
            gc6.Name = "gc6";
            gc6.OptionsColumn.AllowEdit = false;
            gc6.Visible = true;
            gc6.VisibleIndex = 6;
            gc6.Width = 20;

            gc7.Caption = "7";
            gc7.FieldName = "7";
            gc7.Name = "gc7";
            gc7.OptionsColumn.AllowEdit = false;
            gc7.Visible = true;
            gc7.VisibleIndex = 7;
            gc7.Width = 20;

            gc8.Caption = "8";
            gc8.FieldName = "8";
            gc8.Name = "gc8";
            gc8.OptionsColumn.AllowEdit = false;
            gc8.Visible = true;
            gc8.VisibleIndex = 8;
            gc8.Width = 20;

            gc9.Caption = "9";
            gc9.FieldName = "9";
            gc9.Name = "gc9";
            gc9.OptionsColumn.AllowEdit = false;
            gc9.Visible = true;
            gc9.VisibleIndex = 9;
            gc9.Width = 20;

            gc10.Caption = "10";
            gc10.FieldName = "10";
            gc10.Name = "gc10";
            gc10.OptionsColumn.AllowEdit = false;
            gc10.Visible = true;
            gc10.VisibleIndex = 10;
            gc10.Width = 25;

            gc11.Caption = "11";
            gc11.FieldName = "11";
            gc11.Name = "gc11";
            gc11.OptionsColumn.AllowEdit = false;
            gc11.Visible = true;
            gc11.VisibleIndex = 11;
            gc11.Width = 25;

            gc12.Caption = "12";
            gc12.FieldName = "12";
            gc12.Name = "gc12";
            gc12.OptionsColumn.AllowEdit = false;
            gc12.Visible = true;
            gc12.VisibleIndex = 12;
            gc12.Width = 25;

            gc13.Caption = "13";
            gc13.FieldName = "13";
            gc13.Name = "gc13";
            gc13.OptionsColumn.AllowEdit = false;
            gc13.Visible = true;
            gc13.VisibleIndex = 13;
            gc13.Width = 25;

            gc14.Caption = "14";
            gc14.FieldName = "14";
            gc14.Name = "gc14";
            gc14.OptionsColumn.AllowEdit = false;
            gc14.Visible = true;
            gc14.VisibleIndex = 14;
            gc14.Width = 25;

            gc15.Caption = "15";
            gc15.FieldName = "15";
            gc15.Name = "gc15";
            gc15.OptionsColumn.AllowEdit = false;
            gc15.Visible = true;
            gc15.VisibleIndex = 15;
            gc15.Width = 25;

            gc16.Caption = "16";
            gc16.FieldName = "16";
            gc16.Name = "gc16";
            gc16.OptionsColumn.AllowEdit = false;
            gc16.Visible = true;
            gc16.VisibleIndex = 16;
            gc16.Width = 25;

            gc17.Caption = "17";
            gc17.FieldName = "17";
            gc17.Name = "gc17";
            gc17.OptionsColumn.AllowEdit = false;
            gc17.Visible = true;
            gc17.VisibleIndex = 17;
            gc17.Width = 25;

            gc18.Caption = "18";
            gc18.FieldName = "18";
            gc18.Name = "gc18";
            gc18.OptionsColumn.AllowEdit = false;
            gc18.Visible = true;
            gc18.VisibleIndex = 18;
            gc18.Width = 25;

            gc19.Caption = "19";
            gc19.FieldName = "19";
            gc19.Name = "gc19";
            gc19.OptionsColumn.AllowEdit = false;
            gc19.Visible = true;
            gc19.VisibleIndex = 19;
            gc19.Width = 25;

            gc20.Caption = "20";
            gc20.FieldName = "20";
            gc20.Name = "gc20";
            gc20.OptionsColumn.AllowEdit = false;
            gc20.Visible = true;
            gc20.VisibleIndex = 20;
            gc20.Width = 25;

            gc21.Caption = "21";
            gc21.FieldName = "21";
            gc21.Name = "gc21";
            gc21.OptionsColumn.AllowEdit = false;
            gc21.Visible = true;
            gc21.VisibleIndex = 21;
            gc21.Width = 25;

            gc22.Caption = "22";
            gc22.FieldName = "22";
            gc22.Name = "gc22";
            gc22.OptionsColumn.AllowEdit = false;
            gc22.Visible = true;
            gc22.VisibleIndex = 22;
            gc22.Width = 25;

            gc23.Caption = "23";
            gc23.FieldName = "23";
            gc23.Name = "gc23";
            gc23.OptionsColumn.AllowEdit = false;
            gc23.Visible = true;
            gc23.VisibleIndex = 23;
            gc23.Width = 25;

            gc24.Caption = "24";
            gc24.FieldName = "24";
            gc24.Name = "gc24";
            gc24.OptionsColumn.AllowEdit = false;
            gc24.Visible = true;
            gc24.VisibleIndex = 24;
            gc24.Width = 25;

            gc25.Caption = "25";
            gc25.FieldName = "25";
            gc25.Name = "gc25";
            gc25.OptionsColumn.AllowEdit = false;
            gc25.Visible = true;
            gc25.VisibleIndex = 25;
            gc25.Width = 25;

            gc26.Caption = "26";
            gc26.FieldName = "26";
            gc26.Name = "gc26";
            gc26.OptionsColumn.AllowEdit = false;
            gc26.Visible = true;
            gc26.VisibleIndex = 26;
            gc26.Width = 25;

            gc27.Caption = "27";
            gc27.FieldName = "27";
            gc27.Name = "gc27";
            gc27.OptionsColumn.AllowEdit = false;
            gc27.Visible = true;
            gc27.VisibleIndex = 27;
            gc27.Width = 25;

            gc28.Caption = "28";
            gc28.FieldName = "28";
            gc28.Name = "gc28";
            gc28.OptionsColumn.AllowEdit = false;
            gc28.Visible = true;
            gc28.VisibleIndex = 28;
            gc28.Width = 25;

            gc29.Caption = "29";
            gc29.FieldName = "29";
            gc29.Name = "gc29";
            gc29.OptionsColumn.AllowEdit = false;
            gc29.Visible = true;
            gc29.VisibleIndex = 29;
            gc29.Width = 25;

            gc30.Caption = "30";
            gc30.FieldName = "30";
            gc30.Name = "gc30";
            gc30.OptionsColumn.AllowEdit = false;
            gc30.Visible = true;
            gc30.VisibleIndex = 30;
            gc30.Width = 25;

            gcFlagApoyo.Caption = "Apoyo";
            gcFlagApoyo.FieldName = "FlagApoyo";
            gcFlagApoyo.Name = "gcFlagApoyo";
            gcFlagApoyo.OptionsColumn.AllowEdit = false;
            gcFlagApoyo.Visible = true;
            gcFlagApoyo.VisibleIndex = 31;
            gcFlagApoyo.Width = 20;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 32;
            gcDescTienda.Width = 100;

            gcDescArea.Caption = "Area";
            gcDescArea.FieldName = "DescArea";
            gcDescArea.Name = "gcDescArea";
            gcDescArea.OptionsColumn.AllowEdit = false;
            gcDescArea.Visible = true;
            gcDescArea.VisibleIndex = 33;
            gcDescArea.Width = 100;

            gcDescCargo.Caption = "Cargo";
            gcDescCargo.FieldName = "DescCargo";
            gcDescCargo.Name = "gcDescCargo";
            gcDescCargo.OptionsColumn.AllowEdit = false;
            gcDescCargo.Visible = true;
            gcDescCargo.VisibleIndex = 34;
            gcDescCargo.Width = 250;

            gcDescanso.Caption = "Descanso";
            gcDescanso.FieldName = "Descanso";
            gcDescanso.Name = "gcDescanso";
            gcDescanso.OptionsColumn.AllowEdit = false;
            gcDescanso.Visible = true;
            gcDescanso.VisibleIndex = 35;
            gcDescanso.Width = 100;


            gcTotalF.Caption = "Total F";
            gcTotalF.FieldName = "TotalF";
            gcTotalF.Name = "gcTotalF";
            gcTotalF.OptionsColumn.AllowEdit = false;
            gcTotalF.Visible = true;
            gcTotalF.VisibleIndex = 36;
            gcTotalF.Width = 60;

            gcTotalFI.Caption = "Total FI";
            gcTotalFI.FieldName = "TotalFI";
            gcTotalFI.Name = "gcTotalFI";
            gcTotalFI.OptionsColumn.AllowEdit = false;
            gcTotalFI.Visible = true;
            gcTotalFI.VisibleIndex = 37;
            gcTotalFI.Width = 60;

            gcTotalDM.Caption = "Total DM";
            gcTotalDM.FieldName = "TotalDM";
            gcTotalDM.Name = "gcTotalDM";
            gcTotalDM.OptionsColumn.AllowEdit = false;
            gcTotalDM.Visible = true;
            gcTotalDM.VisibleIndex = 38;
            gcTotalDM.Width = 60;

            gcTotalLC.Caption = "Total LC";
            gcTotalLC.FieldName = "TotalLC";
            gcTotalLC.Name = "gcTotalLC";
            gcTotalLC.OptionsColumn.AllowEdit = false;
            gcTotalLC.Visible = true;
            gcTotalLC.VisibleIndex = 39;
            gcTotalLC.Width = 60;

            gvTareo.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gcTipo,
                 gcApeNom,
                 gc1,
                 gc2,
                 gc3,
                 gc4,
                 gc5,
                 gc6,
                 gc7,
                 gc8,
                 gc9,
                 gc10,
                 gc11,
                 gc12,
                 gc13,
                 gc14,
                 gc15,
                 gc16,
                 gc17,
                 gc18,
                 gc19,
                 gc20,
                 gc21,
                 gc22,
                 gc23,
                 gc24,
                 gc25,
                 gc26,
                 gc27,
                 gc28,
                 gc29,
                 gc30,
                 gcFlagApoyo,
                 gcDescTienda,
                 gcDescArea,
                 gcDescCargo,
                 gcDescanso,
                 gcTotalF,
                 gcTotalFI,
                 gcTotalDM,
                 gcTotalLC
                });
        }

        private void ConfigurarGrilla28dias()
        {
            gcTareo.ForceInitialize();
            gvTareo.PopulateColumns();

            gvTareo.Columns.Clear();
            gvTareo.SelectAll();
            gvTareo.DeleteSelectedRows();

               
            gvTareo.OptionsBehavior.Editable = true;
            gvTareo.OptionsCustomization.AllowColumnMoving = true;
            gvTareo.OptionsCustomization.AllowGroup = false;
            gvTareo.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvTareo.OptionsSelection.MultiSelect = true;
            gvTareo.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvTareo.OptionsView.ShowGroupPanel = false;
            gvTareo.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            //DevExpress.XtraGrid.Columns.GridColumn gcDni = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcApeNom = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc4 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc5 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc6 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc7 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc8 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc9 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc10 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc11 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc12 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc13 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc14 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc15 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc16 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc17 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc18 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc19 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc20 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc21 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc22 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc23 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc24 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc25 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc26 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc27 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc28 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescArea = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescanso = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcFlagApoyo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalF = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalFI = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalDM = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalLC = new DevExpress.XtraGrid.Columns.GridColumn();



            gcTipo.Caption = "Tipo";
            gcTipo.FieldName = "Tipo";
            gcTipo.Name = "gcTipo";
            gcTipo.OptionsColumn.AllowEdit = false;
            gcTipo.Visible = false;
            gcTipo.VisibleIndex = -1;
            gcTipo.Width = 250;

            gcApeNom.Caption = "Apellidos y Nombres";
            gcApeNom.FieldName = "ApeNom";
            gcApeNom.Name = "gcApeNom";
            gcApeNom.OptionsColumn.AllowEdit = true;
            gcApeNom.Visible = true;
            gcApeNom.VisibleIndex = 0;
            gcApeNom.Width = 250;

            gc1.Caption = "1";
            gc1.FieldName = "1";
            gc1.Name = "gc1";
            gc1.OptionsColumn.AllowEdit = false;
            gc1.Visible = true;
            gc1.VisibleIndex = 1;
            gc1.Width = 20;

            gc2.Caption = "2";
            gc2.FieldName = "2";
            gc2.Name = "gc2";
            gc2.OptionsColumn.AllowEdit = false;
            gc2.Visible = true;
            gc2.VisibleIndex = 2;
            gc2.Width = 20;

            gc3.Caption = "3";
            gc3.FieldName = "3";
            gc3.Name = "gc3";
            gc3.OptionsColumn.AllowEdit = false;
            gc3.Visible = true;
            gc3.VisibleIndex = 3;
            gc3.Width = 20;

            gc4.Caption = "4";
            gc4.FieldName = "4";
            gc4.Name = "gc4";
            gc4.OptionsColumn.AllowEdit = false;
            gc4.Visible = true;
            gc4.VisibleIndex = 4;
            gc4.Width = 20;

            gc5.Caption = "5";
            gc5.FieldName = "5";
            gc5.Name = "gc5";
            gc5.OptionsColumn.AllowEdit = false;
            gc5.Visible = true;
            gc5.VisibleIndex = 5;
            gc5.Width = 20;

            gc6.Caption = "6";
            gc6.FieldName = "6";
            gc6.Name = "gc6";
            gc6.OptionsColumn.AllowEdit = false;
            gc6.Visible = true;
            gc6.VisibleIndex = 6;
            gc6.Width = 20;

            gc7.Caption = "7";
            gc7.FieldName = "7";
            gc7.Name = "gc7";
            gc7.OptionsColumn.AllowEdit = false;
            gc7.Visible = true;
            gc7.VisibleIndex = 7;
            gc7.Width = 20;

            gc8.Caption = "8";
            gc8.FieldName = "8";
            gc8.Name = "gc8";
            gc8.OptionsColumn.AllowEdit = false;
            gc8.Visible = true;
            gc8.VisibleIndex = 8;
            gc8.Width = 20;

            gc9.Caption = "9";
            gc9.FieldName = "9";
            gc9.Name = "gc9";
            gc9.OptionsColumn.AllowEdit = false;
            gc9.Visible = true;
            gc9.VisibleIndex = 9;
            gc9.Width = 20;

            gc10.Caption = "10";
            gc10.FieldName = "10";
            gc10.Name = "gc10";
            gc10.OptionsColumn.AllowEdit = false;
            gc10.Visible = true;
            gc10.VisibleIndex = 10;
            gc10.Width = 25;

            gc11.Caption = "11";
            gc11.FieldName = "11";
            gc11.Name = "gc11";
            gc11.OptionsColumn.AllowEdit = false;
            gc11.Visible = true;
            gc11.VisibleIndex = 11;
            gc11.Width = 25;

            gc12.Caption = "12";
            gc12.FieldName = "12";
            gc12.Name = "gc12";
            gc12.OptionsColumn.AllowEdit = false;
            gc12.Visible = true;
            gc12.VisibleIndex = 12;
            gc12.Width = 25;

            gc13.Caption = "13";
            gc13.FieldName = "13";
            gc13.Name = "gc13";
            gc13.OptionsColumn.AllowEdit = false;
            gc13.Visible = true;
            gc13.VisibleIndex = 13;
            gc13.Width = 25;

            gc14.Caption = "14";
            gc14.FieldName = "14";
            gc14.Name = "gc14";
            gc14.OptionsColumn.AllowEdit = false;
            gc14.Visible = true;
            gc14.VisibleIndex = 14;
            gc14.Width = 25;

            gc15.Caption = "15";
            gc15.FieldName = "15";
            gc15.Name = "gc15";
            gc15.OptionsColumn.AllowEdit = false;
            gc15.Visible = true;
            gc15.VisibleIndex = 15;
            gc15.Width = 25;

            gc16.Caption = "16";
            gc16.FieldName = "16";
            gc16.Name = "gc16";
            gc16.OptionsColumn.AllowEdit = false;
            gc16.Visible = true;
            gc16.VisibleIndex = 16;
            gc16.Width = 25;

            gc17.Caption = "17";
            gc17.FieldName = "17";
            gc17.Name = "gc17";
            gc17.OptionsColumn.AllowEdit = false;
            gc17.Visible = true;
            gc17.VisibleIndex = 17;
            gc17.Width = 25;

            gc18.Caption = "18";
            gc18.FieldName = "18";
            gc18.Name = "gc18";
            gc18.OptionsColumn.AllowEdit = false;
            gc18.Visible = true;
            gc18.VisibleIndex = 18;
            gc18.Width = 25;

            gc19.Caption = "19";
            gc19.FieldName = "19";
            gc19.Name = "gc19";
            gc19.OptionsColumn.AllowEdit = false;
            gc19.Visible = true;
            gc19.VisibleIndex = 19;
            gc19.Width = 25;

            gc20.Caption = "20";
            gc20.FieldName = "20";
            gc20.Name = "gc20";
            gc20.OptionsColumn.AllowEdit = false;
            gc20.Visible = true;
            gc20.VisibleIndex = 20;
            gc20.Width = 25;

            gc21.Caption = "21";
            gc21.FieldName = "21";
            gc21.Name = "gc21";
            gc21.OptionsColumn.AllowEdit = false;
            gc21.Visible = true;
            gc21.VisibleIndex = 21;
            gc21.Width = 25;

            gc22.Caption = "22";
            gc22.FieldName = "22";
            gc22.Name = "gc22";
            gc22.OptionsColumn.AllowEdit = false;
            gc22.Visible = true;
            gc22.VisibleIndex = 22;
            gc22.Width = 25;

            gc23.Caption = "23";
            gc23.FieldName = "23";
            gc23.Name = "gc23";
            gc23.OptionsColumn.AllowEdit = false;
            gc23.Visible = true;
            gc23.VisibleIndex = 23;
            gc23.Width = 25;

            gc24.Caption = "24";
            gc24.FieldName = "24";
            gc24.Name = "gc24";
            gc24.OptionsColumn.AllowEdit = false;
            gc24.Visible = true;
            gc24.VisibleIndex = 24;
            gc24.Width = 25;

            gc25.Caption = "25";
            gc25.FieldName = "25";
            gc25.Name = "gc25";
            gc25.OptionsColumn.AllowEdit = false;
            gc25.Visible = true;
            gc25.VisibleIndex = 25;
            gc25.Width = 25;

            gc26.Caption = "26";
            gc26.FieldName = "26";
            gc26.Name = "gc26";
            gc26.OptionsColumn.AllowEdit = false;
            gc26.Visible = true;
            gc26.VisibleIndex = 26;
            gc26.Width = 25;

            gc27.Caption = "27";
            gc27.FieldName = "27";
            gc27.Name = "gc27";
            gc27.OptionsColumn.AllowEdit = false;
            gc27.Visible = true;
            gc27.VisibleIndex = 27;
            gc27.Width = 25;

            gc28.Caption = "28";
            gc28.FieldName = "28";
            gc28.Name = "gc28";
            gc28.OptionsColumn.AllowEdit = false;
            gc28.Visible = true;
            gc28.VisibleIndex = 28;
            gc28.Width = 25;

            gcFlagApoyo.Caption = "Apoyo";
            gcFlagApoyo.FieldName = "FlagApoyo";
            gcFlagApoyo.Name = "gcFlagApoyo";
            gcFlagApoyo.OptionsColumn.AllowEdit = false;
            gcFlagApoyo.Visible = true;
            gcFlagApoyo.VisibleIndex = 29;
            gcFlagApoyo.Width = 20;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 30;
            gcDescTienda.Width = 100;

            gcDescArea.Caption = "Area";
            gcDescArea.FieldName = "DescArea";
            gcDescArea.Name = "gcDescArea";
            gcDescArea.OptionsColumn.AllowEdit = false;
            gcDescArea.Visible = true;
            gcDescArea.VisibleIndex = 31;
            gcDescArea.Width = 100;

            gcDescCargo.Caption = "Cargo";
            gcDescCargo.FieldName = "DescCargo";
            gcDescCargo.Name = "gcDescCargo";
            gcDescCargo.OptionsColumn.AllowEdit = false;
            gcDescCargo.Visible = true;
            gcDescCargo.VisibleIndex = 32;
            gcDescCargo.Width = 250;


            gcDescCargo.Caption = "Descanso";
            gcDescCargo.FieldName = "Descanso";
            gcDescCargo.Name = "gcDescanso";
            gcDescCargo.OptionsColumn.AllowEdit = false;
            gcDescCargo.Visible = true;
            gcDescCargo.VisibleIndex = 33;
            gcDescCargo.Width = 100;



            gcTotalF.Caption = "Total F";
            gcTotalF.FieldName = "TotalF";
            gcTotalF.Name = "gcTotalF";
            gcTotalF.OptionsColumn.AllowEdit = false;
            gcTotalF.Visible = true;
            gcTotalF.VisibleIndex = 34;
            gcTotalF.Width = 60;

            gcTotalFI.Caption = "Total FI";
            gcTotalFI.FieldName = "TotalFI";
            gcTotalFI.Name = "gcTotalFI";
            gcTotalFI.OptionsColumn.AllowEdit = false;
            gcTotalFI.Visible = true;
            gcTotalFI.VisibleIndex = 35;
            gcTotalFI.Width = 60;

            gcTotalDM.Caption = "Total DM";
            gcTotalDM.FieldName = "TotalDM";
            gcTotalDM.Name = "gcTotalDM";
            gcTotalDM.OptionsColumn.AllowEdit = false;
            gcTotalDM.Visible = true;
            gcTotalDM.VisibleIndex = 36;
            gcTotalDM.Width = 60;

            gcTotalLC.Caption = "Total LC";
            gcTotalLC.FieldName = "TotalLC";
            gcTotalLC.Name = "gcTotalLC";
            gcTotalLC.OptionsColumn.AllowEdit = false;
            gcTotalLC.Visible = true;
            gcTotalLC.VisibleIndex = 37;
            gcTotalLC.Width = 60;


            gvTareo.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                 gcTipo,
                 gcApeNom,
                 gc1,
                 gc2,
                 gc3,
                 gc4,
                 gc5,
                 gc6,
                 gc7,
                 gc8,
                 gc9,
                 gc10,
                 gc11,
                 gc12,
                 gc13,
                 gc14,
                 gc15,
                 gc16,
                 gc17,
                 gc18,
                 gc19,
                 gc20,
                 gc21,
                 gc22,
                 gc23,
                 gc24,
                 gc25,
                 gc26,
                 gc27,
                 gc28,
                 gcFlagApoyo,
                 gcDescTienda,
                 gcDescArea,
                 gcDescCargo,
                 gcDescanso,
                 gcTotalF,
                 gcTotalFI,
                 gcTotalDM,
                 gcTotalLC
                });
        }

        private void ConfigurarGrilla29dias()
        {
            gcTareo.ForceInitialize();
            gvTareo.PopulateColumns();

            gvTareo.Columns.Clear();
            gvTareo.SelectAll();
            gvTareo.DeleteSelectedRows();


            gvTareo.OptionsBehavior.Editable = true;
            gvTareo.OptionsCustomization.AllowColumnMoving = true;
            gvTareo.OptionsCustomization.AllowGroup = false;
            gvTareo.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvTareo.OptionsSelection.MultiSelect = true;
            gvTareo.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gvTareo.OptionsView.ShowGroupPanel = false;
            gvTareo.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            //DevExpress.XtraGrid.Columns.GridColumn gcDni = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcApeNom = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc4 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc5 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc6 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc7 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc8 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc9 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc10 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc11 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc12 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc13 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc14 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc15 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc16 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc17 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc18 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc19 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc20 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc21 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc22 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc23 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc24 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc25 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc26 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc27 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc28 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gc29 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescTienda = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescArea = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcDescanso = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcFlagApoyo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalF = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalFI = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalDM = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn gcTotalLC = new DevExpress.XtraGrid.Columns.GridColumn();

            gcTipo.Caption = "Tipo";
            gcTipo.FieldName = "Tipo";
            gcTipo.Name = "gcTipo";
            gcTipo.OptionsColumn.AllowEdit = false;
            gcTipo.Visible = false;
            gcTipo.VisibleIndex = -1;
            gcTipo.Width = 250;

            gcApeNom.Caption = "Apellidos y Nombres";
            gcApeNom.FieldName = "ApeNom";
            gcApeNom.Name = "gcApeNom";
            gcApeNom.OptionsColumn.AllowEdit = true;
            gcApeNom.Visible = true;
            gcApeNom.VisibleIndex = 0;
            gcApeNom.Width = 250;

            gc1.Caption = "1";
            gc1.FieldName = "1";
            gc1.Name = "gc1";
            gc1.OptionsColumn.AllowEdit = false;
            gc1.Visible = true;
            gc1.VisibleIndex = 1;
            gc1.Width = 20;

            gc2.Caption = "2";
            gc2.FieldName = "2";
            gc2.Name = "gc2";
            gc2.OptionsColumn.AllowEdit = false;
            gc2.Visible = true;
            gc2.VisibleIndex = 2;
            gc2.Width = 20;

            gc3.Caption = "3";
            gc3.FieldName = "3";
            gc3.Name = "gc3";
            gc3.OptionsColumn.AllowEdit = false;
            gc3.Visible = true;
            gc3.VisibleIndex = 3;
            gc3.Width = 20;

            gc4.Caption = "4";
            gc4.FieldName = "4";
            gc4.Name = "gc4";
            gc4.OptionsColumn.AllowEdit = false;
            gc4.Visible = true;
            gc4.VisibleIndex = 4;
            gc4.Width = 20;

            gc5.Caption = "5";
            gc5.FieldName = "5";
            gc5.Name = "gc5";
            gc5.OptionsColumn.AllowEdit = false;
            gc5.Visible = true;
            gc5.VisibleIndex = 5;
            gc5.Width = 20;

            gc6.Caption = "6";
            gc6.FieldName = "6";
            gc6.Name = "gc6";
            gc6.OptionsColumn.AllowEdit = false;
            gc6.Visible = true;
            gc6.VisibleIndex = 6;
            gc6.Width = 20;

            gc7.Caption = "7";
            gc7.FieldName = "7";
            gc7.Name = "gc7";
            gc7.OptionsColumn.AllowEdit = false;
            gc7.Visible = true;
            gc7.VisibleIndex = 7;
            gc7.Width = 20;

            gc8.Caption = "8";
            gc8.FieldName = "8";
            gc8.Name = "gc8";
            gc8.OptionsColumn.AllowEdit = false;
            gc8.Visible = true;
            gc8.VisibleIndex = 8;
            gc8.Width = 20;

            gc9.Caption = "9";
            gc9.FieldName = "9";
            gc9.Name = "gc9";
            gc9.OptionsColumn.AllowEdit = false;
            gc9.Visible = true;
            gc9.VisibleIndex = 9;
            gc9.Width = 20;

            gc10.Caption = "10";
            gc10.FieldName = "10";
            gc10.Name = "gc10";
            gc10.OptionsColumn.AllowEdit = false;
            gc10.Visible = true;
            gc10.VisibleIndex = 10;
            gc10.Width = 25;

            gc11.Caption = "11";
            gc11.FieldName = "11";
            gc11.Name = "gc11";
            gc11.OptionsColumn.AllowEdit = false;
            gc11.Visible = true;
            gc11.VisibleIndex = 11;
            gc11.Width = 25;

            gc12.Caption = "12";
            gc12.FieldName = "12";
            gc12.Name = "gc12";
            gc12.OptionsColumn.AllowEdit = false;
            gc12.Visible = true;
            gc12.VisibleIndex = 12;
            gc12.Width = 25;

            gc13.Caption = "13";
            gc13.FieldName = "13";
            gc13.Name = "gc13";
            gc13.OptionsColumn.AllowEdit = false;
            gc13.Visible = true;
            gc13.VisibleIndex = 13;
            gc13.Width = 25;

            gc14.Caption = "14";
            gc14.FieldName = "14";
            gc14.Name = "gc14";
            gc14.OptionsColumn.AllowEdit = false;
            gc14.Visible = true;
            gc14.VisibleIndex = 14;
            gc14.Width = 25;

            gc15.Caption = "15";
            gc15.FieldName = "15";
            gc15.Name = "gc15";
            gc15.OptionsColumn.AllowEdit = false;
            gc15.Visible = true;
            gc15.VisibleIndex = 15;
            gc15.Width = 25;

            gc16.Caption = "16";
            gc16.FieldName = "16";
            gc16.Name = "gc16";
            gc16.OptionsColumn.AllowEdit = false;
            gc16.Visible = true;
            gc16.VisibleIndex = 16;
            gc16.Width = 25;

            gc17.Caption = "17";
            gc17.FieldName = "17";
            gc17.Name = "gc17";
            gc17.OptionsColumn.AllowEdit = false;
            gc17.Visible = true;
            gc17.VisibleIndex = 17;
            gc17.Width = 25;

            gc18.Caption = "18";
            gc18.FieldName = "18";
            gc18.Name = "gc18";
            gc18.OptionsColumn.AllowEdit = false;
            gc18.Visible = true;
            gc18.VisibleIndex = 18;
            gc18.Width = 25;

            gc19.Caption = "19";
            gc19.FieldName = "19";
            gc19.Name = "gc19";
            gc19.OptionsColumn.AllowEdit = false;
            gc19.Visible = true;
            gc19.VisibleIndex = 19;
            gc19.Width = 25;

            gc20.Caption = "20";
            gc20.FieldName = "20";
            gc20.Name = "gc20";
            gc20.OptionsColumn.AllowEdit = false;
            gc20.Visible = true;
            gc20.VisibleIndex = 20;
            gc20.Width = 25;

            gc21.Caption = "21";
            gc21.FieldName = "21";
            gc21.Name = "gc21";
            gc21.OptionsColumn.AllowEdit = false;
            gc21.Visible = true;
            gc21.VisibleIndex = 21;
            gc21.Width = 25;

            gc22.Caption = "22";
            gc22.FieldName = "22";
            gc22.Name = "gc22";
            gc22.OptionsColumn.AllowEdit = false;
            gc22.Visible = true;
            gc22.VisibleIndex = 22;
            gc22.Width = 25;

            gc23.Caption = "23";
            gc23.FieldName = "23";
            gc23.Name = "gc23";
            gc23.OptionsColumn.AllowEdit = false;
            gc23.Visible = true;
            gc23.VisibleIndex = 23;
            gc23.Width = 25;

            gc24.Caption = "24";
            gc24.FieldName = "24";
            gc24.Name = "gc24";
            gc24.OptionsColumn.AllowEdit = false;
            gc24.Visible = true;
            gc24.VisibleIndex = 24;
            gc24.Width = 25;

            gc25.Caption = "25";
            gc25.FieldName = "25";
            gc25.Name = "gc25";
            gc25.OptionsColumn.AllowEdit = false;
            gc25.Visible = true;
            gc25.VisibleIndex = 25;
            gc25.Width = 25;

            gc26.Caption = "26";
            gc26.FieldName = "26";
            gc26.Name = "gc26";
            gc26.OptionsColumn.AllowEdit = false;
            gc26.Visible = true;
            gc26.VisibleIndex = 26;
            gc26.Width = 25;

            gc27.Caption = "27";
            gc27.FieldName = "27";
            gc27.Name = "gc27";
            gc27.OptionsColumn.AllowEdit = false;
            gc27.Visible = true;
            gc27.VisibleIndex = 27;
            gc27.Width = 25;

            gc28.Caption = "28";
            gc28.FieldName = "28";
            gc28.Name = "gc28";
            gc28.OptionsColumn.AllowEdit = false;
            gc28.Visible = true;
            gc28.VisibleIndex = 28;
            gc28.Width = 25;

            gc29.Caption = "29";
            gc29.FieldName = "29";
            gc29.Name = "gc29";
            gc29.OptionsColumn.AllowEdit = false;
            gc29.Visible = true;
            gc29.VisibleIndex = 29;
            gc29.Width = 25;

            gcFlagApoyo.Caption = "Apoyo";
            gcFlagApoyo.FieldName = "FlagApoyo";
            gcFlagApoyo.Name = "gcFlagApoyo";
            gcFlagApoyo.OptionsColumn.AllowEdit = false;
            gcFlagApoyo.Visible = true;
            gcFlagApoyo.VisibleIndex = 30;
            gcFlagApoyo.Width = 20;

            gcDescTienda.Caption = "Tienda";
            gcDescTienda.FieldName = "DescTienda";
            gcDescTienda.Name = "gcDescTienda";
            gcDescTienda.OptionsColumn.AllowEdit = false;
            gcDescTienda.Visible = true;
            gcDescTienda.VisibleIndex = 31;
            gcDescTienda.Width = 100;

            gcDescArea.Caption = "Area";
            gcDescArea.FieldName = "DescArea";
            gcDescArea.Name = "gcDescArea";
            gcDescArea.OptionsColumn.AllowEdit = false;
            gcDescArea.Visible = true;
            gcDescArea.VisibleIndex = 32;
            gcDescArea.Width = 100;

            gcDescCargo.Caption = "Cargo";
            gcDescCargo.FieldName = "DescCargo";
            gcDescCargo.Name = "gcDescCargo";
            gcDescCargo.OptionsColumn.AllowEdit = false;
            gcDescCargo.Visible = true;
            gcDescCargo.VisibleIndex = 33;
            gcDescCargo.Width = 250;

            gcDescCargo.Caption = "Descanso";
            gcDescCargo.FieldName = "Descanso";
            gcDescCargo.Name = "gcDescanso";
            gcDescCargo.OptionsColumn.AllowEdit = false;
            gcDescCargo.Visible = true;
            gcDescCargo.VisibleIndex = 34;
            gcDescCargo.Width = 100;

            gcTotalF.Caption = "Total F";
            gcTotalF.FieldName = "TotalF";
            gcTotalF.Name = "gcTotalF";
            gcTotalF.OptionsColumn.AllowEdit = false;
            gcTotalF.Visible = true;
            gcTotalF.VisibleIndex = 35;
            gcTotalF.Width = 60;

            gcTotalFI.Caption = "Total FI";
            gcTotalFI.FieldName = "TotalFI";
            gcTotalFI.Name = "gcTotalFI";
            gcTotalFI.OptionsColumn.AllowEdit = false;
            gcTotalFI.Visible = true;
            gcTotalFI.VisibleIndex = 36;
            gcTotalFI.Width = 60;

            gcTotalDM.Caption = "Total DM";
            gcTotalDM.FieldName = "TotalDM";
            gcTotalDM.Name = "gcTotalDM";
            gcTotalDM.OptionsColumn.AllowEdit = false;
            gcTotalDM.Visible = true;
            gcTotalDM.VisibleIndex = 37;
            gcTotalDM.Width = 60;

            gcTotalLC.Caption = "Total LC";
            gcTotalLC.FieldName = "TotalLC";
            gcTotalLC.Name = "gcTotalLC";
            gcTotalLC.OptionsColumn.AllowEdit = false;
            gcTotalLC.Visible = true;
            gcTotalLC.VisibleIndex = 38;
            gcTotalLC.Width = 60;

            gvTareo.Columns.AddRange(
                new DevExpress.XtraGrid.Columns.GridColumn[] {
                 gcTipo,
                 gcApeNom,
                 gc1,
                 gc2,
                 gc3,
                 gc4,
                 gc5,
                 gc6,
                 gc7,
                 gc8,
                 gc9,
                 gc10,
                 gc11,
                 gc12,
                 gc13,
                 gc14,
                 gc15,
                 gc16,
                 gc17,
                 gc18,
                 gc19,
                 gc20,
                 gc21,
                 gc22,
                 gc23,
                 gc24,
                 gc25,
                 gc26,
                 gc27,
                 gc28,
                 gc29,
                 gcFlagApoyo,
                 gcDescTienda,
                 gcDescArea,
                 gcDescCargo,
                 gcDescanso,
                 gcTotalF,
                 gcTotalFI,
                 gcTotalDM,
                 gcTotalLC
                });
        }

        #endregion

        private void editarpersonatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvTareo.RowCount > 0)
            {
                if (TipoReporte == 2)
                {
                    string Dni = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, "Dni").ToString();
                    PersonaBE objPersonal = new PersonaBE();

                    objPersonal = new PersonaBL().SeleccionaNumeroDocumento(Dni);
                    objPersonal.IdPersona = objPersonal.IdPersona;

                    frmManPersonalEdit objManPersonalEdit = new frmManPersonalEdit();
                    objManPersonalEdit.pOperacion = frmManPersonalEdit.Operacion.Modificar;
                    objManPersonalEdit.IdPersona = objPersonal.IdPersona;
                    objManPersonalEdit.StartPosition = FormStartPosition.CenterParent;

                    if (objManPersonalEdit.ShowDialog() == DialogResult.OK)
                    {
                        int intFoco = gvTareo.FocusedRowHandle;
                        CargarCalculado();
                        gvTareo.FocusedRowHandle = intFoco;
                        //gvTareo.SelectRow(intFoco);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Selecionar la opción Calculado para poder asignar la ausencia laboral.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }   
        }

        private void asignardescansotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvTareo.RowCount > 0)
            {
                if (TipoReporte == 2)
                {
                    //string Valor = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, gvTareo.FocusedColumn.Caption.ToString()).ToString();
                    //if (Valor == "F" || Valor == "")
                    //{
                    string Dni = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, "Dni").ToString();

                    string Dia = gvTareo.FocusedColumn.Caption.ToString();
                    PersonaBE objE_Persona = new PersonaBE();
                    objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(Dni);

                    PersonaDescansoBL objBL_PersonaDescanso = new PersonaDescansoBL();
                    PersonaDescansoBE objE_PersonaDescanso = new PersonaDescansoBE();
                    objE_PersonaDescanso.IdPersonaDescanso = 0;
                    objE_PersonaDescanso.IdPersona = objE_Persona.IdPersona;
                    objE_PersonaDescanso.Fecha = Convert.ToDateTime(Dia + "/" + Convert.ToInt32(cboMes.EditValue).ToString() + "/" + txtPeriodo.Text.ToString());
                    objE_PersonaDescanso.FlagEstado = true;
                    objBL_PersonaDescanso.Inserta(objE_PersonaDescanso);

                    int intFoco = gvTareo.FocusedRowHandle;
                    CargarCalculado();
                    gvTareo.FocusedRowHandle = intFoco;

                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Sólo puede asignar los Días faltados[F].", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                }
                else
                {
                    XtraMessageBox.Show("Selecionar la opción Calculado para poder asignar el descanso laboral.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void eliminardiadescansotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvTareo.RowCount > 0)
            {
                if (TipoReporte == 2)
                {
                    //string Valor = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, gvTareo.FocusedColumn.Caption.ToString()).ToString();
                    //if (Valor == "F" || Valor == "")
                    //{
                    string Dni = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, "Dni").ToString();

                    string Dia = gvTareo.FocusedColumn.Caption.ToString();
                    PersonaBE objE_Persona = null;
                    PersonaDescansoBL objBL_PersonaDescanso = new PersonaDescansoBL();

                    objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(Dni);
                    if (objE_Persona != null)
                    {
                        objBL_PersonaDescanso.Elimina(objE_Persona.IdPersona, Convert.ToDateTime(Dia + "/" + Convert.ToInt32(cboMes.EditValue).ToString() + "/" + txtPeriodo.Text.ToString()));
                    }

                    int intFoco = gvTareo.FocusedRowHandle;
                    CargarCalculado();
                    gvTareo.FocusedRowHandle = intFoco;
                }
                else
                {
                    XtraMessageBox.Show("Selecionar la opción Calculado para poder eliminar el descanso laboral.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void verlistadomingotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvTareo.RowCount > 0)
            {
                if (TipoReporte == 2)
                {
                    string Dni = gvTareo.GetRowCellValue(gvTareo.FocusedRowHandle, "Dni").ToString();
                    string Dia = gvTareo.FocusedColumn.Caption.ToString();
                    //PersonaBE objE_Persona = new PersonaBE();
                    //objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(Dni);
                    DateTime Fecha = Convert.ToDateTime(Dia + "/" + Convert.ToInt32(cboMes.EditValue).ToString() + "/" + txtPeriodo.Text.ToString());

                    PersonaTrabajoBE objPersonaTrabajo = null;
                    objPersonaTrabajo = new PersonaTrabajoBL().SeleccionaFecha(Fecha);

                    if(objPersonaTrabajo != null)
                    {
                        objPersonaTrabajo.IdPersonaTrabajo = objPersonaTrabajo.IdPersonaTrabajo;

                        frmRegPersonaTrabajoEdit objManPersonaTrabajoEdit = new frmRegPersonaTrabajoEdit();
                        objManPersonaTrabajoEdit.pOperacion = frmRegPersonaTrabajoEdit.Operacion.Modificar;
                        objManPersonaTrabajoEdit.IdPersonaTrabajo = objPersonaTrabajo.IdPersonaTrabajo;
                        objManPersonaTrabajoEdit.StartPosition = FormStartPosition.CenterParent;
                        objManPersonaTrabajoEdit.ShowDialog();
                        int intFoco = gvTareo.FocusedRowHandle;
                        //CargarCalculado();
                        //gvTareo.FocusedRowHandle = intFoco;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Selecionar la opción Calculado para poder asignar el descanso laboral.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


    }
}