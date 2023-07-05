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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmConMarcacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CheckinoutBE> mLista = new List<CheckinoutBE>();

        private int IdCheckinout = 0;

        #endregion

        #region "Eventos"

        public frmConMarcacion()
        {
            InitializeComponent();

            //gcApeNom.Caption = "Apellidos y\nNombres";
            //gcHorarioIngreso.Caption = "Horario\nIngreso";
            //gcHorarioSalida.Caption = "Horario\nSalida";
            //gcSalidaRefrigerio.Caption = "Salida\nRefrigerio";
            //gcIngresoRefrigerio.Caption = "Ingreso\nRefrigerio";

            //gcTotalHoras.Caption = "Total\nHoras";
            //gcTotalMinutos.Caption = "Minutos";
            //gcRefrigerio.Caption = "Refrigerio";

        }

        private void frmConMarcacion_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMarcacionPersonal";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMarcacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVersionAnterior_Click(object sender, EventArgs e)
        {
            frmConsultaMarcacionGeneral frm = new frmConsultaMarcacionGeneral();
            frm.Show();
        }

        private void gvMarcacion_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }

        private void gvMarcacion_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvMarcacion.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {

                    object objDocRetiroNac = View.GetRowCellValue(e.RowHandle, View.Columns["Tardanza"]); //o en Descuento
                    if (objDocRetiroNac != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiroNac.ToString());
                        if (IdTipoDocumento > 0 && IdTipoDocumento <= 5)
                        {
                            gvMarcacion.Columns["Tardanza"].AppearanceCell.BackColor = Color.Orange;
                            gvMarcacion.Columns["Tardanza"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Red;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else if (IdTipoDocumento > 5)
                        {
                            gvMarcacion.Columns["Tardanza"].AppearanceCell.BackColor = Color.Red;
                            gvMarcacion.Columns["Tardanza"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Red;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else
                        {
                            gvMarcacion.Columns["Tardanza"].AppearanceCell.BackColor = Color.Green;
                            gvMarcacion.Columns["Tardanza"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }
                    }

                    //Modified
                    object objDocUpdates = View.GetRowCellValue(e.RowHandle, View.Columns["Updates"]);
                    if(objDocUpdates != null)
                    {
                        int Updates = int.Parse(objDocUpdates.ToString());
                        if (Updates > 0)
                        {
                            e.Appearance.BackColor = Color.Orange;
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

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }



        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int IdPersona = Parametros.intPersonaId;

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
                IdPersona = 0;
            
            mLista = new CheckinoutBL().ListaMarcacion("0", IdPersona, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcMarcacion.DataSource = mLista;

            CalcularTotalDocumentos();
            //lblTotalRegistros.Text = gvMarcacion.RowCount.ToString() + " Registros";
        }

        private void CargarBusqueda()
        {
            gcMarcacion.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper()) ||
                                                   obj.Dni.ToUpper().Contains(txtDescripcion.Text.ToUpper()) /*||
                                                   obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper()) ||
                                                   obj.DescArea.ToUpper().Contains(txtDescripcion.Text.ToUpper())*/).ToList();
            CalcularTotalDocumentos();
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                if (gvMarcacion.RowCount > 0)
                {
                    int TotalRegistros = 0;
                    int TotalHoras = 0;
                    int TotalMinutos = 0;
                    int Tardanza = 0;
                    int HoraExtra = 0;
                    int TardanzaRegistros = 0;
                    int HoraExtraRegistros = 0;
                    int TotalTardanzas = 0;
                    int TotalRefrigerio = 0;
                    int TotalHoraExtra = 0;

                    decimal decPromedioHoras = 0;
                    decimal decPromedioMinutos = 0;
                    decimal decPromedioTardanzas = 0;
                    decimal decPromedioRefrigerio = 0;
                    decimal decPromedioHoraExtra = 0;

                    TotalRegistros = gvMarcacion.RowCount;
                    lblTotalRegistros.Text = gvMarcacion.RowCount.ToString() + " Registros";

                    for (int i = 0; i < gvMarcacion.RowCount; i++)
                    {
                        TotalHoras = TotalHoras + Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["Horas"])));
                        TotalMinutos = TotalMinutos + Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["Minutos"])));
                        TotalRefrigerio = TotalRefrigerio + Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["Refrigerio"])));
                        Tardanza = Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["Tardanza"])));
                        HoraExtra = Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["HoraExtra"])));
                        if (Tardanza > 0)
                        {
                            TardanzaRegistros = TardanzaRegistros + 1;
                            TotalTardanzas = TotalTardanzas + Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["Tardanza"])));
                        }
                        if (HoraExtra > 0)
                        {
                            HoraExtraRegistros = HoraExtraRegistros + 1;
                            TotalHoraExtra = TotalHoraExtra + Convert.ToInt32(gvMarcacion.GetRowCellValue(i, (gvMarcacion.Columns["HoraExtra"])));
                        }
                    }

                    txtTotalHoras.EditValue = TotalHoras;
                    txtTotalMinutos.EditValue = TotalMinutos;
                    txtTardanza.EditValue = TotalTardanzas;
                    txtTotalRefrigerio.EditValue = TotalRefrigerio;
                    txtHoraExtra.EditValue = TotalHoraExtra;

                    if (TotalRegistros > 0)
                    {
                        txtPromedioHoras.EditValue = TotalHoras / TotalRegistros;
                        txtPromedioMinutos.EditValue = TotalMinutos / TotalRegistros;
                        txtPromedioRefrigerio.EditValue = TotalRefrigerio / TotalRegistros;
                    }
                    if (TardanzaRegistros > 0)
                    {
                        txtPromedioTardanzas.EditValue = TotalTardanzas / TardanzaRegistros;
                    }

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
            {
                if (Convert.ToInt32(keyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Alt) + Convert.ToInt32(Keys.NumPad5))// + Convert.ToInt32(Keys.O))
                {
                    frmRegAsistenciaFecha frm = new frmRegAsistenciaFecha();
                    frm.Show();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        #endregion

        private void justificartardanzatoolStripMenuItem_Click(object sender, EventArgs e)
        {

            //int IdPersona = int.Parse(gvMarcacion.GetFocusedRowCellValue("IdPersona").ToString());
            //DateTime Fecha = DateTime.Parse(gvMarcacion.GetFocusedRowCellValue("Fecha").ToString());

            //PersonaTardanzaBL objBL_PersonaTardanza = new PersonaTardanzaBL();
            //PersonaTardanzaBE objE_PersonaTardanza = new PersonaTardanzaBE();
            //objE_PersonaTardanza.IdPersonaTardanza = 0;
            //objE_PersonaTardanza.IdPersona = IdPersona;
            //objE_PersonaTardanza.Fecha = Fecha;
            //objE_PersonaTardanza.Tipo = "I";
            //objE_PersonaTardanza.Importe = 0;
            //objE_PersonaTardanza.Observacion = "";
            //objE_PersonaTardanza.FlagDescuento = false;
            //objE_PersonaTardanza.IdPersonaJustifica = 0;
            //objE_PersonaTardanza.FlagEstado = true;

            //objBL_PersonaTardanza.Inserta(objE_PersonaTardanza);

        }

        private void gvMarcacion_DoubleClick(object sender, EventArgs e)
        {
            if (gvMarcacion.RowCount > 0)
            {
                string Dni = gvMarcacion.GetFocusedRowCellValue("Dni").ToString();
                DateTime Fecha = DateTime.Parse(gvMarcacion.GetFocusedRowCellValue("Fecha").ToString());
                int Updates = Int32.Parse(gvMarcacion.GetFocusedRowCellValue("Updates").ToString());

                if (Updates > 0)
                {
                    frmHistorialUpdate frm = new frmHistorialUpdate();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.Dni = Dni;
                    frm.Fecha = Fecha;
                    frm.ShowDialog();
                }
                //else
                //{
                //    XtraMessageBox.Show("No existen registros para mostrar!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }

        private void modificarhorariotoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}