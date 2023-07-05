using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using System.Security.Principal;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmMessageDeleteDocument : DevExpress.XtraEditors.XtraForm
    {
        //public int IdMotivoAnulacion { get; set;}

        public int IdMotivoAnulacion = 0;
        public string DescMotivo = "";

        public frmMessageDeleteDocument()
        {
            InitializeComponent();
        }

        private void frmMessageDeleteDocument_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboMotivoAnulacion, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoAnulacioDocumento), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivoAnulacion.EditValue = 0;
            btnAceptar.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(cboMotivoAnulacion.Text == "")
            {
                XtraMessageBox.Show("Seleccinar un motivo de anulación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            IdMotivoAnulacion = Convert.ToInt32(cboMotivoAnulacion.EditValue);
            DescMotivo = cboMotivoAnulacion.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}