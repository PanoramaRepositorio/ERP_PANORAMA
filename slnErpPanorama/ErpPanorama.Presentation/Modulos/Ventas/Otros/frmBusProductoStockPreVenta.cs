﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmBusProductoStockPreVenta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PreventaDetalleBE> mLista = new List<PreventaDetalleBE>();
        public List<PreventaDetalleBE> pListaProducto { get; set; }
        public PreventaDetalleBE pProductoBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }
        public int IdTienda { get; set; }
        public int IdAlmacen { get; set; }
        public string pDescripcion { get; set; }

        DataTable dt = new DataTable();

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;

        #endregion

        #region "Eventos"

        public frmBusProductoStockPreVenta()
        {
            InitializeComponent();
        }

        private void frmBusProductoStockPreVenta_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = IdTienda;
            intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            CalcularPaginas();
            CargarBusqueda(intPagina, intRegistrosPorPagina);
            HabilitarBotones(false, false, true, true);

            txtDescripcion.Text = pDescripcion;
            gcProducto.Focus();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                cboAlmacen.EditValue = IdAlmacen;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.ToString().Length > 2)
            {
                CargarBusqueda();
            }

        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gcProducto.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                gcProducto.Focus();
            }
        }

        private void gvProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvProducto_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr;
            dr = gvProducto.GetDataRow(e.FocusedRowHandle);
            int IdProducto = int.Parse(dr["IdProducto"].ToString());

            ProductoBE objE_Producto = null;
            objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

            if (objE_Producto.Imagen != null)
            {
                this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
            }
            else
            { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }

        }

        private void gvProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaPrimero;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            cboPagina.EditValue = intPagina;

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            intPagina = intPagina - 1;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPagina = intPagina + 1;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaUltima;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidadRegistros.Text.Length > 0)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            }
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            intPagina = int.Parse(cboPagina.EditValue.ToString());
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
            CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
        }

        #endregion

        #region "Metodos"

        private void CargarBusqueda(int pagina, int registros)
        {
            if (txtDescripcion.Text.ToString().Length > 2)
            {
                dt = FuncionBase.ToDataTable(new PreventaDetalleBL().ListaProductoPrecio(Convert.ToInt32(cboTienda.EditValue), txtDescripcion.Text, pagina, registros));
                gcProducto.DataSource = dt;
            }
        }

        private void CargarBusqueda()
        {
            if (txtDescripcion.Text.ToString().Length > 2)
            {
                dt = FuncionBase.ToDataTable(new PreventaDetalleBL().ListaProductoPrecio(Convert.ToInt32(cboTienda.EditValue), txtDescripcion.Text, intPaginaPrimero, intRegistrosPorPagina));
                gcProducto.DataSource = dt;
            }
            //gvProducto.MoveFirst();

            //if (dt.Rows.Count == 1)
            //{
            //    if (gvProducto.RowCount > 0)
            //    {
            //        int IdProducto = 0;
            //        IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
            //        ErpPanoramaServicios.ProductoBE objE_Producto = null;
            //        objE_Producto = objServicio.Producto_SeleccionaImagen(Parametros.intEmpresaId, IdProducto);

            //        if (objE_Producto.Imagen != null)
            //        {
            //            this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
            //        }
            //        else
            //        { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
            //    }
            //}

            CalcularPaginas();
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);

        }

        private void SeleccionarRegistro()
        {
            if (gvProducto.RowCount > 0)
            {
                PreventaDetalleBE objProducto = new PreventaDetalleBE();
                if (pFlagMultiSelect)
                {
                    List<PreventaDetalleBE> lista = new List<PreventaDetalleBE>();
                    foreach (int i in gvProducto.GetSelectedRows())
                    {
                        objProducto = (PreventaDetalleBE)gvProducto.GetRow(i);
                        lista.Add(objProducto);
                    }
                    pListaProducto = lista;
                }
                else
                {
                    DataRow dr;
                    dr = gvProducto.GetDataRow(gvProducto.FocusedRowHandle);

                    objProducto.IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
                    objProducto.DescFamiliaProducto = gvProducto.GetFocusedRowCellValue("DescFamiliaProducto").ToString();
                    objProducto.IdFamiliaProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdFamiliaProducto").ToString());
                    objProducto.IdLineaProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdLineaProducto").ToString());
                    objProducto.IdMarca = int.Parse(gvProducto.GetFocusedRowCellValue("IdMarca").ToString());
                    objProducto.CodigoProveedor = gvProducto.GetFocusedRowCellValue("CodigoProveedor").ToString();
                    objProducto.NombreProducto = gvProducto.GetFocusedRowCellValue("NombreProducto").ToString();
                    objProducto.Abreviatura = gvProducto.GetFocusedRowCellValue("Abreviatura").ToString();
                    objProducto.Cantidad = int.Parse(gvProducto.GetFocusedRowCellValue("Cantidad").ToString());
                    objProducto.PrecioAB = decimal.Parse(gvProducto.GetFocusedRowCellValue("PrecioAB").ToString());
                    objProducto.PrecioCD = decimal.Parse(gvProducto.GetFocusedRowCellValue("PrecioCD").ToString());
                    objProducto.PrecioABSoles = decimal.Parse(gvProducto.GetFocusedRowCellValue("PrecioABSoles").ToString());
                    objProducto.PrecioCDSoles = decimal.Parse(gvProducto.GetFocusedRowCellValue("PrecioCDSoles").ToString());
                    objProducto.Descuento = decimal.Parse(gvProducto.GetFocusedRowCellValue("Descuento").ToString());
                    objProducto.DescUbicacion = gvProducto.GetFocusedRowCellValue("DescUbicacion").ToString();
                    objProducto.FlagNacional = bool.Parse(gvProducto.GetFocusedRowCellValue("FlagNacional").ToString());
                    objProducto.FlagEscala = bool.Parse(gvProducto.GetFocusedRowCellValue("FlagEscala").ToString());
                    objProducto.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                    pProductoBE = objProducto;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Producto");
            }
        }


        private void CalcularPaginas()
        {
            cboPagina.Properties.Items.Clear();
            intRegistrosTotal = CantidadRegistros();
            if (intRegistrosTotal > 0)
            {
                intPaginaUltima = intRegistrosTotal / intRegistrosPorPagina;
                int Residuo = intRegistrosTotal % intRegistrosPorPagina;
                if (Residuo > 0)
                    intPaginaUltima += 1;
                for (int i = 0; i < intPaginaUltima; i++)
                {
                    cboPagina.Properties.Items.Add(i + 1);
                }
                cboPagina.SelectedIndex = 0;
            }
        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            btnFirst.Enabled = bolFirst;
            btnPrevious.Enabled = bolPrevious;
            btnNext.Enabled = bolNext;
            btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            if (txtDescripcion.Text.ToString().Length > 2)
            {
                intRowCount = new PreventaDetalleBL().ListaProductoPrecioBusquedaCount(Convert.ToInt32(cboTienda.EditValue), txtDescripcion.Text);

            }

            return intRowCount;
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                SeleccionarRegistro();
            }
        }

        #endregion

    }
}