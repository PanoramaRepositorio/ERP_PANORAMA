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

namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    public partial class frmConEstadoCuentaComision : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EstadoCuentaComisionBE> mLista = new List<EstadoCuentaComisionBE>();

        int IdCliente = 0;

        #endregion

        #region "Eventos"

        public frmConEstadoCuentaComision()
        {
            InitializeComponent();
        }

        private void frmConEstadoCuentaComision_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = Convert.ToDateTime("01/01/2016");
            deHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    if (IdCliente == 0)
            //    {
            //        XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    if (gvEstadoCuenta.RowCount > 0)
            //    {
            //        List<ReporteEstadoCuentaComisionCabeceraBE> lstReporte = null;
            //        lstReporte = new ReporteEstadoCuentaComisionCabeceraBL().Listado(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));

            //        if (lstReporte != null)
            //        {
            //            //Listar el datalle del reporte

            //            List<ReporteEstadoCuentaComisionDetalleBE> lstReporteEstadoCuentaComisionDetalle = null;
            //            lstReporteEstadoCuentaComisionDetalle = new ReporteEstadoCuentaComisionDetalleBL().Listado(deDesde.DateTime, deHasta.DateTime, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptAccUsu = new RptVistaReportes();
            //                objRptAccUsu.VerRptEstadoCuentaComision(lstReporte, lstReporteEstadoCuentaComisionDetalle, cboMotivo.Text);
            //                objRptAccUsu.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        Cursor = Cursors.Default;
            //    }


            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEstadoCuentaComisión";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEstadoCuenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    btnConsultar.Focus();
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

                        ////Verificar TipoCliente
                        //if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                        //{
                        //    XtraMessageBox.Show("Atención! El cliente es MAYORISTA se recomienda registrar en el estado de cuenta Dolares", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new EstadoCuentaComisionBL().ListaCliente(deDesde.DateTime, deHasta.DateTime, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
            gcEstadoCuenta.DataSource = mLista;

            if (mLista.Count > 0)
            {
                decimal decTotalCargo = 0;
                decimal decTotalAbono = 0;
                decimal decSaldo = 0;

                foreach (var item in mLista)
                {
                    decTotalCargo = decTotalCargo + item.CreditoCargo;
                    decTotalAbono = decTotalAbono + item.PagoAbono;
                }

                txtTotalCargo.EditValue = decTotalCargo;
                txtTotalAbono.EditValue = decTotalAbono;
                decSaldo = decTotalCargo - decTotalAbono;
                txtSaldo.EditValue = decSaldo;
            }
        }

        #endregion




    }
}