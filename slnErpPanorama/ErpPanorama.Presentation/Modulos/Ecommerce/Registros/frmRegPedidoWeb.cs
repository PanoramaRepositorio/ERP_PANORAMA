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
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;

namespace ErpPanorama.Presentation.Modulos.Ecommerce.Registros
{
    public partial class frmRegPedidoWeb : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PedidoBE> mLista = new List<PedidoBE>();
        
        #endregion

        #region "Eventos"

        public frmRegPedidoWeb()
        {
            InitializeComponent();
        }

        private void frmRegPedidoWeb_Load(object sender, EventArgs e)
        {
            //tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            txtAgenciaTarifa.Text=  String.Format("{0:#,##0.##}", 0);
            textBox2.Text = String.Format("{0:#,##0.##}", 0);
            //BSUtils.LoaderLook(cboVendedor, new  PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);
            //txtPeriodo.EditValue = DateTime.Now.Year;
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                //////frmRegPedidoEdit objManPedidol = new frmRegPedidoEdit();
                //////objManPedidol.pOperacion = frmRegPedidoEdit.Operacion.Nuevo;
                //////objManPedidol.IdPedido = 0;

                //////objManPedidol.StartPosition = FormStartPosition.CenterParent;
                //////objManPedidol.ShowDialog();
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
                        //PedidoBE objE_Pedido = new PedidoBE();

                        objE_Pedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                        objE_Pedido.IdTienda = int.Parse(gvPedido.GetFocusedRowCellValue("IdTienda").ToString());
                        objE_Pedido.IdFormaPago = int.Parse(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
                        objE_Pedido.Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();
                        objE_Pedido.FlagPreVenta = bool.Parse(gvPedido.GetFocusedRowCellValue("FlagPreVenta").ToString());
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


            //if (Parametros.intPerfilId == Parametros.intPerAsesorVentaPiso || Parametros.intPerfilId == Parametros.intPerAsesorDiseñoInterior || Parametros.intPerfilId == Parametros.intPerCajeroCentral || Parametros.intPerfilId == Parametros.intPerCajeroSucursal)// Diseño de Interior para no ser complice al mostrar importes
            //{
            //    PersonaBE ObjE_Personal = new PersonaBE();
            //    ObjE_Personal = new PersonaBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(cboVendedor.EditValue));


            //    if (/*ObjE_Personal.IdTienda == Parametros.intTiendaUcayali &&*/ ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoJunior || ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoSenior || ObjE_Personal.IdCargo == Parametros.intAsesorVentaPisoMaster)
            //    {
            //        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            //        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            //        frmAutoriza.ShowDialog();

            //        if (frmAutoriza.Edita)
            //        {
            //            if (frmAutoriza.IdPersona == ObjE_Personal.IdPersona)
            //            {
            //                Cargar();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        Cargar();
            //    }
            //}
            //else
            //{
            //    Cargar();
            //}
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
                Cargar(); 
        }

        private void gvPedido_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                DataRow dr;
                int IdPPedido = 0;
                string ModalidadEnvio = "";

                dr = gvPedido.GetDataRow(e.RowHandle);
                IdPPedido = int.Parse(dr["IdPPedido"].ToString());
                ModalidadEnvio = (dr["RefOtro"].ToString());

                if ((dr["RefOtro"].ToString().Trim().ToUpper()) == "Delivery".Trim().ToUpper())
                {
                    radioButton2.Checked = true;
                    radioButton3.Checked = false;
                    radioButton1.Checked = false;

                    if (dr["Ciudad"].ToString().Trim().ToUpper() == "LIMA".ToUpper() || dr["Ciudad"].ToString().Trim().ToUpper() == "Lima Metropolitana".ToUpper())
                    {
                        textBox1.Text = (dr["DireccionEnvio"].ToString()).Trim() + " - " + dr["Ciudad"].ToString().Trim() + " - LIMA - LIMA" ;
                    }
                    else if (dr["Ciudad"].ToString().Trim() == "CALLAO")
                    {
                        textBox1.Text = (dr["DireccionEnvio"].ToString()).Trim() + " - " + dr["Ciudad"].ToString().Trim() + " - CALLAO - CALLAO";
                    }
                    else
                    {
                       // textBox1.Text = (dr["DireccionEnvio"].ToString()).Trim() + " - " + dr["Distrito"].ToString().Trim() + " - " + dr["Ciudad"].ToString().Trim() + " - " + dr["PaisLocalidad"].ToString().Trim();
                        textBox1.Text = (dr["DireccionEnvio"].ToString()).Trim() + " - " + dr["Ciudad"].ToString().Trim() + " - LIMA - LIMA";
                    }

                    textBox2.Text= String.Format("{0:#,##0.##}", (dr["TarifaEnvio"].ToString()));
                    txtAgenciaDir.Text = "";
                    txtAgenciaTarifa.Text = "";
                    txtAgenciaTarifa.Text = String.Format("{0:#,##0.##}", new decimal(0.00));
                }
               else if ((dr["RefOtro"].ToString().Trim().ToUpper()) == "Envío a agencia (provincia flete a cargo del cliente)".Trim().ToUpper())
                {
                    radioButton2.Checked = false;
                    radioButton3.Checked = true;
                    radioButton1.Checked = false;

                    txtAgenciaDir.Text = (dr["DireccionEnvio"].ToString()).Trim() + " - " + dr["Ciudad"].ToString().Trim() + " - " + dr["Ciudad"].ToString().Trim();  // + " - " + dr["PaisLocalidad"].ToString().Trim();


                    //if (Convert.ToDecimal(dr["Total"].ToString())>200)
                    //{
                    //    txtAgenciaTarifa.Text = String.Format("{0:#,##0.##}", new decimal(0));
                    //}
                    //else
                    //{
                        txtAgenciaTarifa.Text = String.Format("{0:#,##0.##}", (dr["TarifaEnvio"].ToString()));
                    //}

                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else if ((dr["RefOtro"].ToString().Trim().ToUpper()) == "Recoger en tienda Lima (Jr. Ucayali 425)".Trim().ToUpper() || (dr["RefOtro"].ToString().Trim().ToUpper()) == "Recoger en tienda San Isidro (av. Prescott 329)".Trim().ToUpper()
                    || (dr["RefOtro"].ToString().Trim().ToUpper()) == "Recoger en tienda Lima       (Jr. Ucayali 425)".Trim().ToUpper())
                    
                {
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton1.Checked = true;
                    textBox1.Text = "";
                    textBox2.Text = String.Format("{0:#,##0.##}", 0);
                    txtAgenciaTarifa.Text = String.Format("{0:#,##0.##}", new decimal(0.00));
                }                
                CargarDetalles(IdPPedido);
            }
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManClienteMinoristaEditPre objManCliente = new frmManClienteMinoristaEditPre();
                if (Convert.ToBoolean(gvPedido.GetFocusedDataRow()["FlagCliente"].ToString()) == true)
                {
                    XtraMessageBox.Show("El cliente ya fue validado y asociado al pedido web.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objManCliente.wIdPedidoWeb = Convert.ToInt32(gvPedido.GetFocusedDataRow()["IdPPedido"].ToString());
                objManCliente.wPedidoWeb = Convert.ToString(gvPedido.GetFocusedDataRow()["NumPedidoWeb"].ToString());

                if (Convert.ToString(gvPedido.GetFocusedDataRow()["Ruc"].ToString().Trim()).Length == 11 && Convert.ToString(gvPedido.GetFocusedDataRow()["RazonSocial"].ToString().Trim()).Length > 1)
                {
                    objManCliente.wNumDoc = Convert.ToString(gvPedido.GetFocusedDataRow()["Ruc"].ToString());
                    objManCliente.wDescCliente = Convert.ToString(gvPedido.GetFocusedDataRow()["RazonSocial"].ToString());
                    objManCliente.wConfactura = 2;
                }
                else
                {
                    objManCliente.wNumDoc = Convert.ToString(gvPedido.GetFocusedDataRow()["NumDocumento"].ToString());
                    objManCliente.wDescCliente = Convert.ToString(gvPedido.GetFocusedDataRow()["DescCliente"].ToString());
                    objManCliente.wConfactura = 1;
                }

                objManCliente.wMovil = Convert.ToString(gvPedido.GetFocusedDataRow()["TelMovil"].ToString());
                objManCliente.wCorreo = Convert.ToString(gvPedido.GetFocusedDataRow()["Correo"].ToString());
                objManCliente.wDireccion = Convert.ToString(gvPedido.GetFocusedDataRow()["Direccion"].ToString());


                objManCliente.pOperacion = frmManClienteMinoristaEditPre.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    //txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    //txtDescCliente.Text = objManCliente.DescCliente;
                    //txtDireccion.Text = objManCliente.AbrevDocimicilio.Substring(0, 2) + ". " + objManCliente.Direccion + ' ' + objManCliente.NumDireccion + ' ' + objManCliente.DescDistrito + '-' + objManCliente.DescProvincia + '-' + objManCliente.DescDepartamento;//add
                    //txtTipoCliente.Text = objManCliente.TipoClasificacion;
                    //IdClasificacionCliente = objManCliente.IdClasificacionCliente;
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        //IdCliente = objE_Cliente.IdCliente;

                        //Calcula Cumpleaños
                        DateTime FechaNac = objE_Cliente.FechaNac == null ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(objE_Cliente.FechaNac.ToString());
                        //if (FechaNac == null)
                        //{
                        //    int PeriodoNac = FechaNac.Year;
                        //    int Anios = Parametros.intPeriodo - PeriodoNac;

                        //Compras del mes
                        //List<DocumentoVentaBE> lstVenta = null;
                        //lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, objE_Cliente.IdCliente);

                        //if (FechaNac.Month == Parametros.intMes && Anios > 15 && lstVenta.Count == 0)
                        //{
                        //    lblMensaje.Text = "FELIZ CUMPLEAÑOS !!!!!! " + FechaNac.ToShortDateString();
                        //    bCumpleAnios = true;
                        //}
                        //else
                        //{
                        //    bCumpleAnios = false;
                    }                 

                }
                Cargar();
                //}
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(gvPedido.GetFocusedDataRow()["IdPedidoPanorama"].ToString()) == 0)
                {
                    XtraMessageBox.Show("Antes de procesar con la validación del pago debe generar \nel pedido panorama.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                frmRegPagoCliente objManCliente = new frmRegPagoCliente();

                if (Convert.ToBoolean(gvPedido.GetFocusedDataRow()["FlagPago"].ToString()) == true)
                {
                    XtraMessageBox.Show("El pedido web ya tiene pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                objManCliente.wIdPedidoWeb = Convert.ToInt32(gvPedido.GetFocusedDataRow()["IdPPedido"].ToString());
                objManCliente.wPedidoWeb = Convert.ToString(gvPedido.GetFocusedDataRow()["NumPedidoWeb"].ToString());
                objManCliente.wDescCliente = Convert.ToString(gvPedido.GetFocusedDataRow()["DescCliente"].ToString());

               // objManCliente.pOperacion = frmManClienteMinoristaEditPre.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;

                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    //txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    //txtDescCliente.Text = objManCliente.DescCliente;
                    //txtDireccion.Text = objManCliente.AbrevDocimicilio.Substring(0, 2) + ". " + objManCliente.Direccion + ' ' + objManCliente.NumDireccion + ' ' + objManCliente.DescDistrito + '-' + objManCliente.DescProvincia + '-' + objManCliente.DescDepartamento;//add
                    //txtTipoCliente.Text = objManCliente.TipoClasificacion;
                    //IdClasificacionCliente = objManCliente.IdClasificacionCliente;
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                    }

                }
                Cargar();
            }
            catch (Exception ex)
            {
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
                        //////frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
                        //////objVentaPedido.IdPedido = IdPedido;
                        //////objVentaPedido.NumeroPedido = Numero;
                        //////objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                        //////objVentaPedido.Show();
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
            //if (cboVendedor.Text.Trim() == "")
            //{
            //    XtraMessageBox.Show("Debe seleccionar un vendedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cboVendedor.Focus();
            //    return;
            //}
            
            //try
            //{
            //    List<ReportePedidoVendedorBE> lstReporteComp = null;
            //    lstReporteComp = new ReportePedidoVendedorBL().Listado(Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()), Convert.ToInt32(cboVendedor.EditValue));
            //    txtTotalSolesComprobante.Text = Convert.ToDecimal(Math.Round(lstReporteComp[0].TotalSoles,2)).ToString();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnConsultarVentaDocumento_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToInt32(cboVendedor.EditValue) != 0)
            //    {
            //        //int IdPedido = 0;
            //        //int IdSituacion = 0;
            //        //string Numero = "";

            //        //IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            //        //IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
            //        //Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();

            //        //if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
            //        //{
            //            ////////frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
            //            ////////objVentaPedido.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
            //            ////////objVentaPedido.FechaDesde = deDesde.DateTime;
            //            ////////objVentaPedido.FechaHasta = deHasta.DateTime;
            //            ////////objVentaPedido.NumeroPedido = "";//Numero;
            //            ////////objVentaPedido.StartPosition = FormStartPosition.CenterParent;
            //            ////////objVentaPedido.Height = 500;
            //            ////////objVentaPedido.Show();
            //        //}
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteMovimientoPedidoBE> lstReporte = null;
            //    lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));
            //    if (lstReporte != null)
            //    {
            //        int IdFormaPago = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
            //        if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan || IdFormaPago == Parametros.intSeparacion)
            //        {
            //            if (lstReporte[0].NumeroDocumento == "")
            //            {
            //                XtraMessageBox.Show("No hay documentación de facturación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //            {
            //                if (lstReporte.Count > 0)
            //                {
            //                    RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //                    objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //                    objRptMovimientoPedido.ShowDialog();
            //                }
            //                else
            //                    XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //        else
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //                objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
            //                objRptMovimientoPedido.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //        }
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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
            dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaFechaPrePedidosWeb(deDesde.DateTime, deHasta.DateTime));
            gcPedido.DataSource = dtPedido;

            //txtTotal.Text = dtPedido.Rows.Count.ToString();

            decimal decTotalSoles = 0;
            decimal decTotalDolares = 0;

            //foreach (DataRow row in dtPedido.Rows)
            //{
            //    if (int.Parse(row["IdSituacion"].ToString()) == Parametros.intFacturado || int.Parse(row["IdSituacion"].ToString()) == Parametros.intPVDespachado)
            //    {
            //        //Suma Contado Cancelados o Despachado
            //        if (row["CodMoneda"].ToString() == "US$")
            //        {
            //            decTotalDolares = decTotalDolares + Convert.ToDecimal(row["Total"].ToString());
            //        }
            //        else
            //        {
            //            decTotalSoles = decTotalSoles + Convert.ToDecimal(row["Total"].ToString());
            //        }
            //    }
                
            //}

            //txtTotalSoles.EditValue = decTotalSoles;
            //txtTotalDolares.EditValue = decTotalDolares;
        }

