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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManSectorEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<SectorBE> lstSector;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public SectorBE pSectorBE { get; set; }

        int _IdSector = 0;

        public int IdSector
        {
            get { return _IdSector; }
            set { _IdSector = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManSectorEdit()
        {
            InitializeComponent();
        }

        private void frmManSectorEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda,new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", false);
            cboTienda.EditValue = Parametros.intTiendaId;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Sector - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Sector - Modificar";
                cboTienda.EditValue = pSectorBE.IdTienda;
                cboAlmacen.EditValue = pSectorBE.IdAlmacen;
                txtDescripcion.Text = pSectorBE.DescSector;
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
                    SectorBL objBL_Sector = new SectorBL();
                    SectorBE objSector = new SectorBE();
                    objSector.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                    objSector.IdSector = IdSector;
                    objSector.DescSector = txtDescripcion.Text;
                    objSector.FlagEstado = true;
                    objSector.Usuario = Parametros.strUsuarioLogin;
                    objSector.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSector.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Sector.Inserta(objSector);
                    else
                        objBL_Sector.Actualiza(objSector);

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

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                cboAlmacen.EditValue = Parametros.intAlmBultos;
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboAlmacen.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un almacén.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstSector.Where(oB => oB.DescSector.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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