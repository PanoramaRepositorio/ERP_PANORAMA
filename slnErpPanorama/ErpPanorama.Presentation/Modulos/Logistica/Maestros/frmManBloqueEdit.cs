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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManBloqueEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

       
        public List<BloqueBE> lstBloque;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public BloqueBE pBloqueBE { get; set; }

        int _IdBloque = 0;

        public int IdBloque
        {
            get { return _IdBloque; }
            set { _IdBloque = value; }
        }

        int _IdSector = 0;

        public int IdSector
        {
            get { return _IdSector; }
            set { _IdSector = value; }
        }

        #endregion

        #region "Eventos"

        public frmManBloqueEdit()
        {
            InitializeComponent();
        }

        private void frmManBloqueEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSector, new SectorBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intAlmBultos), "DescSector", "IdSector", true);
            cboSector.EditValue = IdSector;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Bloque - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Bloque - Modificar";
                cboSector.EditValue = pBloqueBE.IdSector;
                txtDescripcion.Text = pBloqueBE.DescBloque;
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
                    BloqueBL objBL_Bloque = new BloqueBL();

                    BloqueBE objBloque = new BloqueBE();
                    objBloque.IdAlmacen = Parametros.intAlmBultos;
                    objBloque.IdSector= Convert.ToInt32(cboSector.EditValue);
                    objBloque.IdBloque = IdBloque;
                    objBloque.DescBloque = txtDescripcion.Text;
                    objBloque.FlagEstado = true;
                    objBloque.Usuario = Parametros.strUsuarioLogin;
                    objBloque.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objBloque.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Bloque.Inserta(objBloque);
                    else
                        objBL_Bloque.Actualiza(objBloque);

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

            if (string.IsNullOrEmpty(cboSector.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un sector.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstBloque.Where(oB => oB.DescBloque.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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