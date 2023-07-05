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
    public partial class frmRegAusenciaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<AusenciaBE> lstAusencia;

        int _IdAusencia = 0;

        public int IdAusencia
        {
            get { return _IdAusencia; }
            set { _IdAusencia = value; }
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


        public frmRegAusenciaEdit()
        {
            InitializeComponent();
        }

        private void frmRegAusenciaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboMotivoAusencia, new MotivoAusenciaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMotivoAusencia", "IdMotivoAusencia", true);
            
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Ausencia - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Ausencia - Modificar";

                AusenciaBE objE_Ausencia = new AusenciaBE();

                objE_Ausencia = new AusenciaBL().Selecciona(IdAusencia);

                cboEmpresa.EditValue = objE_Ausencia.IdEmpresa;
                IdPersona = objE_Ausencia.IdPersona;
                txtPersona.EditValue = objE_Ausencia.ApeNom;
                deFechaDesde.EditValue = objE_Ausencia.FechaDesde;
                deFechaHasta.EditValue = objE_Ausencia.FechaHasta;
                cboMotivoAusencia.EditValue = objE_Ausencia.IdMotivoAusencia;
                IdAutorizado = objE_Ausencia.IdAutorizado;
                txtAutorizado.EditValue = objE_Ausencia.Autorizado;
                txtObservacion.EditValue = objE_Ausencia.Observacion;

            }
            else if (pOperacion == Operacion.Consultar)
            {
                this.Text = "Ausencia - Consultar";

                AusenciaBE objE_Ausencia = new AusenciaBE();

                objE_Ausencia = new AusenciaBL().Selecciona(IdAusencia);

                cboEmpresa.EditValue = objE_Ausencia.IdEmpresa;
                IdPersona = objE_Ausencia.IdPersona;
                txtPersona.EditValue = objE_Ausencia.ApeNom;
                deFechaDesde.EditValue = objE_Ausencia.FechaDesde;
                deFechaHasta.EditValue = objE_Ausencia.FechaHasta;
                cboMotivoAusencia.EditValue = objE_Ausencia.IdMotivoAusencia;
                IdAutorizado = objE_Ausencia.IdAutorizado;
                txtAutorizado.EditValue = objE_Ausencia.Autorizado;
                txtObservacion.EditValue = objE_Ausencia.Observacion;

                cboEmpresa.Properties.ReadOnly = true;
                txtPersona.Properties.ReadOnly = true;
                deFechaDesde.Properties.ReadOnly = true;
                deFechaHasta.Properties.ReadOnly = true;
                txtDias.Properties.ReadOnly = true;
                cboMotivoAusencia.Properties.ReadOnly = true;
                txtAutorizado.Properties.ReadOnly = true;
                txtObservacion.Properties.ReadOnly = true;
                cboEmpresa.Properties.ReadOnly = true;
                btnBuscar.Enabled = false;
                btnBuscarAutorizado.Enabled = false;
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
                    AusenciaBL objBL_Ausencia = new AusenciaBL();
                    AusenciaBE objE_Ausencia = new AusenciaBE();

                    objE_Ausencia.IdAusencia = IdAusencia;
                    objE_Ausencia.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objE_Ausencia.IdPersona = IdPersona;
                    objE_Ausencia.Periodo = Parametros.intPeriodo;
                    objE_Ausencia.FechaDesde = Convert.ToDateTime(deFechaDesde.EditValue);
                    objE_Ausencia.FechaHasta = Convert.ToDateTime(deFechaHasta.EditValue);
                    objE_Ausencia.Dias = Convert.ToInt32(txtDias.EditValue); 
                    objE_Ausencia.IdMotivoAusencia = Convert.ToInt32(cboMotivoAusencia.EditValue);
                    objE_Ausencia.IdAutorizado = IdAutorizado;
                    objE_Ausencia.Observacion = txtObservacion.Text;
                    objE_Ausencia.FlagEstado = true;
                    objE_Ausencia.Usuario = Parametros.strUsuarioLogin;
                    objE_Ausencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Ausencia.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Ausencia.Inserta(objE_Ausencia);
                    else
                        objBL_Ausencia.Actualiza(objE_Ausencia);

                    this.DialogResult = DialogResult.OK;//add 0303

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
                strMensaje = strMensaje + "- Seleccinar un personal.\n";
                flag = true;
            }

            if(Convert.ToInt32(cboMotivoAusencia.EditValue) ==0)
            {
                strMensaje = strMensaje + "- Seleccinar un motivo.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstAusencia.Where(oB => oB.IdPersona == IdPersona && oB.FechaDesde == deFechaDesde.DateTime).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Ausencia ya existe.\n";
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

        private void cboMotivoAusencia_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                if (Convert.ToInt32(cboMotivoAusencia.EditValue) == 8)
                {
                    XtraMessageBox.Show("Esta opción está disponible desde el menú [Tareo Mensual de Personal]", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cboMotivoAusencia.EditValue = 0;
                    return;
                }
            }

            //if (Convert.ToInt32(cboMotivoAusencia.EditValue) == 8)
            //{
            //    //Día de descanso
            //    PersonaBE objE_Persona = new PersonaBE();
            //    objE_Persona = new PersonaBL().Selecciona(Parametros.intEmpresaId, IdPersona);
            //    if (objE_Persona.Descanso.Length > 0)
            //    {
            //        lblMensaje.Text = objE_Persona.Descanso;
            //        lblMensaje.Visible = true;
            //        lblMensajeTitulo.Visible = true;
            //        lblFechaRecuperacion.Visible = true;
            //        deFecha.Properties.ReadOnly = false;

                //    }
                //    else
                //    {
                //        lblMensaje.Text = "";
                //        lblMensaje.Visible = false;
                //        lblMensajeTitulo.Visible = false;
                //        lblFechaRecuperacion.Visible = false;
                //        deFecha.Properties.ReadOnly = true;
                //    }
                //}
        }
    }
}