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
    public partial class frmManComboPromocionalEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CComboDetalle> mListaComboDetalleOrigen = new List<CComboDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdCombo = 0;

        public int IdCombo
        {
            get { return _IdCombo; }
            set { _IdCombo = value; }
        }

        public ComboBE pComboBE { get; set; }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmManComboPromocionalEdit()
        {
            InitializeComponent();
        }

        private void frmManComboPromocionalEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Combo Promocional - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Combo Promocional - Modificar";

                IdCombo = pComboBE.IdCombo;
                txtDescCombo.Text = pComboBE.DescCombo;
            }

            CargaComboDetalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescCombo.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el nombre del combo promocional.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmManComboPromocionalDetalleEdit movDetalle = new frmManComboPromocionalDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaComboDetalleOrigen.Count == 0)
                        {
                            gvComboDetalle.AddNewRow();
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "IdCombo", movDetalle.oBE.IdCombo);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "IdComboDetalle", movDetalle.oBE.IdComboDetalle);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvComboDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaComboDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaComboDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvComboDetalle.AddNewRow();
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "IdCombo", movDetalle.oBE.IdCombo);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "IdComboDetalle", movDetalle.oBE.IdComboDetalle);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvComboDetalle.SetRowCellValue(gvComboDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvComboDetalle.UpdateCurrentRow();

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
            if (mListaComboDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManComboPromocionalDetalleEdit movDetalle = new frmManComboPromocionalDetalleEdit();
                movDetalle.IdCombo = Convert.ToInt32(gvComboDetalle.GetFocusedRowCellValue("IdCombo"));
                movDetalle.IdComboDetalle = Convert.ToInt32(gvComboDetalle.GetFocusedRowCellValue("IdComboDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvComboDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvComboDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvComboDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvComboDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvComboDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvComboDetalle.GetFocusedRowCellValue("Precio"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvComboDetalle.GetFocusedRowCellValue("Descuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvComboDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvComboDetalle.GetFocusedRowCellValue("ValorVenta"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvComboDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvComboDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvComboDetalle.SetRowCellValue(xposition, "IdCombo", movDetalle.oBE.IdCombo);
                        gvComboDetalle.SetRowCellValue(xposition, "IdComboDetalle", movDetalle.oBE.IdComboDetalle);
                        gvComboDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvComboDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvComboDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvComboDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvComboDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvComboDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        gvComboDetalle.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
                        gvComboDetalle.SetRowCellValue(xposition, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                        gvComboDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvComboDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvComboDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvComboDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvComboDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaComboDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvComboDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdComboDetalle = 0;
                        if (gvComboDetalle.GetFocusedRowCellValue("IdComboDetalle") != null)
                            IdComboDetalle = int.Parse(gvComboDetalle.GetFocusedRowCellValue("IdComboDetalle").ToString());
                        int Item = 0;
                        if (gvComboDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvComboDetalle.GetFocusedRowCellValue("Item").ToString());
                        ComboDetalleBE objBE_ComboDetalle = new ComboDetalleBE();
                        objBE_ComboDetalle.IdComboDetalle = IdComboDetalle;
                        objBE_ComboDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_ComboDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_ComboDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        ComboDetalleBL objBL_ComboDetalle = new ComboDetalleBL();
                        objBL_ComboDetalle.Elimina(objBE_ComboDetalle);
                        gvComboDetalle.DeleteRow(gvComboDetalle.FocusedRowHandle);
                        gvComboDetalle.RefreshData();

                    }
                    else
                    {
                        gvComboDetalle.DeleteRow(gvComboDetalle.FocusedRowHandle);
                        gvComboDetalle.RefreshData();
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
                    ComboBL objBL_Combo = new ComboBL();
                    ComboBE objCombo = new ComboBE();
                    objCombo.IdCombo = IdCombo;
                    objCombo.DescCombo = txtDescCombo.Text;
                    objCombo.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objCombo.FlagEstado = true;
                    objCombo.Usuario = Parametros.strUsuarioLogin;
                    objCombo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCombo.IdEmpresa = Parametros.intEmpresaId;

                    //Combo Detalle
                    List<ComboDetalleBE> lstComboDetalle = new List<ComboDetalleBE>();

                    foreach (var item in mListaComboDetalleOrigen)
                    {
                        ComboDetalleBE objE_ComboDetalle = new ComboDetalleBE();
                        objE_ComboDetalle.IdCombo = item.IdCombo;
                        objE_ComboDetalle.IdComboDetalle = item.IdComboDetalle;
                        objE_ComboDetalle.IdProducto = item.IdProducto;
                        objE_ComboDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_ComboDetalle.NombreProducto = item.NombreProducto;
                        objE_ComboDetalle.Abreviatura = item.Abreviatura;
                        objE_ComboDetalle.Cantidad = item.Cantidad;
                        objE_ComboDetalle.Precio = item.Precio;
                        objE_ComboDetalle.Descuento = item.Descuento;
                        objE_ComboDetalle.PrecioVenta = item.PrecioVenta;
                        objE_ComboDetalle.ValorVenta = item.ValorVenta;
                        objE_ComboDetalle.FlagEstado = true;
                        objE_ComboDetalle.TipoOper = item.TipoOper;
                        lstComboDetalle.Add(objE_ComboDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Combo.Inserta(objCombo, lstComboDetalle);
                    }
                    else
                    {
                        objBL_Combo.Actualiza(objCombo, lstComboDetalle);
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
               
                if (mListaComboDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaComboDetalleOrigen)
                    {
                        deValorVenta = item.ValorVenta;
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

        private void CargaComboDetalle()
        {
            List<ComboDetalleBE> lstTmpComboDetalle = null;
            lstTmpComboDetalle = new ComboDetalleBL().ListaTodosActivo(IdCombo);

            foreach (ComboDetalleBE item in lstTmpComboDetalle)
            {
                CComboDetalle objE_ComboDetalle = new CComboDetalle();
                objE_ComboDetalle.IdCombo = item.IdCombo;
                objE_ComboDetalle.IdComboDetalle = item.IdComboDetalle;
                objE_ComboDetalle.IdProducto = item.IdProducto;
                objE_ComboDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_ComboDetalle.NombreProducto = item.NombreProducto;
                objE_ComboDetalle.Abreviatura = item.Abreviatura;
                objE_ComboDetalle.Cantidad = item.Cantidad;
                objE_ComboDetalle.Precio = item.Precio;
                objE_ComboDetalle.Descuento = item.Descuento;
                objE_ComboDetalle.PrecioVenta = item.PrecioVenta;
                objE_ComboDetalle.ValorVenta = item.ValorVenta;
                objE_ComboDetalle.TipoOper = item.TipoOper;
                mListaComboDetalleOrigen.Add(objE_ComboDetalle);
            }

            bsListado.DataSource = mListaComboDetalleOrigen;
            gcComboDetalle.DataSource = bsListado;
            gcComboDetalle.RefreshDataSource();

            CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescCombo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la descripción del combo.\n";
                flag = true;
            }

            if (mListaComboDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el combo, mientra no haya productos.\n";
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

        public class CComboDetalle
        {
            public Int32 IdCombo { get; set; }
            public Int32 IdComboDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Precio { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public Int32 TipoOper { get; set; }

            public CComboDetalle()
            {

            }
        }

        
    }
}