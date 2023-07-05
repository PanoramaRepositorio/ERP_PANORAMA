using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using ErpPanorama.Presentation.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManProductoTransformacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProductoTransformacionBE> mLista = new List<ProductoTransformacionBE>();

        #endregion

        #region "Eventos"

        public frmManProductoTransformacion()
        {
            InitializeComponent();
        }

        private void frmManProductoTransformacion_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManProductoTransformacionEdit objManProductoTransformacion = new frmManProductoTransformacionEdit();
                objManProductoTransformacion.pOperacion = frmManProductoTransformacionEdit.Operacion.Nuevo;
                objManProductoTransformacion.IdProductoTransformacion = 0;
                objManProductoTransformacion.StartPosition = FormStartPosition.CenterParent;
                objManProductoTransformacion.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ProductoTransformacionBE objE_ProductoTransformacion = new ProductoTransformacionBE();
                        objE_ProductoTransformacion.IdProductoTransformacion = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("IdProductoTransformacion").ToString());
                        objE_ProductoTransformacion.Usuario = Parametros.strUsuarioLogin;
                        objE_ProductoTransformacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ProductoTransformacion.IdEmpresa = Parametros.intEmpresaId;

                        ProductoTransformacionBL objBL_ProductoTransformacion = new ProductoTransformacionBL();
                        objBL_ProductoTransformacion.Elimina(objE_ProductoTransformacion);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ErpPanoramaServicios.ReporteProductoTransformacionBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteProductoTransformacion_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptProductoTransformacion = new RptVistaReportes();
            //            objRptProductoTransformacion.VerRptProductoTransformacion(lstReporte);
            //            objRptProductoTransformacion.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoProductoTransformacion";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProductoTransformacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvProductoTransformacion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ProductoTransformacionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcProductoTransformacion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvProductoTransformacion.RowCount > 0)
            {
                ProductoTransformacionBE objProductoTransformacion = new ProductoTransformacionBE();
                objProductoTransformacion.IdProductoTransformacion = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("IdProductoTransformacion").ToString());
                objProductoTransformacion.Codigo = gvProductoTransformacion.GetFocusedRowCellValue("Codigo").ToString();
                objProductoTransformacion.NombreProducto = gvProductoTransformacion.GetFocusedRowCellValue("NombreProducto").ToString();
                objProductoTransformacion.IdUnidadMedida = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("IdUnidadMedida").ToString());
                objProductoTransformacion.Abreviatura = gvProductoTransformacion.GetFocusedRowCellValue("Abreviatura").ToString();
                objProductoTransformacion.Cantidad = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("Cantidad").ToString());
                objProductoTransformacion.Costo = decimal.Parse(gvProductoTransformacion.GetFocusedRowCellValue("Costo").ToString());
                objProductoTransformacion.Margen = decimal.Parse(gvProductoTransformacion.GetFocusedRowCellValue("Margen").ToString());
                objProductoTransformacion.PrecioSoles = decimal.Parse(gvProductoTransformacion.GetFocusedRowCellValue("PrecioSoles").ToString());
                objProductoTransformacion.TipoCambio = decimal.Parse(gvProductoTransformacion.GetFocusedRowCellValue("TipoCambio").ToString());
                objProductoTransformacion.PrecioDolar = decimal.Parse(gvProductoTransformacion.GetFocusedRowCellValue("PrecioDolar").ToString());
                objProductoTransformacion.IdMovimientoAlmacen = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());
                objProductoTransformacion.IdProforma = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("IdProforma").ToString());

                frmManProductoTransformacionEdit objManProductoTransformacionEdit = new frmManProductoTransformacionEdit();
                objManProductoTransformacionEdit.pOperacion = frmManProductoTransformacionEdit.Operacion.Modificar;
                objManProductoTransformacionEdit.IdProductoTransformacion = objProductoTransformacion.IdProductoTransformacion;
                objManProductoTransformacionEdit.pProductoTransformacionBE = objProductoTransformacion;
                objManProductoTransformacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManProductoTransformacionEdit.ShowDialog();

                Cargar();
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

            if (gvProductoTransformacion.GetFocusedRowCellValue("IdProductoTransformacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione ProductoTransformacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

        //private void nuevoProformaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (gvProductoTransformacion.GetFocusedRowCellValue("NumeroProforma").ToString().Length == 0)
        //        {
        //            frmBusProforma movDetalle = new frmBusProforma();
        //            movDetalle.StartPosition = FormStartPosition.CenterParent;
        //            if (movDetalle.ShowDialog() == DialogResult.OK)
        //            {
        //                if (movDetalle.pProformaBE != null)
        //                {
        //                    if (movDetalle.pProformaBE.IdSituacion == Parametros.intPVAnulado)
        //                    {
        //                        XtraMessageBox.Show("No se puede agregar un Proforma Anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                        return;
        //                    }

        //                    int IdProductoTransformacion = 0;
        //                    IdProductoTransformacion = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("IdProductoTransformacion").ToString());
        //                    ////Verficar Proforma existente
        //                    //HojaInstalacionDetalleBE ObjE_Hoja = null;
        //                    //ObjE_Hoja = new HojaInstalacionDetalleBL().SeleccionaProforma(movDetalle.pProformaBE.IdProforma);
        //                    //if (ObjE_Hoja != null)
        //                    //{
        //                    //    string mensajeInstalacion = "";
        //                    //    if (ObjE_Hoja.Fecha > DateTime.Now)
        //                    //        mensajeInstalacion = "se instalará el ";
        //                    //    else
        //                    //        mensajeInstalacion = "fue instalado el ";
        //                    //    XtraMessageBox.Show("El Proforma " + mensajeInstalacion + "día " + ObjE_Hoja.Fecha.ToShortDateString().ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                    //    return;
        //                    //}
        //                    ProductoTransformacionBL objBL_ProductoTrasformacion = new ProductoTransformacionBL();
        //                    objBL_ProductoTrasformacion.ActualizaProforma(IdProductoTransformacion, movDetalle.pProformaBE.IdProforma);

        //                    gvProductoTransformacion.SetRowCellValue(gvProductoTransformacion.FocusedRowHandle, "NumeroProforma", movDetalle.pProformaBE.Numero);
        //                    gvProductoTransformacion.SetRowCellValue(gvProductoTransformacion.FocusedRowHandle, "Fecha", movDetalle.pProformaBE.Fecha);
        //                    gvProductoTransformacion.SetRowCellValue(gvProductoTransformacion.FocusedRowHandle, "DescSituacion", movDetalle.pProformaBE.DescSituacion);
        //                    gvProductoTransformacion.UpdateCurrentRow();

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void eliminarProformaToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (XtraMessageBox.Show("Esta seguro de eliminar el Proforma asociado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
        //        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
        //        frmAutoriza.ShowDialog();

        //        if (frmAutoriza.Edita)
        //        {
        //            int IdProductoTransformacion = 0;
        //            IdProductoTransformacion = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("IdProductoTransformacion").ToString());

        //            ProductoTransformacionBL objBL_ProductoTrasformacion = new ProductoTransformacionBL();
        //            objBL_ProductoTrasformacion.ActualizaProforma(IdProductoTransformacion, 0);

        //            gvProductoTransformacion.SetRowCellValue(gvProductoTransformacion.FocusedRowHandle, "IdProforma", 0);
        //            gvProductoTransformacion.SetRowCellValue(gvProductoTransformacion.FocusedRowHandle, "NumeroProforma", "");
        //            gvProductoTransformacion.SetRowCellValue(gvProductoTransformacion.FocusedRowHandle, "Fecha", null);
        //            gvProductoTransformacion.SetRowCellValue(gvProductoTransformacion.FocusedRowHandle, "DescSituacion", "");
        //        }
        //    }
        //}

        //private void verProformatoolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int IdProforma = int.Parse(gvProductoTransformacion.GetFocusedRowCellValue("IdProforma").ToString());

        //    if (IdProforma > 0)
        //    {
        //        frmRegProformaEdit frm = new frmRegProformaEdit();
        //        frm.IdProforma = IdProforma;
        //        frm.pOperacion = frmRegProformaEdit.Operacion.Consultar;
        //        frm.StartPosition = FormStartPosition.CenterParent;
        //        frm.ShowDialog();
        //    }

        //}
    }
}