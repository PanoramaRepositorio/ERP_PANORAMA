using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegInventarioAjuste : DevExpress.XtraEditors.XtraForm
    {
        public frmRegInventarioAjuste()
        {
            InitializeComponent();
        }

        private void frmRegInventarioAjuste_Load(object sender, EventArgs e)
        {
            deFechaDesde.EditValue = "01/01/" + Parametros.intPeriodo;
            deDesdeBulto.EditValue = "01/01/" + Parametros.intPeriodo;
            deFechaHasta.EditValue = DateTime.Now;
            deHastaBulto.EditValue = DateTime.Now;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Esta seguro de actualizar el Stock?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    
                    InventarioBL objBL_Inventario = new InventarioBL();
                    objBL_Inventario.ActualizaStockKardex(Parametros.intEmpresaId, chkAjustar.Checked, 
                                                          Convert.ToDateTime(deDesdeBulto.DateTime.ToShortDateString()),
                                                          Convert.ToDateTime(deHastaBulto.DateTime.ToShortDateString()), 
                                                          Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), 
                                                          Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                    XtraMessageBox.Show("El stock se actualizó correctamente" , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}