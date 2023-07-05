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
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegInventarioAgregar : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<InventarioBE> mLista = new List<InventarioBE>();
        private List<InventarioBE> lst_InventarioMsg = new List<InventarioBE>();
        public bool bHangTag = false;
        public int IdTienda { get; set; }
        public int IdAlmacen { get; set; }

        public int IdPersonaApoyo = 0;
        public string DescPersonaApoyo = "";
        private bool bGrabar = true;

        #endregion

        #region "Eventos"


        public frmRegInventarioAgregar()
        {
            InitializeComponent();
        }

        private void frmRegInventarioAgregar_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = IdTienda;
            //BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, IdTienda), "DescAlmacen", "IdAlmacen", true);
            //cboAlmacen.EditValue = IdAlmacen;

            chkHangTag.Checked = bHangTag;
            txtPersonaApoyo.EditValue = DescPersonaApoyo;
            txtPersona.EditValue = Parametros.strUsuarioNombres;

            CargaDocumentoVentaDetalle();

            btnNuevo.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void tsmMenuSelText_Click(object sender, EventArgs e)
        {

        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            try
            {
                if (gvInventario.RowCount > 0)
                {
                    Cursor = Cursors.AppStarting;

                    #region "Exportar"
                    
                    string windowsTempPath = Path.GetTempPath();
                    //string randomFileName = Path.GetRandomFileName();//Puede Coincidir el nombre
                    //string tempFile = Path.GetTempFileName();//El archivo no existe en el sistema

                    string _msg = "Se generó una copia del archivo excel de forma automática en la siguiente ubicación.\n{0}";
                    string _fileName = "Inventario_" + "_" + cboAlmacen.Text + "_" + Parametros.strUsuarioLogin + "_" + DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss");
                    
                    gvInventario.ExportToXls(windowsTempPath + @"\" + _fileName + ".xls");
                    string _nM = string.Format(_msg, windowsTempPath + @"\" + _fileName + ".xls");
                    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #endregion

                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                if (gvInventario.RowCount > 0)
                {
                    //InventarioBL objBL_Inventario = new InventarioBL();

                    //List<InventarioBE> lstInventario = null;
                    //lstInventario = new List<InventarioBE>();

                    foreach (var item in mLista)
                    {
                        InventarioBL objBL_Inventario = new InventarioBL();
                        InventarioBE objE_Inventario = new InventarioBE();
                        objE_Inventario.IdInventario = 0;
                        objE_Inventario.IdProducto = item.IdProducto;
                        objE_Inventario.IdEmpresa = Parametros.intEmpresaId;
                        objE_Inventario.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                        objE_Inventario.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                        objE_Inventario.IdAlmacenPiso = Convert.ToInt32(cboAlmacenPiso.EditValue);
                        objE_Inventario.CodigoProveedor = item.CodigoProveedor;
                        objE_Inventario.NombreProducto = item.NombreProducto;
                        objE_Inventario.Abreviatura = item.Abreviatura;
                        objE_Inventario.Cantidad = item.Cantidad;
                        objE_Inventario.Ubicacion = item.Ubicacion;
                        objE_Inventario.IdPersona = Parametros.intPersonaId;
                        objE_Inventario.IdPersona2 = IdPersonaApoyo;
                        objE_Inventario.Observacion = item.Observacion;
                        objE_Inventario.Fecha = DateTime.Now;
                        objE_Inventario.FlagEstado = true;
                        objBL_Inventario.Inserta(objE_Inventario);
                        //lstInventario.Add(objE_Inventario);
                    }
                    //objInventario.Usuario = Parametros.strUsuarioLogin;
                    //objInventario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    XtraMessageBox.Show("Datos guardados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    bGrabar = false;
                }

                this.Close();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.modificarprecioToolStripMenuItem_Click(sender, e);
        }



        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboAlmacen.EditValue) == 0)
                {
                    XtraMessageBox.Show("Seleccionar Almacén", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }



                frmRegInventarioAgregarEdit movDetalle = new frmRegInventarioAgregarEdit();
                movDetalle.pOperacion = frmRegInventarioAgregarEdit.Operacion.Nuevo;
                movDetalle.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                movDetalle.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                movDetalle.HangTag = chkHangTag.Checked;
                movDetalle.FlagUbicacion = chkUbicacion.Checked;
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mLista.Count == 0)
                        {
                            gvInventario.AddNewRow();
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdInventario", 0);
                            //gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdAlmacen", movDetalle.oBE.IdAlmacen);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Ubicacion", movDetalle.oBE.Ubicacion);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Fecha", movDetalle.oBE.Fecha);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "FlagEstado", movDetalle.oBE.FlagEstado);
                            //gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvInventario.UpdateCurrentRow();

                            //bNuevo = movDetalle.bNuevo;


                            CalcularCantidadTotal();

                            btnNuevo.Focus();

                            return;

                        }
                        if (mLista.Count > 0)
                        {
                            //var Buscar = mLista.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            //if (Buscar.Count > 0)
                            //{
                            //    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            gvInventario.AddNewRow();
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdInventario", 0);
                            //gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdAlmacen", movDetalle.oBE.IdAlmacen);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Ubicacion", movDetalle.oBE.Ubicacion);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Fecha", movDetalle.oBE.Fecha);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "FlagEstado", movDetalle.oBE.FlagEstado);
                            //gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvInventario.UpdateCurrentRow();

                            //bNuevo = movDetalle.bNuevo;


                            CalcularCantidadTotal();

                            btnNuevo.Focus();

                            return;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            /*try
            {
                if (cboAlmacen.Text == "")
                {
                    XtraMessageBox.Show("Seleccione un Almacén.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmRegInventarioEdit objInventario = new frmRegInventarioEdit();
                objInventario.pOperacion = frmRegInventarioEdit.Operacion.Nuevo;
                objInventario.IdInventario = 0;
                objInventario.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objInventario.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                objInventario.HangTag = bHangTag;
                objInventario.StartPosition = FormStartPosition.CenterParent;
                objInventario.ShowDialog();
                Cargar();

                btnNuevo.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }


        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    gvInventario.DeleteRow(gvInventario.FocusedRowHandle);
                    gvInventario.RefreshData();
                    CalcularCantidadTotal();
                    XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        #endregion

        #region "Metodos"

        //private void Cargar()
        //{
        //    mLista = new InventarioBL().ListaTodosActivoUsuario(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboAlmacen.EditValue),Parametros.intPersonaId);
        //    gcInventario.DataSource = mLista;

        //    CalcularCantidadTotal();
        //}

        private void CargarTodo()
        {
            mLista = new InventarioBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue));
            gcInventario.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
           // gcInventario.DataSource = mLista.Where(obj =>
             //                                      obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvInventario.GetFocusedRowCellValue("IdInventario").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Inventario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        public void InicializarModificar()
        {

            if (mLista.Count > 0)
            {
                int xposition = 0;

                frmRegInventarioAgregarEdit movDetalle = new frmRegInventarioAgregarEdit();
                movDetalle.pOperacion = frmRegInventarioAgregarEdit.Operacion.Modificar;
                movDetalle.IdProducto = Convert.ToInt32(gvInventario.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvInventario.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvInventario.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvInventario.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvInventario.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtUbicacion.EditValue = gvInventario.GetFocusedRowCellValue("Ubicacion");
                movDetalle.txtObservacion.EditValue = gvInventario.GetFocusedRowCellValue("Observacion");
                movDetalle.cboTienda.EditValue = cboTienda.EditValue;
                movDetalle.cboAlmacen.EditValue = cboTienda.EditValue;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvInventario.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdInventario", 0);
                        //gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdTienda", movDetalle.oBE.IdTienda);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdAlmacen", movDetalle.oBE.IdAlmacen);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Ubicacion", movDetalle.oBE.Ubicacion);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Fecha", movDetalle.oBE.Fecha);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "FlagEstado", movDetalle.oBE.FlagEstado);
                        //gvInventario.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvInventario.UpdateCurrentRow();

                        //bNuevo = movDetalle.bNuevo;

                        CalcularCantidadTotal();

                        btnNuevo.Focus();
                    }
                }
            }




            /*if (gvInventario.RowCount > 0)
            {
                InventarioBE objInventario = new InventarioBE();
                objInventario.IdInventario = int.Parse(gvInventario.GetFocusedRowCellValue("IdInventario").ToString());

                frmRegInventarioEdit objManInventarioEdit = new frmRegInventarioEdit();
                objManInventarioEdit.pOperacion = frmRegInventarioEdit.Operacion.Modificar;
                objManInventarioEdit.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objManInventarioEdit.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                objManInventarioEdit.IdInventario = objInventario.IdInventario;
                objManInventarioEdit.StartPosition = FormStartPosition.CenterParent;
                objManInventarioEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }*/
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private void CalcularCantidadTotal()
        {
            try
            {
                int decTotal = 0;

                for (int i = 0; i < gvInventario.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToInt32(gvInventario.GetRowCellValue(i, (gvInventario.Columns["Cantidad"])));
                    lblRegistros.Text = gvInventario.RowCount.ToString() + " Registros encontrados";
                }
                txtTotal.EditValue = decTotal;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class CDocumentoVentaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdDocumentoVenta { get; set; }
            public Int32 IdDocumentoVentaDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public Int32 IdKardex { get; set; }
            public Boolean FlagMuestra { get; set; }
            public Boolean FlagRegalo { get; set; }
            public Int32 Stock { get; set; }
            public Decimal PorcentajeDescuentoInicial { get; set; }
            public Int32 IdLineaProducto { get; set; }
            public Int32 TipoOper { get; set; }

            public CDocumentoVentaDetalle()
            {

            }
        }

        private void CargaDocumentoVentaDetalle()
        {
            bsListado.DataSource = mLista;
            gcInventario.DataSource = bsListado;
            gcInventario.RefreshDataSource();
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
                    int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim());
                    string Ubicacion = (string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim();
                    string Observacion = (string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim();

                    //ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedorInventario(CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        gvInventario.AddNewRow();
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdInventario", 0);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Cantidad", Cantidad);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Ubicacion", Ubicacion);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Observacion", Observacion);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Fecha", DateTime.Now);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "FlagEstado", true);
                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        InventarioBE ObjE_Inventario = new InventarioBE();
                        ObjE_Inventario.CodigoProveedor = CodigoProveedor;
                        ObjE_Inventario.Cantidad = Cantidad;
                        ObjE_Inventario.Ubicacion = Ubicacion;
                        ObjE_Inventario.Observacion = Observacion;
                        lst_InventarioMsg.Add(ObjE_Inventario);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }


                lblRegistros.Text = gvInventario.RowCount.ToString() + " Registros";
                if (lst_InventarioMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_InventarioMsg;
                    frm.ShowDialog();
                }

                //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void ImportarExcelHangTag(string filename)
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

                    string IdProducto = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim());
                    string Ubicacion = (string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim();
                    string Observacion = (string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim();

                    //ProductoBE objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(IdProducto);
                    string TipoMessage = "";

                    ProductoBE objE_Producto = null; //ADD
                    if (IdProducto.ToString().Count() > 6)
                    {
                        objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(IdProducto.ToString()); //Codigo de Barras de Importación
                        TipoMessage = "HangTag";
                    }
                    else
                    {
                        objE_Producto = new ProductoBL().SeleccionaIdProductoInventario(Convert.ToInt32(IdProducto));
                        TipoMessage = "CodigoBarra";
                    }

                    if (objE_Producto != null)
                    {
                        gvInventario.AddNewRow();
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdInventario", 0);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Cantidad", Cantidad);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Ubicacion", Ubicacion);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Observacion", Observacion);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "Fecha", DateTime.Now);
                        gvInventario.SetRowCellValue(gvInventario.FocusedRowHandle, "FlagEstado", true);
                    }
                    else
                    {
                        //XtraMessageBox.Show("El código de " + TipoMessage +": "+ IdProducto + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        InventarioBE ObjE_Inventario = new InventarioBE();
                        ObjE_Inventario.CodigoProveedor = IdProducto;
                        ObjE_Inventario.Cantidad = Cantidad;
                        ObjE_Inventario.Ubicacion = Ubicacion;
                        ObjE_Inventario.Observacion = Observacion;
                        lst_InventarioMsg.Add(ObjE_Inventario);
                    }


                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                lblRegistros.Text = gvInventario.RowCount.ToString() + " Registros";
                if (lst_InventarioMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_InventarioMsg;
                    frm.ShowDialog();
                }
                //XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        #endregion

        private void gcInventario_Click(object sender, EventArgs e)
        {

        }

        private void gvInventario_DoubleClick(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void frmRegInventarioAgregar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bGrabar)
            {
                if (gvInventario.RowCount > 0)
                {
                    if (XtraMessageBox.Show("Desea guardar esta lista?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnGrabar_Click(sender, e);

                        //// Cancel the Closing event from closing the form.
                        //e.Cancel = true;
                        //// Call method to save file...
                    }
                }
            }
        }

        private void frmRegInventarioAgregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            //btnGrabar_Click(sender, e);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se generó el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            //string _fileName = "ListadoInventario_" + "_" + cboAlmacen.Text + "_" + Parametros.strUsuarioLogin;
            string _fileName = "Inventario_" + "_" + cboAlmacen.Text + "_" + Parametros.strUsuarioLogin + "_" + DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss");
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventario.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void ImportartoolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ImportarporHangTagtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcelHangTag(_file_excel);
                //Cargar();
            }

        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                cboAlmacen.EditValue = 0;
            }
        }

        private void cboAlmacen_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboAlmacenPiso, new AlmacenPisoBL().ListaTodosActivo(Convert.ToInt32(cboAlmacen.EditValue)), "DescAlmacenPiso", "IdAlmacenPiso", true);

            if (Convert.ToInt32(cboAlmacen.EditValue) == Parametros.intAlmCentralUcayali || Convert.ToInt32(cboAlmacen.EditValue) == Parametros.intAlmAnaqueles || Convert.ToInt32(cboAlmacen.EditValue) == Parametros.intAlmBultos)
            {
                chkUbicacion.Checked = true;
                //cboNivel.Visible = false;
            }
            else
            {
                chkUbicacion.Checked = false;
                //cboNivel.Visible = true;
                
            }
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaPersona frm = new frmBuscaPersona();
                frm.TipoBusqueda = 0;
                //frm.Title = "Búsqueda de Persona sin Usuario";
                frm.ShowDialog();
                if (frm._Be != null)
                {
                    IdPersonaApoyo = frm._Be.IdPersona;
                    txtPersonaApoyo.Text = frm._Be.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}