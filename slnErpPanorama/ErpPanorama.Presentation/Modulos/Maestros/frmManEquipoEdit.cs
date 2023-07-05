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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManEquipoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<EquipoBE> lstEquipo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdEquipo = 0;

        public int IdEquipo
        {
            get { return _IdEquipo; }
            set { _IdEquipo = value; }
        }

        private int IdCaja = 0;
        #endregion

        #region "Eventos"

        public frmManEquipoEdit()
        {
            InitializeComponent();
        }

        private void frmManEquipoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Empresa - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Equipo - Modificar";

                EquipoBE objE_Equipo = new EquipoBE();

                objE_Equipo = new EquipoBL().Selecciona(IdEquipo);

                IdEquipo = objE_Equipo.IdEquipo;
                IdCaja = objE_Equipo.IdCaja;
                cboEmpresa.EditValue = objE_Equipo.IdEmpresa;
                cboTienda.EditValue = objE_Equipo.IdTienda;
                cboAlmacen.EditValue = objE_Equipo.IdAlmacen;
                cboCaja.EditValue = objE_Equipo.IdCaja;
                txtHostName.Text = objE_Equipo.HostName;
                txtSO.Text = objE_Equipo.SistemaOperativo;
                txtMAC.Text = objE_Equipo.Mac;

                deFechaRegistro.EditValue = objE_Equipo.FechaRegistro;
                deFechaCreacion.EditValue = objE_Equipo.FechaCreacion;
                deFechaModificacion.EditValue = objE_Equipo.FechaModificacion;
                txtUsuarioCreacion.Text = objE_Equipo.UsuarioCreacion;
                txtUsuarioModificacion.Text = objE_Equipo.UsuarioModificacion;
                chkPermitirAcceso.Checked = objE_Equipo.FlagAcceso;
            }
            txtSO.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!ValidarIngreso())
            {
                EquipoBL objBL_Equipo = new EquipoBL();
                EquipoBE objEquipo = new EquipoBE();

                objEquipo.IdEquipo = IdEquipo;
                objEquipo.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objEquipo.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                objEquipo.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                objEquipo.HostName = txtHostName.Text;
                objEquipo.SistemaOperativo = txtSO.Text;
                objEquipo.Mac = txtMAC.Text;
                objEquipo.FechaRegistro = DateTime.Now;
                objEquipo.FechaCreacion = DateTime.Now;
                objEquipo.UsuarioCreacion = Parametros.strUsuarioLogin;
                objEquipo.FechaModificacion = DateTime.Now;
                objEquipo.UsuarioModificacion = Parametros.strUsuarioLogin;
                objEquipo.FlagAcceso = chkPermitirAcceso.Checked;
                objEquipo.FlagEstado = true;
                objEquipo.Usuario = Parametros.strUsuarioLogin;
                objEquipo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objEquipo.IdEmpresa = Parametros.intEmpresaId;
                if (cboCaja.Text == "") objEquipo.IdCaja = 0;

                if (pOperacion == Operacion.Nuevo)
                    objBL_Equipo.Inserta(objEquipo);
                else
                    objBL_Equipo.Actualiza(objEquipo);

                this.DialogResult = DialogResult.OK;
                this.Close();
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

            if (txtHostName.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el HostName.\n";
                flag = true;
            }

            //if (txtRazonSocial.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese la razón social.\n";
            //    flag = true;
            //}

            //if (cboRegimenTributario.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Seleccione el regimen tributario.\n";
            //    flag = true;
            //}


            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstEquipo.Where(oB => oB.Ruc.ToUpper() == txtRuc.Text.ToUpper()).ToList();
            //    if (Buscar.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- El Ruc ya existe.\n";
            //        flag = true;
            //    }

            //    var BuscarRazonSocial = lstEquipo.Where(oB => oB.RazonSocial.ToUpper() == txtRazonSocial.Text.ToUpper()).ToList();
            //    if (BuscarRazonSocial.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- La Razón social ya existe.\n";
            //        flag = true;
            //    }
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                //BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
                BSUtils.LoaderLook(cboCaja, new EquipoBL().ListaCaja(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue), IdEquipo), "DescCaja", "IdCaja", true);
                    cboCaja.EditValue = IdCaja;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEliminarTienda_Click(object sender, EventArgs e)
        {
            cboTienda.EditValue = 0;
            cboAlmacen.EditValue = 0;
        }

        private void btnEliminarCaja_Click(object sender, EventArgs e)
        {
            cboCaja.EditValue = 0;
        }

        private void cboAlmacen_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}