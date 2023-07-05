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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTalonEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<TalonBE> lstTalon;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        int _IdTienda = 0;

        public int IdTienda
        {
            get { return _IdTienda; }
            set { _IdTienda = value; }
        }

        int _IdTalon = 0;

        public int IdTalon
        {
            get { return _IdTalon; }
            set { _IdTalon = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManTalonEdit()
        {
            InitializeComponent();
        }

        private void frmManTalonEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(IdEmpresa) , "DescTienda", "IdTienda", true);
            cboTienda.EditValue = IdTienda;
            BSUtils.LoaderLook(cboFormato, new TablaElementoBL().ListaTodosActivo(IdEmpresa,Parametros.intTblTipoFormato), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas,0), "CodTipoDocumento", "IdTipoDocumento", true);
            BSUtils.LoaderLook(cboTamanoHoja, new TablaElementoBL().ListaTodosActivo(IdEmpresa, Parametros.intTblTamanoHoja), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Talón - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Talón - Modificar";

                TalonBE objE_Talon = new TalonBE();

                objE_Talon = new TalonBL().Selecciona(IdEmpresa,IdTienda,IdTalon);

                cboCaja.EditValue = objE_Talon.IdCaja;
                cboFormato.EditValue = objE_Talon.IdTipoFormato;
                cboTamanoHoja.EditValue = objE_Talon.IdTamanoHoja;
                cboDocumento.EditValue = objE_Talon.IdTipoDocumento;
                txtNumeroSerie.Text = objE_Talon.NumeroSerie;
                txtNumeroAutorizacion.Text = objE_Talon.NumeroAutoriza;
                txtSerieImpresora.EditValue = objE_Talon.SerieImpresora;
                txtDireccionFiscal.EditValue = objE_Talon.DireccionFiscal;
                txtNombreComercial.EditValue = objE_Talon.NombreComercial;
                txtPaginaWeb.EditValue = objE_Talon.PaginaWeb;
                txtImpresora.EditValue = objE_Talon.Impresora;
                chkAbrirCajon.Checked = objE_Talon.FlagAbrirCajon;
            }

            cboCaja.Select();
        
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(IdEmpresa, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);    
            }
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TalonBL objBL_Talon = new TalonBL();
                    TalonBE objE_Talon = new TalonBE();

                    objE_Talon.IdTalon = IdTalon;
                    objE_Talon.IdEmpresa = IdEmpresa;
                    objE_Talon.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objE_Talon.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_Talon.IdTipoFormato = Convert.ToInt32(cboFormato.EditValue);
                    objE_Talon.IdTamanoHoja = Convert.ToInt32(cboTamanoHoja.EditValue);
                    objE_Talon.NumeroSerie = txtNumeroSerie.Text;
                    objE_Talon.NumeroAutoriza = txtNumeroAutorizacion.Text;
                    objE_Talon.SerieImpresora = txtSerieImpresora.Text;
                    objE_Talon.DireccionFiscal = txtDireccionFiscal.Text;
                    objE_Talon.NombreComercial = txtNombreComercial.Text;
                    objE_Talon.PaginaWeb = txtPaginaWeb.Text;
                    objE_Talon.Impresora = txtImpresora.Text;
                    objE_Talon.FlagAbrirCajon = chkAbrirCajon.Checked;
                    objE_Talon.FlagEstado = true;
                    objE_Talon.Usuario = Parametros.strUsuarioLogin;
                    objE_Talon.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Talon.Inserta(objE_Talon);
                    else
                        objBL_Talon.Actualiza(objE_Talon);

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

            if (cboCaja.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccione la caja.\n";
                flag = true;
            }

            if (cboFormato.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el formato.\n";
                flag = true;
            }

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el tipo de documento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTalon.Where(oB => oB.IdCaja == Convert.ToInt32(cboCaja.EditValue) && oB.IdTipoDocumento == Convert.ToInt32(cboDocumento.EditValue) && oB.NumeroSerie == txtNumeroSerie.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La caja y el documento ya existe.\n";
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

        private void txtNumeroAutorizacion_EditValueChanged(object sender, EventArgs e)
        {
            if(txtNumeroAutorizacion.Text=="TERMICA")
            {
                txtNumeroAutorizacion.ForeColor = Color.Red;
            }
            else
            {
                txtNumeroAutorizacion.ForeColor = Color.Black;
            }
        }
    }
}