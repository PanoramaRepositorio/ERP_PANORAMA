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
    public partial class frmManActualizaDescuentoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProductoBE> mListaProducto = new List<ProductoBE>();


        int _IdListaPrecio = 0;

        public int IdListaPrecio
        {
            get { return _IdListaPrecio; }
            set { _IdListaPrecio = value; }
        }

        public string DescListaPrecio = "";
        
        #endregion

        #region "Eventos"

        public frmManActualizaDescuentoEdit()
        {
            InitializeComponent();
        }

        private void frmManActualizaDescuentoEdit_Load(object sender, EventArgs e)
        {
            txtDescripcion.Text = DescListaPrecio;
            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            BSUtils.LoaderLook(cboMarca, new MarcaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMarca", "IdMarca", true);

            chkLinea.Checked = true;

            cboLinea.Focus();
            
        }

        private void cboLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboSubLinea, new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString())), "DescSubLineaProducto", "IdSubLineaProducto", true);
            }
        }

        private void cboSubLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSubLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboModelo, new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString()), Convert.ToInt32(cboSubLinea.EditValue.ToString())), "DescModeloProducto", "IdModeloProducto", true);
            }
        }
        

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (chkLinea.Checked)
            {
                mListaProducto = new ProductoBL().ListaLinea(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue));
            }

            if (chkLinea.Checked && chkSubLinea.Checked)
            {
                mListaProducto = new ProductoBL().ListaSubLinea(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue), Convert.ToInt32(cboSubLinea.EditValue));
            }

            if (chkLinea.Checked && chkSubLinea.Checked && chkModelo.Checked)
            {
                mListaProducto = new ProductoBL().ListaModelo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue), Convert.ToInt32(cboSubLinea.EditValue), Convert.ToInt32(cboModelo.EditValue));
            }

            if (chkMarca.Checked)
            {
                mListaProducto = new ProductoBL().ListaMarca(Parametros.intEmpresaId, Convert.ToInt32(cboMarca.EditValue));
            }

            if (chkPeriodo.Checked)
            {
                mListaProducto = new ProductoBL().ListaPeriodo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue));
            }

            int Row = 8;
            int TotRow = 8;

            try
            {
                TotRow = mListaProducto.Count;
                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;

                List<ListaPrecioDetalleBE> mListaPrecioDetalle = new List<ListaPrecioDetalleBE>();

                //Recorremos para el detalle del Producto Consultado
                foreach (var item in mListaProducto)
                {
                    ListaPrecioDetalleBE objE_ListaPrecioDetalle = new ListaPrecioDetalleBE();
                    objE_ListaPrecioDetalle.IdListaPrecio = IdListaPrecio;
                    objE_ListaPrecioDetalle.IdProducto = item.IdProducto;
                    objE_ListaPrecioDetalle.Descuento = 0;
                    objE_ListaPrecioDetalle.FlagEstado = true;

                    mListaPrecioDetalle.Add(objE_ListaPrecioDetalle);

                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                ListaPrecioDetalleBL objBL_ListaPrecioDetalle = new ListaPrecioDetalleBL();
                objBL_ListaPrecioDetalle.ActualizaMasivo(mListaPrecioDetalle,chkTodo.Checked);

                XtraMessageBox.Show("La aplicación del descuento se realizó correctamente \n" + mListaProducto.Count + " Registros Afectados. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        
        #region "Metodos"

        #endregion


        
    }
}