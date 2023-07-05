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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegTrackingPedidoPickingEmbalaje : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //private List<StockBE> mListaStock = new List<StockBE>();
        //private List<BultoBE> mLista = new List<BultoBE>();
        //private List<UbicacionProductoBE> mListaUbicacion = new List<UbicacionProductoBE>();
        //private List<UbicacionProductoBE> mListaUbicacionProducto = new List<UbicacionProductoBE>();

        //private int IdProducto = 0;
        private int IdPedidoPicking = 0;
        private int IdPedidoEmbalaje = 0;
        private int IdMovimientoAlmacenPicking = 0;
        private int IdMovimientoAlmacenEmbalaje = 0;

        #endregion

        #region "Eventos"

        public frmRegTrackingPedidoPickingEmbalaje()
        {
            InitializeComponent();
        }

        private void frmRegTrackingPedidoPickingEmbalaje_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            BSUtils.LoaderLook(cboPersonaPicking, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboPersonaPicking.EditValue = 0;
            BSUtils.LoaderLook(cboPersonaEmbalaje, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboPersonaEmbalaje.EditValue = 0;
            BSUtils.LoaderLook(cboPersonaPickingSolicitud, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboPersonaPickingNS, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboPersonaPickingNS.EditValue = 0;
            BSUtils.LoaderLook(cboPersonaEmbalajeNS, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboPersonaEmbalajeNS.EditValue = 0;
            txtNumero.Select();
            lblFecha.Text = DateTime.Now.ToLongDateString().ToString();
            txtPeriodo.EditValue = DateTime.Now.Year;
            txtPeriodoEmbalaje.EditValue = DateTime.Now.Year; ;
            timer1.Enabled = true;
            
        }

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtCodigo.Text.Trim().Length > 0)
            //    {
            //        cboPersonaPicking.EditValue = Convert.ToInt32(txtCodigo.Text.Trim());
            //        lblMensajePicking.Text = "";
            //        if (btnInicioPicking.Enabled)
            //            btnInicioPicking.Focus();
            //        else
            //            btnFinPicking.Focus();
            //    }
            //}
        }

        private void txtCodigoEmbalaje_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtCodigoEmbalaje.Text.Trim().Length > 0)
            //    {
            //        cboPersonaEmbalaje.EditValue = Convert.ToInt32(txtCodigoEmbalaje.Text.Trim());
            //        lblMensajeEmbalaje.Text = "";

            //        if (btnInicioEmbalaje.Enabled)
            //            btnInicioEmbalaje.Focus();
            //        else
            //            btnFinEmbalaje.Focus();
            //        //txtNumeroBultos.Focus();
            //        //txtNumeroBultos.SelectAll();
            //    }
            //}
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1) txtNumero.Select();
            if (keyData == Keys.F2) txtNumeroEmbalaje.Select();
            if (keyData == Keys.F3) txtNumeroNS.Select();
            if (keyData == Keys.F4) txtNumeroEmbalajeNS.Select();
            if (keyData == Keys.Escape) this.Close();

                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (txtNumero.Text.Length < 2)
            //        {
            //            return;
            //        }

            //        if (txtNumero.Text == "")
            //        {
            //            XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtNumero.Focus();
            //            return;
            //        }

            //        PedidoBE objE_Pedido = null;
            //        objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumero.Text);

            //        if (objE_Pedido != null)
            //        {
            //            IdPedidoPicking = objE_Pedido.IdPedido;

            //            //verificar ingreso de N/S
            //            List<MovimientoAlmacenBE> lst_MovimientoNS = new List<MovimientoAlmacenBE>();
            //            lst_MovimientoNS = new MovimientoAlmacenBL().ListaNotaSalidaPendientePedido(objE_Pedido.IdPedido);

            //            if (lst_MovimientoNS.Count > 0)
            //            {
            //                string NumeroNS = "";
            //                foreach (var item in lst_MovimientoNS)
            //                {
            //                    NumeroNS = NumeroNS + ", " + item.DescAlmacen + ":"+ item.Numero;
            //                }
            //                XtraMessageBox.Show("No se puede iniciar el picking faltan recibir N/S." +  NumeroNS, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }

            //            MovimientoPedidoBE objBE_MovimientoPedidoPicking = null;
            //            MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
            //            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

            //            //Verifica situación
            //            objBE_MovimientoPedidoPicking = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

            //            if (objBE_MovimientoPedidoPicking.Preparacion == false)
            //            {
            //                lblMensajePicking.Text = " Inicia Preparación (PICKING)";
            //                btnInicioPicking.Enabled = true;
            //                btnFinPicking.Enabled = false;
            //            }
            //            else 
            //            {
            //                if (objBE_MovimientoPedidoPicking.Preparado == false)
            //                {
            //                    btnInicioPicking.Enabled = false;
            //                    btnFinPicking.Enabled = true;
            //                }
            //                else {
            //                    lblMensajePicking.Text = "El Pedido N°"+ txtNumero.Text +" terminó picking a las "+ objBE_MovimientoPedidoPicking.FechaPreparado.ToString();
            //                }

            //            }

            //            txtCodigo.EditValue = "";
            //            txtNumero.EditValue = "";
            //            txtCodigo.Focus();
            //        }
            //        else
            //        {
            //            IdPedidoPicking = 0;
            //            XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }






            //        //if (txtNumero.Text.Length < 2)
            //        //{
            //        //    return;
            //        //}

            //        //if (txtNumero.Text == "")
            //        //{
            //        //    XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //    txtNumero.Focus();
            //        //    return;
            //        //}

            //        //string Situacion = "";

            //        //PedidoBE objE_Pedido = null;
            //        //objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumero.Text);

            //        //if (objE_Pedido != null)
            //        //{

            //        //    //verificar ingreso de N/S
            //        //    List<MovimientoAlmacenBE> lst_MovimientoNS = new List<MovimientoAlmacenBE>();
            //        //    lst_MovimientoNS = new MovimientoAlmacenBL().ListaNotaSalidaPendientePedido(objE_Pedido.IdPedido);

            //        //    if (lst_MovimientoNS.Count > 0)
            //        //    {
            //        //        string NumeroNS = "";
            //        //        foreach (var item in lst_MovimientoNS)
            //        //        {
            //        //            NumeroNS = NumeroNS + ", " + item.DescAlmacen + ":"+ item.Numero;
            //        //        }
            //        //        XtraMessageBox.Show("No se puede iniciar el picking faltan recibir N/S." +  NumeroNS, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //        return;
            //        //    }


            //        //    //string SituacionPedido = "<NO ESPECIFICADO>";
            //        //    //PedidoBL objBL_Pedido = new PedidoBL();
            //        //    //objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, objE_Pedido.IdPedido, Parametros.ints, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

            //        //    MovimientoPedidoBE objBE_MovimientoPedidoPicking = null;
            //        //    MovimientoPedidoBE objBE_MovimientoPedidoPickingEstado2 = null;
            //        //    MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
            //        //    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

            //        //    //Verifica situación
            //        //    objBE_MovimientoPedidoPicking = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

            //        //    if (objBE_MovimientoPedidoPicking.Preparacion == false) Situacion = " Inicia Preparación (PICKING)";
            //        //    if (objBE_MovimientoPedidoPicking.Preparacion == true) Situacion = " Está en Preparación (PICKING) a las " + objBE_MovimientoPedidoPicking.FechaPreparacion;

            //        //    objBE_MovimientoPedido.IdPedido = objE_Pedido.IdPedido;
            //        //    objBE_MovimientoPedido.Preparado = true;
            //        //    objBE_MovimientoPedido.IdAuxiliar = Convert.ToInt32(cboPersonaPicking.EditValue);
            //        //    objBE_MovimientoPedido.FlagCierre = false;

            //        //    if (objBE_MovimientoPedidoPicking.FechaPreparacion != null &&
            //        //        objBE_MovimientoPedidoPicking.FechaHoraServidor >= objBE_MovimientoPedidoPicking.FechaPreparacion.Value.AddMinutes(1))
            //        //    {
            //        //        objBE_MovimientoPedido.FlagCierre = true;
            //        //    }

            //        //    objBL_MovimientoPedido.ActualizaCierrePicking(objBE_MovimientoPedido);

            //        //    //Verifica
            //        //    objBE_MovimientoPedidoPickingEstado2 = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

            //        //    if (objBE_MovimientoPedidoPickingEstado2.FechaPreparacion > DateTime.Now.AddMinutes(1))
            //        //    {
            //        //        if (objBE_MovimientoPedidoPickingEstado2.Preparacion == true && objBE_MovimientoPedidoPickingEstado2.Preparado == false) Situacion = " cambió a Picking Terminado";
            //        //    }
            //        //    else
            //        //    {
            //        //        if (objBE_MovimientoPedidoPickingEstado2.Preparacion == true && objBE_MovimientoPedidoPickingEstado2.Preparado == true) Situacion = " Terminó PICKING a las " + objBE_MovimientoPedidoPickingEstado2.FechaPreparado.ToString();
            //        //    }


            //        //    lblMensajePicking.Text = "El Pedido N° " + objE_Pedido.Numero + Situacion;
            //        //    txtCodigo.EditValue = "";
            //        //    txtNumero.EditValue = "";
            //        //    txtCodigo.Focus();
            //        //}
            //        //else
            //        //{
            //        //    XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //}
            //        ////else  // Periodo anterior
            //        ////{
            //        ////    objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo - 1, txtNumero.Text);
            //        ////    if (objE_Pedido != null)
            //        ////    {
            //        ////        PedidoBL objBL_Pedido = new PedidoBL();
            //        ////        objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, objE_Pedido.IdPedido, Convert.ToInt32(cboSituacionAlmacen.EditValue), Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
            //        ////        XtraMessageBox.Show("El Pedido ha cambiado de situación a : " + cboSituacionAlmacen.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ////        // XtraMessageBox.Show("El Pedido está ha cambiado de situación a : " + objE_Pedido.DescSituacionAlmacen[0].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ////        txtNumero.Text = "";
            //        ////        txtNumero.Focus();
            //        ////    }
            //        ////    else
            //        ////    {
            //        ////        XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        ////    }
            //        ////}

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtNumeroEmbalaje_KeyUp(object sender, KeyEventArgs e)
        {

            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (txtNumeroEmbalaje.Text.Length < 2)
            //        {
            //            return;
            //        }

            //        if (txtNumeroEmbalaje.Text == "")
            //        {
            //            XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtNumeroEmbalaje.Focus();
            //            return;
            //        }

            //        string Situacion = "";

            //        PedidoBE objE_Pedido = null;
            //        objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroEmbalaje.Text);

            //        if (objE_Pedido != null)
            //        {
            //            //string SituacionPedido = "<NO ESPECIFICADO>";
            //            //PedidoBL objBL_Pedido = new PedidoBL();
            //            //objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, objE_Pedido.IdPedido, Parametros.ints, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

            //            MovimientoPedidoBE objBE_MovimientoPedidoEmbalaje = null;
            //            MovimientoPedidoBE objBE_MovimientoPedidoEmbalajeEstado2 = null;
            //            MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
            //            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

            //            //Buscar situación de picking
            //            MovimientoPedidoBE objBE_MovimientoPedidoPicking = null;
            //            objBE_MovimientoPedidoPicking = objBL_MovimientoPedido.SeleccionaChequeo(objE_Pedido.IdPedido);
            //            if (objBE_MovimientoPedidoPicking.IdChequeador == 0)
            //            {
            //                XtraMessageBox.Show("No se puede registrar el embalaje, El pedido no tiene CHEQUEO, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }


            //            //Verifica situación
            //            objBE_MovimientoPedidoEmbalaje = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

            //            if (objBE_MovimientoPedidoEmbalaje.EnPT == false) Situacion = " Inicia Embalaje a las " + DateTime.Now.TimeOfDay.ToString();
            //            if (objBE_MovimientoPedidoEmbalaje.EnPT == true) Situacion = " Está en Embalaje a las " + objBE_MovimientoPedidoEmbalaje.FechaPT;

            //            objBE_MovimientoPedido.IdPedido = objE_Pedido.IdPedido;
            //            objBE_MovimientoPedido.Embalado = true;
            //            objBE_MovimientoPedido.IdEmbalador = Convert.ToInt32(cboPersonaEmbalaje.EditValue);
            //            objBE_MovimientoPedido.FlagCierre = false;

            //            if (objBE_MovimientoPedidoEmbalaje.FechaPT != null &&
            //                objBE_MovimientoPedidoEmbalaje.FechaHoraServidor >= objBE_MovimientoPedidoEmbalaje.FechaPT.Value.AddMinutes(1))
            //            {
            //                if (txtNumeroBultos.Text.Trim().Length == 0)
            //                {
            //                    XtraMessageBox.Show("Ingresar cantidad de Bultos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    txtNumeroBultos.Focus();
            //                    return;
            //                } 
            //                objBE_MovimientoPedido.FlagCierre = true;
            //            }

            //            objBL_MovimientoPedido.ActualizaCierreEmbalaje2(objBE_MovimientoPedido);

            //            //Verifica
            //            objBE_MovimientoPedidoEmbalajeEstado2 = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

            //            if (objBE_MovimientoPedidoEmbalajeEstado2.FechaPT > DateTime.Now.AddMinutes(1))
            //            {
            //                if (objBE_MovimientoPedidoEmbalajeEstado2.EnPT == true && objBE_MovimientoPedidoEmbalajeEstado2.Embalado == false) Situacion = " cambió a Embalaje Terminado";
            //            }
            //            else
            //            {
            //                if (objBE_MovimientoPedidoEmbalajeEstado2.EnPT == true && objBE_MovimientoPedidoEmbalajeEstado2.Embalado == true) Situacion = " Terminó Embalaje a las " + objBE_MovimientoPedidoEmbalajeEstado2.FechaEmbalado.ToString();
            //            }


            //            lblMensajeEmbalaje.Text = "El Pedido N° " + objE_Pedido.Numero + Situacion;
            //            txtCodigoEmbalaje.EditValue = "";
            //            txtNumeroEmbalaje.EditValue = "";
            //            txtCodigoEmbalaje.Focus();
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }


            //    }
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



            #region "Anterior"

            /*
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtNumeroEmbalaje.Text.Length < 2)
                    {
                        return;
                    }

                    if (txtNumeroEmbalaje.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroEmbalaje.Focus();
                        return;
                    }

                    if (txtNumeroBultos.Text.Trim().Length == 0)
                    {
                        XtraMessageBox.Show("Ingresar cantidad de Bultos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroBultos.Focus();
                        return;
                    } 

                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroEmbalaje.Text);

                    if (objE_Pedido != null)
                    {
                        //string SituacionPedido = "<NO ESPECIFICADO>";
                        //PedidoBL objBL_Pedido = new PedidoBL();
                        //objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, objE_Pedido.IdPedido, Convert.ToInt32(cboSituacionAlmacen.EditValue), Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

                        MovimientoPedidoBE objBE_MovimientoPedidoPicking = null;
                        MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                        MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                        //Buscar situación de picking
                        objBE_MovimientoPedidoPicking = objBL_MovimientoPedido.SeleccionaChequeo(objE_Pedido.IdPedido);
                        if (objBE_MovimientoPedidoPicking.IdAuxiliar == 0)
                        {
                            XtraMessageBox.Show("El Pedido tiene que Pasar por PICKING, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //Inicio Embalaje



                        //Cargar con valores
                        objBE_MovimientoPedido.IdPedido = objE_Pedido.IdPedido;
                        objBE_MovimientoPedido.IdEmbalador = Convert.ToInt32(cboPersonaEmbalaje.EditValue);
                        objBE_MovimientoPedido.EnPT = true;
                        objBE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtNumeroBultos.EditValue);
                        objBL_MovimientoPedido.ActualizaCierreEmbalaje(objBE_MovimientoPedido);

                        lblMensajeEmbalaje.Text = "El Pedido N° " + objE_Pedido.Numero + " Cambió a Embalado";
                        txtCodigoEmbalaje.Text = "";
                        txtNumeroBultos.Text = "";
                        txtNumeroEmbalaje.Text = "";
                        txtCodigoEmbalaje.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }



                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            #endregion


        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            //if (txtCodigo.Text.Trim().Length > 0)
            //{
            //    cboPersonaPicking.EditValue = Convert.ToInt32(txtCodigo.Text.Trim());
            //    txtMensajePicking.Text = "";
            //}

        }

        private void txtCodigoEmbalaje_EditValueChanged(object sender, EventArgs e)
        {
            //if (txtCodigoEmbalaje.Text.Trim().Length > 0)
            //{
            //    cboPersonaEmbalaje.EditValue = Convert.ToInt32(txtCodigoEmbalaje.Text.Trim());
            //    txtMensajeEmbalaje.Text = "";
            //}

        }

        private void txtNumeroBultos_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtCodigoEmbalaje.Focus();
            //    //btnFinEmbalaje.Focus();
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void txtCodigoSolicitud_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCodigoSolicitud.Text.Trim().Length > 0)
            {
                cboPersonaPickingSolicitud.EditValue = Convert.ToInt32(txtCodigoSolicitud.Text.Trim());
                lblMensajePickingSolicitud.Text = "";
            }
        }

        private void txtCodigoSolicitud_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigoSolicitud.Text.Trim().Length > 0)
                {
                    cboPersonaPickingSolicitud.EditValue = Convert.ToInt32(txtCodigoSolicitud.Text.Trim());
                    lblMensajePickingSolicitud.Text = "";
                    txtNumeroSolicitud.Focus();
                    txtNumeroSolicitud.SelectAll();
                }
            }
        }

        private void txtNumeroSolicitud_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtNumeroSolicitud.Text.Length < 2)
                    {
                        return;
                    }

                    if (txtNumeroSolicitud.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar un N° de Solicitud", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroSolicitud.Focus();
                        return;
                    }

                    SolicitudProductoBE objE_SolicitudProducto = null;// new SolicitudProductoBE();
                    objE_SolicitudProducto = new SolicitudProductoBL().SeleccionaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intTipoDocSolicitudProducto, txtNumeroSolicitud.Text.Trim());

                    if (objE_SolicitudProducto != null)
                    {
                        if (objE_SolicitudProducto.DescAuxiliar.Length > 1)
                        {
                            lblMensajePickingSolicitud.Text = "La Solicitud N° " + objE_SolicitudProducto.Numero + " En proceso por " + objE_SolicitudProducto.DescAuxiliar;
                            txtCodigoSolicitud.EditValue = "";
                            txtNumeroSolicitud.EditValue = "";
                            txtCodigoSolicitud.Focus();
                            return;
                        }
                        SolicitudProductoBL objBL_SolicitudProducto = new SolicitudProductoBL();
                        objE_SolicitudProducto.IdAuxiliar = Convert.ToInt32(cboPersonaPickingSolicitud.EditValue);
                        objBL_SolicitudProducto.ActualizaAuxiliar(objE_SolicitudProducto);
                        lblMensajePickingSolicitud.Text = "La Solicitud N° " + objE_SolicitudProducto.Numero + " Inició Picking a las " + lblHora.Text;
                        txtCodigoSolicitud.EditValue = "";
                        txtNumeroSolicitud.EditValue = "";
                        txtCodigoSolicitud.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("El N° de Solicitud no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInicioPicking_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdPedidoPicking > 0)
                {
                    MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                    if (cboPersonaPicking.Text == "")
                    {
                        XtraMessageBox.Show("Debe seleccionar el Personal de picking");
                        return;
                    }

                    objBE_MovimientoPedido.IdPedido = IdPedidoPicking;
                    objBE_MovimientoPedido.IdAuxiliar = Convert.ToInt32(cboPersonaPicking.EditValue);
                    objBE_MovimientoPedido.Preparado = true;
                    objBE_MovimientoPedido.FlagCierre = false;
                    objBL_MovimientoPedido.ActualizaCierrePicking(objBE_MovimientoPedido);

                    btnInicioPicking.Enabled = false;
                    txtMensajePicking.Text = "El pedido " + txtNumero.Text + " Inició Picking a las " + DateTime.Now.ToLongTimeString();
                    txtCodigo.EditValue = "";
                    txtNumero.EditValue = "";
                    cboPersonaPicking.EditValue = 0;
                    IdPedidoPicking = 0;
                    txtNumero.Select();




                    //if (objBE_MovimientoPedidoPicking.Preparacion == true) Situacion = " Está en Preparación (PICKING) a las " + objBE_MovimientoPedidoPicking.FechaPreparacion;

                    //objBE_MovimientoPedido.IdPedido = objE_Pedido.IdPedido;
                    //objBE_MovimientoPedido.Preparado = true;
                    //objBE_MovimientoPedido.IdAuxiliar = Convert.ToInt32(cboPersonaPicking.EditValue);
                    //objBE_MovimientoPedido.FlagCierre = false;

                    //if (objBE_MovimientoPedidoPicking.FechaPreparacion != null &&
                    //    objBE_MovimientoPedidoPicking.FechaHoraServidor >= objBE_MovimientoPedidoPicking.FechaPreparacion.Value.AddMinutes(1))
                    //{
                    //    objBE_MovimientoPedido.FlagCierre = true;
                    //}

                    //objBL_MovimientoPedido.ActualizaCierrePicking(objBE_MovimientoPedido);

                    ////Verifica
                    //objBE_MovimientoPedidoPickingEstado2 = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

                    //if (objBE_MovimientoPedidoPickingEstado2.FechaPreparacion > DateTime.Now.er)
                    //{
                    //    if (objBE_MovimientoPedidoPickingEstado2.Preparacion == true && objBE_MovimientoPedidoPickingEstado2.Preparado == false) Situacion = " cambió a Picking Terminado";
                    //}
                    //else
                    //{
                    //    if (objBE_MovimientoPedidoPickingEstado2.Preparacion == true && objBE_MovimientoPedidoPickingEstado2.Preparado == true) Situacion = " Terminó PICKING a las " + objBE_MovimientoPedidoPickingEstado2.FechaPreparado.ToString();
                    //}


                    //lblMensajePicking.Text = "El Pedido N° " + objE_Pedido.Numero + Situacion;
                    //txtCodigo.EditValue = "";
                    //txtNumero.EditValue = "";
                    //txtCodigo.Focus();
                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinPicking_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdPedidoPicking > 0)
                {
                    MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                    objBE_MovimientoPedido.IdPedido = IdPedidoPicking;
                    objBE_MovimientoPedido.IdAuxiliar = Convert.ToInt32(cboPersonaPicking.EditValue);
                    objBE_MovimientoPedido.Preparado = true;
                    objBE_MovimientoPedido.FlagCierre = true;
                    objBL_MovimientoPedido.ActualizaCierrePicking(objBE_MovimientoPedido);
                    btnFinPicking.Enabled = false;
                    txtMensajePicking.Text = "El pedido N° " + txtNumero.Text + " Finalizó Picking a  las " + DateTime.Now.ToLongTimeString(); ;
                    txtCodigo.EditValue = "";
                    txtNumero.Text = "";
                    IdPedidoPicking = 0;
                    cboPersonaPicking.EditValue = 0;
                    txtNumero.Select();
                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInicioEmbalaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdPedidoEmbalaje > 0)
                {
                    if (cboPersonaEmbalaje.Text == "")
                    {
                        XtraMessageBox.Show("Ud. debe seleccionar el personal de chequeo.");
                        return;
                    }


                    MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                    objBE_MovimientoPedido.IdPedido = IdPedidoEmbalaje;
                    objBE_MovimientoPedido.IdEmbalador = Convert.ToInt32(cboPersonaEmbalaje.EditValue);
                    objBE_MovimientoPedido.Embalado = true;
                    objBE_MovimientoPedido.FlagCierre = false;
                    objBE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtNumeroBultos.EditValue);
                    objBE_MovimientoPedido.PesoKg = Convert.ToDecimal(txtPeso.EditValue);
                    objBL_MovimientoPedido.ActualizaCierreEmbalaje2(objBE_MovimientoPedido);

                    btnInicioEmbalaje.Enabled = false;
                    txtMensajeEmbalaje.Text = "El pedido " + txtNumero.Text + " Inició Embalaje a las " + DateTime.Now.ToLongTimeString();
                    txtCodigoEmbalaje.EditValue = "";
                    txtNumeroEmbalaje.EditValue = "";
                    txtNumeroEmbalaje.Select();
                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinEmbalaje_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdPedidoEmbalaje > 0)
                {
                    if (Convert.ToInt32(txtNumeroBultos.EditValue) > 0 && Convert.ToDecimal(txtPeso.EditValue) > 0)
                    {
                        MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                        MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                        objBE_MovimientoPedido.IdPedido = IdPedidoEmbalaje;
                        objBE_MovimientoPedido.IdEmbalador = Convert.ToInt32(cboPersonaEmbalaje.EditValue);
                        objBE_MovimientoPedido.Embalado = true;
                        objBE_MovimientoPedido.FlagCierre = true;
                        objBE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtNumeroBultos.EditValue);
                        objBE_MovimientoPedido.PesoKg = Convert.ToDecimal(txtPeso.EditValue);
                        objBL_MovimientoPedido.ActualizaCierreEmbalaje2(objBE_MovimientoPedido);

                        btnFinEmbalaje.Enabled = false;
                        lblNumeroBulto.Visible = false;
                        txtNumeroBultos.Visible = false;

                        lblPeso.Visible = false;
                        txtPeso.Visible = false;

                        txtMensajeEmbalaje.Text = "El pedido " + txtNumeroEmbalaje.Text + " Terminó Embalaje a las " + DateTime.Now.ToLongTimeString();
                        txtCodigoEmbalaje.EditValue = "";
                        txtNumeroEmbalaje.EditValue = "";
                        txtNumeroEmbalaje.Select();
                    }
                    else
                    {
                        XtraMessageBox.Show("Tiene que ingresar el bulto y peso para continuar..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroBultos.Select();
                    }
                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtNumero.Text.Length < 2)
                        return;

                    if (txtNumero.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumero.Focus();
                        return;
                    }

                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim());

                    #region "Versión 1"
                    if (objE_Pedido != null)
                    {
                        txtMensajePicking.ForeColor = Color.Black;
                        IdPedidoPicking = objE_Pedido.IdPedido;
                        txtDescCliente.Text = objE_Pedido.DescCliente;
                        txtDescVendedor.Text = objE_Pedido.DescVendedor;
                        txtDescTienda.Text = objE_Pedido.DescTienda;
                        txtDescSituacion.Text = objE_Pedido.DescSituacion;
                        txtDescFormaPago.Text = objE_Pedido.DescFormaPago;
                        txtObservacion.Text = objE_Pedido.Observacion;
                        txtMensajePicking.Text = "Ud. Puede Iniciar Picking";

                        //verificar ingreso de N/S
                        #region "Validar Nota de Salida Pendiente"
                        
                        List<MovimientoAlmacenBE> lst_MovimientoNS = new List<MovimientoAlmacenBE>();
                        lst_MovimientoNS = new MovimientoAlmacenBL().ListaNotaSalidaPendientePedido(objE_Pedido.IdPedido);

                        if (lst_MovimientoNS.Count > 0)
                        {
                            string NumeroNS = "";
                            foreach (var item in lst_MovimientoNS)
                            {
                                NumeroNS = NumeroNS + ", " + item.DescAlmacen + ":" + item.Numero;
                            }
                            XtraMessageBox.Show("No se puede iniciar el picking, falta recibir el stock Físico N/S." + NumeroNS, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        #endregion

                        MovimientoPedidoBE objBE_MovimientoPedidoPicking = null;
                        MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                        MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                        //Verifica situación
                        objBE_MovimientoPedidoPicking = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

                        if (objE_Pedido.IdFormaPago != Parametros.intContado) //add 02012018
                        {
                            if (!objBE_MovimientoPedidoPicking.Recibido) ///add 170816
                            {
                                XtraMessageBox.Show("No se puede iniciar el picking falta RECIBIR el pedido.\nOpción disponible en Gestión de Pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        if (objBE_MovimientoPedidoPicking.Preparacion == false)
                        {
                            //lblMensajePicking.Text = " Inicia Preparación (PICKING)";
                            btnInicioPicking.Enabled = true;
                            btnFinPicking.Enabled = false;
                            txtCodigo.Select();
                            txtCodigo.SelectAll();
                            //btnInicioPicking.Focus();
                        }
                        else
                        {
                            if (objBE_MovimientoPedidoPicking.Preparado == false)
                            {

                                //if (objE_Pedido.IdFormaPago != Parametros.intContado)//add 230118
                                //{
                                    cboPersonaPicking.EditValue = objBE_MovimientoPedidoPicking.IdAuxiliar;
                                    txtMensajePicking.Text = "Ud. Puede Finalizar Picking";
                                    btnInicioPicking.Enabled = false;
                                    btnFinPicking.Enabled = true;
                                    ////txtCodigo.Focus();
                                    //btnFinPicking.Focus();
                                    btnFinPicking_Click(sender, e);
                                //}
                                //else
                                //{
                                //    txtMensajePicking.Text = "El Pedido N°" + txtNumero.Text + " inició picking a las " + objBE_MovimientoPedidoPicking.FechaPreparacion.ToString();
                                //    foreach (var item in Parametros.pListaPersonal)
                                //    {
                                //        if (item.IdPersona == objBE_MovimientoPedidoPicking.IdAuxiliar)
                                //        {
                                //            txtObservacion.Text = "PICKING: " + item.ApeNom + " " + objE_Pedido.Observacion;
                                //        }
                                //    }
                                //    txtMensajePicking.ForeColor = Color.Red;
                                //}
                            }
                            else
                            {
                                txtMensajePicking.Text = "El Pedido N°" + objBE_MovimientoPedidoPicking.Numero + " terminó picking a las " + objBE_MovimientoPedidoPicking.FechaPreparado.ToString();
                                txtObservacion.Text = "PICKING: " + objBE_MovimientoPedidoPicking.DescAuxiliar + " " + objE_Pedido.Observacion;

                                //foreach (var item in Parametros.pListaPersonal)
                                //{
                                //    if (item.IdPersona == objBE_MovimientoPedidoPicking.IdAuxiliar)
                                //    {
                                //        txtObservacion.Text = "PICKING: " + item.ApeNom + " " + objE_Pedido.Observacion;
                                //    }
                                //}
                                IdPedidoPicking = 0;
                                txtNumero.Text = "";
                                txtNumero.Select();
                                //txtCodigo.Properties.ReadOnly = true;
                            }

                        }

                    }
                    else
                    {
                        IdPedidoPicking = 0;
                        XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    #endregion 


                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroEmbalaje_KeyDown(object sender, KeyEventArgs e)
        {
            #region  'Antes'
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (txtNumeroEmbalaje.Text.Length < 2)
            //        {
            //            return;
            //        }

            //        if (txtNumeroEmbalaje.Text == "")
            //        {
            //            XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtNumeroEmbalaje.Focus();
            //            return;
            //        }

            //        PedidoBE objE_Pedido = null;

            //        objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodoEmbalaje.EditValue), txtNumeroEmbalaje.Text.Trim());

            //        if (objE_Pedido != null)
            //        {
            //            IdPedidoEmbalaje = objE_Pedido.IdPedido;
            //            txtDescClienteEmbalaje.Text = objE_Pedido.DescCliente;
            //            txtDescVendedorEmbalaje.Text = objE_Pedido.DescVendedor;
            //            txtDescTiendaEmbalaje.Text = objE_Pedido.DescTienda;
            //            txtDescSituacionEmbalaje.Text = objE_Pedido.DescSituacion;
            //            txtDescFormaPagoEmbalaje.Text = objE_Pedido.DescFormaPago;
            //            txtObservacionEmbalaje.Text = objE_Pedido.Observacion;
            //            txtMensajeEmbalaje.Text = "Ud. Puede Iniciar Embalaje";


            //            lblNumeroBulto.Visible = false;//LimpiarBulto
            //            txtNumeroBultos.Visible = false;
            //            txtNumeroBultos.EditValue = 0;
            //            txtNumeroBultos.Properties.ReadOnly = false;
            //            btnGrabarBulto.Visible = false;

            //            //MovimientoPedidoBE objBE_MovimientoPedidoEmbalaje = null;
            //            //MovimientoPedidoBE objBE_MovimientoPedidoEmbalajeEstado2 = null;
            //            //MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
            //            //MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

            //            //Buscar situación de Embalaje
            //            MovimientoPedidoBE objBE_MovimientoPedidoEmbalaje = null;
            //            MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
            //            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

            //            objBE_MovimientoPedidoEmbalaje = objBL_MovimientoPedido.SeleccionaChequeo(objE_Pedido.IdPedido);
            //            if (objBE_MovimientoPedidoEmbalaje.IdChequeador == 0)
            //            {
            //                XtraMessageBox.Show("No se puede registrar el embalaje, El pedido no tiene CHEQUEO, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }


            //            //Verifica situación
            //            objBE_MovimientoPedidoEmbalaje = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

            //            if (objBE_MovimientoPedidoEmbalaje.EnPT == false)
            //            {
            //                //lblMensajeEmbalaje.Text = " Inicia Preparación (Embalaje)";
            //                btnInicioEmbalaje.Enabled = true;
            //                btnFinEmbalaje.Enabled = false;
            //                lblNumeroBulto.Visible = false;
            //                txtNumeroBultos.Visible = false;
            //                txtCodigoEmbalaje.Select();
            //                //btnInicioEmbalaje.Focus();
            //            }
            //            else
            //            {
            //                if (objBE_MovimientoPedidoEmbalaje.Embalado == false)
            //                {
            //                    cboPersonaEmbalaje.EditValue = objBE_MovimientoPedidoEmbalaje.IdEmbalador;
            //                    txtMensajeEmbalaje.Text = "Ud. Puede Finalizar Embalaje";
            //                    btnInicioEmbalaje.Enabled = false;
            //                    btnFinEmbalaje.Enabled = true;
            //                    lblNumeroBulto.Visible = true;
            //                    txtNumeroBultos.Visible = true;
            //                    txtNumeroBultos.Select();
            //                }
            //                else
            //                {
            //                    lblNumeroBulto.Visible = true;
            //                    txtNumeroBultos.Visible = true;
            //                    txtNumeroBultos.EditValue = objBE_MovimientoPedidoEmbalaje.CantidadBulto;
            //                    txtNumeroBultos.Properties.ReadOnly = true;
            //                    btnGrabarBulto.Visible = true;
            //                    cboPersonaEmbalaje.EditValue = objBE_MovimientoPedidoEmbalaje.IdPersona;
            //                    txtMensajeEmbalaje.Text = "El Pedido N°" + txtNumero.Text + " terminó Embalaje a las " + objBE_MovimientoPedidoEmbalaje.FechaPreparado.ToString();
            //                }

            //            }
            //            //lblMensajeEmbalaje.Text = "El Pedido N° " + objE_Pedido.Numero + Situacion;
            //            //txtCodigoEmbalaje.EditValue = "";
            //            //txtNumeroEmbalaje.EditValue = "";
            //            //txtCodigoEmbalaje.Focus();
            //        }
            //        else
            //        {
            //            IdPedidoEmbalaje = 0;
            //            XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //        }


            //    }
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtNumeroEmbalaje.Text.Length < 2)
                    {
                        return;
                    }

                    if (txtNumeroEmbalaje.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroEmbalaje.Focus();
                        return;
                    }

                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodoEmbalaje.EditValue), txtNumeroEmbalaje.Text.Trim());

                    if (objE_Pedido != null)
                    {
                        IdPedidoEmbalaje = objE_Pedido.IdPedido;
                        txtDescClienteEmbalaje.Text = objE_Pedido.DescCliente;
                        txtDescVendedorEmbalaje.Text = objE_Pedido.DescVendedor;
                        txtDescTiendaEmbalaje.Text = objE_Pedido.DescTienda;
                        txtDescSituacionEmbalaje.Text = objE_Pedido.DescSituacion;
                        txtDescFormaPagoEmbalaje.Text = objE_Pedido.DescFormaPago;
                        txtObservacionEmbalaje.Text = objE_Pedido.Observacion;
                        txtMensajeEmbalaje.Text = "Ud. Puede Iniciar Embalaje";

                        lblNumeroBulto.Visible = false;//LimpiarBulto
                        txtNumeroBultos.Visible = false;

                        lblPeso.Visible = false;
                        txtPeso.Visible = false;

                        txtNumeroBultos.EditValue = 0;
                        txtPeso.EditValue = 0;

                        txtNumeroBultos.Properties.ReadOnly = false;
                        txtPeso.Properties.ReadOnly = false;

                        btnGrabarBulto.Visible = false;

                        //MovimientoPedidoBE objBE_MovimientoPedidoEmbalaje = null;
                        //MovimientoPedidoBE objBE_MovimientoPedidoEmbalajeEstado2 = null;
                        //MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                        //MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                        //Buscar situación de Embalaje
                        MovimientoPedidoBE objBE_MovimientoPedidoEmbalaje = null;
                        MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                        MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                        objBE_MovimientoPedidoEmbalaje = objBL_MovimientoPedido.SeleccionaChequeo(objE_Pedido.IdPedido);
                        if (objBE_MovimientoPedidoEmbalaje.IdChequeador == 0)
                        {
                            XtraMessageBox.Show("No se puede registrar el embalaje, El pedido no tiene CHEQUEO, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //Verifica situación
                        objBE_MovimientoPedidoEmbalaje = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

                        if (objBE_MovimientoPedidoEmbalaje.EnPT == false)
                        {
                            //lblMensajeEmbalaje.Text = " Inicia Preparación (Embalaje)";
                            btnInicioEmbalaje.Enabled = true;
                            btnFinEmbalaje.Enabled = false;

                            lblNumeroBulto.Visible = false;
                            txtNumeroBultos.Visible = false;

                            lblPeso.Visible = false;
                            txtPeso.Visible = false;

                            txtCodigoEmbalaje.Select();
                            //btnInicioEmbalaje.Focus();
                        }
                        else
                        {
                            if (objBE_MovimientoPedidoEmbalaje.Embalado == false)
                            {
                                cboPersonaEmbalaje.EditValue = objBE_MovimientoPedidoEmbalaje.IdEmbalador;
                                txtMensajeEmbalaje.Text = "Ud. Puede Finalizar Embalaje";
                                btnInicioEmbalaje.Enabled = false;
                                btnFinEmbalaje.Enabled = true;

                                lblPeso.Visible = true;
                                txtPeso.Visible = true;

                                lblNumeroBulto.Visible = true;
                                txtNumeroBultos.Visible = true;
                                txtNumeroBultos.Select();
                            }
                            else
                            {
                                lblNumeroBulto.Visible = true;
                                txtNumeroBultos.Visible = true;

                                lblPeso.Visible = true;
                                txtPeso.Visible = true;

                                txtNumeroBultos.EditValue = objBE_MovimientoPedidoEmbalaje.CantidadBulto;
                                txtNumeroBultos.Properties.ReadOnly = true;

                                txtPeso.EditValue = objBE_MovimientoPedidoEmbalaje.PesoKg;
                                txtPeso.Properties.ReadOnly = true;

                                btnGrabarBulto.Visible = true;
                                cboPersonaEmbalaje.EditValue = objBE_MovimientoPedidoEmbalaje.IdPersona;
                                txtMensajeEmbalaje.Text = "El Pedido N°" + txtNumero.Text + " terminó Embalaje a las " + objBE_MovimientoPedidoEmbalaje.FechaPreparado.ToString();
                            }

                        }
                        //lblMensajeEmbalaje.Text = "El Pedido N° " + objE_Pedido.Numero + Situacion;
                        //txtCodigoEmbalaje.EditValue = "";
                        //txtNumeroEmbalaje.EditValue = "";
                        //txtCodigoEmbalaje.Focus();
                    }
                    else
                    {
                        IdPedidoEmbalaje = 0;
                        XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboPersonaPicking.EditValue = 0;

                if (txtCodigo.Text.Length<5)
                {
                    cboPersonaPicking.EditValue = Convert.ToInt32(txtCodigo.Text.Trim());
                }else
                {
                    foreach (var item in Parametros.pListaPersonal)
                    {
                        if (item.Dni == txtCodigo.Text.Trim())
                        {
                            cboPersonaPicking.EditValue = item.IdPersona;
                        }
                    }
                }


                txtMensajePicking.Text = "";
                if (btnInicioPicking.Enabled)
                {
                    btnInicioPicking_Click(sender, e);
                    //btnInicioPicking.Focus();
                }
                else
                {
                    btnFinPicking_Click(sender, e);
                    //btnFinPicking.Focus();
                }
                    


                //if (txtCodigo.Text.Trim().Length > 0)
                //{
                //    cboPersonaPicking.EditValue = Convert.ToInt32(txtCodigo.Text.Trim());
                //}
                //    lblMensajePicking.Text = "";
                //    if (btnInicioPicking.Enabled)
                //        btnInicioPicking.Focus();
                //    else
                //        btnFinPicking.Focus();
            }
        }

        private void txtNumeroBultos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPeso.Select();
            }

        }

        private void txtCodigoEmbalaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboPersonaEmbalaje.EditValue = 0;

                if (txtCodigoEmbalaje.Text.Length < 5)
                {
                    cboPersonaEmbalaje.EditValue = Convert.ToInt32(txtCodigoEmbalaje.Text.Trim());
                }
                else
                {
                    foreach (var item in Parametros.pListaPersonal)
                    {
                        if (item.Dni == txtCodigoEmbalaje.Text.Trim())
                        {
                            cboPersonaEmbalaje.EditValue = item.IdPersona;
                        }
                    }
                }



                txtMensajeEmbalaje.Text = "";
                if (btnInicioEmbalaje.Enabled)
                {
                    //btnInicioEmbalaje.Focus();
                    btnInicioEmbalaje_Click(sender,e);
                }
                else
                {
                    //btnFinEmbalaje.Focus();
                    btnFinEmbalaje_Click(sender, e);
                }
                    


                //if (txtCodigoEmbalaje.Text.Trim().Length > 0)
                //{
                //    cboPersonaEmbalaje.EditValue = Convert.ToInt32(txtCodigoEmbalaje.Text.Trim());
                //    lblMensajeEmbalaje.Text = "";
                //    if (btnInicioEmbalaje.Enabled)
                //        btnInicioEmbalaje.Focus();
                //    else
                //        btnFinEmbalaje.Focus();
                //}
            }
        }

        private void btnGrabarBulto_Click(object sender, EventArgs e)
        {
            #region 'Antes'
            //if (btnGrabarBulto.Text == "Editar")
            //{
            //    btnGrabarBulto.Text = "Grabar";
            //    txtNumeroBultos.Properties.ReadOnly = false;
            //    txtNumeroBultos.Select();
            //    txtNumeroBultos.SelectAll();
            //}
            //else
            //{
            //    if (Convert.ToInt32(txtNumeroBultos.EditValue) > 0)
            //    {
            //        MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
            //        MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();
            //        objE_MovimientoPedido.IdPedido = IdPedidoEmbalaje;
            //        objE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtNumeroBultos.EditValue);

            //        objBL_MovimientoPedido.ActualizaCantidadBulto(objE_MovimientoPedido);
            //        txtMensajeEmbalaje.Text = "Se actualizó la cantidad de bultos al pedido N°" + txtNumeroEmbalaje.Text;
            //        btnGrabarBulto.Visible = false;

            //        txtNumeroBultos.Visible = false;
            //        lblNumeroBulto.Visible = false;
            //        txtCodigoEmbalaje.EditValue = "";
            //        txtNumeroEmbalaje.EditValue = "";
            //        txtNumeroEmbalaje.Select();
            //        btnGrabarBulto.Text = "Editar";
            //    }
            //}
            #endregion
            if (btnGrabarBulto.Text == "Editar")
            {
                btnGrabarBulto.Text = "Grabar";
                txtNumeroBultos.Properties.ReadOnly = false;
                txtNumeroBultos.Select();
                txtNumeroBultos.SelectAll();
            }
            else
            {
                if (Convert.ToInt32(txtNumeroBultos.EditValue) > 0 || Convert.ToDecimal(txtPeso.EditValue) > 0)
                {
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                    MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();
                    objE_MovimientoPedido.IdPedido = IdPedidoEmbalaje;
                    objE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtNumeroBultos.EditValue);
                    objE_MovimientoPedido.PesoKg = Convert.ToDecimal(txtPeso.EditValue);

                    objBL_MovimientoPedido.ActualizaCantidadBulto(objE_MovimientoPedido);
                    txtMensajeEmbalaje.Text = "Se actualizó la cantidad de bultos al pedido N°" + txtNumeroEmbalaje.Text;
                    btnGrabarBulto.Visible = false;

                    txtNumeroBultos.Visible = false;
                    lblNumeroBulto.Visible = false;

                    txtPeso.Visible = false;
                    lblPeso.Visible = false;

                    txtCodigoEmbalaje.EditValue = "";
                    txtNumeroEmbalaje.EditValue = "";
                    txtNumeroEmbalaje.Select();
                    btnGrabarBulto.Text = "Editar";
                }
                else
                {
                    XtraMessageBox.Show("Tiene que ingresar el bulto y peso para continuar..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region "Metodos"

        #endregion


        private void txtNumeroNS_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtNumeroNS.Text.Length < 2)
                    {
                        return;
                    }

                    if (txtNumeroNS.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar un Número de Nota de Sálida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroNS.Focus();
                        return;
                    }

                    List<MovimientoAlmacenBE> lstMovimientoAlmacen = null;
                    lstMovimientoAlmacen = new MovimientoAlmacenBL().SeleccionaNumero(Parametros.intEmpresaId,Parametros.intPeriodo,0,0,Parametros.intTipMovSalida, txtNumeroNS.Text.Trim());

                    if (lstMovimientoAlmacen != null)
                    {
                        IdMovimientoAlmacenPicking = lstMovimientoAlmacen[0].IdMovimientoAlmacen;
                        txtAlmacenOrigen.Text = lstMovimientoAlmacen[0].DescAlmacen;
                        txtAlmacenDestino.Text = lstMovimientoAlmacen[0].DescAlmacenDestino;
                        txtFechaNS.Text = lstMovimientoAlmacen[0].Fecha.ToString();
                        txtUsuario.Text = lstMovimientoAlmacen[0].Usuario;
                        txtObservacionNS.Text = lstMovimientoAlmacen[0].Observaciones;
                        txtMensajePickingNS.Text = "Ud. Puede Iniciar Picking";

                        ////MovimientoPedidoBE objBE_MovimientoPedidoPicking = null;
                        ////MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                        ////MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                        //////Verifica situación
                        ////objBE_MovimientoPedidoPicking = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

                        ////if (lstMovimientoAlmacen[0].Preparado) ///add 170816
                        ////{
                        ////    XtraMessageBox.Show("No se puede iniciar el picking falta RECIBIR el pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ////    return;
                        ////}


                        if (lstMovimientoAlmacen[0].Preparacion == false)
                        {
                            //lblMensajePicking.Text = " Inicia Preparación (PICKING)";
                            btnInicioPickingNS.Enabled = true;
                            btnFinPickingNS.Enabled = false;
                            txtCodigoNS.Select();
                            txtCodigoNS.SelectAll();
                            //btnInicioPicking.Focus();
                        }
                        else
                        {
                            if (lstMovimientoAlmacen[0].Preparado == false)
                            {
                                cboPersonaPickingNS.EditValue = lstMovimientoAlmacen[0].IdAuxiliar;
                                txtMensajePickingNS.Text = "Ud. Puede Finalizar Picking";
                                btnInicioPickingNS.Enabled = false;
                                btnFinPickingNS.Enabled = true;
                                //txtCodigo.Focus();
                                btnFinPickingNS.Focus();
                            }
                            else
                            {
                                txtMensajePickingNS.Text = "La Nota de Salida N°" + txtNumeroNS.Text + " terminó picking a las " + lstMovimientoAlmacen[0].FechaPreparado.ToString();
                            }

                        }
                    }
                    else
                    {
                        IdMovimientoAlmacenPicking = 0;
                        XtraMessageBox.Show("El N° de NS no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoNS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMensajePicking.Text = "";
                if (btnInicioPicking.Enabled)
                    btnInicioPicking.Focus();
                else
                    btnFinPicking.Focus();
            }
        }

        private void btnInicioPickingNS_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdMovimientoAlmacenPicking > 0)
                {
                    MovimientoAlmacenBE objBE_MovimientoAlmacen = new MovimientoAlmacenBE();
                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();

                    if (cboPersonaPickingNS.Text == "")
                    {
                        XtraMessageBox.Show("Debe seleccionar el Personal de picking");
                        return;
                    }

                    objBE_MovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacenPicking;
                    objBE_MovimientoAlmacen.IdAuxiliar = Convert.ToInt32(cboPersonaPickingNS.EditValue);
                    objBE_MovimientoAlmacen.Preparado = true;
                    objBE_MovimientoAlmacen.FlagCierre = false;
                    objBL_MovimientoAlmacen.ActualizaCierrePicking(objBE_MovimientoAlmacen);

                    btnInicioPickingNS.Enabled = false;
                    txtMensajePickingNS.Text = "La NS N°" + txtNumero.Text + " Inició Picking a las " + DateTime.Now.ToLongTimeString();
                    txtCodigoNS.EditValue = "";
                    txtNumeroNS.EditValue = "";
                    txtNumero.Select();
                }
                else
                {
                    XtraMessageBox.Show("El N° de NS no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinPickingNS_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdMovimientoAlmacenPicking > 0)
                {
                    MovimientoAlmacenBE objBE_MovimientoAlmacen = new MovimientoAlmacenBE();
                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();

                    objBE_MovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacenPicking;
                    objBE_MovimientoAlmacen.IdAuxiliar = Convert.ToInt32(cboPersonaPickingNS.EditValue);
                    objBE_MovimientoAlmacen.Preparado = true;
                    objBE_MovimientoAlmacen.FlagCierre = true;
                    objBL_MovimientoAlmacen.ActualizaCierrePicking(objBE_MovimientoAlmacen);

                    btnFinPickingNS.Enabled = false;
                    txtMensajePickingNS.Text = "La NS N° " + txtNumeroNS.Text + " Finalizó Picking a las " + DateTime.Now.ToLongTimeString(); ;
                    txtCodigoNS.EditValue = "";
                    txtNumeroNS.EditValue = "";
                    txtNumeroNS.Select();
                }
                else
                {
                    XtraMessageBox.Show("El N° de NS no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoNS_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCodigoNS.Text.Trim().Length > 0)
            {
                cboPersonaPickingNS.EditValue = Convert.ToInt32(txtCodigoNS.Text.Trim());
                txtMensajePickingNS.Text = "";
            }
        }


        private void txtNumeroEmbalajeNS_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtNumeroEmbalajeNS.Text.Length < 2)
                    {
                        return;
                    }

                    if (txtNumeroEmbalajeNS.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar un Número de Nota de Sálida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroEmbalajeNS.Focus();
                        return;
                    }

                    List<MovimientoAlmacenBE> lstMovimientoAlmacen = null;
                    lstMovimientoAlmacen = new MovimientoAlmacenBL().SeleccionaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, 0, 0, Parametros.intTipMovSalida, txtNumeroEmbalajeNS.Text.Trim());

                    if (lstMovimientoAlmacen != null)
                    {
                        IdMovimientoAlmacenEmbalaje = lstMovimientoAlmacen[0].IdMovimientoAlmacen;
                        txtAlmacenOrigenNS.Text = lstMovimientoAlmacen[0].DescAlmacen;
                        txtAlmacenDestinoNS.Text = lstMovimientoAlmacen[0].DescAlmacenDestino;
                        txtFechaEmbalajeNS.Text = lstMovimientoAlmacen[0].Fecha.ToString();
                        txtUsuarioEmbalajeNS.Text = lstMovimientoAlmacen[0].Usuario;
                        txtObservacionEmbalajeNS.Text = lstMovimientoAlmacen[0].Observaciones;
                        txtMensajeEmbalajeNS.Text = "Ud. Puede Iniciar Embalaje";



                        lblNumeroBultoNS.Visible = false;//LimpiarBulto
                        txtNumeroBultosNS.Visible = false;
                        txtNumeroBultosNS.EditValue = 0;
                        txtNumeroBultosNS.Properties.ReadOnly = false;
                        btnGrabarBultoNS.Visible = false;


                        ////MovimientoPedidoBE objBE_MovimientoPedidoEmbalaje = null;
                        ////MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                        ////MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                        //////Verifica situación
                        ////objBE_MovimientoPedidoEmbalaje = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

                        if (!lstMovimientoAlmacen[0].Preparado) ///add 170816
                        {
                            XtraMessageBox.Show("No se puede iniciar el Embalaje falta realizar el Picking", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }



                        if (lstMovimientoAlmacen[0].FlagEmbalaje == false)
                        {
                            //lblMensajeEmbalaje.Text = " Inicia Preparación (Embalaje)";
                            btnInicioEmbalajeNS.Enabled = true;
                            btnFinEmbalajeNS.Enabled = false;
                            txtCodigoEmbalajeNS.Select();
                            txtCodigoEmbalajeNS.SelectAll();
                            //btnInicioEmbalaje.Focus();
                        }
                        else
                        {
                            if (lstMovimientoAlmacen[0].FlagEmbalado == false)
                            {
                                btnInicioEmbalajeNS.Enabled = false;
                                btnFinEmbalajeNS.Enabled = true;
                                lblNumeroBultoNS.Visible = true;
                                txtNumeroBultosNS.Visible = true;
                                


                                cboPersonaEmbalajeNS.EditValue = lstMovimientoAlmacen[0].IdEmbalador;
                                txtMensajeEmbalajeNS.Text = "Ud. Puede Finalizar Embalaje";
                                btnInicioEmbalajeNS.Enabled = false;
                                btnFinEmbalajeNS.Enabled = true;
                                //txtCodigo.Focus();
                                //btnFinEmbalajeNS.Focus();

                                txtNumeroBultosNS.Select();
                            }
                            else
                            {
                                txtMensajeEmbalajeNS.Text = "La Nota de Salida N°" + txtNumeroEmbalajeNS.Text + " terminó Embalaje a las " + lstMovimientoAlmacen[0].FechaEmbalado.ToString();
                            }

                        }
                    }
                    else
                    {
                        IdMovimientoAlmacenEmbalaje = 0;
                        XtraMessageBox.Show("El N° de NS no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInicioEmbalajeNS_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdMovimientoAlmacenEmbalaje > 0)
                {
                    if (cboPersonaEmbalajeNS.Text == "")
                    {
                        XtraMessageBox.Show("Ud. debe seleccionar el personal de Embalaje.");
                        return;
                    }


                    MovimientoAlmacenBE objBE_MovimientoAlmacen = new MovimientoAlmacenBE();
                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();

                    objBE_MovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacenEmbalaje;
                    objBE_MovimientoAlmacen.IdEmbalador = Convert.ToInt32(cboPersonaEmbalajeNS.EditValue);
                    objBE_MovimientoAlmacen.FlagEmbalado = true;
                    objBE_MovimientoAlmacen.FlagCierre = false;
                    objBE_MovimientoAlmacen.CantidadBulto = Convert.ToInt32(txtNumeroBultosNS.EditValue);
                    objBL_MovimientoAlmacen.ActualizaCierreEmbalaje(objBE_MovimientoAlmacen);

                    btnInicioEmbalajeNS.Enabled = false;
                    txtMensajeEmbalajeNS.Text = "La nota de Salida N°" + txtNumeroEmbalajeNS.Text + " Inició Embalaje a las " + DateTime.Now.ToLongTimeString();
                    txtCodigoEmbalajeNS.EditValue = "";
                    txtNumeroEmbalajeNS.EditValue = "";
                    txtNumeroEmbalajeNS.Select();
                }
                else
                {
                    XtraMessageBox.Show("El N° Almacen no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinEmbalajeNS_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdMovimientoAlmacenEmbalaje > 0)
                {
                    MovimientoAlmacenBE objBE_MovimientoAlmacen = new MovimientoAlmacenBE();
                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();

                    objBE_MovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacenEmbalaje;
                    objBE_MovimientoAlmacen.IdEmbalador = Convert.ToInt32(cboPersonaEmbalajeNS.EditValue);
                    objBE_MovimientoAlmacen.CantidadBulto = Convert.ToInt32(txtNumeroBultosNS.EditValue);
                    objBE_MovimientoAlmacen.FlagEmbalado = true;
                    objBE_MovimientoAlmacen.FlagCierre = true;
                    objBE_MovimientoAlmacen.CantidadBulto = Convert.ToInt32(txtNumeroBultosNS.EditValue);
                    objBL_MovimientoAlmacen.ActualizaCierreEmbalaje(objBE_MovimientoAlmacen);

                    btnFinEmbalajeNS.Enabled = false;
                    lblNumeroBultoNS.Visible = false;
                    txtNumeroBultosNS.Visible = false;
                    txtMensajeEmbalajeNS.Text = "La Nota de Salida N° " + txtNumeroEmbalajeNS.Text + " Terminó Embalaje a las " + DateTime.Now.ToLongTimeString();
                    txtCodigoEmbalajeNS.EditValue = "";
                    txtNumeroEmbalajeNS.EditValue = "";
                    txtNumeroEmbalajeNS.Select();
                }
                else
                {
                    XtraMessageBox.Show("El N° Almacen no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabarBultoNS_Click(object sender, EventArgs e)
        {
            if (btnGrabarBultoNS.Text == "Editar")
            {
                btnGrabarBultoNS.Text = "Grabar";
                txtNumeroBultosNS.Properties.ReadOnly = false;
                txtNumeroBultosNS.Select();
                txtNumeroBultosNS.SelectAll();
            }
            else
            {
                if (Convert.ToInt32(txtNumeroBultosNS.EditValue) > 0)
                {
                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                    MovimientoAlmacenBE objE_MovimientoAlmacen = new MovimientoAlmacenBE();
                    objE_MovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacenEmbalaje;
                    objE_MovimientoAlmacen.CantidadBulto = Convert.ToInt32(txtNumeroBultosNS.EditValue);

                    objBL_MovimientoAlmacen.ActualizaCantidadBulto(objE_MovimientoAlmacen);
                    txtMensajeEmbalajeNS.Text = "Se actualizó la cantidad de bulto N/S N°" + txtNumeroEmbalajeNS.Text;
                    btnGrabarBultoNS.Visible = false;

                    txtNumeroBultosNS.Visible = false;
                    lblNumeroBultoNS.Visible = false;
                    txtCodigoEmbalajeNS.EditValue = "";
                    txtNumeroEmbalajeNS.EditValue = "";
                    txtNumeroEmbalajeNS.Select();
                    btnGrabarBultoNS.Text = "Editar";
                }
            }
        }

        private void txtCodigoEmbalajeNS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMensajeEmbalaje.Text = "";
                if (btnInicioEmbalajeNS.Enabled)
                    btnInicioEmbalajeNS.Focus();
                else
                    btnFinEmbalajeNS.Focus();
            }
        }

        private void txtCodigoEmbalajeNS_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCodigoEmbalajeNS.Text.Trim().Length > 0)
            {
                cboPersonaEmbalajeNS.EditValue = Convert.ToInt32(txtCodigoEmbalajeNS.Text.Trim());
                txtMensajeEmbalajeNS.Text = "";
            }
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnInicioEmbalaje.Enabled)
                    btnInicioEmbalaje.Focus();
                else
                    btnFinEmbalaje.Focus();
                //btnFinEmbalaje.Focus();
            }
        }
    }
}