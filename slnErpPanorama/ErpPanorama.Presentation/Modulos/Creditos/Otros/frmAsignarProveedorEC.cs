using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using System.Security.Principal;
using ErpPanorama.Presentation.Funciones;
using System.Transactions;

namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    public partial class frmAsignarProveedorEC : DevExpress.XtraEditors.XtraForm
    {

        #region "Propieadades"
        private List<FacturaCompraBE> mLista = new List<FacturaCompraBE>();

        public int IdEmpresa { get; set; }
        public int IdDocumentoVenta { get; set; }

        public Decimal Importe { get; set; }

        public int Origen = 0; //0=DocumentoVenta; 1=CuentaBanco
        public int IdCuentaBancoDetalle = 0;

        public int IdProveedor = 0;
        public int IdMotivo = 0;
        public int IdPedido = 0;
        public string NumeroPedido = "";
        public string FormaPago = "";
        public string AbreviaturaBanco="";
        private string AbreviaturaMoneda = "";


        #endregion

        #region "Eventos"
        public frmAsignarProveedorEC()
        {
            InitializeComponent();
        }

        private void frmAsignarProveedorEC_Load(object sender, EventArgs e)
        {
            Parametros.pListaProveedores = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);
            BSUtils.LoaderLook(cboProveedor, Parametros.pListaProveedores, "DescProveedor", "IdProveedor", false);
            txTotal.EditValue = Importe;

            gvFacturaCompra.OptionsBehavior.Editable = false;
            //gridColumn10.OptionsColumn.ReadOnly = false;
            chkPorFactura.Checked = false;

        }

        //private void btnGrabar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeCreditoCobranzas || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion)//contadoras
        //        {

        //            IdProveedor = Convert.ToInt32(cboProveedor.EditValue);

        //            CuentaBancoDetalleBE objE_CuentaBanco = new CuentaBancoDetalleBE();
        //            CuentaBancoDetalleBL objBL_Documento = new CuentaBancoDetalleBL();
        //            objE_CuentaBanco.IdCuentaBancoDetalle = IdCuentaBancoDetalle;
        //            objE_CuentaBanco.IdProveedor = IdProveedor;
        //            objE_CuentaBanco.Observacion = "";
        //            objE_CuentaBanco.DescProveedor = (cboProveedor.Text);
        //            objE_CuentaBanco.Usuario = Parametros.strUsuarioLogin;
        //            objE_CuentaBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

        //            objBL_Documento.ActualizaProveedor(objE_CuentaBanco);

        //            //if (txtNumero.Text.Trim().Length > 0)
        //            //{
        //            //    NumeroPedido = " N° " + txtNumero.Text.Trim();
        //            //}

        //            this.DialogResult = DialogResult.OK;
        //            this.Close();
        //            //}
        //        }
        //        else
        //        {
        //            XtraMessageBox.Show("Ud. no cuenta con los permisos necesarios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
            mLista = new FacturaCompraBL().ListadoPendientesProveedor(Parametros.intIdPanoramaDistribuidores, IdProveedor, null);
            gcFacturaCompra.DataSource = mLista;
        }

        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            
            string numFActura = "";
            Decimal ImporteTotal1 = 0;
            int IdFacturaCompra = 0;

            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ygomez" || Parametros.strUsuarioLogin == "mmurrugarra" || Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeCreditoCobranzas || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion)//contadoras
                    {

                        IdProveedor = Convert.ToInt32(cboProveedor.EditValue);


                        if (chkPorFactura.Checked == true)
                        {
                            foreach (var item2 in mLista)
                            {
                                if (item2.FlagPagado)

                                    ImporteTotal1 = ImporteTotal1 + item2.Importe;
                            }

                            if (Importe == ImporteTotal1)
                            {
                                foreach (var item in mLista)
                                {
                                    //if(objE_FacturaCompra.FlagPagado)
                                    if (item.FlagPagado)
                                    {
                                        numFActura = numFActura + " , " + item.NumeroDocumento;

                                        if (Importe == ImporteTotal1)
                                        {
                                            InsertaEstadoCuentaProveedor(item.Importe, item.IdFacturaCompra);
                                            CuentaBancoDetalleBE objE_CuentaBanco = new CuentaBancoDetalleBE();
                                            CuentaBancoDetalleBL objBL_Documento = new CuentaBancoDetalleBL();
                                            objE_CuentaBanco.IdCuentaBancoDetalle = IdCuentaBancoDetalle;
                                            objE_CuentaBanco.IdProveedor = IdProveedor;
                                            objE_CuentaBanco.DescProveedor = (cboProveedor.Text);

                                            objE_CuentaBanco.Usuario = Parametros.strUsuarioLogin;
                                            objE_CuentaBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                            objE_CuentaBanco.Observacion = numFActura;
                                            objBL_Documento.ActualizaProveedor(objE_CuentaBanco);
                                            //ImporteTotal1 = 0;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item in mLista)
                                {
                                    //if(objE_FacturaCompra.FlagPagado)
                                    //if (item.FlagPagado)
                                    //{
                                    //    numFActura = numFActura + " , " + item.NumeroDocumento;

                                    //    if (Importe == ImporteTotal1)
                                    //    {
                                    //        InsertaEstadoCuentaProveedor(item.Importe, item.IdFacturaCompra);
                                    //        CuentaBancoDetalleBE objE_CuentaBanco = new CuentaBancoDetalleBE();
                                    //        CuentaBancoDetalleBL objBL_Documento = new CuentaBancoDetalleBL();
                                    //        objE_CuentaBanco.IdCuentaBancoDetalle = IdCuentaBancoDetalle;
                                    //        objE_CuentaBanco.IdProveedor = IdProveedor;
                                    //        objE_CuentaBanco.DescProveedor = (cboProveedor.Text);

                                    //        objE_CuentaBanco.Usuario = Parametros.strUsuarioLogin;
                                    //        objE_CuentaBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    //        objE_CuentaBanco.Observacion = numFActura;
                                    //        objBL_Documento.ActualizaProveedor(objE_CuentaBanco);
                                    //        //ImporteTotal1 = 0;
                                    //    }

                                    //}
                                }

                                XtraMessageBox.Show("La Suma de las factura es diferente el importe .", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {

                            InsertaEstadoCuentaProveedor(Importe, IdFacturaCompra);
                            CuentaBancoDetalleBE objE_CuentaBanco = new CuentaBancoDetalleBE();
                            CuentaBancoDetalleBL objBL_Documento = new CuentaBancoDetalleBL();
                            objE_CuentaBanco.IdCuentaBancoDetalle = IdCuentaBancoDetalle;
                            objE_CuentaBanco.IdProveedor = IdProveedor;
                            objE_CuentaBanco.DescProveedor = (cboProveedor.Text);

                            objE_CuentaBanco.Usuario = Parametros.strUsuarioLogin;
                            objE_CuentaBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_CuentaBanco.Observacion = numFActura;
                            objBL_Documento.ActualizaProveedor(objE_CuentaBanco);

                        }



                    }
                    else
                    {
                        XtraMessageBox.Show("Ud. no cuenta con los permisos necesarios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ts.Complete();
                }

                    
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkPorFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPorFactura.Checked == true)
            {
                gvFacturaCompra.OptionsBehavior.Editable = true;
                IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                mLista = new FacturaCompraBL().ListadoPendientesProveedor(Parametros.intIdPanoramaDistribuidores, IdProveedor, null);
                gcFacturaCompra.DataSource = mLista;
            }
            else
            {
                gvFacturaCompra.OptionsBehavior.Editable = false;
                IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                mLista = new FacturaCompraBL().ListadoPendientesProveedor(Parametros.intIdPanoramaDistribuidores, IdProveedor, null);
                gcFacturaCompra.DataSource = mLista;
            }
        }

        private void cboProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnConsultar.Focus();
                //SendKeys.Send("{TAB}");
            }
        }

        private void btnConsultar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                //btnGrabar.Focus();
                SendKeys.Send("{TAB}");
            }
        }

        private void txTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
                //SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Metodos
        private void  InsertaEstadoCuentaProveedor(Decimal Importe, int IdFacturaCompra)
        {
            string MonedaEstadoCuenta = "US$";

            #region "Estado Cuenta"
            //Cargamos Cuenta Banco detalle
            try
            {
                CuentaBancoDetalleBE objBE_CuentaBancoDetalle = new CuentaBancoDetalleBE();
                objBE_CuentaBancoDetalle = new CuentaBancoDetalleBL().Selecciona(IdCuentaBancoDetalle);

                ProveedorBE objE_Proveedor = new ProveedorBE();
                objE_Proveedor = new ProveedorBL().Selecciona(IdProveedor);

                string Numero = "";

                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPagoBancoCuenta, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                }
                //Datos del estado de cuenta
                EstadoCuentaProveedorBE objE_EstadoCuentaProveedor = new EstadoCuentaProveedorBE();
                EstadoCuentaProveedorBL objBL_EstadoCuentaProveedor = new EstadoCuentaProveedorBL();

                //objE_EstadoCuentaProveedor.IdEstadoCuentaProveedor = 0;
                objE_EstadoCuentaProveedor.IdEmpresa = Parametros.intEmpresaId;
                objE_EstadoCuentaProveedor.Periodo = Parametros.intPeriodo;
                objE_EstadoCuentaProveedor.IdProveedor = objE_Proveedor.IdProveedor;
                objE_EstadoCuentaProveedor.NumeroDocumento = "B" + Numero;
                objE_EstadoCuentaProveedor.Fecha = objBE_CuentaBancoDetalle.Fecha; //FechaDeposito;
                objE_EstadoCuentaProveedor.Concepto = ("PAGO " + AbreviaturaBanco + " " + AbreviaturaMoneda + " " + "  " + objE_EstadoCuentaProveedor.NumeroDocumento).ToString().Trim();
                objE_EstadoCuentaProveedor.FechaVencimiento = null;
                objE_EstadoCuentaProveedor.IdMoneda = Parametros.intDolares;
                objE_EstadoCuentaProveedor.Importe = Importe;
                if (Importe == 0)
                {
                    objE_EstadoCuentaProveedor.Importe = objBE_CuentaBancoDetalle.Importe;
                    Importe = objE_EstadoCuentaProveedor.Importe = objBE_CuentaBancoDetalle.Importe;
                }
                objE_EstadoCuentaProveedor.TipoMovimiento = "A";
                objE_EstadoCuentaProveedor.IdMotivo = 0;

                if(IdFacturaCompra==0)
                {
                    objE_EstadoCuentaProveedor.IdFacturaCompra = null;
                }
                else
                {
                    objE_EstadoCuentaProveedor.IdFacturaCompra = IdFacturaCompra;
                }
                objE_EstadoCuentaProveedor.IdCuentaBancoDetalle = objBE_CuentaBancoDetalle.IdCuentaBancoDetalle;
                objE_EstadoCuentaProveedor.ImporteAnt = 0;
                objE_EstadoCuentaProveedor.IdPersona = Parametros.intUsuarioId;
                objE_EstadoCuentaProveedor.UsuarioRegistro = Parametros.strUsuarioLogin;
                objE_EstadoCuentaProveedor.FechaRegistro = Parametros.dtFechaHoraServidor;
                objE_EstadoCuentaProveedor.Observacion = "";
                objE_EstadoCuentaProveedor.Saldo = Importe;
                objE_EstadoCuentaProveedor.FlagEstado = true;
                objE_EstadoCuentaProveedor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_EstadoCuentaProveedor.Usuario = Parametros.strUsuarioLogin;
                objBL_EstadoCuentaProveedor.Inserta(objE_EstadoCuentaProveedor);

                NumeracionDocumentoBL objDL_NumeracionDocumento = new NumeracionDocumentoBL();
                objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPagoBancoCuenta, Parametros.intPeriodo);

                #endregion

                XtraMessageBox.Show("Se registro " + MonedaEstadoCuenta + " " + Importe + " al Estado de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            
        }
        #endregion

 
    }
}