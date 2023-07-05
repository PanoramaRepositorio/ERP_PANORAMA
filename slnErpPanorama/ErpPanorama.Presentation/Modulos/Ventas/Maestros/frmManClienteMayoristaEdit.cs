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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.Text.RegularExpressions;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManClienteMayoristaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ClienteBE> lstCliente;

        public List<CClienteLineaProducto> mListaClienteLineaProductoOrigen = new List<CClienteLineaProducto>();
        public List<CClienteAsociado> mListaClienteAsociadoOrigen = new List<CClienteAsociado>();
        public List<CClienteCorreo> mListaClienteCorreoOrigen = new List<CClienteCorreo>();
        private List<ReportePedidoClienteLineaBE> mListaPedidoClienteLinea = new List<ReportePedidoClienteLineaBE>();
        public List<CClienteTracking> mListaClienteTrackingOrigen = new List<CClienteTracking>();
        //private List<ReporteClienteCumpleanosBE> mListaClienteCumpleanos= new List<ReporteClienteCumpleanosBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }
        int rbuton = 0;
        int _IdCliente = 0;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }
        private int IdClienteOficina = 0;
        private bool FlagSuspendido = false;


        #endregion

        #region "Eventos"

        public frmManClienteMayoristaEdit()
        {
            InitializeComponent();
        }

        private void frmManClienteMayoristaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDocCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboDocumento.EditValue = Parametros.intTipoDocumentoDNI;
            BSUtils.LoaderLook(cboTipoDireccion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoDireccion), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoDireccion.EditValue = Parametros.intTipoDireccionAV;
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;

            deFechaNac.EditValue = DateTime.Now;
            deFechaAniv.EditValue = DateTime.Now;
            txtPeriodo.EditValue = Parametros.intPeriodo;
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            BSUtils.LoaderLook(cboCategoria, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCategoria), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboUbicacionEstrategica, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblUbicacionEstrategica), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTamanoLocal, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTamanoLocal), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboRuta, new RutaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescRuta", "IdRuta", true);
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaCargo(Parametros.intEmpresaId, Parametros.intGestorCartera), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboTipoLocal, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoLocal), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboCondicion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCondicionCliente), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intSITClienteActivo;
            BSUtils.LoaderLook(cboSexo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSexo), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboMotivoSituacion, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoSituacionCliente), "DescTablaElemento", "IdTablaElemento", true);

            BSUtils.LoaderLook(cboDestino, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblDestinoDespacho), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboAgencia, new AgenciaBL().ListaTodosActivo(), "DescAgencia", "IdAgencia", true);
            BSUtils.LoaderLook(cboCompraSolo, CargarLineaUnica(), "Descripcion", "Id", true);
            BSUtils.LoaderLook(cboTipoPersona, CargarTipoPersona(), "Descripcion", "Id", true);


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Cliente Mayorista - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Cliente Mayorista - Modificar";

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
                cboTipoPersona.EditValue = objE_Cliente.TipoPersona;
                txtRepresentante.EditValue = objE_Cliente.Representante;
                txtContacto.Text = objE_Cliente.Contacto;
                txtTelefono.EditValue = objE_Cliente.Telefono;
                txtCelular.EditValue = objE_Cliente.Celular;
                txtOtroTelefono.EditValue = objE_Cliente.OtroTelefono;
                txtTelefonoAdicional.Text = objE_Cliente.TelefonoAdicional;
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
                txtUrbanizacion.Text = objE_Cliente.Urbanizacion;
                txtReferencia.Text = objE_Cliente.Referencia;
                cboCategoria.EditValue = objE_Cliente.IdCategoria;
                cboUbicacionEstrategica.EditValue = objE_Cliente.IdUbicacionEstrategica;
                cboTamanoLocal.EditValue = objE_Cliente.IdTamanoLocal;
                cboRuta.EditValue = objE_Cliente.IdRuta;
                txtObservacion.Text = objE_Cliente.Observacion;
                txtAgencia.Text = objE_Cliente.Agencia;
                lblFechaRegistro.Text = objE_Cliente.Fecha.ToString();
                cboVendedor.EditValue = objE_Cliente.IdVendedor;
                cboTipoLocal.EditValue = objE_Cliente.IdTipoLocal;
                cboCondicion.EditValue = objE_Cliente.IdCondicion;
                cboSituacion.EditValue = objE_Cliente.IdSituacion;
                cboAgencia.EditValue = objE_Cliente.IdAgencia;
                cboDestino.EditValue = objE_Cliente.IdDestino;
                cboCompraSolo.EditValue = objE_Cliente.LineaUnica;
                chkSuspendido.Checked = objE_Cliente.FlagSuspendido;
                FlagSuspendido = objE_Cliente.FlagSuspendido;
                IdClienteOficina = objE_Cliente.IdRuta; //add
                txtTotalVenta.EditValue = objE_Cliente.TotalVenta;
                cboMotivoSituacion.EditValue = objE_Cliente.IdMotivoSituacion;
                cboSexo.EditValue = objE_Cliente.IdSexo;

                cboRuta.Properties.ReadOnly = true;//add
                cboVendedor.Properties.ReadOnly = true;//add

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

                if (objE_Cliente.IdCondicion== Parametros.intSITClienteInactivo)
                {
                    if(Parametros.intPerfilId ==Parametros.intPerAdministrador || Parametros.intPerfilId ==Parametros.intPerJefeCreditoCobranzas|| Parametros.intPerfilId == Parametros.intPerHelpDesk)
                        cboSituacion.Properties.ReadOnly = true;
                    else
                        cboSituacion.Properties.ReadOnly = true;
                }
            }

            //cboDepartamento_EditValueChanged(null, null);

            CargaClienteLineaProducto();
            CargaClienteAsociado();
            CargaClienteCorreo();
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ClienteBL objBL_Cliente = new ClienteBL();
                    ClienteBE objE_Cliente = new ClienteBE();

                    if (radioButton1.Checked)
                    {
                        rbuton = 1;  // Si es 1 corresponde a radio1
                    }
                    else if (radioButton2.Checked)
                    {
                        rbuton = 2;  // Si es 2 corresponde a radio2
                    }

                    objE_Cliente.IdCliente = IdCliente;
                    objE_Cliente.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_Cliente.NumeroDocumento = txtNumeroDocumento.Text.ToString().Trim();
                    objE_Cliente.DescCliente = txtDescripcion.Text;
                    objE_Cliente.TipoPersona = cboTipoPersona.EditValue.ToString();
                    objE_Cliente.Representante = txtRepresentante.Text;
                    objE_Cliente.Contacto = txtContacto.Text;
                    objE_Cliente.IdTipoDireccion = Convert.ToInt32(cboTipoDireccion.EditValue);
                    objE_Cliente.IdSexo = Convert.ToInt32(cboSexo.EditValue);
                    objE_Cliente.Direccion = txtDireccion.Text;
                    objE_Cliente.NumDireccion = txtNumeroDireccion.Text;
                    objE_Cliente.Urbanizacion = txtUrbanizacion.Text;
                    objE_Cliente.Referencia = txtReferencia.Text;
                    objE_Cliente.IdUbigeoDom = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objE_Cliente.Direccion = txtDireccion.Text;
                    objE_Cliente.Telefono = txtTelefono.Text;
                    objE_Cliente.Celular = txtCelular.Text;
                    objE_Cliente.OtroTelefono = txtOtroTelefono.Text;
                    objE_Cliente.TelefonoAdicional = txtTelefonoAdicional.Text;
                    objE_Cliente.Email = txtEmail.Text;
                    objE_Cliente.EmailFE = txtEmailFE.Text;
                    objE_Cliente.FechaNac = deFechaNac.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaNac.DateTime.ToShortDateString());
                    objE_Cliente.FechaAniv = deFechaAniv.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaAniv.DateTime.ToShortDateString());
                    objE_Cliente.IdTipoCliente = Parametros.intTipClienteMayorista;
                    objE_Cliente.IdClasificacionCliente = Parametros.intClasico;
                    objE_Cliente.IdCategoria = Convert.ToInt32(cboCategoria.EditValue);
                    objE_Cliente.IdUbicacionEstrategica = Convert.ToInt32(cboUbicacionEstrategica.EditValue);
                    objE_Cliente.IdTamanoLocal = Convert.ToInt32(cboTamanoLocal.EditValue);
                    objE_Cliente.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objE_Cliente.IdRuta = Convert.ToInt32(cboRuta.EditValue);
                    objE_Cliente.IdTipoLocal = Convert.ToInt32(cboTipoLocal.EditValue);
                    objE_Cliente.IdCondicion = Convert.ToInt32(cboCondicion.EditValue);
                    objE_Cliente.IdSituacion = Convert.ToInt32(cboSituacion.EditValue);
                    objE_Cliente.IdAgencia = Convert.ToInt32(cboAgencia.EditValue);
                    objE_Cliente.IdDestino = Convert.ToInt32(cboDestino.EditValue);
                    objE_Cliente.LineaUnica = Convert.ToInt32(cboCompraSolo.EditValue);
                    objE_Cliente.Observacion = txtObservacion.Text;
                    objE_Cliente.Agencia = txtAgencia.Text;
                    //objE_Cliente.FlagSuspendido = chkSuspendido.Checked;
                    objE_Cliente.FlagSuspendido = FlagSuspendido;
                    objE_Cliente.IdMotivoSituacion = Convert.ToInt32(cboMotivoSituacion.EditValue);
                    objE_Cliente.IdTienda = Parametros.intTiendaId;
                    objE_Cliente.FlagEstado = true;
                    objE_Cliente.Usuario = Parametros.strUsuarioLogin;
                    objE_Cliente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Cliente.IdEmpresa = Parametros.intEmpresaId;

                    objE_Cliente.Procede = rbuton;

                    //Cliente Linea Producto
                    List<ClienteLineaProductoBE> lstClienteLineaProducto = new List<ClienteLineaProductoBE>();
                    foreach (var item in mListaClienteLineaProductoOrigen)
                    {
                        ClienteLineaProductoBE objE_ClienteLineaProducto = new ClienteLineaProductoBE();
                        objE_ClienteLineaProducto.IdClienteLineaProducto = item.IdClienteLineaProducto;
                        objE_ClienteLineaProducto.IdCliente = IdCliente;
                        objE_ClienteLineaProducto.IdLineaProducto = item.IdLineaProducto;
                        objE_ClienteLineaProducto.Numero = item.Numero;
                        objE_ClienteLineaProducto.FlagEstado = true;
                        objE_ClienteLineaProducto.Usuario = Parametros.strUsuarioLogin;
                        objE_ClienteLineaProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClienteLineaProducto.IdEmpresa = Parametros.intEmpresaId; 
                        objE_ClienteLineaProducto.TipoOper = item.TipoOper;
                        lstClienteLineaProducto.Add(objE_ClienteLineaProducto);
                    }

                    //Cliente Asociado
                    List<ClienteAsociadoBE> lstClienteAsociado = new List<ClienteAsociadoBE>();
                    foreach (var item in mListaClienteAsociadoOrigen)
                    {
                        ClienteAsociadoBE objE_ClienteAsociado = new ClienteAsociadoBE();
                        objE_ClienteAsociado.IdClienteAsociado = item.IdClienteAsociado;
                        objE_ClienteAsociado.IdCliente = IdCliente;
                        objE_ClienteAsociado.IdTipoDocumento = item.IdTipoDocumento;
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
                                XtraMessageBox.Show("Verificar el número de RUC - Cliente asociado, debe contener 11 Dígitos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                        objE_ClienteAsociado.NumeroDocumento = item.NumeroDocumento.Trim();
                        objE_ClienteAsociado.DescCliente = item.DescCliente;
                        objE_ClienteAsociado.Direccion = item.Direccion;
                        objE_ClienteAsociado.FlagEstado = true;
                        objE_ClienteAsociado.Usuario = Parametros.strUsuarioLogin;
                        objE_ClienteAsociado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ClienteAsociado.IdEmpresa = Parametros.intEmpresaId;
                        objE_ClienteAsociado.TipoOper = item.TipoOper;
                        lstClienteAsociado.Add(objE_ClienteAsociado);
                    }

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

                    ClienteEncuestaBE objE_ClienteEncuesta = new ClienteEncuestaBE();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Cliente.Inserta(objE_Cliente, lstClienteLineaProducto, lstClienteAsociado, lstClienteCorreo, lstClienteTracking, objE_ClienteEncuesta);
                    else
                        objBL_Cliente.Actualiza(objE_Cliente, lstClienteLineaProducto, lstClienteAsociado, lstClienteCorreo, lstClienteTracking, objE_ClienteEncuesta);

                    this.Close();
                }
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

        private void nuevoLineaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvLineaProducto.AddNewRow();
                if (pOperacion == Operacion.Modificar)
                {
                    gvLineaProducto.SetRowCellValue(gvLineaProducto.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    gvLineaProducto.SetRowCellValue(gvLineaProducto.FocusedRowHandle, "IdClienteLineaProducto", 0);
                }
                else
                {
                    gvLineaProducto.SetRowCellValue(gvLineaProducto.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    gvLineaProducto.SetRowCellValue(gvLineaProducto.FocusedRowHandle, "IdClienteLineaProducto", 0);
                }
                gvLineaProducto.FocusedColumn = gvLineaProducto.Columns["DescLineaProducto"];
                gvLineaProducto.ShowEditor();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarLineaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdClienteLineaProducto = 0;
                IdClienteLineaProducto = int.Parse(gvLineaProducto.GetFocusedRowCellValue("IdClienteLineaProducto").ToString());
                ClienteLineaProductoBE objBE_ClienteLineaProducto = new ClienteLineaProductoBE();
                objBE_ClienteLineaProducto.IdClienteLineaProducto = IdClienteLineaProducto;
                objBE_ClienteLineaProducto.IdEmpresa = Parametros.intEmpresaId;
                objBE_ClienteLineaProducto.Usuario = Parametros.strUsuarioLogin;
                objBE_ClienteLineaProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ClienteLineaProductoBL objBL_ClienteLineaProducto = new ClienteLineaProductoBL();
                objBL_ClienteLineaProducto.Elimina(objBE_ClienteLineaProducto);
                gvLineaProducto.DeleteRow(gvLineaProducto.FocusedRowHandle);
                gvLineaProducto.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcTxtLineaServicio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmBusLineaProducto objLineaProducto = new frmBusLineaProducto();
                objLineaProducto.ShowDialog();
                if (objLineaProducto.pLineaProductoBE != null)
                {
                    var Buscar = mListaClienteLineaProductoOrigen.Where(oB => oB.IdLineaProducto == objLineaProducto.pLineaProductoBE.IdLineaProducto).ToList();
                    if (Buscar.Count > 0)
                    {
                        XtraMessageBox.Show("El tipo de linea de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                   
                    int index = gvLineaProducto.FocusedRowHandle;

                    gvLineaProducto.SetRowCellValue(index, "IdLineaProducto", objLineaProducto.pLineaProductoBE.IdLineaProducto);
                    gvLineaProducto.SetRowCellValue(index, "Numero", objLineaProducto.pLineaProductoBE.Numero);
                    gvLineaProducto.SetRowCellValue(index, "DescLineaProducto", objLineaProducto.pLineaProductoBE.DescLineaProducto);
                    gvLineaProducto.UpdateCurrentRow();

                    gvLineaProducto.FocusedRowHandle = index;
                    gvLineaProducto.FocusedColumn = gvLineaProducto.Columns["DescLineaProducto"];
                    gvLineaProducto.ShowEditor();

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

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 2)
            {
                CargarDetalleLinea();
            }

        }

        private void gvVentaLineaProducto_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvVentaLineaProducto.RowCount > 0)
            {
                //DataRow dr;
                int IdLineaProducto = 0;
                IdLineaProducto = int.Parse(gvVentaLineaProducto.GetFocusedRowCellValue("IdLineaProducto").ToString());
                CargarDetalles(IdLineaProducto);
                CalcularTotalesModelo();
            }
        }

        private void CargarDetalles(int IdLineaProducto)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle = FuncionBase.ToDataTable(new ReportePedidoClienteLineaBL().ListadoModelo(Convert.ToInt32(txtPeriodo.EditValue), IdCliente, IdLineaProducto));
                gcVentaModeloProducto.DataSource = dtDetalle;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDistrito_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDistrito.Text != "")
            {
                AsignarRutaVendedor();
            }

        }

        private void chkSuspendido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSuspendido.Checked == true)
                chkSuspendido.ForeColor = Color.Red;
            else
                chkSuspendido.ForeColor = Color.Black;

            if (Parametros.intPerfilId == Parametros.intPerJefeCreditoCobranzas || Parametros.intPerfilId == Parametros.intPerAsistenteFacturacion || Parametros.intPerfilId == Parametros.intPerAdministrador)
            {
                FlagSuspendido = chkSuspendido.Checked;
            }
        }

        private void cboSituacion_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intSITClienteInactivo)
            {
                cboMotivoSituacion.Visible = true;
                cboMotivoSituacion.EditValue = Parametros.intSITClienteInactivoCerroTienda;
            }
            else
            {
                cboMotivoSituacion.Visible = false;
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

            if (txtDireccion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la dirección del cliente.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboRuta.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Seleccione la ruta del cliente mayorista.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
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
            }

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoDNI)
            {
                if (txtNumeroDocumento.Text.Trim().Length != 8)
                {
                    strMensaje = strMensaje + "- El número de Dni debe de ser de 8 digitos.\n";
                    flag = true;
                }
            }

            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocumentoRUC)
            {
                if (txtNumeroDocumento.Text.Trim().Length != 11)
                {
                    strMensaje = strMensaje + "- El número de ruc debe de ser de 11 digitos.\n";
                    flag = true;
                }
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

            //Validar correo FE
            string CorreoFE = txtEmailFE.Text.Trim();
            if (CorreoFE.Length > 0)
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

        private void CargaClienteLineaProducto()
        {
            List<ClienteLineaProductoBE> lstTmpClienteLineaProducto = null;
            lstTmpClienteLineaProducto = new ClienteLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente);

            foreach (ClienteLineaProductoBE item in lstTmpClienteLineaProducto)
            {
                CClienteLineaProducto objE_ClienteLineaProducto = new CClienteLineaProducto();
                objE_ClienteLineaProducto.IdEmpresa = item.IdEmpresa;
                objE_ClienteLineaProducto.IdClienteLineaProducto = item.IdClienteLineaProducto;
                objE_ClienteLineaProducto.IdCliente = item.IdCliente;
                objE_ClienteLineaProducto.IdLineaProducto = item.IdLineaProducto;
                objE_ClienteLineaProducto.Numero = item.Numero;
                objE_ClienteLineaProducto.DescLineaProducto = item.DescLineaProducto;
                objE_ClienteLineaProducto.TipoOper = item.TipoOper;
                mListaClienteLineaProductoOrigen.Add(objE_ClienteLineaProducto);
            }

            bsListadoLineaProducto.DataSource = mListaClienteLineaProductoOrigen;
            gcLineaProducto.DataSource = bsListadoLineaProducto;
            gcLineaProducto.RefreshDataSource();
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

        private void AsignarRutaVendedor()
        {
            if (IdClienteOficina < 7)//add
            {
                string IdUbigeo = string.Empty;
                IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();

                RutaDetalleBE objE_RutaDetalle = new RutaDetalleBE();
                objE_RutaDetalle = new RutaDetalleBL().SeleccionaUbigeo(IdUbigeo);

                if (objE_RutaDetalle != null)
                {
                    cboRuta.EditValue = objE_RutaDetalle.IdRuta;
                    cboVendedor.EditValue = objE_RutaDetalle.IdVendedor;
                }
            }

        }

        private void CalcularTotalesLinea()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvVentaLineaProducto.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvVentaLineaProducto.GetRowCellValue(i, (gvVentaLineaProducto.Columns["TotalSoles"])));
                }
                txtTotal.EditValue = decTotal;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotalesModelo()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvVentaModeloProducto.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvVentaModeloProducto.GetRowCellValue(i, (gvVentaModeloProducto.Columns["TotalSolesM"])));
                }
                txtTotalModelo.EditValue = decTotal;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalleLinea()
        {
            mListaPedidoClienteLinea = new ReportePedidoClienteLineaBL().Listado(Convert.ToInt32(txtPeriodo.EditValue), IdCliente);
            gcVentaLineaProducto.DataSource = mListaPedidoClienteLinea;
            CalcularTotalesLinea();
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarDetalleLinea();
                CargarDetalles(0);
            }
        }

        private DataTable CargarLineaUnica()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "TODO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "NAVIDAD";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "RELIGIOSO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "MANTELERIA";
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

        public class CClienteLineaProducto
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdClienteLineaProducto { get; set; }
            public Int32 IdCliente { get; set; }
            public Int32 IdLineaProducto { get; set; }
            public Int32 Numero { get; set; }
            public String DescLineaProducto { get; set; }
            public Int32 TipoOper { get; set; }

            public CClienteLineaProducto()
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



        
    }
}