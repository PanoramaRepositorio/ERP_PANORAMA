﻿using System;
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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManModeloProductoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ModeloProductoBE> lstModeloProducto;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ModeloProductoBE pModeloProductoBE { get; set; }

        int _IdModeloProducto = 0;

        public int IdModeloProducto
        {
            get { return _IdModeloProducto; }
            set { _IdModeloProducto = value; }
        }

        int _IdLineaProducto = 0;

        public int IdLineaProducto
        {
            get { return _IdLineaProducto; }
            set { _IdLineaProducto = value; }
        }

        int _IdSubLineaProducto = 0;

        public int IdSubLineaProducto
        {
            get { return _IdSubLineaProducto; }
            set { _IdSubLineaProducto = value; }
        }

        #endregion

        #region "Eventos"

        public frmManModeloProductoEdit()
        {
            InitializeComponent();
        }

        private void frmManModeloProductoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboLineaProducto, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            cboLineaProducto.EditValue = IdLineaProducto;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Modelo Producto - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Modelo Producto - Modificar";
                cboLineaProducto.EditValue = pModeloProductoBE.IdLineaProducto;
                cboSubLineaProducto.EditValue = pModeloProductoBE.IdSubLineaProducto;
                txtDescripcion.Text = pModeloProductoBE.DescModeloProducto;
            }

            txtDescripcion.Focus();
        }

        private void cboLineaProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLineaProducto.EditValue != null)
            {
                 BSUtils.LoaderLook(cboSubLineaProducto, new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLineaProducto.EditValue)), "DescSubLineaProducto", "IdSubLineaProducto", true);
                 cboSubLineaProducto.EditValue = IdSubLineaProducto;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ModeloProductoBL objBL_ModeloProducto = new ModeloProductoBL();
                    ModeloProductoBE objModeloProducto = new ModeloProductoBE();

                    objModeloProducto.IdModeloProducto = IdModeloProducto;
                    objModeloProducto.IdLineaProducto = Convert.ToInt32(cboLineaProducto.EditValue);
                    objModeloProducto.IdSubLineaProducto = Convert.ToInt32(cboSubLineaProducto.EditValue);
                    objModeloProducto.DescModeloProducto = txtDescripcion.Text;
                    objModeloProducto.FlagEstado = true;
                    objModeloProducto.Usuario = Parametros.strUsuarioLogin;
                    objModeloProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objModeloProducto.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_ModeloProducto.Inserta(objModeloProducto);
                    else
                        objBL_ModeloProducto.Actualiza(objModeloProducto);

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

            if (cboLineaProducto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione Linea de producto.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstModeloProducto.Where(oB => oB.DescLineaProducto == txtDescripcion.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El modelo del producto ya existe.\n";
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