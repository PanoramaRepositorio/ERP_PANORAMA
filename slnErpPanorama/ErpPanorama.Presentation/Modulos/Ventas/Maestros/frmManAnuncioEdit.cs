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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManAnuncioEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<AnuncioBE> lstAnuncio;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public AnuncioBE pAnuncioBE { get; set; }

        int _IdAnuncio = 0;

        public int IdAnuncio
        {
            get { return _IdAnuncio; }
            set { _IdAnuncio = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManAnuncioEdit()
        {
            InitializeComponent();
        }

        private void frmAnuncioEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboTipoAnuncio, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoAnuncio), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Anuncio - Nuevo";
                txtAnuncio.Text = "";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Anuncio - Modificar";
                deFecha.EditValue = pAnuncioBE.Fecha;
                txtAnuncio.Text = pAnuncioBE.DescAnuncio.Trim();
                deDesde.EditValue = pAnuncioBE.FechaInicio;
                deHasta.EditValue = pAnuncioBE.FechaFin;
                cboTipoAnuncio.EditValue = pAnuncioBE.IdTipoAnuncio;
                txtTitulo.Text = pAnuncioBE.Titulo;
            }

            txtAnuncio.Select();
        }

        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    AnuncioBL objBL_Anuncio = new AnuncioBL();

                    AnuncioBE objAnuncio = new AnuncioBE();
                    objAnuncio.IdAnuncio = IdAnuncio;
                    objAnuncio.Fecha = deFecha.DateTime;
                    objAnuncio.DescAnuncio = txtAnuncio.Text;
                    objAnuncio.FechaInicio = Convert.ToDateTime(deDesde.DateTime.ToShortDateString());
                    objAnuncio.FechaFin = Convert.ToDateTime(deHasta.DateTime.ToShortDateString());
                    objAnuncio.IdTipoAnuncio = Convert.ToInt32(cboTipoAnuncio.EditValue);
                    objAnuncio.Titulo = txtTitulo.Text;
                    objAnuncio.FlagEstado = true;
                    objAnuncio.Usuario = Parametros.strUsuarioLogin;
                    objAnuncio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objAnuncio.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Anuncio.Inserta(objAnuncio);
                    else
                        objBL_Anuncio.Actualiza(objAnuncio);

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

      
        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtAnuncio.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Anuncio.\n";
                flag = true;
            }

            if (deDesde.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha de Inicio.\n";
                flag = true;
            }

            if (deHasta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Fecha de Término.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstAnuncio.Where(oB => oB.DescAnuncio.ToUpper() == txtAnuncio.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Contenido del Anuncio ya existe.\n";
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

        private void cboTipoAnuncio_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoAnuncio.EditValue) == Parametros.intAnuncioAlerta)
            {
                txtTitulo.Visible = true;
                lblTitulo.Visible = true;
                this.Size = new Size(745, 190);
            }
            else if (Convert.ToInt32(cboTipoAnuncio.EditValue) == Parametros.intAnuncioAlertaPopup)
            {
                txtTitulo.Visible = true;
                lblTitulo.Visible = true;
                this.Size = new Size(745, 350);
            }
            else
            {
                txtTitulo.Visible = false;
                lblTitulo.Visible = false;
                this.Size = new Size(745, 190);
            }
        }
    }
}