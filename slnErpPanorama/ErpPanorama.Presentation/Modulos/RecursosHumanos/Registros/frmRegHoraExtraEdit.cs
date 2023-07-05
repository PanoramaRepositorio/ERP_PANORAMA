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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegHoraExtraEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<HoraExtraBE> lstHoraExtra;

        int _IdHoraExtra = 0;

        public int IdHoraExtra
        {
            get { return _IdHoraExtra; }
            set { _IdHoraExtra = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        private int IdPersona = 0;
        private int IdAutorizado = 0;
        private bool FlagCargado = false;
        public bool bFlagBloqueado = false;
        public bool bFlagWith = false;
        public bool bPerAutorizadas = false;
        #endregion

        #region "Eventos"

        public frmRegHoraExtraEdit()
        {
            InitializeComponent();
        }

        private void frmRegHoraExtraEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            DateTime FechaActual = DateTime.Now;
            deFechaDesde.EditValue = FechaActual; 
            deFechaHasta.EditValue = FechaActual;

            HoraExtraBE objE_HoraExtra = new HoraExtraBE();

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "HoraExtra - Nuevo";
                IdAutorizado = Parametros.intPersonaId;
                txtAutorizado.Text = Parametros.strUsuarioNombres;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "HoraExtra - Modificar";


                objE_HoraExtra = new HoraExtraBL().Selecciona(IdHoraExtra);

                cboEmpresa.EditValue = objE_HoraExtra.IdEmpresa;
                IdPersona = objE_HoraExtra.IdPersona;
                txtPersona.EditValue = objE_HoraExtra.ApeNom;
                deFechaDesde.EditValue = objE_HoraExtra.FechaDesde;
                deFechaHasta.EditValue = objE_HoraExtra.FechaHasta;
                IdAutorizado = objE_HoraExtra.IdAutorizado;
                txtAutorizado.EditValue = objE_HoraExtra.Autorizado;
                txtSueldoHora.EditValue = objE_HoraExtra.SueldoHora;
                txtSueldoHoraNocturna.EditValue = objE_HoraExtra.SueldoHoraNocturna;
                txtImporte.EditValue = objE_HoraExtra.Importe;
                chkCena.Checked = objE_HoraExtra.FlagCena;
                chkDesayuno.Checked = objE_HoraExtra.FlagDesayuno;
                chkCompensacion.Checked = objE_HoraExtra.FlagCompensacion;
                deFechaCompensacion.EditValue = objE_HoraExtra.FechaCompensacion;
                txtMotivo.EditValue = objE_HoraExtra.Motivo;
                deIngreso.EditValue = objE_HoraExtra.Ingreso;
                deSalida.EditValue = objE_HoraExtra.Salida;
                txtObservacion.EditValue = objE_HoraExtra.Observacion;
                FlagCargado = true;
            }
            
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH || Parametros.intPerfilId == Parametros.intPerJefeVisual
                || Parametros.intPerfilId == Parametros.intPerAdministradorTienda)
            {
                gctMarcacion.Enabled = true;
                txtSueldoHora.Properties.ReadOnly = false;
                txtSueldoHoraNocturna.Properties.ReadOnly = false;
                txtImporte.Properties.ReadOnly = false;
            }

            if (bFlagBloqueado)
            {
                txtImporte.Properties.ReadOnly = true;
                txtSueldoHora.Properties.ReadOnly = true;
                txtSueldoHoraNocturna.Properties.ReadOnly = true;
                chkCena.Properties.ReadOnly = true;
                chkCompensacion.Properties.ReadOnly = true;
                deFechaCompensacion.Properties.ReadOnly = true;
                chkDesayuno.Properties.ReadOnly = true;
                deFechaDesde.Properties.ReadOnly = true;
                deFechaHasta.Properties.ReadOnly = true;
                btnBuscar.Enabled = false;
                btnGrabar.Enabled = false;
            }

            btnCalcular.Visible = false;
            this.Validar_Permisos();
            if (bPerAutorizadas)
            {
                btnCalcular.Visible = true;
                if (objE_HoraExtra.FlagAprobado)
                {
                    this.CalcularTotalPagar();
                }
            }

            cboEmpresa.Select();
            this.CalcularTotalHorasMinutos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    cboEmpresa.EditValue = frm._Be.IdEmpresa;
                    IdPersona = frm._Be.IdPersona;
                    txtPersona.Text = frm._Be.ApeNom;

                    PersonaBE objE_Persona = new PersonaBE();
                    objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);

                    //txtSueldoHora.EditValue = Math.Round(Math.Round((objE_Persona.Sueldo / Convert.ToDecimal("30")), 2) / Convert.ToDecimal("8"), 2);
                    //txtSueldoHoraNocturna.EditValue = Math.Round(Math.Round((objE_Persona.Sueldo / Convert.ToDecimal("30")), 2) / Convert.ToDecimal("8"), 2) * Convert.ToDecimal("1.35");

                    List<ContratoBE> lst_Contrato = new List<ContratoBE>();
                    lst_Contrato = new ContratoBL().ListaTodosActivo(Parametros.intPeriodo, objE_Persona.Dni);
                    if (lst_Contrato.Count > 0)
                    {
                        txtSueldoHora.EditValue = Math.Round((Math.Round(((lst_Contrato[0].Sueldo + lst_Contrato[0].BonSueldo) / Convert.ToDecimal("30")),2) / Convert.ToDecimal("8")),2);
                        //txtSueldoHora.EditValue = Math.Round((Math.Round(((lst_Contrato[0].Sueldo + lst_Contrato[0].BonSueldo) / Convert.ToDecimal("30")),2) / Convert.ToDecimal("8")),2) * Convert.ToDecimal("1.35");
                        //if (Convert.ToDecimal(txtSueldoHora.EditValue) > Convert.ToDecimal("7.5"))
                        //{
                        //    txtSueldoHora.EditValue = Convert.ToDecimal("7.5");
                        //}
                        //if (Convert.ToDecimal(txtSueldoHora.EditValue) < Convert.ToDecimal("5.5"))
                        //{
                        //    txtSueldoHora.EditValue = Convert.ToDecimal("5.5");
                        //}
                    }
                    else
                    {
                        txtSueldoHora.EditValue = Convert.ToDecimal("0.00");
                    }

                    this.CalcularTotalPagar();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarAutorizado_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    cboEmpresa.EditValue = frm._Be.IdEmpresa;
                    IdAutorizado = frm._Be.IdPersona;
                    txtAutorizado.Text = frm._Be.ApeNom;
                }
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
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {

                    if (pOperacion == Operacion.Nuevo)
                    {
                        HoraExtraBE objE_HoraExtraConsulta = new HoraExtraBE();
                        objE_HoraExtraConsulta = new HoraExtraBL().ValidaExisteRegistro(IdPersona, Convert.ToDateTime(deFechaDesde.Text), Convert.ToDateTime(deFechaHasta.Text));

                        if (objE_HoraExtraConsulta != null)
                        {
                            XtraMessageBox.Show("Ya existe un registro con el trabajador y la fecha seleccionada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }


                    HoraExtraBL objBL_HoraExtra = new HoraExtraBL();
                    HoraExtraBE objE_HoraExtra = new HoraExtraBE();

                    objE_HoraExtra.IdHoraExtra = IdHoraExtra;
                    objE_HoraExtra.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objE_HoraExtra.IdPersona = IdPersona;
                    objE_HoraExtra.Periodo = Parametros.intPeriodo;   
                    objE_HoraExtra.FechaDesde = Convert.ToDateTime(deFechaDesde.Text);  // Convert.ToDateTime(deFechaDesde.EditValue);
                    objE_HoraExtra.FechaHasta = Convert.ToDateTime(deFechaHasta.Text);
                    objE_HoraExtra.IdAutorizado = IdAutorizado;
                    objE_HoraExtra.SueldoHora = Convert.ToDecimal(txtSueldoHora.EditValue);
                    objE_HoraExtra.SueldoHoraNocturna = Convert.ToDecimal(txtSueldoHoraNocturna.EditValue);
                    objE_HoraExtra.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    //objE_HoraExtra.IdMovimientoCaja = null;
                    objE_HoraExtra.FlagCena = chkCena.Checked;
                    objE_HoraExtra.FlagDesayuno = chkDesayuno.Checked;
                    objE_HoraExtra.FlagCompensacion = chkCompensacion.Checked;
                    objE_HoraExtra.FechaCompensacion = deFechaCompensacion.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deFechaCompensacion.Text);
                    objE_HoraExtra.Ingreso = deIngreso.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deIngreso.Text);
                    objE_HoraExtra.Salida = deSalida.EditValue == null ? (DateTime?)null : Convert.ToDateTime(deSalida.Text);
                    objE_HoraExtra.Motivo = txtMotivo.Text;
                    objE_HoraExtra.Observacion = txtObservacion.Text;
                    objE_HoraExtra.FlagEstado = true;
                    objE_HoraExtra.Usuario = Parametros.strUsuarioLogin;
                    objE_HoraExtra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_HoraExtra.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_HoraExtra.Inserta(objE_HoraExtra);
                    else
                        objBL_HoraExtra.Actualiza(objE_HoraExtra);

                    this.DialogResult = DialogResult.OK;
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

        private void chkCompensacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompensacion.Checked)
            {
                txtSueldoHora.EditValue = 0;
                txtSueldoHoraNocturna.EditValue = 0;
                txtImporte.EditValue = 0;
            }
            this.CalcularTotalPagar();
        }

        private void chkCena_CheckedChanged(object sender, EventArgs e)
        {
            if (FlagCargado)
            {
                txtImporte.EditValue = 0;
            }
        }

        private void chkDesayuno_CheckedChanged(object sender, EventArgs e)
        {
            if (FlagCargado)
            {
                txtImporte.EditValue = 0;
            }
        }

        private void deFechaDesde_EditValueChanged(object sender, EventArgs e)
        {
            this.CalcularTotalPagar();
        }
        private void deFechaHasta_EditValueChanged(object sender, EventArgs e)
        {
            this.CalcularTotalPagar();
        }
        private void btnVerMarcacion_Click(object sender, EventArgs e)
        {
            List<CheckinoutBE> lstMarcacion = null;
            PersonaBE objE_Persona = new PersonaBE();
            objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);

            if (deFechaDesde.Text != "")
            {
                lstMarcacion = new CheckinoutBL().ListaMarcacion(objE_Persona.Dni,0, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()));
                if (lstMarcacion.Count > 0)
                {
                    txtIngresoNormal.EditValue = lstMarcacion[0].Ingreso;
                    txtSalidaRefrigerio.EditValue = lstMarcacion[0].SalidaRefrigerio;
                    txtIngresoRefrigerio.EditValue = lstMarcacion[0].IngresoRefrigerio;
                    txtSalidaNormal.EditValue = lstMarcacion[0].Salida;
                }
            }
            if (deFechaHasta.Text != "" && deFechaDesde.DateTime.Day != deFechaHasta.DateTime.Day)
            {
                lstMarcacion = new CheckinoutBL().ListaMarcacion(objE_Persona.Dni,0, Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
                if (lstMarcacion.Count > 0)
                {
                    txtIngresoNormal2.EditValue = lstMarcacion[0].Ingreso;
                    txtSalidaRefrigerio2.EditValue = lstMarcacion[0].SalidaRefrigerio;
                    txtIngresoRefrigerio2.EditValue = lstMarcacion[0].IngresoRefrigerio;
                    txtSalidaNormal2.EditValue = lstMarcacion[0].Salida;
                }
            }

            //Horario
            //List<ContratoBE> lstContrato = new List<ContratoBE>();
            //lstContrato = new ContratoBL().ListaTodosActivo(Parametros.intPeriodo, objE_Persona.Dni);
            //if (lstContrato.Count > 0)
            //{
            //    txtHorarioInicio.Text = lstContrato[0].HorarioInicio;
            //    txtHorarioFin.Text = lstContrato[0].HorarioFin;
            //}

            List<HorarioPersonaBE> lstHorarioPersona = null;
            lstHorarioPersona = new HorarioPersonaBL().ListaFecha(Parametros.intEmpresaId, IdPersona, Convert.ToDateTime(deFechaDesde.EditValue), Convert.ToDateTime(deFechaHasta.EditValue));
            if (lstHorarioPersona.Count > 0)
            {
                txtHorarioInicio.Text = lstHorarioPersona[0].FechaIngreso.TimeOfDay.ToString();
                txtHorarioFin.Text = lstHorarioPersona[0].FechaSalida.TimeOfDay.ToString();
            }
            else
            {
                txtHorarioInicio.Text = "Sin Horario";
                txtHorarioFin.Text = "Sin Horario";
            }

        }

        private void Validar_Permisos()
        {
            bPerAutorizadas = false;
            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "rtapia" ||
                  Parametros.strUsuarioLogin == "dhuaman" || Parametros.intPerfilId == Parametros.intPerAdministrador ||
                  Parametros.intPerfilId == Parametros.intPerJefeRRHH ||
                  Parametros.intPerfilId == Parametros.intPerAsistenteRRHH)
            {
                bPerAutorizadas = true;
            }
        }
        private void CalcularTotalHorasMinutos()
        {
            try
            {
                lblHoras.Text = "0";
                lblMinutos.Text = "0";

                DateTime dFechaDesde = Convert.ToDateTime(deFechaDesde.Text);
                DateTime dFechaHasta = Convert.ToDateTime(deFechaHasta.Text);
                TimeSpan Diff_dates = dFechaHasta.Subtract(dFechaDesde);
                int Horas = Diff_dates.Hours;
                int Minutos = Convert.ToInt32(Diff_dates.TotalMinutes);

                lblHoras.Text = Horas.ToString();
                lblMinutos.Text = Minutos.ToString();
            }
            catch (Exception)
            {
            }
        }
        
        private void CalcularTotalPagar()
        {
            try
            {
                this.CalcularTotalHorasMinutos();
                if (bPerAutorizadas == false) return;
                int intSizeWith = 345;
                if (IdPersona == 0) return;
                if (chkCompensacion.Checked) 
                {
                    if (bFlagWith)
                    {
                        this.Size = new Size(this.Width - intSizeWith, this.Height);
                        this.StartPosition = FormStartPosition.CenterScreen;
                        this.gcDetallePersonal.Visible = false;
                        this.gcG1DetalleHoraExtra.Visible = false;
                        this.gcG2DetalleHoraExtra.Visible = false;
                        this.gcG3Total.Visible = false;
                    }
                    bFlagWith = false;
                    return;
                } 
                PersonaBE objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);
                if (objE_Persona != null)
                {
                    decimal Sueldo = objE_Persona.Sueldo;
                    DateTime dFechaDesde = Convert.ToDateTime(deFechaDesde.Text);
                    DateTime dFechaHasta = Convert.ToDateTime(deFechaHasta.Text);
                    TimeSpan Diff_dates = dFechaHasta.Subtract(dFechaDesde);
                    int Horas = Diff_dates.Hours;
                    int Minutos = Convert.ToInt32(Diff_dates.TotalMinutes);
                    //XtraMessageBox.Show(Diff_dates.TotalHours.ToString() + " --- ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    int Ptro_PorDosHorasExtras = Convert.ToInt32(new ParametroBL().Selecciona("PorcentajeDosHorasExtras").Numero);
                    int Ptro_PorMasDeDosHorasExtras = Convert.ToInt32(new ParametroBL().Selecciona("PorcentajeMasDeDosHorasExtras").Numero);
                    
                    if (Sueldo.ToString() == "0.00")
                    {
                        XtraMessageBox.Show("No se ha registrado la remuneración para el Personal.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    
                    if (Minutos < 30)
                    {
                        XtraMessageBox.Show("Las horas extras deben ser mayores a 30 min.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Horas = 0;
                        Minutos = 0;
                    }

                    // Aumentar Asignación Familiar
                    lblAsigFam.Visible = false;
                    if (objE_Persona.FlagAsignacion)
                    {
                        ParametroBE Ptro_SueldoMinimo = new ParametroBL().Selecciona("SueldoMinimo");
                        decimal dAsigFam = (Ptro_SueldoMinimo.Numero * Parametros.intPorcentajeAsigFamiliar);
                        Sueldo += dAsigFam;
                        lblAsigFam.Visible = true;
                    }
                    // Aumentar el Ancho del formulario
                    if (!bFlagWith)
                    {
                        this.Size = new Size(this.Width + intSizeWith, this.Height);
                        this.StartPosition = FormStartPosition.CenterScreen;
                        this.gcDetallePersonal.Visible = true;
                        this.gcG1DetalleHoraExtra.Visible = true;
                        this.gcG2DetalleHoraExtra.Visible = true;
                        this.gcG3Total.Visible = true;
                    }
                    bFlagWith = true;

                    // Cuanto Gana Por Hora
                    decimal SueldoHora = Math.Round((Math.Round(((Sueldo) / Convert.ToDecimal("30")), 2) / Convert.ToDecimal("8")), 2);
                    decimal SueldoMin = Math.Round(((Sueldo) / Convert.ToDecimal("30")), 2) / Convert.ToDecimal("8") / Convert.ToDecimal("60");
                    //SET DATOS PERSONAL
                    this.txtExtSueldo.Text = Sueldo.ToString();
                    this.txtExtSueldoxHora.Text = SueldoHora.ToString();
                    this.txtExtSueldoxMin.Text = Math.Round(SueldoMin, 2).ToString();
                    //XtraMessageBox.Show(GanaHoraExtra.ToString() + " --- " + GanaMinExtra.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    int G1Horas = Horas;
                    int G1Minutos = Minutos;

                    int G2Horas = 0;
                    int G2Minutos = 0;

                    if (Horas >= 3)
                    {
                        G1Horas = 2;
                        G1Minutos = 120;

                        G2Horas = Horas - G1Horas;
                        G2Minutos = Minutos - G1Minutos;
                    }

                    //SET DATOS PERSONAL 25%
                    int intExtra = Ptro_PorDosHorasExtras;
                    decimal G1GanaHora = Math.Round((SueldoHora * G1Horas), 2);
                    decimal G1GanaMin = Math.Round((SueldoMin * G1Minutos), 2);
                    HoraExtraTotalBE G1HE = new HoraExtraBL().CalcularHora(intExtra, G1GanaHora, G1GanaMin);
                    this.txtG1ExtTotalHora.Text = G1Horas.ToString();
                    this.txtG1ExtTotalMin.Text = G1Minutos.ToString();
                    this.lblG1HorasExtras.Text = G1HE.PorHorasExtras;
                    this.txtG1ExtAddHora.Text = G1HE.ADDHora.ToString();
                    this.txtG1ExtAddMin.Text = G1HE.ADDMin.ToString();
                    this.txtG1ExtTotalPagarHora.Text = G1HE.GanaHoraExtra.ToString();
                    this.txtG1ExtTotalPagarMin.Text = G1HE.GanaMinExtra.ToString();

                    //SET DATOS PERSONAL 35%
                    intExtra = Ptro_PorMasDeDosHorasExtras;
                    decimal G2GanaHora = Math.Round((SueldoHora * G2Horas), 2);
                    decimal G2GanaMin = Math.Round((SueldoMin * G2Minutos), 2);
                    HoraExtraTotalBE G2HE = new HoraExtraBL().CalcularHora(intExtra, G2GanaHora, G2GanaMin);
                    this.txtG2ExtTotalHora.Text = G2Horas.ToString();
                    this.txtG2ExtTotalMin.Text = G2Minutos.ToString();
                    this.lblG2HorasExtras.Text = G2HE.PorHorasExtras;
                    this.txtG2ExtAddHora.Text = G2HE.ADDHora.ToString();
                    this.txtG2ExtAddMin.Text = G2HE.ADDMin.ToString();
                    this.txtG2ExtTotalPagarHora.Text = G2HE.GanaHoraExtra.ToString();
                    this.txtG2ExtTotalPagarMin.Text = G2HE.GanaMinExtra.ToString();

                    //SUMA
                    txtSueldoHora.Text = SueldoHora.ToString();
                    txtG3ExtTotalPagar.Text = Math.Round(G1HE.GanaMinExtra + G2HE.GanaMinExtra, 2).ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            this.CalcularTotalPagar();
        }
        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdPersona == 0)
            {
                strMensaje = strMensaje + "-     a un personal.\n";
                flag = true;
            }

            if (deFechaDesde.Text == "" || deFechaHasta.Text == "")
            {
                strMensaje = strMensaje + "- La fecha no debe estar vacía.\n";
                flag = true;
            }

            if (chkCompensacion.Checked && deFechaCompensacion.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar fecha de compensación.\n";
                flag = true;
            }

            if (Convert.ToDateTime(deFechaHasta.EditValue) < Convert.ToDateTime(deFechaDesde.EditValue))
            {
                strMensaje = strMensaje + "- La fecha de término no puede ser menor a la fecha inicial.\n";
                flag = true;
            }

            if (Convert.ToDateTime(deFechaHasta.EditValue) == Convert.ToDateTime(deFechaDesde.EditValue))
            {
                strMensaje = strMensaje + "- La fecha de término no puede ser igual a la fecha inicial.\n";
                flag = true;
            }

            //List<HoraExtraBE> lstHoraExtra = null;
            //lstHoraExtra = new HoraExtraBL().ListaValida(IdHoraExtra, IdPersona, Convert.ToDateTime(deFechaDesde.EditValue), Convert.ToDateTime(deFechaHasta.EditValue));

            //if (lstHoraExtra.Count > 0)
            //{
            //    strMensaje = strMensaje + "- La hora extra ya existe y/o el rango de horas coincide con otro registro.\n";
            //    flag = true;
            //}

            //Validar con Horario
            List<HorarioPersonaBE> lstHorarioPersona = null;
            lstHorarioPersona = new HorarioPersonaBL().ListaFecha(Parametros.intEmpresaId, IdPersona, Convert.ToDateTime(deFechaDesde.EditValue), Convert.ToDateTime(deFechaHasta.EditValue));
            if (lstHorarioPersona.Count > 0)
            {
                //if(Convert.ToDateTime(deFechaDesde.EditValue) < lstHorarioPersona[0].FechaSalida)
                //{
                //    strMensaje = strMensaje + "- La hora extra no puede iniciar antes de la hora de salida(Malla de Horario).\n";
                //    flag = true;
                //}
            }
            else
            {
                strMensaje = strMensaje + "- "+ txtPersona.Text +  ", no tiene un horario definido, se asignará el 100% para el cálculo.\n";
            }


            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }




        #endregion

       
    }
}