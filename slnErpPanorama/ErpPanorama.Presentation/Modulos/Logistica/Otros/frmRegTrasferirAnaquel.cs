using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Principal;
using System.Reflection;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmRegTrasferirAnaquel : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int SituacionBulto = 0;
        public int IdBulto = 0;
        public string NumeroBulto = "";
        public int IdProducto = 0;
        public int Cantidad = 0;

        #endregion

        #region "Eventos"

        public frmRegTrasferirAnaquel()
        {
            InitializeComponent();
        }

        private void frmRegTrasferirAnaquel_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescAlmacen", "IdAlmacen", true);
            cboAlmacen.EditValue = Parametros.intAlmAnaqueles;
            BSUtils.LoaderLook(cboUbicacion, new UbicacionProductoBL().ListaCodigo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto), "DescUbicacion", "IdUbicacionProducto", true);

            //Cantidad bulto
            BultoBE objE_Bulto = new BultoBE();
            objE_Bulto = new BultoBL().Selecciona(Parametros.intEmpresaId, IdBulto, Parametros.intBULRecibido);
            if (objE_Bulto != null)
            {
                Cantidad = objE_Bulto.Cantidad;
                txtCantidad.EditValue = Cantidad;
            }
            this.Text = "Pasar Bulto " + NumeroBulto + " --> Anaquel "; 

            txtCantidad.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIngreso())
            {
                BultoBE objE_Bulto = new BultoBE();
                BultoBL objBL_Bulto = new BultoBL();

                objE_Bulto.IdAlmacen = Parametros.intAlmAnaqueles;
                objE_Bulto.IdBulto = IdBulto;
                objE_Bulto.IdProducto = IdProducto;
                objE_Bulto.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_Bulto.IdEmpresa = Parametros.intEmpresaId;

                objBL_Bulto.ActualizaStockAnaqueles(objE_Bulto);

                if (Convert.ToInt32(txtCantidad.EditValue) == Cantidad)
                {
                    DescargarBulto();
                }


                this.Close();
            }
        }

        private void DescargarBulto()
        {
            try
            {
                BultoBE objE_Bulto = null;
                objE_Bulto = new BultoBL().SeleccionaNumeroBulto(Parametros.intEmpresaId, NumeroBulto, Parametros.intBULRecibido);
                if (objE_Bulto != null)
                {

                    //Establecer Los Datos de Cabecera de la Transferencia del Bulto
                    TransferenciaBultoBE objE_TransferenciaBulto = new TransferenciaBultoBE();
                    objE_TransferenciaBulto.IdTransferenciaBulto = 0;
                    objE_TransferenciaBulto.IdEmpresa = Parametros.intEmpresaId;
                    objE_TransferenciaBulto.IdTienda = Parametros.intTiendaId;
                    objE_TransferenciaBulto.Periodo = Parametros.intPeriodo;
                    objE_TransferenciaBulto.IdTipoDocumento = Parametros.intTipoDocTransferencia;
                    objE_TransferenciaBulto.NumeroDocumento = ObtenerCorrelativo();
                    objE_TransferenciaBulto.FechaMovimiento = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    objE_TransferenciaBulto.IdAlmacenOrigen = Parametros.intAlmBultos;
                    objE_TransferenciaBulto.IdAlmacenDestino = Parametros.intAlmCentralUcayali;
                    objE_TransferenciaBulto.Observacion = "Transferencia de Bultos";
                    objE_TransferenciaBulto.IdMovimientoAlmacenIngreso = 0;
                    objE_TransferenciaBulto.IdMovimientoAlmacenSalida = 0;
                    objE_TransferenciaBulto.FlagEstado = true;
                    objE_TransferenciaBulto.Usuario = Parametros.strUsuarioLogin;
                    objE_TransferenciaBulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    List<TransferenciaBultoDetalleBE> lstListaTransferenciaDetalle = new List<TransferenciaBultoDetalleBE>();

                    //Establecer los datos del detalle de la transferencia de bultos
                    TransferenciaBultoDetalleBE objE_DetalleTransferencia = new TransferenciaBultoDetalleBE();
                    objE_DetalleTransferencia.IdTransferenciaBultoDetalle = 0;
                    objE_DetalleTransferencia.IdTransferenciaBulto = 0;
                    objE_DetalleTransferencia.IdBulto = objE_Bulto.IdBulto;
                    objE_DetalleTransferencia.IdProducto = objE_Bulto.IdProducto;
                    objE_DetalleTransferencia.Cantidad = objE_Bulto.Cantidad;
                    objE_DetalleTransferencia.IdKardexBulto = 0;
                    objE_DetalleTransferencia.IdKardex = 0;
                    objE_DetalleTransferencia.FlagEstado = true;
                    objE_DetalleTransferencia.Abreviatura = objE_Bulto.Abreviatura;
                    objE_DetalleTransferencia.PrecioUnitario = objE_Bulto.PrecioUnitario;
                    objE_DetalleTransferencia.Usuario = Parametros.strUsuarioLogin;
                    objE_DetalleTransferencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_DetalleTransferencia.IdEmpresa = Parametros.intEmpresaId;
                    lstListaTransferenciaDetalle.Add(objE_DetalleTransferencia);

                    //Realizamos la transferencia de bultos
                    TransferenciaBultoBL objBL_TransferenciaBulto = new TransferenciaBultoBL();
                    objBL_TransferenciaBulto.Inserta(objE_TransferenciaBulto, lstListaTransferenciaDetalle);

                    XtraMessageBox.Show("El Bulto se descargó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    XtraMessageBox.Show("El numero de bulto no existe por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //gcBulto.DataSource = new BultoBL().ListaNumeroBulto();
                //gcBulto.RefreshDataSource();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnGrabar.Focus();
            }

        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (Convert.ToInt32(cboUbicacion.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Seleccione la Ubicación.\n";
                flag = true;
            }

            if (txtCantidad.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese cantidad de transferencia.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtCantidad.EditValue) > Cantidad)
            {
                strMensaje = strMensaje + "- Solamente puede transferir "+ Cantidad +" Piezas del Bulto.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private string ObtenerCorrelativo()
        {
            List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
            string sNumero = "";
            mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocTransferencia, Parametros.intPeriodo);
            if (mListaNumero.Count > 0)
            {
                sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
            }

            return sNumero;
        }

        #endregion


    }
}