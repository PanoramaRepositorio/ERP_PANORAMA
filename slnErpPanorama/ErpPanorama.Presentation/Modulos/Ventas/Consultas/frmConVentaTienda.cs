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
using DevExpress.XtraPivotGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConVentaTienda : DevExpress.XtraEditors.XtraForm
    {
        private List<ReporteTiendaTipoClienteMetaBE> mLista = new List<ReporteTiendaTipoClienteMetaBE>();
        Random rnd = new Random();

        public frmConVentaTienda()
        {
            InitializeComponent();

        }

        private void frmConVentaTienda_Load(object sender, EventArgs e)
        {
            //Cargar();
            //CargarVentaVendedor();
        }

        private void Cargar()
        {
            mLista = new ReporteTiendaTipoClienteMetaBL().Listado(Parametros.intTiendaUcayali, Parametros.intTipClienteFinal, Convert.ToDateTime("01/08/2016"), Convert.ToDateTime("31/08/2016"));
            gvVentaUcayali.DataSource = mLista;

            mLista = new ReporteTiendaTipoClienteMetaBL().Listado(Parametros.intTiendaAndahuaylas, Parametros.intTipClienteFinal, Convert.ToDateTime("01/08/2016"), Convert.ToDateTime("31/08/2016"));
            gvVentaAndahuaylas.DataSource = mLista;

            mLista = new ReporteTiendaTipoClienteMetaBL().Listado(Parametros.intTiendaPrescott, Parametros.intTipClienteFinal, Convert.ToDateTime("01/08/2016"), Convert.ToDateTime("31/08/2016"));
            gvVentaPrescott.DataSource = mLista;

            mLista = new ReporteTiendaTipoClienteMetaBL().Listado(Parametros.intTiendaAviacion, Parametros.intTipClienteFinal, Convert.ToDateTime("01/08/2016"), Convert.ToDateTime("31/08/2016"));
            gvVentaAviacion.DataSource = mLista;

            mLista = new ReporteTiendaTipoClienteMetaBL().Listado(Parametros.intTiendaMegaplaza, Parametros.intTipClienteFinal, Convert.ToDateTime("01/08/2016"), Convert.ToDateTime("31/08/2016"));
            gvVentaMegaplaza.DataSource = mLista;

        }

        private void CargarVentaVendedor()
        {
            mLista = new ReporteTiendaTipoClienteMetaBL().ListadoVendedor(Parametros.intEmpresaId, Parametros.intTiendaUcayali,0, Convert.ToDateTime("01/08/2016"), Convert.ToDateTime("31/08/2016"));
            gcVentaVendedor.DataSource = mLista;
        }

        private void btnConsultarVentaTienda_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnConsultarVentaVendedor_Click(object sender, EventArgs e)
        {
            //if (cboMes.Text != "")
            //{
                CargarVentaVendedor();
            //}
        }

        private void gvVentaVendedor_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvVentaVendedor.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["Cumplimiento"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(1))
                        {
                            gvVentaVendedor.Columns["Cumplimiento"].AppearanceCell.BackColor = Color.Green;
                            gvVentaVendedor.Columns["Cumplimiento"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(0.81) && IdTipoDocumento < Convert.ToDecimal(0.99))
                        {
                            gvVentaVendedor.Columns["Cumplimiento"].AppearanceCell.BackColor = Color.Orange;
                            gvVentaVendedor.Columns["Cumplimiento"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(0.81))
                        {
                            gvVentaVendedor.Columns["Cumplimiento"].AppearanceCell.BackColor = Color.Red;
                            gvVentaVendedor.Columns["Cumplimiento"].AppearanceCell.BackColor2 = Color.SeaShell;

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
    }
}