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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManListaPrecioEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CListaPrecioDetalle> mListaPrecioDetalleOrigen =  new List<CListaPrecioDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ListaPrecioBE pListaPrecioBE { get; set; }

        int _IdListaPrecio = 0;

        public int IdListaPrecio
        {
            get { return _IdListaPrecio; }
            set { _IdListaPrecio = value; }
        }

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;

        private int StartRowHandle = -1;
        private int CurrentRowHandle = -1;

        #endregion

        #region "Eventos"

        public frmManListaPrecioEdit()
        {
            InitializeComponent();
        }

        private void frmManListaPrecioEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Lista Precio - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Lista Precio - Modificar";

                IdListaPrecio = pListaPrecioBE.IdListaPrecio;
                cboEmpresa.EditValue = pListaPrecioBE.IdEmpresa;
                cboTienda.EditValue = pListaPrecioBE.IdTienda;
                txtDescripcion.Text = pListaPrecioBE.DescListaPrecio;
            }

            txtProducto.Focus();

            intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            CalcularPaginas();
            CargarBusqueda(intPagina, intRegistrosPorPagina);
            HabilitarBotones(false, false, true, true);

            CargarBusqueda();
            FiltroMenuContextual();
            BloquearAccesoPorPerfil();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (cboEmpresa.EditValue != null)
            {
                BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarSalida())
                {
                    ListaPrecioBL objBL_ListaPrecio = new ListaPrecioBL();
                    ListaPrecioBE objListaPrecio = new ListaPrecioBE();

                    objListaPrecio.IdListaPrecio = IdListaPrecio;
                    objListaPrecio.DescListaPrecio = txtDescripcion.Text;
                    objListaPrecio.FlagEstado = true;
                    objListaPrecio.Usuario = Parametros.strUsuarioLogin;
                    objListaPrecio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objListaPrecio.IdEmpresa = Parametros.intEmpresaId;
                    objListaPrecio.IdTienda = Parametros.intTiendaId;

                    //Registro de Compra Detalle
                    List<ListaPrecioDetalleBE> lstListaPrecioDetalle = new List<ListaPrecioDetalleBE>();

                    foreach (var item in mListaPrecioDetalleOrigen)
                    {
                        if(item.PrecioCD <=0)
                        {
                            XtraMessageBox.Show("El precio de venta Ingresado para el código "+ item.CodigoProveedor + " es incorrecto, Por favor verificar.\nSi Ud. desea realizar una venta con precio(0), debe ingresar el precio que corresponde y 100% de Descuento",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                            return;
                        }

                        ListaPrecioDetalleBE objE_ListaPrecioDetalle = new ListaPrecioDetalleBE();
                        objE_ListaPrecioDetalle.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                        objE_ListaPrecioDetalle.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                        objE_ListaPrecioDetalle.IdListaPrecioDetalle = item.IdListaPrecioDetalle;
                        objE_ListaPrecioDetalle.IdListaPrecio = IdListaPrecio;
                        objE_ListaPrecioDetalle.IdProducto = item.IdProducto;
                        objE_ListaPrecioDetalle.PrecioAB = item.PrecioAB;
                        objE_ListaPrecioDetalle.PrecioCD = item.PrecioCD;
                        objE_ListaPrecioDetalle.Descuento = item.Descuento;
                        objE_ListaPrecioDetalle.DescuentoOutlet = item.DescuentoOutlet;
                        objE_ListaPrecioDetalle.FlagAutoservicio = item.FlagAutoservicio;
                        objE_ListaPrecioDetalle.TipoCambioCD = item.TipoCambioCD;
                        objE_ListaPrecioDetalle.FlagEstado = true;
                        objE_ListaPrecioDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_ListaPrecioDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ListaPrecioDetalle.TipoOper = item.TipoOper;
                        lstListaPrecioDetalle.Add(objE_ListaPrecioDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_ListaPrecio.Inserta(objListaPrecio, lstListaPrecioDetalle);
                    }
                    else
                    {
                        objBL_ListaPrecio.Actualiza(objListaPrecio, lstListaPrecioDetalle);
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
        
        private void gvListaPrecioDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
          /*  decimal decPrecioAB = 0;
            decimal decPrecioCD = 0; 
            decimal decPrecioABSoles = 0;
            decimal decPrecioCDSoles = 0;

            if (e.Column.Caption == "Precio AB US$")
            {
                if (decimal.Parse(e.Value.ToString()) > 0)
                {
                    decPrecioAB = decimal.Parse(e.Value.ToString());
                    //Calcular Precio CD
                    decPrecioCD = decPrecioAB * Convert.ToDecimal(1.15);
                    gvListaPrecioDetalle.SetRowCellValue(e.RowHandle, gvListaPrecioDetalle.Columns["PrecioCD"], decPrecioCD);

                    //Calcular Precio AB Soles
                    decPrecioABSoles = decPrecioAB * Convert.ToDecimal(Parametros.dmlTCMayorista);
                    gvListaPrecioDetalle.SetRowCellValue(e.RowHandle, gvListaPrecioDetalle.Columns["PrecioABSoles"], decPrecioABSoles);

                    //Calcular Precio CD Soles
                    decPrecioCDSoles = decPrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista);
                    gvListaPrecioDetalle.SetRowCellValue(e.RowHandle, gvListaPrecioDetalle.Columns["PrecioCDSoles"], decPrecioCDSoles);
                }
            }
            */

            //whit New Modification
            decimal decPrecioAB = 0;
            decimal decPrecioCD = 0;
            decimal decPrecioABSoles = 0;
            decimal decPrecioCDSoles = 0;

            if (e.Column.Caption == "Precio CD US$")
            {
                if (decimal.Parse(e.Value.ToString()) > 0)
                {
                    decPrecioCD = Math.Round(   decimal.Parse(Convert.ToString(String.Format("{0:#,##0.000}", e.Value.ToString()))),3);
                    //Calcular Precio CD
                    decPrecioAB = decPrecioCD;// *Convert.ToDecimal(1.15);
                    gvListaPrecioDetalle.SetRowCellValue(e.RowHandle, gvListaPrecioDetalle.Columns["PrecioAB"], decPrecioAB);

                    //Calcular Precio AB Soles
                    decPrecioABSoles = decPrecioAB * Convert.ToDecimal(Parametros.dmlTCMayorista);
                    gvListaPrecioDetalle.SetRowCellValue(e.RowHandle, gvListaPrecioDetalle.Columns["PrecioABSoles"], decPrecioABSoles);

                    //Calcular Precio CD Soles
                    decPrecioCDSoles = Math.Round(decPrecioCD * Convert.ToDecimal(Parametros.dmlTCMinorista),2);
                    gvListaPrecioDetalle.SetRowCellValue(e.RowHandle, gvListaPrecioDetalle.Columns["PrecioCDSoles"], decPrecioCDSoles);
                }
            }

            
        }

        private void gcTxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string CodigoProveedor = (sender as TextEdit).Text;
                    ProductoBE objE_Producto = new ProductoBE();
                    objE_Producto = new ProductoBL().Selecciona(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue), CodigoProveedor);
                    if (objE_Producto == null)
                    {
                        XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int index = gvListaPrecioDetalle.FocusedRowHandle;
                        gvListaPrecioDetalle.SetRowCellValue(index, "IdProducto", objE_Producto.IdProducto);
                        gvListaPrecioDetalle.SetRowCellValue(index, "CodigoProveedor", objE_Producto.CodigoProveedor);
                        gvListaPrecioDetalle.SetRowCellValue(index, "NombreProducto", objE_Producto.NombreProducto);
                        gvListaPrecioDetalle.SetRowCellValue(index, "Abreviatura", objE_Producto.Abreviatura);
                        gvListaPrecioDetalle.SetRowCellValue(index, "Descuento", 0);
                        gvListaPrecioDetalle.SetRowCellValue(index, "PrecioAB", 0);
                        gvListaPrecioDetalle.SetRowCellValue(index, "PrecioCD", 0);
                        gvListaPrecioDetalle.SetRowCellValue(index, "PrecioABSoles", 0);
                        gvListaPrecioDetalle.SetRowCellValue(index, "PrecioCDSoles", 0);

                        gvListaPrecioDetalle.FocusedRowHandle = index;
                        gvListaPrecioDetalle.FocusedColumn = gvListaPrecioDetalle.GetVisibleColumn(4);
                        gvListaPrecioDetalle.ShowEditor();
                    }
                }

                if (e.KeyCode == Keys.F1)
                {
                    frmBusProducto objBusProducto = new frmBusProducto();
                    objBusProducto.ShowDialog();
                    if (objBusProducto.pProductoBE != null)
                    {
                        int index = gvListaPrecioDetalle.FocusedRowHandle;
                        gvListaPrecioDetalle.SetRowCellValue(index, "IdProducto", objBusProducto.pProductoBE.IdProducto);
                        gvListaPrecioDetalle.SetRowCellValue(index, "CodigoProveedor", objBusProducto.pProductoBE.CodigoProveedor);
                        gvListaPrecioDetalle.SetRowCellValue(index, "NombreProducto", objBusProducto.pProductoBE.NombreProducto);
                        gvListaPrecioDetalle.SetRowCellValue(index, "Abreviatura", objBusProducto.pProductoBE.Abreviatura);
                        gvListaPrecioDetalle.SetRowCellValue(index, "Descuento", 0);
                        gvListaPrecioDetalle.SetRowCellValue(index, "PrecioAB", 0);
                        gvListaPrecioDetalle.SetRowCellValue(index, "PrecioCD", 0);
                        gvListaPrecioDetalle.SetRowCellValue(index, "PrecioABSoles", 0);
                        gvListaPrecioDetalle.SetRowCellValue(index, "PrecioCDSoles", 0);

                        gvListaPrecioDetalle.FocusedRowHandle = index;
                        gvListaPrecioDetalle.FocusedColumn = gvListaPrecioDetalle.GetVisibleColumn(4);
                        gvListaPrecioDetalle.ShowEditor();
                    }
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
                gvListaPrecioDetalle.AddNewRow();
                gvListaPrecioDetalle.SetRowCellValue(gvListaPrecioDetalle.FocusedRowHandle, "Item", (mListaPrecioDetalleOrigen.Count - 1) + 1);
                if (pOperacion == Operacion.Modificar)
                    gvListaPrecioDetalle.SetRowCellValue(gvListaPrecioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                else
                    gvListaPrecioDetalle.SetRowCellValue(gvListaPrecioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                gvListaPrecioDetalle.FocusedColumn = gvListaPrecioDetalle.GetVisibleColumn(1);
                gvListaPrecioDetalle.ShowEditor();

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
                int IdListaPrecioDetalle = 0;
                IdListaPrecioDetalle = int.Parse(gvListaPrecioDetalle.GetFocusedRowCellValue("IdListaPrecioDetalle").ToString());
                int Item = 0;
                Item = int.Parse(gvListaPrecioDetalle.GetFocusedRowCellValue("Item").ToString());
                ListaPrecioDetalleBE objBE_ListaPrecioDetalle = new ListaPrecioDetalleBE();
                objBE_ListaPrecioDetalle.IdListaPrecioDetalle = IdListaPrecioDetalle;
                objBE_ListaPrecioDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_ListaPrecioDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_ListaPrecioDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ListaPrecioDetalleBL objBL_ListaPrecioDetalle = new ListaPrecioDetalleBL();
                objBL_ListaPrecioDetalle.Elimina(objBE_ListaPrecioDetalle);
                gvListaPrecioDetalle.DeleteRow(gvListaPrecioDetalle.FocusedRowHandle);
                gvListaPrecioDetalle.RefreshData();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarlistapreciotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "nillanes" || frmAutoriza.Usuario == "jsanchez" 
                        || Parametros.intPerfilId == Parametros.intPerAsistenteCompras || frmAutoriza.Usuario == "rtapia" 
                        || Parametros.intPerfilId == Parametros.intPerAdministrador || frmAutoriza.Usuario == "ylalupu" 
                        || frmAutoriza.IdPerfil == Parametros.intPerCoordinacionFacturacion || frmAutoriza.Usuario == "evaldez"
                        || Parametros.intPerfilId == Parametros.intPerJefeProduccion
                        || frmAutoriza.IdPerfil == Parametros.intPerSupervisorDiseno || frmAutoriza.Usuario == "jlquispe"
                        || Parametros.intPerfilId == Parametros.intPerSupervisorDiseno)
                    {
                        frmManActualizaListaPrecioEdit objManListaPrecio = new frmManActualizaListaPrecioEdit();
                        objManListaPrecio.IdListaPrecio = IdListaPrecio;
                        objManListaPrecio.DescListaPrecio = txtDescripcion.Text;
                        objManListaPrecio.StartPosition = FormStartPosition.CenterParent;
                        objManListaPrecio.ShowDialog();
                    }
                    else
                    {
                        XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


                //frmManActualizaListaPrecioEdit objManListaPrecio = new frmManActualizaListaPrecioEdit();
                //objManListaPrecio.IdListaPrecio = IdListaPrecio;
                //objManListaPrecio.DescListaPrecio = txtDescripcion.Text;
                //objManListaPrecio.StartPosition = FormStartPosition.CenterParent;
                //objManListaPrecio.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aplicardescuentostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManActualizaDescuentoEdit objManDescuento = new frmManActualizaDescuentoEdit();
                objManDescuento.IdListaPrecio = IdListaPrecio;
                objManDescuento.DescListaPrecio = txtDescripcion.Text;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importardescuentoshangtagtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManImportarDescuentosHangTag objManDescuento = new frmManImportarDescuentosHangTag();
                objManDescuento.IdListaPrecio = IdListaPrecio;
                objManDescuento.DescListaPrecio = txtDescripcion.Text;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void importardescuentostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManImportarDescuentosEdit objManDescuento = new frmManImportarDescuentosEdit();
                objManDescuento.IdListaPrecio = IdListaPrecio;
                objManDescuento.DescListaPrecio = txtDescripcion.Text;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text.ToString().Trim().Length > 2)
            {
                CargarBusqueda();
            }

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaPrimero;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            cboPagina.EditValue = intPagina;

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            intPagina = intPagina - 1;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPagina = intPagina + 1;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaUltima;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            intPagina = int.Parse(cboPagina.EditValue.ToString());
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
            CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidadRegistros.Text.Length > 0)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            }
        }

        private void gvListaPrecioDetalle_MouseDown(object sender, MouseEventArgs e)
        {
            StartRowHandle = GetRowAt(sender as GridView, e.X, e.Y);
        }

        private void gvListaPrecioDetalle_MouseMove(object sender, MouseEventArgs e)
        {
            int newRowHandle = GetRowAt(sender as GridView, e.X, e.Y);
            if (CurrentRowHandle != newRowHandle)
            {
                CurrentRowHandle = newRowHandle;
                SelectRows(sender as GridView, StartRowHandle, CurrentRowHandle);
            }
        }

        private void gvListaPrecioDetalle_MouseUp(object sender, MouseEventArgs e)
        {
            StartRowHandle = -1;
            CurrentRowHandle = -1;

        }

        private void establecerdescuentostoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstablecerDescuento objDescuento = new frmEstablecerDescuento();
            objDescuento.StartPosition = FormStartPosition.CenterParent;
            if (objDescuento.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < gvListaPrecioDetalle.SelectedRowsCount; i++)
                {
                    int row = gvListaPrecioDetalle.GetSelectedRows()[i];
                    gvListaPrecioDetalle.SetRowCellValue(row, "Descuento", objDescuento.Descuento);
                }
            }

            gvListaPrecioDetalle.RefreshData();
        }

        private void importarautoserviciotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManImportarAutoservicioEdit objManDescuento = new frmManImportarAutoservicioEdit();
                objManDescuento.IdListaPrecio = IdListaPrecio;
                objManDescuento.DescListaPrecio = txtDescripcion.Text;
                objManDescuento.bHantag = false;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();
                if (objManDescuento.DialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importarautoserviciohangtagtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManImportarAutoservicioEdit objManDescuento = new frmManImportarAutoservicioEdit();
                objManDescuento.IdListaPrecio = IdListaPrecio;
                objManDescuento.DescListaPrecio = txtDescripcion.Text;
                objManDescuento.bHantag = true;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();
                if (objManDescuento.DialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deshabilitardescuentosmayoristastoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" /*|| Parametros.intPerfilId == Parametros.intPerAdministrador*/)
                {
                    ListaPrecioDetalleBL objListaPrecioDetalle = new ListaPrecioDetalleBL();
                    objListaPrecioDetalle.ActualizaDescuentoMayorista();

                    XtraMessageBox.Show("Los descuentos fueron deshabilitados correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Solamente los administradores del modulo tienen acceso a esta opción", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        #endregion

        #region "Metodos"

        private bool ValidarSalida()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboEmpresa.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una empresa.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboTienda.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una tienda.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción de la lista de precio.\n";
                flag = true;
            }

            foreach (CListaPrecioDetalle item in mListaPrecioDetalleOrigen)
            {
                var BuscarCodigo = mListaPrecioDetalleOrigen.Where(oB => oB.CodigoProveedor.ToUpper() == item.CodigoProveedor.ToUpper()).ToList();
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

        private void CargarBusqueda(int pagina, int registros)
        {
            List<ListaPrecioDetalleBE> lstListaPrecioDetalle = null;
            lstListaPrecioDetalle = new ListaPrecioDetalleBL().ListaBusqueda(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue), IdListaPrecio, txtProducto.Text, pagina, registros);

            mListaPrecioDetalleOrigen.Clear();

            foreach (ListaPrecioDetalleBE item in lstListaPrecioDetalle)
            {
                CListaPrecioDetalle objE_ListaPrecioDetalle = new CListaPrecioDetalle();
                objE_ListaPrecioDetalle.IdEmpresa = item.IdEmpresa;
                objE_ListaPrecioDetalle.IdTienda = item.IdTienda;
                objE_ListaPrecioDetalle.IdListaPrecio = item.IdListaPrecio;
                objE_ListaPrecioDetalle.IdListaPrecioDetalle = item.IdListaPrecioDetalle;
                objE_ListaPrecioDetalle.IdProducto = item.IdProducto;
                objE_ListaPrecioDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_ListaPrecioDetalle.NombreProducto = item.NombreProducto;
                objE_ListaPrecioDetalle.Abreviatura = item.Abreviatura;
                objE_ListaPrecioDetalle.Descuento = item.Descuento;
                objE_ListaPrecioDetalle.DescuentoOutlet = item.DescuentoOutlet;
                objE_ListaPrecioDetalle.PrecioAB = item.PrecioAB;
                objE_ListaPrecioDetalle.PrecioCD = item.PrecioCD;
                objE_ListaPrecioDetalle.PrecioABSoles = item.PrecioABSoles;
                objE_ListaPrecioDetalle.PrecioCDSoles = item.PrecioCDSoles;
                objE_ListaPrecioDetalle.TipoCambioCD = item.TipoCambioCD;
                objE_ListaPrecioDetalle.FlagAutoservicio = item.FlagAutoservicio;
                objE_ListaPrecioDetalle.FlagEstado = item.FlagEstado;
                objE_ListaPrecioDetalle.TipoOper = item.TipoOper;
                mListaPrecioDetalleOrigen.Add(objE_ListaPrecioDetalle);
            }

            bsListado.DataSource = mListaPrecioDetalleOrigen;
            gcListaPrecioDetalle.DataSource = bsListado;
            gcListaPrecioDetalle.RefreshDataSource();
        }

        private void CargarBusqueda()
        {
            List<ListaPrecioDetalleBE> lstListaPrecioDetalle = null;
            lstListaPrecioDetalle = new ListaPrecioDetalleBL().ListaBusqueda(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue), IdListaPrecio, txtProducto.Text, intPaginaPrimero, intRegistrosPorPagina);

            mListaPrecioDetalleOrigen.Clear();

            foreach (ListaPrecioDetalleBE item in lstListaPrecioDetalle)
            {
                CListaPrecioDetalle objE_ListaPrecioDetalle = new CListaPrecioDetalle();
                objE_ListaPrecioDetalle.IdEmpresa = item.IdEmpresa;
                objE_ListaPrecioDetalle.IdTienda = item.IdTienda;
                objE_ListaPrecioDetalle.IdListaPrecio = item.IdListaPrecio;
                objE_ListaPrecioDetalle.IdListaPrecioDetalle = item.IdListaPrecioDetalle;
                objE_ListaPrecioDetalle.IdProducto = item.IdProducto;
                objE_ListaPrecioDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_ListaPrecioDetalle.NombreProducto = item.NombreProducto;
                objE_ListaPrecioDetalle.Abreviatura = item.Abreviatura;
                objE_ListaPrecioDetalle.Descuento = item.Descuento;
                objE_ListaPrecioDetalle.PrecioAB = item.PrecioAB;
                objE_ListaPrecioDetalle.PrecioCD = item.PrecioCD;
                objE_ListaPrecioDetalle.PrecioABSoles = item.PrecioABSoles;
                objE_ListaPrecioDetalle.PrecioCDSoles = item.PrecioCDSoles;
                objE_ListaPrecioDetalle.TipoCambioCD = item.TipoCambioCD;
                objE_ListaPrecioDetalle.FlagEstado = item.FlagEstado;
                objE_ListaPrecioDetalle.FlagAutoservicio = item.FlagAutoservicio;
                objE_ListaPrecioDetalle.DescuentoAB = item.DescuentoAB;
                objE_ListaPrecioDetalle.FlagDescuentoAB = item.FlagDescuentoAB;
                objE_ListaPrecioDetalle.DescuentoOutlet = item.DescuentoOutlet;
                objE_ListaPrecioDetalle.TipoOper = item.TipoOper;
                mListaPrecioDetalleOrigen.Add(objE_ListaPrecioDetalle);
            }

            bsListado.DataSource = mListaPrecioDetalleOrigen;
            gcListaPrecioDetalle.DataSource = bsListado;
            gcListaPrecioDetalle.RefreshDataSource();

            CalcularPaginas();
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);

        }

        private void CalcularPaginas()
        {
            cboPagina.Properties.Items.Clear();
            intRegistrosTotal = CantidadRegistros();
            if (intRegistrosTotal > 0)
            {
                intPaginaUltima = intRegistrosTotal / intRegistrosPorPagina;
                int Residuo = intRegistrosTotal % intRegistrosPorPagina;
                if (Residuo > 0)
                    intPaginaUltima += 1;
                for (int i = 0; i < intPaginaUltima; i++)
                {
                    cboPagina.Properties.Items.Add(i + 1);
                }
                cboPagina.SelectedIndex = 0;
            }
        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            btnFirst.Enabled = bolFirst;
            btnPrevious.Enabled = bolPrevious;
            btnNext.Enabled = bolNext;
            btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            intRowCount = new ListaPrecioDetalleBL().ListaBusquedaCount(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue), IdListaPrecio, txtProducto.Text);
            return intRowCount;
        }

        private void SelectRows(GridView view, int startRow, int endRow)
        {
            if (startRow > -1 && endRow > -1)
            {
                view.BeginSelection();
                view.ClearSelection();
                view.SelectRange(startRow, endRow);
                view.EndSelection();
            }
        }

        private int GetRowAt(GridView view, int x, int y)
        {
            return view.CalcHitInfo(new Point(x, y)).RowHandle;
        }

        private void FiltroMenuContextual()
        {
            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "rtapia" 
                || Parametros.strUsuarioLogin == "etapia" || Parametros.intPerfilId == Parametros.intPerAdministrador
                || Parametros.intPerfilId == Parametros.intPerCoordinacionFacturacion || Parametros.intPerfilId == Parametros.intPerAsistenteCompras 
                || Parametros.intPerfilId == Parametros.intPerJefeProduccion || Parametros.strUsuarioLogin == "jlquispe" || Parametros.intPerfilId == Parametros.intPerSupervisorDiseno )
            {
                nuevoToolStripMenuItem.Visible = true;
                eliminarToolStripMenuItem.Visible = true;
                actualizarlistapreciotoolStripMenuItem.Visible = true;
            }
            else
            {
                nuevoToolStripMenuItem.Visible = false;
                eliminarToolStripMenuItem.Visible = false;
                actualizarlistapreciotoolStripMenuItem.Visible = false;
            }
        }

        private void BloquearAccesoPorPerfil()
        {
            UsuarioBE ObjE_Usuario = null;
            ObjE_Usuario = new UsuarioBL().Selecciona(Parametros.intUsuarioId);

            if (ObjE_Usuario != null)
            {
                if (ObjE_Usuario.IdPerfil == 12 )
                {
                    gvListaPrecioDetalle.Columns["Descuento"].OptionsColumn.AllowEdit = false;
                    gvListaPrecioDetalle.Columns["Descuento"].OptionsColumn.AllowFocus = false;

                    gvListaPrecioDetalle.Columns["PrecioAB"].OptionsColumn.AllowEdit = false;
                    gvListaPrecioDetalle.Columns["PrecioAB"].OptionsColumn.AllowFocus = false;

                    gvListaPrecioDetalle.Columns["PrecioCD"].OptionsColumn.AllowEdit = false;
                    gvListaPrecioDetalle.Columns["PrecioCD"].OptionsColumn.AllowFocus = false;


                    //Bloquear Menu Contextual
                    actualizarlistapreciotoolStripMenuItem.Visible = false;
                    aplicardescuentostoolStripMenuItem.Visible = false;
                    importardescuentostoolStripMenuItem.Visible = false;
                    establecerdescuentostoolStripMenuItem.Visible = false;
                    importardescuentoshangtagtoolStripMenuItem.Visible = false;
                    deshabilitardescuentosmayoristastoolStripMenuItem1.Visible = false;
                }
            }
        }

        #endregion

        public class CListaPrecioDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdTienda { get; set; }
            public Int32 IdListaPrecio { get; set; }
            public Int32 IdListaPrecioDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioAB { get; set; }
            public Decimal PrecioCD { get; set; }
            public Decimal PrecioABSoles { get; set; }
            public Decimal PrecioCDSoles { get; set; }
            public Decimal TipoCambioCD { get; set; }
            public Boolean FlagAutoservicio { get; set; }
            public Decimal DescuentoAB { get; set; }
            public Decimal DescuentoOutlet { get; set; }
            public Boolean FlagDescuentoAB { get; set; }
            public Boolean FlagEstado { get; set; }
            public Int32 TipoOper { get; set; }

            public CListaPrecioDetalle()
            {

            }
        }

        private void importardescuentooutlettoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManImportarDescuentosEdit objManDescuento = new frmManImportarDescuentosEdit();
                objManDescuento.IdListaPrecio = IdListaPrecio;
                objManDescuento.DescListaPrecio = txtDescripcion.Text;
                objManDescuento.StartPosition = FormStartPosition.CenterParent;
                objManDescuento.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}