using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    public partial class frmConSaldos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EstadoCuentaBE> mLista = new List<EstadoCuentaBE>();

        #endregion

        #region "Eventos"

        public frmConSaldos()
        {
            InitializeComponent();
        }

        private void frmConSaldos_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
            //Cargar();
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

        private void toolstpExcel_Click(object sender, EventArgs e)
        {
            //string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            //string _fileName = "ListadoEstadoCuentaResumen_"+ cboTipoCliente.Text+ "_"+ cboMotivo.Text;
            //FolderBrowserDialog f = new FolderBrowserDialog();
            //f.ShowDialog(this);
            //if (f.SelectedPath != "")
            //{
            //    Cursor = Cursors.AppStarting;
            //    gvEstadoCuenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
            //    string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
            //    XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    Cursor = Cursors.Default;
            //}

            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEstadoCuentaResumen_" + cboTipoCliente.Text + "_" + cboMotivo.Text;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEstadoCuenta.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }

        }
        private void cboTipoCliente_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoCliente.EditValue) == Parametros.intTipClienteMayorista)
            {
                cboMotivo.Properties.ReadOnly = true;
                
            }
            else
            {
                cboMotivo.Properties.ReadOnly = true;
                //cboMotivo.EditValue = Parametros.intMotivoVenta;
                //cboMotivo.Properties.ReadOnly = true;
            }
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void verestadocuentatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEstadoCuenta.RowCount > 0)
                {
                    int IdCliente = 0;
                    IdCliente = int.Parse(gvEstadoCuenta.GetFocusedRowCellValue("IdCliente").ToString());

                    if (IdCliente.ToString() != "")
                    {
                        if (Convert.ToInt32(cboTipoCliente.EditValue) == Parametros.intTipClienteMayorista)
                        {
                            //var objE_EstadoCuenta;
                            EstadoCuentaBE objE_EstadoCuenta = null;
                            objE_EstadoCuenta = (EstadoCuentaBE)gvEstadoCuenta.GetFocusedRow();

                            //XtraMessageBox.Show(objE_EstadoCuenta.DescCliente +"   "+ objE_EstadoCuenta.Concepto, this.Text);

                            frmConEstadoCuenta frm = new frmConEstadoCuenta();
                            frm.IdCliente = IdCliente;
                            frm.NumeroDocumento = objE_EstadoCuenta.NumeroDocumento;
                            frm.DescCliente = objE_EstadoCuenta.DescCliente;
                            frm.IdMotivoVenta = Convert.ToInt32(cboMotivo.EditValue);
                            frm.Origen = 1;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                        else
                        {
                            //SeparacionBE objE_Separacion = null;
                            //objE_Separacion = (SeparacionBE)gvEstadoCuenta.GetFocusedRow();

                            frmConSeparacion frm = new frmConSeparacion();
                            frm.IdCliente = IdCliente;
                            frm.NumeroDocumento = gvEstadoCuenta.GetFocusedRowCellValue("NumeroDocumento").ToString();
                            frm.DescCliente = gvEstadoCuenta.GetFocusedRowCellValue("DescCliente").ToString();
                            frm.IdMotivoVenta = Convert.ToInt32(cboMotivo.EditValue);
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
                XtraMessageBox.Show(ex.Message + "\n Verificar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvEstadoCuenta_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvEstadoCuenta.RowCount.ToString() + " Registros";
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new EstadoCuentaBL().ListaClienteResumen
                (Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(DateTime.Now), Parametros.intEmpresaId, Convert.ToInt32(cboTipoCliente.EditValue) , 0, Convert.ToInt32(cboMotivo.EditValue));
            gcEstadoCuenta.DataSource = mLista;
            lblTotalRegistros.Text = gvEstadoCuenta.RowCount.ToString() +" Registros";
            CalcularTotalDocumentos();
        }

        private void CargarBusqueda()
        {
            gcEstadoCuenta.DataSource = mLista.Where(obj =>
                                                   obj.DescCliente.ToUpper().Contains(txtDescripcion.Text.ToUpper())
                                                   || obj.NumeroDocumento.ToUpper().Contains(txtDescripcion.Text.ToUpper())
                                                   ).ToList();
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvEstadoCuenta.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvEstadoCuenta.GetRowCellValue(i, (gvEstadoCuenta.Columns["Saldo"])));
                }
                txtTotal.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}