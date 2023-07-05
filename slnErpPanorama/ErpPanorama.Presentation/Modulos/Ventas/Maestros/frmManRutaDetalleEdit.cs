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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManRutaDetalleEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        String _IdUbigeo = "";

        public string IdUbigeo
        {
            get { return _IdUbigeo; }
            set { _IdUbigeo = value; }
        }

        int _IdRuta = 0;

        public int IdRuta
        {
            get { return _IdRuta; }
            set { _IdRuta = value; }
        }

        int _IdRutaDetalle = 0;
        public int IdRutaDetalle
        {
            get { return _IdRutaDetalle; }
            set { _IdRutaDetalle = value; }
        }

        #endregion

        #region "Eventos"

        public frmManRutaDetalleEdit()
        {
            InitializeComponent();
        }

        private void frmManRutaDetalleEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Ruta Detalle - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Ruta Detalle - Modificar";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                if (IdUbigeo != "")
                    IdDepartamento = IdUbigeo.Substring(0, 2);
                cboDepartamento.EditValue = IdDepartamento;
                if (IdUbigeo != "")
                    IdProvincia = IdUbigeo.Substring(2, 2);
                cboProvincia.EditValue = IdProvincia;
                if (IdUbigeo != "")
                    IdDistrito = IdUbigeo.Substring(4, 2);
                cboDistrito.EditValue = IdDistrito;

            }
            cboDepartamento.Select();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
     
                    RutaDetalleBL objBL_RutaDetalle = new RutaDetalleBL();
                    RutaDetalleBE objE_RutaDetalle = new RutaDetalleBE();

                    objE_RutaDetalle.IdRutaDetalle = IdRutaDetalle;
                    objE_RutaDetalle.IdRuta = IdRuta;
                    objE_RutaDetalle.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objE_RutaDetalle.FlagEstado = true;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_RutaDetalle.Inserta(objE_RutaDetalle);
                    else
                        objBL_RutaDetalle.Actualiza(objE_RutaDetalle);

                    this.Close();
               
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

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }
        }

        #endregion

        #region "Metodos"

        #endregion

    }
}