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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros;
using DevExpress.CodeParser;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegIngresosEgresosEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public List<DetIngresoEgreso> mListaDocumentoVentaDetalleOrigen = new List<DetIngresoEgreso>();

        public List<IngresoEgresoBE> lstIngresoEgreso;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TablaElementoBE pTablaElementoBE { get; set; }

        public SubTipificacionesBE pSubTipificacionesBE { get; set; }

        public IngresoEgresoBE pIngresoEgresoBE { get; set; }

        int _IdTabla = 0;

        public int IdTabla
        {
            get { return _IdTabla; }
            set { _IdTabla = value; }
        }

        int _IdTablaElemento = 0;

        public int IdTablaElemento
        {
            get { return _IdTablaElemento; }
            set { _IdTablaElemento = value; }
        }
        int _IdSubTipificacion = 0;
        public int IdSubTipificacion
        {
            get { return _IdSubTipificacion; }
            set { _IdSubTipificacion = value; }
        }
        int _IdTipificacion = 0;
        public int IdTipificacion
        {
            get { return _IdTipificacion; }
            set { _IdTipificacion = value; }
        }
        int _IdArea = 0;
        public int IdArea
        {
            get { return _IdArea; }
            set { _IdArea = value; }
        }
        #endregion

        #region "Eventos"

        public frmRegIngresosEgresosEdit()
        {
            InitializeComponent();
        }

        private void frmManSubTipificacionesEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;

            BSUtils.LoaderLook(cboLocal, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblLocal), "DescTablaElemento", "IdTablaElemento", true);
            //cboMoneda.EditValue = Parametros.intSoles;

            BSUtils.LoaderLook(cboArea, new FAreasBL().Listar(""), "DescArea", "IdArea", true);
            cboArea.EditValue = -1;

            BSUtils.LoaderLook(cboTipoRegistro, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoGestion), "DescTablaElemento", "IdTablaElemento", true);
            //      cboMoneda.EditValue =  Parametros.intTGestionIngreso;
            BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboMonedabanco, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMonedabanco.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboTipoCuenta, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCuentaBanco), "DescTablaElemento", "IdTablaElemento", true);

            //Obtenemos la lista de proveedores
            Parametros.pListaProveedores = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);
            BSUtils.LoaderLook(cboProveedor, Parametros.pListaProveedores, "DescProveedor", "IdProveedor", false);

            textEdit4.Text = "";
            textEdit5.Text = "";

            //BSUtils.LoaderLook(cboTabla, new TipificacionesBL().Listar("") , "DescTipificacion", "IdTipificacion", true);   // Tipificacion
            //cboTabla.EditValue = pSubTipificacionesBE.IdTipificacion;

            //BSUtils.LoaderLook(cboAreas, new FAreasBL().Listar(""), "DescArea", "IdArea", true);   // Areas
            //cboAreas.EditValue = pSubTipificacionesBE.IdArea;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Nuevo Registro Ingreso - Egreso";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Modificar Registro Ingreso - Egreso";
                //txtDescSubTipificacion.Text = pSubTipificacionesBE.DescSubTipificacion;
            }

            cboTipificacion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                   IngresoEgresoBL objBL_Cab_Ingreso = new IngresoEgresoBL();

                    IngresoEgresoBE objCabIngreso = new IngresoEgresoBE();
                    objCabIngreso.NumIngresoEgreso = "";
                    objCabIngreso.FecIngresoEgreso  = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objCabIngreso.tCambio = Convert.ToDecimal(txtTipoCambio.Text);
                    objCabIngreso.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objCabIngreso.IdArea = Convert.ToInt32(cboArea.EditValue);
                    objCabIngreso.IdTablaTipoGestion = 73;
                    objCabIngreso.IdTablaElementoTipoGestion = Convert.ToInt32(cboTipoRegistro.EditValue);
                    objCabIngreso.IdTipificacion = Convert.ToInt32(cboTipificacion.EditValue);
                    objCabIngreso.IdProveedor = Convert.ToInt32(cboProveedor.EditValue);
                    objCabIngreso.IdTablaTipoDocumento = 83;
                    objCabIngreso.IdTablaElementoTipoDocumento = Convert.ToInt32(cboTipoDocumento.EditValue);
                    objCabIngreso.NumDocumento = txtNumDocumento.Text;
                    objCabIngreso.IdTablaLocal = 81;
                    objCabIngreso.IdTablaElementoLocal = Convert.ToInt32(cboLocal.EditValue);

                    objCabIngreso.IdBanco = Convert.ToInt32(cboBanco.EditValue);
                    objCabIngreso.IdTablaTipoCuenta = 58;
                    objCabIngreso.IdTablaElementoTipoCuenta = Convert.ToInt32(cboLocal.EditValue);

                    objCabIngreso.SubTotal = Convert.ToDecimal(txtSubTotal.Text);
                    objCabIngreso.Igv = Convert.ToDecimal(txtIgv.Text);
                    objCabIngreso.Total = Convert.ToDecimal(txtTotal.Text);
                    objCabIngreso.Detraccion = Convert.ToDecimal(txtDetraccion.Text);

                    objCabIngreso.Estado = chkEstado.Checked;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Cab_Ingreso.Inserta(objCabIngreso);
                    else
                        objBL_Cab_Ingreso.Actualiza(objCabIngreso);

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

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboTipificacion.Text))
            {
                strMensaje = strMensaje + "- Seleccionar la tabla.\n";
                flag = true;
            }

            //if (txtDescSubTipificacion.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese la descripción.\n";
            //    flag = true;
            //}

            if (pOperacion == Operacion.Nuevo)
            {
                //var Buscar = lstTablaElemento.Where(oB => oB.DescSubTipificacion.ToUpper() == txtDescSubTipificacion.Text.ToUpper()).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- La descripción ya existe.\n";
                //    flag = true;
                //}
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion

        private void deFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void frmRegIngresosEgresosEdit_Shown(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)//add 1711
            {
                bool bolFlag = false;

                TipoCambioBE objE_TipoCambio = null;
                objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Parametros.dtFechaHoraServidor);
                if (objE_TipoCambio == null)
                {
                    XtraMessageBox.Show("Falta ingresar Tipo de Cambio del Día", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bolFlag = true;
                }
                else
                {
                    txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Compra.ToString());
                }

                if (bolFlag)
                {
                    this.Close();
                }
            }
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmManProveedorEdit objManProveedor = new frmManProveedorEdit();
            objManProveedor.lstProveedor = Parametros.pListaProveedores;
            objManProveedor.pOperacion = frmManProveedorEdit.Operacion.Nuevo;
            objManProveedor.IdProveedor = 0;
            objManProveedor.StartPosition = FormStartPosition.CenterParent;
            objManProveedor.ShowDialog();

            BSUtils.LoaderLook(cboProveedor, new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId), "DescProveedor", "IdProveedor", false);
        }

        private void cboProveedor_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTipoRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTipoRegistro_EditValueChanged(object sender, EventArgs e)
        {
            while (gvDocumentoDetalle.RowCount != 0)
            {
                gvDocumentoDetalle.SelectAll();
                gvDocumentoDetalle.DeleteSelectedRows();
            }

            if (cboTipoRegistro.EditValue != null)
            {
                BSUtils.LoaderLook(cboTipificacion, new TipificacionesBL().ListarPorTipoGestion(cboTipoRegistro.EditValue.ToString()), "DescTipificacion", "IdTipificacion", false);
               // cboTipificacion.EditValue = Parametros.sIdProvincia;
            }
        }

        public class DetIngresoEgreso
        {
            public Int32 IdSubTipificacion { get; set; }
            public String DescSubTipificacion { get; set; }
            public String UnidadMedida { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Monto { get; set; }
            public Boolean FlagEstado { get; set; }

            public DetIngresoEgreso()
            {

            }
        }
        private void cboTipificacion_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipificacion.EditValue != null)
            {
                //gcDocumentoDetalle.DataSource = null;
                //gvDocumentoDetalle.DataSource = null;
                ////.DataBind();
                while (gvDocumentoDetalle.RowCount != 0)
                {
                    gvDocumentoDetalle.SelectAll();
                    gvDocumentoDetalle.DeleteSelectedRows();
                }


                BSUtils.LoaderLook(cboTipoDocumento, new TipificacionesBL().ListarIdTipificacion(Convert.ToInt32(cboTipificacion.EditValue.ToString())), "DescTablaElemento", "IdTablaElemento", false);
                //cboTipoDocumento.EditValue = Parametros.sIdProvincia;
                
                List<RegIngresoEgresoBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new RegIngresoEgresoBL().ListaTodosActivo(Convert.ToInt32(cboTipoRegistro.EditValue.ToString()), Convert.ToInt32(cboTipificacion.EditValue.ToString()));

                foreach (RegIngresoEgresoBE item in lstTmpDocumentoVentaDetalle)
                {
                    DetIngresoEgreso objE_DocumentoDetalle = new DetIngresoEgreso();

                    objE_DocumentoDetalle.IdSubTipificacion = item.IdSubTipificacion;
                    objE_DocumentoDetalle.DescSubTipificacion = item.DescSubTipificacion;
                    objE_DocumentoDetalle.UnidadMedida = item.UnidadMedida;
                    objE_DocumentoDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoDetalle.Monto = item.Monto;
                    objE_DocumentoDetalle.FlagEstado = item.FlagEstado;

                    mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                }

                bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                gcDocumentoDetalle.DataSource = bsListado;
                gcDocumentoDetalle.RefreshDataSource();


            }
        }

        private void gvDocumentoDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.Caption == "Cantidad")
            //{
            //    decimal decCantidad = 0;
            //    decimal decPrecioVenta = 0;
            //    decimal decValorVenta = 0;

            //    decCantidad = decimal.Parse(e.Value.ToString());
            //    decPrecioVenta = decimal.Parse(gvDocumentoDetalle.GetRowCellValue(e.RowHandle, "PrecioUnitario").ToString()) * ((100 - decimal.Parse(gvDocumentoDetalle.GetRowCellValue(e.RowHandle, "PorcentajeDescuento").ToString())) / 100);
            //    decValorVenta = decPrecioVenta * decCantidad;
            //    gvDocumentoDetalle.SetRowCellValue(e.RowHandle, "PrecioVenta", decPrecioVenta);
            //    gvDocumentoDetalle.SetRowCellValue(e.RowHandle, "ValorVenta", decValorVenta);

            //}

            CalculaTotales();
        }

        private void CalculaTotales()
        {
            try
            {
                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deTotal = 0;
                decimal deTotal22 = 0;
                int intTotalCantidad = 0;

                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                      //  intTotalCantidad = intTotalCantidad + item.Cantidad;
                        deTotal = deTotal + item.Monto;
                    }

                    deTotal = Math.Round(deTotal, 2);
                    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    deImpuesto = Math.Round(deTotal - deSubTotal, 2);
                    txtTotal.EditValue = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(deTotal, 2)));    
                    txtSubTotal.EditValue = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(deSubTotal, 2)));    
                    txtIgv.EditValue = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(deImpuesto, 2)));  

                    //if (Convert.ToDecimal(txtDescuento.EditValue) > 0 || Convert.ToDecimal(txtDescuento.EditValue) > 0)
                    //{
                    //    deTotal22 = deTotal;
                    //    txtTotalBruto.EditValue = Math.Round(deTotal, 2);
                    //    deTotal = deTotal * ((100 - Math.Round((Convert.ToDecimal(txtTotalDescuento.EditValue) * 100) / Convert.ToDecimal(txtTotalBruto.EditValue), 15)) / 100);


                    //    txtDescuento.EditValue = Math.Round((Convert.ToDecimal(txtTotalDescuento.EditValue) * 100) / Convert.ToDecimal(txtTotalBruto.EditValue), 15);

                    //    txtTotal.Text = Math.Round(deTotal, 2).ToString();
                    //    deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    //    txtSubTotal.EditValue = deSubTotal;
                    //    deImpuesto = deTotal - deSubTotal;
                    //}
                }
                else
                {
                    txtSubTotal.EditValue = 0;
                    txtIgv.EditValue = 0;
                    txtTotal.EditValue = 0;
                    txtDetraccion.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboArea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboArea.EditValue != null)
            {
                Parametros.pListaAreas = new FAreasBL().Listar(cboArea.Text.Trim());
                foreach (FAreasBE item in Parametros.pListaAreas)
                {
                    textEdit4.Text = item.DescUnidadNegocio;
                    textEdit5.Text = item.DescCentroCosto;
                }
            }
        }

        private void cboBanco_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboMonedabanco_EditValueChanged(object sender, EventArgs e)
        {

        }

        //private void CargaDetalleSubTipificacion()
        //{
        //    List<RegIngresoEgresoBE> lstTmpDocumentoVentaDetalle = null;
        //    lstTmpDocumentoVentaDetalle = new RegIngresoEgresoBL().ListaTodosActivo(IdDocumentoVenta);

        //    foreach (RegIngresoEgresoBE item in lstTmpDocumentoVentaDetalle)
        //    {
        //        CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
        //        objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
        //        objE_DocumentoDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
        //        objE_DocumentoDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
        //        objE_DocumentoDetalle.Item = item.Item;
        //        objE_DocumentoDetalle.IdProducto = item.IdProducto;
        //        objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
        //        objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
        //        objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
        //        objE_DocumentoDetalle.Cantidad = item.Cantidad;
        //        objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
        //        objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
        //        objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
        //        objE_DocumentoDetalle.Descuento = item.Descuento;
        //        objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
        //        objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
        //        objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
        //        objE_DocumentoDetalle.IdKardex = item.IdKardex;
        //        objE_DocumentoDetalle.FlagMuestra = item.FlagMuestra;
        //        objE_DocumentoDetalle.FlagRegalo = item.FlagRegalo;
        //        objE_DocumentoDetalle.IdPromocion = item.IdPromocion;
        //        objE_DocumentoDetalle.Stock = 0;
        //        objE_DocumentoDetalle.TipoOper = item.TipoOper;
        //        mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
        //    }

        //    bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
        //    gcDocumentoDetalle.DataSource = bsListado;
        //    gcDocumentoDetalle.RefreshDataSource();
        //}

    }
}