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
    public partial class frmRegHoraExtraLiteEdit : DevExpress.XtraEditors.XtraForm
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

        #endregion

        #region "Eventos"
        public frmRegHoraExtraLiteEdit()
        {
            InitializeComponent();
        }

        private void frmRegHoraExtraLiteEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "HoraExtra - Nuevo";
                IdAutorizado = Parametros.intPersonaId;
                txtAutorizado.Text = Parametros.strUsuarioNombres;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "HoraExtra - Modificar";

                HoraExtraBE objE_HoraExtra = new HoraExtraBE();

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

            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeRRHH)
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

            cboEmpresa.Select();
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

                    List<ContratoBE> lst_Contrato = new List<ContratoBE>();
                    lst_Contrato = new ContratoBL().ListaTodosActivo(Parametros.intPeriodo, objE_Persona.Dni);
                    if (lst_Contrato.Count > 0)
                    {
                        txtSueldoHora.EditValue = (((lst_Contrato[0].Sueldo + lst_Contrato[0].BonSueldo) / Convert.ToDecimal("30")) / Convert.ToDecimal("8")) * Convert.ToDecimal("1.35");
                        if (Convert.ToDecimal(txtSueldoHora.EditValue) > Convert.ToDecimal("7.5"))
                        {
                            txtSueldoHora.EditValue = Convert.ToDecimal("7.5");
                        }
                        if (Convert.ToDecimal(txtSueldoHora.EditValue) < Convert.ToDecimal("5.5"))
                        {
                            txtSueldoHora.EditValue = Convert.ToDecimal("5.5");
                        }
                    }
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
                    HoraExtraBL objBL_HoraExtra = new HoraExtraBL();
                    HoraExtraBE objE_HoraExtra = new HoraExtraBE();

                    objE_HoraExtra.IdHoraExtra = IdHoraExtra;
                    objE_HoraExtra.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objE_HoraExtra.IdPersona = IdPersona;
                    objE_HoraExtra.Periodo = Parametros.intPeriodo;
                    objE_HoraExtra.FechaDesde = Convert.ToDateTime(deFechaDesde.Text);
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
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdPersona == 0)
            {
                strMensaje = strMensaje + "- Seleccione a un personal.\n";
                flag = true;
            }

            if (deFechaDesde.Text == ""|| deFechaHasta.Text=="")
            {
                strMensaje = strMensaje + "- La fecha no debe estar vacía.\n";
                flag = true;
            }

            if(chkCompensacion.Checked && deFechaCompensacion.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar fecha de compensación.\n";
                flag = true;
            }

            if (Convert.ToDateTime(deFechaHasta.EditValue) < Convert.ToDateTime(deFechaDesde.EditValue))
            {
                strMensaje = strMensaje + "- La fecha de término no puede ser menor a la fecha inicial.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                List<HoraExtraBE> lstHoraExtra = new List<HoraExtraBE>();
                lstHoraExtra = new HoraExtraBL().ListaPersonaFecha(IdPersona, Convert.ToDateTime(deFechaDesde.EditValue), Convert.ToDateTime(deFechaHasta.EditValue));
                if (lstHoraExtra.Count > 0)
                {
                    strMensaje = strMensaje + "- La hora extra ya existe.\n";
                    flag = true;
                }

                //var Buscar = lstHoraExtra.Where(oB => oB.IdPersona == IdPersona && oB.FechaDesde == deFechaDesde.DateTime).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- La hora extra ya existe.\n";
                //    flag = true;
                //}
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