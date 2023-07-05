using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Funciones.ConsultarSUNAT;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.Text.RegularExpressions;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Ecommerce
{
    public partial class frmRegPagoCliente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ClienteBE> lstCliente;

        public List<CClienteCorreo> mListaClienteCorreoOrigen = new List<CClienteCorreo>();
        public List<CClienteAsociado> mListaClienteAsociadoOrigen = new List<CClienteAsociado>();
        public List<CClienteTracking> mListaClienteTrackingOrigen = new List<CClienteTracking>();
        public Contribuyente myRuc = new Contribuyente();
        public PersonaReniec myInfo = new PersonaReniec();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }
        public int wIdPedidoWeb;
        public String wPedidoWeb;
        public String wDescCliente;

        public Operacion pOperacionEncuesta { get; set; }
        int rbuton = 0;

        int _IdCliente = 0;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }
        private int IdClienteEncuesta = 0;

        public string NumeroDocumento { get; set; }
        public string DescCliente { get; set; }
        public string AbrevDocimicilio { get; set; }
        public string Direccion { get; set; }
        public string NumDireccion { get; set; }
        public string DescDistrito { get; set; }
        public string DescProvincia { get; set; }
        public string DescDepartamento { get; set; }

        public int IdClasificacionCliente { get; set; }
        public string TipoClasificacion { get; set; }
  
        #endregion

        #region "Eventos"

        public frmRegPagoCliente()
        {
            InitializeComponent();
        }

        private void frmManClienteMinoristaEdit_Load(object sender, EventArgs e)
        {
            dteFecPago.EditValue = DateTime.Now;
            this.Text = "Registro de Pago";
            dteFecPago.Focus();
        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void nuevoClienteCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void eliminarClienteCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor = Cursors.WaitCursor;
                ////if (!ValidarIngreso())
                ////{
                //ClienteBL objBL_Cliente = new ClienteBL();
                //ClienteBE objE_Cliente = new ClienteBE();

                //objE_Cliente.IdCliente = IdCliente;
                //objE_Cliente.IdTienda = Parametros.intTiendaId;
                //objE_Cliente.FlagEstado = true;
                //objE_Cliente.Usuario = Parametros.strUsuarioLogin;
                //objE_Cliente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                //objE_Cliente.IdEmpresa = Parametros.intEmpresaId;

                //objE_Cliente.Procede = rbuton;
                //List<ClienteLineaProductoBE> lstClienteLineaProducto = new List<ClienteLineaProductoBE>();

                if (XtraMessageBox.Show("¿Esta seguro de registrar el pago ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    PedidoBL objBL_Pedido = new PedidoBL();
                    objBL_Pedido.RegistroPagoPedidoWeb(wIdPedidoWeb
                                                    , Convert.ToDateTime(dteFecPago.Text)
                                                    , txtedOperacion.Text
                                                    , txtedObs.Text);
                    this.Close();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaAniv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboClasificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtOtroTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void cboDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboDistrito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTipoDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNumeroDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cboVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gcTxtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void gcTxtAbrevDocumento_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void nuevoClienteAsociadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarClienteAsociadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        #endregion

        //#region "Metodos"

        //private bool ValidarIngreso()
        //{
        //    bool flag = false;
        //    string strMensaje = "No se pudo registrar:\n";

        //    if (txtNumeroDocumento.Text.Trim().ToString() == "")
        //    {
        //        strMensaje = strMensaje + "- Ingrese el número de documento.\n";
        //        flag = true;
        //    }

        //    if (txtDescripcion.Text.Trim().ToString() == "")
        //    {
        //        strMensaje = strMensaje + "- Ingrese la descripción del cliente.\n";
        //        flag = true;
        //    }

        //    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoDNI)
        //    {
        //        if (txtNumeroDocumento.Text.Trim().Length != 8)
        //        {
        //            strMensaje = strMensaje + "- El número de Dni debe tener 8 dígitos.\n";
        //            flag = true;
        //        }

        //        if(txtApPaterno.Text.Trim() == "")
        //        {
        //            strMensaje = strMensaje + "- Ingresar Apellido Paterno.\n";
        //            flag = true;
        //        }
        //        if (txtApMaterno.Text.Trim() == "")
        //        {
        //            strMensaje = strMensaje + "- Ingresar Apellido Materno.\n";
        //            flag = true;
        //        }

        //        if (Convert.ToInt32(cboSexo.EditValue) == Parametros.intNinguno)
        //        {
        //            strMensaje = strMensaje + "- Seleccionar el sexo del Cliente.\n";
        //            flag = true;
        //        }
        //    }

        //    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoRUC)
        //    {
        //        if (txtNumeroDocumento.Text.Trim().Length != 11)
        //        {
        //            strMensaje = strMensaje + "- El número de ruc debe tener 11 dígitos.\n";
        //            flag = true;
        //        }

        //        if(txtNumeroDocumento.Text.Trim().Substring(0,2)=="10")
        //        {
        //            if (Convert.ToInt32(cboSexo.EditValue) == Parametros.intNinguno)
        //            {
        //                strMensaje = strMensaje + "- Seleccionar el sexo del Cliente.\n";
        //                flag = true;
        //            }
        //        }
                
        //    }

        //    if (txtDescripcion.Text.Trim().ToString() == "")
        //    {
        //        strMensaje = strMensaje + "- Ingrese el Nombre/Razón social del cliente.\n";
        //        flag = true;
        //    }

        //    if(cboTipoPersona.EditValue.ToString() == "N")
        //    {
        //        if (txtNombres.Text.Trim() == "")
        //        {
        //            strMensaje = strMensaje + "- Ingrese el Nombre del cliente.\n";
        //            flag = true;
        //        }
        //    }
            
        //    if (txtDireccion.Text.Trim().ToString() == "")
        //    {
        //        strMensaje = strMensaje + "- Ingrese la dirección del cliente.\n";
        //        flag = true;
        //    }

        //    #region "Encuesta"
            
        //    //Medio contactado
        //    bool bEncuesta = false;
        //    if (chkFacebook.Checked)
        //        bEncuesta = true;
        //    if (chkRadio.Checked)
        //        bEncuesta = true;
        //    if (chkTv.Checked)
        //        bEncuesta = true;
        //    if (chkRevista.Checked)
        //        bEncuesta = true;
        //    if (chkAmigos.Checked)
        //        bEncuesta = true;
        //    if (chkPanel.Checked)
        //        bEncuesta = true;
        //    if (chkWeb.Checked)
        //        bEncuesta = true;
        //    if (chkOtros.Checked)
        //    {
        //        if (txtEncuestaOtro.Text.Trim().Length == 0)
        //        {
        //            strMensaje = strMensaje + "- Ingresar el otro medio de contacto.\n";
        //            flag = true;
        //        }
        //        else
        //            bEncuesta = true;
        //    }

        //    if(bEncuesta)
        //    {
        //        if(IdClienteEncuesta==0)
        //            pOperacionEncuesta = Operacion.Nuevo;
        //        else
        //            pOperacionEncuesta = Operacion.Modificar;
        //    }
        //    #endregion

        //    if (pOperacion == Operacion.Nuevo)
        //    {
        //        if (!bEncuesta)
        //        {
        //            strMensaje = strMensaje + "- Seleccionar el medio por el cual fue contactado.\n";
        //            flag = true;
        //        }


        //        if (lstCliente != null)
        //        {
        //         //   if (deFechaNac.DateTime.ToShortDateString() == DateTime.Now.ToShortDateString())
	       //         //{
        //         //       strMensaje = strMensaje + "- Ingresa una fecha de nacimiento válida.\n";
        //         //       flag = true;
	       //         //}

        //            var BuscarDocumento = lstCliente.Where(oB => oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
        //            if (BuscarDocumento.Count > 0)
        //            {
        //                strMensaje = strMensaje + "- El número de documento ya existe.\n";
        //                flag = true;
        //            }

        //            var BuscarDescripcion = lstCliente.Where(oB => oB.DescCliente.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
        //            if (BuscarDescripcion.Count > 0)
        //            {
        //                strMensaje = strMensaje + "- La descripción ya existe.\n";
        //                flag = true;
        //            }
        //        }
        //        //asociados
        //        foreach (CClienteAsociado item in mListaClienteAsociadoOrigen)
        //        {
        //            var BuscarNumeroDocumentoAsociado = mListaClienteAsociadoOrigen.Where(oB => oB.NumeroDocumento.ToUpper() == item.NumeroDocumento.ToUpper()).ToList();
        //            if (BuscarNumeroDocumentoAsociado.Count > 1)
        //            {
        //                strMensaje = strMensaje + "- El número de documento del asociado se repite.\n";
        //                flag = true;
        //            }

        //            var BuscarClienteAsociado = mListaClienteAsociadoOrigen.Where(oB => oB.DescCliente.ToUpper() == item.DescCliente.ToUpper()).ToList();
        //            if (BuscarClienteAsociado.Count > 1)
        //            {
        //                strMensaje = strMensaje + "- El nombre del asociado se repite.\n";
        //                flag = true;
        //            }

        //            ClienteBE objE_Cliente = null;
        //            objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, item.NumeroDocumento);
        //            if (objE_Cliente != null)
        //            {
        //                strMensaje = strMensaje + "- El número de documento del asociado se repite en el cliente principal : " + objE_Cliente.NumeroDocumento + " " + objE_Cliente.DescCliente + "\n";
        //                flag = true;
        //            }

        //            objE_Cliente = new ClienteBL().SeleccionaDescripcion(Parametros.intEmpresaId, item.DescCliente);
        //            if (objE_Cliente != null)
        //            {
        //                strMensaje = strMensaje + "- La descripción del asociado se repite en el cliente principal : " + objE_Cliente.NumeroDocumento + " " + objE_Cliente.DescCliente + "\n";
        //                flag = true;
        //            }
        //        }


        //        //Cliente asociados
                
        //        ClienteAsociadoBE ClienteAsociadoBE = null;
        //        ClienteAsociadoBE = new ClienteAsociadoBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text);
        //        if (ClienteAsociadoBE != null)
        //        {
        //            strMensaje = strMensaje + "- El Numero de documento del Cliente ya existe como asociado :" + "\n";
        //            flag = true;
        //        }

        //        ClienteAsociadoBE ClienteAsociadoBE1 = null;
        //        ClienteAsociadoBE1 = new ClienteAsociadoBL().SeleccionaDescripcion(Parametros.intEmpresaId, txtDescripcion.Text);
        //        if (ClienteAsociadoBE1 != null)
        //        {
        //            strMensaje = strMensaje + "- El nombre del Cliente ya existe como asociado :" + "\n";
        //            flag = true;
        //        }
        //    }

        //    if (cboVendedor.Text.Trim().ToString() == "")
        //    {
        //        strMensaje = strMensaje + "- Seleccionar al vendedor.\n";
        //        flag = true;
        //    }

        //    foreach (CClienteCorreo item in mListaClienteCorreoOrigen)
        //    {
        //        var BuscarCorreoAsociado = mListaClienteCorreoOrigen.Where(oB => oB.Email.ToUpper() == item.Email.ToUpper()).ToList();
        //        if (BuscarCorreoAsociado.Count > 1)
        //        {
        //            strMensaje = strMensaje + "- El correo electronico se repite.\n";
        //            flag = true;
        //        }
        //    }

        //    //Validar correo
        //    string Correo = txtEmail.Text.Trim();
        //    if (Correo.Length > 0)
        //    {
        //        if (!ValidarEmail(txtEmail.Text.Trim()))
        //        {
        //            strMensaje = strMensaje + "- Correo electrónico inválido, corregir o dejar en Blanco.\n";
        //            flag = true;
        //        }
        //    }

        //    //Validar correo FE
        //    string CorreoFE = txtEmailFE.Text.Trim();
        //    if(CorreoFE.Length>0)
        //    {
        //        if (!ValidarEmail(txtEmailFE.Text.Trim()))
        //        {
        //            strMensaje = strMensaje + "- Correo de envío de Facturación Electrónica inválido, corregir o dejar en Blanco.\n";
        //            flag = true;
        //        }
        //    }

        //    if (flag)
        //    {
        //        XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        Cursor = Cursors.Default;
        //    }
        //    return flag;
        //}

        //private void CargaClienteCorreo()
        //{
        //    List<ClienteCorreoBE> lstTmpClienteCorreo = null;
        //    lstTmpClienteCorreo = new ClienteCorreoBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente);

        //    foreach (ClienteCorreoBE item in lstTmpClienteCorreo)
        //    {
        //        CClienteCorreo objE_ClienteCorreo = new CClienteCorreo();
        //        objE_ClienteCorreo.IdEmpresa = item.IdEmpresa;
        //        objE_ClienteCorreo.IdClienteCorreo = item.IdClienteCorreo;
        //        objE_ClienteCorreo.IdCliente = item.IdCliente;
        //        objE_ClienteCorreo.Email = item.Email;
        //        objE_ClienteCorreo.TipoOper = item.TipoOper;
        //        mListaClienteCorreoOrigen.Add(objE_ClienteCorreo);
        //    }

        //    bsListadoClienteCorreo.DataSource = mListaClienteCorreoOrigen;
        //    gcClienteCorreo.DataSource = bsListadoClienteCorreo;
        //    gcClienteCorreo.RefreshDataSource();
        //}

        //private void CargaClienteAsociado()
        //{
        //    List<ClienteAsociadoBE> lstTmpClienteAsociado = null;
        //    lstTmpClienteAsociado = new ClienteAsociadoBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente);

        //    foreach (ClienteAsociadoBE item in lstTmpClienteAsociado)
        //    {
        //        CClienteAsociado objE_ClienteAsociado = new CClienteAsociado();
        //        objE_ClienteAsociado.IdEmpresa = item.IdEmpresa;
        //        objE_ClienteAsociado.IdClienteAsociado = item.IdClienteAsociado;
        //        objE_ClienteAsociado.IdCliente = item.IdCliente;
        //        objE_ClienteAsociado.IdTipoDocumento = item.IdTipoDocumento;
        //        //objE_ClienteAsociado.AbrevDocumento = item.AbrevDocumento;
        //        objE_ClienteAsociado.AbrevDocumento = item.AbrevDocumento;
        //        objE_ClienteAsociado.NumeroDocumento = item.NumeroDocumento;
        //        objE_ClienteAsociado.DescCliente = item.DescCliente;
        //        objE_ClienteAsociado.Direccion = item.Direccion;
        //        objE_ClienteAsociado.TipoOper = item.TipoOper;
        //        mListaClienteAsociadoOrigen.Add(objE_ClienteAsociado);
        //    }

        //    bsListadoClienteAsociado.DataSource = mListaClienteAsociadoOrigen;
        //    gcClienteAsociado.DataSource = bsListadoClienteAsociado;
        //    gcClienteAsociado.RefreshDataSource();
        //}

        //private void CargaClienteEncuesta()
        //{
        //    ClienteEncuestaBE objE_Encuesta = null;
        //    objE_Encuesta = new ClienteEncuestaBL().Selecciona(IdCliente);

        //    if (objE_Encuesta != null)
        //    {
        //        chkFacebook.Checked = objE_Encuesta.Facebook;
        //        chkRadio.Checked = objE_Encuesta.Radio;
        //        chkTv.Checked = objE_Encuesta.Television;
        //        chkRevista.Checked = objE_Encuesta.Revista;
        //        chkAmigos.Checked = objE_Encuesta.Amigo;
        //        chkPanel.Checked = objE_Encuesta.Panel;
        //        chkWeb.Checked = objE_Encuesta.Web;
        //        chkInstagram.Checked = objE_Encuesta.Instagram;
        //        chkCorreo.Checked = objE_Encuesta.Web;
        //        chkPeriodico.Checked = objE_Encuesta.Periodico;
        //        chkSms.Checked = objE_Encuesta.Sms;
        //        chkOtros.Checked = objE_Encuesta.Otro;
        //        txtEncuestaOtro.Text = objE_Encuesta.RespuestaOtro;
        //        gcContactadoPor.Enabled = false;
        //        IdClienteEncuesta = objE_Encuesta.IdClienteEncuesta;
        //        pOperacionEncuesta = Operacion.Modificar;
        //    }

        //}

        //private void CargarComboTipoDocumento()
        //{
        //    //repositoryItemLookUpEdit1.DataSource = CargarTipoDocumentoCliente();//new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente);
        //    //repositoryItemLookUpEdit1.ForceInitialize();
        //    //repositoryItemLookUpEdit1.PopulateColumns();
        //    //repositoryItemLookUpEdit1.DisplayMember = "Descripcion";
        //    //repositoryItemLookUpEdit1.ValueMember = "Id";
        //}


        //private void CargaClienteTracking()
        //{
        //    List<ClienteTrackingBE> lstTmpClienteTracking = null;
        //    lstTmpClienteTracking = new ClienteTrackingBL().ListaTodosActivo(IdCliente);

        //    foreach (ClienteTrackingBE item in lstTmpClienteTracking)
        //    {
        //        CClienteTracking objE_ClienteTracking = new CClienteTracking();
        //        objE_ClienteTracking.IdClienteTracking = item.IdClienteTracking;
        //        objE_ClienteTracking.IdCliente = item.IdCliente;
        //        objE_ClienteTracking.FechaRegistro = item.FechaRegistro;
        //        objE_ClienteTracking.Numero = item.Numero;
        //        objE_ClienteTracking.Comentario = item.Comentario;
        //        objE_ClienteTracking.FechaProxima = item.FechaProxima;
        //        objE_ClienteTracking.IdSituacion = item.IdSituacion;
        //        objE_ClienteTracking.DescSituacion = item.DescSituacion;
        //        objE_ClienteTracking.TipoOper = item.TipoOper;
        //        mListaClienteTrackingOrigen.Add(objE_ClienteTracking);
        //    }

        //    bsListadoClienteTracking.DataSource = mListaClienteTrackingOrigen;
        //    gcClienteTracking.DataSource = bsListadoClienteTracking;
        //    gcClienteTracking.RefreshDataSource();
        //}



        //private DataTable CargarTipoDocumentoCliente()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Id", Type.GetType("System.Int32"));
        //    dt.Columns.Add("Descripcion", Type.GetType("System.String"));
        //    DataRow dr;
        //    dr = dt.NewRow();
        //    dr["Id"] = 55;
        //    dr["Descripcion"] = "DNI";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Id"] = 56;
        //    dr["Descripcion"] = "RUC";
        //    dt.Rows.Add(dr);
        //    return dt;
        //}

        //private DataTable CargarTipoPersona()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Id", Type.GetType("System.String"));
        //    dt.Columns.Add("Descripcion", Type.GetType("System.String"));
        //    DataRow dr;
        //    dr = dt.NewRow();
        //    dr["Id"] = "N";
        //    dr["Descripcion"] = "N - NATURAL";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Id"] = "J";
        //    dr["Descripcion"] = "J - JURIDICA";
        //    dt.Rows.Add(dr);
        //    dr = dt.NewRow();
        //    dr["Id"] = "D";
        //    dr["Descripcion"] = "D - SUJETO NO DOMICILIADO";
        //    dt.Rows.Add(dr);
        //    return dt;
        //}

        //private Boolean ValidarEmail(String email)
        //{
        //    String expresion;
        //    expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        //    if (Regex.IsMatch(email, expresion))
        //    {
        //        if (Regex.Replace(email, expresion, String.Empty).Length == 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        //#endregion

        public class CClienteCorreo
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdClienteCorreo { get; set; }
            public Int32 IdCliente { get; set; }
            public String Email { get; set; }
            public Int32 TipoOper { get; set; }

            public CClienteCorreo()
            {

            }
        }

        public class CClienteAsociado
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdClienteAsociado { get; set; }
            public Int32 IdCliente { get; set; }
            public Int32 IdTipoDocumento { get; set; }
            public String AbrevDocumento { get; set; }
            public String NumeroDocumento { get; set; }
            public String DescCliente { get; set; }
            public String Direccion { get; set; }
            public Int32 TipoOper { get; set; }

            public CClienteAsociado()
            {

            }
        }

        public class CClienteTracking
        {
            public Int32 IdClienteTracking { get; set; }
            public Int32 IdCliente { get; set; }
            public DateTime FechaRegistro { get; set; }
            public String Numero { get; set; }
            public String Comentario { get; set; }
            public DateTime FechaProxima { get; set; }
            public Int32 IdSituacion { get; set; }
            public String DescSituacion { get; set; }
            public Int32 TipoOper { get; set; }

            public CClienteTracking()
            {

            }
        }


        private void btnConsultarSunat_Click(object sender, EventArgs e)
        {
        }

        private void lblRefrescarCodigo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        void CargarImagen()
        {

        }

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCaptcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnConsultarSunat_Click(sender, e);

                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #region "Consulta Reniec"

        void CargarImagenReniec()
        {
            //try
            //{
            //    if (myInfo == null)
            //        myInfo = new PersonaReniec();
            //    this.pictureCapcha.Image = myInfo.GetCapcha;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        void CaptionResul()//reniec
        {
            //try
            //{
            //    switch (myInfo.GetResul)
            //    {
            //        case PersonaReniec.Resul.Ok:
            //            this.txtDescripcion.Text = myInfo.ApePaterno + " " + myInfo.ApeMaterno + " " + myInfo.Nombres;
            //            this.txtApPaterno.Text = myInfo.ApePaterno;
            //            this.txtApMaterno.Text = myInfo.ApeMaterno;
            //            this.txtNombres.Text = myInfo.Nombres;
            //            cboTipoPersona.EditValue = "N";
            //            this.lblEstadoRUC.Text = "";
            //            BloqueaModificar();
            //            break;
            //        case PersonaReniec.Resul.NoResul:
            //            this.lblEstadoRUC.Text = "No existe DNI";
            //            break;
            //        case PersonaReniec.Resul.ErrorCapcha:
            //            CargarImagen();
            //            this.lblEstadoRUC.Text = "Ingrese imagen correctamente";
            //            break;
            //        case PersonaReniec.Resul.Error:
            //            this.lblEstadoRUC.Text = "Error Desconocido";
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }


        #endregion

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {
    
        }

        private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void chkOtros_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void BloqueaModificar()
        {
        }

        private void SeparaApellidosNombres()
        {
           
        }

        private void txtNombres_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void txtApPaterno_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtApMaterno_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void gcTxtNumeroTelefono_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void nuevoClienteTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void eliminaClienteTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gcTxtSituacion_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}