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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegAprobacionPedidoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        int _IdPedido = 0;
        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }
        public int IdPersona =0 ;
        public int vPersonaCliente = 0;
        public int vIdTipoCliente = 0;
        public int vIdClasificacionCliente = 0;
        #endregion

        #region "Eventos"
        public frmRegAprobacionPedidoEdit()
        {
            InitializeComponent();
        }

        private void frmRegAprobacionPedidoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionPedidoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intPVAprobado;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoBL objBL_Pedido = new PedidoBL();
                PedidoBE objE_Pedido = null;
                objE_Pedido = objBL_Pedido.Selecciona(IdPedido);
                if (objE_Pedido.IdSituacion == Parametros.intPVAnulado)//add 17 jun
                {
                    XtraMessageBox.Show("No se puede recuperar un pedido anulado, tiene que generar una copia de pedido,", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (objE_Pedido.IdFormaPago == Parametros.intContado)
                {
                    XtraMessageBox.Show("Por enésima vez "+Parametros.strUsuarioNombres +", No se puede aprobar un pedido contado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intPVDespachado)
                {
                    
                    if (Parametros.strUsuarioLogin == "jvasquez" || Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "rpalarcon" 
                        || Parametros.strUsuarioLogin == "dhuaman" || Parametros.strUsuarioLogin == "kconcha" || Parametros.strUsuarioLogin == "mmurrugarra"
                        || Parametros.strUsuarioLogin == "focampo" || Parametros.strUsuarioLogin == "ygomez" || Parametros.strUsuarioLogin == "focampo"
                        || Parametros.intPerfilId == Parametros.intPerAnalistaInventario)
                    {
                        objBL_Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, IdPedido, Convert.ToInt32(cboSituacion.EditValue), 0, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("El usuario no esta autorizado para establecer un pedido despachado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                //Bloquear Pedido A Generado -----------------------------
                MovimientoPedidoBE objE_MovimientoPedido = null;
                objE_MovimientoPedido = new MovimientoPedidoBL().SeleccionaChequeo(IdPedido);
                if (objE_MovimientoPedido != null)
                {
                    if (objE_MovimientoPedido.IdAuxiliar > 0)
                    {
                        XtraMessageBox.Show("El Pedido está en preparación por:" + objE_MovimientoPedido.DescAuxiliar + ", no puede volver a GENERADO, Almacén debe autorizar la modificación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (Convert.ToInt32(cboSituacion.EditValue) == Parametros.intPVAprobado)
                {                 
                    //Cliente con observación  --ADD
                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, objE_Pedido.IdCliente);
                    if (objE_Cliente.FlagSuspendido == true)
                    {
                        XtraMessageBox.Show("No se pudo registrar:\n" + "- El cliente está suspendido, no se puede aprobar, por favor verifique con el Area de Créditos.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.vsn2 = vPersonaCliente;

                    frmAutoriza.ShowDialog();

                    if (vIdTipoCliente == Parametros.intTipClienteFinal && vIdClasificacionCliente == Parametros.intBlack && frmAutoriza.IdPerfil != Parametros.intPerJefeRRHH && Parametros.intPerfilId != 1)
                    {
                        XtraMessageBox.Show("Usted no esta autorizado para aprobar pedidos de Clientes Black.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (objE_Pedido.IdFormaPago == Parametros.intObsequio && (frmAutoriza.IdPerfil  == Parametros.intPerAdministradorTienda || frmAutoriza.IdPerfil == Parametros.intPerJefeCanalMayorista))
                    {
                        XtraMessageBox.Show("Usted no esta autorizado para aprobar pedidos de Obsequio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    if (frmAutoriza.Edita)
                    {
                        if (    frmAutoriza.Usuario == "master" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerAsistenteFacturacion || 
                            frmAutoriza.IdPerfil == Parametros.intPerAsistenteCompras || frmAutoriza.Usuario == "aflores" || frmAutoriza.Usuario == "jlquispe")                                 
                              {
                                    IdPersona = frmAutoriza.IdPersona;

                                    if (objE_Pedido.IdFormaPago == Parametros.intCredito)
                                    {
                                        ClienteCreditoBE objE_ClienteCredito = null;
                                        objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, objE_Pedido.IdCliente, objE_Pedido.IdMotivo);
                                        if (objE_ClienteCredito == null)
                                        {
                                            XtraMessageBox.Show("No se pudo registrar:\n" + "- El cliente seleccionado no tiene una linea de crédito aprobada..por favor verifique con el Area de Créditos.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else
                                        {
                                            if (!objE_Pedido.FlagPreVenta)
                                            {
                                                if (Convert.ToDecimal(objE_Pedido.Total) > objE_ClienteCredito.LineaCreditoDisponible)
                                                {
                                                    XtraMessageBox.Show("No se pudo registrar:\n" + "- El cliente seleccionado excede en su linea de credito disponible..por favor verifique con el Area de Créditos.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                    if (XtraMessageBox.Show("Está seguro de Aprobar el Pedido aún sabiendo que excede el Monto Permitido? \n. Consultar con Cliente-Vendedor", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                                    {
                                                        objBL_Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, IdPedido, Convert.ToInt32(cboSituacion.EditValue), IdPersona, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                                                        ImprimirUbicacionPedido();
                                                        this.Close();
                                                    }
                                                    else
                                                    {
                                                        this.Close();
                                                        return;
                                                    }
                                                    return;
                                                }
                                            }
                                        }

                                        objBL_Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, IdPedido, Convert.ToInt32(cboSituacion.EditValue), IdPersona, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                                        ImprimirUbicacionPedido();
                            }
                            else
                            {
                                objBL_Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, IdPedido, Convert.ToInt32(cboSituacion.EditValue), IdPersona, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                                ImprimirUbicacionPedido();
                            }
                        }
                        else if (frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerAsistenteFacturacion ||
                                  frmAutoriza.IdPerfil == Parametros.intPerJefeMarketingPublicidad || frmAutoriza.Usuario == "kconcha" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "focampo" || frmAutoriza.Usuario == "ygomez" || frmAutoriza.Usuario == "aflores" || frmAutoriza.Usuario == "jlquispe"
                                  || frmAutoriza.IdPerfil == Parametros.intPerSupervisorDiseno || frmAutoriza.IdPerfil == Parametros.intPerAdministradorTienda || frmAutoriza.IdPerfil == Parametros.intPerJefeCanalMayorista  || frmAutoriza.IdPerfil == Parametros.intPerAsistenteCompras)
                            {
                                    IdPersona = frmAutoriza.IdPersona;

                                if (objE_Pedido.IdFormaPago == Parametros.intCredito || objE_Pedido.IdFormaPago == Parametros.intConsignacion)
                                {
                                    XtraMessageBox.Show("Usted no esta autorizado para aprobar un pedido de CREDITO/CONSIGNACION, Por favor comuníquese con el área de Créditos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    objBL_Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, IdPedido, Convert.ToInt32(cboSituacion.EditValue), IdPersona, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                                    ImprimirUbicacionPedido();
                                }
                            }
                        else
                            {
                                XtraMessageBox.Show("El usuario no esta autorizado para aprobar pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                    }
                    this.Close();
                    return;
                }


                //PedidoBL objBL_Pedido = new PedidoBL();
                if (Convert.ToInt32(cboSituacion.EditValue) != Parametros.intPVAprobado)
                {


                    if (Convert.ToInt32(cboSituacion.EditValue) != Parametros.intPVAnulado) //Add
                    {
                        if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerJefeAlmacen || Parametros.strUsuarioLogin == "ygomez" 
                            || Parametros.strUsuarioLogin == "mmurrugarra" || Parametros.strUsuarioLogin == "focampo" || Parametros.strUsuarioLogin == "aflores" || Parametros.strUsuarioLogin == "jlquispe")
                        {
                            objBL_Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, IdPedido, Convert.ToInt32(cboSituacion.EditValue), IdPersona, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                            this.Close();
                        }
                    }
                    else
                    {
                        return;
                    }
                    objBL_Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, IdPedido, Convert.ToInt32(cboSituacion.EditValue), IdPersona, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

                }
                else
                {
                    XtraMessageBox.Show("El usuario no esta autorizado para Cambiar situación de pedido.\nConsultar con el Jefe de Almacén, para autorizar este cambio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

               this.Close();
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

        private void ImprimirUbicacionPedido()
        {
            //Imprimir Pedido
            frmListaPrinters frmPrinter = new frmListaPrinters();
            frmPrinter.bEstadoCopias = true;
            if (frmPrinter.ShowDialog() == DialogResult.OK)
            {
                List<ReportePedidoContadoBE> lstReporte = null;
                lstReporte = new ReportePedidoContadoBL().Listado(Parametros.intPeriodo, IdPedido, Parametros.intTiendaId);
                if (lstReporte.Count > 0)
                {
                    rptPedidoContado objReporteGuia = new rptPedidoContado();
                    objReporteGuia.SetDataSource(lstReporte);
                    objReporteGuia.SetParameterValue("Equipo", WindowsIdentity.GetCurrent().Name.ToString());
                    objReporteGuia.SetParameterValue("Usuario", Parametros.strUsuarioLogin);
                    objReporteGuia.SetParameterValue("Modificado", "()");
                    Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, frmPrinter.intCopias, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                    //Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                }

                //Agregar Auditoria de Impresión

            }
        }

        #endregion
    }
}