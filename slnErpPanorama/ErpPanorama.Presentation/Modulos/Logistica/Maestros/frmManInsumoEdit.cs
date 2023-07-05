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

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManInsumoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<InsumoBE> lstInsumo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdInsumo = 0;

        public int IdInsumo
        {
            get { return _IdInsumo; }
            set { _IdInsumo = value; }
        }

        #endregion

        #region "Eventos"

        public frmManInsumoEdit()
        {
            InitializeComponent();
        }

        private void frmManInsumoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboUnidadMedida, new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId), "Abreviatura", "IdUnidadMedida", true);
            BSUtils.LoaderLook(cboClasificacion, new InsumoClasificacionBL().ListaTodosActivo(Parametros.intEmpresaId), "DescInsumoClasificacion", "IdInsumoClasificacion", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Insumo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Insumo - Modificar";

                InsumoBE objE_Insumo = new InsumoBE();
                objE_Insumo = new InsumoBL().Selecciona(IdInsumo);
                txtIdInsumo.EditValue = objE_Insumo.IdInsumo;
                cboUnidadMedida.EditValue = objE_Insumo.IdUnidadMedida;
                txtDescripcion.Text = objE_Insumo.Descripcion;
                cboClasificacion.EditValue = objE_Insumo.IdInsumoClasificacion;
                txtObservaciones.Text = objE_Insumo.Observacion;
                txtCodigoBarra.Text = objE_Insumo.CodigoBarra;
                chkActivo.Checked = objE_Insumo.FlagEstado;

                if (objE_Insumo.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Insumo.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
            }

            txtIdInsumo.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    InsumoBL objBL_Insumo = new InsumoBL();
                    InsumoBE objE_Insumo = new InsumoBE();

                    objE_Insumo.IdInsumo = IdInsumo;
                    objE_Insumo.IdUnidadMedida = Convert.ToInt32(cboUnidadMedida.EditValue);
                    objE_Insumo.IdInsumoClasificacion = Convert.ToInt32(cboClasificacion.EditValue);
                    objE_Insumo.Descripcion = txtDescripcion.Text;
                    objE_Insumo.CodigoBarra = txtCodigoBarra.Text;
                    objE_Insumo.Imagen = new FuncionBase().Image2Bytes(this.picImage.Image);
                    objE_Insumo.Observacion = txtObservaciones.Text;
                    objE_Insumo.Fecha = Parametros.dtFechaHoraServidor;
                    objE_Insumo.FlagEstado = chkActivo.Checked;//true;
                    objE_Insumo.Usuario = Parametros.strUsuarioLogin;
                    objE_Insumo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Insumo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Insumo.Inserta(objE_Insumo);
                    }
                    else
                    {
                        objBL_Insumo.Actualiza(objE_Insumo);
                    }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Jpg File|*.Jpg|Jpeg File|*.Jpeg|Png File|*.Png |Gif File|*.Gif|All|*.*";
            openFile.ShowDialog();

            if (openFile.FileName.Length != 0)
            {
                FileInfo fi;
                Decimal mxKb = Parametros.dmlTamanioImagen;//Convert.ToDecimal(100);
                Decimal acKb;

                fi = new FileInfo(openFile.FileName);
                acKb = Convert.ToDecimal(fi.Length) / 1024;
                if (fi.Length > (mxKb * 1024))
                {
                    XtraMessageBox.Show(openFile.FileName + " Tamaño Máximo: " + mxKb.ToString() + " Kb. Tamaño Actual: " + acKb.ToString("###,##0.00") + " Kb.", "Importar Imagenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.picImage.Image = Image.FromFile(openFile.FileName);
                }
            }
        }

        #endregion

        #region "Metodos"
        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboUnidadMedida.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la Unidad de Medida.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Nombre del Insumo.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstInsumo.Where(oB => oB.Descripcion.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El código ya existe.\n";
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