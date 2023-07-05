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
using ErpPanorama.Presentation.Modulos.Maestros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManContratoFormatoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ContratoFormatoBE> lstContratoFormato;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        //public ContratoFormatoBE pContratoFormatoBE { get; set; }

        int _IdContratoFormato = 0;

        public int IdContratoFormato
        {
            get { return _IdContratoFormato; }
            set { _IdContratoFormato = value; }
        }

        #endregion

        #region "Eventos"
        public frmManContratoFormatoEdit()
        {
            InitializeComponent();
        }

        private void frmManContratoFormatoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipoContrato, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoContrato), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Contrato - Nuevo";
                //txtContratoFormato.Text = pContratoFormatoBE.DescContratoFormato.Trim();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Contrato - Modificar";

                ContratoFormatoBE objE_ContratoFormatoBE = new ContratoFormatoBE();
                objE_ContratoFormatoBE = new ContratoFormatoBL().Selecciona(IdContratoFormato);
                //IdContratoFormato = objE_ContratoFormatoBE.IdContratoFormato;
                txtDescripcion.Text = objE_ContratoFormatoBE.Descripcion;
                cboTipoContrato.EditValue = objE_ContratoFormatoBE.IdTipoContrato;
                txtTitulo.Text = objE_ContratoFormatoBE.Titulo;
                txtCuerpo.Text = objE_ContratoFormatoBE.Cuerpo;
                txtFirma.Text = objE_ContratoFormatoBE.Firma;
            }

            txtDescripcion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ContratoFormatoBL objBL_ContratoFormato = new ContratoFormatoBL();
                    ContratoFormatoBE objContratoFormato = new ContratoFormatoBE();

                    objContratoFormato.IdContratoFormato = IdContratoFormato;
                    objContratoFormato.IdTipoContrato = Convert.ToInt32(cboTipoContrato.EditValue);
                    objContratoFormato.Descripcion = txtDescripcion.Text;
                    objContratoFormato.Titulo = txtTitulo.Text;
                    objContratoFormato.Cuerpo = txtCuerpo.Text;
                    objContratoFormato.Firma = txtFirma.Text;
                    objContratoFormato.FlagEstado = true;
                    objContratoFormato.Usuario = Parametros.strUsuarioLogin;
                    objContratoFormato.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objContratoFormato.IdEmpresa = Parametros.intEmpresaId;


                    if (pOperacion == Operacion.Nuevo)
                        objBL_ContratoFormato.Inserta(objContratoFormato);
                    else
                        objBL_ContratoFormato.Actualiza(objContratoFormato);

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

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese nombre de contrato.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstContratoFormato.Where(oB => oB.Descripcion.ToUpper() == txtDescripcion.Text.ToUpper() || oB.DescTipoContrato.ToUpper() == cboTipoContrato.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "-El contrato ya existe.\n";
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

        private void btnEditarElemento_Click(object sender, EventArgs e)
        {
            frmManTablaElemento objManTablaElemento = new frmManTablaElemento();
            objManTablaElemento.IdTabla = Parametros.intTblTipoContrato;
            objManTablaElemento.StartPosition = FormStartPosition.CenterParent;
            objManTablaElemento.ShowDialog();
            BSUtils.LoaderLook(cboTipoContrato, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoContrato), "DescTablaElemento", "IdTablaElemento", true);

        }
    }
}