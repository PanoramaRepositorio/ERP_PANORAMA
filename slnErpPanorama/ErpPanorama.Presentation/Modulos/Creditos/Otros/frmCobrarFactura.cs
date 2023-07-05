using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.Security.Principal;
using ErpPanorama.Presentation.Utils;

namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    public partial class frmCobrarFactura : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EstadoCuentaBE> mLista = new List<EstadoCuentaBE>();
        public List<CDocumentoVentaPago> mListaDocumentoVentaPagoOrigen = new List<CDocumentoVentaPago>();

        public int IdDocumentoVenta = 0;
        public int IdCliente = 0;
        public int IdTipoCliente = 0;
        public int IdTipoClasificacionCliente = 0;
        public int IdMoneda = Parametros.intSoles;
        public int IdPedido = 0;
        public int IdTipoDocumento = 0;
        public decimal TotalFactura = 0;
        public string NumeroFactura = "";
        public int IdEmpresa = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmCobrarFactura()
        {
            InitializeComponent();
        }

        private void frmCobrarFactura_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboCondicionPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionPago), "DescTablaElemento", "IdTablaElemento", true);
            cboCondicionPago.EditValue = Parametros.intEfectivo;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;

            txtTotalFactura.EditValue = TotalFactura;
            CargarEstadoCuenta();
            CargaPago();
            cboCondicionPago.Select();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Convert.ToDecimal(txtResta.EditValue)>= Convert.ToDecimal("-1.00"))
            {
                DocumentoVentaPagoBL objBL_DocumentoVentaPago = new DocumentoVentaPagoBL();

                DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
                objE_DocumentoVenta.IdDocumentoVenta = IdDocumentoVenta;
                objE_DocumentoVenta.IdSituacionContable = Parametros.intSitPendienteCon;
                if (Convert.ToDecimal(txtResta.EditValue) <= 0) objE_DocumentoVenta.IdSituacionContable = Parametros.intSitPagadoCon;
                objE_DocumentoVenta.IdEmpresa = IdEmpresa;

                //Documento Venta Pago
                List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                if (mListaDocumentoVentaPagoOrigen.Count > 0)
                {
                    foreach (var item in mListaDocumentoVentaPagoOrigen)
                    {
                        DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                        objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                        objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                        objE_DocumentoVentaPago.Fecha = item.Fecha;
                        objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                        objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                        objE_DocumentoVentaPago.NumeroDocumento = item.NumeroDocumento;
                        objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                        objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                        objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                        objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                        objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                        objE_DocumentoVentaPago.Importe = item.Importe;
                        objE_DocumentoVentaPago.FlagEstado = true;
                        objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                        lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
                    }

                    objBL_DocumentoVentaPago.Inserta(lstDocumentoVentaPago, objE_DocumentoVenta);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }else
            {
                XtraMessageBox.Show("No se puede grabar, verificar saldo.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtImporte.EditValue) == 0)
                {
                    XtraMessageBox.Show("El importe no puede ser 0.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    txtImporte.SelectAll();
                    return;
                }

                if (Convert.ToDecimal(txtImporte.EditValue) < 0)
                {
                    XtraMessageBox.Show("El importe no puede ser menor a 0.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    txtImporte.SelectAll();
                    return;
                }

                if (Convert.ToDecimal(txtImporte.EditValue) > Convert.ToDecimal(txtTotalFactura.Text))
                {
                    XtraMessageBox.Show("El importe no puede ser mayor al total de la venta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    txtImporte.SelectAll();
                    return;
                }

                if (Convert.ToDecimal(txtImporte.Text) > Convert.ToDecimal(txtResta.Text))
                {
                    XtraMessageBox.Show("El importe no puede ser mayor a la resta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtImporte.Focus();
                    txtImporte.SelectAll();
                    return;
                }

                //if(IdMoneda == Parametros.intSoles)
                //{
                //    if(Convert.ToInt32(cboMoneda.EditValue)==Parametros.intSoles)
                //    {
                //         txtImporte.EditValue
                //    }else {                   

                //    }
                //}

                CDocumentoVentaPago objE_Pago = new CDocumentoVentaPago();
                objE_Pago.IdEmpresa = Parametros.intEmpresaId;
                objE_Pago.IdDocumentoVenta = IdDocumentoVenta;
                objE_Pago.IdDocumentoVentaPago = 0;
                objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_Pago.IdTipoDocumento = IdTipoDocumento;
                objE_Pago.CodTipoDocumento = "";
                objE_Pago.NumeroDocumento = NumeroFactura;
                objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
                objE_Pago.DescCondicionPago = cboCondicionPago.Text;
                objE_Pago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                objE_Pago.CodMoneda = cboMoneda.Text;
                objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
                objE_Pago.Importe = Convert.ToDecimal(txtImporte.EditValue);
                objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                mListaDocumentoVentaPagoOrigen.Add(objE_Pago);

                bsListadoPago.DataSource = mListaDocumentoVentaPagoOrigen;
                gcDocumentoVentaPago.DataSource = bsListadoPago;
                gcDocumentoVentaPago.RefreshDataSource();

                CalculaTotales();
                cboCondicionPago.Select();

                //if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                //{
                //    txtResta.EditValue = Convert.ToDecimal(txtResta.Text) - Convert.ToDecimal(txtImporte.Text);
                //}
                //else
                //{
                //    txtResta.EditValue = Convert.ToDecimal(txtResta.Text) - (Convert.ToDecimal(txtImporte.Text) * Convert.ToDecimal(txtTC.EditValue));
                //}

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void elimiarPagotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdDocumentoVentaPago = 0;
                if (gvDocumentoVentaPago.GetFocusedRowCellValue("IdDocumentoVentaPago") != null)
                    IdDocumentoVentaPago = int.Parse(gvDocumentoVentaPago.GetFocusedRowCellValue("IdDocumentoVentaPago").ToString());
                int Item = 0;
                if (gvDocumentoVentaPago.GetFocusedRowCellValue("Item") != null)
                    Item = int.Parse(gvDocumentoVentaPago.GetFocusedRowCellValue("Item").ToString());
                DocumentoVentaPagoBE objBE_DocumentoVentaPago = new DocumentoVentaPagoBE();
                objBE_DocumentoVentaPago.IdDocumentoVentaPago = IdDocumentoVentaPago;
                objBE_DocumentoVentaPago.IdEmpresa = Parametros.intEmpresaId;
                objBE_DocumentoVentaPago.Usuario = Parametros.strUsuarioLogin;
                objBE_DocumentoVentaPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                DocumentoVentaPagoBL objBL_DocumentoVentaPago = new DocumentoVentaPagoBL();
                objBL_DocumentoVentaPago.Elimina(objBE_DocumentoVentaPago);
                gvDocumentoVentaPago.DeleteRow(gvDocumentoVentaPago.FocusedRowHandle);
                gvDocumentoVentaPago.RefreshData();

                CalculaTotales();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deFecha_EditValueChanged(object sender, EventArgs e)
        {
            TipoCambioBE objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.EditValue));
            txtTC.EditValue = objE_TipoCambio.Compra;
        }

        private void deFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboCondicionPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnAgregar_Click(sender, e);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Convert.ToInt32(keyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.B))// + Convert.ToInt32(Keys.O))
            {
                txtImporte.EditValue = txtResta.EditValue;
                txtImporte.Select();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Métodos"
        private void CargarEstadoCuenta()
        {
            mLista = new EstadoCuentaBL().ListaPedido(Parametros.intEmpresaId, IdPedido, "A");
            gcEstadoCuenta.DataSource = mLista;
        }

        private void CargaPago()
        {
            List<DocumentoVentaPagoBE> lstTmpDocumentoVentaPago = null;
            lstTmpDocumentoVentaPago = new DocumentoVentaPagoBL().ListaTodosActivo(Parametros.intEmpresaId, IdDocumentoVenta);

            foreach (DocumentoVentaPagoBE item in lstTmpDocumentoVentaPago)
            {
                CDocumentoVentaPago objE_DocumentoVentaPago = new CDocumentoVentaPago();
                objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
                objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
                objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
                objE_DocumentoVentaPago.Fecha = item.Fecha;
                objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
                objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
                objE_DocumentoVentaPago.NumeroDocumento = item.NumeroDocumento;
                objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
                objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
                objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
                objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
                objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
                objE_DocumentoVentaPago.Importe = item.Importe;
                objE_DocumentoVentaPago.TipoOper = item.TipoOper;
                mListaDocumentoVentaPagoOrigen.Add(objE_DocumentoVentaPago);
            }

            bsListadoPago.DataSource = mListaDocumentoVentaPagoOrigen;
            gcDocumentoVentaPago.DataSource = bsListadoPago;
            gcDocumentoVentaPago.RefreshDataSource();

            CalculaTotales();
        }

        private void CalculaTotales()
        {
            try
            {
                decimal deTotal = 0;

                if (mListaDocumentoVentaPagoOrigen.Count > 0)
                {
                    foreach (var item in mListaDocumentoVentaPagoOrigen)
                    {
                        if(IdMoneda == Parametros.intSoles) 
                        {
                            if(item.IdMoneda ==Parametros.intDolares)
                                deTotal = deTotal + Math.Round((item.Importe*item.TipoCambio),2);
                            else
                                deTotal = deTotal + item.Importe;
                        }else
                        {
                            if (item.IdMoneda == Parametros.intSoles)
                                deTotal = deTotal + Math.Round((item.Importe / item.TipoCambio),2);
                            else
                                deTotal = deTotal + item.Importe;
                        }
                    }
                    txtTotalPago.EditValue = deTotal;
                    txtResta.EditValue = Convert.ToDecimal(txtTotalFactura.EditValue) - Convert.ToDecimal(txtTotalPago.EditValue);
                }
                else
                {
                    txtTotalPago.EditValue = 0;
                    txtResta.EditValue = Convert.ToDecimal(txtTotalFactura.EditValue) - Convert.ToDecimal(txtTotalPago.EditValue);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        public class CDocumentoVentaPago
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdDocumentoVenta { get; set; }
            public Int32 IdDocumentoVentaPago { get; set; }
            public DateTime Fecha { get; set; }
            public Int32 IdTipoDocumento { get; set; }
            public String CodTipoDocumento { get; set; }
            public String NumeroDocumento { get; set; }
            public Int32 IdCondicionPago { get; set; }
            public String DescCondicionPago { get; set; }
            public Int32 IdMoneda { get; set; }
            public String CodMoneda { get; set; }
            public Decimal TipoCambio { get; set; }
            public Decimal Importe { get; set; }
            public Int32 TipoOper { get; set; }

            public CDocumentoVentaPago()
            {

            }
        }


    }

}