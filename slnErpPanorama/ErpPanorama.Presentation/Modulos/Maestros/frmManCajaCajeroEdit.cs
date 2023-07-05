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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManCajaCajeroEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CajaCajeroBE> lstCajaCajero;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CajaCajeroBE pCajaCajeroBE { get; set; }

        int _IdCajaCajero = 0;

        public int IdCajaCajero
        {
            get { return _IdCajaCajero; }
            set { _IdCajaCajero = value; }
        }

        int _IdTienda = 0;

        public int IdTienda
        {
            get { return _IdTienda; }
            set { _IdTienda = value; }
        }

        int _IdCaja = 0;

        public int IdCaja
        {
            get { return _IdCaja; }
            set { _IdCaja = value; }
        }

        private int IdPersona = 0;
        
        #endregion

        #region "Eventos"

        public frmManCajaCajeroEdit()
        {
            InitializeComponent();
        }

        private void frmManCajaCajeroEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = IdTienda;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Caja Cajero(a) - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Caja Cajero(a) - Modificar";
                cboTienda.EditValue = pCajaCajeroBE.IdTienda;
                cboCaja.EditValue = pCajaCajeroBE.IdCaja;
                txtPersona.Text = pCajaCajeroBE.ApeNom;
            }

            btnBuscar.Focus();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CajaCajeroBL objBL_CajaCajero = new CajaCajeroBL();
                    CajaCajeroBE objCajaCajero = new CajaCajeroBE();

                    objCajaCajero.IdCajaCajero = IdCajaCajero;
                    objCajaCajero.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objCajaCajero.IdPersona = IdPersona;
                    objCajaCajero.FlagEstado = true;
                    objCajaCajero.Usuario = Parametros.strUsuarioLogin;
                    objCajaCajero.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCajaCajero.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_CajaCajero.Inserta(objCajaCajero);
                    else
                        objBL_CajaCajero.Actualiza(objCajaCajero);

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

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboCaja.Text))
            {
                strMensaje = strMensaje + "- Seleccionar la tabla.\n";
                flag = true;
            }

            if (IdPersona == 0)
            {
                strMensaje = strMensaje + "- Seleccionar el cajero(a).\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstCajaCajero.Where(oB => oB.IdPersona == IdPersona).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La persona ya existe.\n";
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