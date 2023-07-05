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
    public partial class frmManPromocion3x2Edit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CPromocion2x1Detalle> mListaPromocion2x1DetalleOrigen = new List<CPromocion2x1Detalle>();
        private List<PreventaDetalleBE> lst_Promocion2x1DetalleMsg = new List<PreventaDetalleBE>();

        DataTable dt = new DataTable();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdPromocion3x2 = 0;

        public int IdPromocion3x2
        {
            get { return _IdPromocion3x2; }
            set { _IdPromocion3x2 = value; }
        }

        public Promocion3x2BE pPromocion3x2BE { get; set; }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmManPromocion3x2Edit()
        {
            InitializeComponent();
        }

        private void frmManPromocion3x2Edit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCliente.EditValue = Parametros.intTipClienteFinal;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Promocion 3x2 - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Promocion 3x2 - Modificar";

                cboEmpresa.EditValue = pPromocion3x2BE.IdEmpresa;
                IdPromocion3x2 = pPromocion3x2BE.IdPromocion3x2;
                txtDescPromocion2x1.Text = pPromocion3x2BE.DescPromocion3x2;
                cboTipoCliente.EditValue = pPromocion3x2BE.IdTipoCliente;
                cboFormaPago.EditValue = pPromocion3x2BE.IdFormaPago;
                deDesde.EditValue = pPromocion3x2BE.FechaInicio;
                deHasta.EditValue = pPromocion3x2BE.FechaFin;

                chkContado.Checked = pPromocion3x2BE.FlagContado;
                chkCredito.Checked = pPromocion3x2BE.FlagCredito;
                chkConsignacion.Checked = pPromocion3x2BE.FlagConsignacion;
                chkSeparacion.Checked = pPromocion3x2BE.FlagSeparacion;
                chkContraentrega.Checked = pPromocion3x2BE.FlagContraentrega;
                chkCopagan.Checked = pPromocion3x2BE.FlagCopagan;
                chkObsequio.Checked = pPromocion3x2BE.FlagObsequio;
                chkAsaf.Checked = pPromocion3x2BE.FlagAsaf;
                chkMayorista.Checked = pPromocion3x2BE.FlagClienteMayorista;
                chkMinorista.Checked = pPromocion3x2BE.FlagClienteFinal;

                if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerCoordinadorVisualCentral || Parametros.intPerfilId == Parametros.intPerAsistenteCompras)
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

            CargaPromocion2x1Detalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescPromocion2x1.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el nombre del Promocion2x1 promocional.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaPromocion2x1DetalleOrigen.Count == 0)
                        {
                            gvPromocion2x1Detalle.AddNewRow();
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdPromocion2x1", movDetalle.oBE.IdPromocion);//IdPromocion2x1);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdPromocion2x1Detalle", movDetalle.oBE.IdPromocionDetalle);//.IdPromocion2x1Detalle);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocion2x1Detalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaPromocion2x1DetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaPromocion2x1DetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPromocion2x1Detalle.AddNewRow();
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdPromocion2x1", movDetalle.oBE.IdPromocion);//IdPromocion2x1);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdPromocion2x1Detalle", movDetalle.oBE.IdPromocionDetalle);//.IdPromocion2x1Detalle);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocion2x1Detalle.UpdateCurrentRow();

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
            if (mListaPromocion2x1DetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                movDetalle.IdPromocion = Convert.ToInt32(gvPromocion2x1Detalle.GetFocusedRowCellValue("IdPromocion2x1"));
                movDetalle.IdPromocionDetalle = Convert.ToInt32(gvPromocion2x1Detalle.GetFocusedRowCellValue("IdPromocion2x1Detalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvPromocion2x1Detalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvPromocion2x1Detalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvPromocion2x1Detalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvPromocion2x1Detalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvPromocion2x1Detalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvPromocion2x1Detalle.GetFocusedRowCellValue("Precio"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPromocion2x1Detalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvPromocion2x1Detalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvPromocion2x1Detalle.SetRowCellValue(xposition, "IdPromocion2x1", movDetalle.oBE.IdPromocion);
                        gvPromocion2x1Detalle.SetRowCellValue(xposition, "IdPromocion2x1Detalle", movDetalle.oBE.IdPromocionDetalle);
                        gvPromocion2x1Detalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvPromocion2x1Detalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvPromocion2x1Detalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvPromocion2x1Detalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvPromocion2x1Detalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        //gvPromocion2x1Detalle.SetRowCellValue(xposition, "CantidadVenta", 0);
                        //gvPromocion2x1Detalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvPromocion2x1Detalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvPromocion2x1Detalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPromocion2x1Detalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvPromocion2x1Detalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPromocion2x1DetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvPromocion2x1Detalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdPromocion2x1Detalle = 0;
                        if (gvPromocion2x1Detalle.GetFocusedRowCellValue("IdPromocion2x1Detalle") != null)
                            IdPromocion2x1Detalle = int.Parse(gvPromocion2x1Detalle.GetFocusedRowCellValue("IdPromocion2x1Detalle").ToString());
                        int Item = 0;
                        if (gvPromocion2x1Detalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvPromocion2x1Detalle.GetFocusedRowCellValue("Item").ToString());
                        Promocion2x1DetalleBE objBE_Promocion2x1Detalle = new Promocion2x1DetalleBE();
                        objBE_Promocion2x1Detalle.IdPromocion2x1Detalle = IdPromocion2x1Detalle;
                        objBE_Promocion2x1Detalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_Promocion2x1Detalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_Promocion2x1Detalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        Promocion2x1DetalleBL objBL_Promocion2x1Detalle = new Promocion2x1DetalleBL();
                        objBL_Promocion2x1Detalle.Elimina(objBE_Promocion2x1Detalle);
                        gvPromocion2x1Detalle.DeleteRow(gvPromocion2x1Detalle.FocusedRowHandle);
                        gvPromocion2x1Detalle.RefreshData();

                    }
                    else
                    {
                        gvPromocion2x1Detalle.DeleteRow(gvPromocion2x1Detalle.FocusedRowHandle);
                        gvPromocion2x1Detalle.RefreshData();
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
                    Promocion2x1BL objBL_Promocion2x1 = new Promocion2x1BL();
                    Promocion2x1BE objPromocion2x1 = new Promocion2x1BE();
                    objPromocion2x1.IdPromocion2x1 = IdPromocion3x2;
                    objPromocion2x1.DescPromocion2x1 = txtDescPromocion2x1.Text;
                    objPromocion2x1.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objPromocion2x1.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPromocion2x1.FechaInicio = Convert.ToDateTime(deDesde.DateTime);
                    objPromocion2x1.FechaFin = Convert.ToDateTime(deHasta.DateTime);
                    objPromocion2x1.Tipo = "3x2";
                    objPromocion2x1.FlagContado = chkContado.Checked;
                    objPromocion2x1.FlagCredito = chkCredito.Checked;
                    objPromocion2x1.FlagConsignacion = chkConsignacion.Checked;
                    objPromocion2x1.FlagSeparacion = chkSeparacion.Checked;
                    objPromocion2x1.FlagContraentrega = chkContraentrega.Checked;
                    objPromocion2x1.FlagCopagan = chkCopagan.Checked;
                    objPromocion2x1.FlagObsequio = chkObsequio.Checked;
                    objPromocion2x1.FlagAsaf = chkAsaf.Checked;
                    objPromocion2x1.FlagClienteMayorista = chkMayorista.Checked;
                    objPromocion2x1.FlagClienteFinal = chkMinorista.Checked;
                    //objPromocion2x1.Total = Convert.ToDecimal(txtTotal.EditValue);
                    //objPromocion2x1.Observacion = txtObservacion.Text.Trim();
                    objPromocion2x1.FlagEstado = true;
                    objPromocion2x1.Usuario = Parametros.strUsuarioLogin;
                    objPromocion2x1.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPromocion2x1.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;

                    //Promocion2x1 Detalle
                    List<Promocion2x1DetalleBE> lstPromocion2x1Detalle = new List<Promocion2x1DetalleBE>();

                    foreach (var item in mListaPromocion2x1DetalleOrigen)
                    {
                        Promocion2x1DetalleBE objE_Promocion2x1Detalle = new Promocion2x1DetalleBE();
                        objE_Promocion2x1Detalle.IdPromocion2x1 = item.IdPromocion2x1;
                        objE_Promocion2x1Detalle.IdPromocion2x1Detalle = item.IdPromocion2x1Detalle;
                        objE_Promocion2x1Detalle.IdProducto = item.IdProducto;
                        //objE_Promocion2x1Detalle.CodigoProveedor = item.CodigoProveedor;
                        //objE_Promocion2x1Detalle.NombreProducto = item.NombreProducto;
                        //objE_Promocion2x1Detalle.Abreviatura = item.Abreviatura;
                        //objE_Promocion2x1Detalle.Cantidad = item.Cantidad;
                        //objE_Promocion2x1Detalle.Precio = item.Precio;
                        objE_Promocion2x1Detalle.FlagEstado = true;
                        objE_Promocion2x1Detalle.TipoOper = item.TipoOper;
                        objE_Promocion2x1Detalle.Usuario = Parametros.strUsuarioLogin;
                        objE_Promocion2x1Detalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstPromocion2x1Detalle.Add(objE_Promocion2x1Detalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Promocion2x1.Inserta(objPromocion2x1, lstPromocion2x1Detalle);
                    }
                    else
                    {
                        objBL_Promocion2x1.Actualiza(objPromocion2x1, lstPromocion2x1Detalle);
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

            //    if (mListaPromocion2x1DetalleOrigen.Count > 0)
            //    {
            //        foreach (var item in mListaPromocion2x1DetalleOrigen)
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

            //    lblTotalRegistros.Text = mListaPromocion2x1DetalleOrigen.Count.ToString() + " Registros encontrados";

            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargaPromocion2x1Detalle()
        {
            List<Promocion2x1DetalleBE> lstTmpPromocion2x1Detalle = null;
            lstTmpPromocion2x1Detalle = new Promocion2x1DetalleBL().ListaTodosActivo(IdPromocion3x2);

            foreach (Promocion2x1DetalleBE item in lstTmpPromocion2x1Detalle)
            {
                CPromocion2x1Detalle objE_Promocion2x1Detalle = new CPromocion2x1Detalle();
                objE_Promocion2x1Detalle.IdPromocion2x1 = item.IdPromocion2x1;
                objE_Promocion2x1Detalle.IdPromocion2x1Detalle = item.IdPromocion2x1Detalle;
                objE_Promocion2x1Detalle.IdProducto = item.IdProducto;
                objE_Promocion2x1Detalle.CodigoProveedor = item.CodigoProveedor;
                objE_Promocion2x1Detalle.NombreProducto = item.NombreProducto;
                objE_Promocion2x1Detalle.Abreviatura = item.Abreviatura;
                objE_Promocion2x1Detalle.Fecha = item.Fecha;
                objE_Promocion2x1Detalle.Usuario = item.Usuario;
                objE_Promocion2x1Detalle.Maquina = item.Maquina;
                objE_Promocion2x1Detalle.FechaRegistro = item.FechaRegistro;
                objE_Promocion2x1Detalle.AlmacenCentral = item.AlmacenCentral;
                objE_Promocion2x1Detalle.AlmacenTienda = item.AlmacenTienda;
                objE_Promocion2x1Detalle.AlmacenAndahuaylas = item.AlmacenAndahuaylas;
                objE_Promocion2x1Detalle.AlmacenPrescott = item.AlmacenPrescott;
                objE_Promocion2x1Detalle.AlmacenAviacion = item.AlmacenAviacion;
                objE_Promocion2x1Detalle.AlmacenMegaPlaza = item.AlmacenMegaPlaza;
                objE_Promocion2x1Detalle.StockTotal = item.AlmacenCentral + item.AlmacenTienda + item.AlmacenAndahuaylas + item.AlmacenPrescott + item.AlmacenAviacion + item.AlmacenMegaPlaza;
                objE_Promocion2x1Detalle.DescLineaProducto = item.DescLineaProducto;
                objE_Promocion2x1Detalle.DescSubLineaProducto = item.DescSubLineaProducto;
                //objE_Promocion2x1Detalle.Stock = item.AlmacenAviacion;
                //objE_Promocion2x1Detalle.Diferencia = item.Cantidad - item.CantidadVenta;
                //objE_Promocion2x1Detalle.Precio = item.Precio;
                objE_Promocion2x1Detalle.TipoOper = item.TipoOper;
                mListaPromocion2x1DetalleOrigen.Add(objE_Promocion2x1Detalle);
            }

            bsListado.DataSource = mListaPromocion2x1DetalleOrigen;
            gcPromocion2x1Detalle.DataSource = bsListado;
            gcPromocion2x1Detalle.RefreshDataSource();

            lblTotalRegistros.Text = mListaPromocion2x1DetalleOrigen.Count.ToString() + " Registros encontrados";

            //CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescPromocion2x1.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la descripción del Promocion2x1.\n";
                flag = true;
            }

            if (mListaPromocion2x1DetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el Promocion2x1, mientra no haya productos.\n";
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

        public class CPromocion2x1Detalle
        {
            public Int32 IdPromocion2x1 { get; set; }
            public Int32 IdPromocion2x1Detalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime FechaRegistro { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public String DescLineaProducto { get; set; }
            public String DescSubLineaProducto { get; set; }

            //public Int32 Cantidad { get; set; }
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

            public CPromocion2x1Detalle()
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
                gvPromocion2x1Detalle.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
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


                //Recorremos los códigos de Promocion2x1
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    //int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaPromocion2x1DetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvPromocion2x1Detalle.AddNewRow();
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdPromocion2x1Detalle", 0);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Cantidad", Cantidad);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                        }



                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_Promocion2x1Detalle = new PreventaDetalleBE();
                        ObjE_Promocion2x1Detalle.CodigoProveedor = CodigoProveedor;
                        //ObjE_Promocion2x1Detalle.Cantidad = Cantidad;
                        lst_Promocion2x1DetalleMsg.Add(ObjE_Promocion2x1Detalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvPromocion2x1Detalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_Promocion2x1DetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_Promocion2x1DetalleMsg;
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


                //Recorremos los códigos de Promocion2x1
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    //string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int IdProducto = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaPromocion2x1DetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvPromocion2x1Detalle.AddNewRow();
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdPromocion2x1Detalle", 0);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Cantidad", Cantidad);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvPromocion2x1Detalle.SetRowCellValue(gvPromocion2x1Detalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                        }

                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_Promocion2x1Detalle = new PreventaDetalleBE();
                        ObjE_Promocion2x1Detalle.CodigoProveedor = IdProducto.ToString();
                        //ObjE_Promocion2x1Detalle.Cantidad = Cantidad;
                        lst_Promocion2x1DetalleMsg.Add(ObjE_Promocion2x1Detalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvPromocion2x1Detalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_Promocion2x1DetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_Promocion2x1DetalleMsg;
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

        private void gvPromocion2x1Detalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvPromocion2x1Detalle.RowCount > 0)
                {
                    //DataRow dr;
                    //dr = gvPromocion2x1Detalle.GetDataRow(e.FocusedRowHandle);
                    int IdProducto = 0;
                    IdProducto = int.Parse(gvPromocion2x1Detalle.GetFocusedRowCellValue("IdProducto").ToString());

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

        private void gvPromocion2x1Detalle_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvPromocion2x1Detalle.RowCount > 0)
            {
                //DataRow dr;
                //dr = gvPromocion2x1Detalle.GetDataRow(e.RowHandle);
                int IdProducto = 0;

                IdProducto = int.Parse(gvPromocion2x1Detalle.GetFocusedRowCellValue("IdProducto").ToString());
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

            //dt = FuncionBase.ToDataTable(mListaPromocion2x1DetalleOrigen);//new Promocion2x1DetalleBL().ListaTodosActivo(IdPromocion2x1));
            //gcPromocion2x1Detalle.DataSource = dt;

            //if (gvPromocion2x1Detalle.RowCount > 0)
            //{
            //    ProductoBE objE_Producto = null;
            //    int IdProducto = 0;
            //    IdProducto = int.Parse(gvPromocion2x1Detalle.GetFocusedRowCellValue("IdProducto").ToString());

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
                Promocion2x1DetalleBE ojbE_PromocionDetalle = new Promocion2x1DetalleBE();
                ojbE_PromocionDetalle.IdPromocion2x1 = IdPromocion3x2;
                ojbE_PromocionDetalle.Usuario = Parametros.strUsuarioLogin;
                ojbE_PromocionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                ojbE_PromocionDetalle.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;


                Promocion2x1DetalleBL ojbBL_PromocionDetalle = new Promocion2x1DetalleBL();
                ojbBL_PromocionDetalle.EliminaTodo(ojbE_PromocionDetalle);

                mListaPromocion2x1DetalleOrigen = new List<CPromocion2x1Detalle>();
                CargaPromocion2x1Detalle();
                gvPromocion2x1Detalle.RefreshData();

                XtraMessageBox.Show("Registros eliminados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



    }
}