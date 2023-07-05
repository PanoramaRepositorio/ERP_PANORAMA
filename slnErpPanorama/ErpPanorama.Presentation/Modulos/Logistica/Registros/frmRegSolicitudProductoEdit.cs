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
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Consultas;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ErpPanorama.Presentation.Modulos.Logistica.Rpt;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegSolicitudProductoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<SolicitudProductoBE> lstSolicitudProducto;

        public List<CSolicitudProductoDetalle> mListaSolicitudProductoDetalleOrigen = new List<CSolicitudProductoDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdSolicitudProducto = 0;

        public int IdSolicitudProducto
        {
            get { return _IdSolicitudProducto; }
            set { _IdSolicitudProducto = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegSolicitudProductoEdit()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudProductoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTiendaOrigen, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModLogistica,0), "CodTipoDocumento", "IdTipoDocumento", false);
            cboDocumento.EditValue = Parametros.intTipoDocSolicitudProducto;
            BSUtils.LoaderLook(cboTiendaDestino, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTiendaDestino.EditValue = Parametros.intTiendaId;

            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
           // cboVendedor.EditValue = Parametros.intPersonaId;

            BSUtils.LoaderLook(cboCausal, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCausal), "DescTablaElemento", "IdTablaElemento", true);
            cboCausal.EditValue = Parametros.intNinguno;


            tmrNumero.Enabled = true;
            tmrNumero.Interval = 1000;
            ObtenerCorrelativo();
            txtSolicitante.Text = Parametros.strUsuarioNombres;
            deFecha.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Solicitud Producto - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Solicitud Producto - Modificar";

                SolicitudProductoBE objE_SolicitudProducto = null;
                objE_SolicitudProducto = new SolicitudProductoBL().Selecciona(Parametros.intEmpresaId, IdSolicitudProducto);

                IdSolicitudProducto = objE_SolicitudProducto.IdSolicitudProducto;
                cboDocumento.EditValue = objE_SolicitudProducto.IdTipoDocumento;
                txtNumero.Text = objE_SolicitudProducto.Numero;
                deFecha.EditValue = objE_SolicitudProducto.FechaSolicitud;
                txtSolicitante.Text = objE_SolicitudProducto.Solicitante;
                cboTiendaOrigen.EditValue = objE_SolicitudProducto.IdTiendaOrigen;
                cboAlmacen.EditValue = objE_SolicitudProducto.IdAlmacenOrigen;
                cboTiendaDestino.EditValue = objE_SolicitudProducto.IdTiendaDestino;
                cboAlmacenDestino.EditValue = objE_SolicitudProducto.IdAlmacenDestino;
                txtObservaciones.Text = objE_SolicitudProducto.Observacion;
                cboCausal.EditValue = objE_SolicitudProducto.IdCausalTransferencia;
                txtDocRef.Text = objE_SolicitudProducto.DocReferencia;
                cboVendedor.EditValue = objE_SolicitudProducto.IdVendedor;
            }

            deFecha.Focus();

            CargaSolicitudProductoDetalle();
            
        }

        private void cboTiendaOrigen_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTiendaOrigen.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivoPrincipal(Parametros.intEmpresaId, Convert.ToInt32(cboTiendaOrigen.EditValue)), "DescAlmacen", "IdAlmacen", true);
            }
        }

        private void cboTiendaDestino_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTiendaDestino.EditValue != null)
            {
                // Nuevas restricciones de acuerdo al perfil
                if (Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.intPerfilId == Parametros.intPerAnalistaInventario || Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                    BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivoPerfil(Parametros.intEmpresaId, Convert.ToInt32(cboTiendaDestino.EditValue), Parametros.intPerfilId), "DescAlmacen", "IdAlmacen", true);
                }
                else if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeMarketingPublicidad || Parametros.intPerfilId == Parametros.intPerAsistenteMarketing
                    || Parametros.intPerfilId == Parametros.intPerJefeProduccion
                        || Parametros.intPerfilId == Parametros.intPerJefeProduccion1)
                {
                    BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivoPrincipalMar(Parametros.intEmpresaId, Convert.ToInt32(cboTiendaDestino.EditValue)), "DescAlmacen", "IdAlmacen", true);
                }
                else //los demas almacen
                {
                    BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaAlmacenesTodosActivos(Parametros.intEmpresaId, Convert.ToInt32(cboTiendaDestino.EditValue)), "DescAlmacen", "IdAlmacen", true);
                }


              //  BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivoPrincipal(Parametros.intEmpresaId, Convert.ToInt32(cboTiendaDestino.EditValue)), "DescAlmacen", "IdAlmacen", true);

                if (Convert.ToInt32(cboTiendaDestino.EditValue) == Parametros.intTiendaUcayali)
                {
                    cboAlmacenDestino.EditValue = Parametros.intAlmTiendaUcayali;
                }
                else if (Convert.ToInt32(cboTiendaDestino.EditValue) == Parametros.intTiendaPrescott)
                {
                    cboAlmacenDestino.EditValue = Parametros.intAlmTiendaPrescott;
                }
                else if (Convert.ToInt32(cboTiendaDestino.EditValue) == Parametros.intTiendaAndahuaylas)
                {
                    cboAlmacenDestino.EditValue = Parametros.intAlmTiendaAndahuaylas;
                }
                else if (Convert.ToInt32(cboTiendaDestino.EditValue) == Parametros.intTiendaAviacion2)
                {
                    cboAlmacenDestino.EditValue = Parametros.intAlmTiendaAviacion2;
                }
                else if (Convert.ToInt32(cboTiendaDestino.EditValue) == Parametros.intTiendaSanMiguel)
                {
                    cboAlmacenDestino.EditValue = Parametros.intAlmTiendaSanMiguel;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(cboCausal.EditValue) == Parametros.intFaltanteFisico || 
                    Convert.ToInt32(cboCausal.EditValue) == Parametros.intPedidoVenta    ||
                    Convert.ToInt32(cboCausal.EditValue) == Parametros.intSobranteFisico) && txtDocRef.Text.Trim()=="")
                {
                    XtraMessageBox.Show("Ingrese el documento de referencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    txtDocRef.Focus();
                }


                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    SolicitudProductoBL objBL_SolicitudProducto = new SolicitudProductoBL();
                    SolicitudProductoBE objSolicitudProducto = new SolicitudProductoBE();

                    objSolicitudProducto.IdSolicitudProducto = IdSolicitudProducto;
                    objSolicitudProducto.Periodo = Parametros.intPeriodo;
                    objSolicitudProducto.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objSolicitudProducto.Numero = txtNumero.Text;
                    objSolicitudProducto.FechaSolicitud = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objSolicitudProducto.IdSolicitante = Parametros.intPersonaId;
                    objSolicitudProducto.IdAlmacenOrigen = Convert.ToInt32(cboAlmacen.EditValue);
                    objSolicitudProducto.IdTiendaDestino = Convert.ToInt32(cboTiendaDestino.EditValue);
                    objSolicitudProducto.IdAlmacenDestino = Convert.ToInt32(cboAlmacenDestino.EditValue);
                    objSolicitudProducto.Observacion = txtObservaciones.Text;
                    objSolicitudProducto.FechaEnvio = null;
                    objSolicitudProducto.FlagEnviado = false;
                    objSolicitudProducto.FlagEstado = true;
                    objSolicitudProducto.Usuario = Parametros.strUsuarioLogin;
                    objSolicitudProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objSolicitudProducto.IdEmpresa = Parametros.intEmpresaId;

                    objSolicitudProducto.IdCausalTransferencia = Convert.ToInt32(cboCausal.EditValue);
                    objSolicitudProducto.DocReferencia = txtDocRef.Text.Trim();
                    objSolicitudProducto.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);

                    //Solciitud Producto Detalle
                    List<SolicitudProductoDetalleBE> lstSolicitudProductoDetalle = new List<SolicitudProductoDetalleBE>();

                    foreach (var item in mListaSolicitudProductoDetalleOrigen)
                    {
                        if (item.IdProducto > 0)
                        { 
                            SolicitudProductoDetalleBE objE_SolicitudProductoDetalle = new SolicitudProductoDetalleBE();
                            objE_SolicitudProductoDetalle.IdSolicitudProductoDetalle = item.IdSolicitudProductoDetalle;
                            objE_SolicitudProductoDetalle.IdEmpresa = Parametros.intEmpresaId;
                            objE_SolicitudProductoDetalle.IdSolicitudProducto = IdSolicitudProducto;
                            objE_SolicitudProductoDetalle.Item = item.Item;
                            objE_SolicitudProductoDetalle.IdProducto = item.IdProducto;
                            objE_SolicitudProductoDetalle.Cantidad = Convert.ToInt32(item.Cantidad);
                            objE_SolicitudProductoDetalle.Observacion = item.Observacion;
                            objE_SolicitudProductoDetalle.CostoUnitario = item.CostoUnitario;
                            objE_SolicitudProductoDetalle.MontoTotal = item.MontoTotal;
                            objE_SolicitudProductoDetalle.FlagEstado = true;
                            objE_SolicitudProductoDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_SolicitudProductoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_SolicitudProductoDetalle.TipoOper = item.TipoOper;
                            lstSolicitudProductoDetalle.Add(objE_SolicitudProductoDetalle);                        
                        }
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_SolicitudProducto.Inserta(objSolicitudProducto, lstSolicitudProductoDetalle);
                        //IdSolicitudProducto
                        //objSolicitudProducto.IdSolicitudProducto = IdSolicitudProducto;
                        //objSolicitudProducto.FlagEnviado = true;
                        //objBL_SolicitudProducto.ActualizaEnvio(objSolicitudProducto);
                        //objBL_SolicitudProducto.ActualizaFechaImpresion(objSolicitudProducto);


                        //ImpresionSolicitudProducto(IdSolicitudProducto);
                    }
                    else
                    {
                        objBL_SolicitudProducto.Actualiza(objSolicitudProducto, lstSolicitudProductoDetalle);
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

        private void ImpresionSolicitudProducto(int IdSolicitudProducto)
        {

            if (Parametros.intTiendaId != Parametros.intTiendaUcayali)
            {
                List<ReporteSolicitudProductoBE> lstReporte = null;
                lstReporte = new ReporteSolicitudProductoBL().Listado(Parametros.intEmpresaId, IdSolicitudProducto);

                #region "Codigo Barras"
                iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                bc.TextAlignment = Element.ALIGN_LEFT;
                bc.Code = lstReporte[0].Numero;
                bc.StartStopText = false;
                bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                bc.Extended = true;
                bc.BarHeight = 27;
                lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                #endregion

                if (lstReporte.Count > 0)
                {
                    rptSolicitudProducto1 objReporteGuia = new rptSolicitudProducto1();
                    objReporteGuia.SetDataSource(lstReporte);

                    #region "Buscar Impresora ..."
                    bool found = false;
                    PrinterSettings prtSetting = new PrinterSettings();
                    foreach (string prtName in PrinterSettings.InstalledPrinters)
                    {
                        string printer = "";
                        if (prtName.StartsWith("\\\\"))
                        {
                            printer = prtName.Substring(3);
                            printer = printer.Substring(printer.IndexOf("\\") + 1);
                        }
                        else
                            printer = prtName;

                        if (printer.ToUpper().StartsWith("(SP)"))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            break;
                        }
                    }

                    if (!found)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("La impresora (SP) Nombre para Solicitud de Producto no ha sido encontrada.");
                        return;
                    }
                    //Actualiza Impresión
                    ////objBL_Pedido.ActualizaImpresion(IdPedido, true);

                    //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    MessageBox.Show("La Solicitud se imprimió correctamente");// se envió a  + prtName);
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Llamar a la tienda solicitado para la impresion de la Solicitud de Producto");
            }


        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvSolicitudProductoDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int intCantidad = 0;
            decimal decMontoTotal = 0;

            if (e.Column.Caption == "Cantidad")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intCantidad = int.Parse(e.Value.ToString());
                    decMontoTotal = decimal.Parse(gvSolicitudProductoDetalle.GetRowCellValue(e.RowHandle, gvSolicitudProductoDetalle.Columns["CostoUnitario"]).ToString()) * decimal.Parse(intCantidad.ToString());
                    gvSolicitudProductoDetalle.SetRowCellValue(e.RowHandle, gvSolicitudProductoDetalle.Columns["MontoTotal"], decMontoTotal);
                }
               // tsmMenuAgregar_Click(sender, e);
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

        private void gvSolicitudProductoDetalle_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //if (e.Value != null)
            //{
            //    if (e.Value.ToString().Trim().Length > 0)
            //    {
            //        GridView view = sender as GridView;
            //        if (view.FocusedColumn.FieldName == "Cantidad")
            //        {
            //            object Stock = gvSolicitudProductoDetalle.GetFocusedRowCellValue("Stock");
            //            if (int.Parse(e.Value.ToString()) > Convert.ToInt32(Stock))
            //            {
            //                e.Valid = false;
            //                e.ErrorText = "La cantidad solicitada es mayor al stock" + "\n Stock : " + Stock.ToString();
            //            }
            //        }
            //    }
            //}
        }

        private void gcTxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //string CodigoProveedor = (sender as TextEdit).Text;
                    //ErpPanoramaServicios.StockBE ProductoBE = new ErpPanoramaServicios.StockBE();
                    //ProductoBE = objServicio.Stock_SeleccionaProductoPrecio(Parametros.intTiendaUcayali, CodigoProveedor);
                    //if (ProductoBE == null)
                    //{
                    //    XtraMessageBox.Show("El código de Producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    gvSolicitudProductoDetalle.FocusedColumn = gvSolicitudProductoDetalle.GetVisibleColumn(0);
                    //    gvSolicitudProductoDetalle.ShowEditor();
                    //}
                    //else
                    //{
                    //    if (mListaSolicitudProductoDetalleOrigen.Count > 1)
                    //    {
                    //        var BuscarDocumento = mListaSolicitudProductoDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == CodigoProveedor).ToList();
                    //        if (BuscarDocumento.Count > 0)
                    //        {
                    //            XtraMessageBox.Show("El Código de producto ya existe en la lista, por favor verifique." + "\n Código : " + CodigoProveedor, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            gvSolicitudProductoDetalle.FocusedColumn = gvSolicitudProductoDetalle.GetVisibleColumn(0);
                    //            gvSolicitudProductoDetalle.ShowEditor();
                    //            return;
                    //        }
                    //    }

                    //    int index = gvSolicitudProductoDetalle.FocusedRowHandle;
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "IdProducto", ProductoBE.IdProducto);
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "CodigoProveedor", ProductoBE.CodigoProveedor);
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "NombreProducto", ProductoBE.NombreProducto);
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "Abreviatura", ProductoBE.Abreviatura);
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "DescUbicacion", ProductoBE.DescUbicacion);
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "Stock", 0);
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "Cantidad", 1);
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "CostoUnitario", ProductoBE.PrecioABSoles);
                    //    gvSolicitudProductoDetalle.SetRowCellValue(index, "MontoTotal", ProductoBE.PrecioABSoles);

                    //    gvSolicitudProductoDetalle.FocusedRowHandle = index;
                    //    gvSolicitudProductoDetalle.FocusedColumn = gvSolicitudProductoDetalle.GetVisibleColumn(5);
                    //    gvSolicitudProductoDetalle.ShowEditor();
                    //}

                    frmBusProductoCosto objBusProducto = new frmBusProductoCosto();
                    objBusProducto.pDescripcion = (sender as TextEdit).Text;
                    objBusProducto.ShowDialog();
                    if (objBusProducto.pProductoBE != null)
                    {
                        if (mListaSolicitudProductoDetalleOrigen.Count > 1)
                        {
                            var BuscarDocumento = mListaSolicitudProductoDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == objBusProducto.pProductoBE.CodigoProveedor).ToList();
                            if (BuscarDocumento.Count > 0)
                            {
                                XtraMessageBox.Show("El Código de producto ya existe en la lista, por favor verifique." + "\n Código : " + objBusProducto.pProductoBE.CodigoProveedor, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ColumRowFocus((sender as TextEdit).Text, "CodigoProveedor");
                                return;
                            }
                        }

                        int index = gvSolicitudProductoDetalle.FocusedRowHandle;
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "IdProducto", objBusProducto.pProductoBE.IdProducto);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "CodigoProveedor", objBusProducto.pProductoBE.CodigoProveedor);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "NombreProducto", objBusProducto.pProductoBE.NombreProducto);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "Medida", objBusProducto.pProductoBE.Medida);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "Abreviatura", objBusProducto.pProductoBE.Abreviatura);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "DescUbicacion", objBusProducto.pProductoBE.DescUbicacion);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "Stock", 0);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "Cantidad", 1);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "CostoUnitario", objBusProducto.pProductoBE.CostoUnitario);
                        gvSolicitudProductoDetalle.SetRowCellValue(index, "MontoTotal", objBusProducto.pProductoBE.CostoUnitario);

                        ColumRowFocusCantidad(objBusProducto.pProductoBE.CodigoProveedor, "CodigoProveedor");
                       
                    }
                
                }

                if (e.KeyCode == Keys.F1)
                {
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvSolicitudProductoDetalle.AddNewRow();
                gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "Item", (mListaSolicitudProductoDetalleOrigen.Count - 1) + 1);
                gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "CodigoProveedor", "");
                if (pOperacion == Operacion.Modificar)
                {
                    gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "IdSolicitudProductoDetalle", 0);
                    gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "Stock", 0);
                    gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                }
                else
                {
                    gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "IdSolicitudProductoDetalle", 0);
                    gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "Stock", 0);
                    gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                }
                gvSolicitudProductoDetalle.FocusedColumn = gvSolicitudProductoDetalle.Columns["CodigoProveedor"];
                gvSolicitudProductoDetalle.ShowEditor();

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
                int IdSolicitudProductoDetalle = 0;
                int IdProducto = 0;
                IdSolicitudProductoDetalle = int.Parse(gvSolicitudProductoDetalle.GetFocusedRowCellValue("IdSolicitudProductoDetalle").ToString());
                IdProducto = int.Parse(gvSolicitudProductoDetalle.GetFocusedRowCellValue("IdProducto").ToString());
                int Item = 0;
                Item = int.Parse(gvSolicitudProductoDetalle.GetFocusedRowCellValue("Item").ToString());
                SolicitudProductoDetalleBE objBE_SolicitudProductoDetalle = new SolicitudProductoDetalleBE();
                objBE_SolicitudProductoDetalle.IdSolicitudProductoDetalle = IdSolicitudProductoDetalle;
                objBE_SolicitudProductoDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_SolicitudProductoDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_SolicitudProductoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                if (IdProducto > 0)
                { 
                    SolicitudProductoDetalleBL objBL_SolicitudProductoDetalle = new SolicitudProductoDetalleBL();
                    objBL_SolicitudProductoDetalle.Elimina(objBE_SolicitudProductoDetalle);                
                }
                gvSolicitudProductoDetalle.DeleteRow(gvSolicitudProductoDetalle.FocusedRowHandle);
                gvSolicitudProductoDetalle.RefreshData();

                //RegeneraItem
                int i = 0;
                int cuenta = 0;
                foreach (var item in mListaSolicitudProductoDetalleOrigen)
                {
                    item.Item = Convert.ToByte(cuenta + 1);
                    cuenta++;
                    i++;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrNumero_Tick(object sender, EventArgs e)
        {
            //Obtener el correlativo del documento
            if (pOperacion == Operacion.Nuevo)
                ObtenerCorrelativo();
        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {
            frmConUbicacionProducto frmUbica = new frmConUbicacionProducto();
            frmUbica.Show();
        }

        #endregion

        #region "Metodos"

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocSolicitudProducto, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                txtNumero.Text = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboAlmacen.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el almacen de anaqueles.\n";
                flag = true;
            }

            if (txtNumero.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número del deocumento.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var BuscarDocumento = lstSolicitudProducto.Where(oB => oB.Numero.ToUpper() == txtNumero.Text.ToUpper()).ToList();
                if (BuscarDocumento.Count > 0)
                {
                    strMensaje = strMensaje + "- El número de documento ya existe.\n";
                    flag = true;
                }
            }

            foreach (CSolicitudProductoDetalle item in mListaSolicitudProductoDetalleOrigen)
            {
                var BuscarCodigo = mListaSolicitudProductoDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == item.CodigoProveedor.ToUpper()).ToList();
                if (BuscarCodigo.Count > 1)
                {
                    strMensaje = strMensaje + "- El código "+ item.CodigoProveedor +" de producto se repite.\nEliminar registros en Blanco\n";
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

        private void ColumRowFocus(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcSolicitudProductoDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvSolicitudProductoDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = column;
                }
            }

        }

        private void ColumRowFocusCantidad(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcSolicitudProductoDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            GridColumn columnbus = View.Columns["Cantidad"];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvSolicitudProductoDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = columnbus;
                }
            }

        }

        private void CargaSolicitudProductoDetalle()
        {
            List<SolicitudProductoDetalleBE> lstTmpSolicitudProductoDetalle = null;
            lstTmpSolicitudProductoDetalle = new SolicitudProductoDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdSolicitudProducto);

            mListaSolicitudProductoDetalleOrigen = new List<CSolicitudProductoDetalle>();

            foreach (SolicitudProductoDetalleBE item in lstTmpSolicitudProductoDetalle)
            {
                CSolicitudProductoDetalle objE_SolicitudProductoDetalle = new CSolicitudProductoDetalle();
                objE_SolicitudProductoDetalle.IdEmpresa = item.IdEmpresa;
                objE_SolicitudProductoDetalle.IdSolicitudProducto = item.IdSolicitudProducto;
                objE_SolicitudProductoDetalle.IdSolicitudProductoDetalle = item.IdSolicitudProductoDetalle;
                objE_SolicitudProductoDetalle.Item = item.Item;
                objE_SolicitudProductoDetalle.IdProducto = item.IdProducto;
                objE_SolicitudProductoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_SolicitudProductoDetalle.NombreProducto = item.NombreProducto;
                objE_SolicitudProductoDetalle.Medida = item.Medida;
                objE_SolicitudProductoDetalle.Abreviatura = item.Abreviatura;
                objE_SolicitudProductoDetalle.DescUbicacion = item.DescUbicacion;
                objE_SolicitudProductoDetalle.Cantidad = item.Cantidad;
                objE_SolicitudProductoDetalle.Observacion = item.Observacion;
                objE_SolicitudProductoDetalle.CostoUnitario = item.CostoUnitario;
                objE_SolicitudProductoDetalle.MontoTotal = item.MontoTotal;
                objE_SolicitudProductoDetalle.TipoOper = item.TipoOper;
                mListaSolicitudProductoDetalleOrigen.Add(objE_SolicitudProductoDetalle);
            }

            bsListado.DataSource = mListaSolicitudProductoDetalleOrigen;
            gcSolicitudProductoDetalle.DataSource = bsListado;
            gcSolicitudProductoDetalle.RefreshDataSource();
        }

        //private void CargaVendedor()
        //{
        //    SolicitudProductoBE objE_SolicitudProducto = null;
        //    objE_SolicitudProducto = new SolicitudProductoBL().SeleccionaVendedor(DateTime.Now.Year, txtDocRef.Text.Trim());

        //    cboVendedor.EditValue = objE_SolicitudProducto.IdVendedor;
        //}
        #endregion

        public class CSolicitudProductoDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdSolicitudProducto { get; set; }
            public Int32 IdSolicitudProductoDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Medida { get; set; }
            public String Abreviatura { get; set; }
            public byte[] Imagen { get; set; }
            public String DescUbicacion { get; set; }
            public Decimal Cantidad { get; set; }
            public String Observacion { get; set; }
            public Decimal CostoUnitario { get; set; }
            public Decimal MontoTotal { get; set; }
            public Int32 Stock { get; set; }
            public Int32 TipoOper { get; set; }

            public CSolicitudProductoDetalle()
            {

            }
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
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
                //prgFactura.Properties.Step = 1;
                //prgFactura.Properties.Maximum = TotRow;
                //prgFactura.Properties.Minimum = 0;

                //Recorremos para la Nota de Salida
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedorInventario(CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        gvSolicitudProductoDetalle.AddNewRow();
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "IdMovimientoAlmacen", 0);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "IdSolicitudProductoDetalle", 0);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "Item", (mListaSolicitudProductoDetalleOrigen.Count - 1) + 1);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "CostoUnitario", 0);
                        gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "MontoTotal", 0);
                        if (pOperacion == Operacion.Modificar)
                            gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvSolicitudProductoDetalle.SetRowCellValue(gvSolicitudProductoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    }
                    else
                    {
                        XtraMessageBox.Show("El código " + CodigoProveedor + "No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                    }


                    //prgFactura.PerformStep();
                    //prgFactura.Update();

                    Row++;
                }

                //EncuestaBL objBL_Encuesta = new EncuestaBL();
                //objBL_Encuesta.InsertaLista(mEncuesta);

                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void chkMostrarFoto_CheckedChanged(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Si Ud. modificó los datos. Asegúrate de grabar antes de cambiar entre una opción y otra, desea continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (chkMostrarFoto.Checked)
                {
                    CargarFoto();
                    gridColumn5.Visible = true;
                    gvSolicitudProductoDetalle.RowHeight = 75;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    CargaSolicitudProductoDetalle();
                    gridColumn5.Visible = false;
                    gvSolicitudProductoDetalle.RowHeight = -1;
                }
            }
        }

        private void CargarFoto()
        {
            List<SolicitudProductoDetalleBE> lstTmpSolicitudProductoDetalle = null;
            lstTmpSolicitudProductoDetalle = new SolicitudProductoDetalleBL().ListaTodosImagen(Parametros.intEmpresaId, IdSolicitudProducto);

            mListaSolicitudProductoDetalleOrigen = new List<CSolicitudProductoDetalle>();

            foreach (SolicitudProductoDetalleBE item in lstTmpSolicitudProductoDetalle)
            {
                CSolicitudProductoDetalle objE_SolicitudProductoDetalle = new CSolicitudProductoDetalle();
                objE_SolicitudProductoDetalle.IdEmpresa = item.IdEmpresa;
                objE_SolicitudProductoDetalle.IdSolicitudProducto = item.IdSolicitudProducto;
                objE_SolicitudProductoDetalle.IdSolicitudProductoDetalle = item.IdSolicitudProductoDetalle;
                objE_SolicitudProductoDetalle.Item = item.Item;
                objE_SolicitudProductoDetalle.IdProducto = item.IdProducto;
                objE_SolicitudProductoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_SolicitudProductoDetalle.NombreProducto = item.NombreProducto;
                objE_SolicitudProductoDetalle.Abreviatura = item.Abreviatura;
                objE_SolicitudProductoDetalle.Imagen = item.Imagen;
                objE_SolicitudProductoDetalle.DescUbicacion = item.DescUbicacion;
                objE_SolicitudProductoDetalle.Cantidad = item.Cantidad;
                objE_SolicitudProductoDetalle.Observacion = item.Observacion;
                objE_SolicitudProductoDetalle.CostoUnitario = item.CostoUnitario;
                objE_SolicitudProductoDetalle.MontoTotal = item.MontoTotal;
                objE_SolicitudProductoDetalle.TipoOper = item.TipoOper;
                mListaSolicitudProductoDetalleOrigen.Add(objE_SolicitudProductoDetalle);
            }

            bsListado.DataSource = mListaSolicitudProductoDetalleOrigen;
            gcSolicitudProductoDetalle.DataSource = bsListado;
            gcSolicitudProductoDetalle.RefreshDataSource();

        }

        private void cboCausal_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTiendaDestino.EditValue != null)
            {
                if (Convert.ToInt32(cboCausal.EditValue) == Parametros.intFaltanteFisico)
                {
                    lblTexto.Text = "N/S de Referencia:";
                    txtDocRef.Text = "";

                    lblTexto.Visible = true;
                    txtDocRef.Visible = true;
                    txtDocRef.Properties.MaxLength = 6;

                    lblVendedor.Visible = false;
                    cboVendedor.Visible = false;

                    txtDocRef.Focus();
                }
                else if (Convert.ToInt32(cboCausal.EditValue) == Parametros.intPedidoVenta)
                {
                    lblTexto.Text = "N° Pedido Referencia:";
                    txtDocRef.Text = "";

                    lblTexto.Visible = true;
                    txtDocRef.Visible = true;
                    txtDocRef.Properties.MaxLength = 7;
                    lblVendedor.Visible = true;
                    cboVendedor.Visible = true;
                    txtDocRef.Focus();
                }
                else if (Convert.ToInt32(cboCausal.EditValue) == Parametros.intSobranteFisico)
                {
                    lblTexto.Text = "N/S de Referencia:";
                    txtDocRef.Text = "";

                    lblTexto.Visible = true;
                    txtDocRef.Visible = true;
                    txtDocRef.Properties.MaxLength = 6;

                    lblVendedor.Visible = false;
                    cboVendedor.Visible = false;

                    txtDocRef.Focus();
                }
                else  
                {
                    lblTexto.Visible = false;
                    txtDocRef.Visible = false;
                    lblVendedor.Visible = false;
                    cboVendedor.Visible = false;
                }

            }
        }

        private void txtDocRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (cboCausal.Text)
                {
                    case "PEDIDO DE VENTA":
                        SolicitudProductoBE objE_SolicitudProducto = null;
                        objE_SolicitudProducto = new SolicitudProductoBL().SeleccionaVendedor(DateTime.Now.Year, txtDocRef.Text.Trim());

                        if (objE_SolicitudProducto != null)
                        {
                            cboVendedor.EditValue = objE_SolicitudProducto.IdVendedor;
                        }
                        else
                        {
                            XtraMessageBox.Show("Numero de pedido no encontrado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        cboVendedor.Visible = true;
                        lblVendedor.Visible = true;
                        gcSolicitudProductoDetalle.Select();
                        // CargaVendedor(DateTime.Now.Year, txtDocRef.Text.ToString().Trim());
                        break;
                        //case "N/S":
                        //    CargaNotaSalidaDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        //    break;
                        //case "N/I":
                        //    CargaNotaIngresoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        //    break;
                        //case "FAC":
                        //    CargaFacturaCompra(txtNumeroDocumento.Text.ToString().Trim());
                        //    break;
                        //case "PED":
                    //    CargaPedidoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                    //    break;
                    //break;
                    default:
                        cboVendedor.Visible = false;
                        lblVendedor.Visible = false;
                        gcSolicitudProductoDetalle.Select();

                        break;
                }
            }
        }
    }
}