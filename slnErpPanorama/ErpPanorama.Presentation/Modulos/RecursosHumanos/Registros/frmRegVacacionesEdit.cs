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
    public partial class frmRegVacacionesEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<VacacionesBE> lstVacaciones;

        int _IdVacaciones = 0;

        public int IdVacaciones
        {
            get { return _IdVacaciones; }
            set { _IdVacaciones = value; }
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

        #endregion

        #region "Eventos"

        public frmRegVacacionesEdit()
        {
            InitializeComponent();
        }

        private void frmRegVacacionesEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionVacaciones), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intSITVacacionesPendiente;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;

            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Vacaciones - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Vacaciones - Modificar";

                VacacionesBE objE_Vacaciones = new VacacionesBE();

                objE_Vacaciones = new VacacionesBL().Selecciona(IdVacaciones);

                cboEmpresa.EditValue = objE_Vacaciones.IdEmpresa;
                IdPersona = objE_Vacaciones.IdPersona;
                txtPersona.EditValue = objE_Vacaciones.ApeNom;
                deFechaDesde.EditValue = objE_Vacaciones.FechaDesde;
                deFechaHasta.EditValue = objE_Vacaciones.FechaHasta;
                deFechaRetorno.EditValue = objE_Vacaciones.FechaHasta.AddDays(1);
                txtDias.EditValue = objE_Vacaciones.Dias;
                cboMoneda.EditValue = objE_Vacaciones.IdMoneda;
                txtImporte.EditValue = objE_Vacaciones.Importe;
                deFechaInicio.EditValue = objE_Vacaciones.FechaInicio;
                deFechaFin.EditValue = objE_Vacaciones.FechaFin;
                cboSituacion.EditValue = objE_Vacaciones.IdSituacion;
                chkVacacionesGozadas.Checked = objE_Vacaciones.FlagGozo;
                IdAutorizado = objE_Vacaciones.IdAutorizado;
                txtAutorizado.EditValue = objE_Vacaciones.Autorizado;
                txtObservacion.EditValue = objE_Vacaciones.Observacion;
                lblFechaIngreso.Text = objE_Vacaciones.FechaIngreso.ToString("dd-MM-yyyy");
                chkAdelantoVacaciones.Checked = objE_Vacaciones.FlagAdelantadas;
            }
            this.MostrarVacacionesAdelantadas();
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

                    #region "Vacaciones Adelantadas"
                    PersonaBE objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);
                    string FechaHoy = DateTime.Now.ToString("dd-MM-yyyy");
                    string FechaIngreso = (objE_Persona.FechaIngreso).ToString("dd-MM-yyyy");

                    DateTime dFechaHoy = Convert.ToDateTime(FechaHoy);
                    DateTime dFechaIngresoAdd = Convert.ToDateTime(FechaIngreso).AddYears(1);
                    lblFechaIngreso.Text = FechaIngreso;

                    chkAdelantoVacaciones.Checked = false;
                    if (dFechaIngresoAdd > dFechaHoy)
                    {
                        chkAdelantoVacaciones.Checked = true;
                    }
                    #endregion

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
                    VacacionesBL objBL_Vacaciones = new VacacionesBL();
                    VacacionesBE objE_Vacaciones = new VacacionesBE();

                    objE_Vacaciones.IdVacaciones = IdVacaciones;
                    objE_Vacaciones.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objE_Vacaciones.IdPersona = IdPersona;
                    objE_Vacaciones.Periodo = Parametros.intPeriodo;
                    objE_Vacaciones.FechaDesde = Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString());
                    objE_Vacaciones.FechaHasta = Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()); 
                    objE_Vacaciones.Dias = Convert.ToInt32(txtDias.EditValue);
                    objE_Vacaciones.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objE_Vacaciones.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objE_Vacaciones.IdAutorizado = IdAutorizado;
                    objE_Vacaciones.FechaInicio = Convert.ToDateTime(deFechaInicio.DateTime.ToShortDateString());
                    objE_Vacaciones.FechaFin = Convert.ToDateTime(deFechaFin.DateTime.ToShortDateString());  
                    objE_Vacaciones.IdSituacion = Convert.ToInt32(cboSituacion.EditValue);
                    objE_Vacaciones.FlagGozo = chkVacacionesGozadas.Checked;
                    objE_Vacaciones.FlagAdelantadas = chkAdelantoVacaciones.Checked;
                    objE_Vacaciones.Observacion = txtObservacion.Text;
                    objE_Vacaciones.FlagEstado = true;
                    objE_Vacaciones.Usuario = Parametros.strUsuarioLogin;
                    objE_Vacaciones.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Vacaciones.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Vacaciones.Inserta(objE_Vacaciones);
                    else
                        objBL_Vacaciones.Actualiza(objE_Vacaciones);

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

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdPersona == 0)
            {
                strMensaje = strMensaje + "- Seleccine a un personal.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstVacaciones.Where(oB => oB.IdPersona == IdPersona && oB.FechaDesde == deFechaDesde.DateTime).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Vacaciones ya existe.\n";
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

        private void MostrarVacacionesAdelantadas( )
        {
            lblFIngreso.Visible = true;
            lblFechaIngreso.Visible = true;
            chkAdelantoVacaciones.Visible = true;
            //chkAdelantoVacaciones.Checked = bVisible;
        }
        #endregion


        private void deFechaHasta_EditValueChanged(object sender, EventArgs e)
        {
            TimeSpan ts = deFechaHasta.DateTime - deFechaDesde.DateTime;
            txtDias.EditValue = ts.Days + 1;
        }

        private void txtDias_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (Convert.ToInt32(txtDias.Text) > 0 || txtDias.Text.Trim() != "")
                {
                    deFechaHasta.EditValue = deFechaDesde.DateTime.AddDays(Convert.ToInt32(txtDias.Text) - 1);//--1
                }
            }

        }


    }
}