using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Net;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;


namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegTrackingPedido : DevExpress.XtraEditors.XtraForm
    {
        public frmRegTrackingPedido()
        {
            InitializeComponent();
        }

        private void frmRegTrackingPedido_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboPersonaPicking, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboSituacionAlmacen, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblSituacionAlmacen), "DescTablaElemento", "IdTablaElemento", true);
            timer1.Start();

            lblEquipo.Text = Dns.GetHostName().ToString().ToUpper();
            //Master
            if (lblEquipo.Text == @"HPUSER".ToString().ToUpper() || lblEquipo.Text == @"DESARROLLO-PC".ToString().ToUpper() || lblEquipo.Text == @"JOEL-PC".ToString().ToUpper())
            {
                cboSituacionAlmacen.Enabled = true;
                txtNumero.Enabled = true;
            }

            else if (lblEquipo.Text == @"JRODRIGUEZ-PC".ToString().ToUpper())
            {
                cboSituacionAlmacen.EditValue = Parametros.intEnPreparacion;
                txtNumero.Enabled = true;
                cboSituacionAlmacen.Enabled = false;
            }

            else if (lblEquipo.Text == @"EMBALAJE-PC".ToString().ToUpper())
            {
                cboSituacionAlmacen.EditValue = Parametros.intEnChequeo;
                txtNumero.Enabled = true;
                cboSituacionAlmacen.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //DateTime horario = DateTime.Now; //Te devuelve la hora actual
            //lblFecha.Text = horario.Date.ToShortDateString();
            //lblHora.Text = horario.Hour.ToString(); //Te da la hora.
            //lblMinuto.Text = horario.Minute.ToString(); //Te da los minutos
            //lblSegundo.Text = horario.Second.ToString(); //te da los segundos.

            lblHora.Text = DateTime.Now.ToString();
            //txtNumero.Focus();
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtNumero.Text.Length < 2)
                    {
                        return;
                    }

                    if (txtNumero.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumero.Focus();
                        return;
                    }

                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumero.Text);

                    #region "VerificaPC y Pedido"

                    //if (lblEquipo.Text == @"EMBALAJE-PC".ToString().ToUpper())
                    //{
                        //if (objE_Pedido.DescSituacionAlmacen == "EN PREPARACIÓN")//reemplazar por ID - en Preparación
                        //{
                        //   cboSituacionAlmacen.EditValue = Parametros.intEnChequeo;
                        //}
                        //else if (objE_Pedido.DescSituacionAlmacen == "EN CHEQUEO")
                        //{
                        //    cboSituacionAlmacen.EditValue = 161; //Pasa A PT
                        //}
                        //else
                        //{
                          //  XtraMessageBox.Show("El Pedido N° " + txtNumero.Text + " se encuentra en:" + objE_Pedido.DescSituacionAlmacen[0].ToString() + ", por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                    //}
                    #endregion

                    if (objE_Pedido != null)
                    {
                        //string SituacionPedido = "<NO ESPECIFICADO>";
                        PedidoBL objBL_Pedido = new PedidoBL();
                        objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, objE_Pedido.IdPedido, Convert.ToInt32(cboSituacionAlmacen.EditValue), Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

                        List<MovimientoPedidoBE> objBE_MovimientoPedido = null;
                        MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                        objBE_MovimientoPedido = objBL_MovimientoPedido.ListaNumero(Parametros.intPeriodo, txtNumero.Text.Trim());


                        if (Convert.ToInt32(cboSituacionAlmacen.EditValue) == Parametros.intEnPreparacion)
                        {
                            //usp_MovimientoPedido_ActualizaCierrePicking();
                        }

                        #region "Estado Pedido auto"

                        //if (objBE_MovimientoPedido != null)
                        //{
                        //    if (objBE_MovimientoPedido[0].Chequeo == true)
                        //        SituacionPedido = "CHEQUEO";
                        //    if (objBE_MovimientoPedido[0].Chequeo == true && objBE_MovimientoPedido[0].EnPT == true)
                        //        SituacionPedido = "CHEQUEO TERMINADO (PT)";
                        //    if (cboSituacionAlmacen.Text != "EN CHEQUEO")
                        //        SituacionPedido = cboSituacionAlmacen.Text;
                        //}
                        //XtraMessageBox.Show("El Pedido "+ txtNumero.Text.Trim() +" ha cambiado de situación a: " + SituacionPedido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion

                        XtraMessageBox.Show("El Pedido ha cambiado de situación a : " + cboSituacionAlmacen.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumero.Text = "";
                    }
                    else
                    {
                        XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //else  // Periodo anterior
                    //{
                    //    objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo - 1, txtNumero.Text);
                    //    if (objE_Pedido != null)
                    //    {
                    //        PedidoBL objBL_Pedido = new PedidoBL();
                    //        objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, objE_Pedido.IdPedido, Convert.ToInt32(cboSituacionAlmacen.EditValue), Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                    //        XtraMessageBox.Show("El Pedido ha cambiado de situación a : " + cboSituacionAlmacen.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //       // XtraMessageBox.Show("El Pedido está ha cambiado de situación a : " + objE_Pedido.DescSituacionAlmacen[0].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        txtNumero.Text = "";
                    //        txtNumero.Focus();
                    //    }
                    //    else
                    //    {
                    //        XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    }
                    //}

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSituacionAlmacen_EditValueChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(cboSituacionAlmacen.EditValue) == Parametros.intEnPreparacion)
            {
                txtCodigo.Visible = true;
                cboPersonaPicking.Visible = true;
                lblPersonalPicking.Visible = true;
                //this.Size = new Point(692, 228);
            }
            else
            {
                txtCodigo.Visible = false;
                cboPersonaPicking.Visible = false;
                lblPersonalPicking.Visible = false;
                txtNumero.Focus();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Trim().Length > 0)
                {
                    cboPersonaPicking.EditValue = Convert.ToInt32(txtCodigo.Text.Trim());
                    txtNumero.Focus();
                }
            }
        }

        
    }
}