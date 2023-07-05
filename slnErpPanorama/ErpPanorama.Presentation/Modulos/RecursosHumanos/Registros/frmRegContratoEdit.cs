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
    public partial class frmRegContratoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public ContratoBE oBE = new ContratoBE();
        //public CContrato objE_ContratoC = new CContrato();
        public List<ContratoBE> lstContrato;

        int _IdContrato = 0;

        public int IdContrato
        {
            get { return _IdContrato; }
            set { _IdContrato = value; }
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
        public int TipoRegistro = 0;

        #endregion

        #region "Eventos"

        public frmRegContratoEdit()
        {
            InitializeComponent();
        }

        private void frmRegContratoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipoContrato, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoContrato), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoTrabajador, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoTrabajador), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboArea, new AreaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescArea", "IdArea", true);
            BSUtils.LoaderLook(cboCargo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCargos), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoRenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoRenta), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboHorario, new HorarioBL().ListaTodosActivo(Parametros.intEmpresaId), "DescHorario", "IdHorario", true);
            BSUtils.LoaderLook(cboClasificacionTrabajador, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionTrabajador), "DescTablaElemento", "IdTablaElemento", true);
           
            deFechaIni.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Contrato Laboral - Nuevo";
                lstContrato = new ContratoBL().ListaPersona(IdPersona);
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Contrato Laboral - Modificar";

                //cboTipoContrato.EditValue = oBE.IdTipoContrato;
                //cboTipoTrabajador.EditValue = oBE.IdTipoTrabajador;
                //cboEmpresa.EditValue = oBE.IdEmpresa;
                //IdPersona = oBE.IdPersona;
                //txtPersona.EditValue = oBE.ApeNom;
                //cboTienda.EditValue = oBE.IdTienda;
                //cboArea.EditValue = oBE.IdArea;
                //cboCargo.EditValue = oBE.IdCargo;
                //cboHorario.EditValue = oBE.IdHorario;
                //deFechaIni.EditValue = oBE.FechaIni;
                //deFechaVen.EditValue = oBE.FechaVen;
                //cboTipoRenta.EditValue = oBE.IdTipoRenta;
                //txtSueldo.EditValue = oBE.Sueldo;
                //txtHoraExtra.EditValue = oBE.HoraExtra;
                //txtSueldoNeto.EditValue = oBE.SueldoNeto;
                //cboClasificacionTrabajador.EditValue = oBE.IdClasificacionTrabajador;
                //txtRutaContrato.Text = oBE.RutaContrato;
                //txtObservacion.EditValue = oBE.Observacion;
                //txtDuracion.EditValue = oBE.Dias;
                //chkHoraExtra.Checked = oBE.FlagHoraExtra;


                ContratoBE objE_Contrato = new ContratoBE();

                objE_Contrato = new ContratoBL().Selecciona(IdContrato);

                cboTipoContrato.EditValue = objE_Contrato.IdTipoContrato;
                cboTipoTrabajador.EditValue = objE_Contrato.IdTipoTrabajador;
                cboEmpresa.EditValue = objE_Contrato.IdEmpresa;
                IdPersona = objE_Contrato.IdPersona;
                txtPersona.EditValue = objE_Contrato.ApeNom;
                cboTienda.EditValue = objE_Contrato.IdTienda;
                cboArea.EditValue = objE_Contrato.IdArea;
                cboCargo.EditValue = objE_Contrato.IdCargo;
                cboHorario.EditValue = objE_Contrato.IdHorario;
                deFechaIni.EditValue = objE_Contrato.FechaIni;
                deFechaVen.EditValue = objE_Contrato.FechaVen;
                cboTipoRenta.EditValue = objE_Contrato.IdTipoRenta;
                txtSueldo.EditValue = objE_Contrato.Sueldo;
                txtHoraExtra.EditValue = objE_Contrato.HoraExtra;
                txtSueldoNeto.EditValue = objE_Contrato.SueldoNeto;
                cboClasificacionTrabajador.EditValue = objE_Contrato.IdClasificacionTrabajador;
                txtRutaContrato.Text = objE_Contrato.RutaContrato;
                txtObservacion.EditValue = objE_Contrato.Observacion;
                txtDuracion.EditValue = objE_Contrato.Dias;
                chkHoraExtra.Checked = objE_Contrato.FlagHoraExtra;

            }

            cboTipoContrato.Select();

        }

        private void btnBuscarRuta_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog1 = new OpenFileDialog();
            Dialog1.Filter = "Word Documents|*.doc|Word Documents |*.docx|All Files (*.*)|*.*";
            if (Dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Cursor = Cursors.AppStarting;
                txtRutaContrato.Text = Dialog1.FileName;
                Cursor = Cursors.Default;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (txtRutaContrato.Text != string.Empty)
            {
                System.Diagnostics.Process.Start(txtRutaContrato.Text);

            }
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
                    cboTienda.EditValue = frm._Be.IdTienda;
                    cboArea.EditValue = frm._Be.IdArea;
                    cboCargo.EditValue = frm._Be.IdCargo;
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
                    if (TipoRegistro == 0)
                    {
                        ContratoBL objBL_Contrato = new ContratoBL();
                        //ContratoBE objE_Contrato = new ContratoBE();

                        oBE.IdContrato = IdContrato;
                        oBE.IdTipoContrato = Convert.ToInt32(cboTipoContrato.EditValue);
                        oBE.IdTipoTrabajador = Convert.ToInt32(cboTipoTrabajador.EditValue);
                        oBE.IdPersona = IdPersona;
                        oBE.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                        oBE.IdArea = Convert.ToInt32(cboArea.EditValue);
                        oBE.IdCargo = Convert.ToInt32(cboCargo.EditValue);
                        oBE.IdHorario = Convert.ToInt32(cboHorario.EditValue);
                        oBE.FechaIni = Convert.ToDateTime(deFechaIni.DateTime.ToShortDateString());
                        oBE.FechaVen = deFechaVen.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaVen.DateTime.ToShortDateString());
                        oBE.IdTipoRenta = Convert.ToInt32(cboTipoRenta.EditValue);
                        oBE.Sueldo = Convert.ToDecimal(txtSueldo.EditValue);
                        oBE.HoraExtra = Convert.ToDecimal(txtHoraExtra.EditValue);
                        oBE.BonSueldo = Convert.ToDecimal(txtBonSueldo.EditValue);
                        oBE.SueldoNeto = Convert.ToDecimal(txtSueldoNeto.EditValue);
                        oBE.IdClasificacionTrabajador = Convert.ToInt32(cboClasificacionTrabajador.EditValue);
                        oBE.RutaContrato = txtRutaContrato.Text;
                        oBE.Observacion = txtObservacion.Text;
                        oBE.FlagHoraExtra = chkHoraExtra.Checked;
                        oBE.Dias = Convert.ToInt32(txtDuracion.EditValue);
                        oBE.FlagEstado = true;
                        oBE.Usuario = Parametros.strUsuarioLogin;
                        oBE.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        oBE.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                        if (pOperacion == Operacion.Nuevo)
                            objBL_Contrato.Inserta(oBE);
                        else
                            objBL_Contrato.Actualiza(oBE);

                        this.Close();
                    }
                    else
                    {
                        //ContratoBE oBE = new ContratoBE();
                        oBE.IdContrato = IdContrato;
                        oBE.IdTipoContrato = Convert.ToInt32(cboTipoContrato.EditValue);
                        oBE.DescTipoContrato = cboTipoContrato.Text;
                        oBE.IdTipoTrabajador = Convert.ToInt32(cboTipoTrabajador.EditValue);
                        oBE.DescTipoTrabajador = cboTipoTrabajador.Text;
                        oBE.IdPersona = IdPersona;
                        oBE.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                        oBE.DescTienda = cboTienda.Text;
                        oBE.IdArea = Convert.ToInt32(cboArea.EditValue);
                        oBE.DescArea = cboArea.Text;
                        oBE.IdCargo = Convert.ToInt32(cboCargo.EditValue);
                        oBE.DescCargo = cboCargo.Text;
                        oBE.IdHorario = Convert.ToInt32(cboHorario.EditValue);
                        oBE.FechaIni = Convert.ToDateTime(deFechaIni.EditValue);
                        oBE.FechaVen = deFechaVen.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaVen.DateTime.ToShortDateString());
                        oBE.IdTipoRenta = Convert.ToInt32(cboTipoRenta.EditValue);
                        oBE.DescTipoRenta = cboTipoRenta.Text;
                        oBE.Sueldo = Convert.ToDecimal(txtSueldo.EditValue);
                        oBE.HoraExtra = Convert.ToDecimal(txtHoraExtra.EditValue);
                        oBE.BonSueldo = Convert.ToDecimal(txtBonSueldo.EditValue);
                        oBE.SueldoNeto = Convert.ToDecimal(txtSueldoNeto.EditValue);
                        oBE.IdClasificacionTrabajador = Convert.ToInt32(cboClasificacionTrabajador.EditValue);
                        oBE.DescClasificacionTrabajador = cboClasificacionTrabajador.Text;
                        oBE.RutaContrato = txtRutaContrato.Text;
                        oBE.Observacion = txtObservacion.Text;
                        oBE.FlagHoraExtra = chkHoraExtra.Checked;
                        oBE.Dias = Convert.ToInt32(txtDuracion.EditValue);
                        oBE.FlagEstado = true;
                        oBE.Usuario = Parametros.strUsuarioLogin;
                        oBE.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        oBE.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                        this.DialogResult = DialogResult.OK;
                    }
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

            if (IdPersona == 0 && TipoRegistro == 0)
            {
                strMensaje = strMensaje + "- Seleccione a un personal.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                if (lstContrato.Count>0)
                {
                    var Buscar = lstContrato.Where(oB => oB.IdPersona == IdPersona && oB.FechaIni == deFechaIni.DateTime).ToList();
                    if (Buscar.Count > 0)
                    {
                        strMensaje = strMensaje + "- El Contrato ya existe.\n";
                        flag = true;
                    }
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HistorialBE ins = new HistorialBE();
            HistorialBL ins1 = new HistorialBL();

            ins.Id = IdPersona.ToString();
            ins.FechaInicio = this.deFechaIni.EditValue.ToString();
            ins.FechaFin = this.deFechaVen.EditValue.ToString();
            ins1.Inserta(ins);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ConsultaHistorialBE obj1 = new ConsultaHistorialBE();
            obj1.IdPersona = IdPersona;
            
            Presentation.Modulos.RecursosHumanos.Consultas.frmConstultaHistorial frm = new
            Presentation.Modulos.RecursosHumanos.Consultas.frmConstultaHistorial();
            frm.IdPersona = IdPersona;
            frm.Show();
        
        }

        private void txtSueldo_EditValueChanged(object sender, EventArgs e)
        {
            CalcularSueldoNeto();
            //if (chkHoraExtra.Checked)
            //{
            //    if (Convert.ToDecimal(txtSueldo.EditValue) > 0)
            //    {
            //        txtHoraExtra.EditValue = Math.Round(((((Convert.ToDouble(txtSueldo.EditValue) / 30) / 8) * (1.25 * 24)) * 1.25), 2);
            //        txtSueldoNeto.EditValue = Convert.ToDouble(txtSueldo.EditValue) + Convert.ToDouble(txtHoraExtra.EditValue);                
            //    }
            //}
            //else
            //{
            //    txtSueldoNeto.EditValue = txtSueldo.EditValue;
            //}
        }

        private void chkHoraExtra_CheckedChanged(object sender, EventArgs e)
        {
            CalcularSueldoNeto();
        }


        private void CalcularSueldoNeto()
        {
            if (chkHoraExtra.Checked)
            {
                if (Convert.ToDecimal(txtSueldo.EditValue) > 0)
                {
                    txtHoraExtra.EditValue = Math.Round(((((Convert.ToDouble(txtSueldo.EditValue) / 30) / 8) * (1.25 * 24)) * 1.25), 2);
                    txtSueldoNeto.EditValue = Convert.ToDouble(txtSueldo.EditValue) + Convert.ToDouble(txtHoraExtra.EditValue) + Convert.ToDouble(txtBonSueldo.EditValue);
                }
                else
                {
                    txtHoraExtra.EditValue = 0;
                    txtSueldoNeto.EditValue = 0;
                }
            }
            else
            {
                txtSueldoNeto.EditValue = txtSueldo.EditValue;
                txtHoraExtra.EditValue = 0;
            }
        }

        public class CContrato
        {
            public Int32 IdContrato { get; set; }
            public Int32 IdTipoContrato { get; set; }
            public Int32 IdTipoTrabajador { get; set; }
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPersona { get; set; }
            public Int32 IdTienda { get; set; }
            public Int32 IdArea { get; set; }
            public Int32 IdCargo { get; set; }
            public Int32 IdHorario { get; set; }
            public DateTime FechaIni { get; set; }
            public DateTime? FechaVen { get; set; }
            public Int32 IdTipoRenta { get; set; }
            public Decimal Sueldo { get; set; }
            public Decimal HoraExtra { get; set; }
            public Decimal SueldoNeto { get; set; }
            public Int32 IdClasificacionTrabajador { get; set; }
            public String RutaContrato { get; set; }
            public String Observacion { get; set; }
            public Boolean FlagEstado { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public String DescTipoContrato { get; set; }
            public String DescTipoTrabajador { get; set; }
            public String RazonSocial { get; set; }
            public String Dni { get; set; }
            public String ApeNom { get; set; }
            public String DescTienda { get; set; }
            public String DescArea { get; set; }
            public String DescCargo { get; set; }
            public String DescHorario { get; set; }
            public String DescTipoRenta { get; set; }
            public String DescClasificacionTrabajador { get; set; }
            public Boolean FlagHoraExtra { get; set; }
            public DateTime FechaIngreso { get; set; }
            public String DescBanco { get; set; }
            public String NumeroCuenta { get; set; }
            public String Descanso { get; set; }
            public String SistemaPension { get; set; }
            public Int32 Dias { get; set; }

            public Int32 TipoOper { get; set; }

            public CContrato()
            {

            }
        }

        private void deFechaVen_EditValueChanged(object sender, EventArgs e)
        {
            if (deFechaVen.Text != "" && deFechaIni.Text != "")
            {
                txtDuracion.EditValue = (Convert.ToDateTime(deFechaVen.EditValue) - Convert.ToDateTime(deFechaIni.EditValue)).TotalDays + 1;
            }
        }
    }
}