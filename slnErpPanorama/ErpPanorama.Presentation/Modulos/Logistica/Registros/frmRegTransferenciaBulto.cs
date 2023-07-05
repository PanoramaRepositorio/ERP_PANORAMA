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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegTransferenciaBulto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<BultoBE> mLista = new List<BultoBE>();

        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;
        private string UsuarioSalida = "";

        #endregion

        #region "Eventos"

        public frmRegTransferenciaBulto()
        {
            InitializeComponent();
        }

        private void frmRegTransferenciaBulto_Load(object sender, EventArgs e)
        {
            intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            CalcularPaginas();
            CargarBusqueda(intPagina, intRegistrosPorPagina);
            HabilitarBotones(false, false, true, true);

            CargarBusqueda();

            txtNumero.Focus();
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaBultosRecibidos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBulto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    BultoBE objE_Bulto = null;
                    objE_Bulto = new BultoBL().SeleccionaNumeroBulto(Parametros.intEmpresaId, txtNumero.Text.Trim(), Parametros.intBULRecibido);
                    if (objE_Bulto != null)
                    {
                        if (!objE_Bulto.FlagTransito)
                        {
                            lblMensaje.Text = "El bulto N° " + objE_Bulto.NumeroBulto + " no se encuentra en tránsito, Verificar.\n";
                            return;
                        }

                        txtProducto.EditValue = objE_Bulto.CodigoProveedor + "  ||  " + objE_Bulto.NombreProducto;

                        //Establecer Los Datos de Cabecera de la Transferencia del Bulto
                        TransferenciaBultoBE objE_TransferenciaBulto = new TransferenciaBultoBE();
                        objE_TransferenciaBulto.IdTransferenciaBulto = 0;
                        objE_TransferenciaBulto.IdEmpresa = Parametros.intEmpresaId;
                        objE_TransferenciaBulto.IdTienda = Parametros.intTiendaId;
                        objE_TransferenciaBulto.Periodo = Parametros.intPeriodo;
                        objE_TransferenciaBulto.IdTipoDocumento = Parametros.intTipoDocTransferencia;
                        objE_TransferenciaBulto.NumeroDocumento = ObtenerCorrelativo();
                        objE_TransferenciaBulto.FechaMovimiento = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        objE_TransferenciaBulto.IdAlmacenOrigen = Parametros.intAlmBultos;
                        objE_TransferenciaBulto.IdAlmacenDestino = Parametros.intAlmAnaqueles;//.intAlmCentralUcayali;
                        objE_TransferenciaBulto.Observacion = "Transferencia de Bultos";
                        objE_TransferenciaBulto.IdMovimientoAlmacenIngreso = 0;
                        objE_TransferenciaBulto.IdMovimientoAlmacenSalida = 0;
                        objE_TransferenciaBulto.FlagEstado = true;
                        objE_TransferenciaBulto.Usuario = UsuarioSalida;// Parametros.strUsuarioLogin;
                        objE_TransferenciaBulto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        List<TransferenciaBultoDetalleBE> lstListaTransferenciaDetalle = new List<TransferenciaBultoDetalleBE>();

                        //Establecer los datos del detalle de la transferencia de bultos
                        TransferenciaBultoDetalleBE objE_DetalleTransferencia = new TransferenciaBultoDetalleBE();
                        objE_DetalleTransferencia.IdTransferenciaBultoDetalle = 0;
                        objE_DetalleTransferencia.IdTransferenciaBulto = 0;
                        objE_DetalleTransferencia.IdBulto = objE_Bulto.IdBulto;
                        objE_DetalleTransferencia.IdProducto = objE_Bulto.IdProducto;
                        objE_DetalleTransferencia.Cantidad = objE_Bulto.Cantidad;
                        objE_DetalleTransferencia.IdKardexBulto = 0;
                        objE_DetalleTransferencia.IdKardex = 0;
                        objE_DetalleTransferencia.FlagEstado = true;
                        objE_DetalleTransferencia.Abreviatura = objE_Bulto.Abreviatura;
                        objE_DetalleTransferencia.PrecioUnitario = objE_Bulto.PrecioUnitario;
                        objE_DetalleTransferencia.Usuario = UsuarioSalida;// Parametros.strUsuarioLogin;
                        objE_DetalleTransferencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_DetalleTransferencia.IdEmpresa = Parametros.intEmpresaId;
                        lstListaTransferenciaDetalle.Add(objE_DetalleTransferencia);

                        //Realizamos la transferencia de bultos
                        TransferenciaBultoBL objBL_TransferenciaBulto = new TransferenciaBultoBL();
                        objBL_TransferenciaBulto.Inserta(objE_TransferenciaBulto, lstListaTransferenciaDetalle);

                        XtraMessageBox.Show("El Bulto se descargó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNumero.Text = "";
                        txtNumero.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("El numero de bulto no existe por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //gcBulto.DataSource = new BultoBL().ListaNumeroBulto();
                    //gcBulto.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text.ToString().Trim().Length > 2)
            {
                CargarBusqueda();
            }

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaPrimero;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            cboPagina.EditValue = intPagina;

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            intPagina = intPagina - 1;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPagina = intPagina + 1;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaUltima;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            intPagina = int.Parse(cboPagina.EditValue.ToString());
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
            CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidadRegistros.Text.Length > 0)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            }
        }

        #endregion

        #region "Metodos"

        private void CargarBusqueda(int pagina, int registros)
        {

            gcBulto.DataSource = new BultoBL().ListaRecibidos(Parametros.intEmpresaId, txtProducto.Text, pagina, registros);
            gcBulto.RefreshDataSource();
        }

        private void CargarBusqueda()
        {

            gcBulto.DataSource = new BultoBL().ListaRecibidos(Parametros.intEmpresaId, txtProducto.Text, intPaginaPrimero, intRegistrosPorPagina);
            gcBulto.RefreshDataSource();

           
            CalcularPaginas();
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);

        }

        private void CalcularPaginas()
        {
            cboPagina.Properties.Items.Clear();
            intRegistrosTotal = CantidadRegistros();
            if (intRegistrosTotal > 0)
            {
                intPaginaUltima = intRegistrosTotal / intRegistrosPorPagina;
                int Residuo = intRegistrosTotal % intRegistrosPorPagina;
                if (Residuo > 0)
                    intPaginaUltima += 1;
                for (int i = 0; i < intPaginaUltima; i++)
                {
                    cboPagina.Properties.Items.Add(i + 1);
                }
                cboPagina.SelectedIndex = 0;
            }
        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            btnFirst.Enabled = bolFirst;
            btnPrevious.Enabled = bolPrevious;
            btnNext.Enabled = bolNext;
            btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            intRowCount = new BultoBL().ListaRecibidosCount(Parametros.intEmpresaId, txtProducto.Text);
            return intRowCount;
        }

        private string ObtenerCorrelativo()
        {
            List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
            string sNumero = "";
            mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocTransferencia, Parametros.intPeriodo);
            if (mListaNumero.Count > 0)
            {
                sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
            }

            return sNumero;
        }


        #endregion

        private void frmRegTransferenciaBulto_Shown(object sender, EventArgs e)
        {
            bool bolFlag = false;
            //string Usuario = Parametros.strUsuarioLogin;
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (!frmAutoriza.Edita)
            {
                Cursor = Cursors.Default;
                bolFlag = true;
            }

            if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                bolFlag = true;
            }

            UsuarioSalida = frmAutoriza.Usuario;
            lblMensajeDescarga.Text = "Descargando bultos como: " + UsuarioSalida;

            if (bolFlag)
            {
                this.Close();
            }

        }
    }
}