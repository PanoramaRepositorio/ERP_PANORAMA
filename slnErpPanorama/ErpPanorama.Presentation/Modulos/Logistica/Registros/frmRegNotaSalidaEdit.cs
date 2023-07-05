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
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

using Excel = Microsoft.Office.Interop.Excel;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegNotaSalidaEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<MovimientoAlmacenBE> lstMovimientoAlmacen;
        public List<CMovimientoAlmacenDetalle> mListaMovimientoAlmacenDetalleOrigen = new List<CMovimientoAlmacenDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdMovimientoAlmacen = 0;

        public int IdMovimientoAlmacen
        {
            get { return _IdMovimientoAlmacen; }
            set { _IdMovimientoAlmacen = value; }
        }

        private string Usuario = Parametros.strUsuarioLogin;
        private int? IdAuxiliar;
        private int? IdCliente;
        private int? IdSolicitudProducto;
        private int? IdMovimientoAlmacenReferencia;

        #endregion

        #region "Eventos"

        public frmRegNotaSalidaEdit()
        {
            InitializeComponent();
        }

        private void frmRegNotaSalidaEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;

            if (Parametros.strUsuarioLogin == "jvasquez" || Parametros.strUsuarioLogin == "MASTER" || Parametros.strUsuarioLogin == "JTAPIA"
                || Parametros.strUsuarioLogin == "ADAVILA" || Parametros.strUsuarioLogin == "JLQUISPE" || Parametros.strUsuarioLogin == "EVALDEZ"
                || Parametros.strUsuarioLogin == "PDIAZ" || Parametros.strUsuarioLogin == "pdiaz" || Parametros.strUsuarioLogin == "kconcha"
                || Parametros.strUsuarioLogin == "focampo" || Parametros.strUsuarioLogin == "egutierrez" || Parametros.intPerfilId == Parametros.intPerAdministrador
                || Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.intPerfilId == Parametros.intPerJefeMarketingPublicidad
                || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen
                || Parametros.intPerfilId == Parametros.intPerComunity || Parametros.intPerfilId == Parametros.intPerAnalistaInventario
                || Parametros.intPerfilId == Parametros.intPerAnalistaProducto || Parametros.intPerfilId == Parametros.intPerAsistenteMarketing || Parametros.intPerfilId == Parametros.intPerAsistenteMarketing)  ///Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen || 
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            }
            else
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivoPrincipal(Parametros.intEmpresaId, Parametros.intTiendaId), "DescAlmacen", "IdAlmacen", true);
            }

            BSUtils.LoaderLook(cboCausal, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblCausal), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            // cboVendedor.EditValue = Parametros.intPersonaId;

            //BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivoPrincipal(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            // Nuevas restricciones de acuerdo al perfil
            if (Parametros.strUsuarioLogin == "jtapia" || Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.intPerfilId == Parametros.intPerAnalistaInventario || Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                       BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivoPerfil(Parametros.intEmpresaId, 1, Parametros.intPerfilId), "DescAlmacen", "IdAlmacen", true);
                }
            else if(Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeMarketingPublicidad || Parametros.intPerfilId == Parametros.intPerJefeProduccion
                    || Parametros.intPerfilId == Parametros.intPerJefeProduccion1)
                {
                    BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivoPrincipalMar(Parametros.intEmpresaId, Parametros.intTiendaId), "DescAlmacen", "IdAlmacen", true);
                }
            else //los demas almacen
                {
                    BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaAlmacenesTodosActivos(Parametros.intEmpresaId, Parametros.intTiendaId), "DescAlmacen", "IdAlmacen", true);
                }

            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaNotaSalida(Parametros.intModLogistica), "CodTipoDocumento", "IdTipoDocumento", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaAlmacenSalida(Parametros.intEmpresaId), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMovTransferencia;



            //BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            deFechaDelivery.EditValue = DateTime.Now;
            txtBultos.Text = "0";

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Nota de Salida - Nuevo";
                txtAnio.Text = Convert.ToString(DateTime.Now.Date.Year); 
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Nota de Salida - Modificar";

                MovimientoAlmacenBE objE_MovimientoAlmacen = null;
                objE_MovimientoAlmacen = new MovimientoAlmacenBL().Selecciona(Parametros.intEmpresaId, IdMovimientoAlmacen);

                IdMovimientoAlmacen = objE_MovimientoAlmacen.IdMovimientoAlmacen;
                cboAlmacen.EditValue = objE_MovimientoAlmacen.IdAlmacenOrigen;
                txtNumero.Text = objE_MovimientoAlmacen.Numero;
                deFecha.EditValue = objE_MovimientoAlmacen.Fecha;
                deFechaDelivery.EditValue = objE_MovimientoAlmacen.FechaDelivery;
                cboDocumento.EditValue = objE_MovimientoAlmacen.IdTipoDocumento;
                txtNumeroDocumento.Text = objE_MovimientoAlmacen.NumeroDocumento;
                cboMotivo.EditValue = objE_MovimientoAlmacen.IdMotivo;
                txtObservaciones.Text = objE_MovimientoAlmacen.Observaciones;
                cboAlmacenDestino.EditValue = objE_MovimientoAlmacen.IdAlmacenDestino;
                IdCliente = objE_MovimientoAlmacen.IdCliente;
                IdSolicitudProducto = objE_MovimientoAlmacen.IdSolicitudProducto;
                IdMovimientoAlmacenReferencia = objE_MovimientoAlmacen.IdMovimientoAlmacenReferencia;
                txtBultos.Text = objE_MovimientoAlmacen.Bultos.ToString();


                ///Ver Cliente/Proveedor
                if (IdCliente != null)
                {
                    ClienteBE ObjE_Cliente = new ClienteBE();
                    ObjE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(IdCliente));
                    IdCliente = ObjE_Cliente.IdCliente;
                    txtNumeroDoc.Text = ObjE_Cliente.NumeroDocumento;
                    txtDescCliente.Text = ObjE_Cliente.DescCliente;
                }

                //if(Parametros.intPerfilId != Parametros.intPerAdministrador)
                //    this.ContextMenuStrip = null;
                if(objE_MovimientoAlmacen.FlagRecibido)
                    mnuContextual.Enabled = false;
            }

            CargaMovimientoAlmacenDetalle();
            BloquearAccesoPorPerfil();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (deFechaDelivery.Text == "" && Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovTransferencia && IdSolicitudProducto == null)
                {
                    XtraMessageBox.Show("Ud. Debe ingresar la fecha de delivery", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    deFechaDelivery.Focus();
                    return;
                }

                //string Usuario = Parametros.strUsuarioLogin;
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (!frmAutoriza.Edita)
                {
                    Cursor = Cursors.Default;
                    return;
                }

                if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                    return;
                }

                if (!ValidarSalida())
                {
                    Cursor = Cursors.WaitCursor;

                    ////string Usuario = Parametros.strUsuarioLogin;
                    //frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    //frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    //frmAutoriza.ShowDialog();

                    //if (!frmAutoriza.Edita)
                    //{
                    //    return;
                    //}

                    //if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                    //{
                    //    XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                    //    return; 
                    //}

                    //ObtenerCorrelativo();
                    Usuario = frmAutoriza.Usuario;

                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                    MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                    objMovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
                    objMovimientoAlmacen.Periodo = deFecha.DateTime.Year;
                    objMovimientoAlmacen.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                    objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                    objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(cboAlmacen.EditValue);
                    objMovimientoAlmacen.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    //objMovimientoAlmacen.FechaDelivery = Convert.ToDateTime(deFechaDelivery.DateTime.ToShortDateString());
                    objMovimientoAlmacen.FechaDelivery = deFechaDelivery.Text == "" ? (DateTime?)null : Convert.ToDateTime(deFechaDelivery.DateTime.ToShortDateString());
                    objMovimientoAlmacen.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objMovimientoAlmacen.NumeroDocumento = txtNumeroDocumento.Text;
                    objMovimientoAlmacen.Referencia = "";
                    objMovimientoAlmacen.Observaciones = txtObservaciones.Text.Trim();//+ " - " + txtDescCliente.Text.ToLower() ;
                    objMovimientoAlmacen.IdAlmacenDestino = cboAlmacenDestino.Text.Trim() == "" ? (int?)null : Convert.ToInt32(cboAlmacenDestino.EditValue);
                    objMovimientoAlmacen.IdCliente = IdCliente == null ? (int?)null : IdCliente;
                    objMovimientoAlmacen.IdSolicitudProducto = IdSolicitudProducto == null ? (int?)null : IdSolicitudProducto;
                    objMovimientoAlmacen.IdMovimientoAlmacenReferencia = IdMovimientoAlmacenReferencia == null ? (int?)null : IdMovimientoAlmacenReferencia;
                    objMovimientoAlmacen.FlagEstado = true;
                    objMovimientoAlmacen.Usuario = Usuario; //Parametros.strUsuarioLogin;
                    objMovimientoAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objMovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;
                    objMovimientoAlmacen.IdTienda = Parametros.intTiendaId;
                    objMovimientoAlmacen.IdAuxiliar = IdAuxiliar == null ? (int?)null : IdAuxiliar; //objMovimientoAlmacen.IdAuxiliar = IdAuxiliar;
                    objMovimientoAlmacen.Bultos = Convert.ToInt32(txtBultos.Text);

                    objMovimientoAlmacen.IdCausalTransferencia = Convert.ToInt32(cboCausal.EditValue);
                    objMovimientoAlmacen.DocReferencia = txtDocRef.Text.Trim();
                    objMovimientoAlmacen.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);

                    int Contador = 0;
                    //Registro de Compra Detalle
                    List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = new List<MovimientoAlmacenDetalleBE>();
                    
                    foreach (var item in mListaMovimientoAlmacenDetalleOrigen)
                    {
                        if (item.IdProducto > 0)
                        {
                            MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                            objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                            objE_MovimientoAlmacenDetalle.IdEmpresa = Parametros.intEmpresaId;
                            objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = IdMovimientoAlmacen;
                            objE_MovimientoAlmacenDetalle.Item = item.Item;
                            objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                            objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                            objE_MovimientoAlmacenDetalle.CantidadAnt = item.CantidadAnt;
                            objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                            objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                            objE_MovimientoAlmacenDetalle.IdKardex = item.IdKardex;
                            objE_MovimientoAlmacenDetalle.Observacion =item.Observacion;
                            objE_MovimientoAlmacenDetalle.FlagEstado = true;
                            objE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                            lstMovimientoAlmacenDetalle.Add(objE_MovimientoAlmacenDetalle);
                        }
                        Contador = Contador + 1;   

                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                        string sNumero = "";
                        string sSerie = "";
                        mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocNotaSalida, Parametros.intPeriodo);
                        if (mListaNumero.Count > 0)
                        {
                            sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                            sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                        }
                        txtNumero.Text = sNumero;
                        objMovimientoAlmacen.Numero = sNumero; // txtNumero.Text;
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        int IdMovimiento = 0;
                        IdMovimiento = objBL_MovimientoAlmacen.Inserta(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);

                        //Nota De ingreso
                        if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovTranferenciaDirecta)
                        {
                            InsertaNotaIngreso(IdMovimiento);
                            objBL_MovimientoAlmacen.ActualizaRecibido(IdMovimiento,true);
                        }
                        XtraMessageBox.Show("Se genero satisfactoriamente la Nota de Salida Nro: " + sNumero.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        objMovimientoAlmacen.Numero =   txtNumero.Text;
                        objBL_MovimientoAlmacen.Actualiza(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
                    }

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

        private void gcTxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (chkHangTag.Checked == true)
                    {
                        StockBE pProductoBE = null;
                        string Codigo = (sender as TextEdit).Text;

                        if (Codigo.Count() > 6)
                        {
                            pProductoBE = new StockBL().SeleccionaProductoCodigoBarra(Parametros.intTiendaId, Convert.ToInt32(cboAlmacen.EditValue), Codigo); //Parametros.intAlmTienda, Codigo);
                        }
                        else
                        {
                            pProductoBE = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Convert.ToInt32(cboAlmacen.EditValue), Convert.ToInt32(Codigo)); //Parametros.intAlmTienda, Convert.ToInt32(Codigo));
                        }

                        if (pProductoBE != null)
                        {
                            if (mListaMovimientoAlmacenDetalleOrigen.Count > 1)
                            {
                                var BuscarDocumento = mListaMovimientoAlmacenDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == pProductoBE.CodigoProveedor).ToList();
                                if (BuscarDocumento.Count > 0)
                                {
                                    XtraMessageBox.Show("El Código de producto ya existe en la lista, por favor verifique." + "\n Código : " + pProductoBE.CodigoProveedor, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ColumRowFocus((sender as TextEdit).Text, "CodigoProveedor");
                                    return;
                                }
                            }

                            int index = gvMovimientoAlmacenDetalle.FocusedRowHandle;
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "IdProducto", pProductoBE.IdProducto);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "CodigoProveedor", pProductoBE.CodigoProveedor);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "NombreProducto", pProductoBE.NombreProducto);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Abreviatura", pProductoBE.Abreviatura);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Cantidad", 1);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "CostoUnitario", pProductoBE.CostoUnitario);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "MontoTotal", pProductoBE.CostoUnitario);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Stock", pProductoBE.Cantidad);

                            ColumRowFocusCantidad(pProductoBE.CodigoProveedor, "CodigoProveedor");
                        }

                    }

                    else
                    {
                        frmBusProductoCosto objBusProducto = new frmBusProductoCosto();
                        objBusProducto.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                        objBusProducto.pDescripcion = (sender as TextEdit).Text;
                        objBusProducto.ShowDialog();
                        if (objBusProducto.pProductoBE != null)
                        {
                            if (mListaMovimientoAlmacenDetalleOrigen.Count > 1)
                            {
                                var BuscarDocumento = mListaMovimientoAlmacenDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == objBusProducto.pProductoBE.CodigoProveedor).ToList();
                                if (BuscarDocumento.Count > 0)
                                {
                                    XtraMessageBox.Show("El Código de producto ya existe en la lista, por favor verifique." + "\n Código : " + objBusProducto.pProductoBE.CodigoProveedor, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ColumRowFocus((sender as TextEdit).Text, "CodigoProveedor");
                                    return;
                                }
                            }

                            int index = gvMovimientoAlmacenDetalle.FocusedRowHandle;
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "IdProducto", objBusProducto.pProductoBE.IdProducto);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "CodigoProveedor", objBusProducto.pProductoBE.CodigoProveedor);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "NombreProducto", objBusProducto.pProductoBE.NombreProducto);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Abreviatura", objBusProducto.pProductoBE.Abreviatura);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Cantidad", 1);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "CostoUnitario", objBusProducto.pProductoBE.CostoUnitario);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "MontoTotal", objBusProducto.pProductoBE.CostoUnitario);
                            gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Stock", objBusProducto.pProductoBE.Cantidad);

                            ColumRowFocusCantidad(objBusProducto.pProductoBE.CodigoProveedor, "CodigoProveedor");
                        }
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

        private void gcTxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    nuevoToolStripMenuItem_Click(sender, e);//add
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvMovimientoAlmacenDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int intCantidad = 0;
            decimal decCostoUnitario = 0;
            decimal decMontoTotal = 0;

            if (e.Column.Caption == "Cantidad")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intCantidad = int.Parse(e.Value.ToString());
                    decMontoTotal = decimal.Parse(gvMovimientoAlmacenDetalle.GetRowCellValue(e.RowHandle, gvMovimientoAlmacenDetalle.Columns["CostoUnitario"]).ToString()) * decimal.Parse(intCantidad.ToString());
                    gvMovimientoAlmacenDetalle.SetRowCellValue(e.RowHandle, gvMovimientoAlmacenDetalle.Columns["MontoTotal"], decMontoTotal);

                    //if (int.Parse(gvMovimientoAlmacenDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    //    //if (gvMovimientoAlmacenDetalle.GetFocusedRowCellDisplayText("Cantidad")== true)
                    //{
                        //nuevoToolStripMenuItem_Click(sender, e);//add
                    //}
                }
                
            }

            if (e.Column.Caption == "P.Unitario")
            {
                if (decimal.Parse(e.Value.ToString()) > 0)
                {
                    decCostoUnitario = decimal.Parse(e.Value.ToString());
                    decMontoTotal = decimal.Parse(gvMovimientoAlmacenDetalle.GetRowCellValue(e.RowHandle, gvMovimientoAlmacenDetalle.Columns["Cantidad"]).ToString()) * decCostoUnitario;
                    gvMovimientoAlmacenDetalle.SetRowCellValue(e.RowHandle, gvMovimientoAlmacenDetalle.Columns["MontoTotal"], decMontoTotal);
                }
            }


        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvMovimientoAlmacenDetalle.AddNewRow();
                gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Item", (mListaMovimientoAlmacenDetalleOrigen.Count - 1) + 1);
                gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "CodigoProveedor", "");
                if (pOperacion == Operacion.Modificar)
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                else
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                gvMovimientoAlmacenDetalle.FocusedColumn = gvMovimientoAlmacenDetalle.GetVisibleColumn(1);
                gvMovimientoAlmacenDetalle.ShowEditor();

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
                prgFactura.Visible = true;
                for (int i = 0; i < gvMovimientoAlmacenDetalle.SelectedRowsCount; i++)
                {

                    int row = gvMovimientoAlmacenDetalle.GetSelectedRows()[i];
                    int TotRow = gvMovimientoAlmacenDetalle.SelectedRowsCount;
                    TotRow = TotRow - row + 1;
                    prgFactura.Properties.Step = 1;
                    prgFactura.Properties.Maximum = TotRow;
                    prgFactura.Properties.Minimum = 0;

                    int IdMovimientoAlmacenDetalle = 0;
                    int IdProducto = 0;
                    int Cantidad = 0;
                    IdMovimientoAlmacenDetalle = int.Parse(gvMovimientoAlmacenDetalle.GetRowCellValue(row, "IdMovimientoAlmacenDetalle").ToString());
                    IdProducto = int.Parse(gvMovimientoAlmacenDetalle.GetRowCellValue(row, "IdProducto").ToString());
                    Cantidad = int.Parse(gvMovimientoAlmacenDetalle.GetRowCellValue(row, "Cantidad").ToString());
                    int Item = 0;
                    Item = int.Parse(gvMovimientoAlmacenDetalle.GetRowCellValue(row, "Item").ToString());

                    
                    MovimientoAlmacenDetalleBE objBE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                    objBE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = IdMovimientoAlmacenDetalle;
                    objBE_MovimientoAlmacenDetalle.IdProducto = IdProducto;
                    objBE_MovimientoAlmacenDetalle.Cantidad = Cantidad;
                    objBE_MovimientoAlmacenDetalle.IdEmpresa = Parametros.intEmpresaId;
                    objBE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                    objBE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (IdMovimientoAlmacen > 0)
                    {
                        if (IdProducto > 0)
                        {
                            MovimientoAlmacenDetalleBL objBL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL();
                            objBL_MovimientoAlmacenDetalle.Elimina(objBE_MovimientoAlmacenDetalle, Parametros.intTipoDocNotaSalida, Convert.ToInt32(cboAlmacen.EditValue));
                        }
                    }
                  
                    gvMovimientoAlmacenDetalle.DeleteSelectedRows();
                    gvMovimientoAlmacenDetalle.RefreshData();

                    //RegeneraItem
                    int f = 0;
                    int cuenta = 0;
                    foreach (var item in mListaMovimientoAlmacenDetalleOrigen)
                    {
                        item.Item = Convert.ToByte(cuenta + 1);
                        cuenta++;
                        f++;
                    }

                    prgFactura.Visible = false;

                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tmrNumero_Tick(object sender, EventArgs e)
        {
            //Obtener el correlativo del documento
            //if (pOperacion == Operacion.Nuevo)
            //    ObtenerCorrelativo();
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeteaMovimientoDetalle();

                switch (cboDocumento.Text)
                {
                    case "SCP": CargaSolicitudProductoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "N/S": CargaNotaSalidaDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "N/I": CargaNotaIngresoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "FAC": CargaFacturaCompra(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "PED": CargaPedidoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                        //break;
                    default:
                        break;
                }

                CalcularTotalDocumentos();
            }
        }


        private void SeteaMovimientoDetalle()
        {
            mListaMovimientoAlmacenDetalleOrigen.Clear();
            bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
            gcMovimientoAlmacenDetalle.DataSource = bsListado;
            gcMovimientoAlmacenDetalle.RefreshDataSource();
        }


        private void gvMovimientoAlmacenDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cboAlmacenDestino_EditValueChanged(object sender, EventArgs e)
        {
            //if (cboAlmacen.Text == cboAlmacenDestino.Text)
            //{
            //    XtraMessageBox.Show("No realizar este tipo de movimiento, Consultar con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void cboAlmacen_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovAjusteInventario || Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovMermas)
            {
                cboAlmacenDestino.EditValue = cboAlmacen.EditValue;
            }



        }

        private void cboMotivo_EditValueChanged(object sender, EventArgs e)
        {
            cboAlmacenDestino.Visible = true;
            txtNumeroDoc.Visible = false;
            txtDescCliente.Visible = false;
            btnBuscar.Visible = false;
            lblAlmacenDestino.Text = "Almacén Destino:";

            if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovAjusteInventario)
                txtMensajeMotivo.Text = "Permite regularizar Códigos, permitiendo una salida desde el almacen Origen";

            else if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovFaltanteOrigen)
                txtMensajeMotivo.Text = "Permite realizar movimiento por Mercadería faltante(Factura)";

            else if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovMermas)
                txtMensajeMotivo.Text = "La cantidad se descargará por falla de Origen";

            else if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovTransferencia)
                txtMensajeMotivo.Text = "Permite movimiento entre un Almacen Origen y un Almacen Destino ";

            else if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovTranferenciaDirecta)
                txtMensajeMotivo.Text = "La cantidad Ingresará directamente al almacén destino (Traspaso)";

            else if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovReparacionTaller)
            {
                txtMensajeMotivo.Text = "La Cantidad se descargará hacia un proveedor de Reparación.";
                lblAlmacenDestino.Text = "Proveedor:";
                cboAlmacenDestino.Visible = false;
                txtNumeroDoc.Visible = true;
                txtDescCliente.Visible = true;
                btnBuscar.Visible = true;
                //txtNumeroDoc.Focus();
            }


            //Validar Motivos
            if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovAjusteInventario || Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovMermas)
            {
                cboAlmacenDestino.EditValue = cboAlmacen.EditValue;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                if(Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerJefeAlmacen 
                    || Parametros.strUsuarioLogin =="gcuba" || Parametros.strUsuarioLogin == "asanchez" || Parametros.strUsuarioLogin == "adavila" || Parametros.intPerfilId == Parametros.intPerAnalistaInventario)
                {

                }else
                {
                    if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovAjusteInventario)
                    {
                        cboMotivo.EditValue = Parametros.intMovTransferencia;
                    }

                    if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovTranferenciaDirecta)
                    {
                        cboMotivo.EditValue = Parametros.intMovTransferencia;
                    }

                }

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

        private void btnLectorBarras_Click(object sender, EventArgs e)
        {
            CargarLector();
        }

        private void gcMovimientoAlmacenDetalle_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }


        #endregion

        #region "Metodos"

        private bool ValidarSalida()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboAlmacen.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un almacén.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboDocumento.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un documento de referencia.\n";
                flag = true;
            }

            //if (txtNumero.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese el numero.\n";
            //    flag = true;
            //}

            if (string.IsNullOrEmpty(cboMotivo.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un motivo de movimiento.\n";
                flag = true;
            }

            //if (Convert.ToInt32(txtBultos.Text)<=0)
            //{
            //    strMensaje = strMensaje + "- Ingrese la cantidad de Bultos.\n";
            //    flag = true;
            //}

            if (cboAlmacen.Text == cboAlmacenDestino.Text && Convert.ToInt32(cboMotivo.EditValue) != Parametros.intMovAjusteInventario && Convert.ToInt32(cboMotivo.EditValue) != Parametros.intMovMermas && Convert.ToInt32(cboMotivo.EditValue) != Parametros.intMovReparacionTaller && Convert.ToInt32(cboMotivo.EditValue) != Parametros.intMovFaltanteOrigen)
            {
                strMensaje = strMensaje + "- No se puede generar una salida hacia el mismo Almacén, Verificar almacén Destino.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovReparacionTaller && IdCliente == null)
            {
                strMensaje = strMensaje + "- No se puede generar una salida, Verificar Proveedor Destino.\n";
                flag = true;
            }

            if (Convert.ToInt32(cboMotivo.EditValue) != Parametros.intMovReparacionTaller)
            {
                IdCliente = null;
            }

            foreach (CMovimientoAlmacenDetalle item in mListaMovimientoAlmacenDetalleOrigen)
            {
                var BuscarCodigo = mListaMovimientoAlmacenDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == item.CodigoProveedor.ToUpper()).ToList();
                if (BuscarCodigo.Count > 1)
                {
                    strMensaje = strMensaje + "- El código de producto se repite en lista.\nEliminar Registros en blanco.\n";
                    flag = true;
                }

                if(item.Cantidad<=0)
                {
                    strMensaje = strMensaje + "- Ingresar cantidad válida en el código:"+ item.CodigoProveedor  +"\n";
                    flag = true;
                }

                if (!Parametros.bStockNegativo)
                { 
                    StockBE objE_Stock = new StockBE();
                    objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Convert.ToInt32(cboAlmacen.EditValue), item.IdProducto);
                    if (objE_Stock is null)
                    {
                        //MessageBox.Show("Error");
                        strMensaje = strMensaje + "- Verifique el código: " + item.CodigoProveedor + " cantidad Disponible: 0 "  + "\n";
                        flag = true;
                    }
                    else
                    {
                        if (item.Cantidad > objE_Stock.Cantidad)
                        {
                            strMensaje = strMensaje + "- Stock insuficiente para el código: " + item.CodigoProveedor + " cantidad Disponible " + objE_Stock.Cantidad + "\n";
                            flag = true;
                        }
                    }
                }
            }

            if (mListaMovimientoAlmacenDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Ingrese Productos.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void ObtenerCorrelativo()
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
                txtNumero.Text = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColumRowFocus(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcMovimientoAlmacenDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvMovimientoAlmacenDetalle.FocusedRowHandle + 1, column, searchText);
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
            ColumnView View = (ColumnView)gcMovimientoAlmacenDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            GridColumn columnbus = View.Columns["Cantidad"];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvMovimientoAlmacenDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = columnbus;
                }
            }
        }

        private void CargaSolicitudProductoDetalle(string Numero)
        {
            cboMotivo.EditValue = Parametros.intMovTransferencia;

            SolicitudProductoBE lstSolicitudProducto = null;
            lstSolicitudProducto = new SolicitudProductoBL().SeleccionaNumero(Parametros.intEmpresaId, Convert.ToInt32(txtAnio.EditValue),89 ,Numero);   //Parametros.intPeriodo     13, 2023, 89, '009376'
            if (lstSolicitudProducto != null)
            {
                if (lstSolicitudProducto.FlagRecibido==false)
                {
                    XtraMessageBox.Show("La Solicitud de Producto Nro. " + lstSolicitudProducto.Numero + " No esta recibida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

            }


            List<SolicitudProductoDetalleBE> lstSolicitudProductoDetalle = null;
            lstSolicitudProductoDetalle = new SolicitudProductoDetalleBL().ListaNumero(Parametros.intEmpresaId, Convert.ToInt32(txtAnio.EditValue) , Numero);   //Parametros.intPeriodo

            if (lstSolicitudProductoDetalle == null || lstSolicitudProductoDetalle.Count==0)
            {
                XtraMessageBox.Show("La solicitud no tiene registros y/o No está ENVIADO!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;//add 141215
            }

            cboCausal.EditValue = lstSolicitudProductoDetalle[0].IdCausalTransferencia;
            txtDocRef.Text = lstSolicitudProductoDetalle[0].DocReferencia.Trim();
            cboVendedor.EditValue = lstSolicitudProductoDetalle[0].IdVendedor;

            //Verificar Existencia
            MovimientoAlmacenBE objE_MovimientoAlmacen = null;
            objE_MovimientoAlmacen = new MovimientoAlmacenBL().SeleccionaTipoDocumento(Parametros.intEmpresaId, Parametros.intTipoDocSolicitudProducto, lstSolicitudProductoDetalle[0].IdSolicitudProducto);
            if (objE_MovimientoAlmacen != null)
            {
                XtraMessageBox.Show("La Solicitud de Producto fue atendida por:" + objE_MovimientoAlmacen.Usuario + " Utilizando la N/S: " + objE_MovimientoAlmacen.Numero , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //Cabecera
            //cboAlmacen.EditValue = lstSolicitudProductoDetalle[0].IdAlmacenOrigen;
            cboAlmacenDestino.EditValue = lstSolicitudProductoDetalle[0].IdAlmacenDestino;

            if (Parametros.bStockNegativo == false)
            {
                foreach (SolicitudProductoDetalleBE item in lstSolicitudProductoDetalle)
                {
                    #region "Validar Stock Físico"

                    int CantidadDisponible = 0;
                    StockBE objE_Stock = new StockBE();
                    objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, item.IdProducto);

                    if (objE_Stock is null)
                    {
                        MessageBox.Show("Error");
                    }

                    if (objE_Stock.Cantidad > item.Cantidad)
                    {
                        CantidadDisponible = item.Cantidad;
                    }
                    else
                    {
                        CantidadDisponible = objE_Stock.Cantidad;
                    }

                    #endregion
                    if (CantidadDisponible > 0)
                    {
                        CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                        objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                        objE_MovimientoAlmacenDetalle.Item = item.Item;
                        objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                        objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                        objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                        objE_MovimientoAlmacenDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                        objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                        objE_MovimientoAlmacenDetalle.Stock = CantidadDisponible;//item.Cantidad;
                        objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                        objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;

                        objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                        mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
                    }
                }

                if (mListaMovimientoAlmacenDetalleOrigen.Count == 0)
                {
                    XtraMessageBox.Show("La solicitud no puede ser atentido, STOCK INSUFICIENTE.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else 
            {
                foreach (SolicitudProductoDetalleBE item in lstSolicitudProductoDetalle)
                {
                    CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                    objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                    objE_MovimientoAlmacenDetalle.Item = item.Item;
                    objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                    objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                    objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                    objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;//
                    objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                    objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                    objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                    objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                    objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                    objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;

                    objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                    mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
                }            
            }

            IdAuxiliar = lstSolicitudProductoDetalle[0].IdAuxiliar; //Add
            IdSolicitudProducto = lstSolicitudProductoDetalle[0].IdSolicitudProducto;//add 141215

            bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
            gcMovimientoAlmacenDetalle.DataSource = bsListado;
            gcMovimientoAlmacenDetalle.RefreshDataSource();
        }


        private void CargaFacturaCompra(string Numero)
        {
            List<FacturaCompraDetalleBE> lstFacturaCompraDetalle = null;
            lstFacturaCompraDetalle = new FacturaCompraDetalleBL().ListaNumero(Parametros.intEmpresaId, Numero);

            int Item = 1;

            if (Parametros.bStockNegativo == false)
            {
                foreach (FacturaCompraDetalleBE item in lstFacturaCompraDetalle)
                {
                    #region "Validar Stock Físico"

                    int CantidadDisponible = 0;
                    StockBE objE_Stock = new StockBE();
                    objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Convert.ToInt32(cboAlmacen.EditValue), item.IdProducto);

                    if (objE_Stock == null)
                    {
                        XtraMessageBox.Show("Stock infuciente para el código:" + item.CodigoProveedor + ", Asegurese de tener recepcionado todos los bultos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (objE_Stock.Cantidad > 1)
                    {
                        CantidadDisponible = 1;// item.Cantidad;
                    }
                    else
                    {
                        CantidadDisponible = 0;// objE_Stock.Cantidad;
                    }

                    #endregion

                    if (CantidadDisponible > 0)
                    {
                        CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                        objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                        objE_MovimientoAlmacenDetalle.Item = Item;
                        objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                        objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                        objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                        objE_MovimientoAlmacenDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CostoUnitario = item.PrecioUnitario;
                        objE_MovimientoAlmacenDetalle.MontoTotal = item.Cantidad * item.PrecioUnitario;
                        objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                        objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                        mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
                    }

                    Item++;
                }
            }
            else
            {
                foreach (FacturaCompraDetalleBE item in lstFacturaCompraDetalle)
                {

                    CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                    objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                    objE_MovimientoAlmacenDetalle.Item = Item;
                    objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                    objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                    objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                    objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                    objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                    objE_MovimientoAlmacenDetalle.CostoUnitario = item.PrecioUnitario;
                    objE_MovimientoAlmacenDetalle.MontoTotal = item.Cantidad * item.PrecioUnitario;
                    objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                    objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                    objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                    mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);

                    Item++;
                }
            }


            bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
            gcMovimientoAlmacenDetalle.DataSource = bsListado;
            gcMovimientoAlmacenDetalle.RefreshDataSource();
        }

        private void CargaPedidoDetalle(string Numero)
        {
            cboMotivo.EditValue = Parametros.intMovTransferencia;

            PedidoBE ObjE_Pedido = new PedidoBE();
            ObjE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, Numero);

            if(ObjE_Pedido != null)
            {
                List<PedidoDetalleBE> lstPedidoDetalle = null;
                lstPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(ObjE_Pedido.IdPedido);

                if (Parametros.bStockNegativo == false)
                {
                    foreach (PedidoDetalleBE item in lstPedidoDetalle)
                    {
                        #region "Validar Stock Físico"

                        int CantidadDisponible = 0;
                        StockBE objE_Stock = new StockBE();
                        objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Convert.ToInt32(cboAlmacen.EditValue), item.IdProducto);

                        if (objE_Stock.Cantidad > item.Cantidad)
                        {
                            CantidadDisponible = item.Cantidad;
                        }
                        else
                        {
                            CantidadDisponible = objE_Stock.Cantidad;
                        }

                        #endregion
                        if (CantidadDisponible > 0)
                        {
                            CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                            objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                            objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                            objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                            objE_MovimientoAlmacenDetalle.Item = item.Item;
                            objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                            objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                            objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                            objE_MovimientoAlmacenDetalle.Cantidad = CantidadDisponible; //item.Cantidad;
                            objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                            objE_MovimientoAlmacenDetalle.CostoUnitario = 0; //item.PrecioUnitario;
                            objE_MovimientoAlmacenDetalle.MontoTotal = 0;// item.MontoTotal;
                            objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                            objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;

                            objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                            mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
                        }

                    }
                }
                else
                {
                    foreach (PedidoDetalleBE item in lstPedidoDetalle)
                    {
                        CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                        objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                        objE_MovimientoAlmacenDetalle.Item = item.Item;
                        objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                        objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                        objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                        objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CostoUnitario = item.PrecioUnitario;
                        objE_MovimientoAlmacenDetalle.MontoTotal = 0;//item.PrecioUnitario * item.Cantidad;
                        objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;

                        objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                        mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
                    }

                    bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
                    gcMovimientoAlmacenDetalle.DataSource = bsListado;
                    gcMovimientoAlmacenDetalle.RefreshDataSource();         
                }
            }
            else
            {
                XtraMessageBox.Show("El número de Pedido no existe!, Verificar en el periodo: " + Parametros.intPeriodo.ToString() , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void    CargaNotaSalidaDetalle(string Numero)
        {
            List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = null;
            lstMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intTipMovSalida, Numero);

            if (Parametros.bStockNegativo == false)
            {
                foreach (MovimientoAlmacenDetalleBE item in lstMovimientoAlmacenDetalle)
                {
                    #region "Validar Stock Físico"

                    int CantidadDisponible = 0;
                    StockBE objE_Stock = new StockBE();
                    objE_Stock = new StockBL().SeleccionaCantidadIdProducto(Parametros.intTiendaId, Convert.ToInt32(cboAlmacen.EditValue), item.IdProducto);

                    if (objE_Stock.Cantidad > item.Cantidad)
                    {
                        CantidadDisponible = item.Cantidad;
                    }
                    else
                    {
                        CantidadDisponible = objE_Stock.Cantidad;
                    }

                    #endregion
                    if (CantidadDisponible > 0)
                    {
                        CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                        objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;// item.IdMovimientoAlmacen;
                        objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;//item.IdMovimientoAlmacenDetalle;
                        objE_MovimientoAlmacenDetalle.Item = item.Item;
                        objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                        objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                        objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                        objE_MovimientoAlmacenDetalle.Cantidad = CantidadDisponible;//item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                        objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                        objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                        objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                        objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                        mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
                    }
                }
            }
            else
            {
                foreach (MovimientoAlmacenDetalleBE item in lstMovimientoAlmacenDetalle)
                {
                    CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                    objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = 0;// item.IdMovimientoAlmacen;
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;//item.IdMovimientoAlmacenDetalle;
                    objE_MovimientoAlmacenDetalle.Item = item.Item;
                    objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                    objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                    objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                    objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                    objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                    objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                    objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                    objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                    objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                    objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                    mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
                }            
            }
            bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
            gcMovimientoAlmacenDetalle.DataSource = bsListado;
            gcMovimientoAlmacenDetalle.RefreshDataSource();
        }

        private void CargaNotaIngresoDetalle(string Numero)
        {
            List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = null;
            lstMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intTipMovIngreso , Numero);

            foreach (MovimientoAlmacenDetalleBE item in lstMovimientoAlmacenDetalle)
            {
                CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = item.IdMovimientoAlmacen;
                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                objE_MovimientoAlmacenDetalle.Item = item.Item;
                objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
            }

            bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
            gcMovimientoAlmacenDetalle.DataSource = bsListado;
            gcMovimientoAlmacenDetalle.RefreshDataSource();
        }

        private void CargaMovimientoAlmacenDetalle()
        {
            List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = null;
            lstMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdMovimientoAlmacen);

            foreach (MovimientoAlmacenDetalleBE item in lstMovimientoAlmacenDetalle)
            {
                CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = item.IdMovimientoAlmacen;
                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                objE_MovimientoAlmacenDetalle.Item = item.Item;
                objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                objE_MovimientoAlmacenDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_MovimientoAlmacenDetalle.NombreProducto = item.NombreProducto;
                objE_MovimientoAlmacenDetalle.Abreviatura = item.Abreviatura;
                objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                objE_MovimientoAlmacenDetalle.CantidadAnt = item.Cantidad;
                objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                objE_MovimientoAlmacenDetalle.Stock = item.Cantidad;
                objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                objE_MovimientoAlmacenDetalle.FlagEstado = item.FlagEstado;
                objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                mListaMovimientoAlmacenDetalleOrigen.Add(objE_MovimientoAlmacenDetalle);
            }

            bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
            gcMovimientoAlmacenDetalle.DataSource = bsListado;
            gcMovimientoAlmacenDetalle.RefreshDataSource();

            CalcularTotalDocumentos();
        }

        private void BloquearAccesoPorPerfil()
        {
            UsuarioBE ObjE_Usuario = null;
            ObjE_Usuario = new UsuarioBL().Selecciona(Parametros.intUsuarioId);

            if (ObjE_Usuario != null)
            {
                if (ObjE_Usuario.IdPerfil == 1 || ObjE_Usuario.IdPerfil == 18 || ObjE_Usuario.IdPerfil == 21 || ObjE_Usuario.IdPerfil == 40 || ObjE_Usuario.IdPerfil == 20 || Parametros.strUsuarioLogin == "kconcha" || Parametros.strUsuarioLogin == "focampo")
                {
                    //cboMotivo.Properties.ReadOnly = false;
                    importartoolStripMenuItem.Visible = true;
                }
            }

            if (Parametros.strUsuarioLogin == "gcuba" || Parametros.strUsuarioLogin == "ALAN" || Parametros.strUsuarioLogin == "jhonny" || Parametros.strUsuarioLogin == "yosorio" || Parametros.strUsuarioLogin == "aflores")
            {
                //cboMotivo.Properties.ReadOnly = false;
                importartoolStripMenuItem.Visible = true;
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


                //Recorremos para la Nota de Salida
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        gvMovimientoAlmacenDetalle.AddNewRow();
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "IdMovimientoAlmacen", 0);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "IdMovimientoAlmacenDetalle", 0);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Item", (mListaMovimientoAlmacenDetalleOrigen.Count - 1) + 1);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "CostoUnitario", 0);
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "MontoTotal", 0);
                        if (pOperacion == Operacion.Modificar)
                            gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    }
                    else
                    {
                        XtraMessageBox.Show("El código " + CodigoProveedor + "No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

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

        private void InsertaNotaIngreso(int IdMovimientoReferencia)
        {
            //Correlativo
            List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
            string sNumero = "";
            string sSerie = "";
            mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocNotaIngreso, Parametros.intPeriodo);
            if (mListaNumero.Count > 0)
            {
                sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
            }

            //Nota Ingreso
            MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
            MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

            objMovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
            objMovimientoAlmacen.Periodo = deFecha.DateTime.Year;
            objMovimientoAlmacen.IdTipoDocumento = Parametros.intTipoDocNotaSalida;
            objMovimientoAlmacen.Numero = sNumero;//txtNumero.Text;
            objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovIngreso;
            objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(cboAlmacenDestino.EditValue);
            objMovimientoAlmacen.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            objMovimientoAlmacen.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
            objMovimientoAlmacen.NumeroDocumento = txtNumero.Text;
            objMovimientoAlmacen.Referencia = "";
            objMovimientoAlmacen.Observaciones = "Recepción Automática";
            objMovimientoAlmacen.IdAlmacenDestino = Convert.ToInt32(cboAlmacen.EditValue);
            objMovimientoAlmacen.IdMovimientoAlmacenReferencia = IdMovimientoReferencia;
            objMovimientoAlmacen.FlagEstado = true;
            objMovimientoAlmacen.Usuario = Usuario;//Parametros.strUsuarioLogin;
            objMovimientoAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objMovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;
            objMovimientoAlmacen.IdTienda = Parametros.intTiendaId;

            //Registro de Compra Detalle
            List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = new List<MovimientoAlmacenDetalleBE>();

            foreach (var item in mListaMovimientoAlmacenDetalleOrigen)
            {
                MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = item.IdMovimientoAlmacenDetalle;
                objE_MovimientoAlmacenDetalle.IdEmpresa = Parametros.intEmpresaId;
                objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = IdMovimientoAlmacen;
                objE_MovimientoAlmacenDetalle.Item = item.Item;
                objE_MovimientoAlmacenDetalle.IdProducto = item.IdProducto;
                objE_MovimientoAlmacenDetalle.Cantidad = item.Cantidad;
                objE_MovimientoAlmacenDetalle.CantidadAnt = item.CantidadAnt;
                objE_MovimientoAlmacenDetalle.CostoUnitario = item.CostoUnitario;
                objE_MovimientoAlmacenDetalle.MontoTotal = item.MontoTotal;
                objE_MovimientoAlmacenDetalle.IdKardex = item.IdKardex;
                objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                objE_MovimientoAlmacenDetalle.FlagEstado = true;
                objE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                objE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                lstMovimientoAlmacenDetalle.Add(objE_MovimientoAlmacenDetalle);
            }

            if (pOperacion == Operacion.Nuevo)
            {
                objBL_MovimientoAlmacen.Inserta(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
                XtraMessageBox.Show("Se generó correctamente la Nota de Salida y Nota de Ingreso N° " + sNumero, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objBL_MovimientoAlmacen.Actualiza(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
            }        
        }

        private void CargarLector()
        {
            frmRegAuditoriaPedidoDetalleEdit frm = new frmRegAuditoriaPedidoDetalleEdit();
            frm.StartPosition = FormStartPosition.Manual;
            //frm.Location = new Point(100, 100);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int decCantidad = 0;
                int cantidadLectura = 0;
                int IdProducto = 0;
                string CodigoProveedor = "";
                string NombreProducto = "";
                string Abreviatura = "";

                bool FlagExiste = false;
                cantidadLectura = frm.oBE.Cantidad;
                IdProducto = frm.oBE.IdProducto;
                CodigoProveedor = frm.oBE.CodigoProveedor;
                NombreProducto = frm.oBE.NombreProducto;
                Abreviatura = frm.oBE.Abreviatura;


                for (int i = 0; i < gvMovimientoAlmacenDetalle.RowCount; i++)
                {
                    int IdProductoLista =0;
                    int row = gvMovimientoAlmacenDetalle.GetRowHandle(i);

                    IdProductoLista = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(row, (gvMovimientoAlmacenDetalle.Columns["IdProducto"])));

                    if (IdProducto == IdProductoLista)
                    {
                        decCantidad = Convert.ToInt32(gvMovimientoAlmacenDetalle.GetRowCellValue(row, (gvMovimientoAlmacenDetalle.Columns["Cantidad"])));
                        gvMovimientoAlmacenDetalle.SetRowCellValue(row, gvMovimientoAlmacenDetalle.Columns["Cantidad"], decCantidad + cantidadLectura);
                        lblMensaje.Text = (decCantidad + cantidadLectura).ToString();
                        lblMensaje2.Text = CodigoProveedor;

                        CalcularTotalDocumentos();
                        CargarLector();
                        return;
                    }

                }                

                if (!FlagExiste)
                {
                    //XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " No Existe, Consultar con el Personal de Picking!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    gvMovimientoAlmacenDetalle.AddNewRow();
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Item", (mListaMovimientoAlmacenDetalleOrigen.Count - 1) + 1);
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "IdProducto", IdProducto);
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "CodigoProveedor", CodigoProveedor);
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "NombreProducto", NombreProducto);
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Abreviatura", Abreviatura);
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "Cantidad", cantidadLectura);
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "CostoUnitario", 0);
                    gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "MontoTotal", 0);

                    
                    if (pOperacion == Operacion.Modificar)
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    else
                        gvMovimientoAlmacenDetalle.SetRowCellValue(gvMovimientoAlmacenDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    gvMovimientoAlmacenDetalle.FocusedColumn = gvMovimientoAlmacenDetalle.GetVisibleColumn(1);
                    gvMovimientoAlmacenDetalle.ShowEditor();

                    lblMensaje.Text = cantidadLectura.ToString();
                    lblMensaje2.Text = CodigoProveedor;
                }

                CargarLector();
                //CalcularTotalDocumentos();
            }
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvMovimientoAlmacenDetalle.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvMovimientoAlmacenDetalle.GetRowCellValue(i, (gvMovimientoAlmacenDetalle.Columns["Cantidad"])));
                }

                txtTotalCantidad.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.pNumeroDescCliente = txtNumeroDoc.Text.Trim();
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDoc.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtObservaciones.Text = frm.pClienteBE.DescCliente;
                    txtObservaciones.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDoc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnBuscar_Click(sender, e);

                //numero o cadena
                if (char.IsNumber(Convert.ToChar(txtNumeroDoc.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDoc.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDoc.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtObservaciones.Text = objE_Cliente.DescCliente;
                        txtObservaciones.Focus();
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

            }
        }

        private void cboMotivo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumeroDoc.Visible == true)
                    txtNumeroDoc.Focus();
                else
                    cboAlmacen.Focus();
            }
        }
        
        private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeteaMovimientoDetalle();

                switch (cboDocumento.Text)
                {
                    case "SCP":
                        CargaSolicitudProductoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "N/S":
                        CargaNotaSalidaDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "N/I":
                        CargaNotaIngresoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "FAC":
                        CargaFacturaCompra(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "PED":
                        CargaPedidoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    //break;
                    default:
                        break;
                }

                CalcularTotalDocumentos();
            }
        }

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCausal_EditValueChanged(object sender, EventArgs e)
        {

                if (Convert.ToInt32(cboCausal.EditValue) == Parametros.intFaltanteFisico)
                {
                    lblTexto.Text = "N/S de Referencia:";
                    txtDocRef.Text = "";

                    lblTexto.Visible = true;
                    txtDocRef.Visible = true;
                    txtDocRef.Properties.MaxLength = 6;

                //lblVendedor.Visible = false;
                //cboVendedor.Visible = false;
                cboVendedor.EditValue = 1;

                txtDocRef.Focus();
                }
                else if (Convert.ToInt32(cboCausal.EditValue) == Parametros.intPedidoVenta)
                {
                    lblTexto.Text = "N° Pedido Referencia:";
                    txtDocRef.Text = "";

                    lblTexto.Visible = true;
                    txtDocRef.Visible = true;
                    txtDocRef.Properties.MaxLength = 7;
                //lblVendedor.Visible = true;
                //cboVendedor.Visible = true;
                cboVendedor.EditValue = 1;
                txtDocRef.Focus();
                }
                else if (Convert.ToInt32(cboCausal.EditValue) == Parametros.intSobranteFisico)
                {
                    lblTexto.Text = "N/S de Referencia:";
                    txtDocRef.Text = "";

                    lblTexto.Visible = true;
                    txtDocRef.Visible = true;
                    txtDocRef.Properties.MaxLength = 6;

                //lblVendedor.Visible = false;
                //cboVendedor.Visible = false;
                cboVendedor.EditValue = 1;
                txtDocRef.Focus();
                }
                else
                {
                    lblTexto.Visible = false;
                    txtDocRef.Visible = false;
                //lblVendedor.Visible = false;
                //cboVendedor.Visible = false;
                cboVendedor.EditValue = 1;
            }



        }

        private void txtNumeroDocumento_EditValueChanged_1(object sender, EventArgs e)
        {

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
                        gcMovimientoAlmacenDetalle.Select();
                        break;

                    //case "SOBRANTE FÍSICO":
                    //    SolicitudProductoBE objE_SolicitudProducto1 = null;
                    //    objE_SolicitudProducto = new SolicitudProductoBL().SeleccionaProductos(DateTime.Now.Year, txtDocRef.Text.Trim());

                    //    if (objE_SolicitudProducto != null)
                    //    {
                    //        cboVendedor.EditValue = objE_SolicitudProducto.IdVendedor;
                    //    }
                    //    else
                    //    {
                    //        XtraMessageBox.Show("Numero de pedido no encontrado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }

                    //    cboVendedor.Visible = true;
                    //    lblVendedor.Visible = true;
                    //    gcMovimientoAlmacenDetalle.Select();
                    //    break;

                    //case "FALTANTE FÍSICO":
                    //    SolicitudProductoBE objE_SolicitudProducto2 = null;
                    //    objE_SolicitudProducto = new SolicitudProductoBL().SeleccionaProductos(DateTime.Now.Year, txtDocRef.Text.Trim());

                    //    if (objE_SolicitudProducto != null)
                    //    {
                    //        cboVendedor.EditValue = objE_SolicitudProducto.IdVendedor;
                    //    }
                    //    else
                    //    {
                    //        XtraMessageBox.Show("Numero de pedido no encontrado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }

                    //    cboVendedor.Visible = true;
                    //    lblVendedor.Visible = true;
                    //    gcMovimientoAlmacenDetalle.Select();
                    //    break;

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
                        gcMovimientoAlmacenDetalle.Select();

                        break;
                }
            }
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "DetalleNotaSalida";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMovimientoAlmacenDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }
    }

    public class CMovimientoAlmacenDetalle
    {
        public Int32 IdEmpresa { get; set; }
        public Int32 IdMovimientoAlmacen { get; set; }
        public Int32 IdMovimientoAlmacenDetalle { get; set; }
        public Int32 Item { get; set; }
        public Int32 IdProducto { get; set; }
        public String CodigoProveedor { get; set; }
        public String NombreProducto { get; set; }
        public String Abreviatura { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 CantidadAnt { get; set; }
        public Decimal CostoUnitario { get; set; }
        public Decimal MontoTotal { get; set; }
        public Int32 IdKardex { get; set; }
        public String Observacion { get; set; }
        public Boolean FlagEstado { get; set; }
        public Int32 Stock { get; set; }
        public Int32 TipoOper { get; set; }
        public Int32 IdAlmacen { get; set; }
        public Int32 IdPedido { get; set; }

        public CMovimientoAlmacenDetalle()
        {

        }
    }
}