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


namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManPersonaContratoEdit : DevExpress.XtraEditors.XtraForm
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
            Consultar = 4,
            Renovar = 5
        }

        public Operacion pOperacion { get; set; }

        public int IdPersona = 0;
        public int TipoRegistro = 0;

        #endregion

        #region "Eventos"

        public frmManPersonaContratoEdit()
        {
            InitializeComponent();
        }

        private void frmManPersonaContratoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboModalidad, CargarModalidad(), "Descripcion", "Id", true);
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

                cboTipoContrato.EditValue = oBE.IdTipoContrato;
                cboTipoTrabajador.EditValue = oBE.IdTipoTrabajador;
                cboEmpresa.EditValue = oBE.IdEmpresa;
                IdPersona = oBE.IdPersona;
                cboTienda.EditValue = oBE.IdTienda;
                cboArea.EditValue = oBE.IdArea;
                cboCargo.EditValue = oBE.IdCargo;
                cboHorario.EditValue = oBE.IdHorario;
                deFechaIni.EditValue = oBE.FechaIni;
                if (oBE.FechaVen != null)
                    deFechaVen.EditValue = oBE.FechaVen;
                cboTipoRenta.EditValue = oBE.IdTipoRenta;
                txtSueldo.EditValue = oBE.Sueldo;
                txtBonSueldo.EditValue = oBE.BonSueldo;
                txtHoraExtra.EditValue = oBE.HoraExtra;
                txtMovilidad.EditValue = oBE.Movilidad;
                txtSueldoNeto.EditValue = oBE.SueldoNeto;
                cboClasificacionTrabajador.EditValue = oBE.IdClasificacionTrabajador;
                txtRutaContrato.Text = oBE.RutaContrato;
                txtObservacion.EditValue = oBE.Observacion;
                txtDuracion.EditValue = oBE.Dias;
                txtMeses.EditValue = oBE.Meses;
                chkHoraExtra.Checked = oBE.FlagHoraExtra;

            }
            else if (pOperacion == Operacion.Renovar)
            {
                this.Text = "Contrato Laboral - Renovación";

                //ContratoBE objE_Contrato = new ContratoBE();
                oBE = new ContratoBL().SeleccionaUltimo(IdPersona);

                int Year = 0;
                int Mes = 0;
                DateTime FechaFin = Convert.ToDateTime(oBE.FechaVen).AddMonths(oBE.Meses).AddDays(oBE.Dias);

                cboTipoContrato.EditValue = oBE.IdTipoContrato;
                cboTipoTrabajador.EditValue = oBE.IdTipoTrabajador;
                cboEmpresa.EditValue = oBE.IdEmpresa;
                //IdPersona = oBE.IdPersona;
                cboTienda.EditValue = oBE.IdTienda;
                cboArea.EditValue = oBE.IdArea;
                cboCargo.EditValue = oBE.IdCargo;
                cboHorario.EditValue = oBE.IdHorario;
                deFechaIni.EditValue = Convert.ToDateTime(oBE.FechaVen).AddDays(1);
                //if (oBE.FechaVen != null)
                //deFechaVen.EditValue = Convert.ToDateTime(oBE.FechaVen).AddDays(oBE.Dias + 1);
                //deFechaVen.EditValue = Convert.ToDateTime(oBE.FechaVen).AddMonths(oBE.Meses).AddDays(oBE.Dias);
                deFechaVen.EditValue = Convert.ToDateTime(System.DateTime.DaysInMonth(FechaFin.Year, FechaFin.Month) + "/" + FechaFin.Month + "/" + FechaFin.Year);
                //deFechaVen.EditValue = Convert.ToDateTime(oBE.FechaVen).AddDays(1);
                cboTipoRenta.EditValue = oBE.IdTipoRenta;
                txtSueldo.EditValue = oBE.Sueldo;
                txtBonSueldo.EditValue = oBE.BonSueldo;
                txtHoraExtra.EditValue = oBE.HoraExtra;
                txtMovilidad.EditValue = oBE.Movilidad;
                txtSueldoNeto.EditValue = oBE.SueldoNeto;
                cboClasificacionTrabajador.EditValue = oBE.IdClasificacionTrabajador;
                txtRutaContrato.Text = oBE.RutaContrato;
                txtObservacion.EditValue = oBE.Observacion;
                txtDuracion.EditValue = oBE.Dias;
                txtMeses.EditValue = oBE.Meses;
                chkHoraExtra.Checked = oBE.FlagHoraExtra;
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
             try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    //ContratoBE oBE = new ContratoBE();
                    oBE.IdContrato = IdContrato;
                    oBE.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    oBE.RazonSocial = cboEmpresa.Text;
                    oBE.IdTipoContrato = Convert.ToInt32(cboTipoContrato.EditValue);
                    oBE.DescTipoContrato = cboTipoContrato.Text;
                    oBE.IdTipoTrabajador = Convert.ToInt32(cboTipoTrabajador.EditValue);
                    oBE.DescTipoTrabajador = cboTipoTrabajador.Text;
                    oBE.IdPersona = IdPersona;
                    oBE.ApeNom = cboEmpresa.Text;
                    oBE.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    oBE.DescTienda = cboTienda.Text;
                    oBE.IdArea = Convert.ToInt32(cboArea.EditValue);
                    oBE.DescArea = cboArea.Text;
                    oBE.IdCargo = Convert.ToInt32(cboCargo.EditValue);
                    oBE.DescCargo = cboCargo.Text;
                    oBE.IdHorario = Convert.ToInt32(cboHorario.EditValue);
                    oBE.FechaIni = Convert.ToDateTime(deFechaIni.DateTime.ToShortDateString());
                    oBE.FechaVen = deFechaVen.DateTime.Year == 1 ? (DateTime?)null : Convert.ToDateTime(deFechaVen.DateTime.ToShortDateString());
                    oBE.IdTipoRenta = Convert.ToInt32(cboTipoRenta.EditValue);
                    oBE.DescTipoRenta = cboTipoRenta.Text;
                    oBE.Sueldo = Convert.ToDecimal(txtSueldo.EditValue);
                    oBE.HoraExtra = Convert.ToDecimal(txtHoraExtra.EditValue);
                    oBE.BonSueldo = Convert.ToDecimal(txtBonSueldo.EditValue);
                    oBE.Movilidad = Convert.ToDecimal(txtMovilidad.EditValue);
                    oBE.SueldoNeto = Convert.ToDecimal(txtSueldoNeto.EditValue);
                    oBE.IdClasificacionTrabajador = Convert.ToInt32(cboClasificacionTrabajador.EditValue);
                    oBE.DescClasificacionTrabajador = cboClasificacionTrabajador.Text;
                    oBE.RutaContrato = txtRutaContrato.Text;
                    oBE.Observacion = txtObservacion.Text;
                    oBE.FlagHoraExtra = chkHoraExtra.Checked;
                    oBE.Dias = Convert.ToInt32(txtDuracion.EditValue);
                    oBE.Meses = Convert.ToInt32(txtMeses.EditValue);
                    oBE.FlagEstado = true;
                    oBE.Usuario = Parametros.strUsuarioLogin;
                    oBE.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    oBE.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                    this.DialogResult = DialogResult.OK;
                   
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

        private void txtSueldo_EditValueChanged(object sender, EventArgs e)
        {
            CalcularSueldoNeto();

        }

        private void chkHoraExtra_CheckedChanged(object sender, EventArgs e)
        {
            CalcularSueldoNeto();
        }

        private void deFechaVen_EditValueChanged(object sender, EventArgs e)
        {
            DiferenciaFecha2();
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

            //if (Convert.ToInt32(txtMeses.EditValue) == 0 && Convert.ToInt32(cboModalidad.EditValue) == 1 )
            //{
            //    strMensaje = strMensaje + "- Ingresar la duración en meses del contrato.\n";
            //    flag = true;
            //}

            if (Convert.ToDecimal(txtSueldo.EditValue)<=0)
            {
                strMensaje = strMensaje + "- El sueldo tiene que ser mayor a Cero.\n";
                flag = true;
            }


            if (pOperacion == Operacion.Nuevo)
            {
                if (lstContrato.Count > 0)
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

        private void CalcularSueldoNeto()
        {
            if (chkHoraExtra.Checked)
            {
                if (Convert.ToDecimal(txtSueldo.EditValue) > 0)
                {
                    txtHoraExtra.EditValue = Math.Round(((((Convert.ToDouble(txtSueldo.EditValue) / 30) / 8) * (1.25 * 24)) * 1.25), 2);
                    txtSueldoNeto.EditValue = Convert.ToDouble(txtSueldo.EditValue) + Convert.ToDouble(txtHoraExtra.EditValue);
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

        private DataTable CargarModalidad()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "PLAZO FIJO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "PLAZO INDETERMINADO";
            dt.Rows.Add(dr);
            return dt;
        }

        private String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }

            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";

            return str;
        }


        #endregion

        private void cboModalidad_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboModalidad.EditValue) == 2)
            {
                cboTipoRenta.EditValue = 217;
                cboTipoRenta.Properties.ReadOnly = true;
                txtMeses.Properties.ReadOnly = true;
            }
            else
            {
                cboTipoRenta.Properties.ReadOnly = false;
                txtMeses.Properties.ReadOnly = false;
            }
        }

        private void cboHorario_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void deFechaIni_EditValueChanged(object sender, EventArgs e)
        {
            DiferenciaFecha2();
        }

        private void DiferenciaFecha2()
        {
            if (deFechaVen.Text != "" && deFechaIni.Text != "")
            {
                txtTotalDias.EditValue = (Convert.ToDateTime(deFechaVen.EditValue) - Convert.ToDateTime(deFechaIni.EditValue)).TotalDays + 1;

                #region "Diferencia"
                txtMeses.EditValue = 0;
                txtDuracion.EditValue = 0;
                Int32 anios;
                Int32 meses;
                Int32 dias;
                //String str = "";

                anios = (deFechaVen.DateTime.Year - deFechaIni.DateTime.Year);
                meses = (deFechaVen.DateTime.Month - deFechaIni.DateTime.Month);
                dias = (deFechaVen.DateTime.Day - deFechaIni.DateTime.Day);

                if (meses < 0)
                {
                    anios -= 1;
                    meses += 12;
                }
                if (dias < 0)
                {
                    meses -= 1;
                    dias += DateTime.DaysInMonth(deFechaVen.DateTime.Year, deFechaVen.DateTime.Month);
                }

                if (anios < 0)
                {
                    txtMeses.EditValue = 0;
                    txtDuracion.EditValue = 0;
                }
                //if (anios > 0)
                    //txtMeses.EditValue = (anios * 12);
                if (meses > 0)
                    txtMeses.EditValue = meses;
                if (dias > 0)
                    txtDuracion.EditValue = dias;
                #endregion

            }
        }
    }
}