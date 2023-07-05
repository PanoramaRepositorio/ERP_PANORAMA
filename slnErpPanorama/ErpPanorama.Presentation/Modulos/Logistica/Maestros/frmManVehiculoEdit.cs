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
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManVehiculoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<VehiculoBE> lstVehiculo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public VehiculoBE pVehiculoBE { get; set; }

        int _IdVehiculo = 0;

        public int IdVehiculo
        {
            get { return _IdVehiculo; }
            set { _IdVehiculo = value; }
        }
        public int IdPersona = 0;

        #endregion

        #region "Eventos"

        public frmManVehiculoEdit()
        {
            InitializeComponent();
        }

        private void frmManVehiculoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", false);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Vehiculo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Vehiculo - Modificar";
                //pVehiculoBE.IdVehiculo = IdVehiculo;
                cboEmpresa.EditValue = pVehiculoBE.IdEmpresa;
                txtPlaca.Text = pVehiculoBE.Placa;
                txtNumeroSerie.Text = pVehiculoBE.NumeroSerie;
                txtNumeroMotor.Text = pVehiculoBE.NumeroMotor;
                txtColor.Text = pVehiculoBE.Color;
                txtMarca.Text = pVehiculoBE.Marca;
                txtModelo.Text = pVehiculoBE.Modelo;
                txtCodigo.Text = pVehiculoBE.Codigo;
                txtPeriodo.EditValue = pVehiculoBE.Periodo;
                IdPersona = Convert.ToInt32(pVehiculoBE.IdConductor);
                txtObservacion.Text = pVehiculoBE.Observacion;
                txtPersona.Text = pVehiculoBE.DescConductor;
            }

            txtPlaca.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    VehiculoBL objBL_Vehiculo = new VehiculoBL();
                    VehiculoBE objE_Vehiculo = new VehiculoBE();
                    objE_Vehiculo.IdVehiculo = IdVehiculo;
                    objE_Vehiculo.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objE_Vehiculo.Placa = txtPlaca.Text;
                    objE_Vehiculo.NumeroSerie = txtNumeroSerie.Text.Trim();
                    objE_Vehiculo.NumeroMotor = txtNumeroMotor.Text.Trim();
                    objE_Vehiculo.Color = txtColor.Text;
                    objE_Vehiculo.Marca = txtMarca.Text;
                    objE_Vehiculo.Modelo = txtModelo.Text;
                    objE_Vehiculo.Codigo = txtCodigo.Text;
                    objE_Vehiculo.Periodo = Convert.ToInt32(txtPeriodo.Text);
                    objE_Vehiculo.IdConductor = IdPersona;
                    objE_Vehiculo.Observacion = txtObservacion.Text.Trim();
                    objE_Vehiculo.FlagEstado = true;
                    objE_Vehiculo.Usuario = Parametros.strUsuarioLogin;
                    objE_Vehiculo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Vehiculo.Inserta(objE_Vehiculo);
                    else
                        objBL_Vehiculo.Actualiza(objE_Vehiculo);

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.TipoBusqueda = 0;
                //frm.Title = "Búsqueda de Persona sin Usuario";
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    IdPersona = frm._Be.IdPersona;
                    txtPersona.Text = frm._Be.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IdPersona = 0;
            txtPersona.Text = "";
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboEmpresa.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una Empresa.\n";
                flag = true;
            }

            if (txtPlaca.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la placa.\n";
                flag = true;
            }

            if (txtPeriodo.Text == "")
            {
                strMensaje = strMensaje + "- Ingrese el Año del vehículo.\n";
                flag = true;
            }


            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstVehiculo.Where(oB => oB.Placa.ToUpper() == txtPlaca.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El vehículo ya existe.\n";
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

    }
}