using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegDespacharPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<PedidoBE> mLista = new List<PedidoBE>();
        private int IdPedido = 0;
        private int IdModuloDespacho = 0;
        #endregion

        #region "Eventos"
        public frmRegDespacharPedido()
        {
            InitializeComponent();
        }

        private void frmRegDespacharPedido_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPedidoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intFacturado;

            txtPeriodo.EditValue = DateTime.Now.Year;

            BSUtils.LoaderLook(cboDespachador, new PersonaBL().SeleccionaAuxiliar(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);


            txtNumero.Select();


        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            //GridView view = (GridView)sender;
            //Point pt = view.GridControl.PointToClient(Control.MousePosition);
            //FilaDoubleClick(view, pt);

            asignapersonatoolStripMenuItem1_Click(sender, e);
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboSituacion.Text.Trim() == "")
            {
                XtraMessageBox.Show("Debe seleccionar una situación del pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSituacion.Focus();
                return;
            }

            Cargar();
        }

        private void gvPedido_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvPedido.RowCount > 0)
            {
                DataRow dr;
                int IdPedido = 0;
                dr = gvPedido.GetDataRow(e.RowHandle);
                IdPedido = int.Parse(dr["IdPedido"].ToString());
                CargarDetalles(IdPedido);
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void asignapersonatoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Parametros.intPerfilId == Parametros.intPerAdministrador || Parametros.intPerfilId == Parametros.intPerCoordinadorDespacho)
            {
                int IdSituacion = int.Parse(gvPedido.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion == Parametros.intPVAnulado)
                {
                    XtraMessageBox.Show("No se puede despachar el pedido está anulado.");
                    return;
                }

                frmRegAsignarDespachadorPedido frm = new frmRegAsignarDespachadorPedido();
                frm.IdPedido = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                Cargar();
            }
            else
            {
                XtraMessageBox.Show("UD. no cuenta con permisos para realizar esta operación \nSólo puede ser asignado por el usuario de Despacho.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimirtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "vvillano" /*|| Parametros.intPerfilId == Parametros.intPerSupervisorAlmacen*/)
            {
                Imprimir();
            }
            else
            {
                XtraMessageBox.Show("UD. no cuenta con permisos para realizar esta operación \nSólo puede ser asignado por el usuario de Despacho.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gvPedidoDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {

        }

        private void gvPedido_ColumnFilterChanged(object sender, EventArgs e)
        {
            LAable.Text = gvPedido.RowCount.ToString() + " Registros";
        }

        private void btnDespachar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                PedidoBL objBL_Pedido = new PedidoBL();
                PedidoBE objE_Pedido = new PedidoBE();

                //List<MovimientoPedidoBE> lstMovimientoPedido = new List<MovimientoPedidoBE>();
                MovimientoPedidoBE objMovimientoPedido = new MovimientoPedidoBE();
                MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();
                objE_Pedido = objBL_Pedido.Selecciona(IdPedido);
                if (objE_Pedido.IdSituacion == Parametros.intFacturado)
                {
                    TicketDespachoBE objE_Ticket = null;// new TicketDespachoBE();
                    TicketDespachoBL objBL_Ticket = new TicketDespachoBL();

                    int IdTicketDespacho = 0;
                    objE_Ticket = objBL_Ticket.SeleccionaPedido(IdPedido);
                    if (objE_Ticket == null)
                    {
                        if(!ValidarIngreso())
                        {
                            //Insertar ticket despacho
                            objE_Ticket = new TicketDespachoBE();
                            objE_Ticket.IdTicketDespacho = 0;
                            objE_Ticket.IdPedido = IdPedido;
                            objE_Ticket.Fecha = Convert.ToDateTime(Parametros.dtFechaHoraServidor.ToShortDateString());
                            objE_Ticket.Numero = "0001";
                            objE_Ticket.NumeroPedido = txtNumero.Text;
                            objE_Ticket.IdModuloDespacho = IdModuloDespacho;
                            objE_Ticket.IdDespachador = Convert.ToInt32(txtCodigo.EditValue);
                            objE_Ticket.FechaInicio = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            objE_Ticket.FechaFin = null;// Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            objE_Ticket.IdSituacion = 0;
                            objE_Ticket.FlagDelivery = false;
                            objE_Ticket.FlagEstado = true;
                            objE_Ticket.Usuario = Parametros.strUsuarioLogin;
                            objE_Ticket.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_Ticket.IdEmpresa = Parametros.intEmpresaId;

                            objBL_Ticket.Inserta(objE_Ticket);
                            LimpiarDespacho();
                            txtNumero.Focus();
                        }

                    }
                    else
                    {
                        IdTicketDespacho = objE_Ticket.IdTicketDespacho;

                        if (objE_Ticket.FechaFin == null)
                        {
                            objE_Ticket = new TicketDespachoBE();
                            objE_Ticket.IdTicketDespacho = IdTicketDespacho;
                            objE_Ticket.IdPedido = IdPedido;
                            objE_Ticket.Fecha = Convert.ToDateTime(Parametros.dtFechaHoraServidor.ToShortDateString());
                            objE_Ticket.Numero = "0001";
                            objE_Ticket.NumeroPedido = txtNumero.Text;
                            objE_Ticket.IdModuloDespacho = IdModuloDespacho;
                            objE_Ticket.IdDespachador = Convert.ToInt32(txtCodigo.EditValue);
                            objE_Ticket.FechaInicio = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            objE_Ticket.FechaFin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                            objE_Ticket.IdSituacion = 0;
                            objE_Ticket.FlagDelivery = false;
                            objE_Ticket.FlagEstado = true;
                            objE_Ticket.Usuario = Parametros.strUsuarioLogin;
                            objE_Ticket.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_Ticket.IdEmpresa = Parametros.intEmpresaId;

                            objBL_Ticket.Actualiza(objE_Ticket);
                            LimpiarDespacho();
                            txtNumero.Focus();
                        }
                        else
                        {
                            XtraMessageBox.Show("El pedido ya se despachó", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }


                    //objMovimientoPedido = objBL_MovimientoPedido(IdPedido);
                    //if (objMovimientoPedido.RecepcionDocumento)
                    //{

                    //}
                    //objMovimientoPedido.IdPedido = IdPedido;
                    //objMovimientoPedido.CantidadBulto = 0;
                    //objMovimientoPedido.IdDespachador = Convert.ToInt32(cboDespachador.EditValue);

                    //objBL_MovimientoPedido.ActualizaOrigenDespacho(IdPedido, "Despacho");
                    //objBL_MovimientoPedido.ActualizaDespachador(objMovimientoPedido);
                    //objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intEnAlmacenDespacho, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());


                }
                else
                {
                    XtraMessageBox.Show("No se puede despachar, Por favor verifique si el pedido se encuentra en estado FACTURADO.", this.Text);
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();

                //TicketDespachoBE objE_Ticket = null;
                //objE_Ticket = new TicketDespachoBL().SeleccionaPedido(IdPedido);
                //if(objE_Ticket != null)
                //{
                //    if(objE_Ticket.FechaFin == null)//Finalizar
                //    {
                //        cboDespachador.EditValue = objE_Ticket.IdDespachador;
                //        txtCodigo.EditValue = objE_Ticket.IdDespachador;
                //        txtModulo.EditValue = objE_Ticket.IdModuloDespacho;

                //        txtNumero.Properties.ReadOnly = true;
                //        cboDespachador.Properties.ReadOnly = true;
                //        txtCodigo.Properties.ReadOnly = true;
                //        txtModulo.Properties.ReadOnly = true;

                //        btnDespachar.Focus();

                //    }
                //    else 
                //    {
                //        XtraMessageBox.Show("EL pedido ya fue despachado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}else
                //{
                //    //registrar
                //}




                //txtCodigo.Focus();

            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboDespachador.EditValue = Convert.ToInt32(txtCodigo.Text);
                if (cboDespachador.Text == "")
                {
                    txtCodigo.Text = "";
                    txtCodigo.Select();
                }
                else
                {
                    ModuloDespachoBE objE_Modulo = null;
                    objE_Modulo = new ModuloDespachoBL().SeleccionaDespachador(Convert.ToInt32(txtCodigo.Text));
                    if (objE_Modulo != null)
                    {
                        txtModulo.Text = objE_Modulo.DescModuloDespacho;
                        IdModuloDespacho = objE_Modulo.IdModuloDespacho;
                        btnDespachar.Focus();
                    }
                    else
                    {
                        txtModulo.EditValue = 1;
                        txtModulo.SelectAll();
                    }

                }
            }
        }


        private void btnModicar_Click(object sender, EventArgs e)
        {
            LimpiarDespacho();
            //txtNumero.Properties.ReadOnly = false;
        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaFechaSituacion(deDesde.DateTime, deHasta.DateTime, Convert.ToInt32(cboSituacion.EditValue));
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
            LAable.Text = gvPedido.RowCount.ToString() + " Registros";
        }

        private void CargarBusqueda()
        {
            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim());
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;

            if (mLista.Count > 0)
            {
                if (mLista[0].IdSituacion == Parametros.intFacturado)
                {
                    IdPedido = mLista[0].IdPedido;


                    #region "Despacho"
                    
                    TicketDespachoBE objE_Ticket = null;
                    objE_Ticket = new TicketDespachoBL().SeleccionaPedido(IdPedido);
                    if (objE_Ticket != null)
                    {
                        if (objE_Ticket.FechaFin == null)//Finalizar
                        {
                            cboDespachador.EditValue = objE_Ticket.IdDespachador;
                            txtCodigo.EditValue = objE_Ticket.IdDespachador;
                            txtModulo.EditValue = objE_Ticket.IdModuloDespacho;

                            txtNumero.Properties.ReadOnly = true;
                            cboDespachador.Properties.ReadOnly = true;
                            txtCodigo.Properties.ReadOnly = true;
                            txtModulo.Properties.ReadOnly = true;

                            btnDespachar.Enabled = true;
                            btnDespachar.Focus();

                        }
                        else
                        {
                            XtraMessageBox.Show("EL pedido ya fue despachado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCodigo.SelectAll();
                            return;
                        }
                    }else
                    {
                        //btnDespachar.Enabled = true;
                        HabilitarBotones();
                        txtNumero.Properties.ReadOnly = true;
                        txtCodigo.Select();
                        txtCodigo.SelectAll();
                    }
                    #endregion



                }
                else
                {
                    btnDespachar.Enabled = false;
                    XtraMessageBox.Show("El pedido se encuentra " + mLista[0].DescSituacion + ", el pedido tiene que estar Facturado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtNumero.Select();
                    txtNumero.SelectAll();
                }
            }



        }

        private void CargarDetalles(int IdPedido)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                dtDetalle = FuncionBase.ToDataTable(new PedidoDetalleBL().ListaTodosActivo(IdPedido));
                gcPedidoDetalle.DataSource = dtDetalle;


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //InicializarModificar();
            }
        }

        private void Imprimir()
        {
            frmListaPrinters frmPrinter = new frmListaPrinters();
            if (frmPrinter.ShowDialog() == DialogResult.OK)
            {
                List<ReportePedidoContadoBE> lstReporte = null;
                lstReporte = new ReportePedidoContadoBL().Listado(Parametros.intPeriodo, int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString()), Parametros.intTiendaId);
                if (lstReporte.Count > 0)
                {
                    rptPedidoContado objReporteGuia = new rptPedidoContado();
                    objReporteGuia.SetDataSource(lstReporte);
                    objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                    objReporteGuia.SetParameterValue("Modificado", "()");

                    Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);

                }
            }
        }


        private void LimpiarDespacho()
        {
            btnDespachar.Enabled = false;
            txtNumero.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtModulo.Text = "0";
            cboDespachador.EditValue = 0;
            IdPedido = 0;
            txtNumero.Properties.ReadOnly = false;
        }

        private void HabilitarBotones()
        {
            btnDespachar.Enabled = true;
            txtNumero.Properties.ReadOnly = false;
            txtCodigo.Properties.ReadOnly = false;
            txtModulo.Properties.ReadOnly = false;
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboDespachador.Text == "")
            {
                flag = true;
                strMensaje = strMensaje + "- Seleccionar un despachador.\n";
            }

            if (Convert.ToInt32(txtModulo.EditValue)==0)
            {
                flag = true;
                strMensaje = strMensaje + "- Ingresar módulo.\n";
            }
            
            if(flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion

    }
}