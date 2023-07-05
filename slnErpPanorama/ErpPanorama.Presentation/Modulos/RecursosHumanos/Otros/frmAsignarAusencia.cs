using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmAsignarAusencia : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"
        int _IdAusencia = 0;

        public int IdAusencia
        {
            get { return _IdAusencia; }
            set { _IdAusencia = value; }
        }

        public string Dni;
        public string ApeNom;
        public string Dia = "";
        public int Mes = 0;
        public int Periodo = 2000;
        public int IdPersona = 0;
        public int Origen = 0;
        public DateTime FechaRecupera;

        #endregion

        #region "Eventos"

        public frmAsignarAusencia()
        {
            InitializeComponent();
        }

        private void frmAsignarAusencia_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboMotivo, new MotivoAusenciaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMotivoAusencia", "IdMotivoAusencia", true);
            cboMotivo.EditValue = Parametros.intPersonaId;
            deFechaOrigen.EditValue = Convert.ToDateTime(Convert.ToDateTime(Dia + "/" + Mes.ToString() + "/" + Periodo.ToString()).ToString());
            txtDescPersona.Text = ApeNom;


            //Origen 1
            if (Origen == 1)
            {
                cboMotivo.EditValue = 8;
                cboMotivo.Properties.ReadOnly = true;
            }

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerJefeRRHH)
            {
                cboMotivo.Properties.ReadOnly = false;
            }
            else
            {
                cboMotivo.Properties.ReadOnly = true;
                cboMotivo.EditValue = 8;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (Origen == 1)
                {
                    if (deFecha.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar la fecha de recuperación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    //Descanso Correcto
                    if (chkValidarDescanso.Checked)
                    {
                        CheckinoutBE objE_Checkin = null;
                        objE_Checkin = new CheckinoutBL().SeleccionaFechaRecuperacion(Dni, Convert.ToDateTime(deFecha.DateTime));
                        if (objE_Checkin != null)
                        {
                            XtraMessageBox.Show("La fecha a recuperar es inválida, El día de descanso de " + ApeNom + " es " + objE_Checkin.Descanso, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                    FechaRecupera = Convert.ToDateTime(deFecha.EditValue);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }


                string Mensaje = "";
                string Observacion = "";
                int IdPersonaCalendarioLaboral = 0;

                if (Convert.ToInt32(cboMotivo.EditValue) == 8)
                {
                    if (deFecha.Text == "")
                    {
                        XtraMessageBox.Show("Ingresar la fecha de recuperación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    ////Fecha Marcada
                    //if (chkValidarMarcacion.Checked)
                    //{
                    //    CheckinoutBE objE_CheckinOut = null;
                    //    objE_CheckinOut = new CheckinoutBL().SeleccionaFecha(Dni, Convert.ToDateTime(deFecha.DateTime));
                    //    if (objE_CheckinOut != null)
                    //    {
                    //        XtraMessageBox.Show("La fecha a recuperar es inválida, Verificar que no exista marcación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //        Cursor = Cursors.Default;
                    //        return;
                    //    }
                    //}

                    //Descanso Correcto
                    if (chkValidarDescanso.Checked)
                    {
                        CheckinoutBE objE_Checkin = null;
                        objE_Checkin = new CheckinoutBL().SeleccionaFechaRecuperacion(Dni, Convert.ToDateTime(deFecha.DateTime));
                        if (objE_Checkin != null)
                        {
                            XtraMessageBox.Show("La fecha a recuperar es inválida, El día de descanso de " + ApeNom + " es " + objE_Checkin.Descanso, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cursor = Cursors.Default;
                            return;
                        }
                    }

                    //Fecha Asignada
                    if (chkValidarDescanso.Checked)
                    {
                        PersonaCalendarioLaboralBE objE_Checkin = null;
                        objE_Checkin = new PersonaCalendarioLaboralBL().SeleccionaPersonaFecha(Dni, Convert.ToDateTime(deFecha.DateTime));
                        if (objE_Checkin != null)
                        {
                            XtraMessageBox.Show("Ya existe una recuperación asignada, Por favor asigne otra fecha.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Cursor = Cursors.Default;
                            return;
                        }
                    }

                    PersonaCalendarioLaboralBL objBL_PersonaCalendario = new PersonaCalendarioLaboralBL();
                    PersonaCalendarioLaboralBE objE_PersonaCalendario = new PersonaCalendarioLaboralBE();
                    objE_PersonaCalendario.IdEmpresa = Parametros.intEmpresaId;
                    objE_PersonaCalendario.IdPersonaCalendarioLaboral = 0;
                    objE_PersonaCalendario.IdPersona = IdPersona;
                    objE_PersonaCalendario.Periodo = Periodo;
                    objE_PersonaCalendario.Mes = deFechaOrigen.DateTime.Month;//Mes;
                    objE_PersonaCalendario.Fecha = Convert.ToDateTime(deFecha.EditValue);
                    objE_PersonaCalendario.FechaInicio = Convert.ToDateTime(deFecha.EditValue);
                    objE_PersonaCalendario.FechaFin = Convert.ToDateTime(deFecha.EditValue);
                    objE_PersonaCalendario.IdHorarioTipoIncidencia = 0;
                    if (txtObservacion.Text.Trim() == "") objE_PersonaCalendario.Observacion = " GT "; else objE_PersonaCalendario.Observacion = txtObservacion.Text;
                    objE_PersonaCalendario.FechaOrigen = Convert.ToDateTime(Dia + "/" + Mes + "/" + Periodo);
                    objE_PersonaCalendario.IdMotivoAusencia = 8;
                    objE_PersonaCalendario.Usuario = Parametros.strUsuarioLogin;
                    objE_PersonaCalendario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_PersonaCalendario.FlagEstado = true;

                    IdPersonaCalendarioLaboral = objBL_PersonaCalendario.Inserta(objE_PersonaCalendario);

                    Mensaje = "- Se registro la Fecha a recuperar.";
                    Observacion = "Recupera el Día -"+ deFecha.Text;
                }


                AusenciaBL objBL_Ausencia = new AusenciaBL();
                AusenciaBE objAusencia = new AusenciaBE();
                objAusencia.IdAusencia = _IdAusencia;
                objAusencia.IdPersona = IdPersona;
                objAusencia.IdAutorizado = Parametros.intPersonaId;
                objAusencia.Periodo = Periodo;
                objAusencia.FechaDesde = Convert.ToDateTime(Dia + "/"+ Mes+ "/"+Periodo);
                objAusencia.FechaHasta = Convert.ToDateTime(Dia + "/" + Mes + "/" + Periodo);
                objAusencia.Dias = 1;
                objAusencia.IdMotivoAusencia = Convert.ToInt32(cboMotivo.EditValue);
                objAusencia.IdPersonaCalendarioLaboral = IdPersonaCalendarioLaboral;
                objAusencia.Observacion = txtObservacion.Text + " "+ Observacion;
                objAusencia.Usuario = Parametros.strUsuarioLogin;
                objAusencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objAusencia.IdEmpresa = Parametros.intEmpresaId;
                objAusencia.FlagEstado = true;

                objBL_Ausencia.Inserta(objAusencia);

                XtraMessageBox.Show("- Se registró el motivo de la ausencia\n" + Mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

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

        private void cboMotivo_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMotivo.EditValue) == 8)
            {
                deFecha.Visible = true;
                lblFechaRecuperacion.Visible = true;
                this.Size = new Size(610, 214);
                //chkValidarDescanso.Visible = true;
                //chkValidarMarcacion.Visible = true;

                //Día de descanso
                PersonaBE objE_Persona = new PersonaBE();
                objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);
                if (objE_Persona.Descanso.Length > 0)
                {
                    lblMensaje.Text = objE_Persona.Descanso;
                    lblMensaje.Visible = true;
                    lblMensajeTitulo.Visible = true;
                }
                else
                {
                    lblMensaje.Text = "";
                    lblMensaje.Visible = false;
                    lblMensajeTitulo.Visible = false;
                }

            }
            else
            {
                deFecha.Visible = false;
                lblFechaRecuperacion.Visible = false;
                this.Size = new Size(533, 214);
                //chkValidarDescanso.Visible = false;
                //chkValidarMarcacion.Visible = false;
            }
        }

        #endregion

        #region "Metodos"

        #endregion
    }
}