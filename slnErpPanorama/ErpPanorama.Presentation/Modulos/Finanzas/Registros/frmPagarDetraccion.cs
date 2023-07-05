using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Funciones;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmPagarDetraccion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<CuentaPorPagarBE> mLista2 = new List<CuentaPorPagarBE>();

        private String Bloque = "";
        private String IndiceBloque = "";
        #endregion

        #region "Eventos"
        public frmPagarDetraccion()
        {
            InitializeComponent();
        }

        private void txtLote_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                IndiceBloque = txtLote.Text;
                Bloque = GetBloque(IndiceBloque);

                if (IndiceBloque == "" || IndiceBloque == null)
                {
                    DialogResult res = XtraMessageBox.Show("Ingrese lote de detraccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                        txtLote.Focus();
                }
                else
                {
                    DialogResult res = XtraMessageBox.Show("¿Esta seguro de pagar las detracciones del Lote N° " + IndiceBloque + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        CuentaPorPagarBL objBL_CuentaPorPagar = new CuentaPorPagarBL();
                        int i2 = 0;
                        mLista2 = new CuentaPorPagarBL().ListaPorBloque(IndiceBloque);

                        if (mLista2.Count != 0)
                        {
                            foreach (var c in mLista2)
                            {
                                if (c.IdSituacion == Parametros.intSitPagadoCon)
                                {
                                    XtraMessageBox.Show("El Lote N° " + IndiceBloque + " ya se pagó con anterioridad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                c.IdSituacion = Parametros.intSitPagadoCon;
                                c.fechaBloque = c.fechaBloque;
                                c.NumeroBloque = Bloque;
                                c.IndiceBloque = IndiceBloque;
                                c.IdCuentaPagar = c.IdCuentaPagar;
                                objBL_CuentaPorPagar.CambiaSituacion(c);
                                i2++;
                            }

                            XtraMessageBox.Show("El Lote N° " + IndiceBloque + " fue PAGADO con éxito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("No existe el lote de detraccion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (res == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Close();
            }
        }

        private void txtLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnPagar.Focus();
            }
        }
        #endregion

        #region "Metodos"
        public String GetBloque (String str)
        {
            String strTempBloque = str.Remove(0, 2) == "" ? "0" : str.Remove(0, 2);
            Int32 intTempBloque = Convert.ToInt32(strTempBloque);
            String tempBloque = intTempBloque.ToString();
            return tempBloque;
        }
        #endregion
    }
}