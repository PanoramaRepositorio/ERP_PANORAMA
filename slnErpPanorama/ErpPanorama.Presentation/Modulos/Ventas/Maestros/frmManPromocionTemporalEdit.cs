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
    public partial class frmManPromocionTemporalEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CPromocionTemporalDetalle> mListaPromocionTemporalDetalleOrigen = new List<CPromocionTemporalDetalle>();
        private List<PreventaDetalleBE> lst_PromocionTemporalDetalleMsg = new List<PreventaDetalleBE>();

        DataTable dt = new DataTable();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdPromocionTemporal = 0;

        public int IdPromocionTemporal
        {
            get { return _IdPromocionTemporal; }
            set { _IdPromocionTemporal = value; }
        }

        public PromocionTemporalBE pPromocionTemporalBE { get; set; }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmManPromocionTemporalEdit()
        {
            InitializeComponent();
        }

        private void frmManPromocionTemporalEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCliente.EditValue = Parametros.intTipClienteFinal;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosCombo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboTipoVenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoVenta), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "PromocionTemporal - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "PromocionTemporal - Modificar";

                cboEmpresa.EditValue = pPromocionTemporalBE.IdEmpresa;
                IdPromocionTemporal = pPromocionTemporalBE.IdPromocionTemporal;
                txtDescPromocionTemporal.Text = pPromocionTemporalBE.DescPromocionTemporal;
                cboTipoCliente.EditValue = pPromocionTemporalBE.IdTipoCliente;
                cboFormaPago.EditValue = pPromocionTemporalBE.IdFormaPago;
                cboTienda.EditValue = pPromocionTemporalBE.IdTienda;
                deDesde.EditValue = pPromocionTemporalBE.FechaInicio;
                deHasta.EditValue = pPromocionTemporalBE.FechaFin;
                chkContado.Checked = pPromocionTemporalBE.FlagContado;
                chkCredito.Checked = pPromocionTemporalBE.FlagCredito;
                chkConsignacion.Checked = pPromocionTemporalBE.FlagConsignacion;
                chkSeparacion.Checked = pPromocionTemporalBE.FlagSeparacion;
                chkContraentrega.Checked = pPromocionTemporalBE.FlagContraentrega;
                chkCopagan.Checked = pPromocionTemporalBE.FlagCopagan;
                chkObsequio.Checked = pPromocionTemporalBE.FlagObsequio;
                chkAsaf.Checked = pPromocionTemporalBE.FlagAsaf;
                chkMayorista.Checked = pPromocionTemporalBE.FlagClienteMayorista;
                chkMinorista.Checked = pPromocionTemporalBE.FlagClienteFinal;
                chkWeb.Checked = pPromocionTemporalBE.FlagWeb;
                chkUcayali.Checked = pPromocionTemporalBE.FlagUcayali;
                chkAndahuaylas.Checked = pPromocionTemporalBE.FlagAndahuaylas;
                chkPrescott.Checked = pPromocionTemporalBE.FlagPrescott;
                chkAviacion.Checked = pPromocionTemporalBE.FlagAviacion;
                chkMegaplaza.Checked = pPromocionTemporalBE.FlagMegaplaza;
                deDesdeImpresion.EditValue = pPromocionTemporalBE.FechaInicioImpresion;
                deHastaImpresion.EditValue = pPromocionTemporalBE.FechaFinImpresion;
                cboTipoVenta.EditValue = pPromocionTemporalBE.IdTipoVenta;
                chkAviacion2.Checked = pPromocionTemporalBE.FlagAviacion2;
                chkSanMiguel.Checked = pPromocionTemporalBE.FlagSanMiguel;

                if (Parametros.intPerfilId == Parametros.intPerAdministrador
                   || Parametros.intPerfilId == Parametros.intPerAsistenteCompras 
                   || Parametros.intPerfilId == Parametros.intPerAnalistaProducto)
                {
                    //    || Parametros.intPerfilId == Parametros.intPerCoordinadorVisualCentral                     || Parametros.intPerfilId == Parametros.intPerAuxiliarVisual 
                    btnGrabar.Enabled = true;
                }
                else
                {
                    btnGrabar.Enabled = false;
                    elminartodotoolStripMenuItem.Visible = false;
                    eliminarToolStripMenuItem.Visible = false;
                    importartoolStripMenuItem.Visible = false;
                    nuevoToolStripMenuItem.Visible = false;
                    modificarprecioToolStripMenuItem.Visible = false;
                }
            }

            CargaPromocionTemporalDetalle();
            BloquearAccesoPorPerfil();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescPromocionTemporal.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el nombre del PromocionTemporal promocional.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaPromocionTemporalDetalleOrigen.Count == 0)
                        {
                            gvPromocionTemporalDetalle.AddNewRow();
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdPromocionTemporal", movDetalle.oBE.IdPromocion);//IdPromocionTemporal);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdPromocionTemporalDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdPromocionTemporalDetalle);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocionTemporalDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaPromocionTemporalDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaPromocionTemporalDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPromocionTemporalDetalle.AddNewRow();
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdPromocionTemporal", movDetalle.oBE.IdPromocion);//IdPromocionTemporal);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdPromocionTemporalDetalle", movDetalle.oBE.IdPromocionDetalle);//.IdPromocionTemporalDetalle);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPromocionTemporalDetalle.UpdateCurrentRow();

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
            if (mListaPromocionTemporalDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPromocionDetalleEdit movDetalle = new frmManPromocionDetalleEdit();
                movDetalle.IdPromocion = Convert.ToInt32(gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdPromocionTemporal"));
                movDetalle.IdPromocionDetalle = Convert.ToInt32(gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdPromocionTemporalDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvPromocionTemporalDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvPromocionTemporalDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvPromocionTemporalDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvPromocionTemporalDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvPromocionTemporalDetalle.GetFocusedRowCellValue("Precio"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPromocionTemporalDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvPromocionTemporalDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvPromocionTemporalDetalle.SetRowCellValue(xposition, "IdPromocionTemporal", movDetalle.oBE.IdPromocion);
                        gvPromocionTemporalDetalle.SetRowCellValue(xposition, "IdPromocionTemporalDetalle", movDetalle.oBE.IdPromocionDetalle);
                        gvPromocionTemporalDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvPromocionTemporalDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvPromocionTemporalDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvPromocionTemporalDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvPromocionTemporalDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        //gvPromocionTemporalDetalle.SetRowCellValue(xposition, "CantidadVenta", 0);
                        //gvPromocionTemporalDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvPromocionTemporalDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvPromocionTemporalDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPromocionTemporalDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvPromocionTemporalDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPromocionTemporalDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdPromocionTemporalDetalle = 0;
                        if (gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdPromocionTemporalDetalle") != null)
                            IdPromocionTemporalDetalle = int.Parse(gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdPromocionTemporalDetalle").ToString());
                        int Item = 0;
                        if (gvPromocionTemporalDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvPromocionTemporalDetalle.GetFocusedRowCellValue("Item").ToString());
                        PromocionTemporalDetalleBE objBE_PromocionTemporalDetalle = new PromocionTemporalDetalleBE();
                        objBE_PromocionTemporalDetalle.IdPromocionTemporalDetalle = IdPromocionTemporalDetalle;
                        objBE_PromocionTemporalDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_PromocionTemporalDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_PromocionTemporalDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        PromocionTemporalDetalleBL objBL_PromocionTemporalDetalle = new PromocionTemporalDetalleBL();
                        objBL_PromocionTemporalDetalle.Elimina(objBE_PromocionTemporalDetalle);
                        gvPromocionTemporalDetalle.DeleteRow(gvPromocionTemporalDetalle.FocusedRowHandle);
                        gvPromocionTemporalDetalle.RefreshData();

                    }
                    else
                    {
                        gvPromocionTemporalDetalle.DeleteRow(gvPromocionTemporalDetalle.FocusedRowHandle);
                        gvPromocionTemporalDetalle.RefreshData();
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
                    PromocionTemporalBL objBL_PromocionTemporal = new PromocionTemporalBL();
                    PromocionTemporalBE objPromocionTemporal = new PromocionTemporalBE();
                    objPromocionTemporal.IdPromocionTemporal = IdPromocionTemporal;
                    objPromocionTemporal.DescPromocionTemporal = txtDescPromocionTemporal.Text;
                    objPromocionTemporal.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objPromocionTemporal.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPromocionTemporal.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objPromocionTemporal.IdTipoVenta = Convert.ToInt32(cboTipoVenta.EditValue);
                    objPromocionTemporal.FechaInicio = Convert.ToDateTime(deDesde.DateTime);
                    objPromocionTemporal.FechaFin = Convert.ToDateTime(deHasta.DateTime);
                    objPromocionTemporal.FlagContado = chkContado.Checked;
                    objPromocionTemporal.FlagCredito = chkCredito.Checked;
                    objPromocionTemporal.FlagConsignacion = chkConsignacion.Checked;
                    objPromocionTemporal.FlagSeparacion = chkSeparacion.Checked;
                    objPromocionTemporal.FlagContraentrega = chkContraentrega.Checked;
                    objPromocionTemporal.FlagCopagan = chkCopagan.Checked;
                    objPromocionTemporal.FlagObsequio = chkObsequio.Checked;
                    objPromocionTemporal.FlagAsaf = chkAsaf.Checked;
                    objPromocionTemporal.FlagClienteMayorista = chkMayorista.Checked;
                    objPromocionTemporal.FlagClienteFinal = chkMinorista.Checked;
                    objPromocionTemporal.FlagWeb = chkWeb.Checked;
                    objPromocionTemporal.FlagUcayali = chkUcayali.Checked;
                    objPromocionTemporal.FlagAndahuaylas = chkAndahuaylas.Checked;
                    objPromocionTemporal.FlagPrescott = chkPrescott.Checked;
                    objPromocionTemporal.FlagAviacion = chkAviacion.Checked;
                    objPromocionTemporal.FlagMegaplaza = chkMegaplaza.Checked;
                    objPromocionTemporal.FlagAviacion2 = chkAviacion2.Checked;
                    objPromocionTemporal.FlagSanMiguel = chkSanMiguel.Checked;
                    objPromocionTemporal.FechaInicioImpresion = Convert.ToDateTime(deDesdeImpresion.DateTime);
                    objPromocionTemporal.FechaFinImpresion = Convert.ToDateTime(deHastaImpresion.DateTime);
                    objPromocionTemporal.FlagEstado = true;
                    objPromocionTemporal.Usuario = Parametros.strUsuarioLogin;
                    objPromocionTemporal.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPromocionTemporal.IdEmpresa = Parametros.intEmpresaId;//Convert.ToInt32(cboEmpresa.EditValue);

                    //PromocionTemporal Detalle
                    List<PromocionTemporalDetalleBE> lstPromocionTemporalDetalle = new List<PromocionTemporalDetalleBE>();

                    foreach (var item in mListaPromocionTemporalDetalleOrigen)
                    {
                        PromocionTemporalDetalleBE objE_PromocionTemporalDetalle = new PromocionTemporalDetalleBE();
                        objE_PromocionTemporalDetalle.IdPromocionTemporal = item.IdPromocionTemporal;
                        objE_PromocionTemporalDetalle.IdPromocionTemporalDetalle = item.IdPromocionTemporalDetalle;
                        objE_PromocionTemporalDetalle.IdProducto = item.IdProducto;
                        objE_PromocionTemporalDetalle.Descuento = item.Descuento;
                        //objE_PromocionTemporalDetalle.CodigoProveedor = item.CodigoProveedor;
                        //objE_PromocionTemporalDetalle.NombreProducto = item.NombreProducto;
                        //objE_PromocionTemporalDetalle.Abreviatura = item.Abreviatura;
                        //objE_PromocionTemporalDetalle.Cantidad = item.Cantidad;
                        //objE_PromocionTemporalDetalle.Precio = item.Precio;
                        objE_PromocionTemporalDetalle.FlagEstado = true;
                        objE_PromocionTemporalDetalle.TipoOper = item.TipoOper;
                        objE_PromocionTemporalDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_PromocionTemporalDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstPromocionTemporalDetalle.Add(objE_PromocionTemporalDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_PromocionTemporal.Inserta(objPromocionTemporal, lstPromocionTemporalDetalle);
                    }
                    else
                    {
                        objBL_PromocionTemporal.Actualiza(objPromocionTemporal, lstPromocionTemporalDetalle);
                    }

                    Cursor = Cursors.Default;

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

        private void gvPromocionTemporalDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (chkActivarFoto.Checked)
                {
                    if (gvPromocionTemporalDetalle.RowCount > 0)
                    {
                        //DataRow dr;
                        //dr = gvPromocionTemporalDetalle.GetDataRow(e.FocusedRowHandle);
                        int IdProducto = 0;
                        IdProducto = int.Parse(gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdProducto").ToString());

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
            catch (Exception)
            {
                //throw;
            }
        }

        private void gvPromocionTemporalDetalle_RowClick(object sender, RowClickEventArgs e)
        {
            if (chkActivarFoto.Checked)
            {
                if (gvPromocionTemporalDetalle.RowCount > 0)
                {
                    //DataRow dr;
                    //dr = gvPromocionTemporalDetalle.GetDataRow(e.RowHandle);
                    int IdProducto = 0;

                    IdProducto = int.Parse(gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdProducto").ToString());
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

        private void elminartodotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de eliminar todo los registros?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PromocionTemporalDetalleBE ojbE_PromocionDetalle = new PromocionTemporalDetalleBE();
                ojbE_PromocionDetalle.IdPromocionTemporal = IdPromocionTemporal;
                ojbE_PromocionDetalle.Usuario = Parametros.strUsuarioLogin;
                ojbE_PromocionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                ojbE_PromocionDetalle.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue); //Parametros.intEmpresaId;


                PromocionTemporalDetalleBL ojbBL_PromocionDetalle = new PromocionTemporalDetalleBL();
                ojbBL_PromocionDetalle.EliminaTodo(ojbE_PromocionDetalle);

                mListaPromocionTemporalDetalleOrigen = new List<CPromocionTemporalDetalle>();
                CargaPromocionTemporalDetalle();
                gvPromocionTemporalDetalle.RefreshData();

                XtraMessageBox.Show("Registros eliminados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void gvPromocionTemporalDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //int intCantidad = 0;
            //decimal decCostoUnitario = 0;
            //decimal decMontoTotal = 0;

            if (e.Column.FieldName == "Descuento")
            {
                //if (int.Parse(e.Value.ToString()) > 0)
                //{

                //intCantidad = int.Parse(e.Value.ToString());
                //decMontoTotal = decimal.Parse(gvMovimientoAlmacenDetalle.GetRowCellValue(e.RowHandle, gvMovimientoAlmacenDetalle.Columns["CostoUnitario"]).ToString()) * decimal.Parse(intCantidad.ToString());
                //gvMovimientoAlmacenDetalle.SetRowCellValue(e.RowHandle, gvMovimientoAlmacenDetalle.Columns["MontoTotal"], decMontoTotal);

                ////gvPromocionTemporalDetalle.SetRowCellValue(e.RowHandle, gvPromocionTemporalDetalle.Columns["TipoOper"], 1);

                if (pOperacion == Operacion.Modificar)
                {
                    if (Convert.ToDecimal(gvPromocionTemporalDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                        gvPromocionTemporalDetalle.SetRowCellValue(e.RowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    else
                        gvPromocionTemporalDetalle.SetRowCellValue(e.RowHandle, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                }
            }
        }

        private void chkActivarFoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivarFoto.Checked)
            {
                picImage.Visible = true;
                splitContainerControl1.SplitterPosition = 988;
            }
            else
            {
                picImage.Visible = false;
                splitContainerControl1.SplitterPosition = 1330;
            }
        }

        private void gvPromocionTemporalDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvPromocionTemporalDetalle.RowCount.ToString() + " Registros encontrados";
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
            string _fileName = "ListadoPromocionTemporalDetalle";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPromocionTemporalDetalle.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void chkMayorista_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMayorista.Checked)
                chkMayorista.Font = new Font(chkMayorista.Font, FontStyle.Bold);
            else
                chkMayorista.Font = new Font(chkMayorista.Font, FontStyle.Regular);
        }

        private void chkMinorista_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMinorista.Checked)
                chkMinorista.Font = new Font(chkMinorista.Font, FontStyle.Bold);
            else
                chkMinorista.Font = new Font(chkMinorista.Font, FontStyle.Regular);
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

            //    if (mListaPromocionTemporalDetalleOrigen.Count > 0)
            //    {
            //        foreach (var item in mListaPromocionTemporalDetalleOrigen)
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

            //    lblTotalRegistros.Text = mListaPromocionTemporalDetalleOrigen.Count.ToString() + " Registros encontrados";

            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargaPromocionTemporalDetalle()
        {
            List<PromocionTemporalDetalleBE> lstTmpPromocionTemporalDetalle = null;
            lstTmpPromocionTemporalDetalle = new PromocionTemporalDetalleBL().ListaTodosActivo(IdPromocionTemporal);

            foreach (PromocionTemporalDetalleBE item in lstTmpPromocionTemporalDetalle)
            {
                CPromocionTemporalDetalle objE_PromocionTemporalDetalle = new CPromocionTemporalDetalle();
                objE_PromocionTemporalDetalle.IdPromocionTemporal = item.IdPromocionTemporal;
                objE_PromocionTemporalDetalle.IdPromocionTemporalDetalle = item.IdPromocionTemporalDetalle;
                objE_PromocionTemporalDetalle.IdProducto = item.IdProducto;
                objE_PromocionTemporalDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PromocionTemporalDetalle.NombreProducto = item.NombreProducto;
                objE_PromocionTemporalDetalle.Abreviatura = item.Abreviatura;
                objE_PromocionTemporalDetalle.Descuento = item.Descuento;
                objE_PromocionTemporalDetalle.DescuentoActual = item.DescuentoActual;
                objE_PromocionTemporalDetalle.Fecha = item.Fecha;
                objE_PromocionTemporalDetalle.CantidadCompra = item.CantidadCompra;
                objE_PromocionTemporalDetalle.AlmacenCentral = item.AlmacenCentral;
                objE_PromocionTemporalDetalle.AlmacenTienda = item.AlmacenTienda;
                objE_PromocionTemporalDetalle.AlmacenAndahuaylas = item.AlmacenAndahuaylas;
                objE_PromocionTemporalDetalle.AlmacenPrescott = item.AlmacenPrescott;
                objE_PromocionTemporalDetalle.AlmacenAviacion = item.AlmacenAviacion;
                objE_PromocionTemporalDetalle.AlmacenAviacion2 = item.AlmacenAviacion2;
                objE_PromocionTemporalDetalle.AlmacenMegaPlaza = item.AlmacenMegaPlaza;
                objE_PromocionTemporalDetalle.AlmacenSanMiguel = item.AlmacenSanMiguel;
                objE_PromocionTemporalDetalle.StockTotal = item.AlmacenCentral + item.AlmacenTienda + item.AlmacenAndahuaylas + item.AlmacenPrescott + item.AlmacenAviacion + item.AlmacenMegaPlaza + item.AlmacenAviacion2 + item.AlmacenSanMiguel;
                objE_PromocionTemporalDetalle.DescLineaProducto = item.DescLineaProducto;
                objE_PromocionTemporalDetalle.DescSubLineaProducto = item.DescSubLineaProducto;
                objE_PromocionTemporalDetalle.FlagNacional = item.FlagNacional;
                //objE_PromocionTemporalDetalle.Usuario = item.Usuario;
                //objE_PromocionTemporalDetalle.Maquina = item.Maquina;
                //objE_PromocionTemporalDetalle.FechaRegistro = item.FechaRegistro;
                //objE_PromocionTemporalDetalle.Diferencia = item.Cantidad - item.CantidadVenta;
                objE_PromocionTemporalDetalle.Precio = item.Precio;
                objE_PromocionTemporalDetalle.Precio2 = item.Precio2;
                objE_PromocionTemporalDetalle.TipoOper = item.TipoOper;
                mListaPromocionTemporalDetalleOrigen.Add(objE_PromocionTemporalDetalle);
            }

            bsListado.DataSource = mListaPromocionTemporalDetalleOrigen;
            gcPromocionTemporalDetalle.DataSource = bsListado;
            gcPromocionTemporalDetalle.RefreshDataSource();


            lblTotalRegistros.Text = mListaPromocionTemporalDetalleOrigen.Count.ToString() + " Registros encontrados";

            //CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescPromocionTemporal.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la descripción del PromocionTemporal.\n";
                flag = true;
            }

            if (mListaPromocionTemporalDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el PromocionTemporal, mientra no haya productos.\n";
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
            if (pOperacion == Operacion.Nuevo)
            {
                XtraMessageBox.Show("Debe grabar al menos un código, luego abrir e importar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int TotalAgregado = 0;
            int TotalActualizado = 0;

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


                //Recorremos los códigos de PromocionTemporal
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    decimal Descuento = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaPromocionTemporalDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            PromocionTemporalDetalleBL objBL_PromocionTemporalDetalle = new PromocionTemporalDetalleBL();
                            PromocionTemporalDetalleBE objE_PromocionTemporalDetalle = new PromocionTemporalDetalleBE();

                            objE_PromocionTemporalDetalle.IdPromocionTemporal = IdPromocionTemporal;
                            objE_PromocionTemporalDetalle.IdProducto = objE_Producto.IdProducto;
                            objE_PromocionTemporalDetalle.Descuento = Descuento;
                            objE_PromocionTemporalDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_PromocionTemporalDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_PromocionTemporalDetalle.FlagEstado = true;
                            objBL_PromocionTemporalDetalle.Actualiza(objE_PromocionTemporalDetalle);

                            TotalActualizado = TotalActualizado + 1;

                        }
                        else
                        {
                            if (pOperacion == Operacion.Nuevo)
                            {

                                gvPromocionTemporalDetalle.AddNewRow();
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdPromocionTemporalDetalle", 0);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Descuento", Descuento);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Observacion", Observacion);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "FlagEstado", true);
                                if (pOperacion == Operacion.Modificar)
                                    gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                else
                                    gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                                TotalAgregado = TotalAgregado + 1;
                            }
                            else
                            {
                                PromocionTemporalDetalleBL objBL_PromocionTemporalDetalle = new PromocionTemporalDetalleBL();
                                PromocionTemporalDetalleBE objE_PromocionTemporalDetalle = new PromocionTemporalDetalleBE();

                                objE_PromocionTemporalDetalle.IdPromocionTemporal = IdPromocionTemporal;
                                objE_PromocionTemporalDetalle.IdProducto = objE_Producto.IdProducto;
                                objE_PromocionTemporalDetalle.Descuento = Descuento;
                                objE_PromocionTemporalDetalle.Usuario = Parametros.strUsuarioLogin;
                                objE_PromocionTemporalDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_PromocionTemporalDetalle.FlagEstado = true;
                                objBL_PromocionTemporalDetalle.Inserta(objE_PromocionTemporalDetalle);

                                TotalAgregado = TotalAgregado + 1;
                            }
                        }
                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_PromocionTemporalDetalle = new PreventaDetalleBE();
                        ObjE_PromocionTemporalDetalle.CodigoProveedor = CodigoProveedor;
                        //ObjE_PromocionTemporalDetalle.Cantidad = Cantidad;
                        lst_PromocionTemporalDetalleMsg.Add(ObjE_PromocionTemporalDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvPromocionTemporalDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_PromocionTemporalDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_PromocionTemporalDetalleMsg;
                    frm.ShowDialog();
                }

                XtraMessageBox.Show("La Importacion se realizó correctamente\n" + TotalActualizado + " registros actualizados.\n" + TotalAgregado + " registros Insertados.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                if (pOperacion == Operacion.Modificar)
                {
                    this.Close();
                }
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
            if (pOperacion == Operacion.Nuevo)
            {
                XtraMessageBox.Show("Debe grabar al menos un código, luego abrir e importar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int TotalAgregado = 0;
            int TotalActualizado = 0;

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


                //Recorremos los códigos de PromocionTemporal
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    //string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int IdProducto = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    decimal Descuento = Convert.ToDecimal((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    //string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    //string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaPromocionTemporalDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            PromocionTemporalDetalleBL objBL_PromocionTemporalDetalle = new PromocionTemporalDetalleBL();
                            PromocionTemporalDetalleBE objE_PromocionTemporalDetalle = new PromocionTemporalDetalleBE();

                            objE_PromocionTemporalDetalle.IdPromocionTemporal = IdPromocionTemporal;
                            objE_PromocionTemporalDetalle.IdProducto = objE_Producto.IdProducto;
                            objE_PromocionTemporalDetalle.Descuento = Descuento;
                            objE_PromocionTemporalDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_PromocionTemporalDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_PromocionTemporalDetalle.FlagEstado = true;
                            objBL_PromocionTemporalDetalle.Actualiza(objE_PromocionTemporalDetalle);

                            TotalActualizado = TotalActualizado + 1;
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            if (pOperacion == Operacion.Nuevo)
                            {
                                gvPromocionTemporalDetalle.AddNewRow();
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdPromocionTemporalDetalle", 0);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Descuento", Descuento);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Observacion", Observacion);
                                //gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                                gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "FlagEstado", true);
                                if (pOperacion == Operacion.Modificar)
                                    gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                                else
                                    gvPromocionTemporalDetalle.SetRowCellValue(gvPromocionTemporalDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                                TotalAgregado = TotalAgregado + 1;

                            }
                            else
                            {
                                PromocionTemporalDetalleBL objBL_PromocionTemporalDetalle = new PromocionTemporalDetalleBL();
                                PromocionTemporalDetalleBE objE_PromocionTemporalDetalle = new PromocionTemporalDetalleBE();

                                objE_PromocionTemporalDetalle.IdPromocionTemporal = IdPromocionTemporal;
                                objE_PromocionTemporalDetalle.IdProducto = objE_Producto.IdProducto;
                                objE_PromocionTemporalDetalle.Descuento = Descuento;
                                objE_PromocionTemporalDetalle.Usuario = Parametros.strUsuarioLogin;
                                objE_PromocionTemporalDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_PromocionTemporalDetalle.FlagEstado = true;
                                objBL_PromocionTemporalDetalle.Inserta(objE_PromocionTemporalDetalle);

                                TotalAgregado = TotalAgregado + 1;
                            }


                        }

                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_PromocionTemporalDetalle = new PreventaDetalleBE();
                        ObjE_PromocionTemporalDetalle.CodigoProveedor = IdProducto.ToString();
                        //ObjE_PromocionTemporalDetalle.Cantidad = Cantidad;
                        lst_PromocionTemporalDetalleMsg.Add(ObjE_PromocionTemporalDetalle);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblTotalRegistros.Text = gvPromocionTemporalDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_PromocionTemporalDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_PromocionTemporalDetalleMsg;
                    frm.ShowDialog();
                }

                //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                XtraMessageBox.Show("La Importacion se realizó correctamente\n" + TotalActualizado + " registros actualizados.\n" + TotalAgregado + " registros Insertados.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                if (pOperacion == Operacion.Modificar)
                {
                    this.Close();
                }

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

            //dt = FuncionBase.ToDataTable(mListaPromocionTemporalDetalleOrigen);//new PromocionTemporalDetalleBL().ListaTodosActivo(IdPromocionTemporal));
            //gcPromocionTemporalDetalle.DataSource = dt;

            //if (gvPromocionTemporalDetalle.RowCount > 0)
            //{
            //    ProductoBE objE_Producto = null;
            //    int IdProducto = 0;
            //    IdProducto = int.Parse(gvPromocionTemporalDetalle.GetFocusedRowCellValue("IdProducto").ToString());

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

        private void BloquearAccesoPorPerfil()
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador
                || Parametros.intPerfilId == Parametros.intPerAsistenteCompras || Parametros.intPerfilId == Parametros.intPerAnalistaProducto || Parametros.intPerfilId == Parametros.intPerAuxiliarVisual || Parametros.intPerfilId == Parametros.intPerCoordinadorVisualCentral)
            {
                mnuContextual.Visible = true;
                btnGrabar.Visible = true;
            }
            else
            {
                mnuContextual.Visible = false;
                btnGrabar.Visible = false;
            }


        }
        #endregion

        public class CPromocionTemporalDetalle
        {
            public Int32 IdPromocionTemporal { get; set; }
            public Int32 IdPromocionTemporalDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public DateTime Fecha { get; set; }
            public DateTime FechaRegistro { get; set; }
            public String Usuario { get; set; }
            public String Maquina { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal DescuentoActual { get; set; }
            //public Int32 Cantidad { get; set; }
            //public Int32 CantidadVenta { get; set; }
            //public Int32 Diferencia { get; set; }
            public Decimal Precio { get; set; }
            public Decimal Precio2 { get; set; }

            public Int32 CantidadCompra { get; set; }
            public Int32 AlmacenCentral { get; set; }
            public Int32 AlmacenTienda { get; set; }
            public Int32 AlmacenAndahuaylas { get; set; }
            public Int32 AlmacenPrescott { get; set; }
            public Int32 AlmacenAviacion { get; set; }
            public Int32 AlmacenAviacion2 { get; set; }
            public Int32 AlmacenSanMiguel { get; set; }
            public Int32 AlmacenMegaPlaza { get; set; }
            public Int32 StockTotal { get; set; }

            public String DescLineaProducto { get; set; }
            public String DescSubLineaProducto { get; set; }
            public Boolean FlagNacional { get; set; }

            public Int32 TipoOper { get; set; }

            public CPromocionTemporalDetalle()
            {

            }
        }
    }
}