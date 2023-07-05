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
    public partial class frmRazonSocialEmisora : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int IdTipoDocumento { get; set; }
        public int IdEmpresa { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        
        #endregion

        #region "Eventos"

        public frmRazonSocialEmisora()
        {
            InitializeComponent();
        }

        private void frmRazonSocialEmisora_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            //BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", false);
            cboDocumento.EditValue = Parametros.intTipoDocBoletaVenta;
            deFecha.EditValue = DateTime.Now;
            //cboDocumento.Enabled = false;
            txtSerie.Text = "001";
            txtNumeroDocumento.Focus();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtSerie.Text.Trim() == "")
            {
                XtraMessageBox.Show("Ingrese el número de serie ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtNumeroDocumento.Text.Trim() == "")
            {
                XtraMessageBox.Show("Ingrese el numero del documento ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(cboEmpresa.EditValue) != Parametros.intPanoraramaDistribuidores)
            {
                TopeEmpresaBE objE_TopeEmpresa = new TopeEmpresaBE();
                objE_TopeEmpresa = new TopeEmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));

                decimal Tope = 0;

                if (objE_TopeEmpresa != null)
                {
                    Tope = objE_TopeEmpresa.Tope;
                }

                DocumentoVentaBE objE_Documento = new DocumentoVentaBE();
                objE_Documento = new DocumentoVentaBL().SeleccionaEmpresaPeriodo(Convert.ToInt32(cboEmpresa.EditValue), deFecha.DateTime.Year, deFecha.DateTime.Month);

                decimal TotalVenta = 0;

                if (objE_Documento != null)
                {

                    TotalVenta = Total + objE_Documento.Total;
                }
                else
                {
                    TotalVenta = 0;
                }
                

                EmpresaBE objE_Empresa = null;
                objE_Empresa = new EmpresaBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue));
                if (objE_Empresa != null)
                {
                    if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS )
                    {
                        if (TotalVenta > Tope)
                        {
                            XtraMessageBox.Show("El importe de venta sobrepasa el tope mensual del RUS, por favor verifique\n. Consultar al area de contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    
                }
            }



            this.DialogResult = DialogResult.OK;
            IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
            IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            Serie = txtSerie.Text;
            Numero = txtNumeroDocumento.Text;
            Fecha = deFecha.DateTime;
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

        private void deFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Metodos"
        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "BOV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 26;
            dr["Descripcion"] = "FAV";
            dt.Rows.Add(dr);
            return dt;
        }


        #endregion

        
    }
}