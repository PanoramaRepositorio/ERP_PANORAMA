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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegSeparacion : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<SeparacionBE> mLista = new List<SeparacionBE>();

        int IdCliente = 0;
        
        #endregion

        #region "Eventos"

        public frmRegSeparacion()
        {
            InitializeComponent();
        }

        private void frmRegSeparacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            //try
            //{
            //    if (IdCliente == 0)
            //    {
            //        XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }

            //    frmRegSeparacionEdit objManSeparacion = new frmRegSeparacionEdit();
            //    objManSeparacion.IdCliente = IdCliente;
            //    objManSeparacion.Numero = txtNumeroDocumento.Text;
            //    objManSeparacion.DescCliente = txtDescCliente.Text;
            //    objManSeparacion.TipoCliente = txtTipoCliente.Text;
            //    objManSeparacion.pOperacion = frmRegSeparacionEdit.Operacion.Nuevo;
            //    objManSeparacion.IdSeparacion = 0;
            //    objManSeparacion.StartPosition = FormStartPosition.CenterParent;
            //    objManSeparacion.ShowDialog();
            //    Cargar();

            //    btnBuscar.Focus();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_EditClick()
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            InicializarModificar();

            txtDescCliente.Focus();
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
                        #region "Pedido Auditado"
                        var Pedido = gvSeparacion.GetFocusedRowCellValue("IdPedido");

                        if (Pedido != null)
                        {
                            int IdPedido = 0;
                            IdPedido = int.Parse(gvSeparacion.GetFocusedRowCellValue("IdPedido").ToString());
                            PedidoBE objE_Pedido = null;
                            objE_Pedido = new PedidoBL().Selecciona(Convert.ToInt32(IdPedido));

                            if (objE_Pedido != null)
                            {
                                if (objE_Pedido.FlagAuditado)
                                {
                                    XtraMessageBox.Show("No se puede eliminar, el pedido está auditado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                            }
                        }
                        #endregion

                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            if (frmAutoriza.Usuario == "dhuaman" || frmAutoriza.Usuario == "jzanabria" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ygomez")
                            {
                                string Observacion = "";
                                frmObservacion frmObserva = new frmObservacion();
                                if (frmObserva.ShowDialog() == DialogResult.OK)
                                {
                                    Observacion = frmObserva.strObservacion;
                                }
                                

                                SeparacionBE objE_Separacion = new SeparacionBE();
                                objE_Separacion = new SeparacionBL().Selecciona(Parametros.intEmpresaId, int.Parse(gvSeparacion.GetFocusedRowCellValue("IdSeparacion").ToString()));

                                objE_Separacion.Usuario = Parametros.strUsuarioLogin;
                                objE_Separacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                SeparacionBL objBL_Separacion = new SeparacionBL();
                                objBL_Separacion.Elimina(objE_Separacion);


                                
                                //Insertamos en la auditoria - Estado de cuenta
                                #region "auditoria Eliminacion"
                                
                                    EstadoCuentaHistorialBE objE_EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                                    objE_EstadoCuentaHistorial.IdEstadoCuentaHistorial = 0;
                                    objE_EstadoCuentaHistorial.IdEmpresa = objE_Separacion.IdEmpresa;
                                    objE_EstadoCuentaHistorial.Periodo = objE_Separacion.Periodo;
                                    objE_EstadoCuentaHistorial.IdCliente = objE_Separacion.IdCliente;
                                    objE_EstadoCuentaHistorial.NumeroDocumento = objE_Separacion.NumeroDocumento;
                                    objE_EstadoCuentaHistorial.FechaCredito = objE_Separacion.FechaSeparacion;
                                    objE_EstadoCuentaHistorial.FechaDeposito = objE_Separacion.FechaPago;
                                    objE_EstadoCuentaHistorial.Concepto = objE_Separacion.Concepto;
                                    objE_EstadoCuentaHistorial.FechaVencimiento = objE_Separacion.FechaVencimiento;
                                    objE_EstadoCuentaHistorial.Importe = objE_Separacion.Importe;
                                    objE_EstadoCuentaHistorial.TipoMovimiento = objE_Separacion.TipoMovimiento;
                                    objE_EstadoCuentaHistorial.IdMotivo = objE_Separacion.IdMotivo;
                                    objE_EstadoCuentaHistorial.IdDocumentoVenta = objE_Separacion.IdDocumentoVenta;
                                    objE_EstadoCuentaHistorial.IdCotizacion = objE_Separacion.IdCotizacion;
                                    objE_EstadoCuentaHistorial.IdPedido = objE_Separacion.IdPedido;
                                    objE_EstadoCuentaHistorial.IdMovimientoCaja = objE_Separacion.IdMovimientoCaja;
                                    objE_EstadoCuentaHistorial.Observacion = "";
                                    objE_EstadoCuentaHistorial.ObservacionElimina = Observacion;
                                    objE_EstadoCuentaHistorial.ObservacionOrigen = "E.C. SOLES";
                                    objE_EstadoCuentaHistorial.TipoRegistro = "E";
                                    objE_EstadoCuentaHistorial.FlagEstado = objE_Separacion.FlagEstado;
                                    objE_EstadoCuentaHistorial.Usuario = Parametros.strUsuarioLogin;
                                    objE_EstadoCuentaHistorial.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                    EstadoCuentaHistorialBL objBL_EstadoCuentaHistorial = new EstadoCuentaHistorialBL();
                                    objBL_EstadoCuentaHistorial.Inserta(objE_EstadoCuentaHistorial);
                                #endregion


                                XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                            }
                            else
                            {
                                XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
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

        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoSeparaciones";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSeparacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSeparacion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;

                    txtDescCliente.Focus();
                }

                if (frm.pClienteBE.IdTipoCliente == Parametros.intTipClienteMayorista || frm.pClienteBE.IdClasificacionCliente == Parametros.intBlack)
                {
                    XtraMessageBox.Show("Atención! El cliente es MAYORISTA se recomienda registrar en el estado de cuenta Dolares", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new SeparacionBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
            gcSeparacion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvSeparacion.RowCount > 0)
            {
                SeparacionBE objSeparacion = new SeparacionBE();

                objSeparacion.IdSeparacion = int.Parse(gvSeparacion.GetFocusedRowCellValue("IdSeparacion").ToString());

                frmRegSeparacionEdit objManSeparacionEdit = new frmRegSeparacionEdit();
                objManSeparacionEdit.IdCliente = IdCliente;
                objManSeparacionEdit.Numero = txtNumeroDocumento.Text;
                objManSeparacionEdit.DescCliente = txtDescCliente.Text;
                objManSeparacionEdit.TipoCliente = txtTipoCliente.Text;
                objManSeparacionEdit.pOperacion = frmRegSeparacionEdit.Operacion.Modificar;
                objManSeparacionEdit.IdSeparacion = objSeparacion.IdSeparacion;
                objManSeparacionEdit.StartPosition = FormStartPosition.CenterParent;
                objManSeparacionEdit.ShowDialog();

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

            if (gvSeparacion.GetFocusedRowCellValue("IdSeparacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cliente Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

        private void txtDescCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                tlbMenu_NewClick();
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnBuscar_Click(sender, e);


                //numero o cadena
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                        Cargar();
                        cboMotivo.Focus();

                        //Verificar TipoCliente
                        if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                        {
                            XtraMessageBox.Show("Atención! El cliente es MAYORISTA se recomienda registrar en el estado de cuenta Dolares", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

            }
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumeroDocumento.Focus();
                    return;
                }

                frmRegSeparacionEdit objManSeparacion = new frmRegSeparacionEdit();
                objManSeparacion.IdCliente = IdCliente;
                objManSeparacion.Numero = txtNumeroDocumento.Text;
                objManSeparacion.DescCliente = txtDescCliente.Text;
                objManSeparacion.TipoCliente = txtTipoCliente.Text;
                objManSeparacion.pOperacion = frmRegSeparacionEdit.Operacion.Nuevo;
                objManSeparacion.IdSeparacion = 0;
                objManSeparacion.strTipoMovimiento = "A";
                objManSeparacion.StartPosition = FormStartPosition.CenterParent;
                objManSeparacion.ShowDialog();
                Cargar();

                btnPago.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumeroDocumento.Focus();
                    return;
                }

                frmRegSeparacionEdit objManSeparacion = new frmRegSeparacionEdit();
                objManSeparacion.IdCliente = IdCliente;
                objManSeparacion.Numero = txtNumeroDocumento.Text;
                objManSeparacion.DescCliente = txtDescCliente.Text;
                objManSeparacion.TipoCliente = txtTipoCliente.Text;
                objManSeparacion.pOperacion = frmRegSeparacionEdit.Operacion.Nuevo;
                objManSeparacion.IdSeparacion = 0;
                objManSeparacion.strTipoMovimiento = "C";
                objManSeparacion.StartPosition = FormStartPosition.CenterParent;
                objManSeparacion.ShowDialog();
                Cargar();

                btnCredito.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboMotivo_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }



    }
}