        private void CargarDetalles(int IdPedido)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle = FuncionBase.ToDataTable(new PedidoDetalleBL().ListaTodosActivoDetalleWeb(IdPedido));
                gcPedidoDetalle.DataSource = dtDetalle ;


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
                ////////////PedidoBE objPedido = new PedidoBE();
                ////////////objPedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                ////////////frmRegPedidoEdit objRegPedidoEdit = new frmRegPedidoEdit();
                ////////////objRegPedidoEdit.pOperacion = frmRegPedidoEdit.Operacion.Modificar;
                ////////////objRegPedidoEdit.IdPedido = objPedido.IdPedido;
                ////////////objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                ////////////objRegPedidoEdit.btnGrabar.Enabled = true;
                ////////////if (objRegPedidoEdit.ShowDialog() == DialogResult.OK)
                ////////////{
                ////////////    Cargar();
                ////////////}
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

            if (gvPedido.GetFocusedRowCellValue("IdPedidoPanorama").ToString() == "")
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

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void gcPedido_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(gvPedido.GetFocusedDataRow()["FlagCliente"].ToString()) == false)
            {
                XtraMessageBox.Show("Asocie al cliente con el Pedido Web", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (Convert.ToBoolean(gvPedido.GetFocusedDataRow()["FlagPago"].ToString()) == false)
            //{
            //    XtraMessageBox.Show("Tiene que registrar el pago para procesar el Pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (Convert.ToBoolean(gvPedido.GetFocusedDataRow()["FlagProcesado"].ToString()) == true)
            {
                XtraMessageBox.Show("El Pedido WEB ya fue GENERADO PARA SU FACTURACIÓN.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (gvPedido.RowCount > 0)
            {
                PedidoBE objPedido = new PedidoBE();
                objPedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPPedido").ToString());
        
                frmRegPedidoEditWeb objRegPedidoEdit = new frmRegPedidoEditWeb();
                objRegPedidoEdit.pOperacion = frmRegPedidoEditWeb.Operacion.Modificar;
                objRegPedidoEdit.IdPedido = 0; // objPedido.IdPedido;
                objRegPedidoEdit.IdPedidoWEB = objPedido.IdPedido;
                objRegPedidoEdit.PedDelivery = int.Parse(gvPedido.GetFocusedRowCellValue("ModalidadEnvio").ToString());
                objRegPedidoEdit.CostoDelivery = Convert.ToDecimal(gvPedido.GetFocusedRowCellValue("TarifaEnvio").ToString());
                objRegPedidoEdit.wTotal    = Convert.ToDecimal(gvPedido.GetFocusedRowCellValue("Total").ToString());
                objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                objRegPedidoEdit.btnGrabar.Enabled = true;            

                if (int.Parse(gvPedido.GetFocusedRowCellValue("ModalidadEnvio").ToString()) == 2 && (gvPedido.GetFocusedRowCellValue("Distrito").ToString().Trim().ToUpper() == "LIMA".ToString().Trim().ToUpper()
                                                                                                    || gvPedido.GetFocusedRowCellValue("Distrito").ToString().Trim().ToUpper() == "Lima Metropolitana".ToString().Trim().ToUpper()))
                {
                    if ((gvPedido.GetFocusedRowCellValue("Ciudad").ToString().Trim().ToUpper()) == "LIMA".Trim().ToUpper() || (gvPedido.GetFocusedRowCellValue("Distrito").ToString().Trim().ToUpper()) == "LIMA METROPOLITANA".Trim().ToUpper()
                        || (gvPedido.GetFocusedRowCellValue("Ciudad").ToString().Trim().ToUpper()) == "CALLAO".Trim().ToUpper())
                    {
                        DataTable dtDetalle = new DataTable();
                        if ((gvPedido.GetFocusedRowCellValue("Distrito").ToString().Trim().ToUpper()) == "LIMA METROPOLITANA".Trim().ToUpper())
                        {
                            dtDetalle = FuncionBase.ToDataTable(new UbigeoBL().Selecciona_Ubigeo_xDistrito2(gvPedido.GetFocusedRowCellValue("Ciudad").ToString().Trim()));
                        }
                        else
                        {
                            dtDetalle = FuncionBase.ToDataTable(new UbigeoBL().Selecciona_Ubigeo_xDistrito2(gvPedido.GetFocusedRowCellValue("Distrito").ToString().Trim()));
                        }

                        
                        objRegPedidoEdit.wIdDepartamento = dtDetalle.Rows[0]["IdDepartamento"].ToString();
                        objRegPedidoEdit.wIdProvincia = dtDetalle.Rows[0]["IdProvincia"].ToString();
                        objRegPedidoEdit.wIdDistrito = dtDetalle.Rows[0]["IdDistrito"].ToString();
                        objRegPedidoEdit.wDirReferencia = gvPedido.GetFocusedRowCellValue("DirReferencia").ToString().Trim().ToUpper();   
                        objRegPedidoEdit.wDirDelivery = textBox1.Text.Trim();
                    }
                    else
                    {
                    }
                }
                else if (int.Parse(gvPedido.GetFocusedRowCellValue("ModalidadEnvio").ToString()) == 1 &&  gvPedido.GetFocusedRowCellValue("RefOtro").ToString().Trim().ToUpper() == "Envío a agencia (pago de flete a cargo del cliente)".Trim().ToUpper())
                {
                    DataTable dtDetalle = new DataTable();
                    dtDetalle = FuncionBase.ToDataTable(new UbigeoBL().Selecciona_Ubigeo_xDistrito2("ENVIO A AGENCIA"));
                    objRegPedidoEdit.wIdDepartamento = dtDetalle.Rows[0]["IdDepartamento"].ToString();
                    objRegPedidoEdit.wIdProvincia = dtDetalle.Rows[0]["IdProvincia"].ToString();
                    objRegPedidoEdit.wIdDistrito = dtDetalle.Rows[0]["IdDistrito"].ToString();
                    objRegPedidoEdit.wDirReferencia = gvPedido.GetFocusedRowCellValue("DirReferencia").ToString().Trim().ToUpper();
                    objRegPedidoEdit.wDirDelivery = String.Format("{0:#,##0.##}", txtAgenciaDir.Text);
                    objRegPedidoEdit.CostoDelivery =Convert.ToDecimal( String.Format("{0:#,##0.##}", txtAgenciaTarifa.Text));
                    objRegPedidoEdit.wEnvioAgencia = "ENVIO A AGENCIA";
                }


                    //if (int.Parse(gvPedido.GetFocusedRowCellValue("ModalidadEnvio").ToString()) == 2)
                    //{
                    //    if ((gvPedido.GetFocusedRowCellValue("Ciudad").ToString().Trim().ToUpper()) == "LIMA" || (gvPedido.GetFocusedRowCellValue("Ciudad").ToString().Trim().ToUpper()) == "CALLAO")
                    //    {
                    //        DataTable dtDetalle = new DataTable();
                    //        dtDetalle = FuncionBase.ToDataTable(new UbigeoBL().Selecciona_Ubigeo_xDistrito2(gvPedido.GetFocusedRowCellValue("Distrito").ToString().Trim()));
                    //        objRegPedidoEdit.wIdDepartamento = dtDetalle.Rows[0]["IdDepartamento"].ToString();
                    //        objRegPedidoEdit.wIdProvincia = dtDetalle.Rows[0]["IdProvincia"].ToString();
                    //        objRegPedidoEdit.wIdDistrito = dtDetalle.Rows[0]["IdDistrito"].ToString();
                    //        objRegPedidoEdit.wDirReferencia = gvPedido.GetFocusedRowCellValue("DirReferencia").ToString().Trim().ToUpper();
                    //        objRegPedidoEdit.wDirDelivery = textBox1.Text.Trim();
                    //    }
                    //    else
                    //    {
                    //    }
                    //}



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

        private void gcPedido_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                //DataRow dr;
                //int IdPPedido = 0;
                //dr = gvPedido.GetDataRow(e.RowHandle);
                //IdPPedido = int.Parse(dr["IdPPedido"].ToString());

                //if ((dr["RefOtro"].ToString()) == "Delivery")
                //{
                //    radioButton2.Checked = true;
                //    radioButton1.Checked = false;
                //    textBox1.Text = (dr["DireccionEnvio"].ToString()).Trim() + " - " + dr["Ciudad"].ToString().Trim() + " - " + dr["Distrito"].ToString().Trim();
                //    textBox2.Text = String.Format("{0:#,##0.##}", (dr["TarifaEnvio"].ToString()));
                //}
                //else if ((dr["RefOtro"].ToString()) == "Panorama Hogar" || (dr["RefOtro"].ToString()) == "Recoger tienda Panorama Hogar")
                //{
                //    radioButton1.Checked = true;
                //    radioButton2.Checked = false;
                //    textBox1.Text = "";
                //    textBox2.Text = String.Format("{0:#,##0.##}", 0);
                //}

                CargarDetalles(int.Parse(gvPedido.GetFocusedDataRow()["IdPPedido"].ToString()));
            }
        }

        private void gcPedido_DefaultViewChanged(object sender, EventArgs e)
        {
            CargarDetalles(int.Parse(gvPedido.GetFocusedDataRow()["IdPPedido"].ToString()));
        }

        private void gcPedido_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void gcPedido_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void gcPedido_TextChanged(object sender, EventArgs e)
        {
        }

        private void gcPedido_CursorChanged(object sender, EventArgs e)
        {
      
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //if (Convert.ToBoolean(gvPedido.GetFocusedDataRow()["FlagPago"].ToString()) == false)
            //{
            //    XtraMessageBox.Show("Tiene que VERIFICAR Y REGISTRAR EL PAGO PARA LA EMISIÓN Y ENTREGA.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            frmRegVentaContadoWeb GDocumento = new frmRegVentaContadoWeb();

            GDocumento.ShowDialog();
            Cargar();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            btnConsultar_Click(null, null);
        }

        private void gvPedido_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPedido.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdSituacion"]);
                    if (objDocRetiro != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == Parametros.intPVAnulado)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor = Color.Red;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == Parametros.intCancelado)
                        {
                            e.Appearance.BackColor = Color.Aqua;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor = Color.Aqua;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }


                        if (IdTipoDocumento == Parametros.intPVGenerado)
                        {
                            e.Appearance.BackColor = Color.Orange;
                            e.Appearance.BackColor2 = Color.SeaShell;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor = Color.Orange;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == Parametros.intFacturado)
                        {
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor = Color.Green;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.GreenYellow;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == Parametros.intPendiente)
                        {
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor = Color.LightYellow;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.LightYellow;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void reimprimirPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.Parse(gvPedido.GetFocusedRowCellValue("IdPedidoPanorama").ToString()) == 0)
            {
                XtraMessageBox.Show("Tiene que generar el PEDIDO PANORAMA para immprimir. ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Actualiza Estado Impresion
            PedidoBE objE_Pedido2 = new PedidoBE();
            objE_Pedido2 = new PedidoBL().SeleccionaImpresion(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedidoPanorama").ToString()));

            if (objE_Pedido2.FlagImpresion == true)
            {
                XtraMessageBox.Show("El pedido ya ha sido impreso, por favor Consultar con la Recepción de pedido contado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Boolean Imprimir = true;
            if (Imprimir)
            {
                List<ReportePedidoContadoBE> lstReporte = null;
                lstReporte = new ReportePedidoContadoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("Periodo").ToString()), int.Parse(gvPedido.GetFocusedRowCellValue("IdPedidoPanorama").ToString()), Parametros.intTiendaId);

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
                        rptPedidoContadoTicketWebDelivery objReporteGuia = new rptPedidoContadoTicketWebDelivery();
                        objReporteGuia.SetDataSource(lstReporte);
                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");

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

                            if (printer.ToUpper().StartsWith("(P)"))
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
                            MessageBox.Show("La impresora (P) Nombre para Pedido de Venta no ha sido encontrada.");
                            return;
                        }

                    //Actualiza Impresión
                    PedidoBL objBL_Pedido = new PedidoBL();
                    objBL_Pedido.ActualizaImpresion(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedidoPanorama").ToString()), true);

                    //objReporteGuia.PrintToPrinter(1, false, 0, 0);
                    MessageBox.Show("El pedido se imprimió correctamente");// se envió a  + prtName);
                        #endregion

                }

            }
        }

        private void verPedidoPanoramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                    int IdPedido = 0;
                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedidoPanorama").ToString());
                    if (IdPedido > 0)
                    {
                        frmRegPedidoEdit frm = new frmRegPedidoEdit();
                        frm.IdPedido = IdPedido;
                        frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Verificar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdSituacion")) ==114)
                {
                    XtraMessageBox.Show("El Pedido Panorama se encuentra Anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToString(gvPedido.GetFocusedRowCellValue("CompPago")) != "")
                {
                    XtraMessageBox.Show("No puede Anular, el Pedido Está Facturado, Consulte con Facturación / Caja", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdPedidoPanorama")) <= 0)
                {
                    XtraMessageBox.Show("Seleccione un Pedido Panorama para anular.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                   Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de anular el Pedido ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        #region "Pedido Facturado"
                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdPedidoPanorama")));

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
                        
                        objE_Pedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedidoPanorama").ToString());
                        objE_Pedido.IdTienda = int.Parse(gvPedido.GetFocusedRowCellValue("IdTienda").ToString());
                        objE_Pedido.IdFormaPago = int.Parse(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
                        objE_Pedido.Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();
                        objE_Pedido.FlagPreVenta = bool.Parse(gvPedido.GetFocusedRowCellValue("FlagPreVenta").ToString());
                        objE_Pedido.Usuario = Parametros.strUsuarioLogin;
                        objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Pedido.IdEmpresa = int.Parse(gvPedido.GetFocusedRowCellValue("IdEmpresa").ToString());
                        objBL_Pedido.AnularPedidoWeb(objE_Pedido);
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            RibbonForm1 frm = new RibbonForm1();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdSituacion")) == 114)
                {
                    XtraMessageBox.Show("El Pedido Panorama se encuentra Anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToString(gvPedido.GetFocusedRowCellValue("CompPago")) != "")
                {
                    XtraMessageBox.Show("No puede Anular, el Pedido Está Facturado, Consulte con Facturación / Caja", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de CANCELAR el pedido de prestashop ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //if (!ValidarIngreso())
                    //{
                        //#region "Pedido Facturado"
                        PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaPedidoPrestashop(Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdPPedido")));

                    //if (objE_Pedido != null)
                    //{
                    //    if (objE_Pedido.IdSituacion == Parametros.intFacturado || objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                    //    {
                    //        XtraMessageBox.Show("No puede Eliminar, el Pedido Está Facturado, Consulte con Facturación / Caja", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        return;
                    //    }
                    //}
                    //#endregion
                    PedidoBL objBL_Pedido = new PedidoBL();

                    objE_Pedido.IdPedido = 0;
                    //objE_Pedido.IdTienda = int.Parse(gvPedido.GetFocusedRowCellValue("IdTienda").ToString());
                    //objE_Pedido.IdFormaPago = int.Parse(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
                    //objE_Pedido.Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();
                    //objE_Pedido.FlagPreVenta = bool.Parse(gvPedido.GetFocusedRowCellValue("FlagPreVenta").ToString());
                    objE_Pedido.IdPedidoWeb = Convert.ToInt32(gvPedido.GetFocusedDataRow()["IdPPedido"].ToString()); //gvPedido.GetFocusedRowCellValue("IdPPedido");
                    //objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    //objE_Pedido.IdEmpresa = int.Parse(gvPedido.GetFocusedRowCellValue("IdEmpresa").ToString());
                    objBL_Pedido.AnularPedidoWebPrestashop(objE_Pedido);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    //}
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}