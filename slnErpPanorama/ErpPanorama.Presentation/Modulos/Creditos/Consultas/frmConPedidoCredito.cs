using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Creditos.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    public partial class frmConPedidoCredito : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PedidoBE> mLista = new List<PedidoBE>();
        private List<PedidoDetalleBE> mListaPedidoDetalle = new List<PedidoDetalleBE>();

        #endregion

        #region "Eventos"

        public frmConPedidoCredito()
        {
            InitializeComponent();
        }

        private void frmConPedidoCredito_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            Cargar();

            txtPeriodo.EditValue = DateTime.Now.Year;
        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {

        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
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
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtPedido = new DataTable();
                dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaCreditoNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim()));
                if (dtPedido.Rows.Count > 0)
                {
                    gcPedido.DataSource = dtPedido;
                    btnConsultar.Focus();
                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            
        }

        private void aprobarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedido.RowCount > 0)
                {
                    int IdPedido = 0;
                    string NumeroDoc = "";
                    int IdTipoCliente = 0;
                    int IdClasificacionCliente = 0;

                    IdPedido                = int.Parse(gvPedido.GetFocusedRowCellValue("IdPedido").ToString());
                    NumeroDoc               = gvPedido.GetFocusedRowCellValue("NumDocumento").ToString();
                    IdTipoCliente           = int.Parse(gvPedido.GetFocusedRowCellValue("IdTipoCliente").ToString());
                    IdClasificacionCliente  = int.Parse(gvPedido.GetFocusedRowCellValue("IdClasificacionCliente").ToString());

                    //
                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal) && IdClasificacionCliente == Parametros.intBlack &&   Parametros.intPerfilId == 14)  // Perfil de administrador de tienda
                    {
                        XtraMessageBox.Show("Usted no puede aprobar pedidos de clientes BLACK.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //else if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal) && IdClasificacionCliente == Parametros.intBlack && Parametros.intPerfilId == 14)
                    //{

                    //}

                    MovimientoPedidoBE objE_Movimiento = null;
                    objE_Movimiento = new MovimientoPedidoBL().Selecciona(IdPedido);

                    if (objE_Movimiento != null)
                    {
                        if (objE_Movimiento.FechaDespacho2 == null)
                        {
                            XtraMessageBox.Show("El pedido no tiene fecha de Delivery.\nPara más información consultar con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //return;
                        }
                    }
                    //PersonaBE objE_Personal = null;
                    //objE_Personal = new PersonaBL().SeleccionaNumeroDocumentoPersonal(NumeroDoc);

                    frmRegAprobacionPedidoEdit objManBanco = new frmRegAprobacionPedidoEdit();
                    //if (objE_Personal != null)
                    //{ objManBanco.vPersonaCliente = 1; }

                        objManBanco.IdPedido = IdPedido;
                        objManBanco.StartPosition = FormStartPosition.CenterParent;
                        objManBanco.vIdTipoCliente = IdTipoCliente;
                        objManBanco.vIdClasificacionCliente = IdClasificacionCliente;

                        objManBanco.ShowDialog();

                        Cargar();
                        CargarDetalles(0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolstpExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPedido";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPedido.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void gvPedido_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPedido.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["DisponiblePorcentaje"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento >= Convert.ToDecimal(0.5))
                        {
                            gvPedido.Columns["DisponiblePorcentaje"].AppearanceCell.BackColor = Color.Green;
                            gvPedido.Columns["DisponiblePorcentaje"].AppearanceCell.BackColor2 = Color.SeaShell;
                            //e.Appearance.BackColor = Color.Green; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento >= Convert.ToDecimal(0.2) && IdTipoDocumento < Convert.ToDecimal(0.5))
                        {
                            gvPedido.Columns["DisponiblePorcentaje"].AppearanceCell.BackColor = Color.Orange;
                            gvPedido.Columns["DisponiblePorcentaje"].AppearanceCell.BackColor2 = Color.SeaShell;

                            //e.Appearance.BackColor = Color.Orange; //DarkSeaGreen;
                            //e.Appearance.BackColor2 = Color.SeaShell; //Aprobado
                        }

                        if (IdTipoDocumento < Convert.ToDecimal(0.2))
                        {
                            gvPedido.Columns["DisponiblePorcentaje"].AppearanceCell.BackColor = Color.Red;
                            gvPedido.Columns["DisponiblePorcentaje"].AppearanceCell.BackColor2 = Color.SeaShell;

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

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int TipoReporte = 0;
            if (chkPendiente.Checked)
                TipoReporte = 1;

            DataTable dtPedido = new DataTable();
            dtPedido = FuncionBase.ToDataTable(new PedidoBL().ListaCredito(deDesde.DateTime, deHasta.DateTime, TipoReporte));
            gcPedido.DataSource = dtPedido;

            txtTotal.Text = dtPedido.Rows.Count.ToString();
        }

        private void CargarDetalles(int IdPedido)
        {
            try
            {
                DataTable dtDetalle = new DataTable();
                mListaPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);
                dtDetalle = FuncionBase.ToDataTable(mListaPedidoDetalle);
                gcPedidoDetalle.DataSource = dtDetalle;


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        private void gvPedido_ColumnFilterChanged(object sender, EventArgs e)
        {
            txtTotal.Text = gvPedido.RowCount.ToString();
        }

        private void verestadocuentatoolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}