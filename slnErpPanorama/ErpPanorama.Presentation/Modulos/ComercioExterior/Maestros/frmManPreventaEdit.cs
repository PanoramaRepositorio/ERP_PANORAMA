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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;
//using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros
{
    public partial class frmManPreventaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CPreventaDetalle> mListaPreventaDetalleOrigen = new List<CPreventaDetalle>();
        private List<PreventaDetalleBE> lst_PreventaDetalleMsg = new List<PreventaDetalleBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdPreventa = 0;

        public int IdPreventa
        {
            get { return _IdPreventa; }
            set { _IdPreventa = value; }
        }

        public PreventaBE pPreventaBE { get; set; }

        public Operacion pOperacion;

        #endregion

        #region "Eventos"

        public frmManPreventaEdit()
        {
            InitializeComponent();
        }

        private void frmManPreventaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Preventa - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Preventa - Modificar";

                IdPreventa = pPreventaBE.IdPreventa;
                txtDescPreventa.Text = pPreventaBE.DescPreventa;
                deDesde.EditValue = pPreventaBE.FechaInicio;
                deHasta.EditValue = pPreventaBE.FechaFin;
                txtObservacion.Text = pPreventaBE.Observacion;
            }

            CargaPreventaDetalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescPreventa.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el nombre del Preventa promocional.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmManPreventaDetalleEdit movDetalle = new frmManPreventaDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaPreventaDetalleOrigen.Count == 0)
                        {
                            gvPreventaDetalle.AddNewRow();
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdPreventa", movDetalle.oBE.IdPreventa);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdPreventaDetalle", movDetalle.oBE.IdPreventaDetalle);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPreventaDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaPreventaDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaPreventaDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvPreventaDetalle.AddNewRow();
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdPreventa", movDetalle.oBE.IdPreventa);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdPreventaDetalle", movDetalle.oBE.IdPreventaDetalle);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "CantidadVenta", 0);
                            //gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvPreventaDetalle.UpdateCurrentRow();

                            CalculaTotales();

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaPreventaDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManPreventaDetalleEdit movDetalle = new frmManPreventaDetalleEdit();
                movDetalle.IdPreventa = Convert.ToInt32(gvPreventaDetalle.GetFocusedRowCellValue("IdPreventa"));
                movDetalle.IdPreventaDetalle = Convert.ToInt32(gvPreventaDetalle.GetFocusedRowCellValue("IdPreventaDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvPreventaDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvPreventaDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvPreventaDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvPreventaDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvPreventaDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvPreventaDetalle.GetFocusedRowCellValue("Precio"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPreventaDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvPreventaDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvPreventaDetalle.SetRowCellValue(xposition, "IdPreventa", movDetalle.oBE.IdPreventa);
                        gvPreventaDetalle.SetRowCellValue(xposition, "IdPreventaDetalle", movDetalle.oBE.IdPreventaDetalle);
                        gvPreventaDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvPreventaDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvPreventaDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvPreventaDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvPreventaDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        //gvPreventaDetalle.SetRowCellValue(xposition, "CantidadVenta", 0);
                        //gvPreventaDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvPreventaDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvPreventaDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPreventaDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvPreventaDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaPreventaDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvPreventaDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdPreventaDetalle = 0;
                        if (gvPreventaDetalle.GetFocusedRowCellValue("IdPreventaDetalle") != null)
                            IdPreventaDetalle = int.Parse(gvPreventaDetalle.GetFocusedRowCellValue("IdPreventaDetalle").ToString());
                        int Item = 0;
                        if (gvPreventaDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvPreventaDetalle.GetFocusedRowCellValue("Item").ToString());
                        PreventaDetalleBE objBE_PreventaDetalle = new PreventaDetalleBE();
                        objBE_PreventaDetalle.IdPreventaDetalle = IdPreventaDetalle;
                        objBE_PreventaDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_PreventaDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_PreventaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        PreventaDetalleBL objBL_PreventaDetalle = new PreventaDetalleBL();
                        objBL_PreventaDetalle.Elimina(objBE_PreventaDetalle);
                        gvPreventaDetalle.DeleteRow(gvPreventaDetalle.FocusedRowHandle);
                        gvPreventaDetalle.RefreshData();

                    }
                    else
                    {
                        gvPreventaDetalle.DeleteRow(gvPreventaDetalle.FocusedRowHandle);
                        gvPreventaDetalle.RefreshData();
                    }

                    CalculaTotales();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PreventaBL objBL_Preventa = new PreventaBL();
                    PreventaBE objPreventa = new PreventaBE();
                    objPreventa.IdPreventa = IdPreventa;
                    objPreventa.DescPreventa = txtDescPreventa.Text;
                    objPreventa.FechaInicio = Convert.ToDateTime(deDesde.DateTime);
                    objPreventa.FechaFin = Convert.ToDateTime(deHasta.DateTime);
                    //objPreventa.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objPreventa.Observacion = txtObservacion.Text.Trim() ;
                    objPreventa.FlagEstado = true;
                    objPreventa.Usuario = Parametros.strUsuarioLogin;
                    objPreventa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPreventa.IdEmpresa = Parametros.intEmpresaId;

                    //Preventa Detalle
                    List<PreventaDetalleBE> lstPreventaDetalle = new List<PreventaDetalleBE>();

                    foreach (var item in mListaPreventaDetalleOrigen)
                    {
                        PreventaDetalleBE objE_PreventaDetalle = new PreventaDetalleBE();
                        objE_PreventaDetalle.IdPreventa = item.IdPreventa;
                        objE_PreventaDetalle.IdPreventaDetalle = item.IdPreventaDetalle;
                        objE_PreventaDetalle.IdProducto = item.IdProducto;
                        //objE_PreventaDetalle.CodigoProveedor = item.CodigoProveedor;
                        //objE_PreventaDetalle.NombreProducto = item.NombreProducto;
                        //objE_PreventaDetalle.Abreviatura = item.Abreviatura;
                        objE_PreventaDetalle.Cantidad = item.Cantidad;
                        //objE_PreventaDetalle.Precio = item.Precio;
                        objE_PreventaDetalle.FlagEstado = true;
                        objE_PreventaDetalle.TipoOper = item.TipoOper;
                        lstPreventaDetalle.Add(objE_PreventaDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_Preventa.Inserta(objPreventa, lstPreventaDetalle);
                    }
                    else
                    {
                        objBL_Preventa.Actualiza(objPreventa, lstPreventaDetalle);
                    }

                    Cursor = Cursors.Default;

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

        private void CalculaTotales()
        {
            try
            {

                //decimal deValorVenta = 0;
                //decimal deTotal = 0;

                decimal CantidadTotal = 0;
                decimal CantidadVentaTotal = 0;

                if (mListaPreventaDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaPreventaDetalleOrigen)
                    {
                        //deValorVenta = item.Precio;
                        //deTotal = deTotal + deValorVenta;

                        CantidadTotal = CantidadTotal + item.Cantidad;
                        CantidadVentaTotal += item.CantidadVenta;

                    }

                    //txtTotalVenta.EditValue = Math.Round(deTotal, 2);
                    txtTotalCantidad.EditValue = Math.Round(CantidadTotal, 2);
                    txtTotalVenta.EditValue = Math.Round(CantidadVentaTotal, 2);

                }
                else
                {
                    txtTotalCantidad.EditValue = 0;
                    txtTotalVenta.EditValue = 0;
                }

                lblTotalRegistros.Text = mListaPreventaDetalleOrigen.Count.ToString() + " Registros encontrados";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaPreventaDetalle()
        {
            List<PreventaDetalleBE> lstTmpPreventaDetalle = null;
            lstTmpPreventaDetalle = new PreventaDetalleBL().ListaTodosActivo(IdPreventa);

            foreach (PreventaDetalleBE item in lstTmpPreventaDetalle)
            {
                CPreventaDetalle objE_PreventaDetalle = new CPreventaDetalle();
                objE_PreventaDetalle.IdPreventa = item.IdPreventa;
                objE_PreventaDetalle.IdPreventaDetalle = item.IdPreventaDetalle;
                objE_PreventaDetalle.IdProducto = item.IdProducto;
                objE_PreventaDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PreventaDetalle.NombreProducto = item.NombreProducto;
                objE_PreventaDetalle.Abreviatura = item.Abreviatura;
                objE_PreventaDetalle.Cantidad = item.Cantidad;
                objE_PreventaDetalle.CantidadVenta = item.CantidadVenta;
                objE_PreventaDetalle.Diferencia = item.Cantidad - item.CantidadVenta;
                //objE_PreventaDetalle.Precio = item.Precio;
                objE_PreventaDetalle.TipoOper = item.TipoOper;
                mListaPreventaDetalleOrigen.Add(objE_PreventaDetalle);
            }

            bsListado.DataSource = mListaPreventaDetalleOrigen;
            gcPreventaDetalle.DataSource = bsListado;
            gcPreventaDetalle.RefreshDataSource();

            CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescPreventa.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la descripción del Preventa.\n";
                flag = true;
            }

            if (mListaPreventaDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el Preventa, mientra no haya productos.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion

        public class CPreventaDetalle
        {
            public Int32 IdPreventa { get; set; }
            public Int32 IdPreventaDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Int32 CantidadVenta { get; set; }
            public Int32 Diferencia { get; set; }
            //public Decimal Precio { get; set; }
            public Int32 TipoOper { get; set; }

            public CPreventaDetalle()
            {

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

        private void exportartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPrevenaDetalle";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPreventaDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
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
            string MensajeExiste = "";

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


                //Recorremos los códigos de preventa
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string CodigoProveedor = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    int Cantidad = Convert.ToInt32((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    string Ubicacion = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    string Observacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();

                    ProductoBE objE_Producto = new ProductoBL().SeleccionaCodigoProveedor(Parametros.intEmpresaId, CodigoProveedor);
                    if (objE_Producto != null)
                    {
                        //Verifica existencia
                        var Buscar = mListaPreventaDetalleOrigen.Where(oB => oB.IdProducto == objE_Producto.IdProducto).ToList();
                        if (Buscar.Count > 0)
                        {
                            MensajeExiste = objE_Producto.CodigoProveedor;
                            //XtraMessageBox.Show("El código de producto " + objE_Producto.CodigoProveedor + " ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return;
                        }
                        else
                        {
                            gvPreventaDetalle.AddNewRow();
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdEmpresa", Parametros.intEmpresaId);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdPreventaDetalle", 0);
                            //gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdTienda", cboTienda.EditValue);
                            //gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdAlmacen", cboAlmacen.EditValue);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "IdProducto", objE_Producto.IdProducto);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "CodigoProveedor", objE_Producto.CodigoProveedor);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "NombreProducto", objE_Producto.NombreProducto);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Abreviatura", objE_Producto.Abreviatura);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Cantidad", Cantidad);
                            //gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Ubicacion", Ubicacion);
                            //gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Observacion", Observacion);
                            //gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "Fecha", DateTime.Now);
                            gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "FlagEstado", true);
                            if (pOperacion == Operacion.Modificar)
                                gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            else
                                gvPreventaDetalle.SetRowCellValue(gvPreventaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));
                        }
                    }
                    else
                    {

                        //XtraMessageBox.Show("El código " + CodigoProveedor + " No existe, Verificar!.\nSe continuará la importación con los códigos válidos.", this.Text);
                        PreventaDetalleBE ObjE_PreventaDetalle = new PreventaDetalleBE();
                        ObjE_PreventaDetalle.CodigoProveedor = CodigoProveedor;
                        ObjE_PreventaDetalle.Cantidad = Cantidad;
                        lst_PreventaDetalleMsg.Add(ObjE_PreventaDetalle);
                    }

                    lblTotalRegistros.Text = gvPreventaDetalle.RowCount.ToString() + " Registros";
                    prgFactura.PerformStep();
                    prgFactura.Update();

                    Row++;
                }

                if(MensajeExiste.Length>1)
                XtraMessageBox.Show("El código de producto ya existe:\n" + MensajeExiste  , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //lblTotalRegistros.Text = gvPreventaDetalle.RowCount.ToString() + " Registros";
                CalculaTotales();

                if (lst_PreventaDetalleMsg.Count > 0)
                {
                    frmMsgImportacionErronea frm = new frmMsgImportacionErronea();
                    frm.mLista = lst_PreventaDetalleMsg;
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


    }
}