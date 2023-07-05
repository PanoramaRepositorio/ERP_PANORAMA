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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManRutaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<RutaBE> lstRuta;
        private List<RutaDetalleBE> mLista = new List<RutaDetalleBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdRuta = 0;

        public int IdRuta
        {
            get { return _IdRuta; }
            set { _IdRuta = value; }
        }

        #endregion

        #region "Eventos"

        public frmManRutaEdit()
        {
            InitializeComponent();
        }

        private void frmManRutaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboTipoRuta, CargarTipoRuta(), "Descripcion", "Id", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Ruta - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Ruta - Modificar";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                RutaBE objE_Ruta = new RutaBE();

                objE_Ruta = new RutaBL().Selecciona(Parametros.intEmpresaId, IdRuta);

                txtDescripcion.Text = objE_Ruta.DescRuta;
                cboVendedor.EditValue = objE_Ruta.IdVendedor;
                cboTipoRuta.EditValue = objE_Ruta.Tipo;
                CargarRutaDetalle();
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
                    RutaBL objBL_Ruta = new RutaBL();
                    RutaBE objE_Ruta = new RutaBE();

                    objE_Ruta.IdRuta = IdRuta;
                    objE_Ruta.DescRuta = txtDescripcion.Text;
                    objE_Ruta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objE_Ruta.Tipo = cboTipoRuta.EditValue.ToString();
                    objE_Ruta.FlagEstado = true;
                    objE_Ruta.Usuario = Parametros.strUsuarioLogin;
                    objE_Ruta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Ruta.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Ruta.Inserta(objE_Ruta);
                        XtraMessageBox.Show("Datos grabados correctamente, se actualizó las rutas y vendedores en los clientes que corresponden a la Zona.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objBL_Ruta.Actualiza(objE_Ruta);
                        XtraMessageBox.Show("Datos Actualizados correctamente, se actualizó las rutas y vendedores en los clientes que corresponden al Zona.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                        

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
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstRuta.Where(oB => oB.DescRuta.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManRutaDetalleEdit objManRuta = new frmManRutaDetalleEdit();
                objManRuta.pOperacion = frmManRutaDetalleEdit.Operacion.Nuevo;
                objManRuta.IdUbigeo = "";
                objManRuta.IdRuta = IdRuta;
                objManRuta.IdRutaDetalle = 0;
                objManRuta.StartPosition = FormStartPosition.CenterParent;
                objManRuta.ShowDialog();
                CargarRutaDetalle();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        RutaDetalleBE objE_RutaDetalle = new RutaDetalleBE();
                        objE_RutaDetalle.IdRutaDetalle = int.Parse(gvRutaDetalle.GetFocusedRowCellValue("IdRutaDetalle").ToString());

                        RutaDetalleBL objBL_RutaDetalle = new RutaDetalleBL();
                        objBL_RutaDetalle.Elimina(objE_RutaDetalle);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRutaDetalle();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void CargarRutaDetalle()
        {
            mLista = new RutaDetalleBL().ListaTodosActivo(IdRuta);
            gcRutaDetalle.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvRutaDetalle.RowCount > 0)
            {
                RutaDetalleBE objRutaDetalle = new RutaDetalleBE();
                objRutaDetalle.IdUbigeo = gvRutaDetalle.GetFocusedRowCellValue("IdUbigeo").ToString();
                objRutaDetalle.IdRuta = int.Parse(gvRutaDetalle.GetFocusedRowCellValue("IdRuta").ToString());
                objRutaDetalle.IdRutaDetalle = int.Parse(gvRutaDetalle.GetFocusedRowCellValue("IdRutaDetalle").ToString());

                frmManRutaDetalleEdit objManRutaDetalleEdit = new frmManRutaDetalleEdit();
                objManRutaDetalleEdit.pOperacion = frmManRutaDetalleEdit.Operacion.Modificar;
                objManRutaDetalleEdit.IdUbigeo = objRutaDetalle.IdUbigeo;
                objManRutaDetalleEdit.IdRuta = objRutaDetalle.IdRuta;
                objManRutaDetalleEdit.IdRutaDetalle = objRutaDetalle.IdRutaDetalle;

                objManRutaDetalleEdit.StartPosition = FormStartPosition.CenterParent;
                objManRutaDetalleEdit.ShowDialog();
                CargarRutaDetalle();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private DataTable CargarTipoRuta()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 'R';
            dr["Descripcion"] = "RUTA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 'O';
            dr["Descripcion"] = "OFICINA";
            dt.Rows.Add(dr);
            return dt;
        }


    }
}