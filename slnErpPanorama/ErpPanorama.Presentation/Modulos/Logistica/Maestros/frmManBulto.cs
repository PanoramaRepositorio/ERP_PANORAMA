using System;
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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManBulto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<BultoBE> mLista = new List<BultoBE>();

        private string NumeroNotaSalida = "NS_FO";

        #endregion

        #region "Eventos"

        public frmManBulto()
        {
            InitializeComponent();
        }

        private void frmManBulto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboProveedor, new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId), "DescProveedor", "IdProveedor", false);
        }

        private void tlbMenu_NewClick()
        {
           
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteBultoBE> lstReporte = null;
                lstReporte = new ReporteBultoBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboProveedor.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptBulto = new RptVistaReportes();
                        objRptBulto.VerRptBulto(lstReporte);
                        objRptBulto.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoBulto";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBulto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvBulto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void cboProveedor_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProveedor.EditValue != null)
            {
                BSUtils.LoaderLook(cboDocumento, new FacturaCompraBL().ListaProveedor(Parametros.intEmpresaId, Convert.ToInt32(cboProveedor.EditValue),"") , "NumeroDocumento", "IdFacturaCompra", false);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void descargarunoanaquelestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<InventarioBE> lst_InventarioMsg = new List<InventarioBE>();

                List<BultoBE> mListaBulto = new List<BultoBE>();
                mListaBulto = new BultoBL().ListaTodosActivoTransferenciaAnaqueles(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue));
                gcBulto.DataSource = mListaBulto;

                if (mListaBulto.Count == 0)
                {
                    XtraMessageBox.Show("No se puede descargar, No existen bultos!",this.Text);
                    Cursor = Cursors.Default;
                    return;
                }

                //string Usuario = Parametros.strUsuarioLogin;
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (!frmAutoriza.Edita)
                {
                    return;
                }

                if (frmAutoriza.Usuario == "almacen1")
                {
                    XtraMessageBox.Show("Por favor generar con otro usuario.\nAcceso restringido!", this.Text);
                    return;
                }

                //RECIBIR A ALMACEN DE BULTO
                BultoBL objBL_Bulto = new BultoBL();
                foreach (var item in mListaBulto)
                {
                    BultoBE objE_Bulto = new BultoBE();
                    objE_Bulto.IdBulto = item.IdBulto;
                    objE_Bulto.IdEmpresa = item.IdEmpresa;//Parametros.intEmpresaId;
                    objE_Bulto.IdAlmacen = item.IdAlmacen;//Convert.ToInt32(cboAlmacen.EditValue);
                    objE_Bulto.IdSector = 0;//Convert.ToInt32(cboSector.EditValue);
                    objE_Bulto.IdBloque = 0; //Convert.ToInt32(cboBloque.EditValue);
                    objE_Bulto.IdProducto = item.IdProducto;
                    objE_Bulto.NumeroBulto = "ANAQ"; //txtNumeroBulto.Text;
                    objE_Bulto.Agrupacion = item.Agrupacion; //txtAgrupacion.Text;
                    objE_Bulto.IdFacturaCompra = item.IdFacturaCompra;
                    objE_Bulto.PrecioUnitario = item.PrecioUnitario;
                    objE_Bulto.Cantidad = item.Cantidad;//Convert.ToInt32(txtCantidad.EditValue);
                    objE_Bulto.CostoUnitario = item.CostoUnitario; //CostoUnitario;
                    objE_Bulto.FechaIngreso = item.FechaIngreso;// Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString());
                    objE_Bulto.IdSituacion = Parametros.intBULRecibido;
                    objE_Bulto.Periodo = item.Periodo; //deFechaIngreso.DateTime.Year;
                    objE_Bulto.IdTipoDocumento = item.IdTipoDocumento; //IdTipoDocumento;
                    objE_Bulto.NumeroDocumento = item.NumeroDocumento; // NumeroDocumento;
                    objE_Bulto.Observacion = "Bulto Recepcionado Automático"; //txtObservacion.Text;
                    objE_Bulto.IdKardex = null;
                    objE_Bulto.FlagEstado = true;
                    objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Bulto.Usuario = Parametros.strUsuarioLogin;

                    objBL_Bulto.ActualizaFactura(objE_Bulto);
                }

                //TRANSFERENCIA DE BULTO
                foreach (var item in mListaBulto)
                {
                    //Establecer Los Datos de Cabecera de la Transferencia del Bulto
                    TransferenciaBultoBE objE_TransferenciaBulto = new TransferenciaBultoBE();
                    objE_TransferenciaBulto.IdTransferenciaBulto = 0;
                    objE_TransferenciaBulto.IdEmpresa = Parametros.intEmpresaId;
                    objE_TransferenciaBulto.IdTienda = Parametros.intTiendaId;
                    objE_TransferenciaBulto.Periodo = Parametros.intPeriodo;
                    objE_TransferenciaBulto.IdTipoDocumento = Parametros.intTipoDocTransferencia;
                    objE_TransferenciaBulto.NumeroDocumento = ""; //ObtenerCorrelativo(); For Kardex Bulto;
                    objE_TransferenciaBulto.FechaMovimiento = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    objE_TransferenciaBulto.IdAlmacenOrigen = Parametros.intAlmBultos;
                    objE_TransferenciaBulto.IdAlmacenDestino = Parametros.intAlmAnaqueles;//.intAlmCentralUcayali;
                    objE_TransferenciaBulto.Observacion = "Transferencia Automática a Anaqueles";
                    objE_TransferenciaBulto.IdMovimientoAlmacenIngreso = 0;
                    objE_TransferenciaBulto.IdMovimientoAlmacenSalida = 0;
                    objE_TransferenciaBulto.FlagEstado = true;
                    objE_TransferenciaBulto.Usuario = Parametros.strUsuarioLogin;
                    objE_TransferenciaBulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    List<TransferenciaBultoDetalleBE> lstListaTransferenciaDetalle = new List<TransferenciaBultoDetalleBE>();

                    //Establecer los datos del detalle de la transferencia de bultos
                    TransferenciaBultoDetalleBE objE_DetalleTransferencia = new TransferenciaBultoDetalleBE();
                    objE_DetalleTransferencia.IdTransferenciaBultoDetalle = 0;
                    objE_DetalleTransferencia.IdTransferenciaBulto = 0;
                    objE_DetalleTransferencia.IdBulto = item.IdBulto;
                    objE_DetalleTransferencia.IdProducto = item.IdProducto;
                    objE_DetalleTransferencia.Cantidad = item.Cantidad;
                    objE_DetalleTransferencia.IdKardexBulto = 0;
                    objE_DetalleTransferencia.IdKardex = 0;
                    objE_DetalleTransferencia.FlagEstado = true;
                    objE_DetalleTransferencia.Abreviatura = item.Abreviatura;
                    objE_DetalleTransferencia.PrecioUnitario = item.PrecioUnitario;
                    objE_DetalleTransferencia.Usuario = Parametros.strUsuarioLogin;
                    objE_DetalleTransferencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_DetalleTransferencia.IdEmpresa = Parametros.intEmpresaId;
                    lstListaTransferenciaDetalle.Add(objE_DetalleTransferencia);

                    //Realizamos la transferencia de bultos
                    TransferenciaBultoBL objBL_TransferenciaBulto = new TransferenciaBultoBL();
                    objBL_TransferenciaBulto.Inserta(objE_TransferenciaBulto, lstListaTransferenciaDetalle);

                    //Add Bulto 
                    InventarioBE ObjE_Inventario = new InventarioBE();
                    ObjE_Inventario.CodigoProveedor = item.CodigoProveedor;
                    ObjE_Inventario.Cantidad = item.Cantidad;
                    ObjE_Inventario.Ubicacion = "";
                    ObjE_Inventario.Observacion = "Fac N° "+ item.NumeroDocumento;
                    lst_InventarioMsg.Add(ObjE_Inventario);

                }

                if (lst_InventarioMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.Titulo = "Lista de Bultos Descargados -->Almacen Anaquel";
                    frm.mLista = lst_InventarioMsg;
                    frm.ShowDialog();
                }

                //XtraMessageBox.Show("1 Bulto x Producto descargado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
                this.Close();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generarfaltanteorigentoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                mLista = new BultoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue));
                gcBulto.DataSource = mLista;

                if (mLista.Count == 0)
                {
                    XtraMessageBox.Show("No se puede generar el documento\nNo existen bultos Pendientes!", this.Text);
                    return;
                }

                //string Usuario = Parametros.strUsuarioLogin;
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (!frmAutoriza.Edita)
                {
                    return;
                }

                if (frmAutoriza.Usuario == "almacen1")
                {
                    XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                    return;
                }

                //RECIBIR A ALMACEN DE BULTO
                BultoBL objBL_Bulto = new BultoBL();
                foreach (var item in mLista)
                {
                    BultoBE objE_Bulto = new BultoBE();
                    objE_Bulto.IdBulto = item.IdBulto;
                    objE_Bulto.IdEmpresa = item.IdEmpresa;//Parametros.intEmpresaId;
                    objE_Bulto.IdAlmacen = item.IdAlmacen;//Convert.ToInt32(cboAlmacen.EditValue);
                    objE_Bulto.IdSector = 0;//Convert.ToInt32(cboSector.EditValue);
                    objE_Bulto.IdBloque = 0; //Convert.ToInt32(cboBloque.EditValue);
                    objE_Bulto.IdProducto = item.IdProducto;
                    objE_Bulto.NumeroBulto = "X"; //txtNumeroBulto.Text;
                    objE_Bulto.Agrupacion = item.Agrupacion; //txtAgrupacion.Text;
                    objE_Bulto.IdFacturaCompra = item.IdFacturaCompra;
                    objE_Bulto.PrecioUnitario = item.PrecioUnitario;
                    objE_Bulto.Cantidad = item.Cantidad;//Convert.ToInt32(txtCantidad.EditValue);
                    objE_Bulto.CostoUnitario = item.CostoUnitario; //CostoUnitario;
                    objE_Bulto.FechaIngreso = item.FechaIngreso;// Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString());
                    objE_Bulto.IdSituacion = Parametros.intBULRecibido;
                    objE_Bulto.Periodo = item.Periodo; //deFechaIngreso.DateTime.Year;
                    objE_Bulto.IdTipoDocumento = item.IdTipoDocumento; //IdTipoDocumento;
                    objE_Bulto.NumeroDocumento = item.NumeroDocumento; // NumeroDocumento;
                    objE_Bulto.Observacion = "Bulto Faltante de Origen"; //txtObservacion.Text;
                    //objE_Bulto.FlagInventario = false;
                    objE_Bulto.IdKardex = null;
                    objE_Bulto.FlagEstado = true;
                    objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Bulto.Usuario = Parametros.strUsuarioLogin;

                    objBL_Bulto.ActualizaFactura(objE_Bulto);
                }

                //TRANSFERENCIA DE BULTO
                foreach (var item in mLista)
                {
                    //Establecer Los Datos de Cabecera de la Transferencia del Bulto
                    TransferenciaBultoBE objE_TransferenciaBulto = new TransferenciaBultoBE();
                    objE_TransferenciaBulto.IdTransferenciaBulto = 0;
                    objE_TransferenciaBulto.IdEmpresa = Parametros.intEmpresaId;
                    objE_TransferenciaBulto.IdTienda = Parametros.intTiendaId;
                    objE_TransferenciaBulto.Periodo = Parametros.intPeriodo;
                    objE_TransferenciaBulto.IdTipoDocumento = Parametros.intTipoDocTransferencia;
                    objE_TransferenciaBulto.NumeroDocumento = ""; //ObtenerCorrelativo(); For Kardex Bulto;
                    objE_TransferenciaBulto.FechaMovimiento = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    objE_TransferenciaBulto.IdAlmacenOrigen = Parametros.intAlmBultos;
                    objE_TransferenciaBulto.IdAlmacenDestino = Parametros.intAlmAnaqueles;//.intAlmCentralUcayali;
                    objE_TransferenciaBulto.Observacion = "Transferencia de Bultos";
                    objE_TransferenciaBulto.IdMovimientoAlmacenIngreso = 0;
                    objE_TransferenciaBulto.IdMovimientoAlmacenSalida = 0;
                    objE_TransferenciaBulto.FlagEstado = true;
                    objE_TransferenciaBulto.Usuario = Parametros.strUsuarioLogin;
                    objE_TransferenciaBulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    List<TransferenciaBultoDetalleBE> lstListaTransferenciaDetalle = new List<TransferenciaBultoDetalleBE>();

                    //Establecer los datos del detalle de la transferencia de bultos
                    TransferenciaBultoDetalleBE objE_DetalleTransferencia = new TransferenciaBultoDetalleBE();
                    objE_DetalleTransferencia.IdTransferenciaBultoDetalle = 0;
                    objE_DetalleTransferencia.IdTransferenciaBulto = 0;
                    objE_DetalleTransferencia.IdBulto = item.IdBulto;
                    objE_DetalleTransferencia.IdProducto = item.IdProducto;
                    objE_DetalleTransferencia.Cantidad = item.Cantidad;
                    objE_DetalleTransferencia.IdKardexBulto = 0;
                    objE_DetalleTransferencia.IdKardex = 0;
                    objE_DetalleTransferencia.FlagEstado = true;
                    objE_DetalleTransferencia.Abreviatura = item.Abreviatura;
                    objE_DetalleTransferencia.PrecioUnitario = item.PrecioUnitario;
                    objE_DetalleTransferencia.Usuario = Parametros.strUsuarioLogin;
                    objE_DetalleTransferencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_DetalleTransferencia.IdEmpresa = Parametros.intEmpresaId;
                    lstListaTransferenciaDetalle.Add(objE_DetalleTransferencia);

                    //Realizamos la transferencia de bultos
                    TransferenciaBultoBL objBL_TransferenciaBulto = new TransferenciaBultoBL();
                    objBL_TransferenciaBulto.Inserta(objE_TransferenciaBulto, lstListaTransferenciaDetalle);

                    //XtraMessageBox.Show("El Bulto se descargó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //NOTA DE SALIDA POR FALTANTE DE ORIGEN
                //Usuario = frmAutoriza.Usuario;
                ObtenerCorrelativoNotaSalida();

                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                objMovimientoAlmacen.IdMovimientoAlmacen = 0;
                objMovimientoAlmacen.Periodo = DateTime.Today.Year;
                objMovimientoAlmacen.IdTipoDocumento = Parametros.intTipoDocNotaSalida;//Convert.ToInt32(cboDocumento.EditValue);
                objMovimientoAlmacen.Numero = NumeroNotaSalida;
                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                objMovimientoAlmacen.IdAlmacenOrigen = Parametros.intAlmCentralUcayali;
                objMovimientoAlmacen.Fecha = DateTime.Today.Date;// Convert.ToDateTime(DateTime.Today.DateTime.ToShortDateString());
                objMovimientoAlmacen.IdMotivo = Parametros.intMovFaltanteOrigen; //Convert.ToInt32(cboMotivo.EditValue);
                objMovimientoAlmacen.NumeroDocumento = "X BULTO";
                objMovimientoAlmacen.Referencia = "";
                objMovimientoAlmacen.Observaciones = "Factura Nº " + cboDocumento.Text; //"No llegó al inventario";//+ " - " + txtDescCliente.Text.ToLower() ;
                objMovimientoAlmacen.IdAlmacenDestino = Parametros.intAlmCentralUcayali;//cboAlmacenDestino.Text.Trim() == "" ? (int?)null : Convert.ToInt32(cboAlmacenDestino.EditValue);
                objMovimientoAlmacen.IdCliente = null;//IdCliente == null ? (int?)null : IdCliente;
                objMovimientoAlmacen.FlagEstado = true;
                objMovimientoAlmacen.Usuario = frmAutoriza.Usuario; //Parametros.strUsuarioLogin;
                objMovimientoAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objMovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;
                objMovimientoAlmacen.IdTienda = Parametros.intTiendaId;
                objMovimientoAlmacen.IdAuxiliar = null;//IdAuxiliar == null ? (int?)null : IdAuxiliar; //objMovimientoAlmacen.IdAuxiliar = IdAuxiliar;

                int Contador = 1;
                //Registro de Compra Detalle
                List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = new List<MovimientoAlmacenDetalleBE>();

                foreach (var item in mLista)
                {
                    if (item.IdProducto > 0)
                    {
                        MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0; //item.IdMovimientoAlmacenDetalle;
                        objE_MovimientoAlmacenDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0; //IdMovimientoAlmacen;
                        objE_MovimientoAlmacenDetalle.Item = Contador;//item.Item;
                        objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                        objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CantidadAnt = item.CantidadAnt;
                        objE_MovimientoAlmacenDetalle.CostoUnitario = item.PrecioUnitario;
                        objE_MovimientoAlmacenDetalle.MontoTotal = item.CostoUnitario;//item.MontoTotal;
                        objE_MovimientoAlmacenDetalle.IdKardex = item.IdKardex;
                        objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                        objE_MovimientoAlmacenDetalle.FlagEstado = true;
                        objE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        //objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                        lstMovimientoAlmacenDetalle.Add(objE_MovimientoAlmacenDetalle);
                    }
                    Contador = Contador + 1;

                }

                objBL_MovimientoAlmacen.Inserta(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
                XtraMessageBox.Show("La transacción se generó correctamente, Numero de N/S: " + NumeroNotaSalida, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
                this.Close();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void descargartodorecibidotoolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;

        //        //string Usuario = Parametros.strUsuarioLogin;
        //        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
        //        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
        //        frmAutoriza.ShowDialog();

        //        if (!frmAutoriza.Edita)
        //        {
        //            return;
        //        }
        //        string Maquina = WindowsIdentity.GetCurrent().Name.ToString();
        //        //if (mListaBulto.Count == 0)
        //        //{
        //        //    XtraMessageBox.Show("No se puede descargar, No existen bultos!", this.Text);
        //        //    return;
        //        //}


        //        if (frmAutoriza.Usuario == "almacen1")
        //        {
        //            XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
        //            return;
        //        }

        //        BultoBL objBL_Bulto = new BultoBL();
        //        objBL_Bulto.ActualizaTransferenciaFactura(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue), Maquina);

        //        XtraMessageBox.Show("Bultos descargados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        Cursor = Cursors.Default;
        //        this.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor = Cursors.Default;
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void descargartodorecibidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<BultoBE> mListaBulto = new List<BultoBE>();
                mListaBulto = new BultoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue));
                //gcBulto.DataSource = mListaBulto;

                if (mListaBulto.Count == 0)
                {
                    XtraMessageBox.Show("No se puede descargar, No existen bultos!", this.Text);
                    return;
                }

                //string Usuario = Parametros.strUsuarioLogin;
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (!frmAutoriza.Edita)
                {
                    return;
                }

                if (frmAutoriza.Usuario == "almacen1")
                {
                    XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                    return;
                }

                int Row = 1;
                //int TotRow = 2;

                //TotRow = TotRow - Row + 1;
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = mListaBulto.Count;
                prgFactura.Properties.Minimum = 0;

                //RECIBIR A ALMACEN DE BULTO
                BultoBL objBL_Bulto = new BultoBL();
                foreach (var item in mListaBulto)
                {
                    lblMensaje.Text = "Recepcionando bulto...";
                    BultoBE objE_Bulto = new BultoBE();
                    objE_Bulto.IdBulto = item.IdBulto;
                    objE_Bulto.IdEmpresa = item.IdEmpresa;//Parametros.intEmpresaId;
                    objE_Bulto.IdAlmacen = item.IdAlmacen;//Convert.ToInt32(cboAlmacen.EditValue);
                    objE_Bulto.IdSector = 0;//Convert.ToInt32(cboSector.EditValue);
                    objE_Bulto.IdBloque = 0; //Convert.ToInt32(cboBloque.EditValue);
                    objE_Bulto.IdProducto = item.IdProducto;
                    objE_Bulto.NumeroBulto = "ANAQ"; //txtNumeroBulto.Text;
                    objE_Bulto.Agrupacion = item.Agrupacion; //txtAgrupacion.Text;
                    objE_Bulto.IdFacturaCompra = item.IdFacturaCompra;
                    objE_Bulto.PrecioUnitario = item.PrecioUnitario;
                    objE_Bulto.Cantidad = item.Cantidad;//Convert.ToInt32(txtCantidad.EditValue);
                    objE_Bulto.CostoUnitario = item.CostoUnitario; //CostoUnitario;
                    objE_Bulto.FechaIngreso = item.FechaIngreso;// Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString());
                    objE_Bulto.IdSituacion = Parametros.intBULRecibido;
                    objE_Bulto.Periodo = item.Periodo; //deFechaIngreso.DateTime.Year;
                    objE_Bulto.IdTipoDocumento = item.IdTipoDocumento; //IdTipoDocumento;
                    objE_Bulto.NumeroDocumento = item.NumeroDocumento; // NumeroDocumento;
                    objE_Bulto.Observacion = "Bulto Recepcionado Automático"; //txtObservacion.Text;
                    objE_Bulto.IdKardex = null;
                    objE_Bulto.FlagEstado = true;
                    objE_Bulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Bulto.Usuario = Parametros.strUsuarioLogin;

                    objBL_Bulto.ActualizaFactura(objE_Bulto);

                    prgFactura.PerformStep();
                    prgFactura.Update();
                    Row++;
                }

                Row = 1;
                //TRANSFERENCIA DE BULTO
                foreach (var item in mListaBulto)
                {
                    //Establecer Los Datos de Cabecera de la Transferencia del Bulto
                    TransferenciaBultoBE objE_TransferenciaBulto = new TransferenciaBultoBE();
                    objE_TransferenciaBulto.IdTransferenciaBulto = 0;
                    objE_TransferenciaBulto.IdEmpresa = Parametros.intEmpresaId;
                    objE_TransferenciaBulto.IdTienda = Parametros.intTiendaId;
                    objE_TransferenciaBulto.Periodo = Parametros.intPeriodo;
                    objE_TransferenciaBulto.IdTipoDocumento = Parametros.intTipoDocTransferencia;
                    objE_TransferenciaBulto.NumeroDocumento = ""; //ObtenerCorrelativo(); For Kardex Bulto;
                    objE_TransferenciaBulto.FechaMovimiento = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    objE_TransferenciaBulto.IdAlmacenOrigen = Parametros.intAlmBultos;
                    objE_TransferenciaBulto.IdAlmacenDestino = Parametros.intAlmAnaqueles;//.intAlmCentralUcayali;
                    objE_TransferenciaBulto.Observacion = "Transferencia Automática a Anaqueles";
                    objE_TransferenciaBulto.IdMovimientoAlmacenIngreso = 0;
                    objE_TransferenciaBulto.IdMovimientoAlmacenSalida = 0;
                    objE_TransferenciaBulto.FlagEstado = true;
                    objE_TransferenciaBulto.Usuario = Parametros.strUsuarioLogin;
                    objE_TransferenciaBulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    List<TransferenciaBultoDetalleBE> lstListaTransferenciaDetalle = new List<TransferenciaBultoDetalleBE>();

                    //Establecer los datos del detalle de la transferencia de bultos
                    TransferenciaBultoDetalleBE objE_DetalleTransferencia = new TransferenciaBultoDetalleBE();
                    objE_DetalleTransferencia.IdTransferenciaBultoDetalle = 0;
                    objE_DetalleTransferencia.IdTransferenciaBulto = 0;
                    objE_DetalleTransferencia.IdBulto = item.IdBulto;
                    objE_DetalleTransferencia.IdProducto = item.IdProducto;
                    objE_DetalleTransferencia.Cantidad = item.Cantidad;
                    objE_DetalleTransferencia.IdKardexBulto = 0;
                    objE_DetalleTransferencia.IdKardex = 0;
                    objE_DetalleTransferencia.FlagEstado = true;
                    objE_DetalleTransferencia.Abreviatura = item.Abreviatura;
                    objE_DetalleTransferencia.PrecioUnitario = item.PrecioUnitario;
                    objE_DetalleTransferencia.Usuario = Parametros.strUsuarioLogin;
                    objE_DetalleTransferencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_DetalleTransferencia.IdEmpresa = Parametros.intEmpresaId;
                    lstListaTransferenciaDetalle.Add(objE_DetalleTransferencia);

                    //Realizamos la transferencia de bultos
                    TransferenciaBultoBL objBL_TransferenciaBulto = new TransferenciaBultoBL();
                    objBL_TransferenciaBulto.Inserta(objE_TransferenciaBulto, lstListaTransferenciaDetalle);

                    lblMensaje.Text = "Transferencia a Anaquel...";
                    prgFactura.PerformStep();
                    prgFactura.Update();
                    Row++;


                }
                XtraMessageBox.Show("Bultos descargados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default;
                this.Close();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            if (cboProveedor.Text.ToString().Trim() == "")
            {
                XtraMessageBox.Show("Seleccione un proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboProveedor.Focus();
            }

            if (cboDocumento.Text.ToString().Trim() == "")
            {
                XtraMessageBox.Show("Seleccione una factura compra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDocumento.Focus();
            }

            FacturaCompraBE objE_Factura = null;
            objE_Factura = new FacturaCompraBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue));
            if (objE_Factura != null)
            {
                if (objE_Factura.FechaRecepcion==null)
                {
                    XtraMessageBox.Show("Falta registrar la fecha de recepción\nPor favor consultar con el área de Importaciones.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }


            mLista = new BultoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboDocumento.EditValue));
            gcBulto.DataSource = mLista;

            txtCantidad.Text = mLista.Count().ToString();
        }

        private void CargarBusqueda()
        {
            gcBulto.DataSource = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
            txtCantidad.Text = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).Count().ToString();
        }

        public void InicializarModificar()
        {
            if (gvBulto.RowCount > 0)
            {
                BultoBE objBulto = new BultoBE();
                objBulto.IdBulto = int.Parse(gvBulto.GetFocusedRowCellValue("IdBulto").ToString());

                frmManBultoEdit objManBultoEdit = new frmManBultoEdit();
                objManBultoEdit.pOperacion = frmManBultoEdit.Operacion.Modificar;
                objManBultoEdit.IdBulto = objBulto.IdBulto;
                objManBultoEdit.SituacionBulto = Parametros.intBULGenerado;
                objManBultoEdit.StartPosition = FormStartPosition.CenterParent;
                //objManBultoEdit.ShowDialog();
                if (objManBultoEdit.ShowDialog() == DialogResult.OK)
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

            if (gvBulto.GetFocusedRowCellValue("IdBulto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Bulto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void ObtenerCorrelativoNotaSalida()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocNotaSalida, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                NumeroNotaSalida = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}