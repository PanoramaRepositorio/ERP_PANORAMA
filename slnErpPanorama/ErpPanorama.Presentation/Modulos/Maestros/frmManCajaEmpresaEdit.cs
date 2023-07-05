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
    public partial class frmManCajaEmpresaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CajaEmpresaBE> lstCajaEmpresa;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CajaEmpresaBE pCajaEmpresaBE { get; set; }

        int _IdCajaEmpresa = 0;

        public int IdCajaEmpresa
        {
            get { return _IdCajaEmpresa; }
            set { _IdCajaEmpresa = value; }
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

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        int _IdTipoFormato = 0;
        public int IdTipoFormato //add
        {
            get { return _IdTipoFormato; }
            set { _IdTipoFormato = value; }
        }

        #endregion

        #region "Eventos"
        public frmManCajaEmpresaEdit()
        {
            InitializeComponent();
        }

        private void frmManCajaEmpresaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = IdTienda;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboFormato, new TablaElementoBL().ListaTodosActivoPorTabla(IdEmpresa, Parametros.intTblTipoFormato), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Caja Empresa - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Caja Empresa - Modificar";
                cboTienda.EditValue = pCajaEmpresaBE.IdTienda;
                cboCaja.EditValue = pCajaEmpresaBE.IdCaja;
                cboEmpresa.EditValue = pCajaEmpresaBE.IdEmpresa;
                cboFormato.EditValue = pCajaEmpresaBE.IdTipoFormato;
                txtSerieBoleta.Text = pCajaEmpresaBE.SerieBoleta;
                txtSerieFactura.Text = pCajaEmpresaBE.SerieFactura;
            }

            cboEmpresa.Focus();
        }


        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
                cboCaja.EditValue = IdCaja;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CajaEmpresaBL objBL_CajaEmpresa = new CajaEmpresaBL();
                    CajaEmpresaBE objCajaEmpresa = new CajaEmpresaBE();

                    objCajaEmpresa.IdCajaEmpresa = IdCajaEmpresa;
                    objCajaEmpresa.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objCajaEmpresa.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objCajaEmpresa.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objCajaEmpresa.IdTipoFormato = Convert.ToInt32(cboFormato.EditValue);
                    objCajaEmpresa.SerieBoleta = txtSerieBoleta.Text.Trim();
                    objCajaEmpresa.SerieFactura = txtSerieFactura.Text.Trim();
                    objCajaEmpresa.FlagEstado = true;
                    objCajaEmpresa.Usuario = Parametros.strUsuarioLogin;
                    objCajaEmpresa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_CajaEmpresa.Inserta(objCajaEmpresa);
                    else
                        objBL_CajaEmpresa.Actualiza(objCajaEmpresa);

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

            //if (IdPersona == 0)
            //{
            //    strMensaje = strMensaje + "- Seleccionar el cajero(a).\n";
            //    flag = true;
            //}

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstCajaEmpresa.Where(oB => oB.IdEmpresa == IdEmpresa).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La Empresa ya existe.\n";
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