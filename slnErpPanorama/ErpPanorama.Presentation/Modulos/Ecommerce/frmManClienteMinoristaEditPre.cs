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
    public partial class frmManClienteMinoristaEditPre : DevExpress.XtraEditors.XtraForm
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
        public String wNumDoc;
        public String wMovil;
        public String wCorreo;
        public String wDireccion;
        public int wConfactura;

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

        public frmManClienteMinoristaEditPre()
        {
            InitializeComponent();
        }

        private void frmManClienteMinoristaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente), "DescTablaElemento", "IdTablaElemento", true);
            if (wConfactura == 1)
            {
                cboDocumento.EditValue = Parametros.intTipoDocumentoDNI;
            }
            else if (wConfactura == 2)
            {
                cboDocumento.EditValue = Parametros.intTipoDocumentoRUC;
            }




            BSUtils.LoaderLook(cboClasificacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionClienteFinal), "DescTablaElemento", "IdTablaElemento", true);
            cboClasificacion.EditValue = Parametros.intClasico;
            BSUtils.LoaderLook(cboTipoDireccion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDireccion), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoDireccion.EditValue = Parametros.intTipoDireccionAV;
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;
            BSUtils.LoaderLook(cboSexo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSexo), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboDestino, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblDestinoDespacho), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboAgencia, new AgenciaBL().ListaTodosActivo(), "DescAgencia", "IdAgencia", true);

            //deFechaNac.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboTipoPersona, CargarTipoPersona(), "Descripcion", "Id", true);

            radioButton1.Checked = true;
            radioButton2.Checked = false;

            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ygomez" || Parametros.strUsuarioLogin == "mmurrugarra" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "liliana" || Parametros.strUsuarioLogin == "pmoscaiza" || Parametros.strUsuarioLogin == "nillanes" || Parametros.intPerfilId == Parametros.intPerSupervisorVentasPiso || Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerHelpDesk)
            {
                cboClasificacion.Enabled = true;
                chkAsesorExterno.Enabled = true;
            }
            else
            {
                cboClasificacion.Enabled = false;
                chkAsesorExterno.Enabled = false;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cliente Final - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cliente Final - Modificar";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                ClienteBE objE_Cliente = new ClienteBE();

                objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                cboDocumento.EditValue = objE_Cliente.IdTipoDocumento;
                txtNumeroDocumento.EditValue = objE_Cliente.NumeroDocumento.ToString().Trim();
                deFechaNac.EditValue = objE_Cliente.FechaNac;
                deFechaAniv.EditValue = objE_Cliente.FechaAniv;
                txtDescripcion.EditValue = objE_Cliente.DescCliente;
                txtApPaterno.EditValue = objE_Cliente.ApePaterno;
                txtApMaterno.EditValue = objE_Cliente.ApeMaterno;
                txtNombres.EditValue = objE_Cliente.Nombres;
                cboTipoPersona.EditValue = objE_Cliente.TipoPersona;
                cboClasificacion.EditValue = objE_Cliente.IdClasificacionCliente;
                txtTelefono.EditValue = objE_Cliente.Telefono;
                txtCelular.EditValue = objE_Cliente.Celular;
                txtOtroTelefono.EditValue = objE_Cliente.OtroTelefono;
                txtEmail.EditValue = objE_Cliente.Email;
                txtEmailFE.EditValue = objE_Cliente.EmailFE;

                if (objE_Cliente.IdUbigeoDom.Trim() != "")
                    IdDepartamento = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                cboDepartamento.EditValue = IdDepartamento;
                if (objE_Cliente.IdUbigeoDom.Trim() != "")
                    IdProvincia = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                cboProvincia.EditValue = IdProvincia;
                if (objE_Cliente.IdUbigeoDom.Trim() != "")
                    IdDistrito = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                cboDistrito.EditValue = IdDistrito;

                cboTipoDireccion.EditValue = objE_Cliente.IdTipoDireccion;
                txtDireccion.EditValue = objE_Cliente.Direccion;
                txtNumeroDireccion.Text = objE_Cliente.NumDireccion;
                cboVendedor.EditValue = objE_Cliente.IdVendedor;
                txtAgencia.Text = objE_Cliente.Agencia;
                cboAgencia.EditValue = objE_Cliente.IdAgencia;
                cboDestino.EditValue = objE_Cliente.IdDestino;
                txtReferencia.Text = objE_Cliente.Referencia;
                txtObservacion.Text = objE_Cliente.Observacion;
                chkAsesorExterno.Checked = objE_Cliente.FlagAsesorExterno;
                cboSexo.EditValue = objE_Cliente.IdSexo;
                lblFechaRegistro.Text = objE_Cliente.Fecha.ToString();

                dtpFecRegistro.Value = Convert.ToDateTime(objE_Cliente.Fecha);

                if (objE_Cliente.Procede == 1)
                {
                    radioButton1.Checked = true;  // Si es 1 corresponde a radio1
                }
                else if (objE_Cliente.Procede == 2)
                {
                    radioButton2.Checked = true; // Si es 2 corresponde a radio2
                }
                else if (objE_Cliente.Procede == 0)
                {
                    radioButton1.Checked = false; //  
                    radioButton2.Checked = false; //  
                }

                if (Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerHelpDesk)
                {
                    cboVendedor.Enabled = true;
                    //deFechaNac.Properties.ReadOnly = false;
                }
                else
                {
                    //BloqueaModificar(); //Bloquear al habilitar RENIEC
                    cboVendedor.Enabled = false;
                    //deFechaNac.Properties.ReadOnly = true;
                }
            }

            txtDescripcion.EditValue = wDescCliente;
            txtNumeroDocumento.EditValue = wNumDoc;
            txtCelular.EditValue = wMovil;
            txtEmail.EditValue = wCorreo;
            txtEmailFE.EditValue = wCorreo;
            txtDireccion.EditValue = wDireccion;
            chkWeb.Checked = true;

            CargaClienteCorreo();
            CargaClienteAsociado();
            CargaClienteEncuesta();
            CargaClienteTracking();

            txtNumeroDocumento.Select();
        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }
        }

        private void nuevoClienteCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvClienteCorreo.AddNewRow();

                if (pOperacion == Operacion.Modificar)
                {
                    gvClienteCorreo.SetRowCellValue(gvClienteCorreo.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    gvClienteCorreo.SetRowCellValue(gvClienteCorreo.FocusedRowHandle, "IdClienteCorreo", 0);
                }
                else
                {
                    gvClienteCorreo.SetRowCellValue(gvClienteCorreo.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    gvClienteCorreo.SetRowCellValue(gvClienteCorreo.FocusedRowHandle, "IdClienteCorreo", 0);
                }
                gvClienteCorreo.FocusedColumn = gvClienteCorreo.Columns["Email"];
                gvClienteCorreo.ShowEditor();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarClienteCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClienteCorreo = 0;
                IdClienteCorreo = int.Parse(gvClienteCorreo.GetFocusedRowCellValue("IdClienteCorreo").ToString());
                ClienteCorreoBE objBE_ClienteCorreo = new ClienteCorreoBE();
                objBE_ClienteCorreo.IdClienteCorreo = IdClienteCorreo;
                objBE_ClienteCorreo.IdEmpresa = Parametros.intEmpresaId;
                objBE_ClienteCorreo.Usuario = Parametros.strUsuarioLogin;
                objBE_ClienteCorreo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ClienteCorreoBL objBL_ClienteCorreo = new ClienteCorreoBL();
                objBL_ClienteCorreo.Elimina(objBE_ClienteCorreo);
                gvClienteCorreo.DeleteRow(gvClienteCorreo.FocusedRowHandle);
                gvClienteCorreo.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
               if (radioButton1.Checked)
                {
                    rbuton = 1;  // Si es 1 corresponde a radio1
                }
                else if (radioButton2.Checked)
                {
                    rbuton = 2;  // Si es 2 corresponde a radio2
                }

                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ClienteBL objBL_Cliente = new ClienteBL();
                    ClienteBE objE_Cliente = new ClienteBE();

                    objE_Cliente.IdCliente = IdCliente;
                    objE_Cliente.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_Cliente.NumeroDocumento = txtNumeroDocumento.Text.ToString().Trim();
                    objE_Cliente.ApePaterno = txtApPaterno.Text.Trim();
                    objE_Cliente.ApeMaterno = txtApMaterno.Text.Trim();
                    objE_Cliente.Nombres = txtNombres.Text.Trim();
                    objE_Cliente.DescCliente = txtDescripcion.Text;
                    objE_Cliente.TipoPersona = cboTipoPersona.EditValue.ToString();
                    objE_Cliente.IdSexo = Convert.ToInt32(cboSexo.EditValue);
                    objE_Cliente.Representante = "";
                    objE_Cliente.Contacto = "";
                    objE_Cliente.IdTipoDireccion = Convert.ToInt32(cboTipoDireccion.EditValue);
                    objE_Cliente.Direccion = txtDireccion.Text;
                    objE_Cliente.NumDireccion = txtNumeroDireccion.Text;
                    objE_Cliente.Urbanizacion = "";
                    objE_Cliente.Referencia = txtReferencia.Text.Trim();
                    objE_Cliente.IdUbigeoDom = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objE_Cliente.Direccion = txtDireccion.Text;
                    objE_Cliente.Telefono = txtTelefono.Text;
                    objE_Cliente.Celular = txtCelular.Text;
                    objE_Cliente.OtroTelefono = txtOtroTelefono.Text;
                    objE_Cliente.TelefonoAdicional = "";
                    objE_Cliente.Email = txtEmail.Text;
                    objE_Cliente.EmailFE = txtEmailFE.Text.Trim();
                    objE_Cliente.FechaNac = deFechaNac.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaNac.DateTime.ToShortDateString());
                    objE_Cliente.FechaAniv = deFechaAniv.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaAniv.DateTime.ToShortDateString()); 
                    objE_Cliente.IdTipoCliente = Parametros.intTipClienteFinal;
                    objE_Cliente.IdClasificacionCliente = Convert.ToInt32(cboClasificacion.EditValue);
                    objE_Cliente.IdCategoria = Parametros.intNinguno;
                    objE_Cliente.IdUbicacionEstrategica = Parametros.intNinguno;
                    objE_Cliente.IdTamanoLocal = Parametros.intNinguno;
                    objE_Cliente.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objE_Cliente.IdRuta = Parametros.intNinguno;
                    objE_Cliente.IdTipoLocal = Parametros.intNinguno;
                    objE_Cliente.IdCondicion = Parametros.intNinguno;
                    objE_Cliente.IdSituacion = Parametros.intNinguno;
                    objE_Cliente.IdAgencia = Convert.ToInt32(cboAgencia.EditValue);
                    objE_Cliente.IdDestino = Convert.ToInt32(cboDestino.EditValue);
                    //objE_Cliente.FlagNavidad = chkPreventa.Checked;
                    objE_Cliente.Observacion = txtObservacion.Text;
                    objE_Cliente.Agencia = txtAgencia.Text;
                    objE_Cliente.FlagSuspendido = false;
                    objE_Cliente.IdMotivoSituacion = 0;
                    objE_Cliente.FlagAsesorExterno = chkAsesorExterno.Checked;
                    objE_Cliente.IdTienda = Parametros.intTiendaId;
                    objE_Cliente.FlagEstado = true;
                    objE_Cliente.Usuario = Parametros.strUsuarioLogin;
                    objE_Cliente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Cliente.IdEmpresa = Parametros.intEmpresaId;

                    objE_Cliente.Procede = rbuton;
                    List<ClienteLineaProductoBE> lstClienteLineaProducto = new List<ClienteLineaProductoBE>();
                    //List<ClienteAsociadoBE> lstClienteAsociado = new List<ClienteAsociadoBE>();

                    //Cliente  Correo
                    List<ClienteCorreoBE> lstClienteCorreo = new List<ClienteCorreoBE>();
                    foreach (var item in mListaClienteCorreoOrigen)
                    {
                        ClienteCorreoBE objE_ClienteCorreo = new ClienteCorreoBE();
                        objE_ClienteCorreo.IdClienteCorreo = item.IdClienteCorreo;
                        objE_ClienteCorreo.IdCliente = IdCliente;
                        objE_ClienteCorreo.Email = item.Email;
                        objE_ClienteCorreo.FlagEstado = true;
                        objE_ClienteCorreo.Usuario = Parametros.strUsuarioLogin;
                        objE_ClienteCorreo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClienteCorreo.IdEmpresa = Parametros.intEmpresaId;
                        objE_ClienteCorreo.TipoOper = item.TipoOper;
                        lstClienteCorreo.Add(objE_ClienteCorreo);
                    }

                    //Cliente Asociado
                    List<ClienteAsociadoBE> lstClienteAsociado = new List<ClienteAsociadoBE>();
                    foreach (var item in mListaClienteAsociadoOrigen)
                    {
                        ClienteAsociadoBE objE_ClienteAsociado = new ClienteAsociadoBE();
                        objE_ClienteAsociado.IdClienteAsociado = item.IdClienteAsociado;
                        objE_ClienteAsociado.IdCliente = IdCliente;
                        objE_ClienteAsociado.IdTipoDocumento = item.IdTipoDocumento;//Convert.ToInt32(item.AbrevDocumento);
                        if (objE_ClienteAsociado.IdTipoDocumento == 0)
                        {
                            XtraMessageBox.Show("Verificar el tipo de Documento, Presionar F1 en la celda para Seleccionar DNI o RUC.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Cursor = Cursors.Default;
                            return;
                        }

                        if (item.IdTipoDocumento == Parametros.intTipoDocumentoRUC)//add 080615
                        {
                            if (item.NumeroDocumento.Trim().Length != 11)
                            {
                                XtraMessageBox.Show("Verificar el número de RUC del Cliente asociado, debe contener 11 Dígitos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                        objE_ClienteAsociado.NumeroDocumento = item.NumeroDocumento;
                        objE_ClienteAsociado.DescCliente = item.DescCliente;
                        objE_ClienteAsociado.Direccion = item.Direccion;
                        objE_ClienteAsociado.FlagEstado = true;
                        objE_ClienteAsociado.Usuario = Parametros.strUsuarioLogin;
                        objE_ClienteAsociado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClienteAsociado.IdEmpresa = Parametros.intEmpresaId;
                        objE_ClienteAsociado.TipoOper = item.TipoOper;
                        lstClienteAsociado.Add(objE_ClienteAsociado);
                    }

                    //Tracking de LLamadas
                    List<ClienteTrackingBE> lstClienteTracking = new List<ClienteTrackingBE>();
                    foreach (var item in mListaClienteTrackingOrigen)
                    {
                        ClienteTrackingBE objE_ClienteTracking = new ClienteTrackingBE();
                        objE_ClienteTracking.IdClienteTracking = item.IdClienteTracking;
                        objE_ClienteTracking.IdCliente = IdCliente;
                        objE_ClienteTracking.FechaRegistro = item.FechaRegistro;
                        objE_ClienteTracking.Numero = item.Numero;
                        objE_ClienteTracking.Comentario = item.Comentario;
                        objE_ClienteTracking.FechaProxima = item.FechaProxima;
                        objE_ClienteTracking.IdSituacion = item.IdSituacion;
                        objE_ClienteTracking.FlagEstado = true;
                        objE_ClienteTracking.Usuario = Parametros.strUsuarioLogin;
                        objE_ClienteTracking.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClienteTracking.IdEmpresa = Parametros.intEmpresaId;
                        objE_ClienteTracking.TipoOper = item.TipoOper;
                        lstClienteTracking.Add(objE_ClienteTracking);
                    }

                    //Cliente  Encuesta
                    ClienteEncuestaBE objE_ClienteEncuesta = new ClienteEncuestaBE();
                    objE_ClienteEncuesta.IdClienteEncuesta = IdClienteEncuesta;
                    objE_ClienteEncuesta.IdCliente = IdCliente;
                    objE_ClienteEncuesta.Facebook = chkFacebook.Checked;
                    objE_ClienteEncuesta.Instagram = chkInstagram.Checked;
                    objE_ClienteEncuesta.Radio = chkRadio.Checked;
                    objE_ClienteEncuesta.Television = chkTv.Checked;
                    objE_ClienteEncuesta.Revista = chkRevista.Checked;
                    objE_ClienteEncuesta.Amigo = chkAmigos.Checked;
                    objE_ClienteEncuesta.Panel = chkPanel.Checked;
                    objE_ClienteEncuesta.Web = chkWeb.Checked;
                    objE_ClienteEncuesta.Correo = chkCorreo.Checked;
                    objE_ClienteEncuesta.Periodico = chkPeriodico.Checked;
                    objE_ClienteEncuesta.Sms = chkSms.Checked;
                    objE_ClienteEncuesta.Otro = chkOtros.Checked;
                    objE_ClienteEncuesta.RespuestaOtro = txtEncuestaOtro.Text;
                    objE_ClienteEncuesta.FlagEstado = true;
                    objE_ClienteEncuesta.Usuario = Parametros.strUsuarioLogin;
                    objE_ClienteEncuesta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_ClienteEncuesta.IdEmpresa = Parametros.intEmpresaId;
                    objE_ClienteEncuesta.TipoOper = Convert.ToInt32(pOperacionEncuesta); 

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Cliente.Inserta(objE_Cliente, lstClienteLineaProducto, lstClienteAsociado, lstClienteCorreo, lstClienteTracking, objE_ClienteEncuesta);
                    else
                        objBL_Cliente.Actualiza(objE_Cliente, lstClienteLineaProducto, lstClienteAsociado, lstClienteCorreo, lstClienteTracking, objE_ClienteEncuesta);

                    //Devolvemos el Cliente Generado
                    this.DialogResult = DialogResult.OK;
                    NumeroDocumento = txtNumeroDocumento.Text;
                    DescCliente = txtDescripcion.Text;
                    Direccion = txtDireccion.Text;
                    AbrevDocimicilio = cboTipoDireccion.Text;
                    NumDireccion = txtNumeroDireccion.Text;
                    DescDistrito = cboDistrito.Text;
                    DescProvincia = cboProvincia.Text;
                    DescDepartamento = cboDepartamento.Text;
                    IdClasificacionCliente = Convert.ToInt32(cboClasificacion.EditValue);
                    TipoClasificacion = "CLIENTE FINAL" + "-" + cboClasificacion.Text;

                    //Obteniendo datos del cliente registrado
                    //if (pOperacion == Operacion.Nuevo)
                    //{
                    ClienteBE objE_ClienteV2 = null;
                    objE_ClienteV2 = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());

                    //    if (objE_ClienteV != null)
                    //    {

                    //if (XtraMessageBox.Show("El numero de documento ya se encuentra registrado.\n " + "Cliente: " + wDescCliente + " \n \n ¿Desea seleccionar al cliente para asignarlo al pedido N° " + wPedidoWeb + " ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    //        {
                                PedidoBL objBL_Pedido = new PedidoBL();
                                     objBL_Pedido.Actualizar_PedidoWeb(wIdPedidoWeb
                                                                     , objE_ClienteV2.IdCliente
                                                                     , objE_ClienteV2.NumeroDocumento
                                                                     , objE_ClienteV2.DescCliente
                                                                     , objE_ClienteV2.Direccion
                                                                     , 1);
                                this.Close();
                            //}
                            //else
                            //{
                            //    return;
                            //}

                    //    }
                    //}

                    this.Close();
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
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboDepartamento.Focus();
            }
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
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtNumeroDireccion.Focus();
            }
        }

        private void txtNumeroDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboVendedor.Focus();
            }
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
            if (e.KeyCode == Keys.Enter)
            {
                ClienteBE objE_Cliente = null;
                string Numero = "";
                Numero = (sender as TextEdit).Text;
                objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, Numero);
                if (objE_Cliente != null)
                {
                    int index = gvClienteAsociado.FocusedRowHandle;

                    gvClienteAsociado.SetRowCellValue(index, "IdTipoDocumento", objE_Cliente.IdTipoDocumento);
                    gvClienteAsociado.SetRowCellValue(index, "AbrevDocumento", objE_Cliente.AbrevDocumento);
                    gvClienteAsociado.SetRowCellValue(index, "NumeroDocumento", objE_Cliente.NumeroDocumento);
                    gvClienteAsociado.SetRowCellValue(index, "DescCliente", objE_Cliente.DescCliente);
                    gvClienteAsociado.SetRowCellValue(index, "Direccion", objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion);
                    gvClienteAsociado.UpdateCurrentRow();
                }
            }
        }

        private void gcTxtAbrevDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmBuscaTablaElemento objTablaElemento = new frmBuscaTablaElemento();
                objTablaElemento.IdTabla = Parametros.intTblTipoDocCliente;
                objTablaElemento.ShowDialog();
                if (objTablaElemento.pTablaElementoBE != null)
                {   
                    int index = gvClienteAsociado.FocusedRowHandle;

                    gvClienteAsociado.SetRowCellValue(index, "IdTipoDocumento", objTablaElemento.pTablaElementoBE.IdTablaElemento);
                    gvClienteAsociado.SetRowCellValue(index, "AbrevDocumento", objTablaElemento.pTablaElementoBE.Abreviatura);
                    gvClienteAsociado.UpdateCurrentRow();

                    gvClienteAsociado.FocusedRowHandle = index;
                    gvClienteAsociado.FocusedColumn = gvClienteAsociado.Columns["NumeroDocumento"];
                    gvClienteAsociado.ShowEditor();

                }
            }
        }

        private void nuevoClienteAsociadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvClienteAsociado.AddNewRow();
                if (pOperacion == Operacion.Modificar)
                {
                    gvClienteAsociado.SetRowCellValue(gvClienteAsociado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    gvClienteAsociado.SetRowCellValue(gvClienteAsociado.FocusedRowHandle, "IdClienteAsociado", 0);
                }
                else
                {
                    gvClienteAsociado.SetRowCellValue(gvClienteAsociado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    gvClienteAsociado.SetRowCellValue(gvClienteAsociado.FocusedRowHandle, "IdClienteAsociado", 0);
                }
                gvClienteAsociado.FocusedColumn = gvClienteAsociado.Columns["AbrevDocumento"];
                gvClienteAsociado.ShowEditor();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //try
            //{
            //    gvClienteAsociado.AddNewRow();

            //    repositoryItemLookUpEdit1.DataSource = CargarTipoDocumentoCliente();//new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente);
            //    //repositoryItemLookUpEdit1.Columns["flagestado"].Visible = false;
            //    repositoryItemLookUpEdit1.ForceInitialize();
            //    repositoryItemLookUpEdit1.PopulateColumns();
            //    repositoryItemLookUpEdit1.DisplayMember = "Descripcion";
            //    repositoryItemLookUpEdit1.ValueMember = "Id";
                
            //    if (pOperacion == Operacion.Modificar)
            //    {
            //        gvClienteAsociado.SetRowCellValue(gvClienteAsociado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
            //        gvClienteAsociado.SetRowCellValue(gvClienteAsociado.FocusedRowHandle, "IdClienteAsociado", 0);
            //    }
            //    else
            //    {
            //        gvClienteAsociado.SetRowCellValue(gvClienteAsociado.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
            //        gvClienteAsociado.SetRowCellValue(gvClienteAsociado.FocusedRowHandle, "IdClienteAsociado", 0);
            //    }
            //    gvClienteAsociado.FocusedColumn = gvClienteAsociado.Columns["AbrevDocumento"];
            //    gvClienteAsociado.ShowEditor();

            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void eliminarClienteAsociadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClienteAsociado = 0;
                IdClienteAsociado = int.Parse(gvClienteAsociado.GetFocusedRowCellValue("IdClienteAsociado").ToString());
                ClienteAsociadoBE objBE_ClienteAsociado = new ClienteAsociadoBE();
                objBE_ClienteAsociado.IdClienteAsociado = IdClienteAsociado;
                objBE_ClienteAsociado.IdEmpresa = Parametros.intEmpresaId;
                objBE_ClienteAsociado.Usuario = Parametros.strUsuarioLogin;
                objBE_ClienteAsociado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ClienteAsociadoBL objBL_ClienteAsociado = new ClienteAsociadoBL();
                objBL_ClienteAsociado.Elimina(objBE_ClienteAsociado);
                gvClienteAsociado.DeleteRow(gvClienteAsociado.FocusedRowHandle);
                gvClienteAsociado.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción del cliente.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoDNI)
            {
                if (txtNumeroDocumento.Text.Trim().Length != 8)
                {
                    strMensaje = strMensaje + "- El número de Dni debe tener 8 dígitos.\n";
                    flag = true;
                }

                if(txtApPaterno.Text.Trim() == "")
                {
                    strMensaje = strMensaje + "- Ingresar Apellido Paterno.\n";
                    flag = true;
                }
                if (txtApMaterno.Text.Trim() == "")
                {
                    strMensaje = strMensaje + "- Ingresar Apellido Materno.\n";
                    flag = true;
                }

                if (Convert.ToInt32(cboSexo.EditValue) == Parametros.intNinguno)
                {
                    strMensaje = strMensaje + "- Seleccionar el sexo del Cliente.\n";
                    flag = true;
                }
            }

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoRUC)
            {
                if (txtNumeroDocumento.Text.Trim().Length != 11)
                {
                    strMensaje = strMensaje + "- El número de ruc debe tener 11 dígitos.\n";
                    flag = true;
                }

                if(txtNumeroDocumento.Text.Trim().Substring(0,2)=="10")
                {
                    if (Convert.ToInt32(cboSexo.EditValue) == Parametros.intNinguno)
                    {
                        strMensaje = strMensaje + "- Seleccionar el sexo del Cliente.\n";
                        flag = true;
                    }
                }
                
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Nombre/Razón social del cliente.\n";
                flag = true;
            }

            if(cboTipoPersona.EditValue.ToString() == "N")
            {
                if (txtNombres.Text.Trim() == "")
                {
                    strMensaje = strMensaje + "- Ingrese el Nombre del cliente.\n";
                    flag = true;
                }
            }
            
            if (txtDireccion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la dirección del cliente.\n";
                flag = true;
            }

            #region "Encuesta"
            
            //Medio contactado
            bool bEncuesta = false;
            if (chkFacebook.Checked)
                bEncuesta = true;
            if (chkRadio.Checked)
                bEncuesta = true;
            if (chkTv.Checked)
                bEncuesta = true;
            if (chkRevista.Checked)
                bEncuesta = true;
            if (chkAmigos.Checked)
                bEncuesta = true;
            if (chkPanel.Checked)
                bEncuesta = true;
            if (chkWeb.Checked)
                bEncuesta = true;
            if (chkOtros.Checked)
            {
                if (txtEncuestaOtro.Text.Trim().Length == 0)
                {
                    strMensaje = strMensaje + "- Ingresar el otro medio de contacto.\n";
                    flag = true;
                }
                else
                    bEncuesta = true;
            }

            if(bEncuesta)
            {
                if(IdClienteEncuesta==0)
                    pOperacionEncuesta = Operacion.Nuevo;
                else
                    pOperacionEncuesta = Operacion.Modificar;
            }
            #endregion

            if (pOperacion == Operacion.Nuevo)
            {
                if (!bEncuesta)
                {
                    strMensaje = strMensaje + "- Seleccionar el medio por el cual fue contactado.\n";
                    flag = true;
                }


                if (lstCliente != null)
                {
                 //   if (deFechaNac.DateTime.ToShortDateString() == DateTime.Now.ToShortDateString())
	                //{
                 //       strMensaje = strMensaje + "- Ingresa una fecha de nacimiento válida.\n";
                 //       flag = true;
	                //}

                    var BuscarDocumento = lstCliente.Where(oB => oB.NumeroDocumento.ToUpper() == txtNumeroDocumento.Text.ToUpper()).ToList();
                    if (BuscarDocumento.Count > 0)
                    {
                        strMensaje = strMensaje + "- El número de documento ya existe.\n";
                        flag = true;
                    }

                    var BuscarDescripcion = lstCliente.Where(oB => oB.DescCliente.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                    if (BuscarDescripcion.Count > 0)
                    {
                        strMensaje = strMensaje + "- La descripción ya existe.\n";
                        flag = true;
                    }
                }
                //asociados
                foreach (CClienteAsociado item in mListaClienteAsociadoOrigen)
                {
                    var BuscarNumeroDocumentoAsociado = mListaClienteAsociadoOrigen.Where(oB => oB.NumeroDocumento.ToUpper() == item.NumeroDocumento.ToUpper()).ToList();
                    if (BuscarNumeroDocumentoAsociado.Count > 1)
                    {
                        strMensaje = strMensaje + "- El número de documento del asociado se repite.\n";
                        flag = true;
                    }

                    var BuscarClienteAsociado = mListaClienteAsociadoOrigen.Where(oB => oB.DescCliente.ToUpper() == item.DescCliente.ToUpper()).ToList();
                    if (BuscarClienteAsociado.Count > 1)
                    {
                        strMensaje = strMensaje + "- El nombre del asociado se repite.\n";
                        flag = true;
                    }

                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, item.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        strMensaje = strMensaje + "- El número de documento del asociado se repite en el cliente principal : " + objE_Cliente.NumeroDocumento + " " + objE_Cliente.DescCliente + "\n";
                        flag = true;
                    }

                    objE_Cliente = new ClienteBL().SeleccionaDescripcion(Parametros.intEmpresaId, item.DescCliente);
                    if (objE_Cliente != null)
                    {
                        strMensaje = strMensaje + "- La descripción del asociado se repite en el cliente principal : " + objE_Cliente.NumeroDocumento + " " + objE_Cliente.DescCliente + "\n";
                        flag = true;
                    }
                }


                //Cliente asociados
                
                ClienteAsociadoBE ClienteAsociadoBE = null;
                ClienteAsociadoBE = new ClienteAsociadoBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text);
                if (ClienteAsociadoBE != null)
                {
                    strMensaje = strMensaje + "- El Numero de documento del Cliente ya existe como asociado :" + "\n";
                    flag = true;
                }

                ClienteAsociadoBE ClienteAsociadoBE1 = null;
                ClienteAsociadoBE1 = new ClienteAsociadoBL().SeleccionaDescripcion(Parametros.intEmpresaId, txtDescripcion.Text);
                if (ClienteAsociadoBE1 != null)
                {
                    strMensaje = strMensaje + "- El nombre del Cliente ya existe como asociado :" + "\n";
                    flag = true;
                }
            }

            if (cboVendedor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar al vendedor.\n";
                flag = true;
            }

            foreach (CClienteCorreo item in mListaClienteCorreoOrigen)
            {
                var BuscarCorreoAsociado = mListaClienteCorreoOrigen.Where(oB => oB.Email.ToUpper() == item.Email.ToUpper()).ToList();
                if (BuscarCorreoAsociado.Count > 1)
                {
                    strMensaje = strMensaje + "- El correo electronico se repite.\n";
                    flag = true;
                }
            }

            //Validar correo
            string Correo = txtEmail.Text.Trim();
            if (Correo.Length > 0)
            {
                if (!ValidarEmail(txtEmail.Text.Trim()))
                {
                    strMensaje = strMensaje + "- Correo electrónico inválido, corregir o dejar en Blanco.\n";
                    flag = true;
                }
            }

            //Validar correo FE
            string CorreoFE = txtEmailFE.Text.Trim();
            if(CorreoFE.Length>0)
            {
                if (!ValidarEmail(txtEmailFE.Text.Trim()))
                {
                    strMensaje = strMensaje + "- Correo de envío de Facturación Electrónica inválido, corregir o dejar en Blanco.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaClienteCorreo()
        {
            List<ClienteCorreoBE> lstTmpClienteCorreo = null;
            lstTmpClienteCorreo = new ClienteCorreoBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente);

            foreach (ClienteCorreoBE item in lstTmpClienteCorreo)
            {
                CClienteCorreo objE_ClienteCorreo = new CClienteCorreo();
                objE_ClienteCorreo.IdEmpresa = item.IdEmpresa;
                objE_ClienteCorreo.IdClienteCorreo = item.IdClienteCorreo;
                objE_ClienteCorreo.IdCliente = item.IdCliente;
                objE_ClienteCorreo.Email = item.Email;
                objE_ClienteCorreo.TipoOper = item.TipoOper;
                mListaClienteCorreoOrigen.Add(objE_ClienteCorreo);
            }

            bsListadoClienteCorreo.DataSource = mListaClienteCorreoOrigen;
            gcClienteCorreo.DataSource = bsListadoClienteCorreo;
            gcClienteCorreo.RefreshDataSource();
        }

        private void CargaClienteAsociado()
        {
            List<ClienteAsociadoBE> lstTmpClienteAsociado = null;
            lstTmpClienteAsociado = new ClienteAsociadoBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente);

            foreach (ClienteAsociadoBE item in lstTmpClienteAsociado)
            {
                CClienteAsociado objE_ClienteAsociado = new CClienteAsociado();
                objE_ClienteAsociado.IdEmpresa = item.IdEmpresa;
                objE_ClienteAsociado.IdClienteAsociado = item.IdClienteAsociado;
                objE_ClienteAsociado.IdCliente = item.IdCliente;
                objE_ClienteAsociado.IdTipoDocumento = item.IdTipoDocumento;
                //objE_ClienteAsociado.AbrevDocumento = item.AbrevDocumento;
                objE_ClienteAsociado.AbrevDocumento = item.AbrevDocumento;
                objE_ClienteAsociado.NumeroDocumento = item.NumeroDocumento;
                objE_ClienteAsociado.DescCliente = item.DescCliente;
                objE_ClienteAsociado.Direccion = item.Direccion;
                objE_ClienteAsociado.TipoOper = item.TipoOper;
                mListaClienteAsociadoOrigen.Add(objE_ClienteAsociado);
            }

            bsListadoClienteAsociado.DataSource = mListaClienteAsociadoOrigen;
            gcClienteAsociado.DataSource = bsListadoClienteAsociado;
            gcClienteAsociado.RefreshDataSource();
        }

        private void CargaClienteEncuesta()
        {
            ClienteEncuestaBE objE_Encuesta = null;
            objE_Encuesta = new ClienteEncuestaBL().Selecciona(IdCliente);

            if (objE_Encuesta != null)
            {
                chkFacebook.Checked = objE_Encuesta.Facebook;
                chkRadio.Checked = objE_Encuesta.Radio;
                chkTv.Checked = objE_Encuesta.Television;
                chkRevista.Checked = objE_Encuesta.Revista;
                chkAmigos.Checked = objE_Encuesta.Amigo;
                chkPanel.Checked = objE_Encuesta.Panel;
                chkWeb.Checked = objE_Encuesta.Web;
                chkInstagram.Checked = objE_Encuesta.Instagram;
                chkCorreo.Checked = objE_Encuesta.Web;
                chkPeriodico.Checked = objE_Encuesta.Periodico;
                chkSms.Checked = objE_Encuesta.Sms;
                chkOtros.Checked = objE_Encuesta.Otro;
                txtEncuestaOtro.Text = objE_Encuesta.RespuestaOtro;
                gcContactadoPor.Enabled = false;
                IdClienteEncuesta = objE_Encuesta.IdClienteEncuesta;
                pOperacionEncuesta = Operacion.Modificar;
            }

        }

        private void CargarComboTipoDocumento()
        {
            //repositoryItemLookUpEdit1.DataSource = CargarTipoDocumentoCliente();//new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente);
            //repositoryItemLookUpEdit1.ForceInitialize();
            //repositoryItemLookUpEdit1.PopulateColumns();
            //repositoryItemLookUpEdit1.DisplayMember = "Descripcion";
            //repositoryItemLookUpEdit1.ValueMember = "Id";
        }


        private void CargaClienteTracking()
        {
            List<ClienteTrackingBE> lstTmpClienteTracking = null;
            lstTmpClienteTracking = new ClienteTrackingBL().ListaTodosActivo(IdCliente);

            foreach (ClienteTrackingBE item in lstTmpClienteTracking)
            {
                CClienteTracking objE_ClienteTracking = new CClienteTracking();
                objE_ClienteTracking.IdClienteTracking = item.IdClienteTracking;
                objE_ClienteTracking.IdCliente = item.IdCliente;
                objE_ClienteTracking.FechaRegistro = item.FechaRegistro;
                objE_ClienteTracking.Numero = item.Numero;
                objE_ClienteTracking.Comentario = item.Comentario;
                objE_ClienteTracking.FechaProxima = item.FechaProxima;
                objE_ClienteTracking.IdSituacion = item.IdSituacion;
                objE_ClienteTracking.DescSituacion = item.DescSituacion;
                objE_ClienteTracking.TipoOper = item.TipoOper;
                mListaClienteTrackingOrigen.Add(objE_ClienteTracking);
            }

            bsListadoClienteTracking.DataSource = mListaClienteTrackingOrigen;
            gcClienteTracking.DataSource = bsListadoClienteTracking;
            gcClienteTracking.RefreshDataSource();
        }



        private DataTable CargarTipoDocumentoCliente()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 55;
            dr["Descripcion"] = "DNI";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 56;
            dr["Descripcion"] = "RUC";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarTipoPersona()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "N";
            dr["Descripcion"] = "N - NATURAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "J";
            dr["Descripcion"] = "J - JURIDICA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "D";
            dr["Descripcion"] = "D - SUJETO NO DOMICILIADO";
            dt.Rows.Add(dr);
            return dt;
        }

        private Boolean ValidarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }


        #endregion

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
            try
            {
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoRUC)
                {
                    if (txtCaptcha.Text.Trim() == "")
                    {
                        XtraMessageBox.Show("Ingrese el código que se muestra en la imágen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCaptcha.Select();
                        return;
                    }

                    //Contribuyente myRuc = new Contribuyente();//add
                    
                    myRuc.GetInfo(this.txtNumeroDocumento.Text, this.txtCaptcha.Text);
                    this.txtDireccion.Text = myRuc.Direccion;
                    this.txtDescripcion.Text = myRuc.RazonSocial;
                    this.lblEstadoRUC.Text = myRuc.Estado + " / " + myRuc.Habido;
                    this.txtCaptcha.Text = "";
                    CargarImagen();
                }
                else
                {
                    if (this.txtNumeroDocumento.Text.Length != 8)
                    {
                        this.lblEstadoRUC.Text = "Ingrese Dni Valido";
                        this.txtNumeroDocumento.SelectAll();
                        this.txtNumeroDocumento.Focus();
                        return;
                    }
                    
                    myInfo.GetInfo(this.txtNumeroDocumento.Text, this.txtCaptcha.Text);
                    CaptionResul();
                    CargarImagenReniec(); //Comentar esta linea para consultar multiples DNI usando un solo captcha.                
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //XtraMessageBox.Show("Por el momento este servicio no está disponible.\nPor favor, consulte por el navegador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            /*
             * 
             * 
            ///---------------
             * 
            string ruc = this.txtNumeroDocumento.Text;

            Contribuyente myRuc = new Contribuyente(ruc);

            if (string.IsNullOrEmpty(myRuc.Error))
            {
                txtDescripcion.Text = myRuc.GetInfo.RazonSocial;
                txtDireccion.Text = myRuc.GetInfo.Direccion;
                lblEstadoRUC.Text = "ESTADO: " + myRuc.GetInfo.Estado;

                if(myRuc.GetInfo.Telefono.Length > 3)
                    txtTelefono.Text = myRuc.GetInfo.Telefono;

                cboDocumento.EditValue = Parametros.intTipoDocumentoRUC;

                //this.txtAntiguoRuc.Text = myRuc.GetInfo.AntiguoRuc;
                //this.txtEstado.Text = myRuc.GetInfo.Estado;
                //this.txtEsAgenteRetencion.Text = myRuc.GetInfo.EsAgenteRetencion;
                //this.txtNombreComercial.Text = myRuc.GetInfo.NombreComercial;
                //this.txtDependencia.Text = myRuc.GetInfo.Dependencia;
                //this.txtTipoEmpresa.Text = myRuc.GetInfo.Tipo;
            }
            else
            {
                XtraMessageBox.Show(myRuc.Error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }*/
        }

        private void lblRefrescarCodigo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoRUC)
                CargarImagen();
            else
                CargarImagenReniec();
            this.txtCaptcha.SelectAll();
            this.txtCaptcha.Focus();
        }

        void CargarImagen()
        {
            try
            {
                if (myRuc == null)
                myRuc = new Contribuyente();
                this.pictureCapcha.Image = myRuc.GetCapcha;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {
            txtNumeroDocumento.Text = "";
            txtNumeroDocumento.Select();
            txtNumeroDocumento.SelectAll();

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoRUC)
            {
                txtNumeroDocumento.Properties.MaxLength = 11;
                txtApPaterno.Properties.ReadOnly = true;
                txtApMaterno.Properties.ReadOnly = true;
                txtNombres.Properties.ReadOnly = true;
                txtDescripcion.Properties.ReadOnly = false;

            }
            else if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoDNI)
            {
                txtNumeroDocumento.Properties.MaxLength = 8;
                txtApPaterno.Properties.ReadOnly = false;
                txtApMaterno.Properties.ReadOnly = false;
                txtNombres.Properties.ReadOnly = false;
                txtDescripcion.Properties.ReadOnly = true;
            }
            else 
            {
                txtNumeroDocumento.Properties.MaxLength = 15;
                txtApPaterno.Properties.ReadOnly = false;
                txtApMaterno.Properties.ReadOnly = false;
                txtNombres.Properties.ReadOnly = false;
                txtDescripcion.Properties.ReadOnly = false;
            }
             


            //if (pOperacion == Operacion.Nuevo)
            //{
            //    if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoRUC)
            //    {
            //        CargarImagen();
            //        txtNumeroDocumento.Select();
            //    }
            //    //else if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoDNI)
            //    //{
            //    //    //CargarImagenReniec();
            //    //    //txtNumeroDocumento.Select();
            //    //}
            //    else
            //    {
            //        pictureCapcha.Image = null;
            //    }            
            //}
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
            try
            {
                if (myInfo == null)
                    myInfo = new PersonaReniec();
                this.pictureCapcha.Image = myInfo.GetCapcha;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void CaptionResul()//reniec
        {
            try
            {
                switch (myInfo.GetResul)
                {
                    case PersonaReniec.Resul.Ok:
                        this.txtDescripcion.Text = myInfo.ApePaterno + " " + myInfo.ApeMaterno + " " + myInfo.Nombres;
                        this.txtApPaterno.Text = myInfo.ApePaterno;
                        this.txtApMaterno.Text = myInfo.ApeMaterno;
                        this.txtNombres.Text = myInfo.Nombres;
                        cboTipoPersona.EditValue = "N";
                        this.lblEstadoRUC.Text = "";
                        BloqueaModificar();
                        break;
                    case PersonaReniec.Resul.NoResul:
                        this.lblEstadoRUC.Text = "No existe DNI";
                        break;
                    case PersonaReniec.Resul.ErrorCapcha:
                        CargarImagen();
                        this.lblEstadoRUC.Text = "Ingrese imagen correctamente";
                        break;
                    case PersonaReniec.Resul.Error:
                        this.lblEstadoRUC.Text = "Error Desconocido";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {
            this.lblEstadoRUC.Text = "";
        }

        private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
           // ClienteBL objBL_Cliente = new ClienteBL();
      

            if (e.KeyCode == Keys.Enter)
            {
                //CONSULTAR SI EXISTE
                if(pOperacion == Operacion.Nuevo)
                {
                    ClienteBE objE_ClienteV = null;
                    objE_ClienteV = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());

                    if (objE_ClienteV != null)
                    {

                        if (XtraMessageBox.Show("El numero de documento se encuentra registrado.\n " + "Cliente: " + wDescCliente + " \n \n ¿Desea seleccionar al cliente para asignarlo al pedido N° " + wPedidoWeb + " ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                        {
                            PedidoBL objBL_Pedido = new PedidoBL();
                            objBL_Pedido.Actualizar_PedidoWeb(wIdPedidoWeb
                                                                 , objE_ClienteV.IdCliente
                                                               , objE_ClienteV.NumeroDocumento
                                                               , objE_ClienteV.DescCliente
                                                               , objE_ClienteV.Direccion
                                                               , 1);
                            this.Close();
                        }
                        else
                        {
                            return;
                        }
                        
                    }
                }

                //btnConsultarSunat_Click(sender, e);
                if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoRUC)
                {
                    #region "Consulta RUC Data Local"

                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumeroSunat(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        string IdDepartamento = string.Empty;
                        string IdProvincia = string.Empty;
                        string IdDistrito = string.Empty;

                        txtDescripcion.Text = objE_Cliente.DescCliente;
                        lblEstadoRUC.Text = objE_Cliente.DescCategoria + " - " + objE_Cliente.DescCondicion;


                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDepartamento = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                        cboDepartamento.EditValue = IdDepartamento;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdProvincia = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                        cboProvincia.EditValue = IdProvincia;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDistrito = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                        cboDistrito.EditValue = IdDistrito;

                        //Domicilio
                        switch (objE_Cliente.AbrevDomicilio)
                        {
                            case "AV.":
                                cboTipoDireccion.EditValue = 57;
                                break;
                            case "CAL.":
                                cboTipoDireccion.EditValue = 58;
                                break;
                            case "JR.":
                                cboTipoDireccion.EditValue = 59;
                                break;
                            case "PJ.":
                                cboTipoDireccion.EditValue = 60;
                                break;
                            default:
                                cboTipoDireccion.EditValue = 128;
                                if (objE_Cliente.AbrevDomicilio == "-" || objE_Cliente.AbrevDomicilio == "--" || objE_Cliente.AbrevDomicilio == "---" || objE_Cliente.AbrevDomicilio == "----")
                                    objE_Cliente.AbrevDomicilio = "";
                                else
                                    objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";
                                objE_Cliente.Direccion = objE_Cliente.AbrevDomicilio + objE_Cliente.Direccion;
                                break;
                        }
                        txtDireccion.Text = objE_Cliente.Direccion;

                        //Tipo persona
                        cboTipoPersona.Properties.ReadOnly = true;
                        cboDocumento.Properties.ReadOnly = true;
                        txtNumeroDocumento.Properties.ReadOnly = true;

                        if (txtNumeroDocumento.Text.Trim().Substring(0,2)=="10")
                        {
                            cboTipoPersona.EditValue = "N";
                            SeparaApellidosNombres();
                        }
                        else
                        {
                            cboTipoPersona.EditValue = "J";
                            txtApPaterno.Text = string.Empty;
                            txtApMaterno.Text = string.Empty;
                            txtNombres.Text = string.Empty;
                            BloqueaModificar();
                        }

                        txtTelefono.Focus();
                        e.Handled = true;
                        return;
                    }
                    #endregion

                    else
                    {
                        CargarImagen();

                        if (txtNumeroDocumento.Text.Substring(0, 2) == "20")
                        {
                            cboTipoPersona.EditValue = "J";
                            txtApPaterno.Properties.ReadOnly = true;
                            txtApMaterno.Properties.ReadOnly = true;
                            txtNombres.Properties.ReadOnly = true;
                            txtDescripcion.Properties.ReadOnly = false;

                            txtApPaterno.Text = String.Empty;
                            txtApMaterno.Text = String.Empty;
                            txtNombres.Text = String.Empty;
                            txtDescripcion.Select();
                        }
                        else
                        {
                            cboTipoPersona.EditValue = "N";
                            txtApPaterno.Properties.ReadOnly = false;
                            txtApMaterno.Properties.ReadOnly = false;
                            txtNombres.Properties.ReadOnly = false;
                            txtDescripcion.Properties.ReadOnly = true;
                            txtApPaterno.Select();
                        }
                    }
                }
                else
                {
                    CargarImagenReniec();
                }

                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void chkOtros_CheckedChanged(object sender, EventArgs e)
        {
            //if(pOperacion == Operacion.Nuevo)
            //{
                if (chkOtros.Checked)
                    txtEncuestaOtro.Properties.ReadOnly = false;
                else
                {
                    txtEncuestaOtro.Properties.ReadOnly = true;
                    txtEncuestaOtro.Text = string.Empty;
                }
                    
            //}
            
        }

        private void BloqueaModificar()
        {
            cboTipoPersona.Properties.ReadOnly = true;
            cboDocumento.Properties.ReadOnly = true;
            txtNumeroDocumento.Properties.ReadOnly = true;
            txtApPaterno.Properties.ReadOnly = true;
            txtApMaterno.Properties.ReadOnly = true;
            txtNombres.Properties.ReadOnly = true;
        }

        private void SeparaApellidosNombres()
        {
            bool bPaterno = false;
            bool bMaterno = false;

            string Nombres = "";
            string NombresMat = "";
            string ApPaterno = "";
            string ApMaterno = "";

            string Cliente = txtDescripcion.Text; //"de la ABC cd ef";

            string ClienteSinEspacios = Cliente.Replace(" ", "");
            //int TotalEspacios = Cliente.Length - ClienteSinEspacios.Length;

            string[] arr = Cliente.Split(new string[] { " " }, StringSplitOptions.None);

            string CadenaPat = "";
            string CadenaMat = "";
            string CadenaMat2 = "";
            string PriapMaterno = "";
            int RegistrosPat = 0;
            int RegistrosMat = 0;
            int RegistrosMat2 = 0;
            int RegistrosMatReg = 1;
            foreach (var item in arr)
            {
                if (!bPaterno)
                {
                    CadenaPat = (CadenaPat + " " + item).ToUpper().Trim();
                    if (CadenaPat == "LA" || CadenaPat == "DEL" || CadenaPat == "DE" || CadenaPat == "LAS" || CadenaPat == "LOS" //{ "da", "de", "del", "la", "las", "los", "mac", "mc", "van", "von", "y", "i", "san", "santa" };
                        || CadenaPat == "DE LA" || CadenaPat == "DE LAS" || CadenaPat == "DE LOS")
                    {
                        RegistrosPat = RegistrosPat + 1;
                    }
                    else
                    {
                        if (RegistrosPat > 1)
                            ApPaterno = CadenaPat.Trim();
                        else
                            ApPaterno = item;
                        bPaterno = true;
                        continue;
                    }
                }

                if (bPaterno && !bMaterno)
                {
                    CadenaMat = (CadenaMat + " " + item).ToUpper().Trim();
                    if (CadenaMat == "LA" || CadenaMat == "DEL" || CadenaMat == "DE" || CadenaMat == "LAS" || CadenaMat == "LOS" | CadenaMat == "DE LA" || CadenaMat == "DE LAS" || CadenaMat == "DE LOS")
                    {
                        RegistrosMat = RegistrosMat + 1;
                    }
                    else
                    {
                        if (RegistrosMat > 0)
                        {
                            ApMaterno = CadenaMat;
                            bMaterno = true;
                        }
                        else
                        {
                            if (RegistrosMatReg > 1)
                            {
                                CadenaMat2 = (CadenaMat2 + "" + item).ToUpper().Trim();
                                if (CadenaMat2 == "LA" || CadenaMat2 == "DEL" || CadenaMat2 == "DE" || CadenaMat2 == "LAS" || CadenaMat2 == "LOS" | CadenaMat2 == "DE LA" || CadenaMat2 == "DE LAS" || CadenaMat2 == "DE LOS")
                                {
                                    RegistrosMat2 = RegistrosMat2 + 1;
                                }
                                else
                                {
                                    if (RegistrosMat2 > 0)
                                    {
                                        ApMaterno = PriapMaterno + " " + CadenaMat2;
                                        bMaterno = true;
                                        continue;
                                    }
                                    else
                                    {
                                        ApMaterno = PriapMaterno;
                                        NombresMat = item;//Verificar
                                        bMaterno = true;
                                        //continue;
                                    }
                                }
                            }
                            else
                            {
                                PriapMaterno = item;
                                RegistrosMatReg = RegistrosMatReg + 1;
                            }
                        }
                    }
                }

                if (bPaterno && bMaterno) //Nombres
                {
                    if (NombresMat.Length > 0)
                    {
                        Nombres = NombresMat;
                        NombresMat = string.Empty;
                    }
                    else
                    {
                        Nombres = (Nombres + " " + item).Trim();
                    }
                }
            }

            txtApPaterno.Text = ApPaterno;
            txtApMaterno.Text = ApMaterno;
            txtNombres.Text = Nombres;
        }

        private void txtNombres_KeyUp(object sender, KeyEventArgs e)
        {
            txtDescripcion.Text = (txtApPaterno.Text.Trim() + " " + txtApMaterno.Text.Trim() + " " + txtNombres.Text).Trim();
        }

        private void txtApPaterno_KeyUp(object sender, KeyEventArgs e)
        {
            txtDescripcion.Text = (txtApPaterno.Text.Trim() + " " + txtApMaterno.Text.Trim() + " " + txtNombres.Text).Trim();
        }

        private void txtApMaterno_KeyUp(object sender, KeyEventArgs e)
        {
            txtDescripcion.Text = (txtApPaterno.Text.Trim() + " " + txtApMaterno.Text.Trim() + " " + txtNombres.Text).Trim();
        }

        private void gcTxtNumeroTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmBusClienteTelefonos objClienteTelefonos = new frmBusClienteTelefonos();
                objClienteTelefonos.IdCliente = IdCliente;
                objClienteTelefonos.ShowDialog();
                if (objClienteTelefonos._Be != null)
                {
                    int index = gvClienteTracking.FocusedRowHandle;

                    gvClienteTracking.SetRowCellValue(index, "Numero", objClienteTelefonos._Be.Telefonos);
                    gvClienteTracking.UpdateCurrentRow();

                    gvClienteTracking.FocusedRowHandle = index;
                    gvClienteTracking.FocusedColumn = gvClienteTracking.Columns["Comentario"];
                    gvClienteTracking.ShowEditor();

                }
            }
        }

        private void nuevoClienteTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvClienteTracking.AddNewRow();
                if (pOperacion == Operacion.Modificar)
                {
                    gvClienteTracking.SetRowCellValue(gvClienteTracking.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    gvClienteTracking.SetRowCellValue(gvClienteTracking.FocusedRowHandle, "IdClienteTracking", 0);
                    gvClienteTracking.SetRowCellValue(gvClienteTracking.FocusedRowHandle, "FechaRegistro", DateTime.Now);
                    gvClienteTracking.SetRowCellValue(gvClienteTracking.FocusedRowHandle, "FechaProxima", DateTime.Now);
                }
                else
                {
                    gvClienteTracking.SetRowCellValue(gvClienteTracking.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    gvClienteTracking.SetRowCellValue(gvClienteTracking.FocusedRowHandle, "IdClienteTracking", 0);
                    gvClienteTracking.SetRowCellValue(gvClienteTracking.FocusedRowHandle, "FechaRegistro", DateTime.Now);
                    gvClienteTracking.SetRowCellValue(gvClienteTracking.FocusedRowHandle, "FechaProxima", DateTime.Now);
                }
                gvClienteTracking.FocusedColumn = gvClienteTracking.Columns["Numero"];
                gvClienteTracking.ShowEditor();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminaClienteTrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClienteTracking = 0;
                IdClienteTracking = int.Parse(gvClienteTracking.GetFocusedRowCellValue("IdClienteTracking").ToString());
                ClienteTrackingBE objBE_ClienteTracking = new ClienteTrackingBE();
                objBE_ClienteTracking.IdClienteTracking = IdClienteTracking;
                objBE_ClienteTracking.IdEmpresa = Parametros.intEmpresaId;
                objBE_ClienteTracking.Usuario = Parametros.strUsuarioLogin;
                objBE_ClienteTracking.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ClienteTrackingBL objBL_ClienteTracking = new ClienteTrackingBL();
                objBL_ClienteTracking.Elimina(objBE_ClienteTracking);
                gvClienteTracking.DeleteRow(gvClienteTracking.FocusedRowHandle);
                gvClienteTracking.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtSituacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmBuscaTablaElemento objTablaElemento = new frmBuscaTablaElemento();
                objTablaElemento.IdTabla = Parametros.intTblTrackingCliente;
                objTablaElemento.ShowDialog();
                if (objTablaElemento.pTablaElementoBE != null)
                {
                    int index = gvClienteTracking.FocusedRowHandle;

                    gvClienteTracking.SetRowCellValue(index, "IdSituacion", objTablaElemento.pTablaElementoBE.IdTablaElemento);
                    gvClienteTracking.SetRowCellValue(index, "DescSituacion", objTablaElemento.pTablaElementoBE.DescTablaElemento);
                    gvClienteTracking.UpdateCurrentRow();

                }
            }
        }

        private void txtNumeroDocumento_Validated(object sender, EventArgs e)
        {                //CONSULTAR SI EXISTE
            ClienteBE objE_ClienteV = null;
            objE_ClienteV = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());

            if (objE_ClienteV != null)
            {

                if (XtraMessageBox.Show("El numero de documento se encuentra registrado.\n " + "Cliente: " + wDescCliente + " \n \n ¿Desea seleccionar al cliente para asignarlo al pedido N° " + wPedidoWeb + " ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    PedidoBL objBL_Pedido = new PedidoBL();
                    objBL_Pedido.Actualizar_PedidoWeb(wIdPedidoWeb
                                                         , objE_ClienteV.IdCliente
                                                       , objE_ClienteV.NumeroDocumento
                                                       , objE_ClienteV.DescCliente
                                                       , objE_ClienteV.Direccion
                                                       , 1);
                    this.Close();
                }
                else
                {
                    txtNumeroDocumento.Focus();
                    return;

                }

            }
        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {
                //CONSULTAR SI EXISTE
                    ClienteBE objE_ClienteV = null;
                    objE_ClienteV = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());

                    if (objE_ClienteV != null)
                    {

                        if (XtraMessageBox.Show("El numero de documento se encuentra registrado.\n " + "Cliente: " + wDescCliente + " \n \n ¿Desea seleccionar al cliente para asignarlo al pedido N° " + wPedidoWeb + " ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                        {
                            PedidoBL objBL_Pedido = new PedidoBL();
                            objBL_Pedido.Actualizar_PedidoWeb(wIdPedidoWeb
                                                                 , objE_ClienteV.IdCliente
                                                               , objE_ClienteV.NumeroDocumento
                                                               , objE_ClienteV.DescCliente
                                                               , objE_ClienteV.Direccion
                                                               , 1);
                            this.Close();
                        }
                        else
                        {
                    txtNumeroDocumento.Focus();
                    return;

                        }

                    }

        }
    }
}