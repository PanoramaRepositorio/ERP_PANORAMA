using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManParametro : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<ParametroBE> mLista = new List<ParametroBE>();
        private ParametroBE objE_ParametroStock = null;
        private ParametroBE objE_ParametroStockPreventa = null;
        private ParametroBE objE_ParametroValidaReniec= null;
        private ParametroBE objE_ParametroValidaSunat = null;
        private ParametroBE objE_ParametroValidaStockDetallePedido = null;
        private ParametroBE objE_ParametroValidarPINUsuario = null;
        private ParametroBE objE_ParametroValidarFechaServidor = null;
        private ParametroBE objE_ParametroImpresionPedidoDirecto = null;
        private ParametroBE objE_ParametroImpresionSPDirecto = null;
        private ParametroBE objE_ParametroOnlineBBEE = null;
        private ParametroBE objE_ParametroOnlineFFEE = null;



        #endregion

        #region "Eventos"

        public frmManParametro()
        {
            InitializeComponent();
        }

        private void frmManParametro_Load(object sender, EventArgs e)
        {

            //List<ParametroBE> lstParametro = new List<ParametroBE>();
            //lstParametro = new ParametroBL().ListaTodosActivo();

            //foreach (ParametroBE item in lstParametro)
            //{
            //    if (item.IdParametro == "StockNegativo")
            //    {
            //        chkStockNegativo.Tag = item.IdParametro;
            //        chkStockNegativo.Checked = item.FlagEstado;
            //        chkStockNegativo.ToolTip = item.Descripcion;
            //    }
            //    if (item.IdParametro == "StockNegativoPreventa")
            //    {
            //        chkStockNegativoPreventa.Tag = item.IdParametro;
            //        chkStockNegativoPreventa.Checked = item.FlagEstado;
            //        chkStockNegativoPreventa.ToolTip = item.Descripcion;
            //    }
            //    if (item.IdParametro == "ConsultasReniec")
            //    {
            //        chkConsultaReniec.Tag = item.IdParametro;
            //        chkConsultaReniec.Checked = item.FlagEstado;
            //        chkConsultaReniec.ToolTip = item.Descripcion;
            //    }
            //    if (item.IdParametro == "ConsultasSunat")
            //    {
            //        chkConsultaSunat.Tag = item.IdParametro;
            //        chkConsultaSunat.Checked = item.FlagEstado;
            //        chkConsultaSunat.ToolTip = item.Descripcion;
            //    }

            //    if (item.IdParametro == "ValidarStockDetallePedido")
            //    {
            //        chkValidarStockDetallePedido.Tag = item.IdParametro;
            //        chkValidarStockDetallePedido.Checked = item.FlagEstado;
            //        chkValidarStockDetallePedido.ToolTip = item.Descripcion;
            //    }
            //    if (item.IdParametro == "ValidarPINUsuario")
            //    {
            //        chkValidarPIN.Tag = item.IdParametro;
            //        chkValidarPIN.Checked = item.FlagEstado;
            //        chkValidarPIN.ToolTip = item.Descripcion;
            //    }

            //    if (item.IdParametro == "ValidarFechaServidor")
            //    {
            //        chkValidarFechaServidor.Tag = item.IdParametro;
            //        chkValidarFechaServidor.Checked = item.FlagEstado;
            //        chkValidarFechaServidor.ToolTip = item.Descripcion;
            //    }
            //}

            objE_ParametroStock = new ParametroBL().Selecciona("StockNegativo");
            if (objE_ParametroStock != null)
            {
                chkStockNegativo.Checked = objE_ParametroStock.FlagEstado;
                chkStockNegativo.ToolTip = objE_ParametroStock.Descripcion;
            }

            objE_ParametroStockPreventa = new ParametroBL().Selecciona("StockNegativoPreventa");
            if (objE_ParametroStockPreventa != null)
            {
                chkStockNegativoPreventa.Checked = objE_ParametroStockPreventa.FlagEstado;
                chkStockNegativoPreventa.ToolTip = objE_ParametroStockPreventa.Descripcion;
            }


            objE_ParametroValidaReniec = new ParametroBL().Selecciona("ConsultasReniec");
            if (objE_ParametroValidaReniec != null)
            {
                chkConsultaReniec.Checked = objE_ParametroValidaReniec.FlagEstado;
                chkConsultaReniec.ToolTip = objE_ParametroValidaReniec.Descripcion;
            }

            objE_ParametroValidaSunat = new ParametroBL().Selecciona("ConsultasSunat");
            if (objE_ParametroValidaSunat != null)
            {
                chkConsultaSunat.Checked = objE_ParametroValidaSunat.FlagEstado;
                chkConsultaSunat.ToolTip = objE_ParametroValidaSunat.Descripcion;
            }

            objE_ParametroValidaStockDetallePedido = new ParametroBL().Selecciona("ValidarStockDetallePedido");
            if (objE_ParametroValidaStockDetallePedido != null)
            {
                chkValidarStockDetallePedido.Checked = objE_ParametroValidaStockDetallePedido.FlagEstado;
                chkValidarStockDetallePedido.ToolTip = objE_ParametroValidaStockDetallePedido.Descripcion;
            }


            objE_ParametroValidarPINUsuario = new ParametroBL().Selecciona("ValidarPINUsuario");
            if (objE_ParametroValidarPINUsuario != null)
            {
                chkValidarPIN.Checked = objE_ParametroValidarPINUsuario.FlagEstado;
                chkValidarPIN.ToolTip = objE_ParametroValidarPINUsuario.Descripcion;
            }

            objE_ParametroValidarFechaServidor = new ParametroBL().Selecciona("ValidarFechaServidor");
            if (objE_ParametroValidarFechaServidor != null)
            {
                chkValidarFechaServidor.Checked = objE_ParametroValidarFechaServidor.FlagEstado;
                chkValidarFechaServidor.ToolTip = objE_ParametroValidarFechaServidor.Descripcion;
            }

            objE_ParametroImpresionPedidoDirecto = new ParametroBL().Selecciona("ImpresionPedidoDirecto");
            if (objE_ParametroImpresionPedidoDirecto != null)
            {
                chkImpresionDirectaPedido.Checked = objE_ParametroImpresionPedidoDirecto.FlagEstado;
                chkImpresionDirectaPedido.ToolTip = objE_ParametroImpresionPedidoDirecto.Descripcion;
            }


            objE_ParametroImpresionSPDirecto = new ParametroBL().Selecciona("ImpresionSolicitudDirecto");
            if (objE_ParametroImpresionSPDirecto != null)
            {
                chkImpresionDirectaSP.Checked = objE_ParametroImpresionSPDirecto.FlagEstado;
                chkImpresionDirectaSP.ToolTip = objE_ParametroImpresionSPDirecto.Descripcion;
            }

            objE_ParametroOnlineBBEE = new ParametroBL().Selecciona("OnlineBoletaElectronica");
            if (objE_ParametroOnlineBBEE != null)
            {
                chkOnlineBE.Checked = objE_ParametroOnlineBBEE.FlagEstado;
                chkOnlineBE.ToolTip = objE_ParametroOnlineBBEE.Descripcion;
            }
            objE_ParametroOnlineFFEE = new ParametroBL().Selecciona("OnlineFacturaElectronica");
            if (objE_ParametroOnlineFFEE != null)
            {
                chkOnlineFE.Checked = objE_ParametroOnlineFFEE.FlagEstado;
                chkOnlineFE.ToolTip = objE_ParametroOnlineFFEE.Descripcion;
            }

            Cargar();


        }

        private void tlbMenu_NewClick()
        {
            //try
            //{
            //    frmManAnuncioEdit objManAnuncio = new frmManAnuncioEdit();
            //    objManAnuncio.lstAnuncio = mLista;
            //    objManAnuncio.pOperacion = frmManAnuncioEdit.Operacion.Nuevo;
            //    objManAnuncio.IdAnuncio = 0;
            //    objManAnuncio.StartPosition = FormStartPosition.CenterParent;
            //    objManAnuncio.ShowDialog();
            //    Cargar();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        if (!ValidarIngreso())
            //        {
            //            AnuncioBE objE_Anuncio = new AnuncioBE();
            //            objE_Anuncio.IdAnuncio = int.Parse(gvAnuncio.GetFocusedRowCellValue("IdAnuncio").ToString());
            //            objE_Anuncio.Usuario = Parametros.strUsuarioLogin;
            //            objE_Anuncio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //            objE_Anuncio.IdEmpresa = Parametros.intEmpresaId;

            //            AnuncioBL objBL_Anuncio = new AnuncioBL();
            //            objBL_Anuncio.Elimina(objE_Anuncio);
            //            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Cargar();
            //        }
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

            //    List<ReporteAnuncioBE> lstReporte = null;
            //    lstReporte = new ReporteAnuncioBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptAnuncio = new RptVistaReportes();
            //            objRptAnuncio.VerRptAnuncio(lstReporte);
            //            objRptAnuncio.ShowDialog();
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
            //string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            //string _fileName = "ListadoAnuncioes";
            //FolderBrowserDialog f = new FolderBrowserDialog();
            //f.ShowDialog(this);
            //if (f.SelectedPath != "")
            //{
            //    Cursor = Cursors.AppStarting;
            //    gvAnuncio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
            //    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
            //    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    Cursor = Cursors.Default;
            //}
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAnuncio_DoubleClick(object sender, EventArgs e)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ParametroBL objBL_Parametro = new ParametroBL();

            List<ParametroBE> lstParametro = null;
            lstParametro = new List<ParametroBE>();

            foreach (var item in mLista)
            {
                ParametroBE objE_Parametro = new ParametroBE();
                objE_Parametro.IdParametro = item.IdParametro;
                objE_Parametro.Valor = item.Valor;
                objE_Parametro.Numero = item.Numero;
                objE_Parametro.Descripcion = item.Descripcion;
                objE_Parametro.FlagEstado = true;
                lstParametro.Add(objE_Parametro);
            }

            objBL_Parametro.ActualizaLista(lstParametro);




            //Permitir Negativos
            objE_ParametroStock.FlagEstado = chkStockNegativo.Checked;
            objBL_Parametro.Actualiza(objE_ParametroStock);

            //Permitir Negativos Preventa
            objE_ParametroStockPreventa.FlagEstado = chkStockNegativoPreventa.Checked;
            objBL_Parametro.Actualiza(objE_ParametroStockPreventa);

            //Validar Reniec
            objE_ParametroValidaReniec.FlagEstado = chkConsultaReniec.Checked;
            objBL_Parametro.Actualiza(objE_ParametroValidaReniec);

            //Validar Sunat
            objE_ParametroValidaSunat.FlagEstado = chkConsultaSunat.Checked;
            objBL_Parametro.Actualiza(objE_ParametroValidaSunat);

            //Validar Stock Detalle Pedido
            objE_ParametroValidaStockDetallePedido.FlagEstado = chkValidarStockDetallePedido.Checked;
            objBL_Parametro.Actualiza(objE_ParametroValidaStockDetallePedido);

            //Validar PIN Pedido
            objE_ParametroValidarPINUsuario.FlagEstado = chkValidarPIN.Checked;
            objBL_Parametro.Actualiza(objE_ParametroValidarPINUsuario);

            //Validar Fecha Servidor
            objE_ParametroValidarFechaServidor.FlagEstado = chkValidarFechaServidor.Checked;
            objBL_Parametro.Actualiza(objE_ParametroValidarFechaServidor);

            //Impresión directo de pedidos
            objE_ParametroImpresionPedidoDirecto.FlagEstado = chkImpresionDirectaPedido.Checked;
            objBL_Parametro.Actualiza(objE_ParametroImpresionPedidoDirecto);

            //Impresión directo sp
            objE_ParametroImpresionSPDirecto.FlagEstado = chkImpresionDirectaSP.Checked;
            objBL_Parametro.Actualiza(objE_ParametroImpresionSPDirecto);

            //Online BBEE
            objE_ParametroOnlineBBEE.FlagEstado = chkOnlineBE.Checked;
            objBL_Parametro.Actualiza(objE_ParametroOnlineBBEE);

            //Online FFEE
            objE_ParametroOnlineFFEE.FlagEstado = chkOnlineFE.Checked;
            objBL_Parametro.Actualiza(objE_ParametroOnlineFFEE);

            XtraMessageBox.Show("Configuración guardada correctamente, Se recomienda Salir del Sistema para que los cambios surtan efecto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //string x = "";
            //foreach (Control c in Controls)
            //{
            //    if ((c is CheckBox) && ((CheckBox)c).Checked)
            //        x = c.Name + ", ";
            //    XtraMessageBox.Show(x, "ss");
            //}

            this.Close();

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ParametroBL().ListaNumero();
            gcSueldo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            //gcSueldo.DataSource = mLista.Where(obj =>
            //                                       obj.DescAnuncio.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            //if (gvSueldo.RowCount > 0)
            //{
            //    AnuncioBE objAnuncio = new AnuncioBE();
            //    objAnuncio.IdAnuncio = int.Parse(gvSueldo.GetFocusedRowCellValue("IdAnuncio").ToString());
            //    objAnuncio.Fecha = DateTime.Parse(gvSueldo.GetFocusedRowCellValue("Fecha").ToString());
            //    objAnuncio.DescAnuncio = gvSueldo.GetFocusedRowCellValue("DescAnuncio").ToString();
            //    objAnuncio.FlagEstado = Convert.ToBoolean(gvSueldo.GetFocusedRowCellValue("FlagEstado").ToString());

            //    frmManAnuncioEdit objManAnuncioEdit = new frmManAnuncioEdit();
            //    objManAnuncioEdit.pOperacion = frmManAnuncioEdit.Operacion.Modificar;
            //    objManAnuncioEdit.IdAnuncio = objAnuncio.IdAnuncio;
            //    objManAnuncioEdit.pAnuncioBE = objAnuncio;
            //    objManAnuncioEdit.StartPosition = FormStartPosition.CenterParent;
            //    objManAnuncioEdit.ShowDialog();

            //    Cargar();
            //}
            //else
            //{
            //    MessageBox.Show("No se pudo editar");
            //}
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

            //if (gvAnuncio.GetFocusedRowCellValue("IdAnuncio").ToString() == "")
            //{
            //    XtraMessageBox.Show("Seleccione Linea Producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    flag = true;
            //}

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion
    }
}