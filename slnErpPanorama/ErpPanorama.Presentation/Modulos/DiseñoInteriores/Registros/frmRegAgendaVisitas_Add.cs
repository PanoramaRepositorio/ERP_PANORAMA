using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmRegAgendaVisitas_Add : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"
        int vIdCliente = 0;
        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        int _IdCliente = 0;

        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        int _IdTipoCliente = 0;

        public int IdTipoCliente
        {
            get { return _IdTipoCliente; }
            set { _IdTipoCliente = value; }
        }

        int _IdAsesor = 0;

        public int IdAsesor
        {
            get { return _IdAsesor; }
            set { _IdAsesor = value; }
        }

        string _NombresAsesor = "";
        public string NombresAsesor
        {
            get { return _NombresAsesor; }
            set { _NombresAsesor = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public AsesoriaBE pAsesoriaBE { get; set; }

        private List<AgendaVisitaBE> mPendientes = new List<AgendaVisitaBE>();

        #endregion

        #region "Eventos"

        public frmRegAgendaVisitas_Add()
        {
            InitializeComponent();
        }

        private void frmRegAgendaVisitas_Add_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;
            lblDisenadora.Text = NombresAsesor;
            deFecha.EditValue = DateTime.Now;
            //BSUtils.LoaderLook(cboAsesor, new PersonaBL().SeleccionaAsesor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            //BSUtils.LoaderLook(cboMotivo, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 92), "DescTablaElemento", "IdTablaElemento", true);  //Motivo VISITA
            cboMotivo.EditValue = 553;
            //cboMotivo.EditValue = Parametros.intTiendaId;   // .strUsuarioLogin;

            txtDuracion.Text= String.Format("{0:0}", 0);
            txtPrecioVisita.Text = String.Format("{0:#,##0.00}", 0);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Modificar";
                //deFechaContrato.EditValue = pAsesoriaBE.FechaContrato;
                //deFechaVenta.EditValue = pAsesoriaBE.FechaVenta;
                //deFechaVisita.EditValue = pAsesoriaBE.FechaVisita;
                //deFechaEntrega.EditValue = pAsesoriaBE.FechaEntrega;
                txtObservaciones.EditValue = pAsesoriaBE.Observacion;
                //txtNumero.EditValue = pAsesoriaBE.Numero;
                IdPedido = Convert.ToInt32(pAsesoriaBE.IdPedido);
                IdCliente = pAsesoriaBE.IdCliente;
                txtNumProyecto.ReadOnly = true;
                //cboAsesor.EditValue = pAsesoriaBE.IdAsesor;
                //btnBuscar.Enabled = false;
            }
            //deFecha.Select();
            txtNumeroDocumento.Select();

            CargarPendiente();
            txtNumProyecto.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //if (!ValidarIngreso())
                //{
                    AgendaVisitaBE objAgenda = new AgendaVisitaBE();
                    AgendaVisitaBL objBL_Agenda = new AgendaVisitaBL();

                if (txtNumeroDocumento.Text.Trim()==""  || txtDireccion.Text.Trim()=="")
                {
                    XtraMessageBox.Show("Ingrese nombre/dirección cliente para la cita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumeroDocumento.Select();
                    return;
                }

                if (Convert.ToInt32(cboMotivo.EditValue)==0)
                {
                    XtraMessageBox.Show("Seleccione el motivo de la cita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMotivo.Select();
                    return;
                }

                if (txtAgenda.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingrese la agenda de la cita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAgenda.Select();
                    return;
                }
           
                if (DateTime.Now.Date > Convert.ToDateTime(denavAgenda.EditValue))
                {
                    XtraMessageBox.Show("La fecha de la Cita no puede ser menor a la fecha de hoy.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Convert.ToString(denavAgenda.EditValue).Substring(11, 8) == "00:00:00")
                {
                    XtraMessageBox.Show("Ingrese la hora de la cita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    denavAgenda.Select();
                    return;
                }
                if (Convert.ToInt32(txtDuracion.Text)==0)
                {
                    XtraMessageBox.Show("Ingrese la duración de la cita. (aprox. en minutos)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDuracion.Select();
                    return;
                }

                

                objAgenda.IdPersona = IdAsesor;
                objAgenda.IdCliente = IdCliente;
                objAgenda.FechaAgendaVisita = Convert.ToDateTime(deFecha.EditValue);
                objAgenda.Lugar = txtDireccion.Text.Trim();
                objAgenda.Ubigeo = cboDepartamento.EditValue.ToString().Trim() + cboProvincia.EditValue.ToString().Trim() + cboDistrito.EditValue.ToString().Trim();
                objAgenda.Celular = txtCelular.Text;
                objAgenda.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                objAgenda.Agenda = txtAgenda.Text;
                objAgenda.Observacion = txtObservaciones.Text.Trim();
                objAgenda.Duracion = Convert.ToInt32(txtDuracion.Text);
                objAgenda.IdSituacion = Parametros.intProgramado;
                objAgenda.Usuario = Parametros.strUsuarioLogin;
                objAgenda.FechaAgenda = Convert.ToDateTime(denavAgenda.EditValue);
                objAgenda.PrecioVisita = Convert.ToDecimal(txtPrecioVisita.Text);
                objAgenda.NumeroProyecto = txtNumProyecto.Text.ToString();

                //if (pOperacion == Operacion.Nuevo)
                //objBL_Agenda.Inserta(objAgenda);

                List<AgendaVisitaBE> agendaXvendedora = objBL_Agenda.ListaFechaVisitasValidarFecha(Convert.ToDateTime(denavAgenda.EditValue), Convert.ToDateTime(denavAgenda.EditValue));
                string fecha = String.Format("Día {0} ocupado.\n", Convert.ToDateTime(denavAgenda.EditValue).ToString("dd/MM/yyyy"));
                string mensaje_exitoso = "Se guardó satisfactoriamente la cita.";

                if (agendaXvendedora.Count == 0)
                {
                    objBL_Agenda.Inserta(objAgenda);
                    XtraMessageBox.Show(mensaje_exitoso, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (agendaXvendedora.Count > 0)
                {
                    if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeProduccion1)
                    {
                        DialogResult dr = XtraMessageBox.Show(fecha + "¿Desea agregar excepcionalmente otra visita en el mismo dia?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.OK)
                        {
                            objBL_Agenda.Inserta(objAgenda);
                            XtraMessageBox.Show(mensaje_exitoso, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (dr == DialogResult.Cancel)
                        {
                            XtraMessageBox.Show(fecha, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            XtraMessageBox.Show(fecha, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita && frmAutoriza.FlagMaster)
                        {
                            if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "rtapia" || frmAutoriza.Usuario == "focampo" ||
                               frmAutoriza.Usuario == "dhuaman" || frmAutoriza.Usuario == "aflores" || frmAutoriza.Usuario == "jlquispe" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador ||
                               Parametros.intPerfilId == Parametros.intPerHelpDesk || frmAutoriza.Usuario == "kconcha" || frmAutoriza.Usuario == "pdelaguila" || frmAutoriza.Usuario == "jvallejo" ||
                               frmAutoriza.IdPerfil == Parametros.intPerAdministradorTienda)
                            {
                                //if (IdAsesor == 6827 || IdAsesor == 9857)
                                //{
                                objBL_Agenda.Inserta(objAgenda);
                                XtraMessageBox.Show(mensaje_exitoso, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
                                //else
                                //{
                                //    XtraMessageBox.Show("No puede agendar más de una visita", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //}

                                //XtraMessageBox.Show("No puede agendar más de una visita", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                XtraMessageBox.Show(fecha + "No puede agendar más de una visita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(fecha + "Usted no está autorizado para realizar otra visita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                //else
                //objBL_Asesoria.Actualiza(objAsesoria);
                //     objBL_Agenda.ActualizaFecha(objAgenda);
                //XtraMessageBox.Show("Se guardo satisfactoriamente la cita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                //}
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

        private void deFechaContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaVisita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFechaEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmBusCliente frm = new frmBusCliente();
            //    frm.pFlagMultiSelect = false;
            //    frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
            //    frm.ShowDialog();
            //    if (frm.pClienteBE != null)
            //    {
            //        IdCliente = frm.pClienteBE.IdCliente;
            //        txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
            //        txtDescCliente.Text = frm.pClienteBE.DescCliente;
            //        deFechaVenta.Focus();
            //    }
            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Ingrese el Cliente.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void Autorizar()
        {
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita && frmAutoriza.FlagMaster)
            {
                if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "rtapia" || frmAutoriza.Usuario == "pdelaguila" ||
                   frmAutoriza.Usuario == "dhuaman" || frmAutoriza.Usuario == "aflores" || frmAutoriza.Usuario == "jlquispe" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador ||
                   Parametros.intPerfilId == Parametros.intPerHelpDesk || frmAutoriza.Usuario == "kconcha" || frmAutoriza.Usuario == "focampo" ||
                   frmAutoriza.IdPerfil == Parametros.intPerAdministradorTienda)
                {

                }
                else
                {
                    XtraMessageBox.Show("Usted no puede realizar otra visita", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // 170323 ->
        private void CargarPendiente()
        {
            mPendientes = new AgendaVisitaBL().ListaVisitasPendientes(IdAsesor);
            gcPendientes.DataSource = mPendientes;
        }

        #endregion

        private void cboAsesor_EditValueChanged(object sender, EventArgs e)
        {


        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();

                if (frm.pClienteBE != null)
                {
                    if (frm.pClienteBE.AbrevDomicilio == "OTR") frm.pClienteBE.AbrevDomicilio = ""; else frm.pClienteBE.AbrevDomicilio = frm.pClienteBE.AbrevDomicilio + " ";

                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;

                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        DateTime FechaNac = frm.pClienteBE.FechaNac == null ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(frm.pClienteBE.FechaNac.ToString());
                        int PeriodoNac = FechaNac.Year;
                        int Anios = Parametros.intPeriodo - PeriodoNac;

                        //Compras del mes
                        List<DocumentoVentaBE> lstVenta = null;
                        lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, frm.pClienteBE.IdCliente);
                    }

                    string IdDepartamento = string.Empty;
                    string IdProvincia = string.Empty;
                    string IdDistrito = string.Empty;

                        ClienteBE objE_Cliente = null;
                        objE_Cliente = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, frm.pClienteBE.NumeroDocumento);
                        txtCelular.Text = objE_Cliente.Celular;
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.AbrevDomicilio == "OTR")
                            objE_Cliente.AbrevDomicilio = "";
                        else
                            objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDepartamento = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                        cboDepartamento.EditValue = IdDepartamento;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdProvincia = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                        cboProvincia.EditValue = IdProvincia;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDistrito = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                        cboDistrito.EditValue = IdDistrito;
                    }

                        }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.AbrevDomicilio == "OTR")
                            objE_Cliente.AbrevDomicilio = "";
                        else
                            objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion;  // + objE_Cliente.NumDireccion;
                        IdTipoCliente = objE_Cliente.IdTipoCliente;
                        txtCelular.Text = objE_Cliente.Celular;

                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDepartamento = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                        cboDepartamento.EditValue = IdDepartamento;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdProvincia = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                        cboProvincia.EditValue = IdProvincia;
                        if (objE_Cliente.IdUbigeoDom.Trim() != "")
                            IdDistrito = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                        cboDistrito.EditValue = IdDistrito;
                    }
                    else
                    {
                        if (XtraMessageBox.Show("El cliente no existe, desea registrar al nuevo cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            btnNuevoCliente_Click(sender, e);
                        }
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    txtDescCliente.Text = objManCliente.DescCliente;
                    txtDireccion.Text = objManCliente.AbrevDocimicilio.Substring(0, 2) + ". " + objManCliente.Direccion + ' ' + objManCliente.NumDireccion + ' ' + objManCliente.DescDistrito + '-' + objManCliente.DescProvincia + '-' + objManCliente.DescDepartamento;//add
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;


                        ClienteBE objE_Cliente2 = null;
                        objE_Cliente2 = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, objE_Cliente.NumeroDocumento.Trim());
                        txtCelular.Text = objE_Cliente2.Celular;

                        if (objE_Cliente2 != null)
                        {
                            if (objE_Cliente2.AbrevDomicilio == "OTR")
                                objE_Cliente2.AbrevDomicilio = "";
                            else
                                objE_Cliente2.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                            IdCliente = objE_Cliente2.IdCliente;
                            txtNumeroDocumento.Text = objE_Cliente2.NumeroDocumento;
                            txtDescCliente.Text = objE_Cliente2.DescCliente;
                            txtDireccion.Text = objE_Cliente2.AbrevDomicilio + " " + objE_Cliente.Direccion;  // + objE_Cliente.NumDireccion;
                            IdTipoCliente = objE_Cliente2.IdTipoCliente;

                            if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                                IdDepartamento = objE_Cliente2.IdUbigeoDom.Substring(0, 2);
                            cboDepartamento.EditValue = IdDepartamento;
                            if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                                IdProvincia = objE_Cliente2.IdUbigeoDom.Substring(2, 2);
                            cboProvincia.EditValue = IdProvincia;
                            if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                                IdDistrito = objE_Cliente2.IdUbigeoDom.Substring(4, 2);
                            cboDistrito.EditValue = IdDistrito;
                        }


                    }




                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtNumProyecto_KeyUp(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
            {
                this.txtNumProyecto.Text = txtNumProyecto.Text.ToString().PadLeft(6, '0');
                Dis_ProyectoServicioBE objE_NumProyecto = null;
                objE_NumProyecto = new Dis_ProyectoServicioBL().SeleccionaNumero(DateTime.Now.Year, Convert.ToString(txtNumProyecto.Text.ToString().PadLeft(6, '0')));

                if (objE_NumProyecto != null)
                {
                    IdCliente = objE_NumProyecto.IdCliente;
                    txtNumeroDocumento.EditValue = objE_NumProyecto.NumeroDocumento;
                    txtDescCliente.EditValue = objE_NumProyecto.DescCliente;
                    txtDireccion.Text = objE_NumProyecto.Direccion;


                    denavAgenda.EditValue = objE_NumProyecto.FechaVisita;
                    denavAgenda.DateTime = Convert.ToDateTime( objE_NumProyecto.FechaVisita);
                    txtPrecioVisita.Text = String.Format("{0:#,##0.00}", objE_NumProyecto.PagoAsesoria.ToString());
                    txtObservaciones.EditValue = objE_NumProyecto.Observacion;


                    //IdAgendaVisita = objE_Visitas.IdAgendaVisita;

                    //txtNumVisita.EditValue = objE_Visitas.NumAgendaVisita;
                    //cboFechaVisita.EditValue = objE_Visitas.FechaAgenda;
                    //txtHoraInicio.EditValue = objE_Visitas.Hora;
                    //txtHoraFin.EditValue = objE_Visitas.TiempoTermino;
                    //txtMotivoVisita.EditValue = objE_Visitas.DescMotivo;
                    //txtAgenda.EditValue = objE_Visitas.Agenda;
                    //txtPrecio.EditValue = String.Format("{0:#,##0.00}", objE_Visitas.PrecioVisita);
                    //vSituacion = objE_Visitas.Situacion;
                    //txtDisenador.EditValue = objE_Visitas.Nombres;
                }
                else
                {
                    //AgendaVisitaBE objE_Visitas2 = null;
                    //objE_Visitas2 = new AgendaVisitaBL().BuscarNumVisitaAsociada(Convert.ToString(txtNumVisita.Text.ToString().PadLeft(8, '0')));

                    //if (objE_Visitas2 != null)
                    //{
                    //    XtraMessageBox.Show("El numero de visita ya se encuentra asociada al Nro. Proyecto " + objE_Visitas2.NumeroProyecto, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                }
                txtNumeroDocumento.Select();
            }
        }
    }
}