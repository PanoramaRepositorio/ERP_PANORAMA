using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Creditos.Consultas;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.DiseñoInteriores.Otros;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmRegProyectoServicio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //private List<PedidoBE> mLista = new List<PedidoBE>();
        private List<AsesoriaBE> mLista = new List<AsesoriaBE>();
        private List<PagosBE> mListaPagos = new List<PagosBE>();
        private List<PedidoBE> mListaPedido = new List<PedidoBE>();
        private List<Dis_ContratoFabricacionBE> mListaContrato = new List<Dis_ContratoFabricacionBE>();

        #endregion

        #region "Eventos"

        public frmRegProyectoServicio()
        {
            InitializeComponent();
        }

        private void frmRegProyectoServicio_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = Convert.ToDateTime("01/01" + "/" + DateTime.Now.Year);
            //deDesde.EditValue = Convert.ToDateTime("01" + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year); 
            //deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegProyectoServicioEdit objManDis_ProyectoServiciol = new frmRegProyectoServicioEdit();
                objManDis_ProyectoServiciol.pOperacion = frmRegProyectoServicioEdit.Operacion.Nuevo;
                objManDis_ProyectoServiciol.IdDis_ProyectoServicio = 0;
                objManDis_ProyectoServiciol.StartPosition = FormStartPosition.CenterParent;
                objManDis_ProyectoServiciol.ShowDialog();
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
                if (XtraMessageBox.Show("Está seguro de eliminar el registro de Asesoria?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        Dis_ProyectoServicioBE objE_Dis_ProyectoServicio = new Dis_ProyectoServicioBE();
                        Dis_ProyectoServicioBL objBL_Dis_ProyectoServicio = new Dis_ProyectoServicioBL();

                        objE_Dis_ProyectoServicio.IdDis_ProyectoServicio = int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString());
                        objBL_Dis_ProyectoServicio.Elimina(objE_Dis_ProyectoServicio);


                        Dis_DisenoVisitasRealizadasBE objBE_Dis_DisenoVisitasRea = new Dis_DisenoVisitasRealizadasBE();
                        //objBE_Dis_DisenoVisitasRea.IdDis_ProyectoServicio = IdDis_DisenoFuncional;
                        objBE_Dis_DisenoVisitasRea.IdDis_ProyectoServicio = int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()); 
                        //objBE_Dis_DisenoVisitasRea.Usuario = Parametros.strUsuarioLogin;
                        //objBE_Dis_DisenoVisitasRea.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        Dis_DisenoVisitasRealizadasBL objBL_Dis_DisenoVR = new Dis_DisenoVisitasRealizadasBL();
                        objBL_Dis_DisenoVR.EliminaTodosVisitas(objBE_Dis_DisenoVisitasRea);

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
            //    if (gvDis_ProyectoServicio.RowCount > 0)
            //    {
            //        frmListaPrinters frmPrinter = new frmListaPrinters();
            //        if (frmPrinter.ShowDialog() == DialogResult.OK)
            //        {
            //            List<ReporteDis_ProyectoServicioContadoBE> lstReporte = null;
            //            lstReporte = new ReporteDis_ProyectoServicioContadoBL().Listado(Parametros.intPeriodo, int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()));
            //            if (lstReporte.Count > 0)
            //            {
            //                rptDis_ProyectoServicioContado objReporteGuia = new rptDis_ProyectoServicioContado();
            //                objReporteGuia.SetDataSource(lstReporte);
            //                objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
            //                objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
            //                objReporteGuia.SetParameterValue("Modificado", "()");

            //                Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoDis_ProyectoServicioDiseño";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_ProyectoServicio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDis_ProyectoServicio_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvDis_ProyectoServicio_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvDis_ProyectoServicio.RowCount > 0)
            {
                DataRow dr;
                int IdDis_ProyectoServicio = 0;
                string sIdDis_ProyectoServicio = "";
                dr = gvDis_ProyectoServicio.GetDataRow(e.RowHandle);
                sIdDis_ProyectoServicio = dr["IdDis_ProyectoServicio"].ToString();
                if (sIdDis_ProyectoServicio != "")
                {
                    IdDis_ProyectoServicio = int.Parse(dr["IdDis_ProyectoServicio"].ToString());
                    CargarDetalles(IdDis_ProyectoServicio);
                }
            }
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (gvDis_ProyectoServicio.RowCount > 0)
            //    {

            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            DataTable dtDis_ProyectoServicio = new DataTable();
            dtDis_ProyectoServicio = FuncionBase.ToDataTable(new Dis_ProyectoServicioBL().ListaTodosActivo(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime));

            gcDis_ProyectoServicio.DataSource = dtDis_ProyectoServicio;

            txtTotal.Text = dtDis_ProyectoServicio.Rows.Count.ToString();

            decimal decTotalSoles = 0;
            decimal decTotalDolares = 0;

            foreach (DataRow row in dtDis_ProyectoServicio.Rows)
            {
                if (int.Parse(row["IdSituacion"].ToString()) == Parametros.intFacturado || int.Parse(row["IdSituacion"].ToString()) == Parametros.intPVDespachado)
                {
                    //Suma Contado Cancelados o Despachado
                    if (row["CodMoneda"].ToString() == "US$")
                    {
                        decTotalDolares = decTotalDolares + Convert.ToDecimal(row["Total"].ToString());
                    }
                    else
                    {
                        decTotalSoles = decTotalSoles + Convert.ToDecimal(row["Total"].ToString());
                    }
                }

            }

            txtTotalSoles.EditValue = decTotalSoles;
            txtTotalDolares.EditValue = decTotalDolares;
        }

        private void CargarDetalles(int IdDis_ProyectoServicio)
        {
            mListaPagos = new PagosBL().ListaAsesoria(Parametros.intEmpresaId, IdDis_ProyectoServicio, 0, 0);
            gcReciboPago.DataSource = mListaPagos;

            CargarPedido(IdDis_ProyectoServicio);
            CargarContrato(IdDis_ProyectoServicio);
        }

        public void InicializarModificar()
        {
            if (gvDis_ProyectoServicio.RowCount > 0)
            {
                Dis_ProyectoServicioBE objDis_ProyectoServicio = new Dis_ProyectoServicioBE();
                objDis_ProyectoServicio.IdDis_ProyectoServicio = int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString());
                frmRegProyectoServicioEdit objRegPedidoEdit = new frmRegProyectoServicioEdit();
                objRegPedidoEdit.pOperacion = frmRegProyectoServicioEdit.Operacion.Modificar;
                objRegPedidoEdit.IdDis_ProyectoServicio = objDis_ProyectoServicio.IdDis_ProyectoServicio;
                objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                objRegPedidoEdit.btnGrabar.Enabled = true;
                //objRegPedidoEdit.ShowDialog();
                if (objRegPedidoEdit.ShowDialog() == DialogResult.OK)
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

            if (gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Dis_ProyectoServicio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void CargarPedido(int IdDis_ProyectoServicio)
        {
            mListaPedido = new PedidoBL().ListaProyecto(IdDis_ProyectoServicio);
            gcPedido.DataSource = mListaPedido;
        }

        private void CargarContrato(int IdDis_ProyectoServicio)
        {
            mListaContrato = new Dis_ContratoFabricacionBL().ListaProyecto(Parametros.intEmpresaId, IdDis_ProyectoServicio);
            gcContrato.DataSource = mListaContrato;
        }

        #endregion

        private void imprimirdesarrollotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioBL().Listado(Parametros.intPeriodo, int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()));
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicio(lstReporte);
                        objRptMovimientoPedido.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimirfuncionaltoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_DisenoFuncionalBE> lstReporte = null;
                lstReporte = new ReporteDis_DisenoFuncionalBL().Listado(int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()));
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_DisenoFuncional(lstReporte);
                        objRptMovimientoPedido.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimiresteticotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_DisenoEsteticoBE> lstReporte = null;
                lstReporte = new ReporteDis_DisenoEsteticoBL().Listado(int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()));
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_DisenoEstetico(lstReporte);
                        objRptMovimientoPedido.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimircontratotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioContratoBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioContratoBL().Listados(int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()), 0);
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicioContrato(lstReporte);
                        objRptMovimientoPedido.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("El formato de contrato No pertenece al motivo definido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimircontrato99toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioContratoBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioContratoBL().Listado(int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()), 2);
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicioContrato(lstReporte);
                        objRptMovimientoPedido.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verestadocuentatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDis_ProyectoServicio.RowCount > 0)
                {
                    int IdCliente = 0;
                    int IdMotivo = 0;
                    IdCliente = int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdCliente").ToString());
                    IdMotivo = Parametros.intMotivoVenta;//int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdMotivo").ToString());

                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                    if (IdCliente.ToString() != "")
                    {
                        //if (objE_Cliente.IdTipoCliente  == Parametros.intTipClienteMayorista)
                        if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                        {
                            ////var objE_EstadoCuenta;
                            //EstadoCuentaBE objE_EstadoCuenta = null;
                            //objE_EstadoCuenta = (EstadoCuentaBE)gvPedido.GetFocusedRow();

                            ////XtraMessageBox.Show(objE_EstadoCuenta.DescCliente +"   "+ objE_EstadoCuenta.Concepto, this.Text);

                            frmConEstadoCuenta frm = new frmConEstadoCuenta();
                            frm.IdCliente = IdCliente;
                            frm.NumeroDocumento = objE_Cliente.NumeroDocumento;
                            frm.DescCliente = objE_Cliente.DescCliente;
                            frm.IdMotivoVenta = IdMotivo;
                            frm.Origen = 1;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                        else
                        {
                            //SeparacionBE objE_Separacion = null;
                            //objE_Separacion = (SeparacionBE)gvPedido.GetFocusedRow();

                            frmConSeparacion frm = new frmConSeparacion();
                            frm.IdCliente = IdCliente;
                            frm.NumeroDocumento = objE_Cliente.NumeroDocumento;//  gvPedido.GetFocusedRowCellValue("NumeroDocumento").ToString();
                            frm.DescCliente = objE_Cliente.DescCliente;// gvPedido.GetFocusedRowCellValue("DescCliente").ToString();
                            frm.IdMotivoVenta = IdMotivo;
                            frm.Origen = 1;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Seleccionar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    if (IdPedido > 0)
                    {
                        frmRegPedidoEdit frm = new frmRegPedidoEdit();
                        frm.IdPedido = IdPedido;
                        frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
        
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Verificar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirFormatoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void imprimircontratoserviciotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioContratoBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioContratoBL().Listado(int.Parse( gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString()), 3);
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicioContrato(lstReporte);
                        objRptMovimientoPedido.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cerrarcontratotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdProyecto = int.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("IdDis_ProyectoServicio").ToString());
                bool Cerrado = bool.Parse(gvDis_ProyectoServicio.GetFocusedRowCellValue("FlagCerrado").ToString());
                if(!Cerrado)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.Usuario == "ygomez"
                            || frmAutoriza.IdPerfil == Parametros.intSupervisoraVentaPisoDiseno || frmAutoriza.IdPerfil == Parametros.intPerCoodinadorComprasDiseno
                            || frmAutoriza.IdPerfil == Parametros.intPerSupervisorDiseno)
                        {
                            frmCerrarProyecto frm = new frmCerrarProyecto();
                            frm.IdProyecto = IdProyecto;
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                Dis_ProyectoServicioBE objE_Proyecto = new Dis_ProyectoServicioBE();
                                Dis_ProyectoServicioBL objBL_Proyecto = new Dis_ProyectoServicioBL();
                                objE_Proyecto = frm.oBE;
                                objBL_Proyecto.ActualizaCierre(objE_Proyecto);
                                XtraMessageBox.Show("Proyecto cerrado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                            }
                        }else
                        {
                            XtraMessageBox.Show("Ud. No está autorizado para realizar esta operación.", this.Text,MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }else
                {
                    XtraMessageBox.Show("El proyecto ya está cerrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}