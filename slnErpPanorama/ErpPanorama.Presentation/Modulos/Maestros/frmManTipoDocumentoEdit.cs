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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTipoDocumentoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<TipoDocumentoBE> lstTipoDocumento;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoDocumentoBE pTipoDocumentoBE { get; set; }

        int _IdTipoDocumento = 0;

        public int IdTipoDocumento
        {
            get { return _IdTipoDocumento; }
            set { _IdTipoDocumento = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTipoDocumentoEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoDocumentoEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "TipoDocumento - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "TipoDocumento - Modificar";
                txtCodigo.Text = pTipoDocumentoBE.CodTipoDocumento;
                txtDescripcion.Text = pTipoDocumentoBE.DescTipoDocumento.Trim();
            }

            txtCodigo.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TipoDocumentoBL objBL_TipoDocumento = new TipoDocumentoBL();
                    TipoDocumentoBE objTipoDocumento = new TipoDocumentoBE();

                    objTipoDocumento.IdTipoDocumento = IdTipoDocumento;
                    objTipoDocumento.CodTipoDocumento = txtCodigo.Text.Trim();
                    objTipoDocumento.DescTipoDocumento = txtDescripcion.Text.Trim();
                    objTipoDocumento.FlagEstado = true;
                    objTipoDocumento.Usuario = Parametros.strUsuarioLogin;
                    objTipoDocumento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoDocumento.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TipoDocumento.Inserta(objTipoDocumento);
                    else
                        objBL_TipoDocumento.Actualiza(objTipoDocumento);

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

            if (txtCodigo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la abreviatura.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTipoDocumento.Where(oB => oB.DescTipoDocumento.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La descripción ya existe.\n";
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