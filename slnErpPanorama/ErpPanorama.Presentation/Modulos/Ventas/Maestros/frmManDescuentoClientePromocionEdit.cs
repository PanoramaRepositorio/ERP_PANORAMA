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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManDescuentoClientePromocionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CDescuentoClientePromocionDetalle> mListaDescuentoClientePromocionDetalleOrigen = new List<CDescuentoClientePromocionDetalle>();
        private List<PreventaDetalleBE> lst_DescuentoClientePromocionDetalleMsg = new List<PreventaDetalleBE>();

        DataTable dt = new DataTable();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdDescuentoClientePromocion = 0;

        public int IdDescuentoClientePromocion
        {
            get { return _IdDescuentoClientePromocion; }
            set { _IdDescuentoClientePromocion = value; }
        }

        public DescuentoClientePromocionBE pDescuentoClientePromocionBE { get; set; }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmManDescuentoClientePromocionEdit()
        {
            InitializeComponent();
        }

        private void frmManDescuentoClientePromocionEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCliente.EditValue = Parametros.intTipClienteFinal;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Promocion Descuento - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Promocion Descuento - Modificar";

                IdDescuentoClientePromocion = pDescuentoClientePromocionBE.IdDescuentoClientePromocion;
                txtDescripcion.Text = pDescuentoClientePromocionBE.Descripcion;
                cboTipoCliente.EditValue = pDescuentoClientePromocionBE.IdTipoCliente;
                deDesde.EditValue = pDescuentoClientePromocionBE.FechaInicio;
                deHasta.EditValue = pDescuentoClientePromocionBE.FechaFin;
                txtDescuento.EditValue = pDescuentoClientePromocionBE.Descuento;
                txtObservacion.Text = pDescuentoClientePromocionBE.Observacion;


                if (Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerJefeMarketingPublicidad)
                {
                    btnGrabar.Enabled = true;
                    eliminartodotoolStripMenuItem.Visible = true;
                    eliminarToolStripMenuItem.Visible = true;
                }
                else
                {
                    btnGrabar.Enabled = false;
                    eliminartodotoolStripMenuItem.Visible = false;
                    eliminarToolStripMenuItem.Visible = false;
                    importartoolStripMenuItem.Visible = false;
                    nuevoToolStripMenuItem.Visible = false;
                    modificarprecioToolStripMenuItem.Visible = false;
                }
            }

            CargaDescuentoClientePromocionDetalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcion.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el nombre del DescuentoClientePromocion.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDescuentoClientePromocionDetalleOrigen.Count == 0)
                        {
                            gvDescuentoClientePromocionDetalle.AddNewRow();
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdDescuentoClientePromocion", movDetalle.oBE.IdPromocion);//IdDescuentoClientePromocion);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdDescuentoClientePromocionDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdDescuentoClientePromocionDetalle);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Descuento", txtDescuento.Text);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDescuentoClientePromocionDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaDescuentoClientePromocionDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaDescuentoClientePromocionDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvDescuentoClientePromocionDetalle.AddNewRow();
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdDescuentoClientePromocion", movDetalle.oBE.IdPromocion);//IdDescuentoClientePromocion);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdDescuentoClientePromocionDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdDescuentoClientePromocionDetalle);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Descuento", txtDescuento.Text);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDescuentoClientePromocionDetalle.UpdateCurrentRow();

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
            if (mListaDescuentoClientePromocionDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                movDetalle.IdPromocion = Convert.ToInt32(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdDescuentoClientePromocion"));
                movDetalle.IdPromocionDetalle = Convert.ToInt32(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdDescuentoClientePromocionDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("Precio"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvDescuentoClientePromocionDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "IdDescuentoClientePromocion", movDetalle.oBE.IdPromocion);
                        gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "IdDescuentoClientePromocionDetalle", movDetalle.oBE.IdPromocionDetalle);
                        gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        //gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "CantidadVenta", 0);
                        //gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvDescuentoClientePromocionDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDescuentoClientePromocionDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdDescuentoClientePromocionDetalle = 0;
                        if (gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdDescuentoClientePromocionDetalle") != null)
                            IdDescuentoClientePromocionDetalle = int.Parse(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdDescuentoClientePromocionDetalle").ToString());
                        int Item = 0;
                        if (gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("Item").ToString());
                        DescuentoClientePromocionDetalleBE objBE_DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleBE();
                        objBE_DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = IdDescuentoClientePromocionDetalle;
                        objBE_DescuentoClientePromocionDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_DescuentoClientePromocionDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_DescuentoClientePromocionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        DescuentoClientePromocionDetalleBL objBL_DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleBL();
                        objBL_DescuentoClientePromocionDetalle.Elimina(objBE_DescuentoClientePromocionDetalle);
                        gvDescuentoClientePromocionDetalle.DeleteRow(gvDescuentoClientePromocionDetalle.FocusedRowHandle);
                        gvDescuentoClientePromocionDetalle.RefreshData();

                    }
                    else
                    {
                        gvDescuentoClientePromocionDetalle.DeleteRow(gvDescuentoClientePromocionDetalle.FocusedRowHandle);
                        gvDescuentoClientePromocionDetalle.RefreshData();
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
                    DescuentoClientePromocionBE objDescuentoClientePromocion = new DescuentoClientePromocionBE();
                    DescuentoClientePromocionBL objBL_DescuentoClientePromocion = new DescuentoClientePromocionBL();

                    objDescuentoClientePromocion.IdDescuentoClientePromocion = IdDescuentoClientePromocion;
                    objDescuentoClientePromocion.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objDescuentoClientePromocion.Descripcion = txtDescripcion.Text.Trim();
                    objDescuentoClientePromocion.FechaInicio = Convert.ToDateTime(deDesde.DateTime.ToShortDateString());
                    objDescuentoClientePromocion.FechaFin = Convert.ToDateTime(deHasta.DateTime.ToShortDateString());
                    objDescuentoClientePromocion.Descuento = Convert.ToDecimal(txtDescuento.EditValue);
                    objDescuentoClientePromocion.Observacion = txtObservacion.Text;
                    objDescuentoClientePromocion.FlagEstado = true;
                    objDescuentoClientePromocion.Usuario = Parametros.strUsuarioLogin;
                    objDescuentoClientePromocion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDescuentoClientePromocion.IdEmpresa = Parametros.intEmpresaId;

                    //DescuentoClientePromocion Detalle
                    List<DescuentoClientePromocionDetalleBE> lstDescuentoClientePromocionDetalle = new List<DescuentoClientePromocionDetalleBE>();

                    foreach (var item in mListaDescuentoClientePromocionDetalleOrigen)
                    {
                        DescuentoClientePromocionDetalleBE objE_DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleBE();
                        objE_DescuentoClientePromocionDetalle.IdDescuentoClientePromocion = item.IdDescuentoClientePromocion;
                        objE_DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = item.IdDescuentoClientePromocionDetalle;
                        objE_DescuentoClientePromocionDetalle.IdProducto = item.IdProducto;
                        //objE_DescuentoClientePromocionDetalle.CodigoProveedor = item.CodigoProveedor;
                        //objE_DescuentoClientePromocionDetalle.NombreProducto = item.NombreProducto;
                        //objE_DescuentoClientePromocionDetalle.Abreviatura = item.Abreviatura;
                        //objE_DescuentoClientePromocionDetalle.Cantidad = item.Cantidad;
                        objE_DescuentoClientePromocionDetalle.Descuento = item.Descuento;
                        objE_DescuentoClientePromocionDetalle.FlagEstado = true;
                        objE_DescuentoClientePromocionDetalle.TipoOper = item.TipoOper;
                        objE_DescuentoClientePromocionDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_DescuentoClientePromocionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstDescuentoClientePromocionDetalle.Add(objE_DescuentoClientePromocionDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_DescuentoClientePromocion.Inserta(objDescuentoClientePromocion, lstDescuentoClientePromocionDetalle);
                    }
                    else
                    {
                        objBL_DescuentoClientePromocion.Actualiza(objDescuentoClientePromocion, lstDescuentoClientePromocionDetalle);
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
            //try
            //{

            //    //decimal deValorVenta = 0;
            //    //decimal deTotal = 0;

            //    decimal CantidadTotal = 0;
            //    decimal CantidadVentaTotal = 0;

            //    if (mListaDescuentoClientePromocionDetalleOrigen.Count > 0)
            //    {
            //        foreach (var item in mListaDescuentoClientePromocionDetalleOrigen)
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

            //    lblTotalRegistros.Text = mListaDescuentoClientePromocionDetalleOrigen.Count.ToString() + " Registros encontrados";

            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargaDescuentoClientePromocionDetalle()
        {
            List<DescuentoClientePromocionDetalleBE> lstTmpDescuentoClientePromocionDetalle = null;
            lstTmpDescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleBL().ListaTodosActivo(IdDescuentoClientePromocion);

            foreach (DescuentoClientePromocionDetalleBE item in lstTmpDescuentoClientePromocionDetalle)
            {
                CDescuentoClientePromocionDetalle objE_DescuentoClientePromocionDetalle = new CDescuentoClientePromocionDetalle();
                objE_DescuentoClientePromocionDetalle.IdDescuentoClientePromocion = item.IdDescuentoClientePromocion;
                objE_DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = item.IdDescuentoClientePromocionDetalle;
                objE_DescuentoClientePromocionDetalle.IdProducto = item.IdProducto;
                objE_DescuentoClientePromocionDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DescuentoClientePromocionDetalle.NombreProducto = item.NombreProducto;
                objE_DescuentoClientePromocionDetalle.Abreviatura = item.Abreviatura;
                objE_DescuentoClientePromocionDetalle.Descuento = item.Descuento;
                objE_DescuentoClientePromocionDetalle.Fecha = item.Fecha;
                //objE_DescuentoClientePromocionDetalle.Usuario = item.Usuario;
                //objE_DescuentoClientePromocionDetalle.Maquina = item.Maquina;
                //objE_DescuentoClientePromocionDetalle.FechaRegistro = item.FechaRegistro;
                objE_DescuentoClientePromocionDetalle.AlmacenCentral = item.AlmacenCentral;
                objE_DescuentoClientePromocionDetalle.AlmacenTienda = item.AlmacenTienda;
                objE_DescuentoClientePromocionDetalle.AlmacenAndahuaylas = item.AlmacenAndahuaylas;
                objE_DescuentoClientePromocionDetalle.AlmacenPrescott = item.AlmacenPrescott;
                objE_DescuentoClientePromocionDetalle.AlmacenAviacion = item.AlmacenAviacion;
                objE_DescuentoClientePromocionDetalle.AlmacenMegaPlaza = item.AlmacenMegaPlaza;
                objE_DescuentoClientePromocionDetalle.StockTotal = item.AlmacenCentral + item.AlmacenTienda + item.AlmacenAndahuaylas + item.AlmacenPrescott + item.AlmacenAviacion + item.AlmacenMegaPlaza;
                //objE_DescuentoClientePromocionDetalle.Stock = item.AlmacenAviacion;
                //objE_DescuentoClientePromocionDetalle.Diferencia = item.Cantidad - item.CantidadVenta;
                //objE_DescuentoClientePromocionDetalle.Precio = item.Precio;
                objE_DescuentoClientePromocionDetalle.TipoOper = item.TipoOper;
                mListaDescuentoClientePromocionDetalleOrigen.Add(objE_DescuentoClientePromocionDetalle);
            }

            bsListado.DataSource = mListaDescuentoClientePromocionDetalleOrigen;
            gcDescuentoClientePromocionDetalle.DataSource = bsListado;
            gcDescuentoClientePromocionDetalle.RefreshDataSource();

            lblTotalRegistros.Text = mListaDescuentoClientePromocionDetalleOrigen.Count.ToString() + " Registros encontrados";

            //CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la descripción del DescuentoClientePromocion.\n";
                flag = true;
            }

            //if (mListaDescuentoClientePromocionDetalleOrigen.Count == 0)
            //{
            //    strMensaje = strMensaje + "- Nos se puede generar el DescuentoClientePromocion, mientra no haya productos.\n";
            //    flag = true;
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion

        public class CDescuentoClientePromocionDetalle
        {
            public Int32 IdDescuentoClientePromocion { get; set; }
            public Int32 IdDescuentoClientePromocionDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime FechaRegistro { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public Decimal Descuento { get; set; }
            //public Int32 CantidadVenta { get; set; }
            //public Int32 Diferencia { get; set; }
            //public Decimal Precio { get; set; }

            public Int32 AlmacenCentral { get; set; }
            public Int32 AlmacenTienda { get; set; }
            public Int32 AlmacenAndahuaylas { get; set; }
            public Int32 AlmacenPrescott { get; set; }
            public Int32 AlmacenAviacion { get; set; }
            public Int32 AlmacenMegaPlaza { get; set; }
            public Int32 StockTotal { get; set; }


            public Int32 TipoOper { get; set; }

            public CDescuentoClientePromocionDetalle()
            {

            }
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string _file_excel = "";
            //OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            //objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            //if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    _file_excel = objOpenFileDialog.FileName;
            //    ImportarExcel(_file_excel);
            //    //Cargar();
            //}
        }

        private void exportartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPromocion3x2Detalle";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescuentoClientePromocionDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
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


                //Recorremos los códigos de DescuentoClientePromocion
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    decimal Descuento = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaDescuentoClientePromocionDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvDescuentoClientePromocionDetalle.AddNewRow();
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdDescuentoClientePromocionDetalle", 0);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Descuento", Descuento);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                        }



                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_DescuentoClientePromocionDetalle = new PreventaDetalleBE();
                        ObjE_DescuentoClientePromocionDetalle.CodigoProveedor = CodigoProveedor;
                        //ObjE_DescuentoClientePromocionDetalle.Cantidad = Cantidad;
                        lst_DescuentoClientePromocionDetalleMsg.Add(ObjE_DescuentoClientePromocionDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvDescuentoClientePromocionDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_DescuentoClientePromocionDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_DescuentoClientePromocionDetalleMsg;
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


                //Recorremos los códigos de DescuentoClientePromocion
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    //string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int IdProducto = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    decimal Descuento = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaDescuentoClientePromocionDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvDescuentoClientePromocionDetalle.AddNewRow();
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdDescuentoClientePromocionDetalle", 0);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Descuento", Descuento);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvDescuentoClientePromocionDetalle.SetRowCellValue(gvDescuentoClientePromocionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                        }

                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_DescuentoClientePromocionDetalle = new PreventaDetalleBE();
                        ObjE_DescuentoClientePromocionDetalle.CodigoProveedor = IdProducto.ToString();
                        //ObjE_DescuentoClientePromocionDetalle.Cantidad = Cantidad;
                        lst_DescuentoClientePromocionDetalleMsg.Add(ObjE_DescuentoClientePromocionDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvDescuentoClientePromocionDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_DescuentoClientePromocionDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_DescuentoClientePromocionDetalleMsg;
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

        private void gvDescuentoClientePromocionDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvDescuentoClientePromocionDetalle.RowCount > 0)
                {
                    //DataRow dr;
                    //dr = gvDescuentoClientePromocionDetalle.GetDataRow(e.FocusedRowHandle);
                    int IdProducto = 0;
                    IdProducto = int.Parse(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdProducto").ToString());

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
            catch (Exception)
            {

                //throw;
            }



        }

        private void gvDescuentoClientePromocionDetalle_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvDescuentoClientePromocionDetalle.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvDescuentoClientePromocionDetalle.GetDataRow(e.RowHandle);
                int IdProducto = 0;

                IdProducto = int.Parse(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdProducto").ToString());
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

        private void CargarIdProducto()
        {

            //dt = FuncionBase.ToDataTable(mListaDescuentoClientePromocionDetalleOrigen);//new DescuentoClientePromocionDetalleBL().ListaTodosActivo(IdDescuentoClientePromocion));
            //gcDescuentoClientePromocionDetalle.DataSource = dt;

            //if (gvDescuentoClientePromocionDetalle.RowCount > 0)
            //{
            //    ProductoBE objE_Producto = null;
            //    int IdProducto = 0;
            //    IdProducto = int.Parse(gvDescuentoClientePromocionDetalle.GetFocusedRowCellValue("IdProducto").ToString());

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

        private void eliminartodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de eliminar todo los registros?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DescuentoClientePromocionDetalleBE ojbE_PromocionDetalle = new DescuentoClientePromocionDetalleBE();
                ojbE_PromocionDetalle.IdDescuentoClientePromocion = IdDescuentoClientePromocion;
                ojbE_PromocionDetalle.Usuario = Parametros.strUsuarioLogin;
                ojbE_PromocionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                ojbE_PromocionDetalle.IdEmpresa = Parametros.intEmpresaId;


                DescuentoClientePromocionDetalleBL ojbBL_PromocionDetalle = new DescuentoClientePromocionDetalleBL();
                ojbBL_PromocionDetalle.EliminaTodo(ojbE_PromocionDetalle);

                mListaDescuentoClientePromocionDetalleOrigen = new List<CDescuentoClientePromocionDetalle>();
                CargaDescuentoClientePromocionDetalle();
                gvDescuentoClientePromocionDetalle.RefreshData();

                XtraMessageBox.Show("Registros eliminados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

    }
}