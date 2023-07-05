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
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegControlCalidad : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<PedidoBE> mLista = new List<PedidoBE>();
        private int IdPedido = 0;
        private int IdPedidoCalidad = 0;
        #endregion

        #region "Eventos"
        public frmRegControlCalidad()
        {
            InitializeComponent();
        }

        private void frmRegControlCalidad_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPedidoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intPVAprobado;
            cboSituacion.Enabled = false;
            txtPeriodo.EditValue = DateTime.Now.Year;

            BSUtils.LoaderLook(cboPersonaCalidad, new PersonaBL().SeleccionaAuxiliar(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboPersonaCalidad.EditValue = 0;
            
            txtNumero.Select();
        }

        private void gvPedido_DoubleClick(object sender, EventArgs e)
        {
            //GridView view = (GridView)sender;
            //Point pt = view.GridControl.PointToClient(Control.MousePosition);
            //FilaDoubleClick(view, pt);

            //asignapersonatoolStripMenuItem1_Click(sender, e);
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboSituacion.Text.Trim() == "")
            {
                XtraMessageBox.Show("Debe seleccionar una situación del pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSituacion.Focus();
                return;
            }

            Cargar(0);
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
                Cargar(0);
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

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    cboPersonaCalidad.EditValue = 0;
            //    if (txtCodigo.Text.Length < 5)
            //    {
            //        cboPersonaCalidad.EditValue = Convert.ToInt32(txtCodigo.Text.Trim());
            //    }
            //    else
            //    {
            //        foreach (var item in Parametros.pListaPersonal)
            //        {
            //            if (item.Dni == txtCodigo.Text.Trim())
            //            {
            //                cboPersonaCalidad.EditValue = item.IdPersona;
            //            }
            //        }
            //    }

            //    if (cboPersonaCalidad.Text == "")
            //    {
            //        XtraMessageBox.Show("El código ingresado no existe, por favor verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtCodigo.Text = "";
            //        txtCodigo.Select();
            //    }
            //    else
            //    {
            //        btnCalidad.Focus();
            //    }
            //}
        }


        private void btnModicar_Click(object sender, EventArgs e)
        {
            LimpiarDespacho();
            //txtNumero.Properties.ReadOnly = false;
        }
        #endregion

        #region "Metodos"

        private void Cargar(int TipoConsulta)
        {
            DataTable dtPedido = new DataTable();
            mLista = new PedidoBL().ListaFechaCalidad(deDesde.DateTime, deHasta.DateTime, Convert.ToInt32(cboSituacion.EditValue), TipoConsulta, Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim());
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
            LAable.Text = gvPedido.RowCount.ToString() + " Pedidos";

            if (TipoConsulta == 3 && dtPedido.Rows.Count == 0)
                XtraMessageBox.Show("El N° Pedido no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarBusqueda()
        {
            if (txtNumero.Text.Length < 2)
                return;

            if (txtNumero.Text == "")
            {
                XtraMessageBox.Show("Ingresar un N° de Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return;
            }

            PedidoBE objE_Pedido = null;
            objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim());


            if (objE_Pedido != null)
            {
                IdPedidoCalidad = objE_Pedido.IdPedido;
                txtMensaje.Text = "CLIENTE: " + objE_Pedido.DescCliente;
                //txtMensajePicking.ForeColor = Color.Black;
                //IdPedidoPicking = objE_Pedido.IdPedido;
                //txtDescCliente.Text = objE_Pedido.DescCliente;
                //txtDescVendedor.Text = objE_Pedido.DescVendedor;
                //txtDescTienda.Text = objE_Pedido.DescTienda;
                //txtDescSituacion.Text = objE_Pedido.DescSituacion;
                //txtDescFormaPago.Text = objE_Pedido.DescFormaPago;
                //txtObservacion.Text = objE_Pedido.Observacion;
                //txtMensajePicking.Text = "Ud. Puede Iniciar Picking";

                //verificar ingreso de N/S
                #region "Validar Nota de Salida Pendiente"

                List<MovimientoAlmacenBE> lst_MovimientoNS = new List<MovimientoAlmacenBE>();
                lst_MovimientoNS = new MovimientoAlmacenBL().ListaNotaSalidaPendientePedido(objE_Pedido.IdPedido);

                if (lst_MovimientoNS.Count > 0)
                {
                    string NumeroNS = "";
                    foreach (var item in lst_MovimientoNS)
                    {
                        NumeroNS = NumeroNS + ", " + item.DescAlmacen + ":" + item.Numero;
                    }
                    XtraMessageBox.Show("No se puede iniciar el control de calidad, falta recibir el stock Físico N/S." + NumeroNS, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                MovimientoPedidoBE objBE_MovimientoPedidoCalidad = null;
                MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                //Verifica situación
                objBE_MovimientoPedidoCalidad = objBL_MovimientoPedido.Selecciona(objE_Pedido.IdPedido);

                if (objE_Pedido.IdFormaPago != Parametros.intContado) //add 02012018
                {
                    if (!objBE_MovimientoPedidoCalidad.Recibido) ///add 170816
                    {
                        XtraMessageBox.Show("No se puede iniciar el Control de Calidad, verificar que el pedido haya pasado por Picking.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (objBE_MovimientoPedidoCalidad.FlagIniCalidad == false) //inicio
                {
                    cboPersonaCalidad.EditValue = 0;
                    btnCalidad.Enabled = true;
                    btnCalidad.Text = "Iniciar Control de Calidad";
                    btnCalidad.Font = new Font(btnCalidad.Font, FontStyle.Bold);
                    btnCalidad.ForeColor = Color.Green;
                    btnCalidad.Focus();
                    //txtCodigo.Select();
                    //txtCodigo.SelectAll();
                }
                else //Fin
                {
                    if (objBE_MovimientoPedidoCalidad.FlagFinCalidad == false)
                    {
                        txtMensaje.Text = "N/P " + objBE_MovimientoPedidoCalidad.Numero + "   INICIÓ: " + objBE_MovimientoPedidoCalidad.FechaIniCalidad.ToString().Substring(0, 19);
                        cboPersonaCalidad.EditValue = objBE_MovimientoPedidoCalidad.IdPersonaCalidad;
                        btnCalidad.Enabled = true;
                        btnCalidad.Text = "Finalizar Control de Calidad";
                        btnCalidad.Font = new Font(btnCalidad.Font, FontStyle.Bold);
                        btnCalidad.ForeColor = Color.Blue;
                        btnCalidad.Focus();
                    }
                    else
                    {
                        txtMensaje.Text = "N/P " + objBE_MovimientoPedidoCalidad.Numero + "   INICIÓ: " +  objBE_MovimientoPedidoCalidad.FechaIniCalidad.ToString().Substring(0,19) + " | FINALIZÓ: " + objBE_MovimientoPedidoCalidad.FechaFinCalidad.ToString().Substring(0, 19);// + "\nEjecutado por: : " + objBE_MovimientoPedidoCalidad.DescPersonaCalidad);
                        btnCalidad.Enabled = false;
                        //btnCalidad.Text = "Iniciar Control de Calidad";
                        //btnCalidad.Font = new Font(btnCalidad.Font, FontStyle.Regular);
                        //btnCalidad.ForeColor = Color.Black;
                        Cargar(3);

                        txtNumero.Select();
                        txtNumero.SelectAll();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCalidad.Enabled = false;
                txtNumero.Select();
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
            btnCalidad.Enabled = false;
            txtNumero.Text = string.Empty;
            //txtCodigo.Text = string.Empty;
            cboPersonaCalidad.EditValue = 0;
            IdPedido = 0;
            txtNumero.Properties.ReadOnly = false;
        }

        private void HabilitarBotones()
        {
            btnCalidad.Enabled = true;
            txtNumero.Properties.ReadOnly = false;
            //txtCodigo.Properties.ReadOnly = false;
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboPersonaCalidad.Text == "")
            {
                flag = true;
                strMensaje = strMensaje + "- Seleccionar un despachador.\n";
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion

        private void btnCalidad_Click(object sender, EventArgs e)
        {
            if(btnCalidad.Text == "Iniciar Control de Calidad")
            {
                if (IdPedidoCalidad > 0)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (!frmAutoriza.Edita)
                    {
                        Cursor = Cursors.Default;
                        return;
                    }
                    if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                    {
                        Cursor = Cursors.Default;
                        XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                        return;
                    }
                    cboPersonaCalidad.EditValue = frmAutoriza.IdPersona;
                    cboPersonaCalidad.Properties.ReadOnly = true;


                    if (cboPersonaCalidad.Text == "")
                    {
                        XtraMessageBox.Show("Seleccionar el nombre del Personal de Control de Calidad!.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }


                    MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                    objBE_MovimientoPedido.IdPedido = IdPedidoCalidad;
                    objBE_MovimientoPedido.IdPersonaCalidad = Convert.ToInt32(cboPersonaCalidad.EditValue);
                    objBE_MovimientoPedido.FlagFinCalidad = true;
                    objBE_MovimientoPedido.FlagCierre = false;
                    objBL_MovimientoPedido.ActualizaCierreCalidad(objBE_MovimientoPedido);

                    btnCalidad.Enabled = false;
                    txtMensaje.Text = "El pedido " + txtNumero.Text + " Inició Control de Calidad a las " + DateTime.Now.ToLongTimeString();
                    //txtCodigo.EditValue = "";
                    txtNumero.EditValue = "";
                    cboPersonaCalidad.EditValue = 0;
                    IdPedidoCalidad = 0;
                    txtNumero.Select();

                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else //Finalizar
            {
                if (IdPedidoCalidad > 0)
                {
                    MovimientoPedidoBE objBE_MovimientoPedido = new MovimientoPedidoBE();
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                    objBE_MovimientoPedido.IdPedido = IdPedidoCalidad;
                    objBE_MovimientoPedido.IdPersonaCalidad = Convert.ToInt32(cboPersonaCalidad.EditValue);
                    objBE_MovimientoPedido.FlagFinCalidad = true;
                    objBE_MovimientoPedido.FlagCierre = true;
                    objBL_MovimientoPedido.ActualizaCierreCalidad(objBE_MovimientoPedido);
                    btnCalidad.Enabled = false;
                    txtMensaje.Text = "El pedido N° " + txtNumero.Text + " Finalizó Control de Calidad a  las " + DateTime.Now.ToLongTimeString(); ;
                    //txtCodigo.EditValue = "";
                    txtNumero.Text = "";
                    IdPedidoCalidad = 0;
                    cboPersonaCalidad.EditValue = 0;
                    txtNumero.Select();
                }
                else
                {
                    XtraMessageBox.Show("El N° Pedido no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1) {
                txtNumero.Select();
                txtNumero.SelectAll();
            }

            
            //if (keyData == Keys.Escape) this.Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaCC_" + deDesde.DateTime.ToString("yyyy_MM_dd") + "_To_" + deHasta.DateTime.ToString("yyyy_MM_dd");
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

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}