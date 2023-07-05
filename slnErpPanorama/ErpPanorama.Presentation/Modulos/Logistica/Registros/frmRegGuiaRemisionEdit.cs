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
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegGuiaRemisionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        const short shtIdSeleccionar = -1;
        public List<GuiaRemisionBE> lstGuiaRemision;
        public List<CGuiaRemisionDetalle> mListaGuiaRemisionDetalleOrigen = new List<CGuiaRemisionDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdGuiaRemision = 0;

        public int IdGuiaRemision
        {
            get { return _IdGuiaRemision; }
            set { _IdGuiaRemision = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmRegGuiaRemisionEdit()
        {
            InitializeComponent();
        }

        private void frmRegGuiaRemisionEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            CargarCombos();
            BSUtils.LoaderLook(cboEmpresaDestinatario, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", false);
            cboEmpresaDestinatario.EditValue = Parametros.intIdPanoramaDistribuidores;
            BSUtils.LoaderLook(cboDocumentoReferencia, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModLogistica, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMotivoAlmancen), "DescTablaElemento", "IdTablaElemento", true);
            tmrNumero.Enabled = true;
            tmrNumero.Interval = 10000;
            ObtenerCorrelativo();

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Guia Remisión - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Guia Remisión - Modificar";

                GuiaRemisionBE objE_GuiaRemision = null;
                objE_GuiaRemision = new GuiaRemisionBL().Selecciona(Parametros.intEmpresaId, IdGuiaRemision);

                IdGuiaRemision = objE_GuiaRemision.IdGuiaRemision;
                cboTiendaRemitente.EditValue = objE_GuiaRemision.IdTiendaRemitente;
                txtSerie.Text = objE_GuiaRemision.Serie;
                txtNumero.Text = objE_GuiaRemision.Numero;
                deFecha.EditValue = objE_GuiaRemision.Fecha;
                txtDireccionRemitente.Text = objE_GuiaRemision.DireccionRemitente;
                cboEmpresaDestinatario.EditValue = objE_GuiaRemision.IdEmpresaDestinatario;
                cboTiendaDestinatario.EditValue = objE_GuiaRemision.IdTiendaDestinatario;
                txtDireccionDestinatario.Text = objE_GuiaRemision.DireccionDestinatario;
                txtRuc.Text = objE_GuiaRemision.RucTransportista;
                txtTransportista.Text = objE_GuiaRemision.DescTransportista;
                txtNumeroLicencia.Text = objE_GuiaRemision.NumeroLicencia;
                txtVehiculo.Text = objE_GuiaRemision.DescVehiculo;
                txtPlaca.Text = objE_GuiaRemision.NumeroPlaca;
                cboDocumentoReferencia.EditValue = objE_GuiaRemision.IdTipoDocumentoReferencia;
                txtNumeroDocumento.Text = objE_GuiaRemision.NumeroDocumento;
                cboMotivo.EditValue = objE_GuiaRemision.IdMotivo;
                txtObservaciones.Text = objE_GuiaRemision.Observacion;
            }

            CargaGuiaRemisionDetalle();
        }

        private void cboEmpresaDestinatario_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresaDestinatario.EditValue != null)
            {
                //Destinatario
                List<TiendaBE> ListTiendaDestinatario = new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresaDestinatario.EditValue));
                cboTiendaDestinatario.Properties.DataSource = ListTiendaDestinatario;
                cboTiendaDestinatario.Properties.DisplayMember = "DescTienda";
                cboTiendaDestinatario.Properties.ValueMember = "IdTienda";
                cboTiendaDestinatario.ItemIndex = 0;

                txtDireccionDestinatario.Text = cboTiendaDestinatario.GetColumnValue("Direccion").ToString();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarSalida())
                {
                    GuiaRemisionBL objBL_GuiaRemision = new GuiaRemisionBL();
                    GuiaRemisionBE objGuiaRemision = new GuiaRemisionBE();

                    objGuiaRemision.IdGuiaRemision = IdGuiaRemision;
                    objGuiaRemision.Periodo = Parametros.intPeriodo;
                    objGuiaRemision.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                    objGuiaRemision.Serie = txtSerie.Text;
                    objGuiaRemision.Numero = txtNumero.Text;
                    objGuiaRemision.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objGuiaRemision.IdTiendaRemitente = Convert.ToInt32(cboTiendaRemitente.EditValue);
                    objGuiaRemision.IdEmpresaDestinatario = Convert.ToInt32(cboEmpresaDestinatario.EditValue);
                    objGuiaRemision.IdTiendaDestinatario = Convert.ToInt32(cboTiendaDestinatario.EditValue);
                    objGuiaRemision.DescTransportista = txtTransportista.Text;
                    objGuiaRemision.RucTransportista = txtRuc.Text;
                    objGuiaRemision.NumeroLicencia = txtNumeroLicencia.Text;
                    objGuiaRemision.DescVehiculo = txtVehiculo.Text;
                    objGuiaRemision.NumeroPlaca = txtPlaca.Text;
                    objGuiaRemision.IdTipoDocumentoReferencia = Convert.ToInt32(cboDocumentoReferencia.EditValue);
                    objGuiaRemision.NumeroDocumento = txtNumeroDocumento.Text;
                    objGuiaRemision.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objGuiaRemision.Observacion = txtObservaciones.Text;
                    objGuiaRemision.FlagEstado = true;
                    objGuiaRemision.Usuario = Parametros.strUsuarioLogin;
                    objGuiaRemision.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objGuiaRemision.IdEmpresa = Parametros.intEmpresaId;

                    //Registro de Compra Detalle
                    List<GuiaRemisionDetalleBE> lstGuiaRemisionDetalle = new List<GuiaRemisionDetalleBE>();

                    foreach (var item in mListaGuiaRemisionDetalleOrigen)
                    {
                        GuiaRemisionDetalleBE objE_GuiaRemisionDetalle = new GuiaRemisionDetalleBE();
                        objE_GuiaRemisionDetalle.IdGuiaRemisionDetalle = item.IdGuiaRemisionDetalle;
                        objE_GuiaRemisionDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objE_GuiaRemisionDetalle.IdGuiaRemision = IdGuiaRemision;
                        objE_GuiaRemisionDetalle.Item = item.Item;
                        objE_GuiaRemisionDetalle.IdProducto = item.IdProducto;
                        objE_GuiaRemisionDetalle.Cantidad = item.Cantidad;
                        objE_GuiaRemisionDetalle.CantidadAnt = item.CantidadAnt;
                        objE_GuiaRemisionDetalle.CostoUnitario = item.CostoUnitario;
                        objE_GuiaRemisionDetalle.MontoTotal = item.MontoTotal;
                        objE_GuiaRemisionDetalle.IdKardex = item.IdKardex;
                        objE_GuiaRemisionDetalle.FlagEstado = true;
                        objE_GuiaRemisionDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_GuiaRemisionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_GuiaRemisionDetalle.TipoOper = item.TipoOper;
                        lstGuiaRemisionDetalle.Add(objE_GuiaRemisionDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_GuiaRemision.Inserta(objGuiaRemision, lstGuiaRemisionDetalle);
                    }
                    else
                    {
                        objBL_GuiaRemision.Actualiza(objGuiaRemision, lstGuiaRemisionDetalle);
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
                    string CodigoProveedor = (sender as TextEdit).Text;
                    StockBE objE_Producto = new StockBE();
                    objE_Producto = new StockBL().SeleccionaProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, CodigoProveedor);
                    if (objE_Producto == null)
                    {
                        XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int index = gvGuiaRemisionDetalle.FocusedRowHandle;
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "IdProducto", objE_Producto.IdProducto);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "CodigoProveedor", objE_Producto.CodigoProveedor);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "NombreProducto", objE_Producto.NombreProducto);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "Abreviatura", objE_Producto.Abreviatura);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "Cantidad", 1);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "CostoUnitario", objE_Producto.PrecioABSoles);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "MontoTotal", objE_Producto.PrecioABSoles);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "Stock", objE_Producto.Cantidad);

                        gvGuiaRemisionDetalle.FocusedRowHandle = index;
                        gvGuiaRemisionDetalle.FocusedColumn = gvGuiaRemisionDetalle.GetVisibleColumn(4);
                        gvGuiaRemisionDetalle.ShowEditor();
                    }
                }

                if (e.KeyCode == Keys.F1)
                {
                    frmBusProductoStock objBusProducto = new frmBusProductoStock();
                    objBusProducto.IdTienda = Parametros.intTiendaId;
                    objBusProducto.ShowDialog();
                    if (objBusProducto.pProductoBE != null)
                    {
                        int index = gvGuiaRemisionDetalle.FocusedRowHandle;
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "IdProducto", objBusProducto.pProductoBE.IdProducto);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "CodigoProveedor", objBusProducto.pProductoBE.CodigoProveedor);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "NombreProducto", objBusProducto.pProductoBE.NombreProducto);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "Abreviatura", objBusProducto.pProductoBE.Abreviatura);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "Cantidad", 1);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "CostoUnitario", objBusProducto.pProductoBE.PrecioABSoles);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "MontoTotal", objBusProducto.pProductoBE.PrecioABSoles);
                        gvGuiaRemisionDetalle.SetRowCellValue(index, "Stock", objBusProducto.pProductoBE.Cantidad);

                        gvGuiaRemisionDetalle.FocusedRowHandle = index;
                        gvGuiaRemisionDetalle.FocusedColumn = gvGuiaRemisionDetalle.GetVisibleColumn(4);
                        gvGuiaRemisionDetalle.ShowEditor();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvGuiaRemisionDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int intCantidad = 0;
            decimal decCostoUnitario = 0;
            decimal decMontoTotal = 0;

            if (e.Column.Caption == "Cantidad")
            {
                if (int.Parse(e.Value.ToString()) > 0)
                {
                    intCantidad = int.Parse(e.Value.ToString());
                    decMontoTotal = decimal.Parse(gvGuiaRemisionDetalle.GetRowCellValue(e.RowHandle, gvGuiaRemisionDetalle.Columns["CostoUnitario"]).ToString()) * decimal.Parse(intCantidad.ToString());
                    gvGuiaRemisionDetalle.SetRowCellValue(e.RowHandle, gvGuiaRemisionDetalle.Columns["MontoTotal"], decMontoTotal);
                }
            }

            if (e.Column.Caption == "P.Unitario")
            {
                if (decimal.Parse(e.Value.ToString()) > 0)
                {
                    decCostoUnitario = decimal.Parse(e.Value.ToString());
                    decMontoTotal = decimal.Parse(gvGuiaRemisionDetalle.GetRowCellValue(e.RowHandle, gvGuiaRemisionDetalle.Columns["Cantidad"]).ToString()) * decCostoUnitario;
                    gvGuiaRemisionDetalle.SetRowCellValue(e.RowHandle, gvGuiaRemisionDetalle.Columns["MontoTotal"], decMontoTotal);
                }
            }
        }

        private void gvGuiaRemisionDetalle_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //if (e.Value != null)
            //{
            //    if (e.Value.ToString().Trim().Length > 0)
            //    {
            //        GridView view = sender as GridView;
            //        if (view.FocusedColumn.FieldName == "Cantidad")
            //        {
            //            object Stock = gvGuiaRemisionDetalle.GetFocusedRowCellValue("Stock");
            //            if (int.Parse(e.Value.ToString()) > Convert.ToInt32(Stock))
            //            {
            //                e.Valid = false;
            //                e.ErrorText = "La cantidad solicitada es mayor al stock" + "\n Stock : " + Stock.ToString();
            //            }
            //        }
            //    }
            //}
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvGuiaRemisionDetalle.AddNewRow();
                gvGuiaRemisionDetalle.SetRowCellValue(gvGuiaRemisionDetalle.FocusedRowHandle, "Item", (mListaGuiaRemisionDetalleOrigen.Count - 1) + 1);
                if (pOperacion == Operacion.Modificar)
                    gvGuiaRemisionDetalle.SetRowCellValue(gvGuiaRemisionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                else
                    gvGuiaRemisionDetalle.SetRowCellValue(gvGuiaRemisionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                gvGuiaRemisionDetalle.FocusedColumn = gvGuiaRemisionDetalle.GetVisibleColumn(1);
                gvGuiaRemisionDetalle.ShowEditor();

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
                int IdGuiaRemisionDetalle = 0;
                IdGuiaRemisionDetalle = int.Parse(gvGuiaRemisionDetalle.GetFocusedRowCellValue("IdGuiaRemisionDetalle").ToString());
                int Item = 0;
                Item = int.Parse(gvGuiaRemisionDetalle.GetFocusedRowCellValue("Item").ToString());
                GuiaRemisionDetalleBE objBE_GuiaRemisionDetalle = new GuiaRemisionDetalleBE();
                objBE_GuiaRemisionDetalle.IdGuiaRemisionDetalle = IdGuiaRemisionDetalle;
                objBE_GuiaRemisionDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_GuiaRemisionDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_GuiaRemisionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                GuiaRemisionDetalleBL objBL_GuiaRemisionDetalle = new GuiaRemisionDetalleBL();
                objBL_GuiaRemisionDetalle.Elimina(objBE_GuiaRemisionDetalle, Parametros.intAlmCentralUcayali);
                gvGuiaRemisionDetalle.DeleteRow(gvGuiaRemisionDetalle.FocusedRowHandle);
                gvGuiaRemisionDetalle.RefreshData();

                //RegeneraItem
                int i = 0;
                int cuenta = 0;
                foreach (var item in mListaGuiaRemisionDetalleOrigen)
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
            if (e.KeyCode == Keys.Enter)
            {
                switch (cboDocumentoReferencia.Text)
                {
                    case "SCP": CargaSolicitudProductoDetalle(txtNumeroDocumento.Text.ToString().Trim());
                        break;
                    default:
                        break;
                }
            }
        }

        private void cboTiendaRemitente_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTiendaRemitente.EditValue != null)
            {
                txtDireccionRemitente.Text = cboTiendaRemitente.GetColumnValue("Direccion").ToString();
            }
        }

        private void cboTiendaDestinatario_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTiendaDestinatario.EditValue != null)
            {
                txtDireccionDestinatario.Text = cboTiendaDestinatario.GetColumnValue("Direccion").ToString();
            }
        }

        #endregion

        #region "Metodos"

        private void CargarCombos()
        {
            //Remitente
            List<TiendaBE> ListTiendaRemitente = new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId);
            cboTiendaRemitente.Properties.DataSource = ListTiendaRemitente;
            cboTiendaRemitente.Properties.DisplayMember = "DescTienda";
            cboTiendaRemitente.Properties.ValueMember = "IdTienda";
            cboTiendaRemitente.ItemIndex = 0;

        }

        private bool ValidarSalida()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboEmpresaDestinatario.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una empresa de destino.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboTiendaDestinatario.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una tienda de destino.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboDocumentoReferencia.Text))
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

            foreach (CGuiaRemisionDetalle item in mListaGuiaRemisionDetalleOrigen)
            {
                var BuscarCodigo = mListaGuiaRemisionDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == item.CodigoProveedor.ToUpper()).ToList();
                if (BuscarCodigo.Count > 1)
                {
                    strMensaje = strMensaje + "- El código de producto se repite en lista.\n";
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


        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocGuiaRemision, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                txtSerie.Text = sSerie;
                txtNumero.Text = sNumero;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaSolicitudProductoDetalle(string Numero)
        {
            List<SolicitudProductoDetalleBE> lstSolicitudProductoDetalle = null;
            lstSolicitudProductoDetalle = new SolicitudProductoDetalleBL().ListaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Numero);

            foreach (SolicitudProductoDetalleBE item in lstSolicitudProductoDetalle)
            {
                CGuiaRemisionDetalle objE_GuiaRemisionDetalle = new CGuiaRemisionDetalle();
                objE_GuiaRemisionDetalle.IdEmpresa = item.IdEmpresa;
                objE_GuiaRemisionDetalle.IdGuiaRemision = 0;
                objE_GuiaRemisionDetalle.IdGuiaRemisionDetalle = 0;
                objE_GuiaRemisionDetalle.Item = item.Item;
                objE_GuiaRemisionDetalle.IdProducto = item.IdProducto;
                objE_GuiaRemisionDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_GuiaRemisionDetalle.NombreProducto = item.NombreProducto;
                objE_GuiaRemisionDetalle.Abreviatura = item.Abreviatura;
                objE_GuiaRemisionDetalle.Cantidad = item.Cantidad;
                objE_GuiaRemisionDetalle.CantidadAnt = item.Cantidad;
                objE_GuiaRemisionDetalle.CostoUnitario = item.CostoUnitario;
                objE_GuiaRemisionDetalle.MontoTotal = item.MontoTotal;
                objE_GuiaRemisionDetalle.Stock = item.Cantidad;
                objE_GuiaRemisionDetalle.FlagEstado = item.FlagEstado;

                objE_GuiaRemisionDetalle.TipoOper = item.TipoOper;
                mListaGuiaRemisionDetalleOrigen.Add(objE_GuiaRemisionDetalle);
            }

            bsListado.DataSource = mListaGuiaRemisionDetalleOrigen;
            gcGuiaRemisionDetalle.DataSource = bsListado;
            gcGuiaRemisionDetalle.RefreshDataSource();
        }

        private void CargaGuiaRemisionDetalle()
        {
            List<GuiaRemisionDetalleBE> lstGuiaRemisionDetalle = null;
            lstGuiaRemisionDetalle = new GuiaRemisionDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdGuiaRemision);

            foreach (GuiaRemisionDetalleBE item in lstGuiaRemisionDetalle)
            {
                CGuiaRemisionDetalle objE_GuiaRemisionDetalle = new CGuiaRemisionDetalle();
                objE_GuiaRemisionDetalle.IdEmpresa = item.IdEmpresa;
                objE_GuiaRemisionDetalle.IdGuiaRemision = item.IdGuiaRemision;
                objE_GuiaRemisionDetalle.IdGuiaRemisionDetalle = item.IdGuiaRemisionDetalle;
                objE_GuiaRemisionDetalle.Item = item.Item;
                objE_GuiaRemisionDetalle.IdProducto = item.IdProducto;
                objE_GuiaRemisionDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_GuiaRemisionDetalle.NombreProducto = item.NombreProducto;
                objE_GuiaRemisionDetalle.Abreviatura = item.Abreviatura;
                objE_GuiaRemisionDetalle.Cantidad = item.Cantidad;
                objE_GuiaRemisionDetalle.CantidadAnt = item.Cantidad;
                objE_GuiaRemisionDetalle.CostoUnitario = item.CostoUnitario;
                objE_GuiaRemisionDetalle.MontoTotal = item.MontoTotal;
                objE_GuiaRemisionDetalle.Stock = item.Cantidad;
                objE_GuiaRemisionDetalle.FlagEstado = item.FlagEstado;
                objE_GuiaRemisionDetalle.TipoOper = item.TipoOper;
                mListaGuiaRemisionDetalleOrigen.Add(objE_GuiaRemisionDetalle);
            }

            bsListado.DataSource = mListaGuiaRemisionDetalleOrigen;
            gcGuiaRemisionDetalle.DataSource = bsListado;
            gcGuiaRemisionDetalle.RefreshDataSource();
        }
        
        #endregion

        

    }

    public class CGuiaRemisionDetalle
    {
        public Int32 IdEmpresa { get; set; }
        public Int32 IdGuiaRemision { get; set; }
        public Int32 IdGuiaRemisionDetalle { get; set; }
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
        public Boolean FlagEstado { get; set; }
        public Int32 Stock { get; set; }
        public Int32 TipoOper { get; set; }

        public CGuiaRemisionDetalle()
        {

        }
    }
}