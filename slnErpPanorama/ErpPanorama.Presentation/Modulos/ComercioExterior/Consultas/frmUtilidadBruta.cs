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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using DevExpress.XtraSplashScreen;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas
{
    public partial class frmUtilidadBruta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();
        
        #endregion

        #region "Eventos"

        public frmUtilidadBruta()
        {
            InitializeComponent();
        }

        private void frmUtilidadBruta_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            //Cargar();
            //CargarTiendas();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";

            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                           
                if (tabPane1.SelectedPageIndex == 0)
                {
                    string _fileName = "Utilidad_Bruta";
                    Cursor = Cursors.AppStarting;
                    gvDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string _fileName = "Utilidad_PorTiendas";
                    Cursor = Cursors.AppStarting;
                    gvDocumento2.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            Cargar();
            CargarTiendas();

            splashScreenManager1.CloseWaitForm();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion
        
        #region "Metodos"

        private void Cargar()
        {

            gcDocumento.DataSource = new DocumentoVentaBL().ListaPeriodoGeneral(Convert.ToInt32(txtPeriodo.EditValue));
            gcDocumento.RefreshDataSource();
        }

        private void CargarTiendas()
        {

            gcDocumento2.DataSource = new DocumentoVentaBL().ListaPeriodoTiendas(Convert.ToInt32(txtPeriodo.EditValue));
            gcDocumento2.RefreshDataSource();
        }


        private void CargarCanalesVentas()
        {

            gcDocumento3.DataSource = new DocumentoVentaBL().CanalesVentas(Convert.ToInt32(txtPeriodo.EditValue));
            gcDocumento3.RefreshDataSource();
        }

        #endregion

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    try
            //    {
            //        Cargar();
            //        CargarTiendas();
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show(ex.Message, this.Text);
            //    }
                
            //}
            
            
        }

        private void gvDocumento_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvDocumento.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["RazonSocial"]);
                    if (objDocRetiro != null)
                    {
                        string Glosa =(objDocRetiro.ToString());
                        if (Glosa == "COSTO VENTAS")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            e.Appearance.ForeColor = Color.Red;
                          //  e.Appearance.Font =  Color.Red; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.Red; //Aprobado
                        }

                        if (Glosa == "UTILIDAD BRUTA")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;                            
                            e.Appearance.BackColor = Color.Yellow; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.LightYellow; //Aprobado
                            e.Appearance.ForeColor = Color.Black;
                        }

                        //if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.7))
                        //{
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Orange;
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                        //    //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                        //    //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        //}

                        //if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        //{
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Red;
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                        //    //e.Appearance.BackColor = Color.Red; //DarkSeaGreen;
                        //    //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SplashScreenManager.Default.SetWaitFormCaption("Procesando ...");
            splashScreenManager1.ShowWaitForm();
            Cargar();
            CargarTiendas();
            CargarCanalesVentas();

            splashScreenManager1.CloseWaitForm();
        }

        private void gvDocumento2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvDocumento.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["Tienda"]);
                    if (objDocRetiro != null)
                    {
                        string Glosa = (objDocRetiro.ToString());
                        if (Glosa == "COSTO VENTAS ANDAHUAYLAS" || Glosa == "COSTO VENTAS AVIACION" || Glosa == "COSTO VENTAS AVIACION2" || Glosa == "COSTO VENTAS PRESCOTT" || Glosa == "COSTO VENTAS UCAYALI" || Glosa == "COSTO VENTAS MEGAPLAZA" || Glosa == "COSTO VENTAS SANMIGUEL")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            e.Appearance.ForeColor = Color.Red;
                            //  e.Appearance.Font =  Color.Red; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.Red; //Aprobado
                        }

                        if (Glosa == "UTILIDAD - UCAYALI" || Glosa == "UTILIDAD - AVIACION" || Glosa == "UTILIDAD - AVIACION2" || Glosa == "UTILIDAD - ANDAHUAYLAS" || Glosa == "UTILIDAD - PRESCOTT" || Glosa == "UTILIDAD - MEGAPLAZA" || Glosa == "UTILIDAD - SANMIGUEL")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;                            
                            e.Appearance.BackColor = Color.Yellow; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.LightYellow; //Aprobado
                            e.Appearance.ForeColor = Color.Black;
                        }

                        //if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.7))
                        //{
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Orange;
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                        //    //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                        //    //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        //}

                        //if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        //{
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Red;
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                        //    //e.Appearance.BackColor = Color.Red; //DarkSeaGreen;
                        //    //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvDocumento3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvDocumento.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["Glosa"]);
                    if (objDocRetiro != null)
                    {
                        string Glosa = (objDocRetiro.ToString());
                        if (Glosa == "COSTO VENTAS")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            e.Appearance.ForeColor = Color.Red;
                            //  e.Appearance.Font =  Color.Red; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.Red; //Aprobado
                        }

                        if (Glosa == "UTILIDAD BRUTA" )
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;                            
                            e.Appearance.BackColor = Color.Yellow; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.LightYellow; //Aprobado
                            e.Appearance.ForeColor = Color.Black;
                        }

                        if (Glosa == "MARGEN BRUTO")
                        {
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            //gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;                            
                            e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.LightGreen; //Aprobado
                            e.Appearance.ForeColor = Color.Black;
                        }

                        //if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.7))
                        //{
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Orange;
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                        //    //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                        //    //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        //}

                        //if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        //{
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Red;
                        //    gvDocumento.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                        //    //e.Appearance.BackColor = Color.Red; //DarkSeaGreen;
                        //    //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        //}
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