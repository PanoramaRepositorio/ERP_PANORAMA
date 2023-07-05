using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PedidoBE> mLista = new List<PedidoBE>();
        
        #endregion

        #region "Eventos"

        public frmRegPedido()
        {
            InitializeComponent();
        }

        private void frmRegPedido_Load(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin == "master"  || Parametros.strUsuarioLogin == "ygomez" || Parametros.strUsuarioLogin == "mmurrugarra")
            {
                txtNumero.Visible = true;
                txtperiodo.Visible = true;
                labelControl7.Visible = true;
                labelControl6.Visible = true;
                labelControl8.Visible = true;
                btnRegCliente.Visible = true;
            }


            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboVendedor, new  PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);
            txtperiodo.Text = Convert.ToString(DateTime.Now.Year);

        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegPedidoEdit objManPedidol = new frmRegPedidoEdit();
                objManPedidol.pOperacion = frmRegPedidoEdit.Operacion.Nuevo;
                objManPedidol.IdPedido = 0;

                objManPedidol.StartPosition = FormStartPosition.CenterParent;
                objManPedidol.ShowDialog();
                //Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de anular el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {

                        #region "Pedido Facturado"
                            PedidoBE objE_Pedido = null;
                            objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdPedido")));

                            if (objE_Pedido != null)
                            {
                                if (objE_Pedido.IdSituacion == Parametros.intFacturado || objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                                {
                                    XtraMessageBox.Show("No puede Eliminar, el Pedido Está Facturado, Consulte con Facturación / Caja", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }

                            }

                        #endregion

                        PedidoBL objBL_Pedido = new PedidoBL();
                      //  PedidoBE objE_Pedido = new PedidoBE();

                        objE_Pedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                       // objE_Pedido.IdTienda = int.Parse(gvPedido.GetFocusedRowCellValue("IdTienda").ToString());
                      //  objE_Pedido.IdFormaPago = int.Parse(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
                        objE_Pedido.Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();
                      //  objE_Pedido.FlagPreVenta = bool.Parse(gvPedido.GetFocusedRowCellValue("FlagPreVenta").ToString());
                        objE_Pedido.Usuario = Parametros.strUsuarioLogin;
                        objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Pedido.IdEmpresa = int.Parse(gvPedido.GetFocusedRowCellValue("IdEmpresa").ToString());
                        objBL_Pedido.Elimina(objE_Pedido);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
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

        private void tlbMenu_RefreshClick()
        {
            //Cargar();
            if (Parametros.intPerfilId == Parametros.intPerAsesorVentaPiso || Parametros.intPerfilId == Parametros.intPerAsesorDiseñoInterior || Parametros.intPerfilId == Parametros.intPerCajeroCentral || Parametros.intPerfilId == Parametros.intPerCajeroSucursal)// Diseño de Interior para no ser complice al mostrar importes
            {
                PersonaBE ObjE_Personal = new PersonaBE();
                ObjE_Personal = new PersonaBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(cboVendedor.EditValue));


                if (/*ObjE_Personal.IdTienda == Parametros.intTiendaUcayali &&*/ ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoJunior || ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoSenior || ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoMaster)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.IdPersona == ObjE_Personal.IdPersona)
                        {
                            Cargar();
                        }
                    }
                }
                else
                {
                    Cargar();
                }
            }
            else
            {
                Cargar();
            }
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {

                    if (int.Parse(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString()) == Parametros.intContado)
                    {
                        int IdPedido = 0;
                        IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                        //Actualiza Estado Impresion
                        PedidoBL objBL_Pedido = new PedidoBL();
                        PedidoBE objE_Pedido = new PedidoBE();
                        objE_Pedido = new PedidoBL().SeleccionaImpresion(IdPedido);

                        if (objE_Pedido.FlagImpresion == true)
                        {
                            XtraMessageBox.Show("El pedido ya ha sido impreso, por favor Consultar con la Recepcionista de pedido contado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //PedidoBL objBL_Pedido = new PedidoBL();
                        objBL_Pedido.ActualizaImpresion(IdPedido, true);

                        //Carga Informe

                        frmListaPrinters frmPrinter = new frmListaPrinters();
                        if (frmPrinter.ShowDialog() == DialogResult.OK)
                        {
                            List<ReportePedidoContadoBE> lstReporte = null;
                            lstReporte = new ReportePedidoContadoBL().Listado(Parametros.intPeriodo, int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()), Parametros.intTiendaId);

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
                                rptPedidoContado objReporteGuia = new rptPedidoContado();
                                objReporteGuia.SetDataSource(lstReporte);
                                objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                                objReporteGuia.SetParameterValue("Modificado", "()");

                                Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

                            }
                        }

                    }


                    if (Parametros.intTiendaId != Parametros.intTiendaUcayali)
                    {
                        //Carga Informe

                        frmListaPrinters frmPrinter = new frmListaPrinters();
                        if (frmPrinter.ShowDialog() == DialogResult.OK)
                        {
                            List<ReportePedidoContadoBE> lstReporte = null;
                            lstReporte = new ReportePedidoContadoBL().Listado(Parametros.intPeriodo, int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()), Parametros.intTiendaId);

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
                                rptPedidoContado objReporteGuia = new rptPedidoContado();
                                objReporteGuia.SetDataSource(lstReporte);
                                objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                                objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                                objReporteGuia.SetParameterValue("Modificado", "()");

                                Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

                            }
                        }
                    }
                    else {
                        XtraMessageBox.Show("No se puede imprimir, La impresión sólo es posible desde el módulo de aprobación de pedidos(Créditos y Cobranzas) ó Gestión de pedidos(ALMACEN)", this.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPedido";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPedido.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboVendedor.Text.Trim() == "")
            {
                XtraMessageBox.Show("Debe seleccionar un vendedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVendedor.Focus();
                return;
            }

            //Cargar();

            //-------------------------------------------------------
            //Agregado Temporalmente....

            if (Parametros.intPerfilId == Parametros.intPerAsesorVentaPiso || 
                Parametros.intPerfilId == Parametros.intPerAsesorDiseñoInterior || 
                Parametros.intPerfilId == Parametros.intPerCajeroCentral || 
                Parametros.intPerfilId == Parametros.intPerCajeroSucursal)// Diseño de Interior para no ser complice al mostrar importes
            {
                PersonaBE ObjE_Personal = new PersonaBE();
                ObjE_Personal = new PersonaBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(cboVendedor.EditValue));


                if (ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoJunior    || 
                    ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoSenior    || 
                    ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoMaster    || 
                    ObjE_Personal.IdCargo == Parametros.intDisenadorInteriorMaster  ||
                    ObjE_Personal.IdCargo == Parametros.intDisenadorInteriorSenior  ||
                    ObjE_Personal.IdCargo == Parametros.intDisenadorInteriorJunior               )
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.IdPersona == ObjE_Personal.IdPersona)
                        {
                            Cargar();
                        }
                    }
                }
                else
                {
                    Cargar();
                }
            }
            else
            {
                Cargar(); 
            }

            //---------------------------------------------------
        }

        private void gvPedido_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                DataRow dr;
                int IdPedido = 0;
                dr = gvPedido.GetDataRow(e.RowHandle);
                IdPedido = int.Parse(dr["IdPedido"].ToString());
                CargarDetalles(IdPedido);
            }
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    int Periodo = 0;
                    int IdTipoCliente = 0;
                    int IdClasificacionCliente = 0;
                    string CodMoneda = "";

                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    Periodo = int.Parse(gvPedido.GetFocusedRowCellValue("Periodo").ToString());
                    IdTipoCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdTipoCliente").ToString());
                    IdClasificacionCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdClasificacionCliente").ToString());
                    CodMoneda = gvPedido.GetFocusedRowCellValue("CodMoneda").ToString();

                    if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente != Parametros.intBlack)//Cualquier final
                    {
                        List<ReportePedidoSolesBE> lstReporte = null;
                        lstReporte = new ReportePedidoSolesBL().Listado(Periodo,IdPedido);

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

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                objRptSolicitudProducto.VerRptPedidoSoles(lstReporte, Parametros.strUsuarioLogin);
                                objRptSolicitudProducto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    if (IdTipoCliente == Parametros.intTipClienteFinal && IdClasificacionCliente == Parametros.intBlack)//Trabajadores
                    {
                        //List<ReportePedidoDolaresBE> lstReporte = null;
                        //lstReporte = new ReportePedidoDolaresBL().Listado(Periodo, IdPedido);

                        //if (lstReporte != null)
                        //{
                        //    if (lstReporte.Count > 0)
                        //    {

                        //        RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                        //        objRptSolicitudProducto.VerRptPedidoDolares(lstReporte, Parametros.strUsuarioLogin);
                        //        objRptSolicitudProducto.ShowDialog();


                        //    }
                        //    else
                        //        XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}

                        if (CodMoneda.Contains("S/"))
                        {
                            List<ReportePedidoSolesBE> lstReporte = null;
                            lstReporte = new ReportePedidoSolesBL().Listado(Periodo, IdPedido);

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

                            if (lstReporte != null)
                            {
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                    objRptSolicitudProducto.VerRptPedidoSolesMayorista(lstReporte, Parametros.strUsuarioLogin);
                                    objRptSolicitudProducto.ShowDialog();
                                }
                                else
                                    XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            List<ReportePedidoDolaresBE> lstReporte = null;
                            lstReporte = new ReportePedidoDolaresBL().Listado(Periodo, IdPedido);

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

                            if (lstReporte != null)
                            {
                                if (lstReporte.Count > 0)
                                {

                                    RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                    objRptSolicitudProducto.VerRptPedidoDolares(lstReporte, Parametros.strUsuarioLogin);
                                    objRptSolicitudProducto.ShowDialog();


                                }
                                else
                                    XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }


                    if (IdTipoCliente == Parametros.intTipClienteMayorista)
                    {
                        if (CodMoneda.Contains("S/"))
                        {
                            List<ReportePedidoSolesBE> lstReporte = null;
                            lstReporte = new ReportePedidoSolesBL().Listado(Periodo, IdPedido);

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

                            if (lstReporte != null)
                            {
                                if (lstReporte.Count > 0)
                                {
                                    RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                    objRptSolicitudProducto.VerRptPedidoSolesMayorista(lstReporte, Parametros.strUsuarioLogin);
                                    objRptSolicitudProducto.ShowDialog();
                                }
                                else
                                    XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            List<ReportePedidoDolaresBE> lstReporte = null;
                            lstReporte = new ReportePedidoDolaresBL().Listado(Periodo, IdPedido);

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

                            if (lstReporte != null)
                            {
                                if (lstReporte.Count > 0)
                                {

                                    RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                    objRptSolicitudProducto.VerRptPedidoDolares(lstReporte, Parametros.strUsuarioLogin);
                                    objRptSolicitudProducto.ShowDialog();


                                }
                                else
                                    XtraMessageBox.Show("No hay información para el pedido seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
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

        private void VerCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                    List<ReporteProductoCatalogoPedidoBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoPedidoBL().Listado(Parametros.intEmpresaId, IdPedido);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoPedido = new RptVistaReportes();
                            objRptProductoCatalogoPedido.VerRptProductoCatalogoPedido(lstReporte);
                            objRptProductoCatalogoPedido.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerDocumentoVentatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    int IdSituacion = 0;
                    string Numero = "";

                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                    Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();

                    if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                    {
                        frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
                        objVentaPedido.IdPedido = IdPedido;
                        objVentaPedido.NumeroPedido = Numero;
                        objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                        objVentaPedido.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarVenta_Click(object sender, EventArgs e)
        {
            if (cboVendedor.Text.Trim() == "")
            {
                XtraMessageBox.Show("Debe seleccionar un vendedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboVendedor.Focus();
                return;
            }
            
            try
            {
                List<ReportePedidoVendedorBE> lstReporteComp = null;
                lstReporteComp = new ReportePedidoVendedorBL().Listado(Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()), Convert.ToInt32(cboVendedor.EditValue));
                txtTotalSolesComprobante.Text = Convert.ToDecimal(Math.Round(lstReporteComp[0].TotalSoles,2)).ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarVentaDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboVendedor.EditValue) != 0)
                {
                    //int IdPedido = 0;
                    //int IdSituacion = 0;
                    //string Numero = "";

                    //IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    //IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                    //Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();

                    //if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                    //{
                        frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
                        objVentaPedido.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                        objVentaPedido.FechaDesde = deDesde.DateTime;
                        objVentaPedido.FechaHasta = deHasta.DateTime;
                        objVentaPedido.NumeroPedido = "";//Numero;
                        objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                        objVentaPedido.Height = 500;
                        objVentaPedido.Show();
                    //}
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void imprimirdespachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int IdFormaPago = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
                int IdSituacion = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan || IdFormaPago == Parametros.intSeparacion)
                {
                    if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                    {
                        List<ReporteMovimientoPedidoBE> lstReporte = null;
                        lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                                objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
                                objRptMovimientoPedido.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede Imprimir la hoja de Despacho,\n1. Verificar que el pedido esté embalado ó se encuentre en condición de embalaje.\n2. Verificar si tiene comprobantes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    List<ReporteMovimientoPedidoBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                            objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
                            objRptMovimientoPedido.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void cambiardespachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                int IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                {
                    MessageBox.Show("No se puede modificar la hoja de despacho, después de facturado o despachado!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    frmRegGestionPedidoDespachoEdit frm = new frmRegGestionPedidoDespachoEdit();
                    frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    frm.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Modificar;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void pendienteatenciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("En construcción");
        }

        private void cboVendedor_EditValueChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            DataTable dtPedido = new DataTable();
            dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaFechaVendedor(deDesde.DateTime, deHasta.DateTime, Convert.ToInt32(cboVendedor.EditValue)));
            gcPedido.DataSource = dtPedido;

            txtTotal.Text = dtPedido.Rows.Count.ToString();

            decimal decTotalSoles = 0;
            decimal decTotalDolares = 0;

            foreach (DataRow row in dtPedido.Rows)
            {
                if (int.Parse(row["IdSituacion"].ToString()) == Parametros.intFacturado || int.Parse(row["IdSituacion"].ToString()) == Parametros.intPVDespachado)
                {
                    //Suma Contado Cancelados o Despachado
                    if (row["CodMoneda"].ToString() == "US$")
                    {
                        decTotalDolares = decTotalDolares + Convert.ToDecimal(row["Total"].ToString());
                    }
                    else
                    {
                        decTotalSoles = decTotalSoles + Convert.ToDecimal(row["Total"].ToString());
                    }
                }
                
            }

            txtTotalSoles.EditValue = decTotalSoles;
            txtTotalDolares.EditValue = decTotalDolares;
        }

        private void CargarDetalles(int IdPedido)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle = FuncionBase.ToDataTable(new PedidoDetalleBL().ListaTodosActivo(IdPedido));
                gcPedidoDetalle.DataSource = dtDetalle;


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void InicializarModificar()
        {
            if (gvPedido.RowCount > 0)
            {
                PedidoBE objPedido = new PedidoBE();
                objPedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                frmRegPedidoEdit objRegPedidoEdit = new frmRegPedidoEdit();
                objRegPedidoEdit.pOperacion = frmRegPedidoEdit.Operacion.Modificar;
                objRegPedidoEdit.IdPedido = objPedido.IdPedido;
                objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                objRegPedidoEdit.btnGrabar.Enabled = true;
                if (objRegPedidoEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvPedido.GetFocusedRowCellValue("IdPedido").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtNumero.Text = txtNumero.Text.ToString().PadLeft(7,'0');
                if (this.txtNumero.Text == "0000000")
                {
                    return;
                }

                DataTable dtPedido = new DataTable();
                dtPedido = FuncionBase.ToDataTable(new MovimientoPedidoBL().ListaNumero(Convert.ToInt32(txtperiodo.Text), txtNumero.Text.Trim()));
                if (dtPedido.Rows.Count > 0)
                {
                    gcPedido.DataSource = dtPedido;
                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboVendedor.EditValue) != 0)
                {
                    //int IdPedido = 0;
                    //int IdSituacion = 0;
                    //string Numero = "";

                    //IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    //IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                    //Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();

                    //if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                    //{
                    frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
                    objVentaPedido.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objVentaPedido.FechaDesde = deDesde.DateTime;
                    objVentaPedido.FechaHasta = deHasta.DateTime;
                    objVentaPedido.NumeroPedido = "";//Numero;
                    objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                    objVentaPedido.Height = 500;
                    objVentaPedido.Show();
                    //}
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegCliente_Click(object sender, EventArgs e)
        {
            Form1 Frm = new Form1();

            Frm.ShowDialog();
        }
    }


    }