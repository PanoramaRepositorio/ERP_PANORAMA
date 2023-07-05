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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManDelivery : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ListaPrecioDeliveryBE> mLista = new List<ListaPrecioDeliveryBE>();

        #endregion

        #region "Eventos"
    
        public frmManDelivery()
        {
            InitializeComponent();
        }

        private void frmManDelivery_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();

            if (Parametros.intPerfilId == Parametros.intPerAdministrador)
            {
                btnGrabar.Visible = true;
                btnEditar.Visible = true;
                prgFactura.Visible = false;
            }
            else
            {
                btnGrabar.Visible = false;
                btnEditar.Visible = false;
                prgFactura.Visible = false;
            }
                
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManDeliveryEdit objManDelivery = new frmManDeliveryEdit();
                objManDelivery.lstListaPrecioDelivery = mLista;
                objManDelivery.pOperacion = frmManDeliveryEdit.Operacion.Nuevo;
                objManDelivery.IdListaPrecioDelivery = 0;
                objManDelivery.StartPosition = FormStartPosition.CenterParent;
                objManDelivery.ShowDialog();
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
                        ListaPrecioDeliveryBE objE_Delivery = new ListaPrecioDeliveryBE();
                        objE_Delivery.IdListaPrecioDelivery = int.Parse(gvDelivery.GetFocusedRowCellValue("IdListaPrecioDelivery").ToString());
                        objE_Delivery.Usuario = Parametros.strUsuarioLogin;
                        objE_Delivery.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Delivery.IdEmpresa = Parametros.intEmpresaId;

                        ListaPrecioDeliveryBL objBL_Delivery = new ListaPrecioDeliveryBL();
                        objBL_Delivery.Elimina(objE_Delivery);
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

            //    List<ReporteDeliveryBE> lstReporte = null;
            //    lstReporte = new ReporteDeliveryBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDelivery = new RptVistaReportes();
            //            objRptDelivery.VerRptDelivery(lstReporte);
            //            objRptDelivery.ShowDialog();
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
            string _fileName = "ListadoDelivery";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDelivery.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDelivery_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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

                    if (XtraMessageBox.Show("Esta seguro de Actualizar los registros modificados", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        prgFactura.Visible = true;
                        for (int i = 0; i < gvDelivery.SelectedRowsCount; i++)
                        {
                            int IdListaPrecioDelivery = 0;
                            string IdUbigeo = "";
                            string IdDepartamento = "";
                            string IdProvincia = "";
                            string IdDistrito = "";
                            string DescUbigeo = "";
                            decimal TarifaEnvio = 0;


                            int row = gvDelivery.GetSelectedRows()[i];
                            int TotRow = gvDelivery.SelectedRowsCount;
                            TotRow = TotRow - row + 1;
                            prgFactura.Properties.Step = 1;
                            prgFactura.Properties.Maximum = TotRow;
                            prgFactura.Properties.Minimum = 0;

                            IdListaPrecioDelivery = int.Parse(gvDelivery.GetRowCellValue(row, "IdListaPrecioDelivery").ToString());
                            IdUbigeo = gvDelivery.GetRowCellValue(row, "IdUbigeo").ToString();
                            IdDepartamento = gvDelivery.GetRowCellValue(row, "IdDepartamento").ToString();
                            IdProvincia = gvDelivery.GetRowCellValue(row, "IdProvincia").ToString();
                            IdDistrito = gvDelivery.GetRowCellValue(row, "IdDistrito").ToString();
                            DescUbigeo = gvDelivery.GetRowCellValue(row, "DescUbigeo").ToString();
                            TarifaEnvio = decimal.Parse(gvDelivery.GetRowCellValue(row, "TarifaEnvio").ToString());


                            //Actualizar DeliveryVenta
                            ListaPrecioDeliveryBE objBE_DeliveryVenta = new ListaPrecioDeliveryBE();
                            objBE_DeliveryVenta.IdListaPrecioDelivery = IdListaPrecioDelivery;
                            objBE_DeliveryVenta.IdUbigeo = IdUbigeo;
                            objBE_DeliveryVenta.IdDepartamento = IdDepartamento;
                            objBE_DeliveryVenta.IdProvincia = IdProvincia;
                            objBE_DeliveryVenta.IdDistrito = IdDistrito;
                            objBE_DeliveryVenta.DescUbigeo = DescUbigeo;
                            objBE_DeliveryVenta.TarifaEnvio = TarifaEnvio;
                            objBE_DeliveryVenta.FlagEstado = true;
                            objBE_DeliveryVenta.Usuario = Parametros.strUsuarioLogin;
                            objBE_DeliveryVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objBE_DeliveryVenta.IdEmpresa = Parametros.intIdPanoramaDistribuidores;

                            ListaPrecioDeliveryBL objBL_DeliveryVenta = new ListaPrecioDeliveryBL();
                            objBL_DeliveryVenta.Actualiza(objBE_DeliveryVenta);

                            prgFactura.PerformStep();
                            prgFactura.Update();

                        }
                        //gvDocumento.DeleteRow(gvDocumento.FocusedRowHandle);
                        //gvDocumento.RefreshData();
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        prgFactura.Visible = false;
                        Cargar();

                    }



                    //ListaPrecioDeliveryBL objBL_Almacen = new ListaPrecioDeliveryBL();
                    //ListaPrecioDeliveryBE objAlmacen = new ListaPrecioDeliveryBE();
                    //objAlmacen.IdListaPrecioDelivery = IdListaPrecioDelivery;
                    //objAlmacen.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    //objAlmacen.IdDepartamento = cboDepartamento.EditValue.ToString();
                    //objAlmacen.IdProvincia = cboProvincia.EditValue.ToString();
                    //objAlmacen.IdDistrito = cboDistrito.EditValue.ToString();
                    //objAlmacen.DescUbigeo = txtDescripcion.Text.Trim();
                    //objAlmacen.TarifaEnvio = Convert.ToDecimal(txtTotal.EditValue);
                    //objAlmacen.FlagEstado = true;
                    //objAlmacen.Usuario = Parametros.strUsuarioLogin;
                    //objAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    //objAlmacen.IdEmpresa = Parametros.intIdPanoramaDistribuidores;

                    //if (pOperacion == Operacion.Nuevo)
                    //    objBL_Almacen.Inserta(objAlmacen);
                    //else
                    //    objBL_Almacen.Actualiza(objAlmacen);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            gvDelivery.Columns["TarifaEnvio"].OptionsColumn.AllowEdit = true;
            gvDelivery.Columns["TarifaEnvio"].OptionsColumn.AllowFocus = true;
            btnEditar.Visible = false;
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ListaPrecioDeliveryBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDelivery.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDelivery.DataSource = mLista.Where(obj =>
                                                   obj.DescUbigeo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDelivery.RowCount > 0)
            {
                ListaPrecioDeliveryBE objDelivery = new ListaPrecioDeliveryBE();
                objDelivery.IdListaPrecioDelivery = int.Parse(gvDelivery.GetFocusedRowCellValue("IdListaPrecioDelivery").ToString());
                objDelivery.IdEmpresa = int.Parse(gvDelivery.GetFocusedRowCellValue("IdEmpresa").ToString());
                objDelivery.IdUbigeo = gvDelivery.GetFocusedRowCellValue("IdUbigeo").ToString();
                objDelivery.IdDepartamento = gvDelivery.GetFocusedRowCellValue("IdDepartamento").ToString();
                objDelivery.IdProvincia = gvDelivery.GetFocusedRowCellValue("IdProvincia").ToString();
                objDelivery.IdDistrito = gvDelivery.GetFocusedRowCellValue("IdDistrito").ToString();
                objDelivery.DescUbigeo = gvDelivery.GetFocusedRowCellValue("DescUbigeo").ToString();
                objDelivery.TarifaEnvio = Convert.ToDecimal(gvDelivery.GetFocusedRowCellValue("TarifaEnvio").ToString());
                objDelivery.TarifaEnvioA = Convert.ToDecimal(gvDelivery.GetFocusedRowCellValue("TarifaEnvioA").ToString());
                objDelivery.TarifaEnvioP = Convert.ToDecimal(gvDelivery.GetFocusedRowCellValue("TarifaEnvioP").ToString());
                objDelivery.FlagEstado = Convert.ToBoolean(gvDelivery.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManDeliveryEdit objManDeliveryEdit = new frmManDeliveryEdit();
                objManDeliveryEdit.pOperacion = frmManDeliveryEdit.Operacion.Modificar;
                objManDeliveryEdit.IdListaPrecioDelivery = objDelivery.IdListaPrecioDelivery;
                objManDeliveryEdit.pListaPrecioDeliveryBE = objDelivery;
                objManDeliveryEdit.StartPosition = FormStartPosition.CenterParent;
                objManDeliveryEdit.ShowDialog();

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

            if (gvDelivery.GetFocusedRowCellValue("IdListaPrecioDelivery").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un Delivery", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}