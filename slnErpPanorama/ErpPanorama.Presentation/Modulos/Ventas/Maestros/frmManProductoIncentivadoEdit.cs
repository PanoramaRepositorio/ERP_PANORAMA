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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManProductoIncentivadoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CProductoIncentivadoDetalle> mListaProductoIncentivadoDetalleOrigen = new List<CProductoIncentivadoDetalle>();
        public List<CProductoIncentivadoCargo> mListaProductoIncentivadoCargoOrigen = new List<CProductoIncentivadoCargo>();
        private List<PreventaDetalleBE> lst_ProductoIncentivadoDetalleMsg = new List<PreventaDetalleBE>();

        DataTable dt = new DataTable();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdProductoIncentivado = 0;

        public int IdProductoIncentivado
        {
            get { return _IdProductoIncentivado; }
            set { _IdProductoIncentivado = value; }
        }

        public ProductoIncentivadoBE pProductoIncentivadoBE { get; set; }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmManProductoIncentivadoEdit()
        {
            InitializeComponent();
        }

        private void frmManProductoIncentivadoEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Producto Incentivado - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Producto Incentivado - Modificar";

                IdProductoIncentivado = pProductoIncentivadoBE.IdProductoIncentivado;
                txtDescProductoIncentivado.Text = pProductoIncentivadoBE.DescProductoIncentivado;
                deDesde.EditValue = pProductoIncentivadoBE.FechaInicio;
                deHasta.EditValue = pProductoIncentivadoBE.FechaFin;

                if (Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                    btnGrabar.Enabled = true;
                }
                else
                {
                    btnGrabar.Enabled = false;
                }
            }
            CargaProductoIncentivadoCargo();
            CargaProductoIncentivadoDetalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescProductoIncentivado.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el nombre del ProductoIncentivado promocional.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaProductoIncentivadoDetalleOrigen.Count == 0)
                        {
                            gvProductoIncentivadoDetalle.AddNewRow();
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProductoIncentivado", movDetalle.oBE.IdPromocion);//IdProductoIncentivado);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProductoIncentivadoDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdProductoIncentivadoDetalle);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProductoIncentivadoDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaProductoIncentivadoDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaProductoIncentivadoDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvProductoIncentivadoDetalle.AddNewRow();
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProductoIncentivado", movDetalle.oBE.IdPromocion);//IdProductoIncentivado);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProductoIncentivadoDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdProductoIncentivadoDetalle);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProductoIncentivadoDetalle.UpdateCurrentRow();

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
            if (mListaProductoIncentivadoDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                movDetalle.IdPromocion = Convert.ToInt32(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProductoIncentivado"));
                movDetalle.IdPromocionDetalle = Convert.ToInt32(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProductoIncentivadoDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvProductoIncentivadoDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvProductoIncentivadoDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvProductoIncentivadoDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("Precio"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvProductoIncentivadoDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "IdProductoIncentivado", movDetalle.oBE.IdPromocion);
                        gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "IdProductoIncentivadoDetalle", movDetalle.oBE.IdPromocionDetalle);
                        gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        //gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "CantidadVenta", 0);
                        //gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvProductoIncentivadoDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvProductoIncentivadoDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaProductoIncentivadoDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdProductoIncentivadoDetalle = 0;
                        if (gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProductoIncentivadoDetalle") != null)
                            IdProductoIncentivadoDetalle = int.Parse(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProductoIncentivadoDetalle").ToString());
                        int Item = 0;
                        if (gvProductoIncentivadoDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("Item").ToString());
                        ProductoIncentivadoDetalleBE objBE_ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleBE();
                        objBE_ProductoIncentivadoDetalle.IdProductoIncentivadoDetalle = IdProductoIncentivadoDetalle;
                        objBE_ProductoIncentivadoDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_ProductoIncentivadoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_ProductoIncentivadoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        ProductoIncentivadoDetalleBL objBL_ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleBL();
                        objBL_ProductoIncentivadoDetalle.Elimina(objBE_ProductoIncentivadoDetalle);
                        gvProductoIncentivadoDetalle.DeleteRow(gvProductoIncentivadoDetalle.FocusedRowHandle);
                        gvProductoIncentivadoDetalle.RefreshData();

                    }
                    else
                    {
                        gvProductoIncentivadoDetalle.DeleteRow(gvProductoIncentivadoDetalle.FocusedRowHandle);
                        gvProductoIncentivadoDetalle.RefreshData();
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
                    ProductoIncentivadoBL objBL_ProductoIncentivado = new ProductoIncentivadoBL();
                    ProductoIncentivadoBE objProductoIncentivado = new ProductoIncentivadoBE();
                    objProductoIncentivado.IdProductoIncentivado = IdProductoIncentivado;
                    objProductoIncentivado.DescProductoIncentivado = txtDescProductoIncentivado.Text;
                    objProductoIncentivado.FechaInicio = Convert.ToDateTime(deDesde.DateTime);
                    objProductoIncentivado.FechaFin = Convert.ToDateTime(deHasta.DateTime);
                    //objProductoIncentivado.Total = Convert.ToDecimal(txtTotal.EditValue);
                    //objProductoIncentivado.Observacion = txtObservacion.Text.Trim();
                    objProductoIncentivado.FlagEstado = true;
                    objProductoIncentivado.Usuario = Parametros.strUsuarioLogin;
                    objProductoIncentivado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objProductoIncentivado.IdEmpresa = Parametros.intEmpresaId;

                    //Cargo
                    List<ProductoIncentivadoCargoBE> lstProductoIncentivadoCargo = new List<ProductoIncentivadoCargoBE>();
                    foreach (var item in mListaProductoIncentivadoCargoOrigen)
                    {
                        ProductoIncentivadoCargoBE objE_ProductoIncentivadoCargo = new ProductoIncentivadoCargoBE();
                        objE_ProductoIncentivadoCargo.IdProductoIncentivadoCargo = item.IdProductoIncentivadoCargo;
                        objE_ProductoIncentivadoCargo.IdProductoIncentivado = item.IdProductoIncentivado;
                        objE_ProductoIncentivadoCargo.IdCargo = item.IdCargo;
                        objE_ProductoIncentivadoCargo.FlagEstado = true;
                        objE_ProductoIncentivadoCargo.TipoOper = item.TipoOper;
                        objE_ProductoIncentivadoCargo.Usuario = Parametros.strUsuarioLogin;
                        objE_ProductoIncentivadoCargo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstProductoIncentivadoCargo.Add(objE_ProductoIncentivadoCargo);
                    }

                    //ProductoIncentivado Detalle
                    List<ProductoIncentivadoDetalleBE> lstProductoIncentivadoDetalle = new List<ProductoIncentivadoDetalleBE>();

                    foreach (var item in mListaProductoIncentivadoDetalleOrigen)
                    {
                        ProductoIncentivadoDetalleBE objE_ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleBE();
                        objE_ProductoIncentivadoDetalle.IdProductoIncentivado = item.IdProductoIncentivado;
                        objE_ProductoIncentivadoDetalle.IdProductoIncentivadoDetalle = item.IdProductoIncentivadoDetalle;
                        objE_ProductoIncentivadoDetalle.IdProducto = item.IdProducto;
                        //objE_ProductoIncentivadoDetalle.CodigoProveedor = item.CodigoProveedor;
                        //objE_ProductoIncentivadoDetalle.NombreProducto = item.NombreProducto;
                        //objE_ProductoIncentivadoDetalle.Abreviatura = item.Abreviatura;
                        //objE_ProductoIncentivadoDetalle.Cantidad = item.Cantidad;
                        objE_ProductoIncentivadoDetalle.Incentivo = item.Incentivo;
                        objE_ProductoIncentivadoDetalle.FlagEstado = true;
                        objE_ProductoIncentivadoDetalle.TipoOper = item.TipoOper;
                        objE_ProductoIncentivadoDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_ProductoIncentivadoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstProductoIncentivadoDetalle.Add(objE_ProductoIncentivadoDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_ProductoIncentivado.Inserta(objProductoIncentivado, lstProductoIncentivadoDetalle, lstProductoIncentivadoCargo);
                    }
                    else
                    {
                        objBL_ProductoIncentivado.Actualiza(objProductoIncentivado, lstProductoIncentivadoDetalle, lstProductoIncentivadoCargo);
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


        private void nuevoCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscaTablaElemento objTablaElemento = new frmBuscaTablaElemento();
            objTablaElemento.IdTabla = Parametros.intTblCargos;
            objTablaElemento.ShowDialog();
            if (objTablaElemento.pTablaElementoBE != null)
            {
                //int index = gvProductoIncentivadoCargo.FocusedRowHandle;

                //gvProductoIncentivadoCargo.SetRowCellValue(index, "IdCargo", objTablaElemento.pTablaElementoBE.IdTablaElemento);
                //gvProductoIncentivadoCargo.SetRowCellValue(index, "DescCargo", objTablaElemento.pTablaElementoBE.DescTablaElemento);
                //gvProductoIncentivadoCargo.UpdateCurrentRow();


                if (mListaProductoIncentivadoCargoOrigen.Count == 0)
                {
                    gvProductoIncentivadoCargo.AddNewRow();
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "IdProductoIncentivadoCargo", 0);
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "IdProductoIncentivado", IdProductoIncentivado);
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "IdCargo", objTablaElemento.pTablaElementoBE.IdTablaElemento);
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "DescCargo", objTablaElemento.pTablaElementoBE.DescTablaElemento);
                    //gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "Precio", objTablaElemento.pTablaElementoBE.Precio);
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    gvProductoIncentivadoCargo.UpdateCurrentRow();

                    CalculaTotales();

                    return;

                }
                if (mListaProductoIncentivadoCargoOrigen.Count > 0)
                {
                    var Buscar = mListaProductoIncentivadoCargoOrigen.Where(oB => oB.IdCargo == objTablaElemento.pTablaElementoBE.IdTablaElemento).ToList();
                    if (Buscar.Count > 0)
                    {
                        XtraMessageBox.Show("El Cargo ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    gvProductoIncentivadoCargo.AddNewRow();
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "IdProductoIncentivadoCargo", 0);
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "IdProductoIncentivado", IdProductoIncentivado);
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "IdCargo", objTablaElemento.pTablaElementoBE.IdTablaElemento);
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "DescCargo", objTablaElemento.pTablaElementoBE.DescTablaElemento);
                    gvProductoIncentivadoCargo.SetRowCellValue(gvProductoIncentivadoCargo.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    gvProductoIncentivadoCargo.UpdateCurrentRow();

                    CalculaTotales();

                }
            }
        }

        private void eliminarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdProductoIncentivadoCargo = 0;
                IdProductoIncentivadoCargo = int.Parse(gvProductoIncentivadoCargo.GetFocusedRowCellValue("IdProductoIncentivadoCargo").ToString());
                ProductoIncentivadoCargoBE objBE_ProductoIncentivadoCargo = new ProductoIncentivadoCargoBE();
                objBE_ProductoIncentivadoCargo.IdProductoIncentivadoCargo = IdProductoIncentivadoCargo;
                objBE_ProductoIncentivadoCargo.IdEmpresa = Parametros.intEmpresaId;
                objBE_ProductoIncentivadoCargo.Usuario = Parametros.strUsuarioLogin;
                objBE_ProductoIncentivadoCargo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ProductoIncentivadoCargoBL objBL_ProductoIncentivadoCargo = new ProductoIncentivadoCargoBL();
                objBL_ProductoIncentivadoCargo.Elimina(objBE_ProductoIncentivadoCargo);
                gvProductoIncentivadoCargo.DeleteRow(gvProductoIncentivadoCargo.FocusedRowHandle);
                gvProductoIncentivadoCargo.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void CalculaTotales()
        {
            //try
            //{

            //    //decimal deValorVenta = 0;
            //    //decimal deTotal = 0;

            //    decimal CantidadTotal = 0;
            //    decimal CantidadVentaTotal = 0;

            //    if (mListaProductoIncentivadoDetalleOrigen.Count > 0)
            //    {
            //        foreach (var item in mListaProductoIncentivadoDetalleOrigen)
            //        {
            //            //deValorVenta = item.Precio;
            //            //deTotal = deTotal + deValorVenta;

            //            CantidadTotal = CantidadTotal + item.Cantidad;
            //            CantidadVentaTotal += item.CantidadVenta;

            //        }

            //        //txtTotalVenta.EditValue = Math.Round(deTotal, 2);
            //        txtTotalCantidad.EditValue = Math.Round(CantidadTotal, 2);
            //        txtTotalVenta.EditValue = Math.Round(CantidadVentaTotal, 2);

            //    }
            //    else
            //    {
            //        txtTotalCantidad.EditValue = 0;
            //        txtTotalVenta.EditValue = 0;
            //    }

            //    lblTotalRegistros.Text = mListaProductoIncentivadoDetalleOrigen.Count.ToString() + " Registros encontrados";

            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargaProductoIncentivadoDetalle()
        {
            List<ProductoIncentivadoDetalleBE> lstTmpProductoIncentivadoDetalle = null;
            lstTmpProductoIncentivadoDetalle = new ProductoIncentivadoDetalleBL().ListaTodosActivo(IdProductoIncentivado);

            foreach (ProductoIncentivadoDetalleBE item in lstTmpProductoIncentivadoDetalle)
            {
                CProductoIncentivadoDetalle objE_ProductoIncentivadoDetalle = new CProductoIncentivadoDetalle();
                objE_ProductoIncentivadoDetalle.IdProductoIncentivado = item.IdProductoIncentivado;
                objE_ProductoIncentivadoDetalle.IdProductoIncentivadoDetalle = item.IdProductoIncentivadoDetalle;
                objE_ProductoIncentivadoDetalle.IdProducto = item.IdProducto;
                objE_ProductoIncentivadoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_ProductoIncentivadoDetalle.NombreProducto = item.NombreProducto;
                objE_ProductoIncentivadoDetalle.Abreviatura = item.Abreviatura;
                objE_ProductoIncentivadoDetalle.Precio = item.Precio;
                objE_ProductoIncentivadoDetalle.Descuento = item.Descuento;
                objE_ProductoIncentivadoDetalle.Costo = item.Costo;
                objE_ProductoIncentivadoDetalle.Incentivo = item.Incentivo;
                objE_ProductoIncentivadoDetalle.Fecha = item.Fecha;
                //objE_ProductoIncentivadoDetalle.Usuario = item.Usuario;
                //objE_ProductoIncentivadoDetalle.Maquina = item.Maquina;
                //objE_ProductoIncentivadoDetalle.FechaRegistro = item.FechaRegistro;
                //objE_ProductoIncentivadoDetalle.Diferencia = item.Cantidad - item.CantidadVenta;
                
                objE_ProductoIncentivadoDetalle.TipoOper = item.TipoOper;
                mListaProductoIncentivadoDetalleOrigen.Add(objE_ProductoIncentivadoDetalle);
            }

            bsListado.DataSource = mListaProductoIncentivadoDetalleOrigen;
            gcProductoIncentivadoDetalle.DataSource = bsListado;
            gcProductoIncentivadoDetalle.RefreshDataSource();

            lblTotalRegistros.Text = mListaProductoIncentivadoDetalleOrigen.Count.ToString() + " Registros encontrados";

            //CalculaTotales();
        }

        private void CargaProductoIncentivadoCargo()
        {
            List<ProductoIncentivadoCargoBE> lstTmpProductoIncentivadoCargo = null;
            lstTmpProductoIncentivadoCargo = new ProductoIncentivadoCargoBL().ListaTodosActivo(IdProductoIncentivado);

            foreach (ProductoIncentivadoCargoBE item in lstTmpProductoIncentivadoCargo)
            {
                CProductoIncentivadoCargo objE_ProductoIncentivadoCargo = new CProductoIncentivadoCargo();
                //objE_ProductoIncentivadoCargo.IdEmpresa = item.IdEmpresa;
                objE_ProductoIncentivadoCargo.IdProductoIncentivadoCargo = item.IdProductoIncentivadoCargo;
                objE_ProductoIncentivadoCargo.IdProductoIncentivado = item.IdProductoIncentivado;
                objE_ProductoIncentivadoCargo.IdCargo = item.IdCargo;
                objE_ProductoIncentivadoCargo.DescCargo = item.DescCargo;
                objE_ProductoIncentivadoCargo.TipoOper = item.TipoOper;
                mListaProductoIncentivadoCargoOrigen.Add(objE_ProductoIncentivadoCargo);
            }

            bsListadoProductoIncentivadoCargo.DataSource = mListaProductoIncentivadoCargoOrigen;
            gcProductoIncentivadoCargo.DataSource = bsListadoProductoIncentivadoCargo;
            gcProductoIncentivadoCargo.RefreshDataSource();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescProductoIncentivado.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la descripción del ProductoIncentivado.\n";
                flag = true;
            }

            if (deDesde.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la Fecha Inicio.\n";
                flag = true;
            }

            if (deHasta.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la Fecha Fin.\n";
                flag = true;
            }

            if (mListaProductoIncentivadoDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el ProductoIncentivado, mientra no haya productos.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void ImportarExcel(string filename)
        {
            if (filename.Trim() == "")
                return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            int Row = 2;
            int TotRow = 2;

            try
            {
                //Contador de Registros
                while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;


                //Recorremos los códigos de ProductoIncentivado
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    string incentivoExcel = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                    decimal Incentivo = 0;
                    if (incentivoExcel.Length > 0)
                    {
                        Incentivo = Convert.ToDecimal(incentivoExcel);
                    }
                    //int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedorInventario(CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaProductoIncentivadoDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvProductoIncentivadoDetalle.AddNewRow();
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProductoIncentivadoDetalle", 0);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Precio", objE_Producto.PrecioCD);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Descuento", objE_Producto.Descuento);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Incentivo", Incentivo);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Fecha", objE_Producto.Fecha);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                        }



                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_ProductoIncentivadoDetalle = new PreventaDetalleBE();
                        ObjE_ProductoIncentivadoDetalle.CodigoProveedor = CodigoProveedor;
                        //ObjE_ProductoIncentivadoDetalle.Cantidad = Cantidad;
                        lst_ProductoIncentivadoDetalleMsg.Add(ObjE_ProductoIncentivadoDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvProductoIncentivadoDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_ProductoIncentivadoDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_ProductoIncentivadoDetalleMsg;
                    frm.ShowDialog();
                }

                //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                //this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportarExcelHangTag(string filename)
        {
            if (filename.Trim() == "")
                return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            int Row = 2;
            int TotRow = 2;

            try
            {
                //Contador de Registros
                while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;


                //Recorremos los códigos de ProductoIncentivado
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    //string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int IdProducto = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    string incentivoExcel = (string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim();
                    decimal Incentivo = 0;
                    if (incentivoExcel.Length > 0)
                    {
                        Incentivo = Convert.ToDecimal(incentivoExcel);
                    }

                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaProductoIncentivadoDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvProductoIncentivadoDetalle.AddNewRow();
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProductoIncentivadoDetalle", 0);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Precio", objE_Producto.PrecioCD);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Incentivo", Incentivo);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvProductoIncentivadoDetalle.SetRowCellValue(gvProductoIncentivadoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                        }

                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_ProductoIncentivadoDetalle = new PreventaDetalleBE();
                        ObjE_ProductoIncentivadoDetalle.CodigoProveedor = IdProducto.ToString();
                        //ObjE_ProductoIncentivadoDetalle.Cantidad = Cantidad;
                        lst_ProductoIncentivadoDetalleMsg.Add(ObjE_ProductoIncentivadoDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvProductoIncentivadoDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_ProductoIncentivadoDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_ProductoIncentivadoDetalleMsg;
                    frm.ShowDialog();
                }

                //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                //this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarIdProducto()
        {

            //dt = FuncionBase.ToDataTable(mListaProductoIncentivadoDetalleOrigen);//new ProductoIncentivadoDetalleBL().ListaTodosActivo(IdProductoIncentivado));
            //gcProductoIncentivadoDetalle.DataSource = dt;

            //if (gvProductoIncentivadoDetalle.RowCount > 0)
            //{
            //    ProductoBE objE_Producto = null;
            //    int IdProducto = 0;
            //    IdProducto = int.Parse(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProducto").ToString());

            //    objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

            //    if (objE_Producto.Imagen != null)
            //    {
            //        this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
            //    }
            //    else
            //    { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }

            //    //txtProducto.SelectAll();
            //    //txtProducto.Focus();
            //}
        }

        #endregion

        public class CProductoIncentivadoDetalle
        {
            public Int32 IdProductoIncentivado { get; set; }
            public Int32 IdProductoIncentivadoDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Decimal Precio { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal Costo { get; set; }
            public Decimal Incentivo { get; set; }
            public DateTime Fecha { get; set; }
            //public DateTime FechaRegistro { get; set; }
            //public String Usuario { get; set; }
            //public String Maquina { get; set; }
            //public Int32 Cantidad { get; set; }
            //public Int32 CantidadVenta { get; set; }
            //public Int32 Diferencia { get; set; }
            
            public Int32 TipoOper { get; set; }

            public CProductoIncentivadoDetalle()
            {

            }
        }

        public class CProductoIncentivadoCargo
        {
            public Int32 IdProductoIncentivadoCargo { get; set; }
            public Int32 IdProductoIncentivado { get; set; }
            public Int32 IdCargo { get; set; }
            public String DescCargo { get; set; }
            public String FlagEstado { get; set; }
            public Int32 TipoOper { get; set; }

            public CProductoIncentivadoCargo()
            {

            }
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoProductoIncentivadoDetalle";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProductoIncentivadoDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void importarporcodigotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
                //Cargar();
            }
        }

        private void importarporhangtagtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcelHangTag(_file_excel);
                //Cargar();
            }
        }

        private void gvProductoIncentivadoDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvProductoIncentivadoDetalle.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvProductoIncentivadoDetalle.GetDataRow(e.FocusedRowHandle);
                int IdProducto = 0;
                IdProducto = int.Parse(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProducto").ToString());

                //IdProducto = int.Parse(dr["IdProducto"].ToString());

                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

                if (objE_Producto.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
            }
        }

        private void gvProductoIncentivadoDetalle_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvProductoIncentivadoDetalle.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvProductoIncentivadoDetalle.GetDataRow(e.RowHandle);
                int IdProducto = 0;

                IdProducto = int.Parse(gvProductoIncentivadoDetalle.GetFocusedRowCellValue("IdProducto").ToString());
                //IdProducto = int.Parse(dr["IdProducto"].ToString());


                ProductoBE objE_Producto = null;
                objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

                if (objE_Producto.Imagen != null)
                {
                    this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
                }
                else
                { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
            }
        }




    }
}