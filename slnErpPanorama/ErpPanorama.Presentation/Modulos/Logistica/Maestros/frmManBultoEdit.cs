﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Principal;
using System.Reflection;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManBultoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<BultoBE> mLista = new List<BultoBE>();

        int _IdBulto = 0;

        public int IdBulto
        {
            get { return _IdBulto; }
            set { _IdBulto = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        private int IdProducto = 0;
        private decimal PrecioUnitario = 0;
        private decimal CostoUnitario = 0;
        private int IdFacturaCompra = 0;
        private int IdTipoDocumento = 0;
        private string NumeroDocumento = "";
        public int SituacionBulto = 0;
        public int CantidadAnt = 0;

        #endregion

        #region "Eventos"

        public frmManBultoEdit()
        {
            InitializeComponent();
        }

        private void frmManBultoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescAlmacen", "IdAlmacen", true);
            cboAlmacen.EditValue = Parametros.intAlmBultos;

            deFechaIngreso.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Bulto - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Bulto - Modificar";

                BultoBE objE_Bulto = new BultoBE();

                objE_Bulto = new BultoBL().Selecciona(Parametros.intEmpresaId, IdBulto, SituacionBulto);

                IdProducto = objE_Bulto.IdProducto;
                txtCodigoProveedor.Text = objE_Bulto.CodigoProveedor;
                txtNombreProducto.Text = objE_Bulto.NombreProducto;
                cboAlmacen.EditValue = objE_Bulto.IdAlmacen;
                cboSector.EditValue = objE_Bulto.IdSector;
                PrecioUnitario = objE_Bulto.PrecioUnitario;
                txtCantidad.EditValue = objE_Bulto.Cantidad;
                CantidadAnt = objE_Bulto.Cantidad;
                CostoUnitario = objE_Bulto.CostoUnitario;
                txtNumeroBulto.Text = objE_Bulto.NumeroBulto;
                txtAgrupacion.Text = objE_Bulto.Agrupacion;
                IdFacturaCompra = objE_Bulto.IdFacturaCompra;
                IdTipoDocumento = objE_Bulto.IdTipoDocumento;
                NumeroDocumento = objE_Bulto.NumeroDocumento;
                txtObservacion.Text = objE_Bulto.Observacion;
            }

            cboSector.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {

                    BultoBL objBL_Bulto = new BultoBL();

                    BultoBE objE_Bulto = new BultoBE();
                    objE_Bulto.IdBulto = IdBulto;
                    objE_Bulto.IdEmpresa = Parametros.intEmpresaId;
                    objE_Bulto.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                    objE_Bulto.IdSector = Convert.ToInt32(cboSector.EditValue);
                    objE_Bulto.IdBloque = Convert.ToInt32(cboBloque.EditValue);
                    objE_Bulto.IdProducto = IdProducto;
                    objE_Bulto.NumeroBulto = txtNumeroBulto.Text;
                    objE_Bulto.Agrupacion = txtAgrupacion.Text;
                    objE_Bulto.IdFacturaCompra = IdFacturaCompra;
                    objE_Bulto.PrecioUnitario = PrecioUnitario;
                    objE_Bulto.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                    objE_Bulto.CostoUnitario = CostoUnitario;
                    objE_Bulto.FechaIngreso = Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString());
                    objE_Bulto.IdSituacion = Parametros.intBULRecibido;
                    objE_Bulto.Periodo = deFechaIngreso.DateTime.Year;
                    objE_Bulto.IdTipoDocumento = IdTipoDocumento;
                    objE_Bulto.NumeroDocumento = NumeroDocumento;
                    objE_Bulto.Observacion = txtObservacion.Text;
                    objE_Bulto.IdKardex = null;
                    objE_Bulto.FlagEstado = true;
                    objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Bulto.Usuario = Parametros.strUsuarioLogin;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Bulto.Inserta(objE_Bulto);
                    else
                        objBL_Bulto.ActualizaFactura(objE_Bulto);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAlmacen_EditValueChanged(object sender, EventArgs e)
        {
            if (cboAlmacen.EditValue != null)
            {
                BSUtils.LoaderLook(cboSector, new SectorBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId,Convert.ToInt32(cboAlmacen.EditValue)), "DescSector", "IdSector", true);
            }
        }

        private void cboSector_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSector.EditValue != null)
            {
                BSUtils.LoaderLook(cboBloque, new BloqueBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId,Convert.ToInt32(cboAlmacen.EditValue), Convert.ToInt32(cboSector.EditValue)), "DescBloque", "IdBloque", true);
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

            if (Convert.ToInt32(cboSector.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Seleccione el Sector.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboBloque.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Seleccione el Bloque.\n";
                flag = true;
            }

            if (txtNumeroBulto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Número de Bulto.\n";
                flag = true;
            }

            BultoBE objE_Bulto = null;
            objE_Bulto = new BultoBL().ValidaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intAlmBultos, Convert.ToInt32(cboSector.EditValue), txtNumeroBulto.Text);

            if (objE_Bulto != null)
            {
                strMensaje = strMensaje + "- El número de bulto ya existe, por favor verifique.\n";
                flag = true;
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