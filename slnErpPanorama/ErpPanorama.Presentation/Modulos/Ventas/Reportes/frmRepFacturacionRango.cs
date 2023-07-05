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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity.Reportes;
using ErpPanorama.BusinessLogic.Reportes;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepFacturacionRango : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<ReporteFacturacionBE> mLista = new List<ReporteFacturacionBE>();
        #endregion

        #region "Eventos"
        public frmRepFacturacionRango()
        {
            InitializeComponent();
        }

        private void frmRepFacturacionRango_Load(object sender, EventArgs e)
        {
            List<TiendaBE> lTienda = new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId);
            List<TablaElementoBE> lTipoCliente = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCliente);
            lTipoCliente.RemoveAt(0);

            lTienda.Insert(0, new TiendaBE { DescTienda = "--TODOS--", IdTienda = 0 });
            lTipoCliente.Insert(0, new TablaElementoBE { DescTablaElemento = "--TODOS--", IdTablaElemento = 0 });

            BSUtils.LoaderLook(cboTienda, lTienda, "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboTipoCliente, lTipoCliente, "DescTablaElemento", "IdTablaElemento", true);

            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
        }


        private void cboVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTipoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void tlbMenu_Print_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //List<ReporteFacturacionRangoBE> mLista2 = new DocumentoVentaBL().ListaReporte(
                //    Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboTipoCliente.EditValue),
                //    Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                if (mLista != null)
                {
                    if (mLista.Count > 0)
                    {
                        string sDescTienda = "";
                        string sDescTipoCliente = "";

                        sDescTienda = Convert.ToInt32(cboTienda.EditValue) == 0 ? "Todos" : cboTienda.Text;
                        sDescTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue) == 0 ? "Todos" : cboTipoCliente.Text;

                        RptVistaReportes objRptKardexBulto = new RptVistaReportes();
                        objRptKardexBulto.VerRptFacturacionRango(mLista, sDescTienda, sDescTipoCliente, deFechaDesde.DateTime.ToShortDateString(), deFechaHasta.DateTime.ToShortDateString());
                        objRptKardexBulto.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_Excel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoFacturacionRango";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gcDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            try
            {
                mLista = new ReporteFacturacionBL().ListaReporte(
                   Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboTipoCliente.EditValue),
                   Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                gcDocumento.DataSource = mLista;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

       
    }
}