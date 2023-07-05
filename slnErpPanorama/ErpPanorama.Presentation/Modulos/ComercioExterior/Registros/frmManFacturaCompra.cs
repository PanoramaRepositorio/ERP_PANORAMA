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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmManFacturaCompra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<FacturaCompraBE> mLista = new List<FacturaCompraBE>();
        List<EstadoCuentaProveedorBE> lstEstadoCuentaProveedor = new List<EstadoCuentaProveedorBE>();
        #endregion

        #region "Eventos"

        public frmManFacturaCompra()
        {
            InitializeComponent();
        }

        private void frmManFacturaCompra_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManFacturaCompraEdit objManFacturaCompra = new frmManFacturaCompraEdit();
                objManFacturaCompra.pOperacion = frmManFacturaCompraEdit.Operacion.Nuevo;
                objManFacturaCompra.IdFacturaCompra = 0;
                objManFacturaCompra.StartPosition = FormStartPosition.CenterParent;
                objManFacturaCompra.ShowDialog();
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

                if (gvFacturaCompra.RowCount > 0)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ygomez" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "etapia" || frmAutoriza.IdPerfil ==Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerHelpDesk)
                        {
                            if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (!ValidarIngreso())
                                {
                                    FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                                    objE_FacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
                                    objE_FacturaCompra.Usuario = Parametros.strUsuarioLogin;
                                    objE_FacturaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;

                                    FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                                    objBL_FacturaCompra.Elimina(objE_FacturaCompra);
                                    XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Cargar();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }


                //if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    if (!ValidarIngreso())
                //    {
                //        FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                //        objE_FacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
                //        objE_FacturaCompra.Usuario = Parametros.strUsuarioLogin;
                //        objE_FacturaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                //        objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;

                //        FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                //        objBL_FacturaCompra.Elimina(objE_FacturaCompra);
                //        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        Cargar();
                //    }
                //}
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
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                    objE_FacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
                    objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;
                    
                    List<ReporteFacturaCompraBE> lstReporte = null;
                    lstReporte = new ReporteFacturaCompraBL().Listado(Parametros.intEmpresaId, objE_FacturaCompra.IdFacturaCompra);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptFacturaCompra = new RptVistaReportes();
                            objRptFacturaCompra.VerRptFacturaCompra(lstReporte);
                            objRptFacturaCompra.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoFacturas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvFacturaCompra.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvFacturaCompra_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            Cargar();
        }

        private void actualizafecharecepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmRegActualizaFechaRecepcion objFacturaCompra = new frmRegActualizaFechaRecepcion();
                objFacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
                if (objFacturaCompra.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }

                Cursor = Cursors.Default;
                  
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vercatalogotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvFacturaCompra.RowCount > 0)
                {
                    int IdFactura = 0;
                    IdFactura = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());

                    List<ReporteProductoCatalogoFacturaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoFacturaBL().Listado(Parametros.intEmpresaId, IdFactura, Parametros.intTipClienteMayorista);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoFactura = new RptVistaReportes();
                            objRptProductoCatalogoFactura.VerRptProductoCatalogoFactura(lstReporte);
                            objRptProductoCatalogoFactura.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vercatalogosolestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvFacturaCompra.RowCount > 0)
                {
                    int IdFactura = 0;
                    IdFactura = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());

                    List<ReporteProductoCatalogoFacturaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoFacturaBL().Listado(Parametros.intEmpresaId, IdFactura, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoFactura = new RptVistaReportes();
                            objRptProductoCatalogoFactura.VerRptProductoCatalogoFacturaSoles(lstReporte);
                            objRptProductoCatalogoFactura.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void verclasificacionpreciofototoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaProductoFoto frm = new frmListaProductoFoto();
            frm.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
            frm.Show();
        }

        private void verdetalleventatoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gvFacturaCompra_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvFacturaCompra.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["PorcentajeVenta"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(0.7))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.7))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Orange;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Red;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Red; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vercatalogosinpreciotoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvFacturaCompra.RowCount > 0)
                {
                    int IdFactura = 0;
                    IdFactura = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
                    List<ReporteProductoCatalogoFacturaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoFacturaBL().Listado(Parametros.intEmpresaId, IdFactura, Parametros.intTipClienteMayorista);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoFactura = new RptVistaReportes();
                            objRptProductoCatalogoFactura.VerRptProductoCatalogoFacturaSinPrecio(lstReporte);
                            objRptProductoCatalogoFactura.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnviarEstadoCuentatoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FacturaCompraBE OBJ = new FacturaCompraBE();
            FacturaCompraBL objl = new FacturaCompraBL();

            OBJ = new FacturaCompraBL().Selecciona(13, int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString()));
            // mLista = new FacturaCompraBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intPeriodo);
            int varidformapago = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFormaPago").ToString());

            if (OBJ != null)
            {

                lstEstadoCuentaProveedor = new EstadoCuentaProveedorBL().ListaFacturaCompra(Parametros.intEmpresaId, OBJ.IdFacturaCompra, "C");//Cargo
                if (lstEstadoCuentaProveedor.Count > 0)
                {
                    XtraMessageBox.Show("Ya existe un registro N°: " + lstEstadoCuentaProveedor[0].NumeroDocumento + " en Estado de Cuenta en Dolares(US$) \n US$ " + lstEstadoCuentaProveedor[0].Importe, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (varidformapago == 62 && OBJ.FechaRecepcion != null)
                    {

                        if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ygomez" || Parametros.strUsuarioLogin == "mmurrugarra" || Parametros.intPerfilId == Parametros.intPerAsistenteCompras || Parametros.strUsuarioLogin == "ltapia" || Parametros.intPerfilId == Parametros.intPerJefeCreditoCobranzas)
                        {
                            if (XtraMessageBox.Show("Esta seguro de enviar al Estado de Cuenta", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {

                                try
                                {
                                    EstadoCuentaProveedorBL objBL_EstadoCuentaProveedor = new EstadoCuentaProveedorBL();
                                    //DateTime.Parse(gvDocumento.GetRowCellValue(row, "Fecha").ToString());

                                    EstadoCuentaProveedorBE objBE_EstadoCuentaProveedor = new EstadoCuentaProveedorBE();

                                    objBE_EstadoCuentaProveedor.IdEmpresa = OBJ.IdEmpresa;
                                    objBE_EstadoCuentaProveedor.Periodo = OBJ.Periodo;
                                    objBE_EstadoCuentaProveedor.IdProveedor = OBJ.IdProveedor;
                                    objBE_EstadoCuentaProveedor.NumeroDocumento = OBJ.NumeroDocumento;
                                    objBE_EstadoCuentaProveedor.Fecha = OBJ.FechaCompra;  //verificar la  fecha de credito
                                    objBE_EstadoCuentaProveedor.Concepto = "CREDITO";
                                    objBE_EstadoCuentaProveedor.FechaVencimiento = OBJ.FechaVencimiento;
                                    objBE_EstadoCuentaProveedor.IdMoneda = OBJ.IdMoneda;
                                    objBE_EstadoCuentaProveedor.Importe = Convert.ToDecimal(OBJ.ImportePorPagar);//decimal.Parse(gvFacturaCompra.GetFocusedRowCellValue("Importe").ToString());
                                    objBE_EstadoCuentaProveedor.TipoMovimiento = "C";
                                    objBE_EstadoCuentaProveedor.IdMotivo = Convert.ToInt32(OBJ.IdMotivoVenta);
                                    objBE_EstadoCuentaProveedor.IdFacturaCompra = OBJ.IdFacturaCompra;
                                    objBE_EstadoCuentaProveedor.IdCuentaBancoDetalle = null;
                                    objBE_EstadoCuentaProveedor.IdPersona = Parametros.intUsuarioId;
                                    objBE_EstadoCuentaProveedor.UsuarioRegistro = Parametros.strUsuarioLogin;
                                    objBE_EstadoCuentaProveedor.FechaRegistro = Parametros.dtFechaHoraServidor;
                                    objBE_EstadoCuentaProveedor.Observacion = "";
                                    objBE_EstadoCuentaProveedor.Saldo = Convert.ToDecimal(OBJ.ImportePorPagar);
                                    objBE_EstadoCuentaProveedor.FlagEstado = true;
                                    objBE_EstadoCuentaProveedor.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objBE_EstadoCuentaProveedor.Usuario = Parametros.strUsuarioLogin;
                                    objBL_EstadoCuentaProveedor.Inserta(objBE_EstadoCuentaProveedor);

                                    XtraMessageBox.Show("Se envio al Estado de cuenta del Proveedor", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {

                                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("No cuenta con los permisos  consulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Solo Facturas Crédito con fecha de recepción", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }



        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new FacturaCompraBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intPeriodo);
            gcFacturaCompra.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcFacturaCompra.DataSource = mLista.Where(obj =>
                                                   obj.NumeroDocumento.ToUpper().Contains(txtNumeroDocumento.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvFacturaCompra.RowCount > 0)
            {
                FacturaCompraBE objFacturaCompra = new FacturaCompraBE();
                objFacturaCompra.IdFacturaCompra = int.Parse(gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString());
              
                frmManFacturaCompraEdit objManFacturaCompraEdit = new frmManFacturaCompraEdit();
                objManFacturaCompraEdit.pOperacion = frmManFacturaCompraEdit.Operacion.Modificar;
                objManFacturaCompraEdit.IdFacturaCompra = objFacturaCompra.IdFacturaCompra;
                objManFacturaCompraEdit.bMostrarVenta = chkIncluirVenta.Checked;
                
                lstEstadoCuentaProveedor = new EstadoCuentaProveedorBL().ListaFacturaCompra(Parametros.intEmpresaId, objFacturaCompra.IdFacturaCompra, "C");//Cargo
                if (lstEstadoCuentaProveedor.Count > 0)
                { 
                    objManFacturaCompraEdit.FlagEnviado = true;
                }
                else
                {
                    objManFacturaCompraEdit.FlagEnviado = false;
                }

                objManFacturaCompraEdit.StartPosition = FormStartPosition.CenterParent;

                //objManFacturaCompraEdit.ShowDialog();
                if (objManFacturaCompraEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
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

            if (gvFacturaCompra.GetFocusedRowCellValue("IdFacturaCompra").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Factura Compra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }




        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void gvFacturaCompra_RowCellClick(object sender, RowCellClickEventArgs e)
        {
   
        }

        private void gvFacturaCompra_RowCellStyle_1(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvFacturaCompra.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["PorcentajeVenta"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(0.7))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Green;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.7))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Orange;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        {
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor = Color.Red;
                            gvFacturaCompra.Columns["PorcentajeVenta"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Red; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvFacturaCompra_DoubleClick_1(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }
    }
}