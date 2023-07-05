using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmActualizaDocumentoVenta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int IdDocumentoVenta { get; set; }
        public int IdEmpresa { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        
        #endregion

        #region "Eventos"

        public frmActualizaDocumentoVenta()
        {
            InitializeComponent();
        }

        private void frmActualizaDocumentoVenta_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = IdEmpresa;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocBoletaVenta;
            cboDocumento.Enabled = false;
            txtSerie.Text = Serie;
            txtNumeroDocumento.Text = Numero;
            txtSerie.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
            objE_DocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            objE_DocumentoVenta.IdDocumentoVenta = IdDocumentoVenta;
            objE_DocumentoVenta.Serie = txtSerie.Text;
            objE_DocumentoVenta.Numero = txtNumeroDocumento.Text;
            DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
            objBL_Documento.ActualizaNumeroSerie(objE_DocumentoVenta);

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Metodos"

        #endregion
    }
}