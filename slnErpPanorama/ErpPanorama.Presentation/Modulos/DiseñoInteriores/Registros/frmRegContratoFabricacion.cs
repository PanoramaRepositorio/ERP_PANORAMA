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
using ErpPanorama.Presentation.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Creditos.Consultas;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.DiseñoInteriores.Otros;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmRegContratoFabricacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<Dis_ContratoFabricacionBE> mLista = new List<Dis_ContratoFabricacionBE>();
        private List<PagosBE> mListaPagos = new List<PagosBE>();
        private List<PedidoBE> mListaPedido = new List<PedidoBE>();

        #endregion

        #region "Eventos"

        public frmRegContratoFabricacion()
        {
            InitializeComponent();
        }

        private void frmRegContratoFabricacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);
            cboVendedor.EditValue = Parametros.intPersonaId;
            deDesde.EditValue =  Convert.ToDateTime("01" + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).AddMonths(-1); //   DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegContratoFabricacionEdit objManDis_ContratoFabricacion = new frmRegContratoFabricacionEdit();
                objManDis_ContratoFabricacion.pOperacion = frmRegContratoFabricacionEdit.Operacion.Nuevo;
                objManDis_ContratoFabricacion.IdDis_ContratoFabricacion = 0;
                objManDis_ContratoFabricacion.StartPosition = FormStartPosition.CenterParent;
                objManDis_ContratoFabricacion.ShowDialog();
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
                        Dis_ContratoFabricacionBE objE_Dis_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                        objE_Dis_ContratoFabricacion.IdDis_ContratoFabricacion = int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString());
                        objE_Dis_ContratoFabricacion.Usuario = Parametros.strUsuarioLogin;
                        objE_Dis_ContratoFabricacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Dis_ContratoFabricacion.IdEmpresa = Parametros.intEmpresaId;

                        Dis_ContratoFabricacionBL objBL_Dis_ContratoFabricacion = new Dis_ContratoFabricacionBL();
                        objBL_Dis_ContratoFabricacion.Elimina(objE_Dis_ContratoFabricacion);
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

            //    List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte = null;
            //    lstReporte = new ReporteDis_ProyectoServicioContratoFabricacionBL().Listado(int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString()), 0);
            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
            //            objRptMovimientoPedido.VerRptDis_ProyectoServicioContratoFabricacion(lstReporte);
            //            objRptMovimientoPedido.ShowDialog();
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

            ////
                       try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioContratoFabricacionBL().Listado(int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString()), 1);
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicioContratoFabricacion(lstReporte);
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoDis_ContratoFabricacion";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_ContratoFabricacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDis_ContratoFabricacion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void imprimircontratoaprobadotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioContratoFabricacionBL().Listado(int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString()), 1);
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicioContratoFabricacion(lstReporte);
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

        private void imprimirsinfototoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioContratoFabricacionBL().Listado(int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString()), 0);
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicioContratoFabricacionSinFoto(lstReporte);
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

        private void imprimirconfototoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioContratoFabricacionBL().Listado(int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString()), 0);
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicioContratoFabricacion(lstReporte);
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
                if (gvDis_ContratoFabricacion.RowCount > 0)
                {
                    int IdCliente = 0;
                    int IdMotivo = 0;
                    IdCliente = int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdCliente").ToString());
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

        private void gvDis_ContratoFabricacion_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvDis_ContratoFabricacion.RowCount > 0)
            {
                DataRow dr;
                int IdDis_Contrato = 0;
                string sIdDis_ContratoFabricacion = "";
                IdDis_Contrato = int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString()); //gvDis_ContratoFabricacion.GetDataRow(e.RowHandle);
                CargarPedido(IdDis_Contrato);

            }
        }


        private void CargarPedido(int IdDis_ContratoFabricacion)
        {
            mListaPedido = new PedidoBL().ListaContratoFabricacion(IdDis_ContratoFabricacion);
            gcPedido.DataSource = mListaPedido;

            mListaPagos = new PagosBL().ListaAsesoria(Parametros.intEmpresaId, 0, IdDis_ContratoFabricacion, 1);
            gcReciboPago.DataSource = mListaPagos;

        }

        private void atendertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvDis_ContratoFabricacion.RowCount > 0)
            {
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerCoodinadorComprasDiseno)
                    {
                        int IdContratoFabricacion = 0;
                        IdContratoFabricacion = int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString());

                        Dis_ContratoFabricacionBL objBL_Contrato = new Dis_ContratoFabricacionBL();
                        objBL_Contrato.ActualizaAtender(IdContratoFabricacion, frmAutoriza.Usuario);
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("UD. no tiene permisos para realizar esta acción.", this.Text);
                    }
                }
            }
        }

        private void gvDis_ContratoFabricacion_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvDis_ContratoFabricacion.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objAtencion = View.GetRowCellValue(e.RowHandle, View.Columns["FechaAtencion"]);
                    //object FechaCotizacion = View.GetRowCellValue(e.RowHandle, View.Columns["FechaCotizacion"]);
                    object FechaPrimerAbono = View.GetRowCellValue(e.RowHandle, View.Columns["FechaPrimerAbono"]);
                    //object FechaEntrega = View.GetRowCellValue(e.RowHandle, View.Columns["FechaEntrega"]);
                    object FechaProduccion = View.GetRowCellValue(e.RowHandle, View.Columns["FechaProduccion"]);

                    if (FechaPrimerAbono != null)
                    {
                        string IdTipoDocumento = (FechaPrimerAbono.ToString());
                        if (IdTipoDocumento.ToString().Length > 0 && objAtencion == null)
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                    if (FechaProduccion != null)
                    {
                        DateTime FechaPrpod = DateTime.Parse(FechaProduccion.ToString());
                        if (DateTime.Now >= FechaPrpod.AddDays(-3))
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultarFecha_Click(object sender, EventArgs e)
        {
            mLista = new Dis_ContratoFabricacionBL().ListaTodosActivo(Parametros.intEmpresaId, 0, deDesde.DateTime, deHasta.DateTime);
            gcDis_ContratoFabricacion.DataSource = mLista;
        }

        private void imprimirsinpreciotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteDis_ProyectoServicioContratoFabricacionBE> lstReporte = null;
                lstReporte = new ReporteDis_ProyectoServicioContratoFabricacionBL().Listado(int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString()), 0);
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                        objRptMovimientoPedido.VerRptDis_ProyectoServicioContratoFabricacionSinPrecio(lstReporte);
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

        private void VerPedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;

                    IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    if (IdPedido.ToString() != "")
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

        private void VerDocumentoVentatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (gvDis_ContratoFabricacion.RowCount > 0)
                    {
                        int IdPedido = 0;
                        int IdSituacion = 0;
                        string Numero = "";

                        IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                        IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                        Numero = gvPedido.GetFocusedRowCellValue("Numero").ToString();

                        if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                        {
                            frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
                            objVentaPedido.IdPedido = IdPedido;
                            objVentaPedido.NumeroPedido = Numero;
                            objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                            objVentaPedido.Show();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VerEstadoCuenta2toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdCliente = 0;
                    int IdMotivo = 0;
                    IdCliente = int.Parse(gvPedido.GetFocusedRowCellValue("IdCliente").ToString());
                    IdMotivo = int.Parse(gvPedido.GetFocusedRowCellValue("IdMotivo").ToString());

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

        private void imprimirdespachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int IdFormaPago = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdFormaPago").ToString());
                int IdSituacion = Convert.ToInt32(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdFormaPago == Parametros.intCredito || IdFormaPago == Parametros.intContraEntrega || IdFormaPago == Parametros.intCopagan || IdFormaPago == Parametros.intSeparacion)
                {
                    if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                    {
                        List<ReporteMovimientoPedidoBE> lstReporte = null;
                        lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                                objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
                                objRptMovimientoPedido.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede Imprimir la hoja de Despacho,\n1. Verificar que el pedido esté embalado ó se encuentre en condición de embalaje.\n2. Verificar si tiene comprobantes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    List<ReporteMovimientoPedidoBE> lstReporte = null;
                    lstReporte = new ReporteMovimientoPedidoBL().Listado(int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptMovimientoPedido = new RptVistaReportes();
                            objRptMovimientoPedido.VerRptMovimientoPedido(lstReporte);
                            objRptMovimientoPedido.ShowDialog();
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

        private void cambiardespachotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                int IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion == Parametros.intFacturado || IdSituacion == Parametros.intPVDespachado)
                {
                    MessageBox.Show("No se puede modificar la hoja de despacho, después de facturado o despachado!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    frmRegGestionPedidoDespachoEdit frm = new frmRegGestionPedidoDespachoEdit();
                    frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    frm.pOperacion = frmRegGestionPedidoDespachoEdit.Operacion.Modificar;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
        }

        private void encuestacontratotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdDis_ContratoFabricacion = int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString());
                bool Cerrado = bool.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("FlagEncuestaCerrada").ToString());
                if (!Cerrado)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ygomez" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador 
                            || frmAutoriza.IdPerfil == Parametros.intSupervisoraVentaPisoDiseno || frmAutoriza.IdPerfil == Parametros.intPerCoodinadorComprasDiseno || frmAutoriza.IdPerfil == Parametros.intPerSupervisorDiseno)
                        {
                            frmCerrarContrato frm = new frmCerrarContrato();
                            frm.IdDis_ContratoFabricacion = IdDis_ContratoFabricacion;
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                Dis_ContratoFabricacionBE objE_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                                Dis_ContratoFabricacionBL objBL_ContratoFabricacion = new Dis_ContratoFabricacionBL();
                                objE_ContratoFabricacion = frm.oBE;
                                objBL_ContratoFabricacion.ActualizaEncuesta(objE_ContratoFabricacion);
                                //XtraMessageBox.Show("Proyecto cerrado correctamente!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. No está autorizado para realizar esta operación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("La encuesta del contrato está cerrada!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new Dis_ContratoFabricacionBL().ListaTodosActivo(Parametros.intEmpresaId,Convert.ToInt32(cboVendedor.EditValue),deDesde.DateTime, deHasta.DateTime);
            gcDis_ContratoFabricacion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvDis_ContratoFabricacion.RowCount > 0)
            {
                Dis_ContratoFabricacionBE objDis_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                objDis_ContratoFabricacion.IdDis_ContratoFabricacion = int.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString());
                //objDis_ContratoFabricacion.Numero = gvDis_ContratoFabricacion.GetFocusedRowCellValue("Numero").ToString();
                //objDis_ContratoFabricacion.Fecha = DateTime.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("Fecha").ToString());
                //objDis_ContratoFabricacion.FechaFin = DateTime.Parse(gvDis_ContratoFabricacion.GetFocusedRowCellValue("FechaFin").ToString());
                //objDis_ContratoFabricacion.FechaEntrega = gvDis_ContratoFabricacion.GetFocusedRowCellValue("FechaEntrega").ToString();

                frmRegContratoFabricacionEdit objManDis_ContratoFabricacionEdit = new frmRegContratoFabricacionEdit();
                objManDis_ContratoFabricacionEdit.pOperacion = frmRegContratoFabricacionEdit.Operacion.Modificar;
                objManDis_ContratoFabricacionEdit.IdDis_ContratoFabricacion = objDis_ContratoFabricacion.IdDis_ContratoFabricacion;
                objManDis_ContratoFabricacionEdit.pDis_ContratoFabricacionBE = objDis_ContratoFabricacion;
                objManDis_ContratoFabricacionEdit.StartPosition = FormStartPosition.CenterParent;
                /*objManDis_ContratoFabricacionEdit.ShowDialog()*/;
                if(objManDis_ContratoFabricacionEdit.ShowDialog() ==DialogResult.OK)
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

            if (gvDis_ContratoFabricacion.GetFocusedRowCellValue("IdDis_ContratoFabricacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Dis_ContratoFabricacion", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void gcDis_ContratoFabricacion_Click(object sender, EventArgs e)
        {

        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}