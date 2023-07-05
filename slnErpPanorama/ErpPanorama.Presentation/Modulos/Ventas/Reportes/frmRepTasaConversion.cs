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
using DevExpress.Export;
using DevExpress.XtraPrinting;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepTasaConversion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<ReporteTasaConversionBE> mLista = new List<ReporteTasaConversionBE>();

        #endregion

        #region "Eventos"
        public frmRepTasaConversion()
        {
            InitializeComponent();
        }

        private void frmRepTasaConversion_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now.AddDays(-1);
            deHasta.EditValue = DateTime.Now;

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoTasaConversion" + "Fecha";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gcTasaConversion.DefaultView.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls", new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                if (XtraMessageBox.Show("Desea abrir este archivo", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(f.SelectedPath + @"\" + _fileName + ".xls");
                }

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

        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new ReporteTasaConversionBL().Listado(Convert.ToDateTime(deDesde.DateTime.ToShortDateString()),Convert.ToDateTime(deHasta.DateTime.ToShortDateString()),Parametros.intEmpresaId);
            gcTasaConversion.DataSource = mLista;

        }

        #endregion

        private void gvTasaConversion_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvTasaConversion.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["TasUcayali"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(10))
                        {
                            gvTasaConversion.Columns["TasUcayali"].AppearanceCell.BackColor = Color.Green;
                            gvTasaConversion.Columns["TasUcayali"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(9) && IdTipoDocumento < Convert.ToDecimal(9.99))
                        {
                            gvTasaConversion.Columns["TasUcayali"].AppearanceCell.BackColor = Color.Orange;
                            gvTasaConversion.Columns["TasUcayali"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(9))
                        {
                            gvTasaConversion.Columns["TasUcayali"].AppearanceCell.BackColor = Color.Red;
                            gvTasaConversion.Columns["TasUcayali"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }
                    }

                    object objDocRetiroAnd = View.GetRowCellValue(e.RowHandle, View.Columns["TasAndahuaylas"]);
                    if (objDocRetiroAnd != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiroAnd.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(10))
                        {
                            gvTasaConversion.Columns["TasAndahuaylas"].AppearanceCell.BackColor = Color.Green;
                            gvTasaConversion.Columns["TasAndahuaylas"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(9) && IdTipoDocumento < Convert.ToDecimal(9.99))
                        {
                            gvTasaConversion.Columns["TasAndahuaylas"].AppearanceCell.BackColor = Color.Orange;
                            gvTasaConversion.Columns["TasAndahuaylas"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(9))
                        {
                            gvTasaConversion.Columns["TasAndahuaylas"].AppearanceCell.BackColor = Color.Red;
                            gvTasaConversion.Columns["TasAndahuaylas"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }
                    }


                    object objDocRetiroPre = View.GetRowCellValue(e.RowHandle, View.Columns["TasPrescott"]);
                    if (objDocRetiroPre != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiroPre.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(10))
                        {
                            gvTasaConversion.Columns["TasPrescott"].AppearanceCell.BackColor = Color.Green;
                            gvTasaConversion.Columns["TasPrescott"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(9) && IdTipoDocumento < Convert.ToDecimal(9.99))
                        {
                            gvTasaConversion.Columns["TasPrescott"].AppearanceCell.BackColor = Color.Orange;
                            gvTasaConversion.Columns["TasPrescott"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(9))
                        {
                            gvTasaConversion.Columns["TasPrescott"].AppearanceCell.BackColor = Color.Red;
                            gvTasaConversion.Columns["TasPrescott"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }
                    }


                    object objDocRetiroAvi = View.GetRowCellValue(e.RowHandle, View.Columns["TasAviacion2"]);
                    if (objDocRetiroAvi != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiroAvi.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(10))
                        {
                            gvTasaConversion.Columns["TasAviacion2"].AppearanceCell.BackColor = Color.Green;
                            gvTasaConversion.Columns["TasAviacion2"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(9) && IdTipoDocumento < Convert.ToDecimal(9.99))
                        {
                            gvTasaConversion.Columns["TasAviacion2"].AppearanceCell.BackColor = Color.Orange;
                            gvTasaConversion.Columns["TasAviacion2"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(9))
                        {
                            gvTasaConversion.Columns["TasAviacion2"].AppearanceCell.BackColor = Color.Red;
                            gvTasaConversion.Columns["TasAviacion2"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }
                    }


                    object objDocRetiroMeg = View.GetRowCellValue(e.RowHandle, View.Columns["TasMegaplaza"]);
                    if (objDocRetiroMeg != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiroMeg.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(10))
                        {
                            gvTasaConversion.Columns["TasMegaplaza"].AppearanceCell.BackColor = Color.Green;
                            gvTasaConversion.Columns["TasMegaplaza"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(9) && IdTipoDocumento < Convert.ToDecimal(9.99))
                        {
                            gvTasaConversion.Columns["TasMegaplaza"].AppearanceCell.BackColor = Color.Orange;
                            gvTasaConversion.Columns["TasMegaplaza"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(9))
                        {
                            gvTasaConversion.Columns["TasMegaplaza"].AppearanceCell.BackColor = Color.Red;
                            gvTasaConversion.Columns["TasMegaplaza"].AppearanceCell.BackColor2 = Color.SeaShell;
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