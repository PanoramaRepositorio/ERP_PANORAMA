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
    public partial class frmRegNotaIngresoEdit : DevExpress.XtraEditors.XtraForm
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

        private int? IdCliente;
        private int? IdMovimientoAlmacenReferencia;
        #endregion

        #region "Eventos"

        public frmRegNotaIngresoEdit()
        {
            InitializeComponent();
        }

        private void frmRegNotaIngresoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            txtPeriodo.EditValue = DateTime.Now.Year;
            //BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescAlmacen", "IdAlmacen", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaAlmacenIngreso(Parametros.intEmpresaId), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaNotaIngreso(Parametros.intModLogistica), "CodTipoDocumento", "IdTipoDocumento", true);
            BSUtils.LoaderLook(cboAlmacenDestino, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            cboAlmacenDestino.EditValue = Parametros.intAlmTiendaUcayali;

            if(Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen || Parametros.strUsuarioLogin == "dllanos" || Parametros.strUsuarioLogin == "DLLANOS"
               || Parametros.strUsuarioLogin=="jlquispe" || Parametros.strUsuarioLogin == "FMIRANDA" || Parametros.intPerfilId == Parametros.intPerAsistenteMarketing)  // || Parametros.intPerfilId == Parametros.intPerAuxiliarAlmacen
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            else
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivoPrincipal(Parametros.intEmpresaId, Parametros.intTiendaId), "DescAlmacen", "IdAlmacen", true);

            tmrNumero.Enabled = true;
            tmrNumero.Interval = 100;
            ObtenerCorrelativo();

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Nota de Ingreso - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Nota de Ingreso - Modificar";

                MovimientoAlmacenBE objE_MovimientoAlmacen = null;
                objE_MovimientoAlmacen = new MovimientoAlmacenBL().Selecciona(Parametros.intEmpresaId, IdMovimientoAlmacen);

                IdMovimientoAlmacen = objE_MovimientoAlmacen.IdMovimientoAlmacen;
                cboAlmacen.EditValue = objE_MovimientoAlmacen.IdAlmacenOrigen;
                txtNumero.Text = objE_MovimientoAlmacen.Numero;
                deFecha.EditValue = objE_MovimientoAlmacen.Fecha;
                cboDocumento.EditValue = objE_MovimientoAlmacen.IdTipoDocumento;
                txtNumeroDocumento.Text = objE_MovimientoAlmacen.NumeroDocumento;
                cboMotivo.EditValue = objE_MovimientoAlmacen.IdMotivo;
                cboAlmacenDestino.EditValue = objE_MovimientoAlmacen.IdAlmacenDestino;
                txtObservaciones.Text = objE_MovimientoAlmacen.Observaciones;
                IdMovimientoAlmacenReferencia = objE_MovimientoAlmacen.IdMovimientoAlmacenReferencia;
            }

            CargaMovimientoAlmacenDetalle();

            BloquearAccesoPorPerfil();

        }

    
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    string Usuario = Parametros.strUsuarioLogin;
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (!frmAutoriza.Edita)
                    {
                        return;
                    }

                    if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                    {
                        XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                        return;
                    }

                    Usuario = frmAutoriza.Usuario;
                    //Usuario = Parametros.strUsuarioLogin;

                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                    MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                    objMovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
                    objMovimientoAlmacen.Periodo = deFecha.DateTime.Year;
                    objMovimientoAlmacen.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objMovimientoAlmacen.Numero = txtNumero.Text;
                    objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovIngreso;
                    objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(cboAlmacen.EditValue);
                    objMovimientoAlmacen.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objMovimientoAlmacen.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objMovimientoAlmacen.NumeroDocumento = txtNumeroDocumento.Text;
                    objMovimientoAlmacen.Referencia = "";
                    objMovimientoAlmacen.Observaciones = txtObservaciones.Text;
                    objMovimientoAlmacen.IdAlmacenDestino = Convert.ToInt32(cboAlmacenDestino.EditValue);
                    objMovimientoAlmacen.IdCliente = IdCliente == null ? (int?)null : IdCliente; //Add
                    objMovimientoAlmacen.IdMovimientoAlmacenReferencia = IdMovimientoAlmacenReferencia == null ? (int?)null : IdMovimientoAlmacenReferencia; //Add
                    objMovimientoAlmacen.FlagEstado = true;
                    objMovimientoAlmacen.Usuario = Usuario;//Parametros.strUsuarioLogin;
                    objMovimientoAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objMovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;
                    objMovimientoAlmacen.IdTienda = Parametros.intTiendaId;

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
                            objE_MovimientoAlmacenDetalle.Observacion = item.Observacion;
                            objE_MovimientoAlmacenDetalle.FlagEstado = true;
                            objE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoAlmacenDetalle.TipoOper = item.TipoOper;
                            lstMovimientoAlmacenDetalle.Add(objE_MovimientoAlmacenDetalle);                        
                        }
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_MovimientoAlmacen.Inserta(objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
                    }
                    else
                    {
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
                    //string CodigoProveedor = (sender as TextEdit).Text;
                    //ErpPanoramaServicios.StockBE objE_Producto = new ErpPanoramaServicios.StockBE();
                    //objE_Producto = objServicio.Stock_SeleccionaProductoPrecio(Parametros.intTiendaId, CodigoProveedor);
                    //if (objE_Producto == null)
                    //{
                    //    XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                    //else
                    //{
                    //    int index = gvMovimientoAlmacenDetalle.FocusedRowHandle;
                    //    gvMovimientoAlmacenDetalle.SetRowCellValue(index, "IdProducto", objE_Producto.IdProducto);
                    //    gvMovimientoAlmacenDetalle.SetRowCellValue(index, "CodigoProveedor", objE_Producto.CodigoProveedor);
                    //    gvMovimientoAlmacenDetalle.SetRowCellValue(index, "NombreProducto", objE_Producto.NombreProducto);
                    //    gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Abreviatura", objE_Producto.Abreviatura);
                    //    gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Cantidad", 1);
                    //    gvMovimientoAlmacenDetalle.SetRowCellValue(index, "CostoUnitario", objE_Producto.PrecioABSoles);
                    //    gvMovimientoAlmacenDetalle.SetRowCellValue(index, "MontoTotal", objE_Producto.PrecioABSoles);
                    //    gvMovimientoAlmacenDetalle.SetRowCellValue(index, "Stock", objE_Producto.Cantidad);

                    //    gvMovimientoAlmacenDetalle.FocusedRowHandle = index;
                    //    gvMovimientoAlmacenDetalle.FocusedColumn = gvMovimientoAlmacenDetalle.GetVisibleColumn(4);
                    //    gvMovimientoAlmacenDetalle.ShowEditor();
                    //}
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

                if (e.KeyCode == Keys.F1)
                {
                    
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
                int IdMovimientoAlmacenDetalle = 0;
                int IdProducto = 0;
                IdMovimientoAlmacenDetalle = int.Parse(gvMovimientoAlmacenDetalle.GetFocusedRowCellValue("IdMovimientoAlmacenDetalle").ToString());
                IdProducto = int.Parse(gvMovimientoAlmacenDetalle.GetFocusedRowCellValue("IdProducto").ToString());
                int Item = 0;
                Item = int.Parse(gvMovimientoAlmacenDetalle.GetFocusedRowCellValue("Item").ToString());
                MovimientoAlmacenDetalleBE objBE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                objBE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = IdMovimientoAlmacenDetalle;
                objBE_MovimientoAlmacenDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                if (IdProducto > 0)
                {
                    if (Convert.ToInt32(cboMotivo.EditValue) != Parametros.intMovAjusteInventario)//add 05
                    {
                        MovimientoAlmacenDetalleBL objBL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL();
                        objBL_MovimientoAlmacenDetalle.Elimina(objBE_MovimientoAlmacenDetalle, Parametros.intTipoDocNotaIngreso, Convert.ToInt32(cboAlmacen.EditValue));
                    }


                }
                gvMovimientoAlmacenDetalle.DeleteRow(gvMovimientoAlmacenDetalle.FocusedRowHandle);
                gvMovimientoAlmacenDetalle.RefreshData();

                //RegeneraItem
                int i = 0;
                int cuenta = 0;
                foreach (var item in mListaMovimientoAlmacenDetalleOrigen)
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

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
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

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el numero de documento de referencia.\n";
                flag = true;
            }

            if (txtNumero.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el numero.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboMotivo.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un motivo de movimiento.\n";
                flag = true;
            }

            foreach (CMovimientoAlmacenDetalle item in mListaMovimientoAlmacenDetalleOrigen)
            {
                var BuscarCodigo = mListaMovimientoAlmacenDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == item.CodigoProveedor.ToUpper()).ToList();
                if (BuscarCodigo.Count > 1)
                {
                    strMensaje = strMensaje + "- El código de producto se repite en lista.\nEliminar Registros en Blanco.\n";
                    flag = true;
                }

                if (item.Cantidad <= 0)
                {
                    strMensaje = strMensaje + "- Ingresar cantidad válida en el código:" + item.CodigoProveedor + "\n";
                    flag = true;
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
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocNotaIngreso, Parametros.intPeriodo);
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

        private void CargaNotaSalidaDetalle(string Numero)
        {
            try
            {
                //Verificar
                List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalleIngreso = null;
                lstMovimientoAlmacenDetalleIngreso = new MovimientoAlmacenDetalleBL().ListaNumeroDocumento(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue) , Parametros.intTipMovIngreso, Numero);
                if (lstMovimientoAlmacenDetalleIngreso.Count > 0)
                {
                    XtraMessageBox.Show("El número de documento ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Cargar 
                List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = null;
                lstMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaNumero(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Parametros.intTipMovSalida, Numero);

                if (lstMovimientoAlmacenDetalle.Count == 0)
                {
                     XtraMessageBox.Show("La nota de salida no tiene códigos, Verificar." , this.Text,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     return;
                }

                cboAlmacen.Properties.ReadOnly = true;
                cboAlmacenDestino.Properties.ReadOnly = true;

                //if (IdMovimientoAlmacen == lstMovimientoAlmacenDetalle[0].IdMovimientoAlmacen)//Existe en la BD
                //{
                //    XtraMessageBox.Show("La nota de salida ya existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}

                foreach (MovimientoAlmacenDetalleBE item in lstMovimientoAlmacenDetalle)
                {
                    CMovimientoAlmacenDetalle objE_MovimientoAlmacenDetalle = new CMovimientoAlmacenDetalle();
                    objE_MovimientoAlmacenDetalle.IdEmpresa = item.IdEmpresa;
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = item.IdMovimientoAlmacen;
                    IdMovimientoAlmacen = item.IdMovimientoAlmacen;
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

                //Cargamos el motivo de la nota de salida

                MovimientoAlmacenBE objE_MovimientoAlmacen = null;
                objE_MovimientoAlmacen = new MovimientoAlmacenBL().Selecciona(Parametros.intEmpresaId, IdMovimientoAlmacen);
                cboMotivo.EditValue = Parametros.intMovTransferencia;
                cboAlmacen.EditValue = objE_MovimientoAlmacen.IdAlmacenDestino;
                cboAlmacenDestino.EditValue = objE_MovimientoAlmacen.IdAlmacenOrigen;
                IdCliente = objE_MovimientoAlmacen.IdCliente;
                IdMovimientoAlmacenReferencia = objE_MovimientoAlmacen.IdMovimientoAlmacen;

                //Deshabilitamos la NS
                //gcMovimientoAlmacenDetalle.Enabled = false;
                gvMovimientoAlmacenDetalle.OptionsBehavior.Editable = false;
                mnuContextual.Enabled = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaGuiaRemision(string Numero)
        {
            List<GuiaRemisionDetalleBE> lstGuiaRemisionDetalle = null;
            lstGuiaRemisionDetalle = new GuiaRemisionDetalleBL().ListaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Numero);

            foreach (GuiaRemisionDetalleBE item in lstGuiaRemisionDetalle)
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
        }

        private void BloquearAccesoPorPerfil()
        {
            UsuarioBE ObjE_Usuario = null;
            ObjE_Usuario = new UsuarioBL().Selecciona(Parametros.intUsuarioId);

            if (ObjE_Usuario != null)
            {
                if (ObjE_Usuario.IdPerfil == 1 || ObjE_Usuario.IdPerfil == 18 || ObjE_Usuario.IdPerfil == 58 || ObjE_Usuario.IdPerfil == 20 || Parametros.strUsuarioLogin == "dllanos" 
                    || Parametros.strUsuarioLogin == "DLLANOS"  /*|| ObjE_Usuario.IdPerfil == 3 || ObjE_Usuario.IdPerfil == 21 || ObjE_Usuario.IdPerfil == 20*/)
                {
                    cboMotivo.Properties.ReadOnly = false;
                    cboAlmacen.Properties.ReadOnly = false;
                    //cboMotivo.EditValue = Parametros.intMovTransferencia;
                }
            }

            if (Parametros.strUsuarioLogin == "adavila"|| Parametros.strUsuarioLogin == "gcuba")
            {
                cboMotivo.Properties.ReadOnly = false;
                cboAlmacen.Properties.ReadOnly = false;
                cboMotivo.EditValue = Parametros.intMovTransferencia;
            }

            if (IdMovimientoAlmacen > 0)
            {
                cboMotivo.Properties.ReadOnly = true;
                cboAlmacen.Properties.ReadOnly = true;
                cboAlmacenDestino.Properties.ReadOnly = true;
                cboDocumento.Properties.ReadOnly = true;
                deFecha.Properties.ReadOnly = true;
                txtNumeroDocumento.Properties.ReadOnly = true;
                txtObservaciones.Properties.ReadOnly = true;
                mnuContextual.Enabled = false;
                btnGrabar.Enabled = false;
            }

        }

        private void SeteaMovimientoDetalle()
        {
            mListaMovimientoAlmacenDetalleOrigen.Clear();
            bsListado.DataSource = mListaMovimientoAlmacenDetalleOrigen;
            gcMovimientoAlmacenDetalle.DataSource = bsListado;
            gcMovimientoAlmacenDetalle.RefreshDataSource();
        }

        #endregion

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

            public CMovimientoAlmacenDetalle()
            {

            }
        }

        private void cboAlmacen_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovAjusteInventario || Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovMermas)
            {
                cboAlmacenDestino.EditValue = cboAlmacen.EditValue;
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
                prgFactura.Properties.Step = 1;
                prgFactura.Properties.Maximum = TotRow;
                prgFactura.Properties.Minimum = 0;


                //Recorremos para la Nota de Salida
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                   string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                  //   int CodigoProveedor2 = Convert.ToInt32((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim());
                    int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());

                    //ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
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
                        XtraMessageBox.Show("El código " + Convert.ToString( CodigoProveedor) + "No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
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

        private void cboMotivo_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovTranferenciaDirecta)
            {
                cboAlmacenDestino.EditValue = cboAlmacen.EditValue;
            }
            if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovReparacionTaller)
            {
                cboAlmacenDestino.EditValue = cboAlmacen.EditValue;
            }

            //Ajuste de Inventario
            if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovAjusteInventario || Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovMermas)
            {
                cboAlmacenDestino.EditValue = cboAlmacen.EditValue;
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
            }
            else
            {
                if (Parametros.intPerfilId == Parametros.intPerAdministrador
                    || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen  ||  Parametros.intPerfilId == Parametros.intPerAsistenteMarketing || Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.intPerfilId == Parametros.intPerAnalistaInventario || Parametros.intPerfilId == Parametros.intPerAuxiliarAlmacen || Parametros.intPerfilId == Parametros.intPerAnalistaProducto || Parametros.strUsuarioLogin == "FMIRANDA" || Parametros.strUsuarioLogin == "dllanos" || Parametros.strUsuarioLogin == "DLLANOS")
                    BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);
                else
                    BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivoPrincipal(Parametros.intEmpresaId, Parametros.intTiendaId), "DescAlmacen", "IdAlmacen", true);
            }


            //if (pOperacion == Operacion.Nuevo)
            //{
            //    if (Parametros.intPerfilId != Parametros.intPerAdministrador)
            //    {
            //        if (Convert.ToInt32(cboMotivo.EditValue) == Parametros.intMovAjusteInventario)
            //        {
            //            cboMotivo.EditValue = Parametros.intMovTransferencia;
            //        }
            //    }
            //}
        }

        private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Seteamos el Movimiento
                SeteaMovimientoDetalle();

                switch (cboDocumento.Text)
                {
                    case "N/S":
                        CargaNotaSalidaDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    case "G/R":
                        CargaGuiaRemision(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    default:
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
}