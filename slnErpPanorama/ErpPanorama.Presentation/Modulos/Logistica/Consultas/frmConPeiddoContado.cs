using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Printing;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConPeiddoContado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<PedidoBE> mLista = new List<PedidoBE>();
        
        #endregion

        #region "Eventos"

        public frmConPeiddoContado()
        {
            InitializeComponent();
        }

        private void frmConPeiddoContado_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;

            Cargar();

            BLoquearPerfil();

        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    if (Parametros.intTiendaId == Parametros.intTiendaUcayali  || Parametros.intTiendaId == Parametros.intTiendaAviacion2)
                    {
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            if (frmAutoriza.Usuario == "master" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerJefeAlmacen || frmAutoriza.Usuario == "jrodriguez" || frmAutoriza.IdPerfil == Parametros.intPerAsistenteAlmacen || Parametros.intPerfilId == Parametros.intPerHelpDesk)
                            {
                                string Auxiliar = "";
                                int IdTienda = 0;
                                Auxiliar = gvPedido.GetFocusedRowCellValue("DescAuxiliar").ToString();
                                IdTienda = int.Parse(gvPedido.GetFocusedRowCellValue("IdTienda").ToString());

                                if (IdTienda != Parametros.intTiendaId)//Verificar Pedido
                                {
                                    if (frmAutoriza.IdPerfil != Parametros.intPerAdministrador)
                                    {
                                        XtraMessageBox.Show("No se puede Imprimir el pedido pertenece a otra TIENDA!\nSólo un usuario de sistemas puede Imprimir bajo responsabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                }

                                if (Auxiliar.Length > 0)
                                {
                                    if (XtraMessageBox.Show("El Número pedido está siendo preparado por: " + Auxiliar + "\n desea volver a imprimir?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        Imprimir();
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    Imprimir();
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("El usuario no tiene permisos de impresión. Consultar con su administrador.\nSólo puede reimprimir el Jefe de almacén o un Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            
                        }
                    }
                    else
                    {
                        string Auxiliar = "";
                        Auxiliar = gvPedido.GetFocusedRowCellValue("DescAuxiliar").ToString();

                        if (Auxiliar.Length > 0)
                        {
                            if (XtraMessageBox.Show("El Número pedido está siendo preparado por: " + Auxiliar + "\n desea volver a imprimir?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                Imprimir();
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            Imprimir();
                        }

                    }

                    /////--------------------------------------
                    //string Auxiliar = "";
                    //Auxiliar = gvPedido.GetFocusedRowCellValue("DescAuxiliar").ToString();

                    //if (Auxiliar.Length > 0)
                    //{
                    //    if (XtraMessageBox.Show("El Número pedido está siendo preparado por: " + Auxiliar + "\n desea volver a imprimir?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //    {
                    //        Imprimir();
                    //    }
                    //    else {
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    Imprimir();                
                    //}
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
         
        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
                int IdPedido = 0;
                dr = gvPedido.GetDataRow(e.RowHandle);
                IdPedido = int.Parse(dr["IdPedido"].ToString());
                CargarDetalles(IdPedido);
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtPedido = new DataTable();
                dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaContadoAlmacenNumero(Parametros.intPeriodo,txtNumero.Text.Trim()));
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

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("El pedido no se puede anular, Sólo puede anular el Supervisor de Ventas para el caso de contado ó\nEl Jefe de Créditos y Cobranzas para Crédito, Contraentrega, etc...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "lvicente" || Parametros.strUsuarioLogin == "jrodriguez" || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen)
            //    {
            //        if (XtraMessageBox.Show("Esta seguro de anular el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            PedidoBL objBL_Pedido = new PedidoBL();
            //            PedidoBE objE_Pedido = new PedidoBE();

            //            objE_Pedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

            //            objE_Pedido = objBL_Pedido.Selecciona(objE_Pedido.IdPedido);

            //            //objE_Pedido.IdTienda = int.Parse(gvPedido.GetFocusedRowCellValue("IdTienda").ToString());
            //            objE_Pedido.IdFormaPago = int.Parse(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
            //            objE_Pedido.Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();
            //            objE_Pedido.FlagPreVenta = bool.Parse(gvPedido.GetFocusedRowCellValue("FlagPreVenta").ToString());
            //            objE_Pedido.Usuario = Parametros.strUsuarioLogin;
            //            objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            objE_Pedido.IdEmpresa = int.Parse(gvPedido.GetFocusedRowCellValue("IdEmpresa").ToString());

            //            //objE_Pedido.IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());

            //            if (objE_Pedido.IdSituacion == Parametros.intPVGenerado)
            //            {
            //                objBL_Pedido.Elimina(objE_Pedido);
            //                XtraMessageBox.Show("El registro se anuló correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                Cargar();
            //            }
            //            else
            //            {
            //                XtraMessageBox.Show("El Pedido no se puede anular, Consulte con su Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                return;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tmrNumero_Tick(object sender, EventArgs e)
        {
            Cargar();
        }

        private void asignapersonatoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AsignarAuxiliarPicking();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPedidoContado";
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


        private void habilitarpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // -----
                DataTable dtPedidos= new DataTable();
                dtPedidos = FuncionBase.ToDataTable(new PedidoBL().ListaContadoAlmacenLiberacionPedido(Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdPedido").ToString())));
                int NumLiberacion =Convert.ToInt32(dtPedidos.Rows[0]["NumeroModificacion"].ToString());
                if (NumLiberacion >= 2)
                {
                    XtraMessageBox.Show("El pedido NO puede liberarse mas de 2 veces.\nEl vendedor tendra que crear un nuevo pedido para su modificación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                /// 
                int IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if(IdSituacion ==Parametros.intPVGenerado)
                {
                    if (Parametros.strUsuarioLogin == "master" 
                      || Parametros.strUsuarioLogin == "fojeda"  
                      || Parametros.intPerfilId == Parametros.intPerJefeAlmacen 
                      || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen 
                      || Parametros.intPerfilId == Parametros.intPerEncargadoAnaqueles 
                      || Parametros.intPerfilId == Parametros.intPerSupervisorAlmacenTienda
                      || Parametros.intPerfilId == Parametros.intPerAdministradorTienda
                      || Parametros.intPerfilId == Parametros.intPerAdministrador)
                    {
                        if (XtraMessageBox.Show("Está seguro de habilitar el pedido?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //Chequeador
                            int IdPedido = 0;
                            IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                            MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();
                            MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                            objE_MovimientoPedido.IdPedido = IdPedido;
                            objE_MovimientoPedido.IdAuxiliar = 0;
                            objBL_MovimientoPedido.ActualizaAuxiliar(objE_MovimientoPedido);

                            PedidoBL objBL_Pedido = new PedidoBL();
                            objBL_Pedido.ActualizaImpresion(IdPedido, false);

                            XtraMessageBox.Show("El Pedido quedo libre para ser modificado,\nEsto aplica sólo a pedidos con Situación: Generado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();

                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ud. no tiene los permisos para esta operación\nDisponible para Jefe y Asistente de Almacén", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }else
                {
                    XtraMessageBox.Show("Sólo se liberan pedido GENERADOS", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvPedido_ColumnFilterChanged(object sender, EventArgs e)
        {
            txtTotal.Text = gvPedido.RowCount.ToString();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            DataTable dtPedido = new DataTable();
            dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaContadoAlmacen(Convert.ToInt32(cboTienda.EditValue), deDesde.DateTime, deHasta.DateTime));
            gcPedido.DataSource = dtPedido;

            txtTotal.Text = dtPedido.Rows.Count.ToString();
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


        private void Imprimir()
        {
            frmListaPrinters frmPrinter = new frmListaPrinters();
            if (frmPrinter.ShowDialog() == DialogResult.OK)
            {
                int IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());

                PedidoBL objBL_Pedido = new PedidoBL();
                objBL_Pedido.ActualizaImpresion(IdPedido, true);//add 260116

                List<ReportePedidoContadoBE> lstReporte = null;
                lstReporte = new ReportePedidoContadoBL().Listado(Parametros.intPeriodo, IdPedido, Parametros.intTiendaId);
                #region "Codigo Barras"

                //BarcodeQRCode qrcode = new BarcodeQRCode(lstReporte[0].Numero.ToString(), 1, 1, null);
                //iTextSharp.text.Image qrcodeImage = qrcode.GetImage();
                //qrcodeImage.SetAbsolutePosition(10, 500);
                //qrcodeImage.ScalePercent(200);

                //System.IO.MemoryStream ms = new System.IO.MemoryStream(qrcodeImage.RawData);
                //System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);

                //var img = qrcode.GetImage();
                //var mask = qrcodeImage;
                //mask.MakeMask();
                //img.ImageMask = mask;

                //lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(System.Drawing.Image.FromStream(img));


                //BarcodeQRCode datam = new BarcodeQRCode("55555", 40, 40, null);
                //iTextSharp.text.Image pdfImage = datam.GetImage();
                //pictureBox1.Image = Convert.ToBase64String(datam.GetImage());
                ////lstReporte[0].CodigoBarraNumero = datam.GetImage();

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
                    if (Parametros.intTiendaId == Parametros.intTiendaUcayali || Parametros.intTiendaId == Parametros.intTiendaAndahuaylas
                        || Parametros.intTiendaId == Parametros.intTiendaAviacion || Parametros.intTiendaId == Parametros.intTiendaPrescott ||  Parametros.intTiendaId == Parametros.intTiendaAviacion2) //add temp 29122017
                    {
                        rptPedidoContadoTicket objReporteGuia = new rptPedidoContadoTicket();
                        objReporteGuia.SetDataSource(lstReporte);
                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                        //addd 300715
                        //objReporteGuia.SetParameterValue("Modificado", "()");//add
                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                    }
                    //else if(Parametros.intTiendaId == Parametros.intTiendaPrescott)
                    //{
                    //    #region "Impresión matricial"
                    //    CreaTicket ticket = new CreaTicket();
                    //    ticket.impresora = frmPrinter.strNamePrinter;
                    //    //ticket.TextoCentro(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    //    ticket.TextoCentro("***** " + lstReporte[0].Numero + " *****");
                    //    ticket.TextoIzquierda("");
                    //    ticket.TextoIzquierda("TIENDA : " + lstReporte[0].DescTienda);
                    //    ticket.TextoIzquierda("FECHA  : " + lstReporte[0].Fecha.ToShortDateString() +"    "+ DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                    //    ticket.TextoIzquierda("CLIENTE: " + lstReporte[0].DescCliente);
                    //    ticket.TextoIzquierda("DOCMTO.: " + lstReporte[0].NumeroDocumento);
                    //    ticket.TextoIzquierda("VENDEDOR: " + lstReporte[0].DescVendedor);
                    //    ticket.TextoIzquierda("FORMPAGO: " + lstReporte[0].DescFormaPago);
                    //    ticket.TextoIzquierda("EQUIPO  : " + WindowsIdentity.GetCurrent().Name.ToString());
                    //    ticket.TextoIzquierda("USUARIO : " + Parametros.strUsuarioLogin);
                    //    ticket.TextoIzquierda("");
                    //    ticket.TextoIzquierda("DESPACHADOR:-----------------------------");
                    //    //ticket.LineasGuion();
                    //    //ticket.EncabezadoVenta();
                    //    ticket.TextoIzquierda("CANT      ARTICULO");
                    //    ticket.LineasGuion();
                    //    foreach (var item in lstReporte)
                    //    {
                    //        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                    //        //ticket.AgregaArticuloDetalle(item.NombreProducto.PadRight(, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                    //        ticket.TextoIzquierda( (item.UbicacionUcayali +"   "+item.NombreProducto).Trim());
                    //    }
                    //    ticket.LineasGuion();
                    //    ticket.TextoIzquierda("OBS.:" + lstReporte[0].Observacion);
                    //    ticket.TextoIzquierda("");
                    //    ticket.TextoIzquierda("");
                    //    ticket.TextoIzquierda("");
                    //    ticket.TextoCentro("-----------------------------");
                    //    ticket.TextoCentro("RECIBI CONFORME");
                    //    ticket.CortaTicket();
                    //    #endregion
                    //}
                    else
                    {
                        rptPedidoContadoA5 objReporteGuia = new rptPedidoContadoA5();
                        objReporteGuia.SetDataSource(lstReporte);
                        objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                        objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);

                        //addd 300715
                        //objReporteGuia.SetParameterValue("Modificado", "()");//add
                        objReporteGuia.SetParameterValue("Modificado", "Modif. N°(" + lstReporte[0].NumeroModificacion + ")");
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                    }



                    //rptPedidoContadoA5 objReporteGuia = new rptPedidoContadoA5();
                    ////rptPedidoContado objReporteGuia = new rptPedidoContado();
                    //objReporteGuia.SetDataSource(lstReporte);
                    //objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    //objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                    //objReporteGuia.SetParameterValue("Modificado", "Modif. N°("+ lstReporte[0].NumeroModificacion +")");

                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

                }
            }   
        }

        private void BLoquearPerfil()
        {
            if (Parametros.strUsuarioLogin == "master" 
                || Parametros.intPerfilId == Parametros.intPerJefeAlmacen 
                || Parametros.intPerfilId == Parametros.intPerSupervisorAlmacen 
                || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen 
                || Parametros.intPerfilId == Parametros.intPerEncargadoAnaqueles 
                || Parametros.intPerfilId == Parametros.intPerSupervisorAlmacenTienda 
                || Parametros.intPerfilId == Parametros.intPerAdministrador
                || Parametros.intPerfilId == Parametros.intPerHelpDesk
                || Parametros.intPerfilId == Parametros.intPerCoordinadorAlmacen)
                mnuContextual.Enabled = true;
            else
                mnuContextual.Enabled = false;

            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ygomez" || Parametros.strUsuarioLogin == "mmurrugarra" ||  Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerHelpDesk 
                || Parametros.intPerfilId == Parametros.intPerCoordinadorAlmacen || Parametros.intPerfilId == Parametros.intPerAnalistaInventario)
            {
                cboTienda.Enabled = true;
            }
            else
            {
                cboTienda.Enabled = false;
            }
        }

        #endregion

        private void gvPedido_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
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

                        if (IdTipoDocumento == Parametros.intPVDespachado)
                        {
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor = Color.DarkKhaki;
                            gvPedido.Columns["DescSituacion"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Green;
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

        private void editarPedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        public void InicializarModificar()
        {
            if (gvPedido.RowCount > 0)
            {
                PedidoBE objPedido = new PedidoBE();
                objPedido.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                objPedido.IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());

                if (objPedido.IdSituacion == Parametros.intPVGenerado)
                {
                    frmRegPedidoEdit objRegPedidoEdit = new frmRegPedidoEdit();
                    objRegPedidoEdit.pOperacion = frmRegPedidoEdit.Operacion.Modificar;
                    objRegPedidoEdit.IdPedido = objPedido.IdPedido;
                    objRegPedidoEdit.ActivaCabeceraCaja = true;
                    objRegPedidoEdit.bFlagModificarAlmacen = true;

                    objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                    if (objPedido.IdSituacion == Parametros.intPVGenerado)
                        objRegPedidoEdit.bConsulta = false;
                    else
                        objRegPedidoEdit.bConsulta = true;
                    objRegPedidoEdit.ShowDialog();

                    Cargar();
                }

            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void AsignarAuxiliarPicking()
        {
            frmRegAsignarAuxiliarPedido frm = new frmRegAsignarAuxiliarPedido();
            frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int xposition = 0;
                xposition = gvPedido.FocusedRowHandle;
                gvPedido.SetRowCellValue(xposition, "DescAuxiliar", frm.oBE.DescAuxiliar);
                //Cargar();
            }

        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                AsignarAuxiliarPicking();
                //InicializarModificar();
            }
        }

        private void gcPedido_Click(object sender, EventArgs e)
        {

        }
    }
}