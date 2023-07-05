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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConTransferenciaBulto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<BultoBE> mLista = new List<BultoBE>();
        
        #endregion

        #region "Eventos"

        public frmConTransferenciaBulto()
        {
            InitializeComponent();
        }

        private void frmConTransferenciaBulto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
        }

        private void tlbMenu_NewClick()
        {
            
        }

        private void tlbMenu_EditClick()
        {
            
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Está de seguro de eliminar la transferencia de bulto seleccionado?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BultoBE objE_Bulto = (BultoBE)gvBulto.GetRow(gvBulto.FocusedRowHandle);

                    BultoBL objBL_Bulto = new BultoBL();
                    objE_Bulto.IdEmpresa = Parametros.intEmpresaId;
                    objE_Bulto.IdSituacion = Parametros.intBULRecibido;
                    objE_Bulto.FechaSalida = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
                    objE_Bulto.Usuario = Parametros.strUsuarioLogin;
                    objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objBL_Bulto.ActualizaSituacion(objE_Bulto);
                    gvBulto.DeleteRow(gvBulto.FocusedRowHandle);
                    gvBulto.RefreshData();
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteTransferenciaBultoBE> lstReporte = null;
                lstReporte = new ReporteTransferenciaBultoBL().Listado(Parametros.intEmpresaId, Parametros.intBULTransferido);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptTransferenciaBulto = new RptVistaReportes();
                        objRptTransferenciaBulto.VerRptTransferenciaBulto(lstReporte);
                        objRptTransferenciaBulto.ShowDialog();
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoTransferenciaBulto";
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    if (XtraMessageBox.Show("Está de seguro de eliminar la transferencia de bulto seleccionado?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        BultoBE objE_Bulto = (BultoBE)gvBulto.GetRow(gvBulto.FocusedRowHandle);

                        BultoBL objBL_Bulto = new BultoBL();
                        objE_Bulto.IdEmpresa = Parametros.intEmpresaId;
                        objE_Bulto.IdSituacion = Parametros.intBULRecibido;
                        objE_Bulto.FechaSalida = Convert.ToDateTime(DateTime.Now.ToString());
                        objE_Bulto.Usuario = Parametros.strUsuarioLogin;
                        objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objBL_Bulto.ActualizaSituacion(objE_Bulto);
                        gvBulto.DeleteRow(gvBulto.FocusedRowHandle);
                        gvBulto.RefreshData();
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text.ToString().Trim().Length > 2)
            {
                CargarBusqueda();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new BultoBL().ListaTransferidosFecha(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime);
            gcBulto.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcBulto.DataSource = new BultoBL().ListaTransferidos(Parametros.intEmpresaId, txtProducto.Text);
            gcBulto.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvBulto.GetFocusedRowCellValue("IdBulto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Bulto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}