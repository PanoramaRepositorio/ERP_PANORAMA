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
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegAuditoriaPedidoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CPedidoDetalle> mListaPedidoDetalleOrigen = new List<CPedidoDetalle>();

        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }


        private int IdCliente = 0;
        private bool bModificaChequeo = false;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public bool bNuevo = true;
        public bool bConsulta = false;
        private int EBotonGrabar = 0;

        decimal dmlTipoCambio = 0;

        public ParametroBE pParametroBE;
        private bool Chequeado=false;
        private bool Preparado = false;
        private bool bCumpleanios = false;
        private int? IdContratoFabricacion = null;
        
        #endregion

        #region "Eventos"

        public frmRegAuditoriaPedidoEdit()
        {
            InitializeComponent();
        }

        private void frmRegAuditoriaPedidoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            deFechaChequeo.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboPersonaChequeo, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboPersonaChequeo.EditValue = Parametros.intUsuarioId;
            BSUtils.LoaderLook(cboPersonaPicking, new PersonaBL().ListaTodos(Parametros.intEmpresaId, 0), "ApeNom", "IdPersona", true);

            BSUtils.LoaderLook(cboPersonaEmbalaje, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Auditoria Pedido - Nuevo " ;

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Auditoria Pedido - Modificar";

                //Carga Personal - Todos - Cesados
                BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedorTodos(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);

                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                if (objE_Pedido != null)
                {
                    IdPedido = objE_Pedido.IdPedido;
                    txtNumero.Text = objE_Pedido.Numero;
                    deFecha.EditValue = objE_Pedido.Fecha;
                    cboVendedor.EditValue = objE_Pedido.IdVendedor;
                    bCumpleanios = objE_Pedido.FlagCumpleanios;
                    IdContratoFabricacion = objE_Pedido.IdContratoFabricacion;
                }

                //Chequeador
                MovimientoPedidoBE objE_MovimientoPedido = null;
                objE_MovimientoPedido = new MovimientoPedidoBL().SeleccionaChequeo(IdPedido);
                if (objE_MovimientoPedido != null)
                {
                    cboPersonaPicking.EditValue = objE_MovimientoPedido.IdAuxiliar;
                    cboPersonaChequeo.EditValue = objE_MovimientoPedido.IdChequeador;
                    cboPersonaEmbalaje.EditValue = objE_MovimientoPedido.IdEmbalador;
                    txtNumeroBultos.EditValue = objE_MovimientoPedido.CantidadBulto;
                    Preparado = objE_MovimientoPedido.Preparado;
                    Chequeado = objE_MovimientoPedido.Chequeado;
                }

                //CargaPedidoDetalle();
                CargaPedidoDetallePorProducto();

                if (Convert.ToInt32(txtTotalDiferencia.EditValue) == 0)
                {
                    btnGrabar.Enabled = false;
                }

                return;
            }

            //CargaPedidoDetalle();
            CargaPedidoDetallePorProducto();

        }

        private void btnLectorBarras_Click(object sender, EventArgs e)
        {
            //CargarLector();
            CargarLector111();
        }

        private void frmRegPedidoEdit_Shown(object sender, EventArgs e)
        {
        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (!ValidarIngreso())
                {
                    ///Int32 Numero = 0;

                    PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                    PedidoDetalleBE objPedidoDetalle = new PedidoDetalleBE();


                    //Pedido Detalle
                    List<PedidoDetalleBE> lstPedidoDetalle = new List<PedidoDetalleBE>();

                    foreach (var item in mListaPedidoDetalleOrigen)
                    {
                        PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                        objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                        objE_PedidoDetalle.IdPedido = item.IdPedido;
                        objE_PedidoDetalle.IdProducto = item.IdProducto;
                        objE_PedidoDetalle.CantidadChequeo = item.CantidadChequeo;
                        lstPedidoDetalle.Add(objE_PedidoDetalle);
                    }

                    objBL_PedidoDetalle.ActualizaChequeoProducto(lstPedidoDetalle); //add 170117



                    //Chequeador
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                    MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();

                    objE_MovimientoPedido.IdPedido = IdPedido;
                    objE_MovimientoPedido.IdChequeador = Convert.ToInt32(cboPersonaChequeo.EditValue);

                    objBL_MovimientoPedido.ActualizaChequeador(objE_MovimientoPedido);

                    //if (Convert.ToDecimal(txtTotalDiferencia.Text) == 0)
                    //{
                    //    objE_MovimientoPedido.Chequeado = true;
                    //    objBL_MovimientoPedido.ActualizaCierreChequeado(objE_MovimientoPedido);
                    //}

                    ////Embalador
                    //GrabarEmbalador();

                    Cursor = Cursors.Default;

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) txtCodigo.Select() ;
            if (keyData == Keys.F12) CargarLector111();

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void gvPedidoDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {
            //CalcularTotalDocumentos();
        }

        #endregion

        #region "Metodos"


        private void CargarBusqueda()
        {
            gcPedidoDetalle.DataSource = mListaPedidoDetalleOrigen.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        private void ObtenerCorrelativo()
        {
            //try
            //{
            //    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
            //    string sNumero = "";
            //    string sSerie = "";
            //    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocPedidoVenta, Parametros.intPeriodo);
            //    if (mListaNumero.Count > 0)
            //    {
            //        sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
            //        sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
            //    }
            //    txtNumero.Text = sNumero;
            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void CargaPedidoDetalle()
        {
            mListaPedidoDetalleOrigen = new List<CPedidoDetalle>();

            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoChequeo(IdPedido);

            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
            {
                CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                objE_PedidoDetalle.IdPedido = item.IdPedido;
                objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                objE_PedidoDetalle.Item = item.Item;
                objE_PedidoDetalle.IdProducto = item.IdProducto;
                objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                objE_PedidoDetalle.Cantidad = item.Cantidad;
                objE_PedidoDetalle.CantidadChequeo = item.CantidadChequeo;
                objE_PedidoDetalle.CantidadDiferencia = item.Cantidad - item.CantidadChequeo;
                objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
                objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_PedidoDetalle.Descuento = item.Descuento;
                objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                objE_PedidoDetalle.Observacion = item.Observacion;
                objE_PedidoDetalle.IdKardex = item.IdKardex;
                objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                objE_PedidoDetalle.Stock = 0;
                objE_PedidoDetalle.PrecioUnitarioInicial = 0;
                objE_PedidoDetalle.PorcentajeDescuentoInicial = 0;
                objE_PedidoDetalle.IdLineaProducto = 0;
                objE_PedidoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

                if ((item.Cantidad - item.CantidadChequeo) < 0)
                {
                    gvPedidoDetalle.Columns["CantidadChequeo"].OptionsColumn.AllowEdit = true;
                    gvPedidoDetalle.Columns["CantidadChequeo"].OptionsColumn.AllowFocus = true;
                }
            }

            bsListado.DataSource = mListaPedidoDetalleOrigen;
            gcPedidoDetalle.DataSource = bsListado;
            gcPedidoDetalle.RefreshDataSource();


            //CalcularCantidad();
            txtTotalRegistros.EditValue = mListaPedidoDetalleOrigen.Count;

            CalcularTotalDocumentos();
        }

        private void CargaPedidoDetallePorProducto()
        {
            mListaPedidoDetalleOrigen = new List<CPedidoDetalle>();

            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoChequeoProducto(IdPedido);

            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
            {
                CPedidoDetalle objE_PedidoDetalle = new CPedidoDetalle();
                objE_PedidoDetalle.IdEmpresa = Parametros.intEmpresaId;// item.IdEmpresa;
                objE_PedidoDetalle.IdPedido = item.IdPedido;
                objE_PedidoDetalle.IdPedidoDetalle = 0;// item.IdPedidoDetalle;
                objE_PedidoDetalle.Item = item.Item;
                objE_PedidoDetalle.IdProducto = item.IdProducto;
                objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                objE_PedidoDetalle.Cantidad = item.Cantidad;
                objE_PedidoDetalle.CantidadChequeo = item.CantidadChequeo;
                objE_PedidoDetalle.CantidadDiferencia = item.Cantidad - item.CantidadChequeo;
                objE_PedidoDetalle.CantidadAnt = 0;
                objE_PedidoDetalle.PrecioUnitario = 0;
                objE_PedidoDetalle.PorcentajeDescuento = 0;
                objE_PedidoDetalle.Descuento = 0;
                objE_PedidoDetalle.PrecioVenta = 0;
                objE_PedidoDetalle.ValorVenta = 0;
                objE_PedidoDetalle.Observacion = "";
                objE_PedidoDetalle.IdKardex = 0;
                objE_PedidoDetalle.IdAlmacen = 0; //add
                objE_PedidoDetalle.FlagMuestra = false;
                objE_PedidoDetalle.FlagRegalo = false;
                objE_PedidoDetalle.Stock = 0;
                objE_PedidoDetalle.PrecioUnitarioInicial = 0;
                objE_PedidoDetalle.PorcentajeDescuentoInicial = 0;
                objE_PedidoDetalle.IdLineaProducto = 0;
                objE_PedidoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalleOrigen.Add(objE_PedidoDetalle);

                if ((item.Cantidad - item.CantidadChequeo) < 0)
                {
                    gvPedidoDetalle.Columns["CantidadChequeo"].OptionsColumn.AllowEdit = true;
                    gvPedidoDetalle.Columns["CantidadChequeo"].OptionsColumn.AllowFocus = true;
                }
            }

            bsListado.DataSource = mListaPedidoDetalleOrigen;
            gcPedidoDetalle.DataSource = bsListado;
            gcPedidoDetalle.RefreshDataSource();


            //CalcularCantidad();
            txtTotalRegistros.EditValue = mListaPedidoDetalleOrigen.Count;

            CalcularTotalDocumentos();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboPersonaChequeo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar Personal de Chequeo.\n";
                flag = true;
            }

            if (mListaPedidoDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar la venta, mientra no haya productos.\n";
                flag = true;
            }

            if (bModificaChequeo == true) //
            {
                bModificaChequeo = false;
            }
 
            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargarLector()
        {
            frmRegAuditoriaPedidoDetalleEdit frm = new frmRegAuditoriaPedidoDetalleEdit();
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Location = new Point(100, 100);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int decCantidad = 0;
                int decCantidadChequeo = 0;
                int decCantidadDiferencia = 0;
                int cantidadLectura = 0;
                int IdProducto = 0;
                bool FlagExiste = false;
                cantidadLectura = frm.oBE.Cantidad;
                IdProducto = frm.oBE.IdProducto;


                int PosicionX = 0;
                foreach (CPedidoDetalle item in mListaPedidoDetalleOrigen)
                {
                    if (IdProducto == item.IdProducto)
                    {
                        FlagExiste = true;
                        bModificaChequeo = true;

                        //gcPedidoDetalle.DataSource = mListaPedidoDetalleOrigen.Where(obj => obj.IdProducto.ToString().Contains(IdProducto.ToString())).ToList();

                        decCantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["Cantidad"])));
                        decCantidadChequeo = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["CantidadChequeo"])));
                        decCantidadDiferencia = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(PosicionX, (gvPedidoDetalle.Columns["CantidadDiferencia"])));

                        if ((decCantidad - (decCantidadChequeo + cantidadLectura)) < -1)
                        {
                            XtraMessageBox.Show("Cantidad ingresada del Código: " + frm.oBE.CodigoProveedor + " es mayor a lo solicitado, Cuidado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //\nSe capturó el registro para auditoria
                            return;
                        }
                        else if ((decCantidad - (decCantidadChequeo + cantidadLectura)) < 0)
                        {
                            XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " está completo , Cuidado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            decCantidadDiferencia = decCantidad - (decCantidadChequeo + cantidadLectura);
                            gvPedidoDetalle.SetRowCellValue(PosicionX, gvPedidoDetalle.Columns["CantidadChequeo"], decCantidadChequeo + cantidadLectura);
                            //gvPedidoDetalle.SetRowCellValue(PosicionX, gvPedidoDetalle.Columns["CantidadDiferencia"], decCantidad - (decCantidadChequeo + cantidadLectura));
                            gvPedidoDetalle.SetRowCellValue(PosicionX, gvPedidoDetalle.Columns["CantidadDiferencia"], decCantidadDiferencia);
                        }

                        CalcularTotalDocumentos();// add

                        if (decCantidadDiferencia == 0)
                            lblMensaje.Text = "COMPLETO";
                        else
                            lblMensaje.Text = "FALTAN " + (decCantidadDiferencia).ToString();

                    }
                    PosicionX = PosicionX + 1;
                }


                if (!FlagExiste)
                {
                    XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " No Existe, Consultar con el Personal de Picking!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarLector();
                //CalcularTotalDocumentos();
            }



        }

        private void CargarLector111()
        {
            frmRegAuditoriaPedidoDetalleEdit frm = new frmRegAuditoriaPedidoDetalleEdit();
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.Location = new Point(100, 100);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int decCantidad = 0;
                int decCantidadChequeo = 0;
                int decCantidadDiferencia = 0;
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

                for (int i = 0; i < gvPedidoDetalle.RowCount; i++) //Existe
                {
                    int IdProductoLista = 0;
                    int row = gvPedidoDetalle.GetRowHandle(i);

                    IdProductoLista = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(row, (gvPedidoDetalle.Columns["IdProducto"])));

                    if (IdProducto == IdProductoLista)
                    {
                        FlagExiste = true;
                        decCantidad = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(row, (gvPedidoDetalle.Columns["Cantidad"])));
                        decCantidadChequeo = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(row, (gvPedidoDetalle.Columns["CantidadChequeo"])));
                        decCantidadDiferencia = Convert.ToInt32(gvPedidoDetalle.GetRowCellValue(row, (gvPedidoDetalle.Columns["CantidadDiferencia"])));


                        if ((decCantidad - (decCantidadChequeo + cantidadLectura)) < -1)
                        {
                            XtraMessageBox.Show("Cantidad ingresada del Código: " + frm.oBE.CodigoProveedor + " es mayor a lo solicitado, Cuidado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //\nSe capturó el registro para auditoria
                            return;
                        }
                        else if ((decCantidad - (decCantidadChequeo + cantidadLectura)) < 0)
                        {
                            XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " está completo , Cuidado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            decCantidadDiferencia = decCantidad - (decCantidadChequeo + cantidadLectura);
                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["CantidadChequeo"], decCantidadChequeo + cantidadLectura);
                            gvPedidoDetalle.SetRowCellValue(row, gvPedidoDetalle.Columns["CantidadDiferencia"], decCantidad - (decCantidadChequeo + cantidadLectura));
                            lblMensaje.Text = (decCantidad + cantidadLectura).ToString();
                            lblMensaje2.Text = CodigoProveedor;
                            //CargarLector111();
                            //return;                   
                        }

                        CalcularTotalDocumentos();
                        if (decCantidadDiferencia == 0)
                            lblMensaje.Text = "COMPLETO";
                        else
                            lblMensaje.Text = "FALTAN " + (decCantidadDiferencia).ToString();

                    }
                }

                if (!FlagExiste)
                {
                    XtraMessageBox.Show("El Código: " + frm.oBE.CodigoProveedor + " No Existe, Consultar con el Personal de Picking!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ////gvPedidoDetalle.AddNewRow();
                    ////gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Item", (mListaPedidoDetalleOrigen.Count - 1) + 1);
                    ////gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "IdProducto", IdProducto);
                    ////gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CodigoProveedor", CodigoProveedor);
                    ////gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "NombreProducto", NombreProducto);
                    ////gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Abreviatura", Abreviatura);
                    ////gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "Cantidad", cantidadLectura);
                    ////gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CostoUnitario", 0);
                    ////gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "MontoTotal", 0);


                    ////if (pOperacion == Operacion.Modificar)
                    ////    gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    ////else
                    ////    gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                    ////gvPedidoDetalle.FocusedColumn = gvPedidoDetalle.GetVisibleColumn(1);
                    ////gvPedidoDetalle.ShowEditor();

                    lblMensaje.Text = cantidadLectura.ToString();
                    lblMensaje2.Text = CodigoProveedor;
                }

                CargarLector111();
                //CalcularTotalDocumentos();
            }
        }





        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotalChequeo = 0;
                decimal decTotalDiferencia = 0;

                for (int i = 0; i < gvPedidoDetalle.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["Cantidad"])));
                    decTotalChequeo = decTotalChequeo + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["CantidadChequeo"])));
                    decTotalDiferencia = decTotalDiferencia + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["CantidadDiferencia"])));

                }

                txtTotalCantidad.EditValue = decTotal;
                txtTotalChequeo.EditValue = decTotalChequeo;
                txtTotalDiferencia.EditValue = decTotalDiferencia;

                //Botones y Etiquetas
                if (decTotalDiferencia == 0)
                {
                    lblMensaje.Text = "PEDIDO COMPLETO";
                    lblMensaje.ForeColor = Color.Red;
                    txtTotalDiferencia.ForeColor = Color.Blue;
                    txtTotalDiferencia.BackColor = Color.LawnGreen;
                    btnIniciar.Visible = false;

                    if (Chequeado)
                        btnFinalizar.Visible = false;
                    else
                        btnFinalizar.Visible = true;
                }

                if (decTotalChequeo > 0 && decTotalDiferencia >0)
                {
                    lblMensaje.Text = "";
                    //btnFinalizar.Visible = false;
                    btnIniciar.Visible = false;
                    btnLectorBarras.Visible = true;
                }
                    

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularCantidad()
        {
            try
            {
                decimal decTotalDiferencia = 0;
                decimal decCantidad = 0;

                //if (e.Column.Caption == "CantidadChequeo")
                //{
                    //if (decimal.Parse(e.Value.ToString()) > 0)
                    //{
                    //decCantidad = decimal.Parse(e.Value.ToString());
                    //Calcular Total
                    decCantidad = Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(gvPedidoDetalle.FocusedRowHandle, (gvPedidoDetalle.Columns["decCantidad"])));
                    decTotalDiferencia = decCantidad - Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(gvPedidoDetalle.FocusedRowHandle, (gvPedidoDetalle.Columns["CantidadChequeo"])));
                    gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, gvPedidoDetalle.Columns["CantidadDiferencia"], decTotalDiferencia);

                    //}
                //}
                ////--calculamos el total general ------------
                //for (int i = 0; i < gvPedidoDetalle.RowCount; i++)
                //{
                //    decTotalGeneral = decTotalGeneral + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(i, (gvPedidoDetalle.Columns["Total"])));
                //}
                //txtTotal.EditValue = decTotalGeneral;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        private void GrabarEmbalador()
        {
            try
            {
                if (Convert.ToInt32(txtNumeroBultos.EditValue)>0)
                {
                    if (txtNumeroBultos.Text.Trim().Length == 0)
                    {
                        XtraMessageBox.Show("Ingresar cantidad de Bultos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroBultos.Focus();
                        return;
                    }

                    //MovimientoPedidoBE objBE_MovimientoPedidoPicking = null;
                    MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                    ////Buscar situación de picking
                    //objBE_MovimientoPedidoPicking = objBL_MovimientoPedido.SeleccionaChequeo(objE_Pedido.IdPedido);
                    //if (objBE_MovimientoPedidoPicking.IdAuxiliar == 0)
                    //{
                    //    XtraMessageBox.Show("El Pedido tiene que Pasar por PICKING, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    //Cargar con valores
                    objBE_MovimientoPedido.IdPedido = IdPedido;
                    objBE_MovimientoPedido.IdEmbalador = Convert.ToInt32(cboPersonaEmbalaje.EditValue);
                    objBE_MovimientoPedido.EnPT = true;
                    objBE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtNumeroBultos.EditValue);
                    objBL_MovimientoPedido.ActualizaCierreEmbalaje(objBE_MovimientoPedido);

                    //XtraMessageBox.Show("Se guardó N° Bulto Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        #endregion

        public class CPedidoDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdPedido { get; set; }
            public Int32 IdPedidoDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Int32 CantidadChequeo { get; set; }
            public Int32 CantidadDiferencia { get; set; }
            public Int32 CantidadAnt { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public String Observacion { get; set; }
            public Int32? IdKardex { get; set; }
            public Int32? IdAlmacen { get; set; }
            public Boolean FlagMuestra { get; set; }
            public Boolean FlagRegalo { get; set; }
            public Int32 Stock { get; set; }
            public Decimal PrecioUnitarioInicial { get; set; }
            public Decimal PorcentajeDescuentoInicial { get; set; }
            public Int32 IdLineaProducto { get; set; }
            public Int32 TipoOper { get; set; }

            public CPedidoDetalle()
            {

            }
        }

        private void gvPedidoDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
            //decimal decCantidad = 0;
            //decimal decCantidadChequeo = 0;
            //decimal decCantidadDiferencia = 0;

            //if (e.Column.Caption == "Cant. Chequeo")
            //{
            //    decCantidad = decCantidad + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(e.RowHandle, (gvPedidoDetalle.Columns["Cantidad"])));
            //    decCantidadChequeo = decCantidadChequeo + Convert.ToDecimal(gvPedidoDetalle.GetRowCellValue(e.RowHandle, (gvPedidoDetalle.Columns["CantidadChequeo"])));
            //    decCantidadDiferencia = decCantidad - decCantidadChequeo;

            //    if (decCantidadDiferencia < 0)
            //    {
            //        XtraMessageBox.Show("La cantidad de chequeo, no puede ser mayor a la cantidad solicitada, VERIFICAR!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        //gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "decCantidadChequeo", decCantidadChequeo);
            //    }
            //    else
            //    { 
            //      gvPedidoDetalle.SetRowCellValue(gvPedidoDetalle.FocusedRowHandle, "CantidadDiferencia", decCantidadDiferencia);
            //        CalcularTotalDocumentos();              
            //    }

            //}
        }

        private void gvPedidoDetalle_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPedidoDetalle.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["CantidadDiferencia"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == 0)
                        {
                            //gvPedidoDetalle.Columns["DisponiblePorcentaje"].AppearanceCell.BackColor = Color.Green;
                            //gvPedidoDetalle.Columns["DisponiblePorcentaje"].AppearanceCell.BackColor2 = Color.SeaShell;
                            e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                     }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegAuditoriaPedidoEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (bModificaChequeo == true)
            //{
            //    if (XtraMessageBox.Show("Está seguro que desea Cerrar el registro de chequeo?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    {
            //        return;
            //    }
                    
            //}
        }

        private void gcPedidoDetalle_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (cboPersonaPicking.Text == "")
            {
                XtraMessageBox.Show("No se puede CHEQUEAR sin antes pasar por PICKING\nFavor de registrar utilizando el módulo de picking.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Preparado)
            {
                XtraMessageBox.Show("El pedido aún no finaliza PICKING!.\nPor favor consultar con el personal de Picking.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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
            cboPersonaChequeo.EditValue = frmAutoriza.IdPersona;
            cboPersonaChequeo.Properties.ReadOnly = true;


            if (cboPersonaChequeo.Text == "")
            {
                XtraMessageBox.Show("Seleccionar el nombre del CHEQUEADOR!.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            PedidoBL objBL_Pedido = new PedidoBL();
            objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intEnChequeo, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
            btnLectorBarras.Visible = true;
            btnIniciar.Visible = false;

            if (Convert.ToInt32(txtTotalChequeo.EditValue) == 0)
            {
                this.Text = this.Text  + " - Inicio de Picking " + DateTime.Now.ToString();
            }
        }

        private void txtNumeroBultos_EditValueChanged(object sender, EventArgs e)
        {
            if (txtNumeroBultos.Text.Trim().Count() > 0)
            {
                btnGrabar.Enabled = true;
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(txtTotalDiferencia.EditValue) != 0)
            //{
            //    XtraMessageBox.Show("No se puede Finalizar el chequeo, Verificar que todos los códigos existan.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}

            ///VERIFICAR EL PEDIDO SI NO TIENE 6X3 U OTRA PROMOCION ** 
            ///********************************

            //PedidoBL objBL_Pedido = new PedidoBL();
            //PedidoBE objPedido = new PedidoBE();

            ////objPedido.IdPedido = IdPedido;
            ////objPedido.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
            ////objPedido.SubTotal = 0; //Convert.ToDecimal(txtSubTotal.EditValue);
            ////objPedido.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.EditValue);
            ////objPedido.PorcentajeImpuesto = Parametros.dmlIGV;
            ////objPedido.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
            ////objPedido.Total = Convert.ToDecimal(txtTotal.EditValue);
            ////objPedido.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
            ////objPedido.Observacion = txtObservaciones.Text; //Agregar si es liquidacion **************
            ////objPedido.FlagEstado = true;
            ////objPedido.Usuario = Parametros.strUsuarioLogin;
            ////objPedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

            ////Pedido Detalle
            //List<PedidoDetalleBE> lstPedidoDetalle = new List<PedidoDetalleBE>();

            //foreach (var item in mListaPedidoDetalleOrigen)
            //{
            //    PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
            //    objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
            //    objE_PedidoDetalle.IdPedido = item.IdPedido;
            //    objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
            //    objE_PedidoDetalle.Item = item.Item;
            //    objE_PedidoDetalle.IdProducto = item.IdProducto;
            //    objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
            //    objE_PedidoDetalle.NombreProducto = item.NombreProducto;
            //    objE_PedidoDetalle.Abreviatura = item.Abreviatura;
            //    objE_PedidoDetalle.Cantidad = item.Cantidad;
            //    objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
            //    objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
            //    objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
            //    objE_PedidoDetalle.Descuento = item.Descuento;
            //    objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
            //    objE_PedidoDetalle.ValorVenta = item.ValorVenta;
            //    if (item.FlagMuestra)
            //        objE_PedidoDetalle.Observacion = "MUESTRA";
            //    else
            //        objE_PedidoDetalle.Observacion = item.Observacion;
            //    objE_PedidoDetalle.IdKardex = item.IdKardex;
            //    objE_PedidoDetalle.IdAlmacen = item.IdAlmacen;
            //    objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacenOrigen;
            //    objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;
            //    objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
            //    objE_PedidoDetalle.FlagRegalo = false;
            //    objE_PedidoDetalle.FlagBultoCerrado = item.FlagBultoCerrado;
            //    objE_PedidoDetalle.IdPromocion = item.IdPromocion;
            //    objE_PedidoDetalle.DescPromocion = item.DescPromocion;
            //    objE_PedidoDetalle.FlagEstado = true;
            //    objE_PedidoDetalle.TipoOper = item.TipoOper;
            //    lstPedidoDetalle.Add(objE_PedidoDetalle);

            //}

            if (XtraMessageBox.Show("Esta seguro de finalizar el chequeo de productos?\nEstá acción eliminará los productos sin chequear.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //despues
                btnGrabar_Click(sender, e);
                this.ActualizarDescuentoPorCumple();

                PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                PedidoDetalleBL objBL_Pedido = new PedidoDetalleBL();
                objE_PedidoDetalle.IdPedido = IdPedido;
                objE_PedidoDetalle.Usuario = Parametros.strUsuarioLogin;
                objE_PedidoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objE_PedidoDetalle.IdEmpresa = Parametros.intEmpresaId;

                objBL_Pedido.EliminaSinChequear(objE_PedidoDetalle);

                //Actualizar cierre de chequeado
                MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                objBE_MovimientoPedido.IdPedido = IdPedido;
                objBE_MovimientoPedido.Chequeado = true;
                objBL_MovimientoPedido.ActualizaCierreChequeado(objBE_MovimientoPedido);
                btnLectorBarras.Visible = false;
                btnIniciar.Visible = false;
                btnFinalizar.Visible = false;
                XtraMessageBox.Show("El chequeo se finalizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void ActualizarDescuentoPorCumple()
        {
            try
            {
                if (IdContratoFabricacion == null) { IdContratoFabricacion = 0; }
                if (bCumpleanios == false) return;
                if (IdContratoFabricacion != 0) return;
                if (txtTotalCantidad.Text == txtTotalDiferencia.Text) return;

                decimal detotalDsctoCumple = 0;
                List<PedidoDetalleBE> lstPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);
                foreach (var item in mListaPedidoDetalleOrigen)
                {
                    var var_i = lstPedidoDetalle.Find(x => x.IdProducto == item.IdProducto);
                    if (var_i != null)
                    {
                        decimal pValorVenta = var_i.PrecioVenta * item.CantidadChequeo;
                        detotalDsctoCumple = new PedidoBL().lgDescuentoPorCumpleanios(detotalDsctoCumple, var_i.IdMarca, var_i.PorcentajeDescuento, pValorVenta);
                    }
                }

                // decimal dDec=  Math.Round(  Convert.ToDecimal(87.945) , 2) ;
                // Se realizo asi porque no redondeaba correctamente, por ejemplo: 87.945 , Tomaba 87.94 
                detotalDsctoCumple = Math.Round(detotalDsctoCumple, 2, MidpointRounding.AwayFromZero);

                MovimientoPedidoBL objBL_MovPedi = new MovimientoPedidoBL();
                objBL_MovPedi.ActualizarDescuentoPorCumpleanios(IdPedido, detotalDsctoCumple);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}