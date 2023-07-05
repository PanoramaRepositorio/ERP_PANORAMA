using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManPromocionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CPromocionDetalle> mListaPromocionDetalleOrigen = new List<CPromocionDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdPromocion = 0;

        public int IdPromocion
        {
            get { return _IdPromocion; }
            set { _IdPromocion = value; }
        }

        public PromocionBE pPromocionBE { get; set; }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmManPromocionEdit()
        {
            InitializeComponent();
        }

        private void frmManPromocionEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Promocion - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Promocion - Modificar";

                IdPromocion = pPromocionBE.IdPromocion;
                cboFormaPago.EditValue = pPromocionBE.IdFormaPago;
                cboTipoCliente.EditValue = pPromocionBE.IdTipoCliente;
                txtMontoMin.EditValue = pPromocionBE.MontoMin;
                txtMontoMax.EditValue = pPromocionBE.MontoMax;

            }

            CargaPromocionDetalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtMontoMin.Text.Trim() == "")
                //{
                //    XtraMessageBox.Show("Ingresar el nombre de Promocion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaPromocionDetalleOrigen.Count == 0)
                        {
                            gvPromocionDetalle.AddNewRow();
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "IdPromocion", movDetalle.oBE.IdPromocion);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "IdPromocionDetalle", movDetalle.oBE.IdPromocionDetalle);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocionDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaPromocionDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaPromocionDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPromocionDetalle.AddNewRow();
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "IdPromocion", movDetalle.oBE.IdPromocion);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "IdPromocionDetalle", movDetalle.oBE.IdPromocionDetalle);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocionDetalle.SetRowCellValue(gvPromocionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocionDetalle.UpdateCurrentRow();

                            CalculaTotales();

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaPromocionDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                movDetalle.IdPromocion = Convert.ToInt32(gvPromocionDetalle.GetFocusedRowCellValue("IdPromocion"));
                movDetalle.IdPromocionDetalle = Convert.ToInt32(gvPromocionDetalle.GetFocusedRowCellValue("IdPromocionDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvPromocionDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvPromocionDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvPromocionDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvPromocionDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvPromocionDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvPromocionDetalle.GetFocusedRowCellValue("Precio"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPromocionDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvPromocionDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvPromocionDetalle.SetRowCellValue(xposition, "IdPromocion", movDetalle.oBE.IdPromocion);
                        gvPromocionDetalle.SetRowCellValue(xposition, "IdPromocionDetalle", movDetalle.oBE.IdPromocionDetalle);
                        gvPromocionDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvPromocionDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvPromocionDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvPromocionDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvPromocionDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvPromocionDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvPromocionDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvPromocionDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPromocionDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvPromocionDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPromocionDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvPromocionDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdPromocionDetalle = 0;
                        if (gvPromocionDetalle.GetFocusedRowCellValue("IdPromocionDetalle") != null)
                            IdPromocionDetalle = int.Parse(gvPromocionDetalle.GetFocusedRowCellValue("IdPromocionDetalle").ToString());
                        int Item = 0;
                        if (gvPromocionDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvPromocionDetalle.GetFocusedRowCellValue("Item").ToString());
                        PromocionDetalleBE objBE_PromocionDetalle = new PromocionDetalleBE();
                        objBE_PromocionDetalle.IdPromocionDetalle = IdPromocionDetalle;
                        objBE_PromocionDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_PromocionDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_PromocionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        PromocionDetalleBL objBL_PromocionDetalle = new PromocionDetalleBL();
                        objBL_PromocionDetalle.Elimina(objBE_PromocionDetalle);
                        gvPromocionDetalle.DeleteRow(gvPromocionDetalle.FocusedRowHandle);
                        gvPromocionDetalle.RefreshData();

                    }
                    else
                    {
                        gvPromocionDetalle.DeleteRow(gvPromocionDetalle.FocusedRowHandle);
                        gvPromocionDetalle.RefreshData();
                    }

                    CalculaTotales();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PromocionBL objBL_Promocion = new PromocionBL();
                    PromocionBE objPromocion = new PromocionBE();
                    objPromocion.IdPromocion = IdPromocion;
                    objPromocion.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPromocion.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objPromocion.MontoMin = Convert.ToDecimal(txtMontoMin.EditValue);
                    objPromocion.MontoMax = Convert.ToDecimal(txtMontoMax.EditValue);
                    objPromocion.FlagEstado = true;
                    objPromocion.Usuario = Parametros.strUsuarioLogin;
                    objPromocion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPromocion.IdEmpresa = Parametros.intEmpresaId;

                    //Promocion Detalle
                    List<PromocionDetalleBE> lstPromocionDetalle = new List<PromocionDetalleBE>();

                    foreach (var item in mListaPromocionDetalleOrigen)
                    {
                        PromocionDetalleBE objE_PromocionDetalle = new PromocionDetalleBE();
                        objE_PromocionDetalle.IdPromocion = item.IdPromocion;
                        objE_PromocionDetalle.IdPromocionDetalle = item.IdPromocionDetalle;
                        objE_PromocionDetalle.IdProducto = item.IdProducto;
                        objE_PromocionDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_PromocionDetalle.NombreProducto = item.NombreProducto;
                        objE_PromocionDetalle.Abreviatura = item.Abreviatura;
                        objE_PromocionDetalle.Cantidad = item.Cantidad;
                        objE_PromocionDetalle.Precio = item.Precio;
                        objE_PromocionDetalle.FlagEstado = true;
                        objE_PromocionDetalle.TipoOper = item.TipoOper;
                        lstPromocionDetalle.Add(objE_PromocionDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Promocion.Inserta(objPromocion, lstPromocionDetalle);
                    }
                    else
                    {
                        objBL_Promocion.Actualiza(objPromocion, lstPromocionDetalle);
                    }

                    Cursor = Cursors.Default;

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

        private void CalculaTotales()
        {
            try
            {

                decimal deValorVenta = 0;
                decimal deTotal = 0;

                if (mListaPromocionDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaPromocionDetalleOrigen)
                    {
                        deValorVenta = item.Precio;
                        deTotal = deTotal + deValorVenta;
                    }

                    txtTotal.EditValue = Math.Round(deTotal, 2);

                }
                else
                {
                    txtTotal.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaPromocionDetalle()
        {
            List<PromocionDetalleBE> lstTmpPromocionDetalle = null;
            lstTmpPromocionDetalle = new PromocionDetalleBL().ListaTodosActivo(IdPromocion);

            foreach (PromocionDetalleBE item in lstTmpPromocionDetalle)
            {
                CPromocionDetalle objE_PromocionDetalle = new CPromocionDetalle();
                objE_PromocionDetalle.IdPromocion = item.IdPromocion;
                objE_PromocionDetalle.IdPromocionDetalle = item.IdPromocionDetalle;
                objE_PromocionDetalle.IdProducto = item.IdProducto;
                objE_PromocionDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PromocionDetalle.NombreProducto = item.NombreProducto;
                objE_PromocionDetalle.Abreviatura = item.Abreviatura;
                objE_PromocionDetalle.Cantidad = item.Cantidad;
                objE_PromocionDetalle.Precio = item.Precio;
                objE_PromocionDetalle.TipoOper = item.TipoOper;
                mListaPromocionDetalleOrigen.Add(objE_PromocionDetalle);
            }

            bsListado.DataSource = mListaPromocionDetalleOrigen;
            gcPromocionDetalle.DataSource = bsListado;
            gcPromocionDetalle.RefreshDataSource();

            CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            //if (txtDescPromocion.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingresar la descripción del Promocion.\n";
            //    flag = true;
            //}

            if (mListaPromocionDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el Promocion, mientra no haya productos.\n";
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

        public class CPromocionDetalle
        {
            public Int32 IdPromocion { get; set; }
            public Int32 IdPromocionDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Precio { get; set; }
            public Int32 TipoOper { get; set; }

            public CPromocionDetalle()
            {

            }
        }


    }
}